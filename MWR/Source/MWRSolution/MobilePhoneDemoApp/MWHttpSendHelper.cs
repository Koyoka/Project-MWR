using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using ComLib;
using Newtonsoft.Json.Linq;

namespace MobilePhoneDemoApp
{
    public class MWHttpSendHelper
    {
        


        public static bool SendTxn(ref string resData,ref string errMsg)
        {
            List<JProperty> reqParams = new List<JProperty>();
            reqParams.Add(new JProperty("userName", "eleven"));
            reqParams.Add(new JProperty("password", "121212"));
            string body = "";
            if (reqParams != null && reqParams.Count > 0)
            {
                JObject jo = new JObject();
                for (int i = 0; i < reqParams.Count; i++)
                {
                    jo.Add(reqParams[i]);
                }
                body = jo.ToString();
            }
            RequestToJson(body, "POST", @"http://localhost:15809/Services/MWRecoverServer.aspx", ref resData, ref errMsg);
            
            return true;
        }

        private static bool RequestToJson(string body,string reqMethod,string fullUrl,ref string responseData,ref string errMsg)
        {
            return DoRequest("application/json",body,reqMethod,fullUrl,ref responseData,ref errMsg);
        }

        private static bool DoRequest(string contentType,string body,string reqMethod,string fullUrl,ref string responseData,ref string errMsg)
        {
            Encoding encoding = Encoding.UTF8;

            string result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl);
            {
                #region set request params
                request.Method = reqMethod;
                request.Date = DateTime.Now;
                request.ContentType = "application/json";
                #endregion

                #region set request body data
                using (Stream s = request.GetRequestStream())
                {
                    byte[] buffer = encoding.GetBytes(body);
                    s.Write(buffer, 0, buffer.Length);
                    s.Close();
                }
                #endregion

                #region set reqeust header data
                string encryptStr = "";
                if(true)
                {
                    encryptStr = AuthorizationHelper.EncryptWebBody(AuthorizationHelper.S_SECRET_KEY, reqMethod, contentType, request.Headers.Get("Date"), fullUrl, body, encoding);
                }
                else
                {
                    string hexDigest = "";// getBodyHexDigest(body);// _EMPTY_DIGET;// "d41d8cd98f00b204e9800998ecf8427e";
                    #region Calculate digest
                    {
                        if (string.IsNullOrEmpty(body))
                        {
                            hexDigest = AuthorizationHelper.EMPTY_DIGET;
                        }
                        else
                        {
                            MD5 md5 = new MD5CryptoServiceProvider();
                            byte[] md5Byte = md5.ComputeHash(encoding.GetBytes(body));
                            hexDigest = BitConverter.ToString(md5Byte).Replace("-", "").ToLower();
                        }
                    }
                    #endregion

                    string method = request.Method;
                    //string contentType = request.ContentType;
                    string dateValue = request.Headers.Get("Date");
                    string requestPath = request.RequestUri.LocalPath;// "/targets/4e4149c38c164e209e813028ea79ef06";//r.RequestUri.Host;04-23 13:36:14.540: D/(3942): /targets/4e4149c38c164e209e813028ea79ef06
                    string toDigest = method + "\n" + hexDigest + "\n" + contentType + "\n" + dateValue + "\n" + requestPath;
                    encryptStr = ComFn.CalculateRFC2104HMAC(AuthorizationHelper.S_SECRET_KEY, toDigest);
                    
                }
                request.Headers.Add("Authorization", AuthorizationHelper.S_ACCESS_KEY + ":" + encryptStr);
                #endregion

                #region Send
                using (System.IO.StreamReader sr = new System.IO.StreamReader(request.GetResponse().GetResponseStream(), encoding))
                {
                    responseData = sr.ReadToEnd();

                    sr.Close();
                }
                #endregion
                request = null;
                return true;
            }
        }

        //private void 

        //private static string getBodyHexDigest1(string body)
        //{
        //    if (string.IsNullOrEmpty(body))
        //    {
        //        return _EMPTY_DIGET;
        //    }

        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] md5Byte = md5.ComputeHash(encodeStringToByte(body));
        //    string bodyMd5 = BitConverter.ToString(md5Byte).Replace("-", "").ToLower();
        //    return bodyMd5;
        //}


    }
}
