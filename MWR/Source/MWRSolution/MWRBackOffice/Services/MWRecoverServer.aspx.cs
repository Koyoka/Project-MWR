using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using ComLib;
using System.Text;
using YRKJ.MWR.Business.BaseData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ComLib.Log;
using YRKJ.MWR.Business.BO;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.BackOffice.Services
{
    public partial class MWRecoverServer : System.Web.UI.Page
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Services.MWRecoverServer";
        
        private string _action = "";
        private string _value = "";
        private JObject _requestJO = null;
        //private string _requestData = "";

        //private string _accessKey = "[ server access key ]";
        //private string _secretKey = "[ server secret key ]";

        class JsonData
        {
            public string name = "";
            public string value = "";
            public string[] files = new string[] {"aaa"};
        }

        private const string RequestMethod_RecoverInventorySubmit = "RecoverInventorySubmit";
        private const string RequestMethod_RecoverDestroySubmit = "RecoverDestroySubmit";

        protected string OutputText = "";

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string errMsg = "";
                if (!IsPostBack)
                {
                    if (!InitPage(ref errMsg))
                    {
                        JsonData jd = new JsonData();
                        jd.name = "eleven";
                        jd.value = "eleven";
                        string s = JsonConvert.SerializeObject(jd);
                        //Response.AddHeader("Content-Disposition", "attachment; filename=\"files.json\"");
                        Response.ContentType = "application/octet-stream";
                        Response.ClearContent();
                        Response.Write(s);
                        // do error thing
                        //OutputText = errMsg + @"\r\n" + _value;
                        //StringBuilder sb = new StringBuilder();
                        //sb.AppendLine(errMsg);
                        //sb.AppendLine(_value);
                        //OutputText = sb.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                OutputText = ex.Message;
                LogMng.GetLog().PrintError(ClassName, "Page_Load", ex);
            }
            finally
            {
            }


        }
        #endregion

        #region Functions

        #region page function
        private bool InitPage(ref string errMsg)
        {
            if (!LoadData(ref errMsg))
            {
                return false;
            }

            if (_action.Equals(RequestMethod_RecoverInventorySubmit))
            {
                return RecoverInventorySubmit(ref errMsg);
            }
            else if (_action.Equals(RequestMethod_RecoverDestroySubmit))
            {
                return RecoverDestroySubmit(ref errMsg);
            }

            return true;
        }

        private bool LoadData(ref string errMsg)
        {

            string requestData = "";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream, Encoding.UTF8))
            {
                requestData = sr.ReadToEnd();
                sr.Close();
            }

            #region valid request data
            string Authorization = Request.Headers.Get("Authorization");// "";//MWR 
            string assessKey = "";
            string secretKey = "";
            string reqEncryptStr = "";
            if (string.IsNullOrEmpty(Authorization))
            {
                errMsg = LngRes.MSG_InvalidSubmit;
                return false;
            }
            else
            {
                string[] vals = Authorization.TrimStart("MWR".ToCharArray()).Split(':');
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

                assessKey = vals[0].Trim();
                reqEncryptStr = vals[1].Trim();

                TblMWWorkStation ws = null;
                if (!BaseDataMng.GetWSByAssessKey(assessKey, ref ws, ref errMsg))
                {
                    return false;
                }
                if (ws == null)
                {
                    errMsg = LngRes.MSG_InvalidAssessKey + " " + assessKey;
                    return false;
                }
                secretKey = ws.SecretKey;

               

            }

            //string _S_SECRET_KEY = ComLib.AuthorizationHelper.S_SECRET_KEY;
            string reqMethod = Request.HttpMethod;
            string contentType = Request.ContentType;
            string date = Request.Headers.Get("Date");
            string fullUrl = Request.Url.ToString();
            string encryptStr = 
                ComLib.AuthorizationHelper.EncryptWebBody(secretKey, reqMethod, contentType, date, fullUrl, requestData, Encoding.UTF8);

            if (!reqEncryptStr.Equals(encryptStr))
            {
                errMsg = LngRes.MSG_InvalidSecretKey;
                return false;
            }
            #endregion
            OutputText = requestData;

            _requestJO = (JObject)JsonConvert.DeserializeObject(requestData);
            if (_requestJO == null)
            {
                errMsg = LngRes.MSG_InvalidParams;
                return false;
            }
            _action = WebAppFn.SafeJsonToString("action", _requestJO);
            _value = WebAppFn.SafeJsonToString("value", _requestJO);

            //OutputText = _action + " " + RequestMethod_RecoverInventorySubmit + " " + _action.Equals(RequestMethod_RecoverInventorySubmit);
            return true;
        }
        #endregion

        #region action function
        public bool RecoverDestroySubmit(ref string errMsg)
        {
            JObject jValue = (JObject)_requestJO["value"];
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

                OutputText = "Success";


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
        private bool RecoverInventorySubmit(ref string errMsg)
        {

            JObject jValue = (JObject)_requestJO["value"];
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
                        decimal subWeight =  ComFn.StringToDecimal(WebAppFn.SafeJsonToString("SubWeight", jDtl));
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

                OutputText = "Success";


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
        #endregion

        #endregion

        #region PageDatas

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

        public class HttpRequestHelper
        {
            public static bool Post(string p,ref string errMsg)
            {

                return true;
            }
        }

        #endregion
    }
}

/*
 <% = Request.ContentType  %>
<br/ >
<% = Request.Headers.Get("Date")%>
<br/ >
<% = Request.Url %>
<br/ >
<% = Request.HttpMethod %>
<br/ >
<% = Request.RawUrl %> == 1
<br/ >
<% 
    string responseData = "";
    using (System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream, Encoding.UTF8))
    {
        responseData = sr.ReadToEnd();

        sr.Close();
    }
%>
<% = responseData %>  == 2
<br />
<% = Request.Headers.Get("Authorization")%>
<br />
<% 
    string _S_SECRET_KEY = ComLib.AuthorizationHelper.S_SECRET_KEY;
    string reqMethod = Request.HttpMethod;
    string contentType = Request.ContentType;
    string date = Request.Headers.Get("Date");
    string fullUrl = Request.Url.ToString();
    string encryptStr = "";
    encryptStr = ComLib.AuthorizationHelper.EncryptWebBody(_S_SECRET_KEY, reqMethod, contentType, date, fullUrl, responseData, Encoding.UTF8);
    
    %>
    <% = encryptStr %>
 <br />

 <% = Request.Form.Count %>
  <br />
<% = responseData%>
 */