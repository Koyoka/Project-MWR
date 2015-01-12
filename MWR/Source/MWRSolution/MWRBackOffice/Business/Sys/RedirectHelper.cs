using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class RedirectHelper
    {
        public const string PAGE_ROOT = @"Pages/";

        public const string SysError = PAGE_ROOT + "";

        public static void GotoErrPage(HttpResponse response, string errMsg)
        {
            UrlParaCollection paraList = new UrlParaCollection();
            paraList.Add("Msg", errMsg);
            Redirect(response, RedirectHelper.SysError, paraList);
        }

        public static void Redirect(HttpResponse response, string pageUrl)
        {
            Redirect(response, pageUrl, null);
        }

        public static void Redirect(HttpResponse response, string pageUrl, UrlParaCollection paraList)
        {
            string url = WebUIFn.GetFullUrl(pageUrl);

            if (paraList != null && paraList.Count > 0)
            {
                if (url.EndsWith("?"))
                {
                    url = url + paraList.ToString();
                }
                else
                {
                    url = url + "?" + paraList.ToString();
                }
            }

            response.Redirect(url);
        }
    }
}