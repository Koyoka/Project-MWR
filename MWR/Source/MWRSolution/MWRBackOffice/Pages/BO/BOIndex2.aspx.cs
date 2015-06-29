﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.BO
{
    public partial class BOIndex2 : System.Web.UI.Page
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
                    RedirectHelper.GotoLoginErrPage();
                }
            }
        }

        #region Events

        #endregion

        #region Functions

        private bool InitPage(ref string errMsg)
        {

            if (!MWParams.GetHasBeenInitData())
            {
                Response.Redirect(WebAppFn.GetBoSetupFullPageUrl(RedirectHelper.SetupMainPage));
                return true;
            }

            if (!LoadData(ref errMsg))
            {
                return false;
            }

            return true;
        }

        private bool LoadData(ref string errMsg)
        {
            TblMWEmploy empy = null;
            if (!SessionHelper.GetSessionEmploy(ref empy, ref errMsg))
            {
                return false;
            }
            PageEmpyNameData = empy.EmpyName;
            return true;
        }

        #endregion

        #region PageDatas
        protected string PageEmpyNameData = "";

        #endregion

        #region Common

        #endregion
    }
}