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

namespace MWRSyncMng
{
    public partial class FrmMain : Form
    {
        private const string ClassName = "MWRSyncMng.FrmMain";
        private FormMng _frmMng = null;
        private SMSProcessMng _smpMng = null;

        public FrmMain()
        {
            InitializeComponent();
        } 

        #region Event

        private void c_back_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                //this.Cursor = Cursors.WaitCursor;

                if (_smpMng != null)
                {
                    c_txtMain.Text = _smpMng.InfoMsg;

                    if (_smpMng.HasCrashed)
                    {
                        c_txtMain.Text = _smpMng.CrashedErrMsg;
                        ServiceEnd();
                        return;
                    }
                }

                DateTime lastBeginTime = DateTime.MinValue;
                if (_smpMng != null)
                {
                    if (_smpMng.IsRunning)
                    {
                        return;
                    }

                    lastBeginTime = _smpMng.BeginTime;
                }

                TimeSpan ts = DateTime.Now - lastBeginTime;
                if (ts.TotalSeconds < 0 || ts.TotalSeconds >= 100)
                {
                    //OK
                }
                else
                {
                    return;
                }

                _smpMng = new SMSProcessMng();
                _smpMng.Run();
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_time_Tick", ex);
                //MsgBox.Error(ex);
            }
            finally
            {
                //this.Cursor = Cursors.Default;
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
            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        private bool ServiceBegin()
        {
            _smpMng = new SMSProcessMng();
            _smpMng.Run();

            c_sspMain_R_txtStatus.Text = "RUNNING";
            c_sspMain_R_txtStatus.ForeColor = Color.Green;

            c_time.Interval = 100;
            c_time.Enabled = true;
            return true;
        }

        private bool ServiceEnd()
        {
            if (_smpMng != null)
            {
                _smpMng.Stop();


                c_sspMain_R_txtStatus.Text = "STOP";
                c_sspMain_R_txtStatus.ForeColor = Color.Red;
                c_time.Enabled = false;
            }

            return true;
        }
        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "";
        }

        #endregion

        #region Form Data Property
        public class SMSProcessMng
        {
            private bool _isRunning = false;
            private bool _needStop = false;
            private DateTime _beginTime = DateTime.MinValue;
            private bool _hasCrashed = false;
            private string _crashedErrMsg = "";
            private string _infoMsg = "";

            public bool IsRunning
            {
                get
                {
                    return _isRunning;
                }
            }

            public DateTime BeginTime
            {
                get
                {
                    return _beginTime;
                }
            }

            public bool HasCrashed
            {
                get
                {
                    return _hasCrashed;
                }
            }

            public string CrashedErrMsg
            {
                get
                {
                    return _crashedErrMsg;
                }
            }

            public string InfoMsg
            {
                get
                {
                    return _infoMsg;
                }
            }

            public void Stop()
            {
                _needStop = true;
            }

            public void Run()
            {
                _beginTime = DateTime.Now;
                System.Threading.Thread t = new System.Threading.Thread(RunBase);
                t.Start();
            }

            private void RunBase()
            {
                _isRunning = true;
                _needStop = false;
                try
                {
                   
                }
                catch (Exception ex)
                {
                    _hasCrashed = true;
                    _crashedErrMsg = ex.Message;
                }
                finally
                {
                    _isRunning = false;
                }
            }
        }
        #endregion


    }
}
