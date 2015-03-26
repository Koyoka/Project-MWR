using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Report;

namespace YRKJ.MWR.BackOffice.Pages.BO.Txn
{
    public partial class TxnDetail : System.Web.UI.Page
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Txn.TxnDetail";

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

            return true;
        }
        private bool LoadData_TxnData(ref string errMsg)
        {
            string txnNum = "";
            string txnType = "";
            if (!ReportDataMng.GetTxnType(txnNum, ref txnType, ref errMsg))
            {
                return false;
            }
            if (txnType.Equals(TblMWTxnDetail.TXNTYPE_ENUM_Destroy))
            {
                TblMWTxnRecoverHeader header = null;
                if (!ReportDataMng.GetTxnRecoverHeader(txnNum, ref header, ref errMsg))
                {
                    return false;
                }
            }
            else if (txnType.Equals(TblMWTxnDetail.TXNTYPE_ENUM_Destroy))
            {
                TblMWTxnPostHeader header = null;
                if (!ReportDataMng.GetTxnPostHeader(txnNum, ref header, ref errMsg))
                {
                    return false;
                }
            }
            else if (txnType.Equals(TblMWTxnDetail.TXNTYPE_ENUM_Destroy))
            {
                TblMWTxnDestroyHeader header = null;
                if (!ReportDataMng.GetTxnDestroyHeader(txnNum, ref header, ref errMsg))
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region PageDatas
        protected string PageTxnNumData = "";
        protected string PageTxnDateData = "";

        #endregion

        #region Common

        #endregion
    }
}