using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using ComLib.db;
using YRKJ.MWR;
using YRKJ.MWR.Business.Sys;
using Newtonsoft.Json;

namespace MWRSyncMng
{
    public class SyncHelper
    {
        public void Run()
        { }

        public void Stop()
        { }

        public static bool GetSyncData(ref List<SyncReportData> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            DateTime now = SqlDBMng.GetDBNow();
            DateTime lastSyncTime = DateTime.MinValue;

            #region get last sync time
            {
                TblMWSynclog item = null;

                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWSynclog.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWSynclog.STATUS_ENUM_Complete);
                sqm.QueryColumn.AddTop(1);
                sqm.Condition.OrderBy.Add(TblMWSynclog.getSyncDateTimeColumn(), SqlCommonFn.SqlOrderByType.ASC);
                if (!TblMWSynclogCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
                {
                    return false;
                }
                if (item != null)
                {
                    lastSyncTime = item.SyncDateTime;
                }
            }
            if (lastSyncTime == DateTime.MinValue)
            {
                TblMWTxnRecoverHeader item = null;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.QueryColumn.AddTop(1);
                sqm.Condition.OrderBy.Add(TblMWTxnRecoverHeader.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.ASC);

                if (!TblMWTxnRecoverHeaderCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
                {
                    return false;
                }

                if (item != null)
                {
                    lastSyncTime = item.EntryDate;
                }
                else
                {
                    //no data
                    return true;
                }
            }
           
            #endregion

            #region get sync data
            //运量
            List<TblMWTxnRecoverHeader> txnRecoverHeaderList = null;
            {
                DateTime syncDate = lastSyncTime;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalSubWeightColumn());
                sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalTxnWeightColumn());
                sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalCrateQtyColumn());
                //sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getEntryDateColumn());
                string formatColname = SqlCommonFn.FormatSqlDateTimeColumnString2(TblMWTxnRecoverHeader.getEntryDateColumn(), SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
                sqm.QueryColumn.Add(formatColname, "Date2");
                sqm.Condition.Where.AddDateTimeCompareValue(TblMWTxnRecoverHeader.getEntryDateColumn(), SqlCommonFn.SqlWhereCompareEnum.MoreEquals, syncDate, SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
                sqm.Condition.OrderBy.Add(TblMWTxnRecoverHeader.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.ASC);
                sqm.Condition.GroupBy.Add("Date2");

                List<TblMWTxnRecoverHeader> itemList = null;
                if (!TblMWTxnRecoverHeaderCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
                {
                    return false;
                }
                txnRecoverHeaderList = itemList;
                //itemList[0].GetValue("");
                //reportData.ReportInCarAndSubWeight = itemList;
                //object d = itemList[0].GetValue("Date2");
            }

            //回收总量，出库总量，处置总量
            List<TblMWInventory> inventoryList = null;
            {
                DateTime syncDate = lastSyncTime;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.QueryColumn.Add(TblMWInventory.getRecoWeightColumn());
                sqm.QueryColumn.Add(TblMWInventory.getInvWeightColumn());
                sqm.QueryColumn.Add(TblMWInventory.getPostWeightColumn());
                sqm.QueryColumn.Add(TblMWInventory.getDestWeightColumn());
                //sqm.QueryColumn.Add(TblMWInventory.getEntryDateColumn());
                string formatColname = SqlCommonFn.FormatSqlDateTimeColumnString2(TblMWTxnRecoverHeader.getEntryDateColumn(), SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
                sqm.QueryColumn.Add(formatColname, "Date2");
                sqm.Condition.Where.AddDateTimeCompareValue(TblMWInventory.getEntryDateColumn(), SqlCommonFn.SqlWhereCompareEnum.MoreEquals, syncDate, SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
                sqm.Condition.GroupBy.Add("Date2");
                //sqm.Condition.GroupBy.Add(TblMWInventory.getEntryDateColumn());

                List<TblMWInventory> itemList = null;
                if (!TblMWInventoryCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
                {
                    return false;
                }
                inventoryList = itemList;
            }
            #endregion

            #region set sync data
            List<SyncReportData> syncReportDataList = new List<SyncReportData>();
            {
                DateTime d = lastSyncTime;
                //StringBuilder sb = new StringBuilder();
                for (int i = 0; (now - d.AddDays(i)).Days > 0; i++)
                {
                    DateTime reportDate = d.AddDays(i);
                    string defineDateStr = reportDate.ToString("yyyy-MM-dd");
                    SyncReportData rData = new SyncReportData();

                    {
                        bool hasData = false;
                        foreach (var item in txnRecoverHeaderList)
                        {
                            if (item.GetValue("Date2").ToString() == defineDateStr)
                            {
                                rData.RecoverInCarWeigth = item.TotalSubWeight;
                                rData.RecoverSubWeigth = item.TotalTxnWeight;
                                hasData = true;
                                break;
                            }
                        }

                        foreach (var item in inventoryList)
                        {
                            if (item.GetValue("Date2").ToString() == defineDateStr)
                            {
                                rData.RecoverTxnWeight = item.InvWeight;
                                //rData.InvWeight = item.PostWeight - item.InvWeight;
                                rData.PostTxnWeight = item.PostWeight;
                                rData.DestroyTxnWeight = item.DestWeight;
                                hasData = true;
                                break;
                            }
                        }
                        if (hasData)
                        {
                            rData.ReportData = reportDate;
                            syncReportDataList.Add(rData);
                        }
                    }
                }

                dataList = syncReportDataList;
            }
            #endregion
            

            return true;
        }
        
        public static bool DoSycn(ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            TblMWSynclog item = new TblMWSynclog();
            item.SyncDateTime = SqlDBMng.GetDBNow();
            item.Status = TblMWSynclog.STATUS_ENUM_Complete;

            int updCount = 0;
            if (!TblMWSynclogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
            {
                return false;
            }

            return true;
        }
       
        public static bool DoRequest(
            List<SyncReportData> reportDataList, ref string errMsg)
        {
            ResJsonData data = new ResJsonData();
            List<ResJsonData.ResJsonBusData> busdata = new List<ResJsonData.ResJsonBusData>();

            string guid = "";
            string city = "";
            #region get lcoation client base infomation

            #endregion

            #region set request json data
            data.city = city;
            data.guid = guid;
            foreach (var item in reportDataList)
            {
                #region //运量
                {
                    ResJsonData.ResJsonBusData defineBusData = new ResJsonData.ResJsonBusData();
                    defineBusData.createtime = item.ReportData.ToString("yyyy-MM-dd");
                    defineBusData.opttype = ResJsonData.ResJsonBusData_OptType_InCar;
                    defineBusData.optnum = item.RecoverInCarWeigth.ToString();
                    busdata.Add(defineBusData);
                }
                #endregion

                #region //接货量
                {
                    ResJsonData.ResJsonBusData defineBusData = new ResJsonData.ResJsonBusData();
                    defineBusData.createtime = item.ReportData.ToString("yyyy-MM-dd");
                    defineBusData.opttype = ResJsonData.ResJsonBusData_OptType_RecoSub;
                    defineBusData.optnum = item.RecoverSubWeigth.ToString();
                    busdata.Add(defineBusData);
                }
                #endregion

                #region //入库
                {
                    ResJsonData.ResJsonBusData defineBusData = new ResJsonData.ResJsonBusData();
                    defineBusData.createtime = item.ReportData.ToString("yyyy-MM-dd");
                    defineBusData.opttype = ResJsonData.ResJsonBusData_OptType_RecoTxn;
                    defineBusData.optnum = item.RecoverTxnWeight.ToString();
                    busdata.Add(defineBusData);
                }
                #endregion

                #region //库存
                {
                    //ResJsonData.ResJsonBusData defineBusData = new ResJsonData.ResJsonBusData();
                    //defineBusData.createtime = item.ReportData.ToString("yyyy-MM-dd");
                    //defineBusData.opttype = ResJsonData.ResJsonBusData_OptType_;
                    //defineBusData.optnum = item.RecoverTxnWeight.ToString();
                    //busdata.Add(defineBusData);
                }
                #endregion

                #region //出库
                {
                    ResJsonData.ResJsonBusData defineBusData = new ResJsonData.ResJsonBusData();
                    defineBusData.createtime = item.ReportData.ToString("yyyy-MM-dd");
                    defineBusData.opttype = ResJsonData.ResJsonBusData_OptType_PostTxn;
                    defineBusData.optnum = item.PostTxnWeight.ToString();
                    busdata.Add(defineBusData);
                }
                #endregion

                #region //处置
                {
                    ResJsonData.ResJsonBusData defineBusData = new ResJsonData.ResJsonBusData();
                    defineBusData.createtime = item.ReportData.ToString("yyyy-MM-dd");
                    defineBusData.opttype = ResJsonData.ResJsonBusData_OptType_DestTxn;
                    defineBusData.optnum = item.DestroyTxnWeight.ToString();
                    busdata.Add(defineBusData);
                }
                #endregion

            }
            data.busdata = busdata;
            #endregion

            #region convent to json str
            string jsonStr = "";
            if (!ObjectToJson(data, ref jsonStr, ref errMsg))
            {
                return false;
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

        public static bool ObjectToJson(object obj, ref string jsonStr, ref string errMsg)
        {
            try
            {
                jsonStr = JsonConvert.SerializeObject(obj);
                return true;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        public class SyncReportData
        {
            //public List<TblMWTxnRecoverHeader> ReportInCarAndSubWeight = new List<TblMWTxnRecoverHeader>();
            //public List<TblMWInventory> ReportInventoryWeigth = new List<TblMWInventory>();

            public decimal RecoverInCarWeigth { get; set; }//运量
            public decimal RecoverSubWeigth { get; set; }//接货量
            public decimal RecoverTxnWeight { get; set; }//入库量
            public decimal InvWeight { get; set; }//库存量
            public decimal PostTxnWeight { get; set; }//出库量
            public decimal DestroyTxnWeight { get; set; }//处置量
            public DateTime ReportData { get; set; }

        }
        public class ResJsonData
        {
            public string guid { get; set; }
            public string city { get; set; }
            public List<ResJsonBusData> busdata { get; set; }
            public class ResJsonBusData
            {
                public string createtime { get; set; }
                public string opttype { get; set; }
                public string optnum { get; set; }
                public string remark { get; set; }
            }
            public const string ResJsonBusData_OptType_InCar = "1";
            public const string ResJsonBusData_OptType_RecoSub = "2";
            public const string ResJsonBusData_OptType_RecoTxn = "3";
            public const string ResJsonBusData_OptType_Inv = "4";
            public const string ResJsonBusData_OptType_PostTxn = "5";
            public const string ResJsonBusData_OptType_DestTxn = "6";
        }

    }
}
