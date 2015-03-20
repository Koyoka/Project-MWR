using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.BaseData;

namespace YRKJ.MWR.BackOffice.Pages.BO.BaseData
{
    public partial class BDWaste : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDWaste";

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
        public bool AjaxSubWaste_save(string wasteCode, string waste, string optType, string page)
        {
            string errMsg = "";
            if (optType.ToLower().Equals("new"))
            {
                TblMWWasteCategory item = new TblMWWasteCategory();
                item.WasteCode = wasteCode.Trim();
                item.Waste = waste.Trim();
                if (!BaseDataMng.AddNewWaste(item, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }
            else if (optType.ToLower().Equals("edit"))
            {
                if (!BaseDataMng.EditWasteInfo(wasteCode.Trim(), waste.Trim(), ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            int curPage = ComLib.ComFn.StringToInt(page);

            if (!LoadData_WasteData(curPage, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }
        public bool AjaxSubWaste_common(string page)
        {
            string errMsg = "";
            int curPage = ComLib.ComFn.StringToInt(page);
            
            if (!LoadData_WasteData(curPage, ref errMsg))
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
            if (!LoadData_WasteData(1, ref errMsg))
            {
                return false;
            }
            return true;
        }

        private bool LoadData_WasteData(int page, ref string errMsg)
        {
            int pageSize = 20;
            long pageCount = 0;
            long rowCount = 0;
            if (!BaseDataMng.GetWasteCategoryDataList(page, pageSize, ref pageCount, ref rowCount, ref PageWasteDataList, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(page, (int)pageCount);

            return true;
        }

        #endregion

        #region PageDatas
        protected List<TblMWWasteCategory> PageWasteDataList = new List<TblMWWasteCategory>();
        #endregion

        #region Common

        #endregion
    }
}