using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Sys;
using YRKJ.MWR.Business.Permit;
using ComLib.db;

namespace YRKJ.MWR.BackOffice.Pages.BO.Sys
{
    public partial class SysAdmin : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Sys.SysAdmin";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errMsg = "";
                if (!InitPage(ref errMsg))
                {
                    // do error thing
                    RedirectHelper.GotoErrPage(errMsg, RedirectHelper.Index, RedirectHelper.BackType.include);
                }
            }
        }

        #region Events

        public bool AjaxFormSub(string oldAdminPassword, string newAdminPassword, string confirmAdminPassword)
        {
            string errMsg = "";
            string defineOldPwd = MWParams.GetAdministratorPassword();
            if (!oldAdminPassword.Equals(defineOldPwd))
            {
                ReturnAjaxError("旧密码错误。");
                return false;
            }
            
            if (!MWParams.SetAdministratorPassword(newAdminPassword, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }

            string adminAccount = MWParams.GetAdministrator();

            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWEmploy.getPasswordColumn(), newAdminPassword);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, adminAccount);

            int updCount = 0;
            if (!TblMWEmployCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return false;
        }

        #endregion

        #region Functions

        private bool InitPage(ref string errMsg)
        {
            if (!LoadData(ref errMsg))
            {
                return false;
            }

            return true;
        }

        private bool LoadData(ref string errMsg)
        {

            PageAdministratorAccount = MWParams.GetAdministrator();
            return true;
        }

        #endregion

        #region PageDatas
        protected string PageAdministratorAccount = "";

        #endregion

        #region Common

        #endregion
    }
}