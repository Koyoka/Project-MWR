using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComLib;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.Business.BO;

namespace YRKJ.MWR.BackOffice.Pages.BO.Inventory
{
    public partial class InvAuthorizeDetail : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Inventory.InvAuthorizeDetail";

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            string errMsg = "";
            if (!IsPostBack)
            {
                if (!InitPage(ref errMsg))
                {
                    PageAuthData = new VewIvnAuthorizeWithTxnDetail();
                    // do error thing
                    RedirectHelper.GotoErrPage(errMsg);
                }
            }
        }

        public bool AjaxSubAuthorize(string invAuthId,string remark)
        {
            string errMsg = "";
            string authEmpyCode = "YG0008";
            int defineId = ComFn.StringToInt(invAuthId);
            if (defineId == 0)
            {
                ReturnAjaxError("无效的审核编号ID");
                return false;
            }
            if (!MWRWorkflowMng.PassAuthorize(defineId, authEmpyCode, remark, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            ReturnAjaxJson("审核完成");
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
            string s = Request.QueryString["id"];
            if (string.IsNullOrEmpty(s))
            {
                errMsg = "valid params";
                return false;
            }
            invAuthId = ComFn.StringToInt(s);
            if (invAuthId == 0)
            {
                errMsg = "无效的ID参数";
                return false;
            }
           
            if (!BaseDataMng.GetAuthorize(invAuthId, ref PageAuthData, ref errMsg))
            {
                return false;
            }
            if (PageAuthData == null)
            {
                errMsg = "没有找到当前ID的审核计划单";
                return false;
            }
            if (PageAuthData.Status.Equals(TblMWInvAuthorize.STATUS_ENUM_Complete))
            {
                errMsg = "当前审核计划单已经完成";
                return false;
            }

            return true;
        }

        #endregion

        #region PageDatas
        protected VewIvnAuthorizeWithTxnDetail PageAuthData = null;
        protected int invAuthId = 0;
        #endregion

        #region Common

        #endregion
    }
}