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

            ComLib.db.SqlDBMng.setConnectionString(
                       ComLib.db.SqlDBMng.GetConnStr("MWRDATA",
                       "127.0.0.1",
                       "root",
                       "-101868"));
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
            System.Diagnostics.Debug.WriteLine("Application_AcquireRequestState " + this.Request.Path);


            string requestPath = this.Request.Path.ToUpper();
            //if(requestPath)
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