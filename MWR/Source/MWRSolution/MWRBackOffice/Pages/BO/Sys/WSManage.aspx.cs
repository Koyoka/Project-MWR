using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.BO;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.BackOffice.Pages.BO.Sys
{
    public partial class WSManage : BasePage
    {
        public const string ClassName = "ClassName";
        const int PageSize = 20;

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
        public bool AjaxInitMobile()
        {
            string errMsg = "";
            string ak = "";
            string sk = "";
            string code = "";

            if (!WSMng.CreateMWSInitInformation(ref code, ref ak, ref sk, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }

            string formatStr = "MWR-INITMOBILE {0} {1} {2}";

            string reEncryt = ComLib.ComFn.EncryptStringBy64(string.Format(formatStr, code, ak, sk));

            ReturnAjaxJson(reEncryt);

            return false;
        }

        public bool AjaxGetWS(string page)
        {

            int curPage = ComLib.ComFn.StringToInt(page);
            if (curPage == 0)
            {
                ReturnAjaxError(LngRes.MSG_ValidData);
                return false;
            }

            string errMsg = "";

            long pageCount = 0;
            long rowCount = 0;
            List<TblMWWorkStation> wsList = null;
            if (!WSMng.GetWorkstation(curPage, PageSize, ref pageCount, ref rowCount, ref wsList, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }

            foreach (TblMWWorkStation ws in wsList)
            {
                PageWSData item = PageWSData.ConventSqlDataToPageData(ws);
                PageWSDataList.Add(item);
            }
            c_UPage.ShowPage(curPage, (int)pageCount);

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
            int page = 1;
            long pageCount = 0;
            long rowCount = 0;

            List<TblMWWorkStation> wsList = null;
            if (!WSMng.GetWorkstation(page, PageSize, ref pageCount, ref rowCount, ref wsList, ref errMsg))
            {
                return false;
            }

            foreach (TblMWWorkStation ws in wsList)
            {
                PageWSData item = PageWSData.ConventSqlDataToPageData(ws);
                PageWSDataList.Add(item);
            }
            c_UPage.ShowPage(page, (int)pageCount);
            return true;
        }

        #endregion

        #region PageDatas
        protected List<PageWSData> PageWSDataList = new List<PageWSData>();

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "";
            public const string MSG_ValidData = "请选择需要提交的信息";
            
        }

        protected class PageWSData
        {
            public string WSCode { get; set; }
            public string WSType { get; set; }
            public string WSStatus { get; set; }
            public string AssessKey { get; set; }
            public string SecretKey { get; set; }
            public bool CanInitMob = false;

            public static PageWSData ConventSqlDataToPageData(TblMWWorkStation data)
            {
                PageWSData item = new PageWSData();
                item.UpdateSqlDataToPageData(data);
                return item;
            }

            public void UpdateSqlDataToPageData(TblMWWorkStation data)
            {
                PageWSData item = this;
                item.WSCode = data.WSCode;
                item.WSType = BizHelper.GetWSType(data.WSType);
                item.WSStatus = "";
                item.AssessKey = data.AccessKey;
                item.SecretKey = data.SecretKey;
                item.CanInitMob = data.WSType.Equals(TblMWWorkStation.WSTYPE_ENUM_WaitWorkStation) ? true : false;
            }
        }

        #endregion
    }
}