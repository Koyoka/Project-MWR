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
    public partial class BDDepot : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDDepot";

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
        public bool AjaxSubDepot_save(string deptCode, string desc, string optType, string page)
        {
            string errMsg = "";
            if (optType.ToLower().Equals("new"))
            {
                TblMWDepot item = new TblMWDepot();
                item.DeptCode = deptCode.Trim();
                item.Desc = desc.Trim();
                if (!BaseDataMng.AddNewDepot(item, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }
            else if (optType.ToLower().Equals("edit"))
            {
                if (!BaseDataMng.EditDepotInfo(deptCode.Trim(), desc.Trim(), ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            int curPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_DepotData(curPage, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }
        public bool AjaxSubDepot_common(string page)
        {
            string errMsg = "";
            int curPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_DepotData(curPage, ref errMsg))
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
            if (!LoadData_DepotData(1, ref errMsg))
            {
                return false;
            }
            return true;
        }

        private bool LoadData_DepotData(int page, ref string errMsg)
        {
            int pageSize = 20;
            long pageCount = 0;
            long rowCount = 0;
            if (!BaseDataMng.GetDepotDataList(page, pageSize, ref pageCount, ref rowCount, ref PageDepotDataList, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(page, (int)pageCount);
            return true;
        }

        #endregion

        #region PageDatas
        protected List<TblMWDepot> PageDepotDataList = new List<TblMWDepot>();
        #endregion

        #region Common

        #endregion
    }
}