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
    public partial class BDCrate : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDCrate";

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
        public bool AjaxEditCrate(string crateCode, string desc, string opyType)
        {
            string errMsg = "";
            if (opyType.ToLower().Equals("new"))
            {
               TblMWCrate item = new TblMWCrate();
                item.CrateCode = crateCode.Trim();
                item.Desc = desc.Trim();
                if (!BaseDataMng.AddNewCrate(item, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }
            else if (opyType.ToLower().Equals("edit"))
            {
                if (!BaseDataMng.EditCrateInfo(crateCode.Trim(), desc.Trim(), ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            return false;
        }

        public bool AjaxSubCrate(string opyCode, string opyType,string page)
        {
            string errMsg = "";
            if (opyType.ToLower().Equals("void"))
            {
                if (!BaseDataMng.VoidCrate(opyCode, ref errMsg))
                {
                    return false;
                }
            }
            else if (opyType.ToLower().Equals("active"))
            {
                if (!BaseDataMng.ActiveCrate(opyCode, ref errMsg))
                {
                    return false;
                }
            }

            int curPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_CrateData(curPage, ref errMsg))
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
            if(!LoadData_CrateData(1,ref errMsg))
            {
                return false;
            }
            return true;
        }

        private bool LoadData_CrateData(int page,ref string errMsg)
        {
            int pageSize = 20;
            long pageCount = 0;
            long rowCount = 0;
            if (!BaseDataMng.GetCrateDataList(page, pageSize, ref pageCount, ref rowCount, ref PageCrateDataList, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(page, (int)pageCount);
            return true;
        }
        #endregion

        #region PageDatas
        protected List<TblMWCrate> PageCrateDataList = new List<TblMWCrate>();
        #endregion

        #region Common

        #endregion
    }
}