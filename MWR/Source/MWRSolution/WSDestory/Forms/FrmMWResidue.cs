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
using YRKJ.MWR.WSDestory.Business.Modbus;
using YRKJ.MWR.WSDestory.Business.Sys;
using YRKJ.MWR.Business.WS;
using ComLib.db;

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWResidue : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWResidue";
        private FormMng _frmMng = null;
        private ModbusHelper _modbus = null;
        private SavePLCDataHelper _savePLCDataHelper = null;
        private UpdateDestroyMCDetailHelper _updMCDetailHelper = null;

        public FrmMWResidue()
        {
            InitializeComponent();
        } 

        #region Event
        private void FrmMWResidue_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMWResidue_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnSaveModbusConfig_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";

                SysInfo.GetInstance().Config.ModbusIp = c_txtModbusIp.Text;
                SysInfo.GetInstance().Config.ModbusPort = c_txtModbusPort.Text;

                #region save config
                if (!YRKJ.MWR.WinBase.WinAppBase.Config.ConfigMng.SaveAppConfig(SysInfo.GetInstance().Config, ref errMsg))
                {
                    MsgBox.Error(errMsg);
                    return;
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnSaveModbusConfig_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_btnReConn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";
                InitModbus(ref errMsg);


            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_btnReConn_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (_modbus != null)
                {
                    _modbus.Dispose();
                }
                Init();
                
                doReadPLC();
               
            }
            catch (Exception ex)
            {
                //LogMng.GetLog().PrintError(ClassName, "c_bgw_DoWork", ex);
            }
            finally
            {
            }
        }
        
        private void FrmMWResidue_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string errMsg = "";
                c_time.Stop();

                if (_modbus != null)
                    _modbus.Dispose();

                System.Diagnostics.Debug.WriteLine("FrmMWResidue_FormClosing=========");
                _savePLCDataHelper.SaveToDb(ref errMsg);
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMWResidue_FormClosing", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        
        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Pool data count:" + _savePLCDataHelper.PoolDataCount);

                DateTime locTime = DateTime.Now;
                if ((locTime - _savePLCDataHelper.LastSaveTime).TotalSeconds >= _savePLCDataHelper.Interval)
                {
                    string errMsg = "";
                    System.Diagnostics.Debug.WriteLine("c_time_Tick=========");
                    _savePLCDataHelper.SaveToDb(ref errMsg);
                }

                if (!c_bgw.IsBusy)
                {
                    c_bgw.RunWorkerAsync();
                }



            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
        #endregion

        #region Functions

        private bool InitFrm()
        {

            string errMsg = "";

            

            if (!LoadData())
                return false;
            
            //string unit = "1";
            //_modbus.ReadHoldRegs_PLC_MC(Convert.ToByte(unit));

            return true;
        }
        private bool Init()
        {
            string errMsg = "";
            _modbus = new ModbusHelper();

            string ip = SysInfo.GetInstance().Config.ModbusIp;
            ushort port = ComLib.ComFn.StringToUShort(SysInfo.GetInstance().Config.ModbusPort);

            if (!_modbus.Connect(ip, port, ref errMsg))
            {
                c_txtModbusStatus.Text = "连接失败" + errMsg;
                //MsgBox.Error(errMsg);
                return false;
            }
            c_txtModbusStatus.Text = "连接成功";

            _modbus.OnResponseData = new ModbusHelper.DelegateResponseData((x) =>
            {
                ThreadSafe(() =>
                {
                    DataBind(x);
                    _savePLCDataHelper.Add(x);
                    _updMCDetailHelper.RefCurrentDisinum(x);
                    c_txtmodbusLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 获取数据成功 ";// +
                    //(saveSuccess?"数据保存成功":"数据保存失败");
                    if (_modbus.IsConnected)
                    {
                        c_txtModbusStatus.Text = "连接成功";
                    }
                });

            });
            _modbus.OnException = new ModbusHelper.DelegateException((x) =>
            {
                ThreadSafe(() =>
                {
                    c_txtmodbusLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " error:" + x;
                    if (!_modbus.IsConnected)
                    {
                        c_txtModbusStatus.Text = "连接丢失";
                    }

                });
                //MsgBox.Error(x);
            });

            return true;
        }
        private bool InitModbus(ref string errMsg)
        {
            if (_modbus != null && _modbus.IsConnected)
            {
                //MsgBox.Show("设备已连接");
                c_txtModbusStatus.Text = "设备已连接";
                return true;
            }

            _modbus = new ModbusHelper();

            string ip = SysInfo.GetInstance().Config.ModbusIp;
            ushort port = ComLib.ComFn.StringToUShort(SysInfo.GetInstance().Config.ModbusPort);

            if (!_modbus.Connect(ip, port, ref errMsg))
            {
                c_txtModbusStatus.Text = "连接失败"+errMsg;
                //MsgBox.Error(errMsg);
                return false;
            }
            c_txtModbusStatus.Text = "连接成功";

            _modbus.OnResponseData = new ModbusHelper.DelegateResponseData((x) =>
            {
                ThreadSafe(() =>
                {
                    DataBind(x);
                    _savePLCDataHelper.Add(x);
                    _updMCDetailHelper.RefCurrentDisinum(x);
                    c_txtmodbusLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 获取数据成功 ";// +
                        //(saveSuccess?"数据保存成功":"数据保存失败");
                    if (_modbus.IsConnected)
                    {
                        c_txtModbusStatus.Text = "连接成功";
                    }
                });

            });
            _modbus.OnException = new ModbusHelper.DelegateException((x) =>
            {
                ThreadSafe(() =>
                {
                    c_txtmodbusLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " error:" + x;
                    if (!_modbus.IsConnected)
                    {
                        c_txtModbusStatus.Text = "连接丢失";
                    }
                    
                });
                //MsgBox.Error(x);
            });
            c_time.Start();
            return true;
        }

        private bool InitCtrls()
        {
            string errMsg = "";
            c_txtModbusIp.Text = SysInfo.GetInstance().Config.ModbusIp;
            c_txtModbusPort.Text = SysInfo.GetInstance().Config.ModbusPort;
            c_txtModbusStatus.Text = "未连接";

            _savePLCDataHelper = new SavePLCDataHelper();
            _updMCDetailHelper = new UpdateDestroyMCDetailHelper();
            if (!InitModbus(ref errMsg))
            {
                return false;
            }
            doReadPLC();
            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        private void doReadPLC()
        {
            string s = "stop";
            if (_modbus.RunStatus == ModbusHelper.EnumRunStatus.Stop)
            {
                s = "run";
                string unit = "0";
                //label3.Text = label3.Text + unit;
                _modbus.ReadHoldRegs_PLC_MC(Convert.ToByte(unit));
            }
            c_txtTest.Text = DateTime.Now.ToString("HHmmss") + "_" + s + "_" + _modbus.IsConnected;
        }

        private void DataBind(ModbusHelper.BizModel model)
        {
            c_picMCStart.BackgroundImage = imageList1.Images[model.MCStrat ? 0 : 1];
            c_picMCWarning.BackgroundImage = imageList1.Images[model.MCWarning ? 1 : 0];
            c_picDisiComp.BackgroundImage = imageList1.Images[model.MCDisiCompliance ? 0 : 1];
            c_txtMCAutoOrManu.Text = model.MCAutoRun ? "自动" : "手动";

            c_txtTotalBatchCount.Text = model.TotalBatchCount+"";
            c_txtTotalCrateCount.Text = model.TotalCrateCount;
            c_txtTotalFeedCount.Text = model.TotalFeedCount;

            c_txtBatchStartTime.Text =
                    model.BatchStartTimeYear + "-" +
                    model.BatchStartTimeMonth + "-" +
                    model.BatchStartTimeDay + " " +
                    model.BatchStartTimeHour + ":" +
                    model.BatchStartTimeMinute + ":" +
                    model.BatchStartTimeSecond;
            c_txtBatchCrateCount.Text = model.BatchCrateCount;
            c_txtBatchFeedCount.Text = model.BatchFeedCount;
            c_txtETFeedCount.Text = model.ETFeedCount;
            c_txtMCWarningCount.Text = model.MCWarningCount;
            c_txtMCStatus.Text = model.MCStatusDesc;

            c_txtPressure.Text = model.MCPressure.ToString("F3");
            c_txtMCInTemperature.Text = model.MCInTemperature.ToString("F3");
            c_txtMCExTemperature.Text = model.MCExTemperature.ToString("F3");
            c_txtElectric1.Text = model.MCElectricCurrent1.ToString("F3");
            c_txtElectric2.Text = model.MCElectricCurrent2.ToString("F3");

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
            public const string MSG_FormName = "";
        }

        private class SavePLCDataHelper
        {
            public DateTime LastSaveTime = DateTime.MinValue;
            public DateTime LastAddTime = DateTime.MinValue;
            public int Interval = 20;
            private object lockObj = new object();

            private List<TblMWDestroyMCParamsLog> _dataPool = new List<TblMWDestroyMCParamsLog>();
            public int PoolDataCount { get { return _dataPool.Count; } }

            public void Add(TblMWDestroyMCParamsLog data)
            {
                _dataPool.Add(data);
            }
            public void Add(ModbusHelper.BizModel model)
            {
                if (!model.MCStrat)
                    return;

                #region
                 DateTime locTime = DateTime.Now;
                 if ((locTime - LastAddTime).TotalSeconds <= 5)
                 {
                     return;
                 }
                #endregion


                DateTime dbNow = SqlDBMng.GetDBNow();
                _dataPool.Add(new TblMWDestroyMCParamsLog()
                {
                    MCCode = SysInfo.GetInstance().Config.WSCode,
                    RunDate = dbNow,//DateTime.Now,
                    WSCode = SysInfo.GetInstance().Config.WSCode,
                    DisiNum = (int)model.TotalBatchCount,
                    Pressure = model.MCPressure,
                    InTemperature = model.MCInTemperature,
                    ExTemperature = model.MCExTemperature,
                    EC1 = model.MCElectricCurrent1,
                    EC2 = model.MCElectricCurrent2,
                    WordStatus = model.MCStatusDesc

                });
                LastAddTime = locTime;
            }

            public bool SaveToDb(ref string errMsg)
            {
                if (_dataPool.Count == 0)
                    return true;

                lock (lockObj)
                {
                    int len = _dataPool.Count;

                    List<TblMWDestroyMCParamsLog> saveData = _dataPool.GetRange(0, len);
                    if (!TxnMng.BatchAddDMCParamsLog(saveData, ref errMsg))
                    {
                        // error log
                        return false;
                    }
                    System.Diagnostics.Debug.WriteLine("Pool Save Count:" + saveData.Count);
                    _dataPool.RemoveRange(0, len);
                    LastSaveTime = DateTime.Now;
                }

                System.Diagnostics.Debug.WriteLine("Pool Left Count:" + _dataPool.Count);
                return true;
            }
        }

        private class UpdateDestroyMCDetailHelper
        {
            private int? _curDisiNum = null;
            public void RefCurrentDisinum(ModbusHelper.BizModel m)
            {
                if (!m.MCStrat)
                    return;

                int disiNum = (int)m.TotalBatchCount;
                if (disiNum == 0)
                    return;

                if (disiNum == _curDisiNum)
                    return;

                _curDisiNum = disiNum;
                if (UpdateCurrentDisiNumToDetail(disiNum) != 0)
                {
                    _curDisiNum = null;
                }
            }

            private int UpdateCurrentDisiNumToDetail(int disiNum)
            {
                string errMsg = "";
                int updCount = 0;
                if (!TxnMng.UpdateDestroyMCDetailToDisiNum(disiNum, ref updCount, ref errMsg))
                {
                    MsgBox.Show(errMsg);
                    return 0;
                }
                return updCount;
            }
        }
        #endregion

        #region Form Data Property

        #endregion
    }
}
