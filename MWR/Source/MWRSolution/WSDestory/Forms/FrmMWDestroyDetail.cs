using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;
using ComLib.Log;
using YRKJ.MWR.Business;
using YRKJ.MWR.Business.WS;
using YRKJ.MWR.WSDestory.Business.Sys;
using YRKJ.MWR.WinBase.WinUtility;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWDestroyDetail : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWDestoryDetail";
        private FormMng _frmMng = null;
        private FrmMain _frmMain = null;
        private ScannerMng _scannerMng = null;

        private string _txnNum = "";
        private BindingList<GridTxnDetailData> _gridTxnDetailData = new BindingList<GridTxnDetailData>();
        private BindingManagerBase _bindingTxnDetailDataMng = null;

        private EnumOpyType _optType = EnumOpyType.NewDestroy;
        enum EnumOpyType { EditDestroy, NewDestroy }

        FrmMWDestroyDetail()
        {
            InitializeComponent();
            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.c_grdMWTxnDetail.AutoGenerateColumns = false;

            _scannerMng = new ScannerMng(this, ClassName, 
                SysParams.GetInstance().GetCrateCodeMask());
                //WinAppBase.CrateBarCodeMask);
            _scannerMng.CodeScanned += new ScannerMng.ScannedEventHandler(FrmMWDestroyDetail_CodeScanned);
            //_scannerMng.InvalidCodeScanned += new ScannerMng.ScannedEventHandler(FrmMWDestroyDetail_InvalidCodeScanned);
        }

        public FrmMWDestroyDetail(FrmMain f,string destroyTxnNum)
            : this()
        {
            _frmMain = f;
            _txnNum = destroyTxnNum;
            _optType = EnumOpyType.EditDestroy;
        }
        public FrmMWDestroyDetail(FrmMain f)
            : this()
        {
            _frmMain = f;
            _optType = EnumOpyType.NewDestroy;
        }

        #region Event
        private void FrmMWDestroyDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!InitFrm())
                    return;
                if (!InitCtrls())
                    return;

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestroyDetail_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWDestroyDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                c_time.Stop();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestroyDetail_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        private void FrmMWDestroyDetail_CodeScanned(string code)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";

                #region check crate exist cur txn
                GridTxnDetailData[] defineDatas = _gridTxnDetailData.Where(x => x.CrateCode.Equals(code)).ToArray();
                if (defineDatas.Length != 0)
                {
                    GridTxnDetailData curData = defineDatas[0];
                    TblMWTxnDetail detail = curData.ORGData;

                    for (int i = 0; i < _gridTxnDetailData.Count; i++)
                    {
                        if (_gridTxnDetailData[i].CrateCode.Equals(curData.CrateCode))
                        {
                            c_grdMWTxnDetail.Rows[i].Selected = true;
                            c_grdMWTxnDetail.CurrentCell = c_grdMWTxnDetail.Rows[i].Cells[0];
                            break;
                        }
                    }

                    if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Process)
                    {
                        TblMWInventory inv = null;
                        if (!TxnMng.GetInventroy(detail.InvRecordId, ref inv, ref errMsg))
                        {
                            MsgBox.Error(errMsg);
                            return;
                        }
                        if (inv == null)
                        {
                            MsgBox.Error(LngRes.MSG_CrateNoInventory);
                            return;
                        }
                        ShowDestroyCrate(inv);
                    }
                    else if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Wait)
                    {
                        AuthCrate(curData);
                    }
                    else
                    {
                        //nothing
                    }

                    return;
                }
                #endregion

                #region add new txn detail
                {
                    TblMWInventory inv = null;

                    if (!TxnMng.GetDestroyInventory(code, ref inv, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }
                    if (inv == null)
                    {
                        MsgBox.Error(LngRes.MSG_CrateNoInventory);
                        return;
                    }
                    ShowDestroyCrate(inv);
                }
                #endregion
               
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestroyDetail_CodeScanned", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }   
        }

        private void FrmMWDestroyDetail_Confirm(string code,decimal weight)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";
                string wsCode = SysInfo.GetInstance().Config.WSCode;
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
               
                GridTxnDetailData[] defineDatas = _gridTxnDetailData.Where(x => x.CrateCode.Equals(code)).ToArray();
                if (defineDatas.Length != 0)
                {
                    #region confirm recover crate to destroy
                    GridTxnDetailData curData = defineDatas[0];
                    TblMWTxnDetail detail = curData.ORGData;
                    if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Process)
                    {
                        if (!TxnMng.ConfirmRecoverCrateToDestroy(detail.TxnDetailId, weight, wsCode, empyCode, ref errMsg))
                        {
                            MsgBox.Error(errMsg);
                        }
                    }
                    else
                    {
                        //nothing
                    }
                    #endregion
                }
                else
                {
                    TblMWInventory inv = null;
                    if (!TxnMng.GetDestroyInventory(code, ref inv, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }

                    if (string.IsNullOrEmpty(_txnNum))
                    {
                        string newTxnNum = "";
                        #region add new destroy txn
                        if (!TxnMng.ConfirmCrateToDestroyNew(inv.InvRecordId, weight, wsCode, empyCode, ref newTxnNum, ref errMsg))
                        {
                            MsgBox.Error(errMsg);
                            return;
                        }
                        #endregion
                        _txnNum = newTxnNum;
                        c_txtDestNum.Text = newTxnNum;
                    }
                    else
                    {
                        #region edit current txn
                        if (!TxnMng.ConfirmCrateToDestroyEdit(inv.InvRecordId, _txnNum, weight, wsCode, empyCode, ref errMsg))
                        {
                            MsgBox.Error(errMsg);
                            return;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestroyDetail_Confirm", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }   
        }

        private void FrmMWDestroyDetail_Authorize(string code, decimal weight)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                 string errMsg = "";
                string wsCode = SysInfo.GetInstance().Config.WSCode;
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
               
                GridTxnDetailData[] defineDatas = _gridTxnDetailData.Where(x => x.CrateCode.Equals(code)).ToArray();
                if (defineDatas.Length != 0)
                {
                    #region confirm recover crate to authorize
                    GridTxnDetailData curData = defineDatas[0];
                    TblMWTxnDetail detail = curData.ORGData;
                    if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Process)
                    {
                        if (!TxnMng.ConfirmDestroyRecoverCrateToAuthorize(detail.TxnDetailId, weight, wsCode, empyCode, ref errMsg))
                        {
                            MsgBox.Error(errMsg);
                            return;
                        }
                    }
                    else
                    {
                        //nothing
                    }
                    #endregion
                }
                else
                {
                    TblMWInventory inv = null;
                    if (!TxnMng.GetDestroyInventory(code, ref inv, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }

                    int reInvAuthId = 0;
                    if (string.IsNullOrEmpty(_txnNum))
                    {
                        string newTxnNum = "";
                        #region add new destroy txn authorize
                        if(!TxnMng.ConfirmDestroyToAuthorizeNew(inv.InvRecordId, weight, wsCode, empyCode,ref reInvAuthId, ref newTxnNum, ref errMsg))
                        {
                            MsgBox.Error(errMsg);
                            return;
                        }
                        #endregion
                        _txnNum = newTxnNum;
                        c_txtDestNum.Text = newTxnNum;
                    }
                    else
                    {
                        #region edit current txn authorize
                        if (!TxnMng.ConfirmDestroyToAuthorizeEdit(inv.InvRecordId, _txnNum, weight, wsCode, empyCode,ref reInvAuthId, ref errMsg))
                        {
                            MsgBox.Error(errMsg);
                            return;
                        }
                        #endregion
                    }
                }
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestroyDetail_Authorize", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnManually_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_bindingTxnDetailDataMng.Position == -1)
                {
                    return;
                }

                string errMsg = "";
                GridTxnDetailData curData = _bindingTxnDetailDataMng.Current as GridTxnDetailData;
                if (curData.ORGData.Status.Equals(TblMWTxnDetail.STATUS_ENUM_Process))
                {
                    TblMWTxnDetail detail = curData.ORGData;
                    TblMWInventory inv = null;
                    if (!TxnMng.GetInventroy(detail.InvRecordId, ref inv, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }
                    if (inv == null)
                    {
                        MsgBox.Error(LngRes.MSG_CrateNoInventory);
                        return;
                    }
                    ShowDestroyCrate(inv);
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnManually_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (_bindingTxnDetailDataMng.Position == -1)
                {
                    return;
                }

                GridTxnDetailData curData = _bindingTxnDetailDataMng.Current as GridTxnDetailData;
                AuthCrate(curData);

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnCheck_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void c_btnDestDone_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";

                if (_gridTxnDetailData.Count == 0)
                {
                    MsgBox.Show(LngRes.MSG_EmptyDetail);
                    return;
                }

                if (!TxnMng.EndConfirmDestroyTxn(_txnNum, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }

                this.Close();
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY);
               
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnDestDone_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnStopDest_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();

                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY);
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStopDest_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!c_bgwRefTxnDetail.IsBusy)
                    c_bgwRefTxnDetail.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_time_Tick", ex);
            }
            finally
            {
            }
        }

        private void c_bgwRefTxnDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string errMsg = "";
                List<TblMWTxnDetail> dataList = null;
                if (!TxnMng.GetDetailList(_txnNum, ref dataList, ref errMsg))
                {
                    return;
                }
                ThreadSafe(() =>
                {
                    
                    foreach (TblMWTxnDetail data in dataList)
                    {
                        GridTxnDetailData[] defineDatas = _gridTxnDetailData.Where(x => x.TxnDetailId == data.TxnDetailId).ToArray();
                        GridTxnDetailData item = null;
                        if (defineDatas.Length == 0)
                        {
                            item = GridTxnDetailData.ConventDBDataToFormData(data);
                            _gridTxnDetailData.Add(item);
                        }
                        else
                        {
                            item = defineDatas[0];
                            item.UpdataDBDataToFormData(data);
                        }
                    }
                    c_grdMWTxnDetail.Refresh();
                    WinFn.ReadBingdingText(c_labCurTxnWeight);
                    WinFn.ReadBingdingText(c_labCurStatus);
                    WinFn.ReadBingdingEnabled(c_btnManually);
                    WinFn.ReadBingdingEnabled(c_btnCheck);

                });

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_bgwRefTxnDetail_DoWork", ex);
            }
            finally
            {
            }
        }

        #endregion

        #region Functions

        private bool InitFrm()
        {
            _bindingTxnDetailDataMng = this.BindingContext[_gridTxnDetailData];

            if (!LoadData())
                return false;
            

            return true;
        }

        private bool InitCtrls()
        {
            _bindingTxnDetailDataMng.PositionChanged += (sender, e) => {
                c_grpCurTxnDetail.Enabled = _bindingTxnDetailDataMng.Position == -1 ? false : true;
            };

            if (_optType == EnumOpyType.EditDestroy)
            {
                c_txtDestNum.Text = _txnNum;
            }

            if (_optType == EnumOpyType.NewDestroy)
            {
                c_txtDestNum.Text = "新建处置计划";
                c_grpCurTxnDetail.Enabled = false;
                //c_labCurStatus.Text = "";
            }

            c_txtCurCrateCode.DataBindings.Add("Text", _gridTxnDetailData, "CrateCode");
            c_labCurSubWeight.DataBindings.Add("Text", _gridTxnDetailData, "SubWeight");
            c_labCurTxnWeight.DataBindings.Add("Text", _gridTxnDetailData, "TxnWeight");
            c_labCurStatus.DataBindings.Add("Text", _gridTxnDetailData, "Status");

            c_btnCheck.DataBindings.Add("Enabled", _gridTxnDetailData, "NeedAuthorize");
            c_btnManually.DataBindings.Add("Enabled", _gridTxnDetailData, "CanConfirm");

            c_grdMWTxnDetail_C_CrateCode.DataPropertyName = "CrateCode";
            c_grdMWTxnDetail_C_Vendor.DataPropertyName = "Vendor";
            c_grdMWTxnDetail_C_Waste.DataPropertyName = "Waste";
            c_grdMWTxnDetail_C_SubWeight.DataPropertyName = "SubWeight";
            c_grdMWTxnDetail_C_TxnWeight.DataPropertyName = "TxnWeight";
            c_grdMWTxnDetail_C_EntryDate.DataPropertyName = "EntryDate";
            c_grdMWTxnDetail_C_Status.DataPropertyName = "Status";

            c_grdMWTxnDetail.DataSource = _gridTxnDetailData;

            SysHelper.SetCtrlUnitText(c_labUnit1, c_labUnit2, c_labUnit3, c_labUnit4);

            CalculateSumWeigthAndCount();
            c_time.Start();
            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";


            List<TblMWTxnDetail> detailList = null;
            if (!TxnMng.GetDetailList(_txnNum, ref detailList, ref errMsg))
            {
                MsgBox.Error(errMsg);
                return false;
            }
            foreach (TblMWTxnDetail data in detailList)
            {
                GridTxnDetailData item =
                GridTxnDetailData.ConventDBDataToFormData(data);
                _gridTxnDetailData.Add(item);
            }
            return true;
        }

        private void CalculateSumWeigthAndCount()
        {
            int totalQty = 0;
            decimal totalSubWeight = 0;
            decimal totalTxnWeight = 0;

            foreach (GridTxnDetailData data in _gridTxnDetailData)
            {
                totalQty++;
                totalSubWeight += data.SubWeight;
                totalTxnWeight += data.TxnWeight;
            }
            c_labTotalQty.Text = totalQty + "";
            c_labTotalSubWeigth.Text = totalSubWeight + "";
            c_labTotalTxnWeight.Text = totalTxnWeight + "";
        }
       
        private void ShowDestroyCrate(TblMWInventory inv)
        {
            decimal subWeight = 0;
            #region valid
            
            if (inv.Status == TblMWInventory.STATUS_ENUM_Recovered)
            {
                subWeight = inv.InvWeight;
            }
            else if (inv.Status == TblMWInventory.STATUS_ENUM_Posted)
            {
                subWeight = inv.PostWeight;
            }
            else if (inv.Status == TblMWInventory.STATUS_ENUM_Destroying)
            {
                subWeight = inv.PostWeight;
            }
            else
            {
                MsgBox.Error(LngRes.MSG_UnValidCrate);
                return;
            }
            #endregion

            FrmMWCrateView.FormViewData viewData =
                new FrmMWCrateView.FormViewData()
                {
                    CrateCode = inv.CrateCode,
                    Vendor = inv.Vendor,
                    Waste = inv.Waste,
                    SubWeight = subWeight
                };
            using (FrmMWCrateView f = new FrmMWCrateView(viewData))
            {
                f.OnAuthorizeClick = this.FrmMWDestroyDetail_Authorize;
                f.OnOkClick = this.FrmMWDestroyDetail_Confirm;

                DialogResult result = f.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                { }
                else if (result == System.Windows.Forms.DialogResult.Abort)
                { }
                else
                {
                    return;
                }
            }

            #region update view data

            string errMsg = "";
            TblMWTxnDetail newTxnDetail = null;
            if (!TxnMng.GetInventoryTxnDetail(inv.InvRecordId, _txnNum, ref newTxnDetail, ref errMsg))
            {
                MsgBox.Error(errMsg);
            }
            if (newTxnDetail == null)
            {
                MsgBox.Error(LngRes.MSG_NoDestroyTxn);
                return;
            }

            GridTxnDetailData[] defineArrayDatas =
            _gridTxnDetailData.Where(x => x.ORGData.InvRecordId == newTxnDetail.InvRecordId).ToArray();

           
            if (defineArrayDatas.Length != 0)
            {
                defineArrayDatas[0].UpdataDBDataToFormData(newTxnDetail);
              
            }
            else
            {
                GridTxnDetailData updateViewData = GridTxnDetailData.ConventDBDataToFormData(newTxnDetail);
                _gridTxnDetailData.Add(updateViewData);
            }
            c_grdMWTxnDetail.Refresh();
            WinFn.ReadBingdingText(c_labCurTxnWeight);
            WinFn.ReadBingdingText(c_labCurStatus);
            WinFn.ReadBingdingEnabled(c_btnManually);
            WinFn.ReadBingdingEnabled(c_btnCheck);
            CalculateSumWeigthAndCount();
           
            #endregion

        }

        private void AuthCrate(GridTxnDetailData curData)
        {
            if (!curData.ORGData.Status.Equals(TblMWTxnDetail.STATUS_ENUM_Wait))
            {
                return;
            }
            GridTxnDetailData txnDetail = curData;

            #region open form
            using (FrmMWCrateReview f = new FrmMWCrateReview(txnDetail.ORGData))
            {
                DialogResult result = f.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //check this list last txndetail,and close this txn

                    //int count = 0;
                    //if (!TxnMng.GetRecoverLeftDetailCount(_txnNum, ref count, ref errMsg))
                    //{
                    //    return false;
                    //}
                    //if (count == 0)
                    //{
                    //    if (!TxnMng.EndConfirmRecoverTxn(_txnNum, ref errMsg))
                    //    {
                    //        return false;
                    //    }

                    //    this.Close();
                    //    if (_frmMain != null)
                    //    {
                    //        _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVER);
                    //    }
                    //    return true;
                    //}
                }
                else
                {
                    return ;
                }
            }
            #endregion

            txnDetail.ORGData.Status = TblMWTxnDetail.STATUS_ENUM_Complete;
            txnDetail.ORGData.EntryDate = ComLib.db.SqlDBMng.GetDBNow();
            txnDetail.UpdataDBDataToFormData(txnDetail.ORGData);

            c_grdMWTxnDetail.Refresh();
            WinFn.ReadBingdingText(c_labCurTxnWeight);
            WinFn.ReadBingdingText(c_labCurStatus);
            WinFn.ReadBingdingEnabled(c_btnManually);
            WinFn.ReadBingdingEnabled(c_btnCheck);

            CalculateSumWeigthAndCount();
        }

        private void ThreadSafe(MethodInvoker method)
        {
            //try
            //{
            if (this.InvokeRequired)
            {
                this.Invoke(method);
            }
            else
            {
                method();
            }
            //}
            //catch (Exception ex)
            //{ }
        }
        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "医疗废物处置";
            public const string MSG_CrateNoInventory = "警告！当前处理货箱没有库存信息，请检查货箱来源";
            public const string MSG_NoDestroyTxn = "没有找到处置货箱记录";
            public const string MSG_UnValidCrate = "警告！库存中不存在当前货箱的入库或出库记录，请检查货箱来源";
            public const string MSG_EmptyDetail = "当前没有任何处置货箱，提交失败";
        }

        private class GridTxnDetailData
        {
            public int TxnDetailId = 0;
            //{
            //    get { return _txnDetailId; }
            //    set { _txnDetailId = value; }
            //}
            //TxnType
            //TxnNum
            //WSCode
            //EmpyName
            //EmpyCode

            public string CrateCode { get; set; }
            public string Vendor { get; set; }
            //VendorCode
            public string Waste { get; set; }
            //WasteCode
            public decimal SubWeight { get; set; }
            //TxnWeight
            public decimal TxnWeight { get; set; }
            public string EntryDate { get; set; }
            //InvRecordId
            //InvAuthId
            public string Status { get; set; }

            public bool NeedAuthorize
            {
                get { return Status == BizHelper.GetTxnDetailStatus(TblMWTxnDetail.STATUS_ENUM_Wait) ? true : false; }
            }
            public bool CanConfirm
            {
                get { return Status == BizHelper.GetTxnDetailStatus(TblMWTxnDetail.STATUS_ENUM_Process) ? true : false; }
            }

            public int AuthId = 0;

            public TblMWTxnDetail ORGData { get; set; }
            public static GridTxnDetailData ConventDBDataToFormData(TblMWTxnDetail data)
            {
                GridTxnDetailData item = new GridTxnDetailData();
                item.UpdataDBDataToFormData(data);
                return item;
            }
            public void UpdataDBDataToFormData(TblMWTxnDetail data)
            {
                ORGData = data;
                GridTxnDetailData item = this;
                TxnDetailId = data.TxnDetailId;
                //item.TxnType = data.TxnType;
                //item.TxnNum = data.TxnNum;
                //item.WSCode = data.WSCode;
                //item.EmpyName = data.EmpyName;
                //item.EmpyCode = data.EmpyCode;
                item.CrateCode = data.CrateCode;
                item.Vendor = data.Vendor;
                //item.VendorCode = data.VendorCode;
                item.Waste = data.Waste;
                //item.WasteCode = data.WasteCode;
                item.SubWeight = data.SubWeight;
                item.TxnWeight = data.TxnWeight;
                item.EntryDate = ComLib.ComFn.DateTimeToString(data.EntryDate, BizBase.GetInstance().DateTimeFormatString);
                //item.InvRecordId = data.InvRecordId;
                //item.InvAuthId = data.InvAuthId;
                item.Status = BizHelper.GetTxnDetailStatus(data.Status);
                item.AuthId = data.InvAuthId;
            }
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
