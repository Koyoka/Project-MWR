using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using YRKJ.MWR.BackOffice.Business.Sys;

namespace YRKJ.MWR.BackOffice
{
    public class Global : System.Web.HttpApplication//, IRequiresSessionState 
    {

        protected void Application_Start(object sender, EventArgs e)
        {

           
            string errMsg = "";
            #region log
            if (!ComLib.Log.LogMng.InitLog(ComLib.ComFn.GetAppExePath() + "Setting\\Log", "MWR", ref errMsg))
            {
                //MsgBox.Error("初始化错误/r/n" + errMsg);
                return;
            }

            #endregion

            #region database
            ComLib.db.SqlDBMng.initDBMng(ComLib.db.SqlDBMng.DBTypeEnum.MySQl);
            string dbName = System.Configuration.ConfigurationManager.AppSettings["DBName"].ToString();
            string dbService = System.Configuration.ConfigurationManager.AppSettings["DBService"].ToString();
            string dbUser = System.Configuration.ConfigurationManager.AppSettings["DBUser"].ToString();
            string dbPassword = System.Configuration.ConfigurationManager.AppSettings["DBPassword"].ToString();
            string dbPort = System.Configuration.ConfigurationManager.AppSettings["DBPort"].ToString();
            string dbKey = System.Configuration.ConfigurationManager.AppSettings["Key"].ToString();
            dbPassword = ComLib.ComFn.DecryptDBPassword(dbKey, dbPassword);
            ComLib.db.SqlDBMng.setConnectionString(
                       ComLib.db.SqlDBMng.GetConnStr(dbName,
                      dbService,
                       dbUser,
                       dbPassword, dbPort));
            #endregion
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Application_AcquireRequestState " + this.Request.Path);
//#if DEBUG
//            return;
//#endif

            string requestPath = this.Request.Path.ToUpper();
            //if(requestPath)
            #region func
            if( requestPath.IndexOf(@"FUNC.ASPX") >= 0)
            {
                return;   
            }

            #endregion



            #region BO
            if (//requestPath.EndsWith(@"SYSERROR.ASPX") ||
                requestPath.IndexOf(@"/PAGES/BO/") >= 0)
            {
                if (System.Web.HttpContext.Current.Session == null)
                {
                    return;
                }

                #region un valid
                if (requestPath.EndsWith(@"ERROR.ASPX"))
                {
                    return;
                }
                if (requestPath.EndsWith(@"BOINDEX2.ASPX"))
                {
                    return;
                }
                #endregion

                #region valid permit
                string errMsg = "";
                TblMWEmploy empy = null;
                if (!SessionHelper.GetSessionEmploy(ref empy, ref errMsg))
                {
                    //RedirectHelper.GotoErrPage(errMsg, RedirectHelper.Index, RedirectHelper.BackType.redirect);
                    if (requestPath.EndsWith(RedirectHelper.BOIndex.ToUpper()))
                    {
                        RedirectHelper.GotoLoginErrPage();
                    }
                    else
                    {
                        RedirectHelper.GotoErrPage(errMsg, RedirectHelper.Index, RedirectHelper.BackType.redirect);
                    }
                    
                    return;
                }

                #region administrator permit
                if (empy.FuncGroupId == YRKJ.MWR.Business.Permit.PermitMng.ADMINISTRATOR_DEFAULT_GROUPID)
                {
                    return;
                }
                #endregion

                #region main menu page permit
                if (requestPath.EndsWith(RedirectHelper.BOIndex.ToUpper()))
                {
                    return;
                }

                if (requestPath.EndsWith(RedirectHelper.BOMain.ToUpper()))
                {
                    return;
                }
                #endregion

                #region function page permit
                List<TblMWFunction> funcList = null;
                SessionHelper.GetSessionEmpyFunc(ref funcList);

                bool permit = false;
                foreach (TblMWFunction item in funcList)
                {
                    string definePage = item.FuncTag.TrimStart(YRKJ.MWR.Business.Permit.PermitMng.GetFuncGroupPerfix(YRKJ.MWR.Business.Permit.PermitMng.BACKOFFICE_DEFAULT_GROUPDID).ToArray()) + ".aspx";
                  
                    if (requestPath.EndsWith(definePage.ToUpper()))
                    {
                        permit = true;
                        break;
                    }
                }
                if (!permit)
                {
                    //RedirectHelper.GotoLoginErrPage();
                    RedirectHelper.GotoErrPage("没有权限使用当前功能", RedirectHelper.BOMain, RedirectHelper.BackType.include);
                    return;
                }

                #endregion

                #endregion
            }
            #endregion
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