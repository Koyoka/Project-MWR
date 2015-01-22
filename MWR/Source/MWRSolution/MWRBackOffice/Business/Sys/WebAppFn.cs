using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class WebAppFn
    {
        #region Url
        private static string _siteRoot = null;

        public static string GetBoFullPageUrl(string page)
        {
            return GetFullUrl(@"Pages/BO/"+page);
        }
        public static string GetSiteUrl()
        {
            if (string.IsNullOrEmpty(_siteRoot))
            {
                HttpContext context = HttpContext.Current;
                _siteRoot = context.Request.ApplicationPath.TrimEnd(new char[] { '/', ' ' });
            }
            return _siteRoot;
        }

        public static string GetFullUrl(string pageUrl)
        {
            string url = pageUrl.Trim();
            string siteUrl = GetSiteUrl() + @"/";

            if (url.ToUpper().StartsWith(siteUrl.ToUpper()))
            {
                return url;
            }
            else
            {
                return siteUrl + url;
            }
        }
        #endregion

        #region request response

        public static string SafeQueryString(string name)
        {
            if (HttpContext.Current.Request.QueryString[name] != null)
            {
                return HttpContext.Current.Request.QueryString[name].ToString();
            }

            return "";
        }

        public static string SafeFormString(string name)
        {
            if (HttpContext.Current.Request.Form[name] != null)
            {
                return HttpContext.Current.Request.Form[name].ToString();
            }

            return "";
        }

        #endregion

        public static string GetCurrentPageName()
        { 
            string currentFilePath = HttpContext.Current.Request.FilePath; 
            string CurrentPageName = currentFilePath.Substring(currentFilePath.LastIndexOf("/") + 1);
            return CurrentPageName;
        }
    }
}