using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinAppBase;

namespace YRKJ.MWR.WSInventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            DateTime tempDt = DateTime.Now;          //保存按键按下时刻的时间点
            TimeSpan ts = tempDt.Subtract(_dt);     //获取时间间隔
            if (ts.Milliseconds > 50)                           //判断时间间隔，如果时间间隔大于50毫秒，则将TextBox清空
                textBox1.Text = "";
            _dt = tempDt;
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



    }
}
