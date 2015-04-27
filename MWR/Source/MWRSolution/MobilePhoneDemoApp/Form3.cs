using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YRKJ.MWR.WinBase.WinUtility;
using YRKJ.MWR.Business;
using ComLib.db.BaseSys;

namespace MobilePhoneDemoApp
{
    public partial class Form3 : Form
    {
        private ScalesMng _scalesMng = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            InitFrm();
        }

        private bool InitFrm()
        {
            _scalesMng = new ScalesMng(this);

            _scalesMng.onConnected = () =>
            {
                //c_labScalesStatus.Text = "等待称重";
            };
            _scalesMng.onDisConnected = () =>
            {
                //c_labScalesStatus.Text = "请链接台秤";
            };
            _scalesMng.onScalesDataReceived = FrmMWCrateView_onScalesDataReceived;
            _scalesMng.onScalesDataReceivedAuto = FrmMWCrateView_onScalesDataReceived2;

            //if (!LoadData())
            //    return false;
            _scalesMng.Open();
            return true;
        }

        private void FrmMWCrateView_onScalesDataReceived2(string status, string lable, decimal weight, string unit)
        {
            string s = "status:[{0}] lable:[{1}] weight:[{2}] unit:[{3}] ";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(s, status, lable, weight, unit));

            {
                textBox1.Text = sb.ToString() + textBox1.Text;
            }

            MessageBox.Show("complete");
        }

        private void FrmMWCrateView_onScalesDataReceived(string status, string lable, decimal weight, string unit)
        {
            string s = "status:[{0}] lable:[{1}] weight:[{2}] unit:[{3}] ";
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(s, status, lable, weight, unit));
           
            {
                textBox1.Text = sb.ToString() + textBox1.Text;
            }
           

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            _scalesMng.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scalesMng.Open();
        }

    }
}
