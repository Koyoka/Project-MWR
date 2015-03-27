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
using YRKJ.MWR.WSDestory.Business.Sys;
using YRKJ.MWR.Business.WS;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWDestroy : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWDestory";
        private FormMng _frmMng = null;
        private FrmMain _frmMain = null;

        private BindingList<GridMWDestroyTxnData> _gridMWPostTxnData = new BindingList<GridMWDestroyTxnData>();
        private BindingManagerBase _bindingDestroyDataMng = null;

        FrmMWDestroy()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;
            this.c_grdMWDestroy.AutoGenerateColumns = false;
        }

        public FrmMWDestroy(FrmMain f)
            : this()
        {
            _frmMain = f;
        }

        #region Event
        private void FrmMWDestory_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestory_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWDestory_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                c_time.Stop();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestory_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnDestInv_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_DETAIL, new FrmMWDestroyDetail(_frmMain));

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnDestInv_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnDestRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_RECOVER, new FrmMWDestroyRecover(_frmMain));

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnDestRecover_Click", ex);
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
                if (_bindingDestroyDataMng.Position == -1)
                {
                    return;
                }

                GridMWDestroyTxnData curData = _bindingDestroyDataMng.Current as GridMWDestroyTxnData;

                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_DETAIL, new FrmMWDestroyDetail(_frmMain, curData.TxnNum));
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

        private void c_bgwRecoverToDest_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                string errMsg = "";
                int count = 0;
                string wscode = SysInfo.GetInstance().Config.WSCode;
                if (!TxnMng.GetGetRecoverToDestroyTxnCount(wscode, ref count, ref errMsg))
                {
                    return;
                }
                ThreadSafe(() =>
                {
                    c_labRecoverTxnCount.Visible = count != 0 ? true : false;
                    c_labRecoverTxnCount.Text = count + "";
                    BroadcastMng.GetInstance().Send(SysInfo.Broadcast_RecoverTxnCount, new BroadcastMng.BroadcastMessage
                    {
                        Message = count,
                        Data = count
                    });
                });

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_bgwRecoverToDest_DoWork", ex);
            }
            finally
            {
            }
        }

        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!c_bgwRecoverToDest.IsBusy)
                    c_bgwRecoverToDest.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_time_Tick", ex);
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
                _gridMWPostTxnData.Clear();
                LoadData();
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
            _bindingDestroyDataMng = this.BindingContext[_gridMWPostTxnData];
            if (!LoadData())
                return false;

            return true;
        }

        private bool InitCtrls()
        {

            _bindingDestroyDataMng.PositionChanged += (sender, e) => {
                c_btnCheck.Enabled = _bindingDestroyDataMng.Position == -1 ? false : true;
            };
            c_btnCheck.Enabled = _bindingDestroyDataMng.Position == -1 ? false : true;

            c_grdMWDestroy_C_TxnNum.DataPropertyName = "TxnNum";
            //c_grdMWDestroy_C_WSCode.DataPropertyName = "PostWSCode";
            c_grdMWDestroy_C_EmpyName.DataPropertyName = "DestEmpyName";
            c_grdMWDestroy_C_StartDate.DataPropertyName = "StartDate";
            c_grdMWDestroy_C_TotleQty.DataPropertyName = "TotalCrateQty";
            c_grdMWDestroy_C_TotolSubWeight.DataPropertyName = "TotalSubWeight";
            c_grdMWDestroy_C_TotalTxnWeight.DataPropertyName = "TotalTxnWeight";
            c_grdMWDestroy_C_Status.DataPropertyName = "Status";

            c_grdMWDestroy.DataSource = _gridMWPostTxnData;

            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";

            string wscode = SysInfo.GetInstance().Config.WSCode;

            List<TblMWTxnDestroyHeader> headerList = null;
            if (!TxnMng.GetDestroyTxnHeaderList(wscode, ref headerList, ref errMsg))
            {
                MsgBox.Error(errMsg);
                return false;
            }
            foreach (TblMWTxnDestroyHeader header in headerList)
            {
                _gridMWPostTxnData.Add(GridMWDestroyTxnData.ConventDBDataToFormData(header));
            }
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
            public const string MSG_FormName = "医疗废物处理";
        }

        private class GridMWDestroyTxnData
        {
            public int DestHeaderId = 0;
            public string DestType = "";
            public string TxnNum { get; set; }
            //public string PostWSCode { get; set; }
            public string DestEmpyName { get; set; }
            public string StartDate { get; set; }
            public int TotalCrateQty { get; set; }
            public decimal TotalSubWeight { get; set; }
            public decimal TotalTxnWeight { get; set; }
            public string Status { get; set; }

            public static GridMWDestroyTxnData ConventDBDataToFormData(TblMWTxnDestroyHeader data)
            {
                GridMWDestroyTxnData item = new GridMWDestroyTxnData();
                item.UpdateDBDataToFormData(data);
                return item;
            }

            public void UpdateDBDataToFormData(TblMWTxnDestroyHeader data)
            {
                GridMWDestroyTxnData item = this;

                item.DestHeaderId = data.DestHeaderId;
                item.TxnNum = data.TxnNum;
                item.DestType = data.DestType;
                item.StartDate = ComLib.ComFn.DateTimeToString(data.StartDate, BizBase.GetInstance().DateTimeFormatString);
                //item.EndDate = data.EndDate;
                //item.DestWSCode = data.DestWSCode;
                item.DestEmpyName = data.DestEmpyName;
                //item.DestEmpyCode = data.DestEmpyCode;
                item.TotalCrateQty = data.TotalCrateQty;
                item.TotalSubWeight = data.TotalSubWeight;
                item.TotalTxnWeight = data.TotalTxnWeight;
                item.Status = BizHelper.GetTxnDestroyHeaderStatus(data.Status);

            }
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
