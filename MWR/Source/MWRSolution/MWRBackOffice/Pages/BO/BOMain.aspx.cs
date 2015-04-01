using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.WS;

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
            return true;
        }

        #endregion

        #region PageDatas
        protected List<TblMWTxnDetail> PageIWSTxnDetailDataList = new List<TblMWTxnDetail>();
        protected List<TblMWTxnDetail> PageDWSTxnDetailDataList = new List<TblMWTxnDetail>();

        #endregion

        #region Common

        #endregion
    }
}