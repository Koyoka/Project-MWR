using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace YRKJ.MWR.BackOffice
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ComLib.db.SqlDBMng.initDBMng(ComLib.db.SqlDBMng.DBTypeEnum.MySQl);

            ComLib.db.SqlDBMng.setConnectionString(
                       ComLib.db.SqlDBMng.GetConnStr("MWRDATA",
                       "127.0.0.1",
                       "root",
                       "-101868"));
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}