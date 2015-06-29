using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ComLib.Log;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Permit;
using YRKJ.MWR.Business.BaseData;
using System.Web.SessionState;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.BackOffice.Services
{
    /// <summary>
    /// MWMainServiceHandler 的摘要说明
    /// </summary>
    public class MWMainServiceHandler : IHttpHandler, IRequiresSessionState
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Services.MWMainServiceHandler";
        const string BOUSERLOGIN = "bouserlogin";

        #region main
        public void ProcessRequest(HttpContext context)
        {
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
        private bool InitPostHandle(HttpContext context, ref string errMsg)
        {
            
            string action = WebAppFn.SafeFormString(context.Request, "action").ToLower();
            string result = "";
            switch (action) 
            {
                case BOUSERLOGIN:
                    if (!BOUserLogin(context, ref result, ref errMsg))
                    {
                        return false;
                    }
                    break;
            }

            WriteJson(context, string.IsNullOrEmpty(result) ? "success" : result);
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
        private void WriteJson(HttpContext context, string msg)
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
        private bool BOUserLogin(HttpContext context, ref string result, ref string errMsg)
        {
            if (!MWParams.GetHasBeenInitData())
            {
                return true;
            }

            string empyCode = WebAppFn.SafeFormString(context.Request, "empycode").ToLower();
            string password = WebAppFn.SafeFormString(context.Request, "password").ToLower();
           
            if (!PermitMng.BOLogin(empyCode, password, ref errMsg))
            {
                return false;
            }

            TblMWEmploy empy = null;
            if (!BaseDataMng.GetEmpyData(empyCode, ref empy, ref errMsg))
            {
                return false;
            }

            int funcGrpId = empy.FuncGroupId;
            List<TblMWFunction> funcList = null;
            if (funcGrpId < 0) // is default function group
            {
                string grpPreFix = PermitMng.GetFuncGroupPerfix(funcGrpId);
                if (!BaseDataMng.GetFunctionList(grpPreFix, ref funcList, ref errMsg))
                {
                    return false;
                }
            }
            else
            {
                if (!BaseDataMng.GetFunctionList(funcGrpId, ref funcList, ref errMsg))
                {
                    return false;
                }
            }

            SessionHelper.SetSessionEmploy(context,empy);
            SessionHelper.SetSessionEmpyFunc(context, funcList);
            return true;
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