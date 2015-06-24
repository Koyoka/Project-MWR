using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Web;

namespace YAS.ComUtility.SMTP
{
    public class SMTPHelper
    {
        private string _serviceURL = "";//url
        private string _serviceCode = "";

        private string _userName = "";
        private string _userPassword = "";

        public SMTPHelper(string serviceURL,string serviceCode,string userName,string password)
        {
            _serviceURL = serviceURL;
            _serviceCode = serviceCode;
            _userName = userName;
            _userPassword = password;
        }

        #region common
        private string GetTimeStamp()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        private string GetSign(string password, string timeStamp)
        {
            string input = password + timeStamp;
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
               
            }
            return sb.ToString();
        }

        private string ParamsNameValue(string key, string val)
        {
            Encoding encodingGBK = Encoding.GetEncoding("GBK");
            return ParamsNameValue(key, val, encodingGBK);
        }
        private string ParamsNameValue(string key,string val,Encoding encoding)
        {
            return string.Format("{0}={1}&", 
                HttpUtility.UrlEncode(key,encoding), 
                HttpUtility.UrlEncode(val,encoding)
                );
        }
        private string GetRequestParams(string phone,int msgId,string content)
        {
            string timeStamp = GetTimeStamp();
            int priority = 1;// 优先级 1 - 9
            StringBuilder sb = new StringBuilder();
            #region
            {
                sb.Append(ParamsNameValue("timestamp", timeStamp));
                sb.Append(ParamsNameValue("userName", _userName));
                sb.Append(ParamsNameValue("sign", GetSign(_userPassword, timeStamp)));
                sb.Append(ParamsNameValue("serviceCode", _serviceCode));
                sb.Append(ParamsNameValue("phones", phone));
                sb.Append(ParamsNameValue("mhtMsgIds", msgId + ""));
                sb.Append(ParamsNameValue("sendTime", timeStamp));
                sb.Append(ParamsNameValue("priority", priority+""));
                sb.Append(ParamsNameValue("orgCode",""));
                sb.Append(ParamsNameValue("msgType", ""));
                sb.Append(ParamsNameValue("msgContent", content));
                sb.Append(ParamsNameValue("reportFlag", "0"));
            }
            //{
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("timestamp", encodingGBK), timeStamp);
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("userName", encodingGBK), _userName);
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("sign", encodingGBK), GetSign(_userPassword, timeStamp));
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("serviceCode", encodingGBK), _serviceCode);

            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("phones", encodingGBK), phone);
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("mhtMsgIds", encodingGBK), msgId);
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("sendTime", encodingGBK), timeStamp);
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("priority", encodingGBK), priority);
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("orgCode", encodingGBK), "");
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("msgType", encodingGBK), "");
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("msgContent", encodingGBK), content);
            //    sb.AppendFormat("{0}={1}&", HttpUtility.UrlEncode("reportFlag", encodingGBK), 0);
            //}
            #endregion
            string param = sb.ToString().TrimEnd('&');
            return param;
        }
        
        private bool DoRequest(string url, string phone, int msgId, string content,ref string responseData,ref string errMsg)
        {
            try
            {
                Encoding encodingGBK = Encoding.GetEncoding("GBK");

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                {
                    request.Method = "POST";

                    using (Stream s = request.GetRequestStream())
                    {
                        byte[] postBytes = encodingGBK.GetBytes(GetRequestParams(phone, msgId, content)); 
                        s.Write(postBytes, 0, postBytes.Length);
                        s.Close();
                    }
                }

                #region Send
                using (System.IO.StreamReader sr = new System.IO.StreamReader(request.GetResponse().GetResponseStream(), encodingGBK))
                {
                    responseData = sr.ReadToEnd();
                    sr.Close();
                }
                #endregion
                request = null;
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }
        #endregion

        public bool Send(
            int msgId,
            string phone,
            string content,
            ref string responseData,
            ref string errMsg
            )
        {
            return DoRequest(_serviceURL, phone, msgId, content, ref responseData, ref errMsg);
           
        }


    }
}
