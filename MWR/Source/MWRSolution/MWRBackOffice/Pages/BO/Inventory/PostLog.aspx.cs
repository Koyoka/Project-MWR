using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Report;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.BackOffice.Pages.BO.Inventory
{
    public partial class PostLog : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Inventory.PostLog";

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
            if (!LoadData_InvTrackData(1, filter.Trim(), ref errMsg))
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
            if (!LoadData_InvTrackData(curPage, filter.Trim(), ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }

        public bool AjaxExpandTable(string txnDetailId)
        {
            int defineTxnDetailId = ComLib.ComFn.StringToInt(txnDetailId);
            string errMsg = "";

            List<TblMWTxnLog> dataList = null;
            if (!ReportDataMng.GetTxnLogList(defineTxnDetailId, ref dataList, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            List<PageExpandLogData> pageExpandLogData = new List<PageExpandLogData>();
            foreach (var data in dataList)
            {
                pageExpandLogData.Add(new PageExpandLogData()
                {
                    WSCode = data.WSCode,
                    EmpyName = data.EmpyName,
                    OptType = BizHelper.GetTxnLogOptType(data.OptType) + "-" + BizHelper.GetTxnDetailTxnType(data.TxnLogType),
                    OptDate = ComLib.ComFn.DateTimeToString(data.OptDate, BizBase.GetInstance().DateTimeFormatString)
                });
            }
            ReturnAjaxJsonObj(pageExpandLogData);
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
            if (!LoadData_InvTrackData(1, "", ref errMsg))
            {
                return false;
            }
            return true;
        }
        private bool LoadData_InvTrackData(int page, string filter, ref string errMsg)
        {
            PageFilterValue = filter;
            int pageSize = 10;
            long pageCount = 0;
            long rowCount = 0;
            if (!ReportDataMng.GetPostInventoryTrack(filter, page, pageSize, ref pageCount, ref rowCount, ref PagePostInvTrackDatalist, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(page, (int)pageCount);
            return true;
        }
        #endregion

        #region PageDatas
        protected List<TblMWInventoryTrack> PagePostInvTrackDatalist = new List<TblMWInventoryTrack>();
        protected string PageFilterValue = "";
        #endregion

        #region Common
        protected class PageExpandLogData
        {
            public string WSCode { get; set; }
            public string EmpyName { get; set; }
            public string OptType { get; set; }
            public string OptDate { get; set; }
        }
        #endregion
    }
}