using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class BasePage : System.Web.UI.Page
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Business.Sys.BasePage";

        protected static class AjaxResponseMng
        {

            public static string GetAjaxErrorMsg(string errMsg)
            { 
                string jsonStr = "";
                AJAXResultObj resultObj = new AJAXResultObj(AJAXResultObj.EnumResult.Err, errMsg);
                if (!ObjectToJson(resultObj, ref jsonStr, ref errMsg))
                {
                    AJAXResultObj ajaxObj = new AJAXResultObj(AJAXResultObj.EnumResult.Err, errMsg);
                    ObjectToJson(ajaxObj, ref jsonStr, ref errMsg);

                    return jsonStr;
                }

                return jsonStr;

            }
            public static void ReturnAjaxResponse(HttpResponse response, AJAXResultObj.EnumResult result, object Obj)
            {
                string errMsg = "";
                string jsonStr = "";
                AJAXResultObj resultObj = new AJAXResultObj(result, Obj);
                if (!ObjectToJson(resultObj, ref jsonStr, ref errMsg))
                {
                    AJAXResultObj ajaxObj = new AJAXResultObj(AJAXResultObj.EnumResult.Err, errMsg);
                    ObjectToJson(ajaxObj, ref jsonStr, ref errMsg);
                    {
                        ResponsWriteJson(response, jsonStr);
                    }
                }
                else
                {
                    ResponsWriteJson(response, jsonStr);
                }
            }
            public static void ResponsWriteJson(HttpResponse response, string strJson)
            {
                response.Clear();
                response.ContentEncoding = System.Text.Encoding.UTF8;
                response.ContentType = "appliction/json";
                response.Write(strJson);
                response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                //response.End();

            }
            public static void ResponsWrite(HttpResponse response, string strJson)
            {
                response.Clear();
                response.ContentEncoding = System.Text.Encoding.UTF8;
                //response.ContentType = "appliction/json";
                response.Write(strJson);
                response.Flush();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
                //response.End();

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
            public class AJAXResultObj
            {
                public AJAXResultObj(EnumResult result, object value)
                {
                    _result = result;
                    _value = value;
                }

                private EnumResult _result = EnumResult.Success;
                public EnumResult Result
                {
                    get
                    {
                        return _result;
                    }
                }
                private object _value = null;
                public object Value
                {
                    get
                    {
                        return _value;
                    }
                }

                public enum EnumResult
                {
                    Success,
                    Err
                }
            }
        }
        public void ReturnAjaxError(string errMsg)
        {
            AjaxResponseMng.ReturnAjaxResponse(this.Response, AjaxResponseMng.AJAXResultObj.EnumResult.Err, errMsg);
        }
        public void ReturnAjaxError(int code, string errMsg) 
        {
        }
        public void ReturnAjaxJson(string str)
        {
            AjaxResponseMng.ReturnAjaxResponse(this.Response, AjaxResponseMng.AJAXResultObj.EnumResult.Success, str);
        }
        public void ReturnAjaxJsonObj(object obj)
        {
            AjaxResponseMng.ReturnAjaxResponse(this.Response, AjaxResponseMng.AJAXResultObj.EnumResult.Success, obj);
        }



        private bool InitPage()
        {
            #region Ajax Request

            if (!string.IsNullOrEmpty(Request.Form["_AjaxRequest"])
                && Request.Form["_AjaxRequest"].Contains("AjaxRequest")
                && !string.IsNullOrEmpty(Request.Form["_Method"]))
            {
                string methodName = Request.Form["_Method"];
                try
                {
                    
                    
                    if (Request.Form.Count < 2)
                    {
                        throw new Exception("ajax service function need default params [_AjaxRequest] [_Method] ");
                    }
                    string methodGroup = "";
                    if (Request.Form["_Group"] != null)
                    {
                        methodGroup = "_" + Request.Form["_Group"];
                        methodName = methodName + methodGroup;
                    }
                    int paramCount = Request.Form.Count - (string.IsNullOrEmpty(methodGroup) ? 2 : 3);

                    Type tp = this.GetType();
                    System.Reflection.MethodInfo me ;
                   
                    if (paramCount == 0)
                    {
                        me = tp.GetMethod(methodName);
                    }
                    else 
                    {
                        Type[] pType = new Type[paramCount];
                        for (int i = 0;i<pType.Length;i++)
                        {
                            pType[i] = typeof(String);
                        }
                        me = tp.GetMethod(methodName,pType);
                    }

                    string reqMethodParams = "";
                    foreach (var pName in Request.Form.Keys)
                    {
                        if (pName.Equals("_AjaxRequest") || pName.Equals("_Method") || pName.Equals("_Group"))
                        {
                            continue;
                        }
                        reqMethodParams += "<span style=\"color:blue;\">string</span> " + pName + ",";
                    }
                    string reqMethod = "<span style=\"font-size:14px\"><span style=\"color:blue;\">public bool </span>" + methodName + "(" + reqMethodParams.TrimEnd(',') + ")</span>";

                    if (me == null)
                    {
                        string err = "<br/>ajax service no method ";
                        err += "<br/>";
                        err += reqMethod;
                        err += "<br/>";
                        throw new Exception(err);
                    }

                    if (me.ReturnType != typeof(bool))
                    {
                        throw new Exception("ajax service need return [bool] <br/>" + reqMethod+"<br/>");
                    }

                    _isPostBack = true;
                    object returnValue;
                    if (paramCount == 0)
                    {
                        returnValue = me.Invoke(this, null);
                    }
                    else 
                    {
                        string setParamsErr = "";
                        object[] Param = new object[paramCount];
                        System.Reflection.ParameterInfo[] pInfos = me.GetParameters();

                        string serviceMethodParams = "";
                        foreach (var p in pInfos)
                        {
                            
                            if (Request.Form[p.Name] == null)
                            {
                                serviceMethodParams += "<span style=\"color:blue;\">string</span> <span style=\"color:red;\">" + p.Name + "</span>,";
                                setParamsErr += " [" + p.Name + "] ";
                            }
                            else
                            {
                                serviceMethodParams += "<span style=\"color:blue;\">string</span> " + p.Name + ",";
                                Param[p.Position] =
                                Request.Form[p.Name].ToString();
                            }
                        }
                        string serviceMethod = "<span style=\"font-size:14px\"><span style=\"color:blue;\">public bool </span>" + methodName + "(" + serviceMethodParams.TrimEnd(',') + ")</span>";
                        if (!string.IsNullOrEmpty(setParamsErr))
                        {
                            string err = " ["+methodName + "] method Mismatch";
                            err += "<br/>";
                            err += "client request method:" + reqMethod;
                            err += "<br/>";
                            err += "server existed method:" + serviceMethod;
                            err += "<br/>";
                            err += "client request params don't include params:";
                            err += "<br/>";
                            err += setParamsErr;
                            throw new Exception(err);
                        }

                        returnValue = me.Invoke(this, Param);
                    }
                    //return to continue write page code
                    //if (o is bool)
                    //{
                    if (!(bool)returnValue)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    //}
                    //else
                    //{
                    //    throw new Exception("ajax service function need return [bool]");
                    //}
                        
                    //}
                    //else
                    //{
                    //    ReturnAjaxError(ComLib.Error.ErrorMng.GetCodingError(ClassName, "", "not have method:(" + methodName + ")"));
                    //    return true;
                    //}
                }
                catch (Exception ex)
                {
                    ReturnAjaxError(ex.Message);
                    return true;
                }
            }
            else
            {
                return false;
            }



            #endregion
        }

        private bool _isPostBack = false;
        public new bool IsPostBack
        {
            get {
                return base.IsPostBack || _isPostBack;
            }
        }

        protected override void OnLoad(EventArgs e)
        {


            if (!InitPage())
            {
                base.OnLoad(e);
            }
            else
            {
                Response.End();
            }

        }
    }
}