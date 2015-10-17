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
using YAS.ComUtility.Common;
using System.Collections.Specialized;
using YRKJ.MWR.WinBase.WinAppBase;
using System.Web;


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

        private void button6_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:6243/api/services/app/user/UpdateUser";
            string body = "";
            {
                var item = new {
                    NickName = "小明"
                };

                string s = HttpUtility.UrlEncode("小明");
                body = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            }
            NameValueCollection nv = new NameValueCollection();
            nv.Add("Cookie", ".AspNet.ApplicationCookie=oKsOVqndMfuL2Bd8jjjGjfvVmB3yyZUXZvv3C9PG2sjLbKJTIyGC4JNCnMCXk7BSKMsXTT-hmwR-EoiAv6_noP9Mi4tbV4L-B62YxCecSFMts237P9xHIDr-Fdl5qyTgEs5uZHKpiMUJPlf_81kEdZCqzq8A-9Z_ar_NtrULpEEsau0aZTFNiZPBz-aYdY6-eazP1U8peTzN4Ao2zBeFItBI4pJ84w7KZw72b6arW8N3HyZiOAirGrHM6bAFg3_WUv74YxsPznG_qvQAC1KhV3Bs40MbWBSw702DwhcumHnx7BVPNXwE6yO6LJ1TUSOZpwm97eTocmhUPMqyOrAnyFE2MAdqIuSTSNwCp5-b9M-PpejeI_XVcEs34rCOa4o8JZ5PhQ9ZPucpQfjRahJpON2p2PzuCIZ7HSN9XSogK428M_tZFM-dl5PUHbjYOS_2; path=/; HttpOnly ");

            string resData = "";
            int code = 0;
            string errMsg = "";
            if (!HttpHelper.DoHttp(url, "POST", "application/json", body, nv, Encoding.UTF8, ref resData, ref code, ref errMsg))
            {
                MsgBox.Error(errMsg);
            }
        }

        class YASTestHelper
        {
            #region model
            public class UpdUser
            {
                public string NickName { get; set; }

                /// <summary>
                /// 性别
                /// </summary>
                public string Gender { get; set; }

                /// <summary>
                /// 公司
                /// </summary>
                public string Company { get; set; }

                /// <summary>
                /// 公司职务
                /// </summary>
                public string Title { get; set; }

                /// <summary>
                /// 手机号
                /// </summary>
                public string PhoneNumber { get; set; }
            }
            #endregion

            #region do
            public static bool DoUpdateUser()
            {


                return true;
            }
            #endregion
        }
    }
}
