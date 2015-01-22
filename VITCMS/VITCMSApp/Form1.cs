using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VITCMSApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                MainForm f = new MainForm();
                f.ShowDialog();
                return;
            }

            return;
            {
                EditImageTargetForm f = new EditImageTargetForm();
                f.ShowDialog();
            }
            return;
            string errMsg = "";
            string fileFullPath = c_txtFileName.Text.Trim();
            byte[] image = VWSAPIHelper.putFileByteArray(fileFullPath);
            if (image == null)
            {
                return;
            }
            if (!VWSAPIHelper.AddImageTarget("NewImage", 32.0f, image, -1, null, ref errMsg))
            {
                MessageBox.Show(errMsg);
            }

            return;
            if (!VWSAPIHelper.UpdateImageTarget("4e4149c38c164e209e813028ea79ef06", "bbbb", 0, image, -1, null, ref errMsg))
            {
                MessageBox.Show(errMsg);
            }
            return;
            updateImage("4e4149c38c164e209e813028ea79ef06");
            return;
            send();
        }



        private static bool isDebug = false;
        private static string _S_ACCESS_KEY = isDebug ? "8b60b06310297d99e964857e729211f8b2244989" : "9e15f4f7d6fdc178eeab8caf79d863054bdfea78";
        private static string _S_SECRET_KEY = isDebug ? "0f8d40366fd8ea0a582d6096083a2efcbe71d123" : "ae46214f1ee0269f7eb5126895ff166f02ede4f1";
        private static string _EMPTY_DIGET = "d41d8cd98f00b204e9800998ecf8427e";//igest
        private static string _URL = "https://vws.vuforia.com";
       
       

        private byte[] encodeStringToByte(string s)
        {
            return Encoding.Default.GetBytes(s);
        }

        private string getBodyHexDigest(string body)
        {
            if (string.IsNullOrEmpty(body))
            {
                return _EMPTY_DIGET;
            }

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5Byte = md5.ComputeHash(encodeStringToByte(body));
            string bodyMd5 = BitConverter.ToString(md5Byte).Replace("-", "").ToLower();
            return bodyMd5;
        }

        private string putRequestBody(params JProperty[] ps)
        {
            if (ps != null && ps.Length > 0)
            {
                JObject jo = new JObject();
                for (int i = 0; i < ps.Length; i++)
                {
                    jo.Add(ps[i]);
                }
                return jo.ToString();
            }
            return "";
        }

        private void createRequestBody(HttpWebRequest r,string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            Stream s = r.GetRequestStream();
            byte[] buffer = encodeStringToByte(content);
            s.Write(buffer, 0, buffer.Length);
            s.Close();
        }

        private void createRequestHeader(HttpWebRequest r,string body)
        {
            r.Date = DateTime.Now;
            if (!string.IsNullOrEmpty(body))
            {
                r.ContentType = "application/json";
            }

            string method = r.Method;
            string hexDigest = getBodyHexDigest(body);// _EMPTY_DIGET;// "d41d8cd98f00b204e9800998ecf8427e";
            string contentType = r.ContentType;
            string dateValue = r.Headers.Get("Date");
            string requestPath = r.RequestUri.LocalPath;// "/targets/4e4149c38c164e209e813028ea79ef06";//r.RequestUri.Host;04-23 13:36:14.540: D/(3942): /targets/4e4149c38c164e209e813028ea79ef06
            string toDigest = method + "\n" + hexDigest + "\n" + contentType + "\n" + dateValue + "\n" + requestPath;

            r.Headers.Add("Authorization",
                "VWS " +
                _S_ACCESS_KEY +
                ":" +
                calculateRFC2104HMAC(_S_SECRET_KEY, toDigest));
        }

        private string doRequest(HttpWebRequest r)
        {
            WebResponse wresp = null;
            wresp = r.GetResponse();
            Stream stream2 = wresp.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);
            string result = string.Empty;
            result = reader2.ReadToEnd();
            if (wresp != null)
            {
                wresp.Close();
                wresp = null;
            }

            r = null;

            return result;
        }

        private void updateImage(string id)
        {
            string fullURL = _URL + "/targets/"+id;
         
            HttpWebRequest r = (HttpWebRequest)WebRequest.Create(
                   !isDebug ? fullURL : "http://localhost:1242/testWeb/test.aspx");
            r.Method = "PUT";

            string body = putRequestBody(
                //new JProperty("active_flag",false)
                new JProperty("name","eleven")
                );

            createRequestBody(r, body);
            createRequestHeader(r, body);
            doRequest(r);

            #region none
            //r.Date = DateTime.Now;
            //if (!string.IsNullOrEmpty(body))
            //{
            //    r.ContentType = "application/json";
            //}
            //string method = r.Method;
            //string hexDigest = getBodyHexDigest(body);// _EMPTY_DIGET;// "d41d8cd98f00b204e9800998ecf8427e";
            //string contentType = r.ContentType;
            //string dateValue = r.Headers.Get("Date");
            //string requestPath = r.RequestUri.LocalPath;// "/targets/4e4149c38c164e209e813028ea79ef06";//r.RequestUri.Host;04-23 13:36:14.540: D/(3942): /targets/4e4149c38c164e209e813028ea79ef06
            //string toDigest = method + "\n" + hexDigest + "\n" + contentType + "\n" + dateValue + "\n" + requestPath;

            ////string digest = calculateRFC2104HMAC(_S_SECRET_KEY, toDigest);
            ////MessageBox.Show(toDigest+"  " + digest);
            
            //r.Headers.Add("Authorization", 
            //    "VWS " + 
            //    _S_ACCESS_KEY + 
            //    ":" +
            //    calculateRFC2104HMAC(_S_SECRET_KEY, toDigest));

            #endregion

            #region send none
            //WebResponse wresp = null;
            //wresp = r.GetResponse();
            //Stream stream2 = wresp.GetResponseStream();
            //StreamReader reader2 = new StreamReader(stream2);
            //string result = string.Empty;
            //result = reader2.ReadToEnd();
            //if (wresp != null)
            //{
            //    wresp.Close();
            //    wresp = null;
            //}

            //r = null;
            //MessageBox.Show(result);
            #endregion

            #region none
            //DataContractJsonSerializer json = new DataContractJsonSerializer(;
            //JObject jo = new JObject();

            //JProperty p1 = new JProperty("age", "");
            //jo.Add("active_flag", false);
            //jo.Add(p1);
            //MessageBox.Show(jo.ToString());

            #region none
            //Stream s = r.GetRequestStream();
            //string body = jo.ToString();// "{\"active_flag\":false}";
            //byte[] bodyByty = Encoding.Default.GetBytes(body);
            //s.Write(bodyByty, 0, bodyByty.Length);
            //s.Close();

            //MD5 md5 = new MD5CryptoServiceProvider();
            //byte[] md5Byte = md5.ComputeHash(bodyByty);
            //string bodyMd5 = BitConverter.ToString(md5Byte).Replace("-", "").ToLower();
            //MessageBox.Show(bodyMd5);
            //string Content_MD5 = FormsAuthentication.HashPasswordForStoringInConfigFile("aaa", "MD5").ToLower();
            #endregion
            #endregion
        }

        

        private void send()
        {
            HttpWebRequest r = (HttpWebRequest)WebRequest.Create(
                !isDebug ? "https://vws.vuforia.com/targets" : "http://localhost:1242/testWeb/test.aspx");
            //r.Headers.Add(HttpRequestHeader.Date, DateTime.Now.ToString());
            r.Method = "GET";
            r.Date = DateTime.Now;
            //r.ContentType = "application/json";
            

            string method = r.Method;
            string hexDigest = "d41d8cd98f00b204e9800998ecf8427e";
            string contentType = "";// r.ContentType;
            string dateValue = r.Headers.Get("Date");
            string requestPath = "/targets";//r.RequestUri.Host;
            string toDigest = method + "\n" + hexDigest + "\n" + contentType + "\n" + dateValue + "\n" + requestPath;

            string digest = calculateRFC2104HMAC(_S_SECRET_KEY,toDigest);
            r.Headers.Add("Authorization", "VWS " + _S_ACCESS_KEY + ":" + digest);

            WebResponse wresp = null;
            wresp = r.GetResponse();
            Stream stream2 = wresp.GetResponseStream();
            StreamReader reader2 = new StreamReader(stream2);
            string result = string.Empty;
            result = reader2.ReadToEnd();
            if (wresp != null)
            {
                wresp.Close();
                wresp = null;
            }
            
            r = null;
            MessageBox.Show(result);

        }

        private string calculateRFC2104HMAC(string secret,string mk)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.ASCII.GetBytes(secret);
            byte[] dataBuffer = Encoding.ASCII.GetBytes(mk);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);

            using (System.Security.Cryptography.HMACSHA1 hmac =
                new System.Security.Cryptography.HMACSHA1(Encoding.ASCII.GetBytes(secret))
                )
            {

                return Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(mk)));
            }
            return "";
        }

        private void c_btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                c_txtFileName.Text = openFileDialog1.FileName;
                string fileFullPath = c_txtFileName.Text.Trim();
                //VWSAPIHelper.putFileByteArray(fileFullPath);
            }
        }
    }
}
