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
using YRKJ.MWR.WinBase.WinUtility;
using YRKJ.MWR.Business.WS;
using YRKJ.MWR.WSInventory.Business.Sys;
using YRKJ.MWR.Business;
using ComLib.Error;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMWRecoverDetail : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWRecoverDetail";
        private FormMng _frmMng = null;
        private FrmMain _frmMain = null;
        private ScannerMng _scannerMng = null;
        private string _txnNum = "";

        private VewTxnHeaderWithCarDispatch _header = null;
        private List<TblMWTxnDetail> _detailList = null;
        private FromCtrlBindingData _bindingData = new FromCtrlBindingData();
        private TblMWDepot _defaultDepot = null;

        private BindingList<GridTxnDetailData> _gridTxnDetailData = new BindingList<GridTxnDetailData>();
        private BindingManagerBase _bindingTxnDetailDataMng = null;
       
        public FrmMWRecoverDetail()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.c_grdMWTxnDetail.AutoGenerateColumns = false;

          
        }

        public FrmMWRecoverDetail(FrmMain f, string recoNum)
            : this()
        {
            _frmMain = f;
            _txnNum = recoNum;

            _scannerMng = new ScannerMng(this, ClassName, WinAppBase.CrateBarCodeMask);
            _scannerMng.CodeScanned += new ScannerMng.ScannedEventHandler(FrmMWRecoverDetail_CodeScanned);
            _scannerMng.InvalidCodeScanned += new ScannerMng.ScannedEventHandler(FrmMWRecoverDetail_InvalidCodeScanned);
        }

        #region Event

        private void FrmMWRecoverDetail_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecoverDetail_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWRecoverDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                c_time.Stop();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecoverDetail_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";

                if (!TxnMng.EndConfirmTxn(_txnNum, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }

                this.Close();
                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVER);
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnRecover_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnStopRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.Close();
                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVER);
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStopRecover_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnSelectDepot_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //_detailList[0].Status = TblMWTxnDetail.STATUS_ENUM_Complete;
                //this.CalculateLastWeigthAndCount();
                //return;
                using (Dtl.FrmDepotDtl f = new Dtl.FrmDepotDtl())
                {
                    if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _defaultDepot = f.GetSelectDepot();
                        if (_defaultDepot != null)
                            c_txtDepot.Text = _defaultDepot.Desc;
                    }
                }
               
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnSelectDepot_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWRecoverDetail_InvalidCodeScanned(string code)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //MsgBox.Show(LngRes.MSG_InvalidBarCode + " " + code);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecoverDetail_InvalidCodeScanned", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void FrmMWRecoverDetail_CodeScanned(string code)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";
                TblMWTxnDetail txnDetail = null;
                if (!GetScannerTxnDetail(code,ref txnDetail, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }

                for (int i = 0; i < _gridTxnDetailData.Count; i++)
                {
                    if (_gridTxnDetailData[i].CrateCode.Equals(code))
                    {
                        c_grdMWTxnDetail.Rows[i].Selected = true;
                        c_grdMWTxnDetail.CurrentCell = c_grdMWTxnDetail.Rows[i].Cells[0];
                        break;
                    }
                }
                if (txnDetail.Status == TblMWTxnDetail.STATUS_ENUM_Wait)
                {
                    if (!AuthCrate(txnDetail, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                    }
                }
                else if (txnDetail.Status == TblMWTxnDetail.STATUS_ENUM_Process)
                {
                    if (!RecoverCrate(txnDetail, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                    }
                }
                else if(txnDetail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
                {
                    MsgBox.Show(LngRes.MSG_IsCompleteTxn);
                }
                else if (txnDetail.Status == TblMWTxnDetail.STATUS_ENUM_Authorize)
                {
                    MsgBox.Show(LngRes.MSG_IsAuthorizeTxn);
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecoverDetail_CodeScanned", ex);
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
                string errMsg = "";

                TblMWTxnDetail txnDetail = null;
                if (!GetCurrentSelectTxnDetail(ref txnDetail, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
                if (!RecoverCrate(txnDetail,ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
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
                string errMsg = "";
                TblMWTxnDetail txnDetail = null;
                if (!GetCurrentSelectTxnDetail(ref txnDetail, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
                if (!AuthCrate(txnDetail, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
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

        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!c_bgwRefTxnDetail.IsBusy)
                {
                    c_bgwRefTxnDetail.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_time_Tick", ex);
                MsgBox.Error(ex);
            }
            finally
            {
            }
        }

        private void c_bgwRefTxnDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                GridTxnDetailData curData = null;

                if (_bindingTxnDetailDataMng.Position != -1)
                {
                    curData = _bindingTxnDetailDataMng.Current as GridTxnDetailData;
                }

                ThreadSafe(() => {
                    string errMsg = "";
                    List<TblMWTxnDetail> dataList = null;
                    if (!TxnMng.GetRecoverDetail(_txnNum, ref dataList, ref errMsg))
                    {
                        return ;
                    }
                    //CalculateLastWeigthAndCount();
                    foreach (TblMWTxnDetail data in dataList)
                    {
                        GridTxnDetailData item =  _gridTxnDetailData.Where(x => x.TxnDetailId == data.TxnDetailId).First();
                        if (item == null)
                        {
                            item = GridTxnDetailData.ConventDBDataToFormData(data);
                            _gridTxnDetailData.Add(item);
                        }
                        else
                        {
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
            c_grpRecoInfo.Text += "-流水号：" + _txnNum;

            if (_header == null)
            {
                return true;
            }
            c_labCarCode.Text = _header.CarCode;
            c_labDriver.Text = _header.Driver;
            c_labInspector.Text = _header.Inspector;
            c_labEmpy.Text = SysInfo.GetInstance().Employ.EmpyName;
            c_labOutDate.Text = ComLib.ComFn.DateTimeToString(_header.OutDate, "yyyy-MM-dd HH:mm");
            c_labIndate.Text = ComLib.ComFn.DateTimeToString(_header.InDate, "yyyy-MM-dd HH:mm");
            c_labHeaderStatus.Text = BizHelper.GetTxnRecoverHeaderStatus(_header.Status);

            c_txtDepot.Text = _defaultDepot.Desc;

            c_labSubTotalQty.Text = _header.TotalCrateQty + "";
            c_labSubTotalWeight.Text = _header.TotalSubWeight + "";


            c_labTxnTotalQty.DataBindings.Add("Text", _bindingData, FromCtrlBindingData.TxnTotalQtyName);
            c_labTxnTotalWeigth.DataBindings.Add("Text", _bindingData, FromCtrlBindingData.TxnTotalWeightName);
            c_labLeftCount.DataBindings.Add("Text", _bindingData, FromCtrlBindingData.LeftCrateQtyName);
                       
            c_txtCurCrateCode.DataBindings.Add("Text", _gridTxnDetailData, "CrateCode");
            c_labCurSubWeight.DataBindings.Add("Text", _gridTxnDetailData, "SubWeight");
            c_labCurStatus.DataBindings.Add("Text", _gridTxnDetailData, "Status");
            c_labCurTxnWeight.DataBindings.Add("Text", _gridTxnDetailData, "TxnWeight");
            c_btnCheck.DataBindings.Add("Enabled", _gridTxnDetailData, "NeedAuthorize");
            c_btnManually.DataBindings.Add("Enabled", _gridTxnDetailData, "CanConfirm");

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
           
            SysHelper.SetCtrlUnitText(c_labUnit1, c_labUnit2, c_labUnit3, c_labUnit4);
            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";

            
            List<TblMWDepot> depotDataList = null;
            if (!SysCacheData.GetInstance().GetDepotList(ref depotDataList, ref errMsg))
            {
                MsgBox.Error(errMsg);
                return false;
            }
            if (depotDataList.Count != 0)
            {
                _defaultDepot = depotDataList[0];
            }
            if (_defaultDepot == null)
            {
                MsgBox.Error(LngRes.MSG_NoDepotData);
                return false;
            }
           
            if (!TxnMng.GetRecoverHeaderAndDetail(_txnNum, ref _header, ref _detailList, ref errMsg))
            {
                MsgBox.Error(errMsg);

                return false;
            }

            CalculateLastWeigthAndCount();
            foreach (TblMWTxnDetail data in _detailList)
            {
                GridTxnDetailData item = 
                GridTxnDetailData.ConventDBDataToFormData(data);
                _gridTxnDetailData.Add(item);
            }
            return true;
        }

        private void CalculateLastWeigthAndCount()
        {
            int txnTotalQty = 0;
            decimal txnTotalWeight = 0; 
            foreach (TblMWTxnDetail dtl in _detailList)
            {
                if (dtl.Status.Equals(TblMWTxnDetail.STATUS_ENUM_Complete))
                {
                    txnTotalQty++;
                    txnTotalWeight += dtl.TxnWeight;
                }
            }
            _bindingData.TxnTotalQty = txnTotalQty;
            _bindingData.TxnTotalWeight = txnTotalWeight;
            _bindingData.LeftCrateQty = _header.TotalCrateQty - _bindingData.TxnTotalQty;

            WinFn.ReadBingdingText(c_labTxnTotalQty);
            WinFn.ReadBingdingText(c_labTxnTotalWeigth);
            WinFn.ReadBingdingText(c_labLeftCount);
        }

        private bool GetScannerTxnDetail(string crateCode,ref TblMWTxnDetail txnDetail, ref string errMsg)
        {
            foreach (TblMWTxnDetail dtl in _detailList)
            {
                if (dtl.CrateCode == crateCode)
                {
                    txnDetail = dtl;
                    break;
                }
            }
            if (txnDetail == null)
            {
                errMsg = LngRes.MSG_NoNoCrateInTxn;
                return false;
            }
            return true;
        }
        private bool GetCurrentSelectTxnDetail(ref TblMWTxnDetail txnDetail, ref string errMsg)
        {
            if (_bindingTxnDetailDataMng.Position == -1)
            {
                errMsg = LngRes.MSG_NoTxnDetailData;
                return false;
            }
            GridTxnDetailData data = _bindingTxnDetailDataMng.Current as GridTxnDetailData;
                //c_grdMWTxnDetail.CurrentRow.DataBoundItem as GridTxnDetailData;
            if (data == null)
            {
                ErrorMng.GetCodingError(ClassName, "c_btnManually_Click", "对象查找错误");
                return false;
            }

            foreach (TblMWTxnDetail dtl in _detailList)
            {
                if (dtl.TxnDetailId == data.TxnDetailId)
                {
                    txnDetail = dtl;
                    break;
                }
            }
            if (txnDetail == null)
            {
                ErrorMng.GetCodingError(ClassName, "c_btnManually_Click", "数据源查找错误");
                return false;
            }
            return true;
        }

        private bool AuthCrate(TblMWTxnDetail txnDetail,ref string errMsg)
        {
            #region valid data
            if (_defaultDepot == null)
            {
                errMsg = LngRes.MSG_NoSelectDepot;
                return false;
            }
            if (txnDetail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
            {
                errMsg = LngRes.MSG_IsCompleteTxn;
                return false;
            }
            //if (txnDetail.Status == TblMWTxnDetail.STATUS_ENUM_Authorize)
            //{
            //    errMsg = LngRes.MSG_IsAuthorizeTxn;
            //    return false;
            //}
            #endregion

            #region open form
            using (FrmMWCrateReview f = new FrmMWCrateReview(txnDetail, _defaultDepot.DeptCode))
            {
                DialogResult result = f.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //check this list last txndetail,and close this txn

                    int count = 0;
                    if (!TxnMng.GetRecoverLeftDetailCount(_txnNum, ref count, ref errMsg))
                    {
                        return false;
                    }
                    if (count == 0)
                    {
                        if (!TxnMng.EndConfirmTxn(_txnNum, ref errMsg))
                        {
                            return false;
                        }

                        this.Close();
                        if (_frmMain != null)
                        {
                            _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVER);
                        }
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            #endregion

            #region up return form data
            GridTxnDetailData curData = null;

            curData = _gridTxnDetailData.Where(x => x.TxnDetailId == txnDetail.TxnDetailId).First();

            if (curData == null)
            {
                errMsg = LngRes.MSG_SysDataError;
                return false;
            }

            #region update grid binding data
            curData.TxnWeight = txnDetail.TxnWeight;
            curData.AuthId = txnDetail.InvAuthId;
            curData.EntryDate = ComLib.ComFn.DateTimeToString(txnDetail.EntryDate,BizBase.GetInstance().DateTimeFormatString);
            curData.Status = BizHelper.GetTxnDetailStatus(txnDetail.Status);
            #endregion

            #region set current ctrl view
            c_grdMWTxnDetail.Refresh();
            WinFn.ReadBingdingText(c_labCurTxnWeight);
            WinFn.ReadBingdingText(c_labCurStatus);
            WinFn.ReadBingdingEnabled(c_btnManually);
            WinFn.ReadBingdingEnabled(c_btnCheck);
            #endregion

            #region set report data
            CalculateLastWeigthAndCount();
            #endregion
            #endregion
            return true;
        }
        private bool RecoverCrate(TblMWTxnDetail txnDetail,ref string errMsg)
        {
            #region valid data
            if (_defaultDepot == null)
            {
                errMsg = LngRes.MSG_NoSelectDepot;
                return false;
            }
            if (txnDetail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
            {
                errMsg = LngRes.MSG_IsCompleteTxn;
                return false;
            }
            if (txnDetail.Status == TblMWTxnDetail.STATUS_ENUM_Authorize)
            {
                errMsg = LngRes.MSG_IsAuthorizeTxn;
                return false;
            }
            #endregion

            #region open form 
            using (FrmMWCrateView f = new FrmMWCrateView(txnDetail, _defaultDepot.DeptCode))
            {
                DialogResult result = f.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    //check this list last txndetail,and close this txn

                    int count = 0;
                    if (!TxnMng.GetRecoverLeftDetailCount(_txnNum, ref count, ref errMsg))
                    {
                        return false;
                    }
                    if (count == 0)
                    {
                        if (!TxnMng.EndConfirmTxn(_txnNum, ref errMsg))
                        {
                            return false;
                        }

                        this.Close();
                        if (_frmMain != null)
                        {
                            _frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVER);
                        }
                        return true;
                    }
                }
                else if (result == System.Windows.Forms.DialogResult.Abort)
                {
                    // nothing
                }
                else if(result == System.Windows.Forms.DialogResult.Cancel)
                {
                    return true;
                }

            }
            #endregion

            #region up return form data 
            GridTxnDetailData curData = null;

            curData = _gridTxnDetailData.Where(x => x.TxnDetailId == txnDetail.TxnDetailId).First();
            
            if (curData == null)
            {
                errMsg = LngRes.MSG_SysDataError;
                return false;
            }

            #region update grid binding data
            curData.TxnWeight = txnDetail.TxnWeight;
            curData.AuthId = txnDetail.InvAuthId;
            curData.EntryDate = ComLib.ComFn.DateTimeToString(txnDetail.EntryDate, BizBase.GetInstance().DateTimeFormatString);
            curData.Status = BizHelper.GetTxnDetailStatus(txnDetail.Status);
            #endregion

            #region set current ctrl view
            c_grdMWTxnDetail.Refresh();
            WinFn.ReadBingdingText(c_labCurTxnWeight);
            WinFn.ReadBingdingText(c_labCurStatus);
            WinFn.ReadBingdingEnabled(c_btnManually);
            WinFn.ReadBingdingEnabled(c_btnCheck);
            #endregion

            #region set report data
            CalculateLastWeigthAndCount();
            #endregion
            #endregion
            return true;
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
            public const string MSG_FormName = "废物货箱回收";
            public const string MSG_InvalidBarCode = "无效的条形码，请重新扫描";
            public const string MSG_NoDepotData = "没有仓库数据，请联系管理员添加";
            public const string MSG_NoSelectDepot = "请选择当前货箱入库的仓库";
            public const string MSG_SysDataError = "加载数据错误，请重新选择";
            public const string MSG_IsCompleteTxn = "当前货箱已入库";
            public const string MSG_IsAuthorizeTxn = "当前货箱正在审核中";
            public const string MSG_NoTxnDetailData = "没有选择任何货箱数据";
            public const string MSG_NoNoCrateInTxn = "当前提交计划批次中，不包含此货箱";
        
        }

        private class FromCtrlBindingData
        {
            public const string LeftCrateQtyName = "LeftCrateQty";
            private int _leftCrateQty = 0;
            public int LeftCrateQty
            {
                get { return _leftCrateQty; }
                set { _leftCrateQty = value; }
            }

            public const string TxnTotalQtyName = "TxnTotalQty";
            private int _txnTotalQty = 0;
            public int TxnTotalQty
            {
                get { return _txnTotalQty; }
                set { _txnTotalQty = value; }
            }

            public const string TxnTotalWeightName = "TxnTotalWeight";
            private decimal _txnTotalWeight = 0;
            public decimal TxnTotalWeight
            {
                get { return _txnTotalWeight; }
                set { _txnTotalWeight = value; }
            }

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

            public static GridTxnDetailData ConventDBDataToFormData(TblMWTxnDetail data)
            {
                GridTxnDetailData item = new GridTxnDetailData();
                item.UpdataDBDataToFormData(data);
                return item;
            }
            public  void UpdataDBDataToFormData(TblMWTxnDetail data)
            {
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
