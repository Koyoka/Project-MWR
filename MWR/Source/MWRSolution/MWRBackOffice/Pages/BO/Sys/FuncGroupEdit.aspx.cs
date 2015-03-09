using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.Business.Permit;
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.BackOffice.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.BO.Sys
{
    public partial class FuncGroupEdit : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Sys.FuncGroupEdit";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string errMsg = "";
                if (!InitPage(ref errMsg))
                {
                    // do error thing
                    RedirectHelper.GotoErrPage(errMsg,RedirectHelper.BOMain, RedirectHelper.BackType.include);
                }
            }
        }

        #region Events

        public bool AjaxRemoveFuncGroup(string functionGroupId)
        {
            int defineFuncGroupId = ComLib.ComFn.StringToInt(functionGroupId);
            string errMsg = "";

            if (!PermitMng.RemoveFunctionGroup(defineFuncGroupId, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }

        public bool AjaxAddNewFuncGroup(string functionGroupId, string funcGrpName)
        {
            string errMsg = "";
            if (string.IsNullOrEmpty(funcGrpName))
            {
                ReturnAjaxError("请输入权限组名称.");
                return false;
            }

            if (!PermitMng.AddNewFunctionGroup(funcGrpName, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }

            int defineFuncGroupId = ComLib.ComFn.StringToInt(functionGroupId);
            if (!LoadData_FunctionGroup(ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            if (!LoadData_Function(defineFuncGroupId, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }

        public bool AjasSubFunctionGroupDetail( string functionGroupId,string optFuncTag, string optType)
        {
            int defineFuncGroupId = ComLib.ComFn.StringToInt(functionGroupId);

            string errMsg = "";
            if (optType.ToLower().Equals("remove"))
            {
                if (!PermitMng.RemoveFunctionFromGroup(defineFuncGroupId, optFuncTag, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }
            else if (optType.ToLower().Equals("add"))
            {
                if (!PermitMng.AddFunctionToGroup(defineFuncGroupId, optFuncTag, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }

            }
            else if (optType.ToLower().Equals("removeFuncGroup".ToLower()))
            {
                if (!PermitMng.RemoveFunctionGroup(defineFuncGroupId, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
                defineFuncGroupId = -1;
            }


            if (!LoadData_FunctionGroup(ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            if (!LoadData_Function(defineFuncGroupId, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
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
            if (!LoadData_FunctionGroup(ref errMsg))
            {
                return false;
            }

            int defineFuncGrpId = 0;
            if (PageFuncGroupDataList.Count == 0)
            {
                return true;
            }

            defineFuncGrpId = PageFuncGroupDataList[0].FuncGroupId;
            return LoadData_Function(defineFuncGrpId, ref errMsg);
        }


        private bool LoadData_FunctionGroup(ref string errMsg)
        {

            List<TblMWFunctionGroup> defaultFuncGrp = null;
            PermitMng.GetSysDefaultFuncGroup(ref defaultFuncGrp);
            PageFuncGroupDataList.AddRange(defaultFuncGrp);

            List<TblMWFunctionGroup> defineFuncGrp = null;
            if (!BaseDataMng.GetFunctionGroupList(ref defineFuncGrp, ref errMsg))
            {
                return false;
            }
            PageFuncGroupDataList.AddRange(defineFuncGrp);

            if (PageFuncGroupDataList.Count == 0)
            {
                return false;
            }
            return true;
        }

        private bool LoadData_Function(int funcGrpId,ref string errMsg)
        {

            TblMWFunctionGroup curFuncGrp = null;

            List<TblMWFunctionGroup> defaultFuncGrp = null;
            PermitMng.GetSysDefaultFuncGroup(ref defaultFuncGrp);

            defaultFuncGrp = defaultFuncGrp.Where(x => x.FuncGroupId == funcGrpId).ToList();
            if (defaultFuncGrp.Count != 0)
            {
                curFuncGrp = defaultFuncGrp[0];
            }
            else
            {
                if (!BaseDataMng.GetFunctionGroup(funcGrpId, ref curFuncGrp, ref errMsg))
                {
                    return false;
                }
            }
            if (curFuncGrp == null)
            {
                errMsg = LngRes.MSG_NoPermitInfo;
                return false;
            }
            PageCurPermitGroupName = curFuncGrp.FuncGroupName;
            PageCurPermitGroupId = curFuncGrp.FuncGroupId;

            if (funcGrpId < 0) // is default function group
            {
                string grpPreFix = PermitMng.GetFuncGroupPerfix(funcGrpId);
                if (!BaseDataMng.GetFunctionList(grpPreFix, ref PageCurGroupFunctionDataList, ref errMsg))
                {
                    return false;
                }
            }
            else {
                if (!BaseDataMng.GetFunctionList(funcGrpId, ref PageCurGroupFunctionDataList, ref errMsg))
                {
                    return false;
                }

                if (!BaseDataMng.GetUnInGroupFunctionList(funcGrpId, ref PageOtherFunctionDataList, ref errMsg))
                {
                    return false;
                }
            }

           
            return true;
        }

        protected string GetFunctionShortName(string funcName)
        {
            string[] defineAry = funcName.Split('-');
            if (defineAry.Length != 2)
            {
                return funcName;
            }
            return defineAry[1];
        }

        protected string GetFunctionPackageName(string funcName)
        {
            string[] defineAry = funcName.Split('-');
            if (defineAry.Length != 2)
            {
                return funcName;
            }
            return defineAry[0];
        }

        #endregion

        #region PageDatas
        protected int PageCurPermitGroupId = 0;
        protected string PageCurPermitGroupName = "";
        protected List<TblMWFunctionGroup> PageFuncGroupDataList = new List<TblMWFunctionGroup>();

        protected List<TblMWFunction> PageCurGroupFunctionDataList = new List<TblMWFunction>();
        protected List<TblMWFunction> PageOtherFunctionDataList = new List<TblMWFunction>();

        #endregion

        #region Common

        private class LngRes
        {
            public const string MSG_FormName = "";
            public const string MSG_NoPermitInfo = "没有找到当前的权限组信息";
        }

        #endregion

    }
}