using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Report;
using YRKJ.MWR.Business.WS;

namespace YRKJ.MWR.BackOffice.Pages.BO.Inventory
{
    public partial class InvAuthorizeLog : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Inventory.InvAuthorizeLog";

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
            if (!LoadData_AuthDataList(1, 0, filter.Trim(), ref errMsg))
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
            if (!LoadData_AuthDataList(curPage,0, filter.Trim(), ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }
        public bool AjaxExpandTable(string invAuthId, string txnDetailId)
        {
            string errMsg = "";
            PageExpandLogData data = new PageExpandLogData();
            data.InvAuthId = invAuthId;
            int defineInvAuthId = ComLib.ComFn.StringToInt(invAuthId);
            int defineTxnDetailId = ComLib.ComFn.StringToInt(txnDetailId);
            {
                TblMWTxnDetail detail = null;
                if (!TxnMng.GetTxnDetail(defineTxnDetailId, ref detail, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
                if (detail == null)
                {
                    ReturnAjaxError("没有找到当前的交易详情");
                    return false;
                }

                data.Vendor = detail.Vendor;
                data.Waste = detail.Waste;
            }
            {
                List<TblMWInvAuthorizeAttach> dataList = new List<TblMWInvAuthorizeAttach>();
                if (!ReportDataMng.getAuthorizeAttachDataList(defineInvAuthId, ref dataList, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
                foreach (var item in dataList)
                {
                    data.AttachList.Add(item.Path.Replace("//","/"));
                }
                
            }

            ReturnAjaxJsonObj(data);

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
            string paramInvAuthoId = WebAppFn.SafeQueryString("ID");
            int defineId = 0;
            if (!string.IsNullOrEmpty(paramInvAuthoId))
            {
                defineId = ComLib.ComFn.StringToInt(paramInvAuthoId);

            }
            if (!LoadData_AuthDataList(1, defineId, "", ref errMsg))
            {
                return false;
            }
            return true;
        }

        private bool LoadData_AuthDataList(int page,int invAuthoId,string filter, ref string errMsg)
        {
            PageFilterValue = filter;

            int pageSize = 10;
            long pageCount = 0;
            long rowCount = 0;

            if (!ReportDataMng.GetAuthorizeDataList(filter, invAuthoId, page, pageSize, ref pageCount, ref rowCount, ref PageInvAuthorizeDataList, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(page, (int)pageCount);
            return true;
        }

        #endregion

        #region PageDatas
        protected string PageFilterValue = "";
        protected List<VewIvnAuthorizeWithTxnDetail> PageInvAuthorizeDataList = new List<VewIvnAuthorizeWithTxnDetail>();
        #endregion

        #region Common
        protected class PageExpandLogData
        {
            public string InvAuthId { get; set; }
            public string Vendor { get; set; }
            public string Waste { get; set; }
            public List<string> AttachList = new List<string>();
            
        }
        #endregion
    }
}