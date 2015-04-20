using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.Business.Sys;
using YRKJ.MWR.BackOffice.Business.Sys;
using ComLib.db;

namespace YRKJ.MWR.BackOffice.Pages.BOSetup
{
    public partial class SetupAdmin : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BOSetup.SetupAdmin";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errMsg = "";
                if (!InitPage(ref errMsg))
                {
                    // do error thing
                }
            }
        }

        #region Events
        public bool AjaxFormSub(string newAdminPassword, string confirmAdminPassword)
        {
            string errMsg = "";
            if (newAdminPassword != confirmAdminPassword)
            {
                ReturnAjaxError("密码输入不一致");
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