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
        private SMSRunTimeHelper _smrHelpr = null;
        private int _interval = 10;
        private List<string> _txtMain = new List<string>();

        public FrmMain()
        {
            InitializeComponent();
        } 

        #region Event

        private void FrmMain_Load(object sender, EventArgs e)
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
                LogMng.GetLog().PrintError(ClassName, "FrmMain_Load", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_mnuServiceStrat_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ServiceBegin();
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_mnuServiceStrat_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_mnuStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ServiceEnd();
                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_mnuStop_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_mnuPSetting_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_mnuPSetting_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void c_back_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void c_time_Tick(object sender, EventArgs e)
        {
            try
            {
                //this.Cursor = Cursors.WaitCursor;

                c_sspMain_L_txtRunTime.Text = _smrHelpr.RunTimeInfo;

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
                if (ts.TotalSeconds < 0 || ts.TotalSeconds >= _interval)
                {
                    //OK
                    if (_smpMng != null)
                    {

                        c_txtMain.Text = _smpMng.InfoMsg;
                        //_txtMain.Insert(0, _smpMng.InfoMsg);
                        //c_txtMain.Lines = _txtMain.ToArray();

                        if (_smpMng.HasCrashed)
                        {
                            c_txtMain.Text = _smpMng.CrashedErrMsg;
                            ServiceEnd();
                            return;
                        }
                    }
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

        private void c_notifyIconMain_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (WindowState != FormWindowState.Minimized)
                {
                    ShowInTaskbar = false;
                    WindowState = FormWindowState.Minimized;
                }
                else
                {
                    ShowInTaskbar = true;
                    WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "c_notifyIconMain_Click", ex);
                MsgBox.Error(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.WindowState == FormWindowState.Minimized)
                {
                    ShowInTaskbar = false;
                    c_notifyIconMain.Visible = true;
                }
                else
                {
                    c_notifyIconMain.Visible = false;
                }
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "FrmMain_Resize", ex);
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

            _smrHelpr = new SMSRunTimeHelper();

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
            _smrHelpr.Begin();

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
            _smrHelpr.End();

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
        public class SMSRunTimeHelper
        {
            private bool _isBegin = false;
            private DateTime _lastBeginTime = DateTime.MinValue;
            private DateTime _beginTime = DateTime.MinValue;
            private string _runTimeInfo = "";
            public string RunTimeInfo
            {
                get
                {
                    calcuTotleTime();
                    return _runTimeInfo;
                }
            }

            public void Begin()
            {
                if (_isBegin)
                    return;

                _isBegin = true;
                _beginTime = DateTime.Now;
            }
            
            public void End()
            {
                _isBegin = false;
            }
            
            private void calcuTotleTime()
            {
                if (!_isBegin)
                    return;
                {
                    TimeSpan ts = DateTime.Now - _lastBeginTime;
                    if (ts.TotalSeconds < 1)
                    {
                        return;
                    }
                }

                {
                    TimeSpan ts = DateTime.Now - _beginTime;

                    double days = ts.Days;
                    double hours = ts.Hours;
                    double minutes = ts.Minutes;
                    double seconds = ts.Seconds;
                    StringBuilder sb = new StringBuilder();

                    sb.Append("开始时间：" + _beginTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(" 运行时间：");
                    if (days != 0)
                        sb.Append(days + "天");
                    if (days != 0 || hours != 0)
                        sb.Append(hours + "小时");
                    if (days != 0 || hours != 0 || minutes != 0)
                        sb.Append(minutes + "分钟");

                    sb.Append(seconds + "秒");
                    _runTimeInfo = sb.ToString();

                    _lastBeginTime = DateTime.Now;
                }
            }
        }

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
                    #region Show Info
                    StringBuilder sb = new StringBuilder();
                    
                    DateTime now = ComLib.db.SqlDBMng.GetDBNow();
                    sb.AppendLine("Search Time = " + now.ToString("yyyy-MM-dd HH:mm:ss") + "");
                    //sb.AppendLine("Need Send SMS Count = " + smsDataList.Length.ToString() + "");
                    //if (smsDataList.Length > 0)
                    //{
                    //    sb.AppendLine("---------------------------------------------------");
                    //    foreach (TblQWSMSPool smsData in smsDataList)
                    //    {
                    //        sb.AppendLine("SMSId # " + smsData.SMSId.ToString() + "");
                    //    }
                    //    sb.AppendLine("");
                    //}

                    _infoMsg = sb.ToString();
                    #endregion
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
