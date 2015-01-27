//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;
//using System.IO.Ports;
//using Microsoft.Win32;
//using System.Threading;

//namespace MobilePhoneDemoApp
//{
//    public partial class FrmScales : Form
//    {
//        public FrmScales()
//        {
//            InitializeComponent();
//        }

//        private SerialPort Sp = new SerialPort();

//        private void FrmScales_Load(object sender, EventArgs e)
//        {
//            initFrm();
//        }

//        private void initFrm()
//        {
//            GetComList();
//        }

//        /// <summary> 
//        /// 从注册表获取系统串口列表 
//        /// </summary> 
//        private void GetComList()
//        {
//            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey("Hardware\\DeviceMap\\SerialComm");
//            if (keyCom != null)
//            {
//                string[] sSubKeys = keyCom.GetValueNames();
//                this.comboBox1.Items.Clear();
//                foreach (string sName in sSubKeys)
//                {
//                    string sValue = (string)keyCom.GetValue(sName);
//                    this.comboBox2.Items.Add(sValue);
//                }
//            }
//        }

//        private void FrmScales_FormClosing(object sender, FormClosingEventArgs e)
//        {
//            Sp.Close();
//        }

//        public delegate void HandleInterfaceUpdataDelegate(string text); //委托，此为重点 
//        private HandleInterfaceUpdataDelegate interfaceUpdataHandle;
//        private void UpdateTextBox(string text)
//        {
//            textBox1.Text = text;
//        }
//        private void open()
//        { 
//            if ((this.comboBox2.Text.Trim() != "") && (this.comboBox1.Text != ""))
//            {
//                interfaceUpdataHandle = new HandleInterfaceUpdataDelegate(UpdateTextBox);//实例化委托对象 
//                Sp.PortName = this.comboBox2.Text.Trim();
//                Sp.BaudRate = Convert.ToInt32(this.comboBox1.Text.Trim());
//                Sp.Parity = Parity.None;
//                Sp.StopBits = StopBits.One;
//                Sp.DataReceived  += new SerialDataReceivedEventHandler(Sp_DataReceived);
//                Sp.ReceivedBytesThreshold = 1;
//                try
//                {
//                    Sp.Open();
 
//                    ATCommand3("AT CLIP=1\r", "OK");
 
 
//                    btPause.Enabled = true;
//                    btENT.Enabled = false;
//                }
//                catch
//                {
//                    MessageBox.Show("端口"   this.comboBox2.Text.Trim()   "打开失败！");
//                }
//            }
//            else
//            {
//                MessageBox.Show("请输入正确的端口号和波特率！");
//                this.comboBox2.Focus();
//            }
//        }

//        public void Sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
//        {
//            string strTemp = "";
//            double iSecond = 0.5;

//            DateTime dtOld = System.DateTime.Now;
//            DateTime dtNow = System.DateTime.Now;
//            TimeSpan dtInter;
//            dtInter = dtNow - dtOld;

//            int i = Sp.BytesToRead;
//            if (i > 0)
//            {
//                try
//                {
//                    strTemp = Sp.ReadExisting();
//                }
//                catch
//                { }
//                if (strTemp.ToLower().IndexOf("\r") < 0)
//                {
//                    i = 0;
//                }
//                else
//                {
//                    this.Invoke(interfaceUpdataHandle, strTemp);
//                }
//            }
//            while (dtInter.TotalSeconds < iSecond && i <= 0)
//            {
//                dtNow = System.DateTime.Now;
//                dtInter = dtNow - dtOld;
//                i = Sp.BytesToRead;
//                if (i > 0)
//                {
//                    try
//                    {
//                        strTemp = Sp.ReadExisting();
//                    }
//                    catch
//                    { }
//                    if (strTemp.ToLower().IndexOf("\r") < 0)
//                    {
//                        i = 0;
//                    }
//                    else
//                    {
//                        this.Invoke(interfaceUpdataHandle, strTemp);
//                    }
//                }
//            }
//            // do null  

//        }

//        /// <summary> 
//        /// 执行AT指令并返回 成功失败 
//        /// </summary> 
//        /// <param name="ATCmd">AT指令</param> 
//        /// <param name="StCmd">AT指令标准结束标识</param> 
//        /// <returns></returns> 
//        private void ATCommand3(string ATCmd, string StCmd)
//        {
//            string response = "";
//            response = ATCommand(ATCmd, StCmd);


//        }

//        /// <summary> 
//        /// 执行AT指令并返回结果字符 
//        /// </summary> 
//        /// <param name="ATCmd">AT指令</param> 
//        /// <param name="StCmd">AT指令标准结束标识</param> 
//        /// <returns></returns> 
//        private string ATCommand(string ATCmd, string StCmd)
//        {
//            string response = "";
//            int i;
//            if (!ATCmd.EndsWith("\x01a"))
//            {
//                if (!(ATCmd.EndsWith("\r") || ATCmd.EndsWith("\r\n")))
//                {
//                    ATCmd = ATCmd   "\r";
//                }
//            }
//            Sp.WriteLine(ATCmd);
 
//            //第一次读响应数据 
//            if (Sp.BytesToRead > 0)
//            {
//                response = Sp.ReadExisting();
 
//                //去除前端多可能多读取的字符 
//                if (response.IndexOf(ATCmd) > 0)
//                {
//                    response = response.Substring(response.IndexOf(ATCmd));
//                }
//                else
//                {
 
//                }
 
//                if (response == "" || response.IndexOf(StCmd) < 0)
//                {
//                    if (response != "")
//                    {
//                        if (response.Trim() == "ERROR")
//                        {
//                            //throw vError = new UnknowException("Unknown exception in sending command:"   ATCmd); 
//                        }
//                        if (response.IndexOf(" CMS ERROR") >= 0)
//                        {
//                            string[] cols = new string[100];
//                            cols = response.Split(';');
//                            if (cols.Length > 1)
//                            {
//                                string errorCode = cols[1];
//                            }
//                        }
//                    }
//                }
//            }
 
//            //读第一次没有读完的响应数据，直到读到特征数据或超时 
//            for (i = 0; i < 3; i++ )
//            {
//                Thread.Sleep(1000);
//                response = Sp.ReadExisting();
//                if (response.IndexOf(StCmd) >= 0)
//                {
//                    break;
//                }
//            }
 
//            return response;
 
 
//        }
 

//    }
//}
