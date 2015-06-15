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

namespace YRKJ.MWR.WSDestory.Forms
{
    public partial class FrmMWResidue : Form
    {
        private const string ClassName = "YRKJ.MWR.WSDestory.Forms.FrmMWResidue";
        private FormMng _frmMng = null;
        private ModbusHelper _modbus = null;

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

        private void c_bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (_modbus.RunStatus == ModbusHelper.EnumRunStatus.Stop)
                {
                    string unit = "1";
                    _modbus.ReadHoldRegs_PLC_MC(Convert.ToByte(unit));
                }

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

                if (_modbus != null)
                    _modbus.Dispose();
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
            _modbus = new ModbusHelper();
            string ip = "127.0.0.1";
            ushort port = 502;

            if (!_modbus.Connect(ip, port, ref errMsg))
            {
                MsgBox.Error(errMsg);
                return false;
            }
            _modbus.OnResponseData = new ModbusHelper.DelegateResponseData((x) =>
            {
                ThreadSafe(() => {
                    DataBind(x);
                });
                
            });
            _modbus.OnException = new ModbusHelper.DelegateException((x) =>
            {
                MsgBox.Error(x);
            });

            if (!LoadData())
                return false;
            
            //string unit = "1";
            //_modbus.ReadHoldRegs_PLC_MC(Convert.ToByte(unit));

            return true;
        }

        private bool InitCtrls()
        {
            //c_picMCStart.BackgroundImage = imageList1.Images[1];

            c_time.Start();
            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        private void DataBind(ModbusHelper.BizModel model)
        {
            c_picMCStart.BackgroundImage = imageList1.Images[model.MCStrat ? 0 : 1];
            c_picMCWarning.BackgroundImage = imageList1.Images[model.MCWarning ? 0 : 1];
            c_picDisiComp.BackgroundImage = imageList1.Images[model.MCDisiCompliance ? 0 : 1];
            c_txtMCAutoOrManu.Text = model.MCAutoRun ? "自动" : "手动";

            c_txtTotalBatchCount.Text = model.TotalBatchCount;
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
            c_txtMCStatus.Text = model.MCStatus;

            c_txtPressure.Text = model.MCPressure+"";
            c_txtMCInTemperature.Text = model.MCInTemperature + "";
            c_txtMCExTemperature.Text = model.MCExTemperature + "";
            c_txtElectric1.Text = model.MCElectricCurrent1 + "";
            c_txtElectric2.Text = model.MCElectricCurrent2 + "";

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

        #endregion

       
        #region Form Data Property

        #endregion
    }
}
