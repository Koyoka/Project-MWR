using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.BO.Sys
{
    public partial class WSManage : System.Web.UI.Page
    {
        public const string ClassName = "ClassName";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errMsg = "";
                if (!InitPage(ref errMsg))
                {
                    // do error thing
                    RedirectHelper.GotoErrPage(errMsg);
                }
            }
        }

        #region Events
        public bool AjaxGetWS()
        {

            return true;
        }
        #endregion

        #region Functions

        private bool InitPage(ref string errMsg)
        {
            if (!LoadData())
            {
                return false;
            }

            return true;
        }

        private bool LoadData()
        {

            return true;
        }

        #endregion

        #region PageDatas

        #endregion

        #region Common

        #endregion
    }
}