using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class SessionHelper
    {
        public const string session_key_employ = "myemploy";
        public const string session_key_employFuncList = "myemployfunclist";


        public static bool GetSessionEmploy(ref TblMWEmploy empy,ref string errMsg)
        {
            //empy = new TblMWEmploy();
            //empy.FuncGroupId = -1;
            //return true;
            if (HttpContext.Current.Session[session_key_employ] == null)
            {
                errMsg = "用户数据超时，请重新登录";
                return false;
            }
            empy = HttpContext.Current.Session[session_key_employ] as TblMWEmploy;
            if (empy == null)
            {
                errMsg = "用户数据超时，请重新登录";
                return false;
            }
            return true;

        }
        public static void SetSessionEmploy(HttpContext context, TblMWEmploy empy)
        {
            context.Session[session_key_employ] = empy;
        }

        public static void GetSessionEmpyFunc(ref List<TblMWFunction> funcList)
        {
            if (HttpContext.Current.Session[session_key_employFuncList] == null)
            {
                funcList = new List<TblMWFunction>();
                return;
            }

            funcList = HttpContext.Current.Session[session_key_employFuncList] as List<TblMWFunction>;
            if (funcList == null)
            {
                funcList = new List<TblMWFunction>();
            }
        }
        public static void SetSessionEmpyFunc(HttpContext context,List<TblMWFunction> funcList)
        {
            context.Session[session_key_employFuncList] = funcList;
        }

        public static void EmpyLogout()
        {
            HttpContext.Current.Session[session_key_employ] = null;
            HttpContext.Current.Session[session_key_employ] = null;
        }

        public static bool CheckLogin()
        {
            bool valid = true;
            valid = HttpContext.Current.Session[session_key_employ] != null ? true : false && valid;
            return valid;
        }
    }
}