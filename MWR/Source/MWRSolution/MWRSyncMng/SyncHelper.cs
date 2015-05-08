using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using ComLib.db;
using YRKJ.MWR;

namespace MWRSyncMng
{
    public class SyncHelper
    {
        public void Run()
        { }

        public void Stop()
        { }

        private static bool GetSyncData(ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            DateTime now = SqlDBMng.GetDBNow();
            DateTime lastSyncTime = DateTime.MinValue;

            #region get last sync time
            {
                TblMWSynclog item = null;

                SqlQueryMng sqm = new SqlQueryMng();
                sqm.QueryColumn.AddTop(1);
                sqm.Condition.OrderBy.Add(TblMWSynclog.getSyncDateTimeColumn(), SqlCommonFn.SqlOrderByType.DESC);
                if (!TblMWSynclogCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
                {
                    return false;
                }
                if (item != null)
                {
                    lastSyncTime = item.SyncDateTime;
                }
            }
            //if (lastSyncTime == DateTime.MinValue)
            //{
            //    TblMWTxnRecoverHeader item = null;
            //    SqlQueryMng sqm = new SqlQueryMng();
            //    sqm.QueryColumn.AddTop(1);
            //    sqm.Condition.OrderBy.Add(TblMWTxnRecoverHeader.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);

            //    if (!TblMWTxnRecoverHeaderCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
            //    {
            //        return false;
            //    }

            //    if (item != null)
            //    {
            //        lastSyncTime = item.EntryDate;
            //    }
            //    else
            //    {
            //        lastSyncTime = DateTime.MinValue;
            //    }
            //}
            #endregion

            #region get need sync time
            //{
            //    TimeSpan ts = now - lastSyncTime;
            //    if (ts.Days == 0)
            //    {
            //        //is today
            //        return true;
            //    }

            //    List<DateTime> needSyncDay = new List<DateTime>();
            //    for (int i = 1; i <= ts.Days; i++)
            //    {
            //        DateTime defineTime = DateTime.MinValue;
            //        defineTime = lastSyncTime.AddDays(i);
            //        needSyncDay.Add(defineTime);
            //    }

            //}
            #endregion

            #region get sync data
            //运量
            {
                DateTime syncDate = lastSyncTime;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalSubWeightColumn());
                sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalTxnWeightColumn());
                sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalCrateQtyColumn());
                sqm.Condition.Where.AddDateTimeCompareValue(TblMWTxnRecoverHeader.getEntryDateColumn(), SqlCommonFn.SqlWhereCompareEnum.MoreEquals, syncDate, SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
                sqm.Condition.GroupBy.Add(TblMWTxnRecoverHeader.getEntryDateColumn());

            }
            #endregion

            return true;
        }

        private static bool DoRequest(string assesssKey, string secretKey, string contentType, string body, string reqMethod, string fullUrl, ref string responseData, ref string errMsg)
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
                //string encryptStr = "";
                ////if(true)
                //{
                //    string url = request.RequestUri.AbsolutePath;
                //    encryptStr = AuthorizationHelper.EncryptWebBody(secretKey, reqMethod, contentType, request.Headers.Get("Date"), url, body, encoding);
                //}
                ////else
                ////{
                ////    string hexDigest = "";// getBodyHexDigest(body);// _EMPTY_DIGET;// "d41d8cd98f00b204e9800998ecf8427e";
                ////    #region Calculate digest
                ////    {
                ////        if (string.IsNullOrEmpty(body))
                ////        {
                ////            hexDigest = AuthorizationHelper.EMPTY_DIGET;
                ////        }
                ////        else
                ////        {
                ////            MD5 md5 = new MD5CryptoServiceProvider();
                ////            byte[] md5Byte = md5.ComputeHash(encoding.GetBytes(body));
                ////            hexDigest = BitConverter.ToString(md5Byte).Replace("-", "").ToLower();
                ////        }
                ////    }
                ////    #endregion

                ////    string method = request.Method;
                ////    //string contentType = request.ContentType;
                ////    string dateValue = request.Headers.Get("Date");
                ////    string requestPath = request.RequestUri.LocalPath;// "/targets/4e4149c38c164e209e813028ea79ef06";//r.RequestUri.Host;04-23 13:36:14.540: D/(3942): /targets/4e4149c38c164e209e813028ea79ef06
                ////    string toDigest = method + "\n" + hexDigest + "\n" + contentType + "\n" + dateValue + "\n" + requestPath;
                ////    encryptStr = ComFn.CalculateRFC2104HMAC(AuthorizationHelper.S_SECRET_KEY, toDigest);

                ////}
                //request.Headers.Add("Authorization", "MWR " + assesssKey + ":" + encryptStr);
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
    }
}
