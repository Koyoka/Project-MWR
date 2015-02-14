using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YRKJ.MWR.BackOffice.Business.Sys;
using Newtonsoft.Json.Linq;
using ComLib.Log;
using ComLib;
using YRKJ.MWR.Business;
using YRKJ.MWR.Business.BO;
using System.Text;
using Newtonsoft.Json;
using YRKJ.MWR.Business.BaseData;

namespace YRKJ.MWR.BackOffice.Services
{
    /// <summary>
    /// MWMobileWSHandler 的摘要说明
    /// </summary>
    public class MWMobileWSHandler : IHttpHandler
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Services.MWMobileWSHandler";

        private const string RequestMethod_RecoverInventorySubmit = "RecoverInventorySubmit";
        private const string RequestMethod_RecoverDestroySubmit = "RecoverDestroySubmit";
        private const string RequestMethod_InitMWS = "InitMWSSubmit";


        #region main
        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            try
            {
                string errMsg = "";

                switch (context.Request.HttpMethod)
                {
                    case "HEAD":
                    case "GET":
                        break;

                    case "POST":
                    case "PUT":
                        if (!InitPostHandle(context, ref errMsg))
                        {
                            WriteError(context, errMsg);
                            return;
                        }
                        break;

                    case "DELETE":
                        break;

                    case "OPTIONS":
                        ReturnOptions(context);
                        return;
                    default:
                        context.Response.ClearHeaders();
                        context.Response.StatusCode = 405;
                        return;
                }

              
            }
            catch (Exception ex)
            {
                LogMng.GetLog().PrintError(ClassName, "ProcessRequest", ex);
                WriteError(context, ex.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion
        
        #region Internal Functions
        private bool InitPostHandle(HttpContext context,ref string errMsg)
        {
            string requestData = "";
            #region get response data
            using (System.IO.StreamReader sr = new System.IO.StreamReader(context.Request.InputStream, Encoding.UTF8))
            {
                requestData = sr.ReadToEnd();
                sr.Close();
            }
            #endregion

            JObject reqDataValue = null;
            string action = "";
            string authorization = "";
            #region get response data params
            JObject jo = (JObject)JsonConvert.DeserializeObject(requestData);
            {
                action = WebAppFn.SafeJsonToString("action", jo);
                reqDataValue = (JObject)jo["value"];
            }
            authorization = context.Request.Headers.Get("Authorization");
           
            #endregion

            #region valid response data
            if (!InitHandle_ValidAuthorize(context, authorization, requestData, ref errMsg))
            {
                return false;
            }
            #endregion

            #region handler response data
            switch (action)
            {
                case RequestMethod_RecoverInventorySubmit:
                    if (!RecoverInventorySubmit(reqDataValue, ref errMsg))
                        return false;
                    break;
                case RequestMethod_RecoverDestroySubmit:
                    if (!RecoverDestroySubmit(reqDataValue, ref errMsg))
                        return false;
                    break;
                case "test":

                    break;
                default:
                    errMsg = "unvalid action params";
                    return false;
            }
            #endregion
            WriteJson(context, "success");
            return true;
        }

        private bool InitHandle_ValidAuthorize(HttpContext context, string authorizetion, string requestData, ref string errMsg)
        {
            if (string.IsNullOrEmpty(authorizetion))
            {
                errMsg = LngRes.MSG_InvalidSubmit;
                return false;
            }
            else
            {
                string[] vals = authorizetion.TrimStart("MWR".ToCharArray()).Split(':');
                if (vals == null)
                {
                    errMsg = LngRes.MSG_InvalidSubmit;
                    return false;
                }
                else if (vals.Length != 2)
                {
                    errMsg = LngRes.MSG_InvalidSubmit;
                    return false;
                }

                string accessKey = "";
                string secretKey = "";
                string reqEncryptStr = "";

                accessKey = vals[0].Trim();
                reqEncryptStr = vals[1].Trim();

                TblMWWorkStation ws = null;
                if (!BaseDataMng.GetWSByAssessKey(accessKey, ref ws, ref errMsg))
                {
                    return false;
                }
                if (ws == null)
                {
                    errMsg = LngRes.MSG_InvalidAssessKey + " " + accessKey;
                    return false;
                }
                secretKey = ws.SecretKey;

                string reqMethod = context.Request.HttpMethod;
                string contentType = context.Request.ContentType;
                string date = context.Request.Headers.Get("Date");
                string fullUrl = context.Request.Url.AbsolutePath;//.Url.ToString();
                string encryptStr =
                    ComLib.AuthorizationHelper.EncryptWebBody(secretKey, reqMethod, contentType, date, fullUrl, requestData, Encoding.UTF8);

                if (!reqEncryptStr.Equals(encryptStr))
                {
                    errMsg = LngRes.MSG_InvalidSecretKey;
                    return false;
                }
            }
            return true;
        }

        private static void ReturnOptions(HttpContext context)
        {
            context.Response.AddHeader("Allow", "DELETE,GET,HEAD,POST,PUT,OPTIONS");
            context.Response.StatusCode = 200;
        }

        private void WriteError(HttpContext context, string errMsg)
        {
            context.Response.AddHeader("Vary", "Accept");
            try
            {
                if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    context.Response.ContentType = "application/json";
                else
                    context.Response.ContentType = "text/plain";
            }
            catch
            {
                context.Response.ContentType = "text/plain";
            }
            OutputData data = OutputData.SetError(errMsg);
            var jsonObj = JsonConvert.SerializeObject(data);
            context.Response.Write(jsonObj);

        }
        private void WriteJson(HttpContext context,string msg)
        {
            context.Response.AddHeader("Vary", "Accept");
            try
            {
                if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    context.Response.ContentType = "application/json";
                else
                    context.Response.ContentType = "text/plain";
            }
            catch
            {
                context.Response.ContentType = "text/plain";
            }
            OutputData data = OutputData.SetSuccess(msg);
            var jsonObj = JsonConvert.SerializeObject(data);
            context.Response.Write(jsonObj);
        }

        #endregion

        #region External Interface
        private bool RecoverDestroySubmit(JObject reqDataValue, ref string errMsg)
        {
            JObject jValue = reqDataValue;
            try
            {
                #region set data
                TblMWTxnRecoverHeader txnHeader = new TblMWTxnRecoverHeader();
                txnHeader.CarCode = WebAppFn.SafeJsonToString("carcode", jValue);
                txnHeader.Driver = WebAppFn.SafeJsonToString("drvier", jValue);//= DemoData.GetInstance().Driver;
                txnHeader.DriverCode = WebAppFn.SafeJsonToString("drivercode", jValue); //DemoData.GetInstance().DriverCode;
                txnHeader.Inspector = WebAppFn.SafeJsonToString("inspector", jValue); //DemoData.GetInstance().Inspector;
                txnHeader.InspectorCode = WebAppFn.SafeJsonToString("inspectorcode", jValue); //DemoData.GetInstance().InspectorCode;
                txnHeader.RecoMWSCode = WebAppFn.SafeJsonToString("mwscode", jValue); //DemoData.GetInstance().MWSCode;

                List<TblMWTxnDetail> txnDetailList = new List<TblMWTxnDetail>();
                {
                    JArray jTxnDtlList = (JArray)jValue["txndetaillist"];

                    for (int i = 0; i < jTxnDtlList.Count; i++)
                    {
                        JObject jDtl = (JObject)jTxnDtlList[i];
                        TblMWTxnDetail dtl = new TblMWTxnDetail();
                        //dtl.TxnDetailId = WebAppFn.SafeJsonToString("TxnDetailId", jDtl);
                        //dtl.TxnType = WebAppFn.SafeJsonToString("TxnType", jDtl);
                        //dtl.TxnNum = WebAppFn.SafeJsonToString("TxnNum", jDtl);
                        //dtl.WSCode = WebAppFn.SafeJsonToString("WSCode", jDtl);
                        //dtl.EmpyName = WebAppFn.SafeJsonToString("EmpyName", jDtl);
                        //dtl.EmpyCode = WebAppFn.SafeJsonToString("EmpyCode", jDtl);
                        dtl.CrateCode = WebAppFn.SafeJsonToString("CrateCode", jDtl);
                        dtl.Vendor = WebAppFn.SafeJsonToString("Vendor", jDtl);
                        dtl.VendorCode = WebAppFn.SafeJsonToString("VendorCode", jDtl);
                        dtl.Waste = WebAppFn.SafeJsonToString("Waste", jDtl);
                        dtl.WasteCode = WebAppFn.SafeJsonToString("WasteCode", jDtl);
                        //dtl.SubWeight = ComFn.StringToDecimal(WebAppFn.SafeJsonToString("SubWeight", jDtl));
                        decimal subWeight = ComFn.StringToDecimal(WebAppFn.SafeJsonToString("SubWeight", jDtl));
                        string subUnit = WebAppFn.SafeJsonToString("Unit", jDtl);
                        dtl.SubWeight = BizHelper.ConventToSysUnitWeight(subWeight, subUnit, SysParams.GetInstance().GetSysWeightUnit());
                        //dtl.TxnWeight = WebAppFn.SafeJsonToString("TxnWeight", jDtl);
                        //dtl.EntryDate = WebAppFn.SafeJsonToString("EntryDate", jDtl);
                        //dtl.InvRecordId = WebAppFn.SafeJsonToString("InvRecordId", jDtl);
                        //dtl.InvAuthId = WebAppFn.SafeJsonToString("InvAuthId", jDtl);
                        //dtl.Status = WebAppFn.SafeJsonToString("Status", jDtl);

                        txnDetailList.Add(dtl);
                    }
                }

                if (!MWRWorkflowMng.RecoverToDestroy(
                    txnHeader.CarCode,
                    txnHeader.DriverCode,
                    txnHeader.InspectorCode,
                    txnHeader.RecoMWSCode,
                    txnDetailList, ref errMsg))
                {
                    return false;
                }

                #endregion
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                LogMng.GetLog().PrintError(ClassName, "RecoverDestroySubmit", ex);
                return false;
            }
            finally
            {
            }

            return true;
        }
        private bool RecoverInventorySubmit(JObject reqDataValue, ref string errMsg)
        {

            JObject jValue = reqDataValue;// (JObject)_requestJO["value"];
            try
            {
                #region set data
                TblMWTxnRecoverHeader txnHeader = new TblMWTxnRecoverHeader();
                txnHeader.CarCode = WebAppFn.SafeJsonToString("carcode", jValue);
                txnHeader.Driver = WebAppFn.SafeJsonToString("drvier", jValue);
                txnHeader.DriverCode = WebAppFn.SafeJsonToString("drivercode", jValue); 
                txnHeader.Inspector = WebAppFn.SafeJsonToString("inspector", jValue); 
                txnHeader.InspectorCode = WebAppFn.SafeJsonToString("inspectorcode", jValue); 
                txnHeader.RecoMWSCode = WebAppFn.SafeJsonToString("mwscode", jValue); 

                List<TblMWTxnDetail> txnDetailList = new List<TblMWTxnDetail>();
                {
                    JArray jTxnDtlList = (JArray)jValue["txndetaillist"];

                    for (int i = 0; i < jTxnDtlList.Count; i++)
                    {
                        JObject jDtl = (JObject)jTxnDtlList[i];
                        TblMWTxnDetail dtl = new TblMWTxnDetail();
                        //dtl.TxnDetailId = WebAppFn.SafeJsonToString("TxnDetailId", jDtl);
                        //dtl.TxnType = WebAppFn.SafeJsonToString("TxnType", jDtl);
                        //dtl.TxnNum = WebAppFn.SafeJsonToString("TxnNum", jDtl);
                        //dtl.WSCode = WebAppFn.SafeJsonToString("WSCode", jDtl);
                        //dtl.EmpyName = WebAppFn.SafeJsonToString("EmpyName", jDtl);
                        //dtl.EmpyCode = WebAppFn.SafeJsonToString("EmpyCode", jDtl);
                        dtl.CrateCode = WebAppFn.SafeJsonToString("CrateCode", jDtl);
                        dtl.Vendor = WebAppFn.SafeJsonToString("Vendor", jDtl);
                        dtl.VendorCode = WebAppFn.SafeJsonToString("VendorCode", jDtl);
                        dtl.Waste = WebAppFn.SafeJsonToString("Waste", jDtl);
                        dtl.WasteCode = WebAppFn.SafeJsonToString("WasteCode", jDtl);
                        //dtl.SubWeight = ComFn.StringToDecimal(WebAppFn.SafeJsonToString("SubWeight", jDtl));
                        decimal subWeight = ComFn.StringToDecimal(WebAppFn.SafeJsonToString("SubWeight", jDtl));
                        string subUnit = WebAppFn.SafeJsonToString("Unit", jDtl);
                        dtl.SubWeight = BizHelper.ConventToSysUnitWeight(subWeight, subUnit, SysParams.GetInstance().GetSysWeightUnit());
                        //dtl.TxnWeight = WebAppFn.SafeJsonToString("TxnWeight", jDtl);
                        //dtl.EntryDate = WebAppFn.SafeJsonToString("EntryDate", jDtl);
                        //dtl.InvRecordId = WebAppFn.SafeJsonToString("InvRecordId", jDtl);
                        //dtl.InvAuthId = WebAppFn.SafeJsonToString("InvAuthId", jDtl);
                        //dtl.Status = WebAppFn.SafeJsonToString("Status", jDtl);

                        txnDetailList.Add(dtl);
                    }
                }

                if (!MWRWorkflowMng.RecoverToInventory(
                    txnHeader.CarCode,
                    txnHeader.DriverCode,
                    txnHeader.InspectorCode,
                    txnHeader.RecoMWSCode,
                    txnDetailList, ref errMsg))
                {
                    return false;
                }



                #endregion
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                LogMng.GetLog().PrintError(ClassName, "RecoverInventorySubmit", ex);
                return false;
            }
            finally
            {
            }

            return true;

        }

        private bool InitMWSSubmit(JObject reqDataValue, ref string errMsg)
        {
            try
            {
                string wsCode = WebAppFn.SafeJsonToString("wscode", reqDataValue);
                if (string.IsNullOrEmpty(wsCode))
                {
                    errMsg = "上传参数错误";
                    return false;
                }
                return WSMng.RegistMWSInitInformation(wsCode, ref errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                LogMng.GetLog().PrintError(ClassName, "InitMWSSubmit", ex);
                return false;
            }
        }
        #endregion

        #region Common
        private class LngRes
        {
            public const string MSG_FormName = "";
            public const string MSG_InvalidParams = "无效的提交参数";
            public const string MSG_InvalidAssessKey = "无效的AssessKEY";
            public const string MSG_InvalidSubmit = "无效的提交";
            public const string MSG_InvalidSecretKey = "无效的提交数据";
        }

        private class OutputData
        {
            public bool Error { get; set; }
            public string ErrMsg { get; set; }
            public string Result { get; set; }
            public static OutputData SetSuccess(string result)
            {
                OutputData data = new OutputData();
                data.Error = false;
                data.ErrMsg = "";
                data.Result = result;
                return data;
            }
            public static OutputData SetError(string errMsg)
            {
                OutputData data = new OutputData();
                data.Error = true;
                data.ErrMsg = errMsg;
                data.Result = null;
                return data;
            }
        }
        #endregion
    }
}