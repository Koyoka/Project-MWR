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
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMWCrateReview : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.FrmMWCrateReview";
        private FormMng _frmMng = null;

        private string _depotCode = "";
        private TblMWTxnDetail _txnDetail = null;
        private VewIvnAuthorizeWithTxnDetail _invAuth = null;

        private EnumOptType _optType = EnumOptType.defalut;
        private enum EnumOptType
        {
            Recover, Post, defalut
        }

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

        public FrmMWCrateReview(TblMWTxnDetail recoverTxnDetail, string depotCode)
            :this()
        {
            _txnDetail = recoverTxnDetail;
            _depotCode = depotCode;
            _optType = EnumOptType.Recover;
        }
        public FrmMWCrateReview(TblMWTxnDetail postTxnDetail)
            : this()
        {
            _txnDetail = postTxnDetail;
            _optType = EnumOptType.Post;
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

                #region post
                if (_optType == EnumOptType.Post)
                {
                    if (!TxnMng.AuthorizeCrateToPost(_txnDetail.InvRecordId, _txnDetail.TxnNum, wscode, empyCode, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }
                }
                #endregion

                #region recover
                if (_optType == EnumOptType.Recover)
                {
                    if (!TxnMng.AuthorizeCrareToInventory(_txnDetail.TxnDetailId,
                        empyCode, wscode, _depotCode, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }
                   
                }
                #endregion

                //#region update current form txndetail data
                //_txnDetail.EmpyCode = SysInfo.GetInstance().Employ.EmpyCode;
                //_txnDetail.EmpyName = SysInfo.GetInstance().Employ.EmpyName;
                //_txnDetail.WSCode = SysInfo.GetInstance().Config.WSCode;
                //_txnDetail.Status = TblMWTxnDetail.STATUS_ENUM_Complete;
                //_txnDetail.EntryDate = ComLib.db.SqlDBMng.GetDBNow();
                //#endregion

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
            
            if (!BaseDataMng.GetAuthorize(_txnDetail.InvAuthId, ref _invAuth, ref errMsg))
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
