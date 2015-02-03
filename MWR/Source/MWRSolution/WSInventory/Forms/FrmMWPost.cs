using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;
using YRKJ.MWR.WinBase.WinUtility;
using ComLib.Log;
using YRKJ.MWR.WSInventory.Business.Sys;
using YRKJ.MWR.Business;
using YRKJ.MWR.Business.WS;

namespace YRKJ.MWR.WSInventory.Forms
{
    public partial class FrmMWPost : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.FrmMWPost";
        private FormMng _frmMng = null;

        private FrmMain _frmMain = null;

        private BindingList<GridMWPostTxnData> _gridMWRecoverData = new BindingList<GridMWPostTxnData>();
        private BindingManagerBase _bindingPostDataMng = null;


        public FrmMWPost()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

        }

        public FrmMWPost(FrmMain f)
            : this()
        {
            _frmMain = f;
        }

        #region Event

        private void FrmMWPost_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //WinFn.SafeFocusAndSelectAll(textBox1);
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWPost_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void c_btnStratPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST_DETAIL,
                        new FrmMWPostDetail(_frmMain, FrmMWPostDetail.PostTypeEnum.Nocare));
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStratPost_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnStratCheckPost_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST_DETAIL,
                        new FrmMWPostDetail(_frmMain, FrmMWPostDetail.PostTypeEnum.Normal));
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStratCheckPost_Click", ex);
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

                if (_frmMain != null)
                {
                    _frmMain.ShowFrom(FrmMain.TabToggleEnum.POST_DETAIL, new FrmMWPostDetail(_frmMain, "Eleven9000"));
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
                //WinFn.SafeFocusAndSelectAll(textBox1);

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
            //YRKJ.MWR.WinBase.WinUtility.BroadcastMng.GetInstance().Listen(SysInfo.Broadcast_RecoverTxnCount, (x) =>
            //{
            //    this.c_labTxnCount.Text = x.Data.ToString();
            //});
            _bindingPostDataMng = this.BindingContext[_gridMWRecoverData];
            if (!LoadData())
                return false;



            return true;
        }

        private bool InitCtrls()
        {

            c_labTxnNum.DataBindings.Add("Text", _gridMWRecoverData, "TxnNum");
            c_labEmpyName.DataBindings.Add("Text", _gridMWRecoverData, "PostEmpyName");
            c_labStatus.DataBindings.Add("Text", _gridMWRecoverData, "Status");
            c_labSubWeight.DataBindings.Add("Text", _gridMWRecoverData, "TotalSubWeight");
            c_labTotalQty.DataBindings.Add("Text", _gridMWRecoverData, "TotalCrateQty");
            c_labTxnWeight.DataBindings.Add("Text", _gridMWRecoverData, "TotalTxnWeight");
            //c_btnPost.DataBindings.Add("Enabled", _gridMWRecoverData, "");

            c_labTxnCount.Text = _gridMWRecoverData.Count+"";

            SysHelper.SetCtrlUnitText(c_labUnit1, c_labUnit2);

            c_grdMWPost_C_TxnNum.DataPropertyName = "TxnNum";
            c_grdMWPost_C_WSCode.DataPropertyName = "PostWSCode";
            c_grdMWPost_C_EmpyName.DataPropertyName = "PostEmpyName";
            c_grdMWPost_C_StartDate.DataPropertyName = "StartDate";
            c_grdMWPost_C_TotleQty.DataPropertyName = "TotalCrateQty";
            c_grdMWPost_C_TotolSubWeight.DataPropertyName = "TotalSubWeight";
            c_grdMWPost_C_TotalTxnWeight.DataPropertyName = "TotalTxnWeight";
            c_grdMWPost_C_Status.DataPropertyName = "Status";

            c_grdMWPost.DataSource = _gridMWRecoverData;

            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";
            string wscode = SysInfo.GetInstance().Config.WSCode;
            List<TblMWTxnPostHeader> header = null;
            if (!TxnMng.GetProcessingPostTxnList(wscode, ref header, ref errMsg))
            {
                MsgBox.Error(errMsg);
            }

            foreach (TblMWTxnPostHeader data in header)
            {
                GridMWPostTxnData item = GridMWPostTxnData.ConventDBDataToFormData(data);
                _gridMWRecoverData.Add(item);
            }

            return true;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "出库计划";
        }

        class GridMWPostTxnData
        {
            public string TxnNum { get; set; }
            public string PostWSCode { get; set; }
            public string PostEmpyName { get; set; }
            public string StartDate { get; set; }
            public int TotalCrateQty { get; set; }
            public decimal TotalSubWeight { get; set; }
            public decimal TotalTxnWeight { get; set; }
            public string Status { get; set; }

            public static GridMWPostTxnData ConventDBDataToFormData(TblMWTxnPostHeader data)
            {
                GridMWPostTxnData item = new GridMWPostTxnData();
                item.UpdateDBDataToFormData(data);
                return item;
            }

            public void UpdateDBDataToFormData(TblMWTxnPostHeader data)
            {
                GridMWPostTxnData item = this;

                item.TxnNum = data.TxnNum;
                item.PostWSCode = data.PostWSCode;
                item.PostEmpyName = data.PostEmpyName;
                item.StartDate = ComLib.ComFn.DateTimeToString(data.StartDate, BizBase.GetInstance().DateTimeFormatString);
                //item.EndDate = data.EndDate;
                //item.PostType = data.PostType;
                item.TotalCrateQty = data.TotalCrateQty;
                item.TotalSubWeight = data.TotalSubWeight;
                item.TotalTxnWeight = data.TotalTxnWeight;
                item.Status = data.Status;
                
            }
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
