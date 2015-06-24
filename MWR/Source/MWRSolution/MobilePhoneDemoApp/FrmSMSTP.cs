using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YAS.ComUtility.SMTP;


namespace MobilePhoneDemoApp
{
    public partial class FrmSMSTP : Form
    {
        public FrmSMSTP()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://111.47.111.59:8098/smtp/http/submit";
            string code = "999901";
            string userName = "sjkj";
            string password = "sjkj";
            //ComUtility.Class1 c;
            SMTPHelper smtp = new SMTPHelper(url, code, userName, password);

            string data = "";
            string errMsg = "";
            string phone = c_txtPhone.Text;
            string content = c_txtContent.Text;
            smtp.Send(1, phone, content, ref data, ref errMsg);
            textBox1.Text = errMsg + "\r\n" + data;
        }
    }
}
