using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace YAS.ComUtility.Common
{
    public class HttpHelper
    {

        public static bool DoPostHttp(string url, string requestBody, ref string responseData, ref int statusCode, ref string errMsg)
        {
            Encoding encoding = Encoding.UTF8;
            return DoHttp(url, "POST", "", 
                requestBody,
                null,
                encoding, 
                ref responseData, ref statusCode, ref errMsg);
        }
        public static bool DoPostJSONHttp(string url, string requestBody, ref string responseData, ref int statusCode, ref string errMsg)
        {
            Encoding encoding = Encoding.UTF8;
            return DoHttp(url, "POST", "application/json", 
                requestBody, 
                null,
                encoding, 
                ref responseData, ref statusCode, ref errMsg);
        }
        public static bool DoGetHttp(string url, NameValueCollection headerNVs, ref string responseData, ref int statusCode, ref string errMsg)
        {
            Encoding encoding = Encoding.UTF8;
            return DoHttp(url, "Get", "",
                "",
                headerNVs,
                encoding,
                ref responseData, ref statusCode, ref errMsg);
        }

        public static bool DoHttp(
            string url, string method, string contentType, 
            string requestBody, 
            NameValueCollection headerNVs,
            Encoding encoding,
            ref string responseData,ref int statusCode, ref string errMsg)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 5000;
                request.Method = method;
                if (headerNVs != null)
                    request.Headers.Add(headerNVs);
                if (!string.IsNullOrEmpty(contentType))
                    request.ContentType = contentType;

                if (!string.IsNullOrEmpty(requestBody))
                {
                    using (Stream s = request.GetRequestStream())
                    {
                        byte[] postBytes = encoding.GetBytes(requestBody);
                        s.Write(postBytes, 0, postBytes.Length);
                        s.Close();
                    }
                }

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                if (response == null)
                {
                    errMsg = "response is null";
                    return false;
                }
                statusCode = (int)response.StatusCode;  
                using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                {
                    responseData = sr.ReadToEnd();
                    sr.Close();
                }
                return true;

            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    statusCode = (int)(ex.Response as HttpWebResponse).StatusCode;
                }
                errMsg = ex.Message;
                return false;
            }
        }
    }
}
