using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class BasePage : System.Web.UI.Page
    {
        protected static class AjaxResponseMng
        {

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
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
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
                    object[] Param = null;

                    if (Request.Form.Count > 2)
                    {
                        Param = new string[Request.Form.Count - 2];
                        for (int i = 0; i < Param.Length; i++)
                        {
                            Param[i] = Request.Form[i];
                        }
                    }
                    Type tp = this.GetType();
                    System.Reflection.MethodInfo me = tp.GetMethod(methodName);
                    if (me != null)
                    {
                        _isPostBack = true;
                        object o = me.Invoke(this, Param);
                        
                        if (o != null)
                        {
                            string s = me.Invoke(this, Param).ToString();
                            AjaxResponseMng.ResponsWrite(this.Response, s);
                            Response.End();
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
                    else
                    {
                        throw new Exception("not have method:(" + methodName + ")");
                    }
                   
                    return true;
                }
                catch (Exception ex)
                {
                    AjaxResponseMng.ReturnAjaxResponse(this.Response, AjaxResponseMng.AJAXResultObj.EnumResult.Err, ex.Message);
                    Response.End();
                    return true;
                }
                finally
                {
                   

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

        }
    }
}