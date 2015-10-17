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
using YRKJ.MWR.Business.Sys;

namespace MWRSyncMng
{
    public partial class FrmMain : Form
    {
        private const string ClassName = "MWRSyncMng.FrmMain";
        private FormMng _frmMng = null;
        private SMSProcessHelper _smpMng = null;
        private SMSRunTimeHelper _smrHelpr = null;
        private SMSCacheHelper _carchHelpr = null;
        private SMSCacheHelper _carchMCDataHelpr = null;
        private SMSCacheHelper _carchMCDetailDataHelpr = null;
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
                using (Form f = new FrmSetting())
                {
                    f.ShowDialog();
                    c_sspMain_L_txtService.Text = SysInfo.GetInstance().Config.ServiceRoot;
                }
                
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

                DateTime locNow = DateTime.Now;
                #region check need sync
                {
                    DateTime syncTime = MWParams.GetSyncDateTime();
                    TimeSpan sp = locNow.TimeOfDay - syncTime.TimeOfDay;
                    if (!(sp.Hours == 0 && sp.Minutes >= 0 && sp.Minutes <= 10))
                    {
                        c_txtMain.Text = "同步时间未到 -> " + syncTime.ToString("HH:mm");
                        return;
                    }
                }
                #endregion

                DateTime lastBeginTime = DateTime.MinValue;
                if (_smpMng != null)
                {
                    //if (!string.IsNullOrEmpty(_smpMng.InfoMsg))
                    //{
                    //    c_txtMain.Text = _smpMng.InfoMsg;
                    //}
                    if (_smpMng.IsRunning)
                    {
                        return;
                    }

                    lastBeginTime = _smpMng.BeginTime;
                }

