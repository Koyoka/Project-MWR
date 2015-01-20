using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.Error
{
    public class ErrorMng
    {
        public static string GetCodingError(string className, string method, string msg)
        {
            return "Coding Error:[" + className + "." + method + ":" + msg + "]";
        }

        public static string GetDBError(string className, string method, string msg)
        {
            return "DB Error:[" + className + "." + method + ":" + msg + "]";
        }
    }
}
