using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class WebUIFn
    {
        #region Url
        private static string _siteRoot = null;
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
    }
}