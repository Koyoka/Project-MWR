using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.Demo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string paramPage = WebAppFn.SafeQueryString("page");
            int page = ComLib.ComFn.StringToInt(paramPage);
            long pageCount = 100;
            UPage1.ShowPage(page, (int)pageCount);
        }
    }
}