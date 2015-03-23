using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Report;

namespace YRKJ.MWR.BackOffice.Pages.BO.Report
{
    public partial class RecoverReport : System.Web.UI.Page
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

            if (!LoadData_RecoverDataList(1, ref errMsg))
            {
                return false;
            }
            return true;
        }
        private bool LoadData_RecoverDataList(int page, ref string errMsg)
        {
            int pageSize = 10;
            long pageCount = 0;
            long rowCount = 0;
            if (!ReportDataMng.GetTxnRecoverDataList(page, pageSize, ref pageCount, ref rowCount, ref PageRecoverListData, ref errMsg))
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
        #endregion

        #region Common

        #endregion
    }
}