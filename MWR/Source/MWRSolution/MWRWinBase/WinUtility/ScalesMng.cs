using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsbHid;
using System.Windows.Forms;

namespace YRKJ.MWR.WinBase.WinUtility
{
    public class ScalesMng
    {
        private UsbHidDevice Device = null;
        private Form _form = null;
        private bool InvokeRequired
        {
            get
            {
                return _form == null ? false : _form.InvokeRequired;
            }
        }

        private Timer _time = null;
        string _scalesStatus = "";
        string _label = "";
        string _value = "";
        decimal _weight = 0;
        string _unit = "";

        //private bool _isOpen = false;
        //public bool IsOpen
        //{
        //    get { return _isOpen; }
        //}
        //private bool _isClose = false;
        private bool _isReceived = false;

        public delegate void ScalesOnConnected();
        public delegate void ScalesOnDisConected();
        public delegate void ScalesOnScalesDataReceived(string status,string lable,decimal weight,string unit,bool isComplete);
        public delegate void ScalesOnScalesDataReceivedAuto(string status, string lable, decimal weight, string unit);

        public ScalesOnConnected onConnected = null;
        public ScalesOnDisConected onDisConnected = null;
        public ScalesOnScalesDataReceived onScalesDataReceived = null;
        public ScalesOnScalesDataReceivedAuto onScalesDataReceivedAuto = null;

        public ScalesMng(Form form)
        {
            _form = form;
            Init();
        }

        private void Init()
        {
            Device = new UsbHidDevice(0x0483, 0x5750);
            Device.OnConnected += DeviceOnConnected;
            Device.OnDisConnected += DeviceOnDisConnected;
            Device.DataReceived += DeviceDataReceived;

            _time = new Timer();
            _time.Interval = 10;
            _time.Tick += (x, y) =>
            {
                if (onScalesDataReceived != null && _isReceived)
                    onScalesDataReceived(_scalesStatus, _label, _weight, _unit, _complete);

                
            };

            _form.FormClosing += new FormClosingEventHandler((x,y) => {
                _time.Stop();
            });
            _time.Start();
        }

       
        public bool Strat()
        {
            _complete = false;
            _stratScale = false;
            _stCount = 0;

            bool isOpen = false;
            if (!Device.IsDeviceConnected)
                isOpen = Device.Connect();


            return isOpen;
        }

        public void Close()
        {
            _complete = true;
            if (Device.IsDeviceConnected)
            {
                Device.Disconnect();
            }
        }

        #region Events
        // 设备连接事件
        private void DeviceOnConnected()
        {
            try
            {
                _complete = false;
                _stratScale = false;
                _stCount = 0;
                if (onConnected != null)
                    onConnected();
            }
            catch(Exception ex)
            {}
        }
        // 设备失联事件
        private void DeviceOnDisConnected()
        {
            try
            {
                if (onDisConnected != null)
                    onDisConnected();
            }
            catch (Exception ex)
            { }
        }

        private const string US = "US";
        private const string ST = "ST";
        private bool _complete = false;
        private bool _stratScale = false;
        private int _stCount = 0;
        private const int _completeSTCount = 5;
        // 数据接收事件
        private void DeviceDataReceived(byte[] data)
        {
            string[] defineDatas = ByteArrayToString(data).Split(',');
            if (defineDatas.Length != 3)
            {
                return;
            }
            #region split data get result 
          
           
            string val = defineDatas[2];
            #endregion

            #region get weight & unit
            string[] trimVals = val.Trim().Split(' ');
            if (trimVals.Length != 2)
            {
                return;
            }
            _isReceived = false;
            _scalesStatus = defineDatas[0];
            _label = defineDatas[1];
            _value = defineDatas[2];
            _weight = ComLib.ComFn.StringToDecimal(trimVals[0]);
            _unit = trimVals[1].TrimEnd('\r','\n','\0');
            _isReceived = true;
            #endregion

            if (_scalesStatus.ToUpper() == US)
            {
                _stratScale = true;
            }
            else if (_scalesStatus.ToUpper() == ST && _weight != 0)
            {
                _stratScale = true;
            }

            if (_stratScale && _scalesStatus.ToUpper() == ST)
            {
                _stCount++;
            }

            if (_stratScale && _stCount >= _completeSTCount)
            {
                if (_weight == 0)
                {
                    _stratScale = false;
                    _stCount = 0;
                }
                else
                {
                    ThreadSafe(() =>
                    {

                        if (onScalesDataReceivedAuto != null)
                        {
                          
                            Close();
                            onScalesDataReceivedAuto(_scalesStatus, _label, _weight, _unit);
                        }

                    });
                }
            }
            //if (onScalesDataReceived != null)
            //{
            //    //onScalesDataReceived(_scalesStatus, _label, _weight, _unit);
            //    //ThreadSafe(() => onScalesDataReceived(_scalesStatus, _label, _weight, _unit));
            //}
        }
        #endregion
        
        #region utility
        private static string ByteArrayToString(ICollection<byte> input)
        {
            var result = string.Empty;

            if (input != null && input.Count > 0)
            {
                var isFirst = true;
                foreach (var b in input)
                {
                    if (isFirst)  // 第一个字节为报告ID，需要丢弃
                    {
                        isFirst = false;
                        continue;
                    }
                    else
                    {
                        result += (char)b;
                    }
                }
            }
            return result;
        }
        #endregion
        //private object _closeLock = new object();
        private void ThreadSafe(MethodInvoker method)
        {
             if (InvokeRequired)
                 _form.Invoke(method);
             else
                 method();
        //    //lock (_closeLock)
        //    {
        //        System.Diagnostics.Debug.WriteLine("ThreadSafe--------[" + _isClose + "] b " + (method != null));
        //        if (!Device.IsDeviceConnected)
        //            return;
        //        if (_isClose)
        //            return;
        //        if (_form.IsDisposed)
        //            return;
        //        try
        //        {
        //            if (InvokeRequired)
        //                _form.Invoke(method);
        //            else
        //                method();
        //        }
        //        catch (Exception ex)
        //        { }
        //        finally 
        //        {
        //            System.Diagnostics.Debug.WriteLine("ThreadSafe--------[" + _isClose + "] e");
        //        }

                
        //    }
        }
    }
}
