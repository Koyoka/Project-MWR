using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.BO.Inventory
{
    public partial class InvAuthorize : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Inventory.InvAuthorize";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!InitPage())
                {
                    // do error thing
                }
            }
        }

        #region Events
        
        #endregion

        #region Functions

        private bool InitPage()
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

        protected class PageInvAuthorizeData
        { 
            
        }

        #endregion

        #region Common

        #endregion
    }
}