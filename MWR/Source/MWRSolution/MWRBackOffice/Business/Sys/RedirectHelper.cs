﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class RedirectHelper
    {
        public const string PAGE_ROOT = "";//@"Pages/BO/";

        public const string SysError = PAGE_ROOT + "";

        #region Main page
        public const string BOIndex = "BOIndex.aspx";
        public const string BOMain = PAGE_ROOT + "BOMain.aspx";
        #endregion

        #region Car page
        public const string CarDispatch = PAGE_ROOT + "Car/CarDispatch.aspx";
        public const string CarLocus = PAGE_ROOT + "Car/CarLocus.aspx";
        public const string CarTrack = PAGE_ROOT + "Car/CarTrack.aspx";
        public const string CarRound = PAGE_ROOT + "Car/CarRound.aspx";
        #endregion

        #region Inventory
        public const string InvAuthorize = "Inventory/InvAuthorize.aspx";


        #endregion

        public static void GotoErrPage( string errMsg)
        {
            UrlParaCollection paraList = new UrlParaCollection();
            paraList.Add("Msg", errMsg);
            Redirect( RedirectHelper.SysError, paraList);
        }

        public static void Redirect( string pageUrl)
        {
            Redirect( pageUrl, null);
        }

        public static void Redirect( string pageUrl, UrlParaCollection paraList)
        {
            string url = WebAppFn.GetFullUrl(pageUrl);

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

            HttpContext.Current.Response.Redirect(url);
        }
    }
}