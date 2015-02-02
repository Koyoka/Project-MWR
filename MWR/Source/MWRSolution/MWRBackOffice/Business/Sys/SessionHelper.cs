using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class SessionHelper
    {
        public const string session_key_employ = "myemploy";


        public static bool GetSessionEmploy(ref TblMWEmploy empy)
        {
#if DEBUG
            empy = new TblMWEmploy();
            empy.EmpyCode = "YG0008";
            empy.EmpyName = "李6-跟车";
            return true;
#else
            empy = HttpContext.Current.Session[session_key_employ] as TblMWEmploy;
            if (empy == null)
            {
                return false;
            }
            return true;
#endif

        }

        public static bool CheckLogin()
        {
            bool valid = true;
            valid = HttpContext.Current.Session[session_key_employ] != null ? true : false && valid;
            return valid;
        }
    }
}