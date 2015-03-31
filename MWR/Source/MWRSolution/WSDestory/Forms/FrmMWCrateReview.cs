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
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.Business;
using YRKJ.MWR.WSDestory.Business.Sys;
using YRKJ.MWR.Business.Report;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWCrateReview : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWCrateReview";
        private FormMng _frmMng = null;

        private TblMWTxnDetail _txnDetail = null;
        private VewIvnAuthorizeWithTxnDetail _invAuth = null;

        FrmMWCrateReview()
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

       
        public FrmMWCrateReview(TblMWTxnDetail destTxnDetail)
            : this()
        {
            _txnDetail = destTxnDetail;
        }


        #region Event

        private void FrmMWCrateReview_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWCrateReview_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                string wscode = SysInfo.GetInstance().Config.WSCode;

                if (!TxnMng.ConfirmAuthorizeCrateToDestroy(_txnDetail.InvRecordId, _txnDetail.TxnNum, wscode, empyCode, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

        private void c_btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
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
            if (!LoadData())
                return false;



            return true;
        }

        private bool InitCtrls()
        {
            c_labCrateCode.Text = _txnDetail.CrateCode;
            c_labVendor.Text = _txnDetail.Vendor;
            c_labWaste.Text = _txnDetail.Waste;
            //c_labEntryDate.Text = ComLib.ComFn.DateTimeToString(_txnDetail.EntryDate, BizBase.GetInstance().DateTimeFormatString);

            c_labEmpyName.Text = _invAuth.EmpyName;
            c_labSubWeight.Text = _invAuth.SubWeight.ToString(BizBase.GetInstance().DecimalFormatString) + SysParams.GetInstance().GetSysWeightUnit();
            c_labTxnWeight.Text = _invAuth.TxnWeight.ToString(BizBase.GetInstance().DecimalFormatString) + SysParams.GetInstance().GetSysWeightUnit(); ;
            c_labDiffWeight.Text = _invAuth.DiffWeight.ToString(BizBase.GetInstance().DecimalFormatString) + SysParams.GetInstance().GetSysWeightUnit(); ;
            c_labAuthSubDate.Text = ComLib.ComFn.DateTimeToString(_invAuth.EntryDate, BizBase.GetInstance().DateTimeFormatString);

            c_labAuthEmpyName.Text = _invAuth.AuthEmpyName;
            c_labAuthCompleteDate.Text = ComLib.ComFn.DateTimeToString(_invAuth.CompDate, BizBase.GetInstance().DateTimeFormatString);
            c_txtAuthRemark.Text = _invAuth.Remark;

            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";

            if (!ReportDataMng.GetAuthorize(_txnDetail.InvAuthId, ref _invAuth, ref errMsg))
            {
                MsgBox.Error(errMsg);
                return false;
            }
            return true;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "周转箱审核";
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
