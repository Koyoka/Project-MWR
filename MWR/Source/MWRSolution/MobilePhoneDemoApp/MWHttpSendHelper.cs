using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using ComLib;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MobilePhoneDemoApp
{
    public class MWHttpSendHelper
    {

        public static bool RequestToJson(string assesssKey, string secretKey, string body, string reqMethod, string fullUrl, ref string responseData, ref string errMsg)
        {
            return DoRequest(assesssKey,secretKey,"application/json",body,reqMethod,fullUrl,ref responseData,ref errMsg);
        }

        private static bool DoRequest(string assesssKey,string secretKey,string contentType,string body,string reqMethod,string fullUrl,ref string responseData,ref string errMsg)
        {
            Encoding encoding = Encoding.UTF8;

            string result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl+"?a=1");
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
                //if(true)
                {
                    string url = request.RequestUri.AbsolutePath;
                    encryptStr = AuthorizationHelper.EncryptWebBody(secretKey, reqMethod, contentType, request.Headers.Get("Date"), url, body, encoding);
                }
                //else
                //{
                //    string hexDigest = "";// getBodyHexDigest(body);// _EMPTY_DIGET;// "d41d8cd98f00b204e9800998ecf8427e";
                //    #region Calculate digest
                //    {
                //        if (string.IsNullOrEmpty(body))
                //        {
                //            hexDigest = AuthorizationHelper.EMPTY_DIGET;
                //        }
                //        else
                //        {
                //            MD5 md5 = new MD5CryptoServiceProvider();
                //            byte[] md5Byte = md5.ComputeHash(encoding.GetBytes(body));
                //            hexDigest = BitConverter.ToString(md5Byte).Replace("-", "").ToLower();
                //        }
                //    }
                //    #endregion

                //    string method = request.Method;
                //    //string contentType = request.ContentType;
                //    string dateValue = request.Headers.Get("Date");
                //    string requestPath = request.RequestUri.LocalPath;// "/targets/4e4149c38c164e209e813028ea79ef06";//r.RequestUri.Host;04-23 13:36:14.540: D/(3942): /targets/4e4149c38c164e209e813028ea79ef06
                //    string toDigest = method + "\n" + hexDigest + "\n" + contentType + "\n" + dateValue + "\n" + requestPath;
                //    encryptStr = ComFn.CalculateRFC2104HMAC(AuthorizationHelper.S_SECRET_KEY, toDigest);
                    
                //}
                request.Headers.Add("Authorization", "MWR " + assesssKey + ":" + encryptStr);
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

        public static bool DoMWServerResponseData(string resData,ref string resultData,ref string errMsg)
        {
            try
            {
                JObject jo = (JObject)JsonConvert.DeserializeObject(resData);
                bool Error = jo["Error"].ToString().ToLower().Equals("true");
                string ErrMsg = jo["ErrMsg"].ToString();
                string Result = jo["Result"].ToString();

                if (Error)
                {
                    errMsg = ErrMsg;
                    return false;
                }
                resultData = Result;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;
        }
    }
}