                TimeSpan ts = locNow - lastBeginTime;
                if (ts.TotalSeconds < 0 || ts.TotalSeconds >= _interval)
                {
                    //OK
                    if (_smpMng != null)
                    {
                        if (!string.IsNullOrEmpty(_smpMng.InfoMsg))
                        {
                            c_txtMain.Text = _smpMng.InfoMsg;
                        }
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

                _smpMng = new SMSProcessHelper(_carchHelpr, _carchMCDataHelpr, _carchMCDetailDataHelpr);
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
            _carchHelpr = new SMSCacheHelper();
            _carchMCDataHelpr = new SMSCacheHelper();
            _carchMCDetailDataHelpr = new SMSCacheHelper();
            if (!LoadData())
                return false;

            _smrHelpr = new SMSRunTimeHelper();

            return true;
        }

        private bool InitCtrls()
        {
            c_sspMain_L_txtService.Text = SysInfo.GetInstance().Config.ServiceRoot;
            return true;
        }

        private bool LoadData()
        {
            return true;
        }

        private bool ServiceBegin()
        {
            #region check params
            string city = MWParams.GetSyncCity();
            if (string.IsNullOrEmpty(city))
            {
                MessageBox.Show("请在配置中设置城市");
                return false;
            }
            #endregion

            _smrHelpr.Begin();

            _smpMng = new SMSProcessHelper(_carchHelpr, _carchMCDataHelpr, _carchMCDetailDataHelpr);
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
        public class SMSCacheHelper
        {
            private string _jsData = null;
            
            public bool GetCacheData(DelegateGetData d,ref string data,ref string errMsg)
            {
                if(string.IsNullOrEmpty(_jsData) && d != null)
                {
                    return d(ref data,ref errMsg);
                }
                data = _jsData;
                return true;
            }
            public bool GetCacheData(DelegateGetDataByLastDate d, ref string data, ref DateTime lastCreationDate, ref string errMsg)
            {
                if (string.IsNullOrEmpty(_jsData) && d != null)
                {
                    return d(ref data, ref lastCreationDate, ref errMsg);
                }
                data = _jsData;
                return true;
            }
            public void Clear()
            {
                _jsData = null;
            }
            public delegate bool DelegateGetData(ref string data, ref string errMsg);
            public delegate bool DelegateGetDataByLastDate(ref string data, ref  DateTime lastCreationDate, ref string errMsg);
        }

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

        public class SMSProcessHelper
        {

            public SMSProcessHelper(SMSCacheHelper cacheHelper, SMSCacheHelper cacheMCDataHelper, SMSCacheHelper carchMCDetailDataHelpr)
            {
                _cacheHelper = cacheHelper;
                _cacheMCDataHelper = cacheMCDataHelper;
                _carchMCDetailDataHelpr = carchMCDetailDataHelpr;
            }

            private SMSCacheHelper _cacheHelper = null;
            private SMSCacheHelper _cacheMCDataHelper = null;
            private SMSCacheHelper _carchMCDetailDataHelpr = null;

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
                    string errMsg = "";

                    #region request

                    #region report data
                    {
                        string jsonData = "";

                        #region get data
                        if (!_cacheHelper.GetCacheData(
                            SyncHelper.GetSyncData, ref jsonData, ref errMsg))
                        {
                            _hasCrashed = true;
                            _crashedErrMsg = errMsg;
                            return;
                        }
                        #endregion

                        if (string.IsNullOrEmpty(jsonData))
                        {
                            // do nothing
                        }
                        else
                        {
                            string sericveUrl = SysInfo.GetInstance().Config.ServiceRoot + "/SynBusinessData.ashx";
                            if (!SyncHelper.DoRequest(jsonData,
                                //"http://192.168.1.152:8081/SynBusinessData.ashx", 
                                sericveUrl,
                                ref errMsg))
                            {
                                SyncHelper.RollbackSyncData(ref errMsg);
                                _hasCrashed = true;
                                _crashedErrMsg = errMsg;
                                return;
                            }
                            else
                            {
                                
                            }
                        }

                        #region Show Info
                        StringBuilder sb = new StringBuilder();

                        DateTime now = ComLib.db.SqlDBMng.GetDBNow();
                        //string defineTestStr = "运量{0}，接货量{1}，入库量{2}，库存量{3}，出库量{4}，处置量{5} 统计日期{6}";
                        sb.AppendLine("同步时间 = " + now.ToString("yyyy-MM-dd HH:mm:ss") + "");
                        sb.AppendLine(jsonData);
                        _infoMsg = sb.ToString();
                        #endregion

                        _cacheHelper.Clear();
                    }
                    #endregion

                    #region mc data
                    //if(false)
                    {
                        string jsonData = "";
                        DateTime lastDate = MWParams.GetSyncMCLastDataCreationDate();
                        #region get data
                        if (!_cacheMCDataHelper.GetCacheData(
                            SyncHelper.GetSyncMCData, ref jsonData, ref lastDate, ref errMsg))
                        {
                            _hasCrashed = true;
                            _crashedErrMsg = errMsg;
                            return;
                        }
                        #endregion

                        if (string.IsNullOrEmpty(jsonData))
                        {
                            // do nothing
                        }
                        else
                        {
                            string sericveUrl = SysInfo.GetInstance().Config.ServiceRoot + "/SynHandleData.ashx";
                                //"http://192.168.5.222:3448/SynHandleData.ashx";//SysInfo.GetInstance().Config.ServiceRoot;
                            if (!SyncHelper.DoRequest(jsonData,
                                    sericveUrl,
                                    ref errMsg))
                            {
                                _hasCrashed = true;
                                _crashedErrMsg = errMsg;
                                return;
                            }
                            else
                            {
                                MWParams.SetSyncMCLastDataCreationDate(lastDate, ref errMsg);
                            }
                        }

                        _cacheMCDataHelper.Clear();
                    }
                    #endregion

                    #region mc detail data
                    //if (false)
                    {
                        string jsonData = "";
                        DateTime lastDate = MWParams.GetSyncMCDetailLastDataCreationDate();
                        #region get data
                        if (!_carchMCDetailDataHelpr.GetCacheData(
                            SyncHelper.GetSyncMCDetailData, ref jsonData, ref lastDate, ref errMsg))
                        {
                            _hasCrashed = true;
                            _crashedErrMsg = errMsg;
                            return;
                        }
                        #endregion

                        if (string.IsNullOrEmpty(jsonData))
                        {
                            // do nothing
                        }
                        else
                        {
                            string sericveUrl = SysInfo.GetInstance().Config.ServiceRoot + "/SynHandleParamData.ashx";
                                //"http://192.168.5.222:8085/SynHandleParamData.ashx";//SysInfo.GetInstance().Config.ServiceRoot;
                            if (!SyncHelper.DoRequest(jsonData,
                                    sericveUrl,
                                    ref errMsg))
                            {
                                _hasCrashed = true;
                                _crashedErrMsg = errMsg;
                                return;
                            }
                            else {
                                MWParams.SetSyncMCDetailLastDataCreationDate(lastDate, ref errMsg);
                            }
                        }

                        _carchMCDetailDataHelpr.Clear();
                    }
                    #endregion

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
