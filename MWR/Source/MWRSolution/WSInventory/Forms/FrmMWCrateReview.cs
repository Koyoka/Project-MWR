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
using YRKJ.MWR.WSInventory.Business.Sys;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMWCrateReview : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.FrmMWCrateReview";
        private FormMng _frmMng = null;

        private string _depotCode = "";
        private TblMWTxnDetail _txnDetail = null;

        public FrmMWCrateReview()
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

        public FrmMWCrateReview(TblMWTxnDetail txnDetail, string depotCode)
            :this()
        {
            _txnDetail = txnDetail;
            _depotCode = depotCode;
        } 

        #region Event

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
            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "周转箱审核";
        }

        #endregion

        private void c_btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                string empyName = SysInfo.GetInstance().Employ.EmpyName;
                string wscode = SysInfo.GetInstance().Config.WSCode;

                if (!TxnMng.AuthorizeCrareToInventory(_txnDetail.TxnDetailId,
                    empyCode, wscode, _depotCode, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
                #region update current form txndetail data
                _txnDetail.EmpyCode = SysInfo.GetInstance().Employ.EmpyCode;
                _txnDetail.EmpyName = SysInfo.GetInstance().Employ.EmpyName;
                _txnDetail.WSCode = SysInfo.GetInstance().Config.WSCode;
                _txnDetail.Status = TblMWTxnDetail.STATUS_ENUM_Complete;
                #endregion
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

        #region Form Data Property

        #endregion
    }
}
