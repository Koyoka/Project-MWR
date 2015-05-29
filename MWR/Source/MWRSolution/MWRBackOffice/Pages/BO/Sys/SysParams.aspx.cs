using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.BO.Sys
{
    public partial class SysParams : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Sys.SysParams";



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errMsg = "";
                if (!InitPage(ref errMsg))
                {
                    // do error thing
                    RedirectHelper.GotoErrPage(errMsg, RedirectHelper.BOMain, RedirectHelper.BackType.include);
                }
            }
        }

        #region Events
        //public bool AjaxFormSub(string crateCode, string mapCity, string baiduMapKey, string allowDiffWeightAsIdentical, string allowDiffWeight_All, string allowDiffWeight_Recover, string allowDiffWeight_Post, string allowDiffWeight_Destory, string isResidueFunction)
        
        public bool AjaxFormSub(string crateCode,string mapCity,string baiduMapKey,string allowDiffWeightAsIdentical,string allowDiffWeight_All,string carGPSMapCode,string allowDiffWeight_Recover,string allowDiffWeight_Post,string allowDiffWeight_Destory,string isResidueFunction)
        {
            string errMsg = "";
            bool success = true;
            success = MWParams.SetCrateCodeMask(crateCode, ref errMsg) && success;
            success = MWParams.SetDefaultMapCity(mapCity, ref errMsg) && success;
            success = MWParams.SetBaiduMapAK(baiduMapKey, ref errMsg) && success;
            success = MWParams.SetAllowDiffWeightAsIdentical(!string.IsNullOrEmpty(allowDiffWeightAsIdentical), ref errMsg) && success;
            success = MWParams.SetAllowDiffWeight_All(ComLib.ComFn.StringToDecimal(allowDiffWeight_All), ref errMsg) && success;
            success = MWParams.SetCarGPSMapCode(carGPSMapCode, ref errMsg) && success;
            success = MWParams.SetAllowDiffWeight_Recover(ComLib.ComFn.StringToDecimal(allowDiffWeight_Recover), ref errMsg) && success;
            success = MWParams.SetAllowDiffWeight_Post(ComLib.ComFn.StringToDecimal(allowDiffWeight_Post), ref errMsg) && success;
            success = MWParams.SetAllowDiffWeight_Destory(ComLib.ComFn.StringToDecimal(allowDiffWeight_Destory), ref errMsg) && success;
            success = MWParams.SetIsResidueFunction(!string.IsNullOrEmpty(isResidueFunction), ref errMsg) && success;
            if (!success)
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

            return true;
        }

        #endregion

        #region PageDatas

        #endregion

        #region Common

        #endregion
    }
}