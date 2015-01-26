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
    public partial class FrmMWCrateView : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWCrateDetail";
        private FormMng _frmMng = null;

        //private string _crateCode = "";
        string _depotCode = "";
        private TblMWTxnDetail _txnDetail = null;

        public FrmMWCrateView()
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

        public FrmMWCrateView(TblMWTxnDetail txnDetail,string depotCode)
            :this()
        {
            _txnDetail = txnDetail;
            _depotCode = depotCode;
        }

        #region Event

        private void FrmMWCrateView_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWCrateView_Load", ex);
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
                //string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                //string empyName = SysInfo.GetInstance().Employ.EmpyName;
                //string wscode = SysInfo.GetInstance().Config.WSCode;

                _txnDetail.TxnWeight = 999;
                _txnDetail.EmpyCode = SysInfo.GetInstance().Employ.EmpyCode;
                _txnDetail.EmpyName = SysInfo.GetInstance().Employ.EmpyName;
                _txnDetail.WSCode = SysInfo.GetInstance().Config.WSCode;
                
                if (!TxnMng.ConfirmCrateToInventory(_txnDetail.TxnDetailId,
                    //_txnWeight, empyCode, wscode, 
                    _depotCode,
                    ref errMsg))
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

        private void c_btnError_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

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
            this.c_txtCrateCode.Text = _txnDetail.CrateCode;

            this.c_txtCrateCode.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getCrateCodeColumn().ColumnName);
            this.c_labVendor.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getVendorColumn().ColumnName);
            this.c_labWaster.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getWasteColumn().ColumnName);
            this.c_labSubWeight.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getSubWeightColumn().ColumnName);

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
            public const string MSG_FormName = "周转箱称重";
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
