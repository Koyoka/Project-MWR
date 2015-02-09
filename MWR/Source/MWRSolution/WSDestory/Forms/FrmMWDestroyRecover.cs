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
using ComLib;
using YRKJ.MWR.Business;
using YRKJ.MWR.Business.WS;
using YRKJ.MWR.WSDestory.Business.Sys;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWDestroyRecover : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmDestoryRecover";
        private FormMng _frmMng = null;
        private FrmMain _frmMain = null;

        private BindingList<GridMWRecoverData> _gridMWRecoverData = new BindingList<GridMWRecoverData>();
        private BindingManagerBase _bindingRecoverDataMng = null;

        FrmMWDestroyRecover()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.c_grdMWRecover.AutoGenerateColumns = false;
        }

        public FrmMWDestroyRecover(FrmMain f)
            : this()
        {
            _frmMain = f;
        }

        #region Event

        private void FrmMWDestoryRecover_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!InitFrm())
                {
                    return;
                }

                if (!InitCtrls())
                    return;

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWDestoryRecover_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        private void c_btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY);
                this.Close();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStop_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnStrat_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_bindingRecoverDataMng.Position == -1)
                {
                    return;
                }

                GridMWRecoverData curData = _bindingRecoverDataMng.Current as GridMWRecoverData;

                string errMsg = "";
                string wsCode = SysInfo.GetInstance().Config.WSCode;
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                string newTxnNum = "";
                if (!TxnMng.BeginConfirmRecoverToDestroy(curData.TxnNum, wsCode, empyCode, ref newTxnNum, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                }
                _frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_DETAIL, new FrmMWDestroyDetail(_frmMain, newTxnNum));
                this.Close();
                //return;

                //string txnNum = curData.TxnNum;
                //_frmMain.ShowFrom(FrmMain.TabToggleEnum.DESTORY_RECOVER_DETAIL, new FrmMWDestroyRecoverDetail(_frmMain, txnNum));
                //this.Close();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStrat_Click", ex);
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
            _bindingRecoverDataMng = this.BindingContext[_gridMWRecoverData];
            if (!LoadData())
                return false;
            

            return true;
        }

        private bool InitCtrls()
        {
            c_btnStrat.Enabled = _gridMWRecoverData.Count == 0 ? false : true;

            c_grdMWRecover_C_CarCode.DataPropertyName = "CarCode";
            c_grdMWRecover_C_Driver.DataPropertyName = "Driver";
            c_grdMWRecover_C_Inspector.DataPropertyName = "Inspector";
            c_grdMWRecover_C_TotleCount.DataPropertyName = "TotalCount";
            c_grdMWRecover_C_TotolWeight.DataPropertyName = "TotalWeight";
            c_grdMWRecover_C_OutDate.DataPropertyName = "OutDate";
            c_grdMWRecover_C_InDate.DataPropertyName = "InDate";
            c_grdMWRecover_C_StartDate.DataPropertyName = "StartDate";
            c_grdMWRecover_C_Status.DataPropertyName = "Status";

            c_grdMWRecover.DataSource = _gridMWRecoverData;
            return true;
        }

        private bool LoadData()
        {
            string errMsg = "";
            string wscode = SysInfo.GetInstance().Config.WSCode;
            List<VewTxnHeaderWithCarDispatch> headerList = null;
            if (!TxnMng.GetRecoverToDestroyTxnList(wscode, ref headerList, ref errMsg))
            {
                return false;
            }
            foreach (VewTxnHeaderWithCarDispatch data in headerList)
            {
                GridMWRecoverData item = GridMWRecoverData.ConventDBDataToFormData(data);
                _gridMWRecoverData.Add(item);
            }

            return true;
        }

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "车辆回收废品处理";
        }

        private class GridMWRecoverData
        {
            public string TxnNum = "";
            public string CarCode { get; set; }

            public string Driver { get; set; }

            public string Inspector { get; set; }

            public string OutDate { get; set; }

            public string InDate { get; set; }
           
            public string StartDate { get; set; }
            
            public string Status { get; set; }

            public int TotalCount { get; set; }

            public decimal TotalWeight { get; set; }

            public VewTxnHeaderWithCarDispatch ORGData { get; set; }
            public static GridMWRecoverData ConventDBDataToFormData(VewTxnHeaderWithCarDispatch data)
            {
                GridMWRecoverData item = new GridMWRecoverData();
                item.UpdataDBDataToFormData(data);
                return item;
            }
            public void UpdataDBDataToFormData(VewTxnHeaderWithCarDispatch data)
            {
                ORGData = data;
                GridMWRecoverData item = this;
                item.TxnNum = data.TxnNum;
                item.CarCode = data.CarCode;
                item.Driver = data.Driver;
                item.Inspector = data.Inspector;
                item.TotalCount = data.TotalCrateQty;
                item.TotalWeight = data.TotalSubWeight;
                item.OutDate = ComFn.DateTimeToString(data.OutDate, BizBase.GetInstance().DateTimeFormatString);
                item.InDate = ComFn.DateTimeToString(data.InDate, BizBase.GetInstance().DateTimeFormatString);
                item.StartDate = ComFn.DateTimeToString(data.StratDate, BizBase.GetInstance().DateTimeFormatString);
                item.Status = BizHelper.GetTxnRecoverHeaderStatus(data.Status);

            }
        }

        #endregion

        #region Form Data Property

        #endregion
    }
}
