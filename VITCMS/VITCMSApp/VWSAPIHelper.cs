using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace VITCMSApp
{
    public class VWSAPIHelper
    {
        private static bool isDebug = false;
        private static string _S_ACCESS_KEY = "9e15f4f7d6fdc178eeab8caf79d863054bdfea78";
        private static string _S_SECRET_KEY = "ae46214f1ee0269f7eb5126895ff166f02ede4f1";
        private static string _EMPTY_DIGET = "d41d8cd98f00b204e9800998ecf8427e";//igest
        private static string _URL = isDebug ?"http://localhost:1242/testWeb/test.aspx" : "https://vws.vuforia.com";

        #region VWS API Funtion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">图片名称</param>
        /// <param name="width">宽度 morethen 0</param>
        /// <param name="image">图片二进制数据</param>
        /// <param name="active_flag">是否激活 -[1:不做操作] [0:取消激活] [1:激活]</param>
        /// <param name="application_metadata">图片使用的元数据</param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool AddImageTarget(
            string name,
            float width,
            byte[] image,
            int active_flag,
            byte[] application_metadata,
            ref string errMsg)
        {
            try
            {
                #region valid params
                if (string.IsNullOrEmpty(name) || width <= 0)
                {
                    errMsg = "[NAME] & [width] is mandatory params";
                    return false;
                }
                #endregion

                string body = "";
                #region add request params
                List<JProperty> reqParams = new List<JProperty>();

                reqParams.Add(new JProperty("name", name));
                reqParams.Add(new JProperty("width", width));

                if (image != null)
                {
                    reqParams.Add(new JProperty("image", Convert.ToBase64String(image)));
                }

                if (active_flag != -1)
                {
                    reqParams.Add(new JProperty("active_flag", active_flag == 0 ? false : true));
                }

                if (application_metadata != null)
                {
                    reqParams.Add(new JProperty("application_metadata", Convert.ToBase64String(application_metadata)));
                }

                if (reqParams.Count != 0)
                {
                    body = putRequestBody(reqParams.ToArray());
                }
                else
                {
                    //no params do't do anything
                    return true;
                }
                #endregion

                string fullURL = _URL + "/targets";
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(fullURL);
                r.Method = "POST";

                createRequestBody(r, body);
                createRequestHeader(r, body);

                string result = doRequest(r);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }

            return true;

        }

        /// <summary>
        /// 更新ImageTargets 数据
        /// </summary>
        /// <param name="imageTargetId"></param>
        /// <param name="name">图片名称</param>
        /// <param name="width">宽度 morethen 0</param>
        /// <param name="image">图片二进制数据</param>
        /// <param name="active_flag">是否激活 -[1:不做操作] [0:取消激活] [1:激活]</param>
        /// <param name="application_metadata">图片使用的元数据</param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool UpdateImageTarget(string imageTargetId, 
            string name,
            float width,
            byte[] image,
            int active_flag,
            byte[] application_metadata,
            ref string errMsg)
        {
            try
            {
                string body = "";
                #region add request params
                List<JProperty> reqParams = new List<JProperty>();

                if (!string.IsNullOrEmpty(name))
                {
                    reqParams.Add(new JProperty("name", name));
                }

                if (width > 0)
                {
                    reqParams.Add(new JProperty("width", width));
                }

                if (image != null)
                {
                    reqParams.Add(new JProperty("image",Convert.ToBase64String(image)));
                }

                if (active_flag != -1)
                {
                    reqParams.Add(new JProperty("active_flag", active_flag == 0 ? false : true));
                }

                if (application_metadata != null)
                {
                    reqParams.Add(new JProperty("application_metadata", Convert.ToBase64String(application_metadata)));
                }

                if (reqParams.Count != 0)
                {
                    body = putRequestBody(reqParams.ToArray());
                }
                else
                {
                    //no params do't do anything
                    return true;
                }
                #endregion

                string fullURL = _URL + "/targets/" + imageTargetId;
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(fullURL);
                r.Method = "PUT";

                createRequestBody(r, body);
                createRequestHeader(r, body);

                string result = doRequest(r);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除 imageTarget
        /// </summary>
        /// <param name="imageTargetId"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool DeleteIamgeTarget(string imageTargetId, ref string errMsg)
        {
            try
            {
                
                string fullURL = _URL + "/targets/" + imageTargetId;
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(fullURL);
                r.Method = "DELETE";

                //createRequestBody(r, body);
                createRequestHeader(r);

                string result = doRequest(r);

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取所有的ImageTargets 
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static bool GetImageTargetList(ref string result, ref string errMsg)
        {
            try
            {
                string fullURL = _URL + "/targets";
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(fullURL);
                r.Method = "GET";

                //createRequestBody(r, body);
                createRequestHeader(r);

                result = doRequest(r);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }

            return true;
        }

        public static bool GetImageTargetDetail_Report(string imageTargetId,ref string errMsg)
        {
            try
            {
                string fullURL = _URL + "/summary/" + imageTargetId;
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(fullURL);
                r.Method = "GET";

                //createRequestBody(r, body);
                createRequestHeader(r);

                string result = doRequest(r);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;
        }

        public static bool GetImageTargetDetail_Retrieving(string imageTargetId,ref string result, ref string errMsg)
        {
            try
            {
                string fullURL = _URL + "/targets/" + imageTargetId;
                HttpWebRequest r = (HttpWebRequest)WebRequest.Create(fullURL);
                r.Method = "GET";

                //createRequestBody(r, body);
                createRequestHeader(r);

                result = doRequest(r);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;
        }

        #endregion

        #region utils

        public static byte[] putFileByteArray(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                return null;
            }

            if (!File.Exists(file))
            {
                return null;
            }

            byte[] fileByteArray = null;
            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read);
            try
            {
                fileByteArray = new byte[fileStream.Length];
                int length = fileByteArray.Length;
                int count;
                int sum = 0;
                while ((count = fileStream.Read(fileByteArray, sum, length - sum)) > 0)
                {
                    sum += count;
                }
            }
            finally
            {
                fileStream.Close();
            }

            return fileByteArray;
            
        }

        private static byte[] encodeStringToByte(string s)
        {
            return Encoding.Default.GetBytes(s);
        }

        private static string calculateRFC2104HMAC(string secret, string mk)
        {
            HMACSHA1 hmacsha1 = new HMACSHA1();
            hmacsha1.Key = Encoding.ASCII.GetBytes(secret);
            byte[] dataBuffer = Encoding.ASCII.GetBytes(mk);
            byte[] hashBytes = hmacsha1.ComputeHash(dataBuffer);
            return Convert.ToBase64String(hashBytes);

            //using (System.Security.Cryptography.HMACSHA1 hmac =
            //    new System.Security.Cryptography.HMACSHA1(Encoding.ASCII.GetBytes(secret))
            //    )
            //{
            //    return Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(mk)));
            //}
            //return "";
        }

        private static string getBodyHexDigest(string body)
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

        private static string putRequestBody(params JProperty[] ps)
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

        private static void createRequestBody(HttpWebRequest r, string content)
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

        private static void createRequestHeader(HttpWebRequest r)
        {
            createRequestHeader(r, "");
        }
        private static void createRequestHeader(HttpWebRequest r, string body)
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

        private static string doRequest(HttpWebRequest r)
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

            //MessageBox.Show(result);

            return result;
        }

        #endregion
    }
}
