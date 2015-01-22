using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ComLib
{
    public class AuthorizationHelper
    {
        public const string S_ACCESS_KEY = "9e15f4f7d6fdc178eeab8caf79d863054bdfea78";
        public const string S_SECRET_KEY = "ae46214f1ee0269f7eb5126895ff166f02ede4f1";
        public const string EMPTY_DIGET = "d41d8cd98f00b204e9800998ecf8427e";//igest
        public static string EncryptWebBody(string secretKey,string method, string contentType, string dateValue, string requestPath,string body,Encoding encoding)
        {

            string hexDigest = "";
            if (string.IsNullOrEmpty(body))
            {
                hexDigest = EMPTY_DIGET;
            }
            else
            {
                using (MD5 md5 = new MD5CryptoServiceProvider())
                {
                    byte[] md5Byte = md5.ComputeHash(encoding.GetBytes(body));
                    hexDigest = BitConverter.ToString(md5Byte).Replace("-", "").ToLower();
                }
            }
            //string method = request.Method;
            //string contentType = request.ContentType;
            //string dateValue = request.Headers.Get("Date");
            //string requestPath = request.RequestUri.LocalPath;// "/targets/4e4149c38c164e209e813028ea79ef06";//r.RequestUri.Host;04-23 13:36:14.540: D/(3942): /targets/4e4149c38c164e209e813028ea79ef06
            string toDigest = method + "\n" + hexDigest + "\n" + contentType + "\n" + dateValue + "\n" + requestPath;
            return ComFn.CalculateRFC2104HMAC(secretKey, toDigest);
        }
    }
}
