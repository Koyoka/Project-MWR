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
using YRKJ.MWR.WinBase.WinUtility;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMWCrateView : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWCrateDetail";
        private FormMng _frmMng = null;

        //private string _crateCode = "";
        private string _sysunit = "kg";
        private decimal _txnWeight = 0;
        private decimal _allowDiffWeight = 1;
        private string _depotCode = "";
        private TblMWTxnDetail _txnDetail = null;
        private ScalesMng _scalesMng = null;

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

                if (!_scalesMng.Open())
                {
                    MsgBox.Show(LngRes.MSG_NoConnScales);
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

        
        private void c_btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                string empyName = SysInfo.GetInstance().Employ.EmpyName;
                string wscode = SysInfo.GetInstance().Config.WSCode;
                decimal weight = _txnWeight;
                
                if (Math.Abs(_txnDetail.SubWeight - weight) > _allowDiffWeight)
                {
                    MsgBox.Error(LngRes.MSG_DiffWeight);
                    return;
                }

                if (!TxnMng.ConfirmCrateToInventory(_txnDetail.TxnDetailId,
                    weight, empyCode, wscode, 
                    _depotCode,
                    ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
                #region update current form txndetail data

                _txnDetail.TxnWeight = weight;
                _txnDetail.EmpyCode = SysInfo.GetInstance().Employ.EmpyCode;
                _txnDetail.EmpyName = SysInfo.GetInstance().Employ.EmpyName;
                _txnDetail.WSCode = SysInfo.GetInstance().Config.WSCode;
                _txnDetail.Status = TblMWTxnDetail.STATUS_ENUM_Complete;
                _txnDetail.EntryDate = ComLib.db.SqlDBMng.GetDBNow();
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

        private void c_btnError_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string errMsg = "";

                decimal weight = _txnWeight;
                if (!MsgBox.Confirm("警告", "当前称重[" + weight + " " + _sysunit + "],回收重量[" + _txnDetail.SubWeight + "]确定提交审核么？"))
                {
                    return;
                }
                
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                string wsCode = SysInfo.GetInstance().Config.WSCode;
                int invAuthId = 0;
                if (!TxnMng.ConfirmCrareToAuthorize(_txnDetail.TxnDetailId, _txnWeight, empyCode, wsCode,ref invAuthId, ref errMsg))
                {
                    return;
                }

                #region update current form txndetail data

                _txnDetail.TxnWeight = weight;
                _txnDetail.EmpyCode = SysInfo.GetInstance().Employ.EmpyCode;
                _txnDetail.EmpyName = SysInfo.GetInstance().Employ.EmpyName;
                _txnDetail.WSCode = SysInfo.GetInstance().Config.WSCode;
                _txnDetail.Status = TblMWTxnDetail.STATUS_ENUM_Authorize;
                _txnDetail.InvAuthId = invAuthId;
                #endregion

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

            if (!LoadData())
                return false;
            
            return true;
        }

        private bool InitCtrls()
        {
            c_labScalesStatus.Text = "请链接台秤";

            this.c_txtCrateCode.Text = _txnDetail.CrateCode;

            this.c_txtCrateCode.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getCrateCodeColumn().ColumnName);
            this.c_labVendor.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getVendorColumn().ColumnName);
            this.c_labWaster.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getWasteColumn().ColumnName);
            this.c_labSubWeight.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getSubWeightColumn().ColumnName);
            this.c_labSubWeight.Text += " " + SysParams.GetInstance().GetSysWeightUnit();
            this.c_labSysUnit.Text = SysParams.GetInstance().GetSysWeightUnit();
            return true;
        }

        private bool LoadData()
        {
      
            _sysunit = SysParams.GetInstance().GetSysWeightUnit();
#if DEBUG
            if (_scalesMng.IsOpen)
                _allowDiffWeight = SysParams.GetInstance().GetAllowDiffWeight();
            else
                _allowDiffWeight = 100;
#else
             _allowDiffWeight = SysParams.GetInstance().GetAllowDiffWeight();
#endif
            return true;
        }

       
        private void FrmMWCrateView_onScalesDataReceived(string status, string lable, decimal weight, string unit)
        {
            //ThreadSafe(() => {
            _txnWeight = BizHelper.ConventToSysUnitWeight(weight, unit, SysParams.GetInstance().GetSysWeightUnit());


            if (status.ToLower() == "us")
                c_labScalesStatus.Text = "称重中.....";
            else if (status.ToLower() == "st")
                c_labScalesStatus.Text = "当前重量 " + _sysunit;
            c_labTxnWeight.Text = weight.ToString("f2") + " " + _sysunit;
              
            //});
            
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "周转箱称重";
            public const string MSG_DiffWeight = "提交重量与回收重量不符，请提交审核";
            public const string MSG_NoConnScales = "电子秤未连接";
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
