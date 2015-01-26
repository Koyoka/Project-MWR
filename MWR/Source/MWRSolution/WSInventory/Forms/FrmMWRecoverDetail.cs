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
        private string _depotCode = "";

        private VewTxnHeaderWithCarDispatch _header = null;
        private List<TblMWTxnDetail> _detailList = null;
        private FromCtrlBindingData _bindingData = new FromCtrlBindingData();

        private BindingList<GridTxnDetailData> _gridTxnDetailData = new BindingList<GridTxnDetailData>();
       
        public FrmMWRecoverDetail()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          
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
               
        private void c_btnRecover_Click(object sender, EventArgs e)
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

                using (Dtl.FrmDepotDtl f = new Dtl.FrmDepotDtl())
                {
                    f.ShowDialog();
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

                RecoverCrate(txnDetail);
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
                RecoverCrate(txnDetail);

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
                
                using (FrmMWCrateReview f = new FrmMWCrateReview())
                {
                    f.ShowDialog();
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

            c_labSubTotalQty.Text = _header.TotalCrateQty + "";
            c_labSubTotalWeight.Text = _header.TotalSubWeight + "";


            //c_labTxnTotalQty.DataBindings.Add("Text", _bindingData, FromCtrlBindingData.TxnTotalQtyName);
            //c_labTxnTotalWeigth.DataBindings.Add("Text", _bindingData, FromCtrlBindingData.TxnTotalWeightName);
            //c_labLastCount.DataBindings.Add("Text", _bindingData, FromCtrlBindingData.LastCrateQtyName);

            c_labTxnTotalQty.Text = _bindingData.TxnTotalQty + "";
            c_labTxnTotalWeigth.Text = _bindingData.TxnTotalWeight + "";
            c_labLastCount.Text = _bindingData.LastCrateQty + "";

            c_txtCurCrateCode.DataBindings.Add("Text", _gridTxnDetailData, "CrateCode");
            c_labCurSubWeight.DataBindings.Add("Text", _gridTxnDetailData, "SubWeight");
            c_labCurStatus.DataBindings.Add("Text", _gridTxnDetailData, "Status");
            c_labCurTxnWeight.DataBindings.Add("Text", _gridTxnDetailData, "TxnWeight");

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
            
            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";
           
            if (!TxnMng.GetRecoverHeaderAndDetail(_txnNum, ref _header, ref _detailList, ref errMsg))
            {
                return false;
            }

            //_bindingData.Add(new FromCtrlBindingData());
            CalculateLastWeigthAndCount();
            SetGridTxnDetailBindingData();

            return true;
        }

        private void SetGridTxnDetailBindingData()
        {
            
            foreach (TblMWTxnDetail data in _detailList)
            {
                GridTxnDetailData item = new GridTxnDetailData();
                item.TxnDetailId = data.TxnDetailId;
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
                item.EntryDate = ComLib.ComFn.DateTimeToString(data.EntryDate,"yyyy-MM-dd HH:mm");
                //item.InvRecordId = data.InvRecordId;
                //item.InvAuthId = data.InvAuthId;
                item.Status = BizHelper.GetTxnDetailStatus(data.Status);

                _gridTxnDetailData.Add(item);
            }

        }

        private void CalculateLastWeigthAndCount()
        {
            _bindingData.TxnTotalQty = 0;
            _bindingData.TxnTotalWeight = 0;
            foreach (TblMWTxnDetail dtl in _detailList)
            {
                if (dtl.Status.Equals(TblMWTxnDetail.STATUS_ENUM_Complete))
                {
                    _bindingData.TxnTotalQty++;
                    _bindingData.TxnTotalWeight += dtl.TxnWeight;
                }
            }

            _bindingData.LastCrateQty = _header.TotalCrateQty - _bindingData.TxnTotalQty;
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
                errMsg = "当前提交计划批次中，不包含此货箱";
                return false;
            }
            return true;
        }
        private bool GetCurrentSelectTxnDetail(ref TblMWTxnDetail txnDetail, ref string errMsg)
        {
            GridTxnDetailData data = c_grdMWTxnDetail.CurrentRow.DataBoundItem as GridTxnDetailData;
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
       
        private void RecoverCrate(TblMWTxnDetail txnDetail)
        {
            using (FrmMWCrateView f = new FrmMWCrateView(txnDetail,_depotCode))
            {
                DialogResult result = f.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                  
                }

            }
            GridTxnDetailData curData = null;

            curData = _gridTxnDetailData.Where(x => x.TxnDetailId == txnDetail.TxnDetailId).First();
            //foreach(GridTxnDetailData data in _gridTxnDetailData)
            //{
            //    if (data.TxnDetailId == txnDetail.TxnDetailId)
            //    {
            //        curData = data;
            //        break;
            //    }
            //}
            if (curData == null)
            {
                return;
            }

            #region update grid binding data
            curData.TxnWeight = txnDetail.TxnWeight;
            curData.Status = BizHelper.GetTxnDetailStatus(txnDetail.Status);
            #endregion

            #region set current ctrl view
            c_grdMWTxnDetail.Refresh();
            c_labCurTxnWeight.Text = curData.TxnWeight + "";
            c_labCurStatus.Text = curData.Status;
            #endregion

            #region set report data
            CalculateLastWeigthAndCount();
            c_labTxnTotalQty.Text = _bindingData.TxnTotalQty + "";
            c_labTxnTotalWeigth.Text = _bindingData.TxnTotalWeight + "";
            c_labLastCount.Text = _bindingData.LastCrateQty + "";
            #endregion
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "废物货箱回收";
            public const string MSG_InvalidBarCode = "无效的条形码，请重新扫描";
        }

        private class FromCtrlBindingData
        {
            //public const string LastCrateQtyName = "LastCrateQty";
            private int _lastCrateQty = 0;
            public int LastCrateQty
            {
                get { return _lastCrateQty; }
                set { _lastCrateQty = value; }
            }

            //public const string TxnTotalQtyName = "TxnTotalQty";
            private int _txnTotalQty = 0;
            public int TxnTotalQty
            {
                get { return _txnTotalQty; }
                set { _txnTotalQty = value; }
            }

            //public const string TxnTotalWeightName = "TxnTotalWeight";
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
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
