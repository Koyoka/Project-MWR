using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;
using System.Threading;
using YRKJ.MWR.WinBase.WinUtility;
using System.Text.RegularExpressions;

namespace YRKJ.MWR.WSInventory
{
    public partial class Form1 : Form
    {
    //    System.Windows.Forms.Timer _Time;
        private ScannerMng _scannerMng = null;
        public Form1()
        {
            InitializeComponent();

            //_Time = new System.Windows.Forms.Timer();
            //_Time.Interval = 1000;
            //_Time.Tick += new EventHandler(t_Tick);

            _scannerMng = new ScannerMng(this, "", "HX#####");
            _scannerMng.CodeScanned += new ScannerMng.ScannedEventHandler(code);
            _scannerMng.InvalidCodeScanned += new ScannerMng.ScannedEventHandler(code);

          
        }

        private void code(string c)
        {
            textBox1.Text = c;
            //MsgBox.Show(c);
        }
        private void t_Tick(object sender, EventArgs e)
        {
            //textBox1.Text = DateTime.Now.ToString();
        }
        private void test()
        {
            Thread t = new Thread(delegate() {
                int count = 50;
                while(count == 0)
                {
                    Thread.Sleep(50);
                    count--;
                    
                }
               
                _testC();
            });

            t.Start();
        }

        private delegate void TestC();
        TestC _testC;
        
        private void button1_Click(object sender, EventArgs e)
        {
            _scannerMng.SetCodeMask(textBox2.Text);
            //MessageBox.Show(Regex.IsMatch(textBox1.Text, @"^\d{1}$")+"");
            //MessageBox.Show(Regex.IsMatch(textBox1.Text, @"^[A-Za-z]{1}[A-Za-z]{1}\d{1}$") + "");
            //MessageBox.Show(Regex.IsMatch(textBox1.Text, @"^[Y]{1}$") + "");
            //^[A-Za-z]+$
            //_Time.Start();
            //_testC = new TestC(func);
            //test();
        }
        private void func()
        {
            textBox1.Text = "thread";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {






            //label2.Text += e.KeyChar.ToString();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            //if (textBox1.Text.Length > 13)
            //{
            //    textBox1.Text = "";
            //    ctrl.Tag = null;
            //}


            
           
            //MsgBox.Show(textBox1.Text);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //DateTime tempDt = DateTime.Now;          //保存按键按下时刻的时间点
            //TimeSpan ts = tempDt.Subtract(_dt);     //获取时间间隔
            //if (ts.Milliseconds > 50)                           //判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空
            //    textBox1.Text = "";
            //_dt = tempDt;
        }
        DateTime _dt = DateTime.MinValue;
        DateTime d = DateTime.MinValue;
        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (textBox1.Text.Length == 0)
            //{
            //    d = DateTime.Now;
            //}
          
            //TimeSpan ts = DateTime.Now-d;
            //if (ts.Milliseconds > 500)
            //{
            //    textBox1.Text = "";
            //    //d = DateTime.Now;
            //}

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //Control ctrl = (Control)sender;
            //if (ctrl.Tag == null)
            //{
            //    ctrl.Tag = DateTime.Now;
            //}
            //else if (ctrl.Tag is DateTime)
            //{
            //    TimeSpan ts = DateTime.Now - (DateTime)ctrl.Tag;
            //    if (ts.Milliseconds > 500)
            //    {
            //        textBox1.Text = "";
            //        ctrl.Tag = null;
            //    }
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

     



    }
}
