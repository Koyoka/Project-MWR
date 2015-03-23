using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Report;
using YRKJ.MWR.Business.WS;

namespace YRKJ.MWR.BackOffice.Pages.BO.Report
{
    public partial class RecoverReport : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Report.RecoverReport";

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
        public bool AjaxSubTxn_search(string filter)
        {
            string errMsg = "";
            if (!LoadData_RecoverDataList(1,filter.Trim(), ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }
        public bool AjaxSubTxn_common(string filter, string page)
        {
            string errMsg = "";
            int curPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_RecoverDataList(curPage, filter.Trim(), ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }

        public bool AjaxExpandTable(string txnNum)
        {
            string errMsg = "";
            PageTxnExpandData expandData = new PageTxnExpandData();
            List<TblMWTxnDetail> detailList = null;
            if (!TxnMng.GetDetailList(txnNum, ref detailList, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            expandData.detailList = detailList;

            ReturnAjaxJsonObj(expandData);

            return false;
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
            if (!ReportDataMng.GetTxnRecoverReportData(ref PageRecoverReportData, ref errMsg))
            {
                return false;
            }
            if (PageRecoverReportData == null)
            {
                errMsg = "report data error.";
                return false;
            }

            if (!LoadData_RecoverDataList(1,"", ref errMsg))
            {
                return false;
            }
            return true;
        }
        private bool LoadData_RecoverDataList(int page,string filter, ref string errMsg)
        {
            PageFilterValue = filter;
            int pageSize = 10;
            long pageCount = 0;
            long rowCount = 0;
            if (!ReportDataMng.GetTxnRecoverDataList(filter,page, pageSize, ref pageCount, ref rowCount, ref PageRecoverListData, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(page, (int)pageCount);
            return true;
        }

        #endregion

        #region PageDatas
        protected TblMWTxnRecoverHeader PageRecoverReportData = new TblMWTxnRecoverHeader();
        protected List<TblMWTxnRecoverHeader> PageRecoverListData = new List<TblMWTxnRecoverHeader>();
        protected string PageFilterValue = "";
        #endregion

        #region Common
        class PageTxnExpandData
        {
            public List<TblMWTxnDetail> detailList { get; set; }
        }
        #endregion
    }
}