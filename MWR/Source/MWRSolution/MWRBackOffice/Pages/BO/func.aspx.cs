using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.Business.Permit;

namespace YRKJ.MWR.BackOffice.Pages.BO
{
    public partial class func : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["p"] != null && Request.QueryString["p"].ToString() == "-101868")
            {
                string errMsg = "";
                string path = ComLib.ComFn.GetAppExePath() + @"Setting\function.xml";
                if (!PermitMng.InitSysFuncPermit(path, ref errMsg))
                {
                    Response.Write(errMsg + "<p>" + path + "<p>");
                }
                else
                {
                    Response.Write("success" + "<p>");
                }
            }
        }
    }
}