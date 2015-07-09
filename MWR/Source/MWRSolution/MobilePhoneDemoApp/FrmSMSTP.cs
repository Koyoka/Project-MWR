using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YAS.ComUtility.SMTP;
using YAS.ComUtility.IM;


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

        private void button4_Click(object sender, EventArgs e)
        {
            string orgName = "elevendemo";
            string appName = "elevendemoapp";
            //string clientId = "YXA6WQDpcBtKEeWhFY0nM0YckA";
            //string clientSecret = "YXA6vOyYXwnjmMPnbcL-5O2w6JtX-TQ";
            string clientId = "YXA6WQDpcBtKEeWhFY0nM0YckA";
            string clientSecret = "ccA6vOyYXwnjmMPnbcL-5O2w6JtX-TQ";
            //token
            HXIMHelper hxIMHelper = new HXIMHelper(
                orgName,
                appName,clientId,clientSecret);
            //string errMsg = "";
            //if (!hxIMHelper.GetAppToken(ref errMsg))
            //{
            //    MessageBox.Show(errMsg);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //好友
            string orgName = "elevendemo";
            string appName = "elevendemoapp";
            string clientId = "YXA6WQDpcBtKEeWhFY0nM0YckA";
            string clientSecret = "YXA6vOyYXwnjmMPnbcL-5O2w6JtX-TQ";
            //string clientId = "YXA6WQDpcBtKEeWhFY0nM0YckA";
            //string clientSecret = "ccA6vOyYXwnjmMPnbcL-5O2w6JtX-TQ";
            //token
            HXIMHelper hxIMHelper = new HXIMHelper(
                orgName,
                appName, clientId, clientSecret);
            string errMsg = "";
            List<string> users = null;
            hxIMHelper.GetUserContacts("u1", "YWMtMaxS0htaEeWMuV9qSXPpcgAAAU9gnatR1scIxj7FXk4esB9hc622CbiLSiA",ref users, ref errMsg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
              string orgName = "elevendemo";
            string appName = "elevendemoapp";
            string clientId = "YXA6WQDpcBtKEeWhFY0nM0YckA";
            string clientSecret = "YXA6vOyYXwnjmMPnbcL-5O2w6JtX-TQ";
            //string clientId = "YXA6WQDpcBtKEeWhFY0nM0YckA";
            //string clientSecret = "ccA6vOyYXwnjmMPnbcL-5O2w6JtX-TQ";
            //token
            HXIMHelper hxIMHelper = new HXIMHelper(
                orgName,
                appName, clientId, clientSecret);
            string errMsg = "";
             List<string> owners = new List<string>();
             List<string> members = new List<string>();
            hxIMHelper.GetGroupDetails("75932856479646128", "YWMtMaxS0htaEeWMuV9qSXPpcgAAAU9gnatR1scIxj7FXk4esB9hc622CbiLSiA",
                ref owners,
                ref members,
                ref errMsg);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
             string orgName = "elevendemo";
            string appName = "elevendemoapp";
            string clientId = "YXA6WQDpcBtKEeWhFY0nM0YckA";
            string clientSecret = "YXA6vOyYXwnjmMPnbcL-5O2w6JtX-TQ";
            //string clientId = "YXA6WQDpcBtKEeWhFY0nM0YckA";
            //string clientSecret = "ccA6vOyYXwnjmMPnbcL-5O2w6JtX-TQ";
            //token
            HXIMHelper hxIMHelper = new HXIMHelper(
                orgName,
                appName, clientId, clientSecret);
             List<string> owners = new List<string>();
             string errMsg = "";
             List<YAS.ComUtility.IM.HXIMHelper.HXGroupInfoData> groups = null;
             hxIMHelper.GetGroupsByUser("", "", ref groups, ref errMsg);
        }
    }
}
