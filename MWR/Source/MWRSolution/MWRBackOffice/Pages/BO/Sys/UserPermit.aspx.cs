using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.Business.Permit;

namespace YRKJ.MWR.BackOffice.Pages.BO.Sys
{
    public partial class UserPermit : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Sys.UserPermit";

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

        public bool AjaxRefUserPermitGroup(string functionGroupId,string optEmpyCode, string optType)
        {
            string errMsg = "";

            int defineFuncGroupId = ComLib.ComFn.StringToInt(functionGroupId);

            if (optType.ToLower().Equals("remove"))
            {
                if (!PermitMng.RemoveUserPermit(optEmpyCode, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }
            else if (optType.ToLower().Equals("add"))
            {
                if (!PermitMng.AddUserPermit(optEmpyCode, defineFuncGroupId, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            if (!LoadData_FunctionGroup(ref errMsg))
            {
                return false;
            }

            if(!LoadData_UserPermitGroup(defineFuncGroupId, ref errMsg))
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
            return LoadData_UserPermitGroup(PageFuncGroupDataList[0].FuncGroupId,ref errMsg);
          
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

        private bool LoadData_UserPermitGroup(int funcGrpId,ref string errMsg)
        {
            int curFunctionGroupId = funcGrpId;
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

            curFunctionGroupId = curFuncGrp.FuncGroupId;
            PageCurPermitGroupName = curFuncGrp.FuncGroupName;
            PageCurPermitGroupId = curFuncGrp.FuncGroupId.ToString();

            List<TblMWEmploy> defineEmpyList = null;
            if (!BaseDataMng.GetEmpyDataList(ref defineEmpyList, ref errMsg))
            {
                return false;
            }

            if (!BaseDataMng.GetEmpyInFuncGroup(curFunctionGroupId, ref PageCurPermitEmpyDataList, ref errMsg))
            {
                return false;
            }

            PageOtherPermitEmpyDataList = (from t in defineEmpyList
                                           where (from t1 in PageCurPermitEmpyDataList
                                                  where t1.EmpyCode == t.EmpyCode
                                                  select t1).ToList().Count == 0 && t.FuncGroupId != 0
                                           select t).ToList();

            PageNoPermitEmpyDataList = (from t in defineEmpyList
                                        where t.FuncGroupId == 0
                                        select t).ToList();

            return true;
        }

        public string GetFunctionGroupName(int funcGrpId)
        {
            foreach (var item in PageFuncGroupDataList)
            {
                if (item.FuncGroupId == funcGrpId) 
                {
                    return item.FuncGroupName;
                }
            }
            return "";
        }

        #endregion

        #region PageDatas
        protected string PageCurPermitGroupId = "";
        protected string PageCurPermitGroupName = "";
        protected List<TblMWFunctionGroup> PageFuncGroupDataList = new List<TblMWFunctionGroup>();
        protected List<TblMWEmploy> PageCurPermitEmpyDataList = new List<TblMWEmploy>();
        protected List<TblMWEmploy> PageOtherPermitEmpyDataList = new List<TblMWEmploy>();
        protected List<TblMWEmploy> PageNoPermitEmpyDataList = new List<TblMWEmploy>();

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