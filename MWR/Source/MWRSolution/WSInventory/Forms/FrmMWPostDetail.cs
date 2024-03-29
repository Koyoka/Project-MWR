﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;
using ComLib.Log;
using YRKJ.MWR.WinBase.WinUtility;
using YRKJ.MWR.Business;
using YRKJ.MWR.Business.WS;
using YRKJ.MWR.Business.Sys;
using YRKJ.MWR.WSInventory.Business.Sys;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMWPostDetail : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmPostDetail";
        private FormMng _frmMng = null;
        private FrmMain _frmMain = null;
        private ScannerMng _scannerMng = null;

        private string _txnNum = "";
        public enum PostTypeEnum { Nocare, New, Edit }
        private PostTypeEnum _postType = PostTypeEnum.Nocare;

        private BindingList<GridTxnDetailData> _gridTxnDetailData = new BindingList<GridTxnDetailData>();
        private BindingManagerBase _bindingTxnDetailDataMng = null;

        public FrmMWPostDetail()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            _scannerMng = new ScannerMng(this, ClassName, 
                SysParams.GetInstance().GetCrateCodeMask());
                //WinAppBase.CrateBarCodeMask);
            _scannerMng.CodeScanned += new ScannerMng.ScannedEventHandler(FrmMWPostDetail_CodeScanned);

            this.c_grdMWTxnDetail.AutoGenerateColumns = false;

        }
        public FrmMWPostDetail(FrmMain f)
            : this()
        {
            _frmMain = f;
            _postType = PostTypeEnum.New;
        }
        public FrmMWPostDetail(FrmMain f, string txnNum)
            : this()
        {
            _frmMain = f;
            _txnNum = txnNum;
            _postType = PostTypeEnum.Edit;
        }

        #region Event

        private void FrmMWPostDetail_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!InitFrm())
                {
                    return;
                }

                if (!InitCtrls())
                {
                    return;
                }

                c_time.Start();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWPostDetail_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWPostDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                c_time.Stop();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWPostDetail_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
            
        }

        private void FrmMWPostDetail_CodeScanned(string code)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";

                #region authorize txn detail
                GridTxnDetailData[] datas = _gridTxnDetailData.Where(x => x.CrateCode.Equals(code)).ToArray();
                if (datas.Length > 0)
                {
                    GridTxnDetailData curData = datas[0];
                    if (curData.ORGData.Status.Equals(TblMWTxnDetail.STATUS_ENUM_Wait))
                    {
                        AuthPost(curData);
                    }
                    else if (curData.ORGData.Status.Equals(TblMWTxnDetail.STATUS_ENUM_Complete)
                        || curData.ORGData.Status.Equals(TblMWTxnDetail.STATUS_ENUM_Authorize))
                    {
                        MsgBox.Show(LngRes.MSG_CurrentExistCrate);
                    }

                    return;
                }
                #endregion

                #region add new txn detail
                TblMWInventory inv = null;
                if (!TxnMng.GetRecoveredInventory(code, ref inv, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }

                if (inv == null)
                {
                    MsgBox.Show(LngRes.MSG_NoInventory);
                    return;
                }

                FrmMWCrateView frmMWCrateView = null;
                FrmMWCrateView.FormViewData viewData = 
                new FrmMWCrateView.FormViewData()
                {
                    CrateCode = inv.CrateCode,
                    Vendor = inv.Vendor,
                    Waste = inv.Waste,
                    SubWeight = inv.InvWeight,
                    DepotCode = inv.DepotCode
                };

                if (string.IsNullOrEmpty(_txnNum))
                {
                    frmMWCrateView = new FrmMWCrateView(inv.InvRecordId, viewData,
                           (newTxnNum) => {
                               _txnNum = newTxnNum;
                               c_txtPostNum.Text = newTxnNum;
                           });
                }
                else
                {
                    frmMWCrateView = new FrmMWCrateView(inv.InvRecordId,_txnNum, viewData);
                }
                using (FrmMWCrateView f = frmMWCrateView)
                {
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
                
                //using (FrmMWCrateView f = new FrmMWCrateView(inv.InvRecordId, _txnNum, new FrmMWCrateView.FormViewData()
                //{
                //    CrateCode = inv.CrateCode,
                //    Vendor = inv.Vendor,
                //    Waste = inv.Waste,
                //    SubWeight = inv.InvWeight,
                //    DepotCode = inv.DepotCode
                //}
                //))
                //{
                    
                //    DialogResult result = f.ShowDialog();

                //    if (result == System.Windows.Forms.DialogResult.OK)
                //    { }
                //    else if (result == System.Windows.Forms.DialogResult.Abort)
                //    { }
                //    else 
                //    {
                //        return;
                //    }
                //}
               

                TblMWTxnDetail invTxnDetail = null;
                if (!TxnMng.GetInventoryTxnDetail(inv.InvRecordId, _txnNum, ref invTxnDetail, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
                if (invTxnDetail == null)
                {
                    MsgBox.Error(LngRes.MSG_NoInventoryTxnDetail);
                    return;
                }

                GridTxnDetailData item = GridTxnDetailData.ConventDBDataToFormData(invTxnDetail);
                _gridTxnDetailData.Add(item);
                CalculateTotalWeight();
                #endregion
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWPostDetail_CodeScanned", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnStopPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Close();
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStopPost_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_gridTxnDetailData.Count == 0)
                {
                    MsgBox.Show(LngRes.MSG_TxnDetailIsEmpty);
                    return;
                }

                string errMsg = "";
                if(!TxnMng.EndConfirmPostTxn(_txnNum,ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return ;
                }

                this.Close();
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnPost_Click", ex);
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
                AuthPost(curData);
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

        private void c_bgwPostDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                GridTxnDetailData curData = null;
                if (_bindingTxnDetailDataMng.Position != -1)
                {
                    curData = _bindingTxnDetailDataMng.Current as GridTxnDetailData;
                }

                ThreadSafe(() =>
                {
                    string errMsg = "";
                    List<TblMWTxnDetail> dataList = null;
                    if (!TxnMng.GetDetailList(_txnNum, ref dataList, ref errMsg))
                    {
                        return;
                    }
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
                    WinFn.ReadBingdingText(c_labStatus);
                    WinFn.ReadBingdingEnabled(c_btnCheck);

                });

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_bgwPostDetail_DoWork", ex);
            }
            finally
            {
            }
        }

        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!c_bgwPostDetail.IsBusy)
                {
                    c_bgwPostDetail.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_time_Tick", ex);
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
            _bindingTxnDetailDataMng.PositionChanged += (sender, e) =>
            {
                c_grpCurrentData.Enabled = _bindingTxnDetailDataMng.Position == -1 ? false : true;
            };
            c_grpCurrentData.Enabled = _bindingTxnDetailDataMng.Position == -1 ? false : true;

            if (_postType == PostTypeEnum.Edit)
            {
                c_labPostType.Text = LngRes.MSG_PostType_Edit;
            }
            else
            {
                c_labPostType.Text = _postType == PostTypeEnum.Nocare ? LngRes.MSG_PostType_Nocare : LngRes.MSG_PostType_Normal;
            }

            c_txtPostNum.Text = _txnNum;

            SysHelper.SetCtrlUnitText(c_labUnit1, c_labUnit2, c_labUnit3, c_labUnit4);

            c_txtCrateCode.DataBindings.Add("Text", _gridTxnDetailData, "CrateCode");
            c_labStatus.DataBindings.Add("Text", _gridTxnDetailData, "Status");
            c_labSubWeight.DataBindings.Add("Text", _gridTxnDetailData, "SubWeight");
            c_labTxnWeight.DataBindings.Add("Text", _gridTxnDetailData, "TxnWeight");
            c_btnCheck.DataBindings.Add("Enabled", _gridTxnDetailData, "NeedAuthorize");//.Enabled

            #region add new txndetail form initCtrls
            if (_postType == PostTypeEnum.New)
            {
                c_txtPostNum.Text = "新建订单";
            }
            #endregion

            #region edit txndetail form initCtrls
            if (_postType == PostTypeEnum.Edit)
            {
               

                
            }
            #endregion

            //c_grdMWTxnDetail_C_TxnDetailId.DataPropertyName = "TxnDetailId";
            //c_grdMWTxnDetail_C_TxnType.DataPropertyName = "TxnType";
            //c_grdMWTxnDetail_C_TxnNum.DataPropertyName = "TxnNum";
            //c_grdMWTxnDetail_C_WSCode.DataPropertyName = "WSCode";
            //c_grdMWTxnDetail_C_EmpyName.DataPropertyName = "EmpyName";
            //c_grdMWTxnDetail_C_EmpyCode.DataPropertyName = "EmpyCode";
            c_grdMWTxnDetail_C_CrateCode.DataPropertyName = "CrateCode";
            c_grdMWTxnDetail_C_Vendor.DataPropertyName = "Vendor";
            //c_grdMWTxnDetail_C_VendorCode.DataPropertyName = "VendorCode";
            c_grdMWTxnDetail_C_Waste.DataPropertyName = "Waste";
            //c_grdMWTxnDetail_C_WasteCode.DataPropertyName = "WasteCode";
            c_grdMWTxnDetail_C_SubWeight.DataPropertyName = "SubWeight";
            c_grdMWTxnDetail_C_TxnWeight.DataPropertyName = "TxnWeight";
            c_grdMWTxnDetail_C_EntryDate.DataPropertyName = "EntryDate";
            //c_grdMWTxnDetail_C_InvRecordId.DataPropertyName = "InvRecordId";
            //c_grdMWTxnDetail_C_InvAuthId.DataPropertyName = "InvAuthId";
            c_grdMWTxnDetail_C_Status.DataPropertyName = "Status";
            //c_grdMWTxnDetail_C_TxnWeight

            c_grdMWTxnDetail.DataSource = _gridTxnDetailData;
            CalculateTotalWeight();
            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";
            string wsCode = SysInfo.GetInstance().Config.WSCode;
            string empyCode = SysInfo.GetInstance().Employ.EmpyCode;

            #region normal add new txndetail load data
            if (_postType == PostTypeEnum.New)
            {
                //_txnNum = MWNextIdMng
                //string txnNum = "";
                //if (!TxnMng.BeginOperatePostTxn(wsCode, empyCode, ref txnNum, ref errMsg))
                //{
                //    return false;
                //}
                //_txnNum = txnNum;
            }
            #endregion

            #region edit txndetail load data
            if (_postType == PostTypeEnum.Edit)
            {
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
            }
            #endregion

            return true;
        }

        private void CalculateTotalWeight()
        {
            decimal totalSubWeight = 0;
            decimal totalTxnWeight = 0;
            foreach (GridTxnDetailData data in _gridTxnDetailData)
            {
                totalSubWeight += data.SubWeight;
                totalTxnWeight += data.TxnWeight;
            }

            c_labTotalSubWeight.Text = totalSubWeight.ToString(BizBase.GetInstance().DecimalFormatString);
            c_labTotalTxnWeight.Text = totalTxnWeight.ToString(BizBase.GetInstance().DecimalFormatString);
            c_labTotalQty.Text = _gridTxnDetailData.Count + "";
        }

        private void AuthPost(GridTxnDetailData curData)
        {
            if (_bindingTxnDetailDataMng.Position == -1)
            {
                return;
            }

            if (!curData.ORGData.Status.Equals(TblMWTxnDetail.STATUS_ENUM_Wait))
            {
                MsgBox.Show(LngRes.MSG_NotCompleteAuthorize);
                return;
            }

            for (int i = 0; i < _gridTxnDetailData.Count; i++)
            {
                if (_gridTxnDetailData[i].CrateCode.Equals(curData.CrateCode))
                {
                    c_grdMWTxnDetail.Rows[i].Selected = true;
                    c_grdMWTxnDetail.CurrentCell = c_grdMWTxnDetail.Rows[i].Cells[0];
                    break;
                }
            }

            TblMWTxnDetail txnDetail = curData.ORGData;
            using (FrmMWCrateReview f = new FrmMWCrateReview(txnDetail))
            {
                DialogResult result = f.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    txnDetail.Status = TblMWTxnDetail.STATUS_ENUM_Complete;
                    txnDetail.EntryDate = ComLib.db.SqlDBMng.GetDBNow();
                    curData.UpdataDBDataToFormData(txnDetail);
                    c_grdMWTxnDetail.Refresh();
                    WinFn.ReadBingdingText(c_labStatus);
                    WinFn.ReadBingdingEnabled(c_btnCheck);
                }
            }
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
        
        public void ControlActivity()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.Focus();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "ControlActivity", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "出库计划";
            public const string MSG_PostType_Normal = "称重出库";
            public const string MSG_PostType_Nocare = "直接出库";
            public const string MSG_PostType_Edit = "审核出库";
            public const string MSG_NoInventory = "警告！没有找到当前货箱的库存信息，请确认货箱来源。";
            public const string MSG_NoInventoryTxnDetail = "没有生成出库交易";
            public const string MSG_CurrentExistCrate = "当前货箱已添加";
            public const string MSG_NotCompleteAuthorize = "当前交易货箱未完成审核";
            public const string MSG_TxnDetailIsEmpty = "提交失败，当前没有处理任何货箱";
        }

        private class GridTxnDetailData
        {
            //private int _txnDetailId = 0;
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
            private string _crateCode = "";
            public string CrateCode
            {
                get { return _crateCode; }
                set { _crateCode = value; }
            }

            private string _vendor = "";
            public string Vendor
            {
                get { return _vendor; }
                set { _vendor = value; }
            }
            //VendorCode
            private string _waste = "";
            public string Waste
            {
                get { return _waste; }
                set { _waste = value; }
            }
            //WasteCode
            private decimal _subWeight = 0;
            public decimal SubWeight
            {
                get { return _subWeight; }
                set { _subWeight = value; }
            }
            //TxnWeight
            private decimal _txnWeight = 0;
            public decimal TxnWeight
            {
                get { return _txnWeight; }
                set { _txnWeight = value; }
            }
            private string _entryDate = "";
            public string EntryDate
            {
                get { return _entryDate; }
                set { _entryDate = value; }
            }
            //InvRecordId
            //InvAuthId
            private string _status = "";
            public string Status
            {
                get { return _status; }
                set { _status = value; }
            }

            public bool NeedAuthorize
            {
                get { return _status == BizHelper.GetTxnDetailStatus(TblMWTxnDetail.STATUS_ENUM_Wait) ? true : false; }
            }
            public bool CanConfirm
            {
                get { return _status == BizHelper.GetTxnDetailStatus(TblMWTxnDetail.STATUS_ENUM_Process) ? true : false; }
            }

            public int AuthId = 0;

            #region data control
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
            #endregion
        }

        #endregion

        #region Form Data Property

        #endregion

      
    }
}
