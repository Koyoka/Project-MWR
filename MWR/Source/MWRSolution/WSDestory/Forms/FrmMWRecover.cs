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
using YRKJ.MWR.Business.WS;
using ComLib;
using YRKJ.MWR.Business;
using YRKJ.MWR.WSDestory.Business.Sys;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWRecover : Form
    {
        private const string ClassName = "YRKJ.MWR.WSInventory.Forms.FrmMWRevocer";
        private FormMng _frmMng = null;
        private FrmMain _frmMain = null;

        private BindingList<GridMWRecoverData> _gridMWRecoverData = new BindingList<GridMWRecoverData>();
        private BindingManagerBase _bindingRecoverDataMng = null;

        public FrmMWRecover()
        {
            InitializeComponent();

            _frmMng = new FormMng(this, ClassName);
            this.Text = LngRes.MSG_FormName;

            //this.c_grdMWRecover.RowHeadersVisible = false;
        }

        public FrmMWRecover(FrmMain f) : this()
        {
            _frmMain = f;
        }
      
        #region Event

        private void FrmMWRecover_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";

                if (!InitFrm(ref errMsg))
                {
                    return;
                }

                if (!InitCtrls(ref errMsg))
                {
                    return;
                }

                c_time.Start();

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecover_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMWRecover_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                //MessageBox.Show("close");
                c_time.Stop();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWRecover_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnStratRecover_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";

                if (_bindingRecoverDataMng.Position == -1)
                {
                    MsgBox.Show(LngRes.MSG_NoData);
                    return;
                }
                GridMWRecoverData data = _bindingRecoverDataMng.Current as GridMWRecoverData;
                if (data == null)
                {
                    return;
                }
                
                string wscode = SysInfo.GetInstance().Config.WSCode;
                string empyCode = SysInfo.GetInstance().Employ.EmpyCode;
                if(!TxnMng.BeginOperateRecoverTxn(data.TxnNum,wscode,empyCode,ref errMsg))
                {
                    MsgBox.Show(errMsg);
                    return;
                }

                if (_frmMain != null)
                {
                    string defineRecoNum = data.TxnNum;
                    //_frmMain.ShowFrom(FrmMain.TabToggleEnum.RECOVE_RDETAIL, new FrmMWRecoverDetail(_frmMain, defineRecoNum));
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnStratRecover_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_bgwGetRecoverTxnHeader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string errMsg = "";

                GridMWRecoverData curData = null;

                if (_bindingRecoverDataMng.Position != -1)
                {
                    curData = _bindingRecoverDataMng.Current as GridMWRecoverData;
                }

                ThreadSafe(() =>
                {
                    #region get new data
                    _gridMWRecoverData.Clear();
                    if (!LoadData(ref errMsg))
                    {
                        return;
                    }
                    #endregion

                    #region update form view data
                    c_labHeaderCount.Text = _gridMWRecoverData.Count + "";
                    BroadcastMng.GetInstance().Send(SysInfo.Broadcast_RecoverTxnCount, new BroadcastMng.BroadcastMessage
                    {
                        Message = _gridMWRecoverData.Count,
                        Data = _gridMWRecoverData.Count
                    });
                    #endregion

                    #region set current row select
                    if (curData != null)
                    {
                        bool hasBeenExist = false;
                        for (int i = 0; i < _gridMWRecoverData.Count; i++)
                        {
                            if (_gridMWRecoverData[i].TxnNum.Equals(curData.TxnNum))
                            {
                                hasBeenExist = true;
                                c_grdMWRecover.Rows[i].Selected = true;
                                c_grdMWRecover.CurrentCell = c_grdMWRecover.Rows[i].Cells[0];
                                break;
                            }
                        }
                        if (!hasBeenExist)
                        {
                            _bindingRecoverDataMng.Position = 0;
                        }
                    }
                    #endregion

                });
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_bgwGetRecoverTxnHeader_DoWork", ex);
                MsgBox.Error(ex);
            }
            finally
            {
            }
        }

        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!c_bgwGetRecoverTxnHeader.IsBusy)
                {
                    c_bgwGetRecoverTxnHeader.RunWorkerAsync();
                }

            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_time_Tick", ex);
                MsgBox.Error(ex);
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

                string errMsg = "";
                //_bindingRecoverDataMng = this.BindingContext[_gridMWRecoverData];
                //_gridMWRecoverData.Clear();
                //if (!LoadData(ref errMsg))
                //{
                //    MsgBox.Error(errMsg);
                //    return;
                //}

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

        private bool InitFrm(ref string errMsg)
        {
            _bindingRecoverDataMng = this.BindingContext[_gridMWRecoverData];
           
            if (!LoadData(ref errMsg))
                return false;


            return true;
        }

        private bool InitCtrls(ref string errMsg)
        {
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
            c_labHeaderCount.Text = _gridMWRecoverData.Count + "";
            return true;
        }
      
        private bool LoadData(ref string errMsg)
        {
            string wscode = SysInfo.GetInstance().Config.WSCode;
            List<VewTxnHeaderWithCarDispatch> headerList = null;
            if (!TxnMng.GetRecoverToInvTxnList(wscode,ref headerList, ref errMsg))
            {
                return false;
            }
            foreach (VewTxnHeaderWithCarDispatch data in headerList)
            {
                GridMWRecoverData item = new GridMWRecoverData();
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
                _gridMWRecoverData.Add(item);
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
            public const string MSG_FormName = "入库计划";
            public const string MSG_NoData = "没有选择任何数据";
        }

        private class GridMWRecoverData
        {
            public string TxnNum = "";
            private string _carCode = "";
            public string CarCode
            {
                get { return _carCode; }
                set { _carCode = value; }
            }

            private string _driver = "";
            public string Driver
            {
                get { return _driver; }
                set { _driver = value; }
            }

            private string _inspector = "";
            public string Inspector
            {
                get { return _inspector; }
                set { _inspector = value; }
            }

            private string _outDate = "";
            public string OutDate
            {
                get { return _outDate; }
                set { _outDate = value; }
            }

            private string _inDate = "";
            public string InDate
            {
                get { return _inDate; }
                set { _inDate = value; }
            }

            private string _stratDate = "";
            public string StartDate
            {
                get { return _stratDate; }
                set { _stratDate = value; }
            }

            private string _status = "";
            public string Status
            {
                get { return _status; }
                set { _status = value; }
            }

            private int _totalCount = 0;
            public int TotalCount
            {
                get { return _totalCount; }
                set { _totalCount = value; }
            }

            private decimal _totalWeight = 0;
            public decimal TotalWeight
            {
                get { return _totalWeight; }
                set { _totalWeight = value; }
            }
        }

        #endregion
        
        #region Form Data Property

        #endregion
    }
}
