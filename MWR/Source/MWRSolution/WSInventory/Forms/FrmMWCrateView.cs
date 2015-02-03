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
        private ScalesMng _scalesMng = null;

        private decimal _txnWeight = 0;
        private decimal _allowDiffWeight = 1;
        
        private FormViewData _formViewData = null;
        private FormReturnData _formReturnData = new FormReturnData();

        private EnumOptType _optType = EnumOptType.defalut;
        public enum EnumOptType
        { 
            Recover,Post,defalut
        }

        //recover data
        private int _txnDetailId = 0;

        //post data
        private int _invRecordId = 0;
        private string _txnNum = "";

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

        public FrmMWCrateView(int txnDetailId ,FormViewData viewData)
            :this()
        {
            _formViewData = viewData;
            _optType =  EnumOptType.Recover;
            _txnDetailId = txnDetailId;
        }

        public FrmMWCrateView(int invRecordId, string txnNum, FormViewData viewData)
            : this()
        {
            _formViewData = viewData;
            _optType =  EnumOptType.Post;
            _invRecordId = invRecordId;
            _txnNum = txnNum;

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
                string wsCode = SysInfo.GetInstance().Config.WSCode;
                decimal weight = _txnWeight;

                if (Math.Abs(_formViewData.SubWeight - weight) > _allowDiffWeight)
                {
                    MsgBox.Error(LngRes.MSG_DiffWeight);
                    return;
                }

                #region recover to inventory
                if (_optType == EnumOptType.Recover)
                {
                    if (!TxnMng.ConfirmCrateToInventory(_txnDetailId,
                        weight, empyCode, wsCode,
                        _formViewData.DepotCode,
                        ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }
                    #region update return data
                    _formReturnData.TxnWeight = weight;
                    _formReturnData.TxnStatus = TblMWTxnDetail.STATUS_ENUM_Complete;
                    _formReturnData.EntryDate = ComLib.db.SqlDBMng.GetDBNow();
                    #endregion
                }
                #endregion

                #region inventory to post
                if (_optType == EnumOptType.Post)
                {
                    if (!TxnMng.ConfirmInventoryToPost(_invRecordId, _txnNum, _txnWeight, wsCode, empyCode, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }
                    #region update return data
                    _formReturnData.TxnWeight = weight;
                    _formReturnData.TxnStatus = TblMWTxnDetail.STATUS_ENUM_Complete;
                    _formReturnData.EntryDate = ComLib.db.SqlDBMng.GetDBNow();
                    #endregion
                }
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
                string unit = SysParams.GetInstance().GetSysWeightUnit();

                if (!MsgBox.Confirm("警告", "当前称重[" + weight + " " + unit + "],实际重量[" + _formViewData.SubWeight + "]确定提交审核么？"))
                {
                    return;
                }
                
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                string wsCode = SysInfo.GetInstance().Config.WSCode;

                #region recover to authorize
                if (_optType == EnumOptType.Recover)
                {
                    int invAuthId = 0;
                    if (!TxnMng.ConfirmCrareToAuthorize(_txnDetailId, _txnWeight, empyCode, wsCode, ref invAuthId, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }

                    #region update return data
                    _formReturnData.TxnWeight = weight;
                    _formReturnData.InvAuthId = invAuthId;
                    _formReturnData.TxnStatus = TblMWTxnDetail.STATUS_ENUM_Authorize;
                    #endregion
                }
                #endregion

                #region post to authorize
                if (_optType == EnumOptType.Post)
                {
                    int invAuthId = 0;
                    if (!TxnMng.ConfirmInventoryToAuthorize(_invRecordId, _txnNum, _txnWeight, wsCode, empyCode,
                        ref invAuthId, ref errMsg))
                    {
                        MsgBox.Error(errMsg);
                        return;
                    }
                    #region update return data
                    _formReturnData.TxnWeight = weight;
                    _formReturnData.InvAuthId = invAuthId;
                    _formReturnData.TxnStatus = TblMWTxnDetail.STATUS_ENUM_Authorize;
                    #endregion
                }
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

            this.c_txtCrateCode.Text = _formViewData.CrateCode;
            this.c_labVendor.Text = _formViewData.Vendor;
            this.c_labWaster.Text = _formViewData.Waste;
            this.c_labSubWeight.Text = _formViewData.SubWeight.ToString(BizBase.GetInstance().DecimalFormatString)+SysParams.GetInstance().GetSysWeightUnit();
            //this.c_txtCrateCode.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getCrateCodeColumn().ColumnName);
            //this.c_labVendor.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getVendorColumn().ColumnName);
            //this.c_labWaster.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getWasteColumn().ColumnName);
            //this.c_labSubWeight.DataBindings.Add("Text", _txnDetail, TblMWTxnDetail.getSubWeightColumn().ColumnName);
            //this.c_labSubWeight.Text += " " + SysParams.GetInstance().GetSysWeightUnit();

            SysHelper.SetCtrlUnitText(this.c_labSysUnit);

            return true;
        }

        private bool LoadData()
        {
      
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
                c_labScalesStatus.Text = "当前重量 " + SysParams.GetInstance().GetSysWeightUnit();
            c_labTxnWeight.Text = weight.ToString("f2") + " " + SysParams.GetInstance().GetSysWeightUnit();
              
            //});
            
        }
        
        public FormReturnData GetScalesTxnWeight()
        {
            return _formReturnData;
        }
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
            public string DepotCode { get; set; }
        }
        public class FormReturnData
        {
            public decimal TxnWeight { get; set; }
            public int InvAuthId { get; set; }
            public string TxnStatus { get; set; }
            public DateTime EntryDate { get; set; }
        }
        #endregion

        #region Form Data Property

        #endregion
    }
}
