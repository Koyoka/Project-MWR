using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.BackOffice.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.BO.BaseData
{
    public partial class BDVendor : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDVendor";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errMsg = "";
                if (!InitPage(ref errMsg))
                {
                    // do error thing
                    RedirectHelper.GotoErrPage(errMsg, RedirectHelper.BOMain, RedirectHelper.BackType.include);
                }
            }
        }

        #region Events
        public bool AjaxSubVendor_save(string vendorCode, string vendor, string address, string optType, string page)
        {
            string errMsg = "";
            if (optType.ToLower().Equals("new"))
            {
                TblMWVendor item = new TblMWVendor();
                item.VendorCode = vendorCode.Trim();
                item.Vendor = vendor.Trim();
                item.Address = address.Trim();
                if (!BaseDataMng.AddNewVendor(item, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }
            else if (optType.ToLower().Equals("edit"))
            {
                if (!BaseDataMng.EditVendorInfo(vendorCode.Trim(), vendor.Trim(), address.Trim(), ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            int curPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_VenorData(curPage, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }
        public bool AjaxSubVendor_common(string page)
        {
            string errMsg = "";
           
            int curPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_VenorData(curPage, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }

        #endregion

        #region Functions

        private bool InitPage(ref string errMsg)
        {
            if (!LoadData(ref errMsg))
            {
                return false;
            }

            return true;
        }

        private bool LoadData(ref string errMsg)
        {
            if (!LoadData_VenorData(1,ref errMsg))
            {
                return false;
            }

            return true;
        }
        private bool LoadData_VenorData(int page, ref string errMsg)
        {
            int pageSize = 10;
            long pageCount = 0;
            long rowCount = 0;
            if (!BaseDataMng.GetVendorData(page,pageSize,ref pageCount,ref rowCount,ref PageVendorDataList, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(page, (int)pageCount);
            return true;
        }


        #endregion

        #region PageDatas
        protected List<TblMWVendor> PageVendorDataList = new List<TblMWVendor>();
        #endregion

        #region Common

        #endregion
    }
}