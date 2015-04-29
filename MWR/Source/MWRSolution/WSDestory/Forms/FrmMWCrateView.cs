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
using YRKJ.MWR.Business.WS;
using YRKJ.MWR.WinBase.WinUtility;
using YRKJ.MWR.Business;
using YRKJ.MWR.WSDestory.Business.Sys;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWCrateView : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWCrateDetail";
        private FormMng _frmMng = null;
        private ScalesMng _scalesMng = null;

        private decimal _txnWeight = 0;
        private decimal _allowDiffWeight = 1;
        
        private FormViewData _formViewData = null;
        
        //private string _txnNum = "";
        //private int _invRecordId = 0;
        //private int _txnDetailId = 0;
       
        //private DelegateConfirmDestroyNew _confirmDestroyNew = null;
        public DelegateOnOkClick OnOkClick = null;
        public DelegateOnAuthorizeClick OnAuthorizeClick = null;
        public DelegateOnCancelClick OnCancelClick = null;
        
        //private enum EnumOpyType { New, Edit ,Default}
        //public enum EnumDestoryType { Recover, Inventory, Default }



        //private EnumOpyType _optType = EnumOpyType.Default;
        //private EnumDestoryType _destType = EnumDestoryType.Default;

        FrmMWCrateView()
        {
            InitializeComponent();
            
            _frmMng = new FormMng(this, ClassName, FormMng.EscExistEnum.YES);

            this.Text = LngRes.MSG_FormName;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        public FrmMWCrateView( FormViewData viewData)
            :this()
        {
            _formViewData = viewData;
            //_invRecordId = invRecordId;
            //_confirmDestroyNew = confirmDestroyNew;
            //_optType = EnumOpyType.New;
        }
        //public FrmMWCrateView(int invRecordId, string txnNum, FormViewData viewData)
        //    : this()
        //{
        //    _formViewData = viewData;
        //    _invRecordId = invRecordId;
        //    _txnNum = txnNum;
        //    _optType = EnumOpyType.Edit;
        //}

    
        #region Event

        private void FrmMWCrateView_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWCrateView_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWCrateView_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _scalesMng.Close();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWCrateView_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWCrateView_onScalesDataReceived2(string status, string lable, decimal weight, string unit) 
        {
            c_labScalesStatus.Text = "称重关闭 ";
            _txnWeight = BizHelper.ConventToSysUnitWeight(weight, unit, SysParams.GetInstance().GetSysWeightUnit());
            if (!confirmScaleWieght(_txnWeight))
            {
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        private void FrmMWCrateView_onScalesDataReceived(string status, string lable, decimal weight, string unit, bool isComplete)
        {
            //ThreadSafe(() => {
            //_txnWeight = BizHelper.ConventToSysUnitWeight(weight, unit, SysParams.GetInstance().GetSysWeightUnit());
            if (isComplete)
            {
                c_labScalesStatus.Text = "称重关闭";
            }
            else// if (status.ToLower() == "us")
                c_labScalesStatus.Text = "称重中.....";
            //else if (status.ToLower() == "st")
            //    c_labScalesStatus.Text = "当前重量 ";
            c_labTxnWeight.Text = weight.ToString("f2") + " " + SysParams.GetInstance().GetSysWeightUnit();

            //});

        }

        private bool confirmScaleWieght(decimal weight)
        {
            string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
            string empyName = SysInfo.GetInstance().Employ.EmpyName;
            string wsCode = SysInfo.GetInstance().Config.WSCode;
         
            if (Math.Abs(_formViewData.SubWeight - weight) > _allowDiffWeight)
            {
                MsgBox.Error(LngRes.MSG_DiffWeight);
                return false;
            }

            if (OnOkClick != null)
                OnOkClick(_formViewData.CrateCode, weight);

            return true;
        }
        private void c_btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _scalesMng.Strat();
#if DEBUG
                //_txnWeight = 1.23M;
#endif
                //decimal weight = _txnWeight;
                //if (!confirmScaleWieght(weight))
                //{
                //    _scalesMng.Strat();
                //    return;
                //}

                //string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                //string empyName = SysInfo.GetInstance().Employ.EmpyName;
                //string wsCode = SysInfo.GetInstance().Config.WSCode;
               
                //if (Math.Abs(_formViewData.SubWeight - weight) > _allowDiffWeight)
                //{
                //    MsgBox.Error(LngRes.MSG_DiffWeight);
                //    return;
                //}

                //if (OnOkClick != null)
                //    OnOkClick(_formViewData.CrateCode, weight);

                //this.DialogResult = System.Windows.Forms.DialogResult.OK;

                //this.Close();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnOk_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnError_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
//#if DEBUG
//                _txnWeight = 1.23M;
//#endif
                string errMsg = "";
                decimal weight = _txnWeight;
                string unit = SysParams.GetInstance().GetSysWeightUnit();
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                string wsCode = SysInfo.GetInstance().Config.WSCode;
                if (!MsgBox.Confirm("警告", "当前称重[" + weight + " " + unit + "],实际重量[" + _formViewData.SubWeight + "]确定提交审核么？"))
                {
                    return;
                }

                if (OnAuthorizeClick != null)
                    OnAuthorizeClick(_formViewData.CrateCode,weight);

                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnError_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (OnCancelClick != null)
                    OnCancelClick();
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnCancel_Click", ex);
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
            _scalesMng = new ScalesMng(this);
            
            _scalesMng.onConnected = () => {
                c_labScalesStatus.Text = "等待称重";
            };
            _scalesMng.onDisConnected = () => {
                c_labScalesStatus.Text = "请链接台秤";
            };
            _scalesMng.onScalesDataReceived = FrmMWCrateView_onScalesDataReceived;
            _scalesMng.onScalesDataReceivedAuto = FrmMWCrateView_onScalesDataReceived2;
            if (!LoadData())
                return false;
            
            return true;
        }

        private bool InitCtrls()
        {
            c_labScalesStatus.Text = "请链接台秤";

            this.c_txtCrateCode.Text = _formViewData.CrateCode;
            this.c_labVendor.Text = _formViewData.Vendor;
            this.c_labWaster.Text = _formViewData.Waste;
            this.c_labSubWeight.Text = _formViewData.SubWeight.ToString(BizBase.GetInstance().DecimalFormatString)+SysParams.GetInstance().GetSysWeightUnit();

            SysHelper.SetCtrlUnitText(this.c_labSysUnit);

            if (!_scalesMng.Strat())
            {
                MsgBox.Show(LngRes.MSG_NoConnScales);
            }

            return true;
        }

        private bool LoadData()
        {

            bool pDiffWeightAsIdentical = MWParams.GetAllowDiffWeightAsIdentical();
            decimal defineDiffWeight = 0;
            if (pDiffWeightAsIdentical)
            {
                defineDiffWeight = MWParams.GetAllowDiffWeight_All();
            }
            else {
                defineDiffWeight = MWParams.GetAllowDiffWeight_Destory();
            }

//#if DEBUG
//            if (_scalesMng.IsOpen)
//                _allowDiffWeight = defineDiffWeight;//SysParams.GetInstance().GetAllowDiffWeight();
//            else
//                _allowDiffWeight = 100;
//#else
             _allowDiffWeight = defineDiffWeight;//SysParams.GetInstance().GetAllowDiffWeight();
//#endif
            return true;
        }

        //public FormReturnData GetFormData()
        //{
        //    return _formReturnData;
        //}
        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "周转箱称重";
            public const string MSG_DiffWeight = "提交重量与回收重量不符，请提交审核";
            public const string MSG_NoConnScales = "电子秤未连接";
        }

        public class FormViewData
        {
            
            public string CrateCode { get; set; }
            public string Vendor { get; set; }
            public string Waste { get; set; }
            public decimal SubWeight { get; set; }
        }
        //public class FormReturnData
        //{
        //    public string TxnNum { get; set; }
        //    public decimal TxnWeight { get; set; }
        //    public int InvAuthId { get; set; }
        //    public string TxnStatus { get; set; }
        //    public DateTime EntryDate { get; set; }
        //}newTxnNum, weight, TblMWTxnDetail.STATUS_ENUM_Complete, ComLib.db.SqlDBMng.GetDBNow()

        //public delegate void DelegateConfirm(decimal txnWeight,string txnStatus,DateTime entryDate);
        //public delegate void DelegateAuthorize(int invAuthId, decimal txnWeight, string txnStatus);

        //public delegate void DelegateConfirmDestroyNew(string newTxnNum);

        public delegate void DelegateOnOkClick(string crateCode,decimal txnWeight);
        public delegate void DelegateOnAuthorizeClick(string crateCode, decimal txnWeight);
        public delegate void DelegateOnCancelClick();
       
        #endregion

        #region Form Data Property

        #endregion
    }
}
