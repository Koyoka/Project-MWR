using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.Business.Sys;
using YRKJ.MWR.Business.Permit;

namespace YRKJ.MWR.BackOffice.Pages.BOSetup
{
    public partial class SetupComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errMsg = "";
            MWParams.SetHasBeenInitData(true, ref errMsg);
            string path = ComLib.ComFn.GetAppExePath() + @"Setting\function.xml";
            if (!PermitMng.InitSysFuncPermit(path, ref errMsg))
            {
                //Response.Write(errMsg + "<p>" + path + "<p>");
            }
            
        }
    }
}