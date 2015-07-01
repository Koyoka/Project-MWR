using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.WS;
using YRKJ.MWR.Business.Report;

namespace YRKJ.MWR.BackOffice.Pages.BO
{
    public partial class BOMain : System.Web.UI.Page
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.BOMain";

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

            if (!TxnMng.GetTodayIWSTxnDetail(ref PageIWSTxnDetailDataList, ref errMsg))
            {
                return false;
            }

            if (!TxnMng.GetTodayDWSTxnDetail(ref PageDWSTxnDetailDataList, ref errMsg))
            {
                return false;
            }
            int carDisWholeCount = 0;
            int carDisTodayCount = 0;
            int carDisNoOutCount = 0;
            int carDisLeftCount = 0;
            ReportDataMng.GetCarDispatchReport(ref carDisWholeCount, ref carDisTodayCount, ref carDisNoOutCount, ref carDisLeftCount, ref errMsg);
            PageMainPageReport.CarOutCount = carDisLeftCount;
            {
                int count = 0;
                if (!ReportDataMng.GetProcessAuthorizeCount(ref count, ref errMsg))
                {
                    return false;
                }
                PageMainPageReport.AuthorizeCount = count;
            }

            {
               
                TblMWTxnRecoverHeader item = null;
                if (!ReportDataMng.GetTodayTxnRecoverRepotData(ref item, ref errMsg))
                {
                    return false;
                }
                if (item != null)
                    PageMainPageReport.TodayRecoverCount = item.TotalSubWeight;
            }

            {
                TblMWTxnDestroyHeader item = null;
                if (!ReportDataMng.GetTodayTxnDestroyReportData(ref item, ref errMsg))
                {
                    return false;
                }
                if (item != null)
                    PageMainPageReport.TodayDestoryCount = item.TotalSubWeight;

            }
            return true;
        }

        #endregion

        #region PageDatas
        protected List<TblMWTxnDetail> PageIWSTxnDetailDataList = new List<TblMWTxnDetail>();
        protected List<TblMWTxnDetail> PageDWSTxnDetailDataList = new List<TblMWTxnDetail>();
        protected MainPageReport PageMainPageReport = new MainPageReport();
        protected class MainPageReport {
            public int CarOutCount { get; set; }
            public int AuthorizeCount { get; set; }
            public decimal TodayRecoverCount { get; set; }
            public decimal TodayDestoryCount { get; set; }
        }
        #endregion

        #region Common

        #endregion
    }
}