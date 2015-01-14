using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.MasterPages
{
    public partial class MWBOMain : System.Web.UI.MasterPage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.MasterPages.MWBOMain";

        protected bool IsContainerPage = false;
        protected bool IsIndexPage = false;


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!this.IsPostBack)
            {
                InitPage();
                LoadData();
            }

        }

        private void InitPage()
        {
            string container = WebAppFn.SafeQueryString("container");
            IsContainerPage = string.IsNullOrEmpty(container) ? false : true;
            IsIndexPage = WebAppFn.GetCurrentPageName().ToLower().Equals("boindex.aspx".ToLower()) ? true : false;
        }

        private void LoadData()
        { }
    }
}