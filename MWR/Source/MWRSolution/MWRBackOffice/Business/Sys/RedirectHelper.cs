using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Business.Sys
{
    public class RedirectHelper
    {
        public const string PAGE_ROOT = "";//@"Pages/BO/";

        public const string SysError = "/Pages/BO/Error.aspx";

        #region Login
        public const string Index = "Index.html";
        #endregion

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
        public const string InvAuthorizeDetail = "Inventory/InvAuthorizeDetail.aspx";

        #endregion

        #region Report

        public const string IntegratedReport = "Report/IntegratedReport.aspx";
        public const string VendorReport = "Report/VendorReport.aspx";
        public const string WasteReport = "Report/WasteReport.aspx";
        #endregion

        #region BaseData
        public const string BDEmploy = "BaseData/BDEmploy.aspx";
        public const string BDVendor = "BaseData/BDVendor.aspx";
        public const string BDCar = "BaseData/BDCar.aspx";
        public const string BDWaste = "BaseData/BDWaste.aspx";
        public const string BDDepot = "BaseData/BDDepot.aspx";
        public const string BDCrate = "BaseData/BDCrate.aspx";

        public const string DemoBDCrate = "BaseData/DemoBDCrate.aspx";
        #endregion

        #region System
        public const string WSManage = "Sys/WSManage.aspx";
        public const string UserPermit = "Sys/UserPermit.aspx";
        public const string FuncGroupEdit = "Sys/FuncGroupEdit.aspx";
        public const string SysInit = "Sys/SysInit.aspx";
        #endregion
        public enum BackType { redirect, include };
        public static void GotoLoginErrPage()
        {
            UrlParaCollection paraList = new UrlParaCollection();
           
            Redirect(WebAppFn.GetBoFullPageUrl("error.html"), paraList);
        }
        public static void GotoErrPage(string errMsg, string backPage, BackType type)
        {
            UrlParaCollection paraList = new UrlParaCollection();
            paraList.Add("Msg", errMsg);
            paraList.Add("BP", backPage);
            paraList.Add("BT",type+"");
            paraList.Add("container", "1");
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