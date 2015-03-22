using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.Business;
using YRKJ.MWR.Business.Permit;
using YRKJ.MWR.BackOffice.Business.Sys;
using ComLib.db;

namespace YRKJ.MWR.BackOffice.Pages.BO.BaseData
{
    public partial class BDEmploy : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDEmploy";

        private int pageSize = 20;

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
        public bool AjaxSubEmpy_search(string filter)
        {
            string errMsg = "";
            int CurrentPage = 1;

            if (!LoadData_EmpyData(CurrentPage, filter.Trim(), ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            if (!LoadData_FunctionGroup(ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }
        public bool AjaxSubEmpy_common(string filter,string page)
        {
            string errMsg = "";
            int CurrentPage = ComLib.ComFn.StringToInt(page);

            if (!LoadData_EmpyData(CurrentPage, filter.Trim(), ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            if (!LoadData_FunctionGroup(ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }
        public bool AjaxSubEmpy_active(string filter,string opyEmpyCode,string opyType,string page)
        {
            string errMsg = "";
            if (opyType.ToLower().Equals("void"))
            {
                if (!BaseDataMng.VoidEmploy(opyEmpyCode, ref errMsg))
                {
                    return false;
                }
            }
            else if (opyType.ToLower().Equals("active"))
            {
                if (!BaseDataMng.ActiveEmploy(opyEmpyCode, ref errMsg))
                {
                    return false;
                }
            }

            int CurrentPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_EmpyData(CurrentPage, filter.Trim(), ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            if (!LoadData_FunctionGroup(ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }
        public bool AjaxSubEmpy_save(string filter, string empyCode, string password, string empyName, string empyType, string empyFuncGroup, string optType, string page)
        {
            string errMsg = "";
            if (optType.ToLower().Equals("new"))
            {
                TblMWEmploy empy = new TblMWEmploy();
                empy.EmpyCode = empyCode.Trim();
                empy.EmpyName = empyName.Trim();
                empy.Password = password;
                empy.EmpyType = empyType;
                empy.FuncGroupId = ComLib.ComFn.StringToInt(empyFuncGroup);
                empy.Status = TblMWEmploy.STATUS_ENUM_Active;
                if (!BaseDataMng.AddNewEmploy(empy, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }
            else if (optType.ToLower().Equals("edit"))
            {
                if (!BaseDataMng.EditEmpyInfo(empyCode.Trim(), password, empyName.Trim(), empyType, ComLib.ComFn.StringToInt(empyFuncGroup), ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            int CurrentPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_EmpyData(CurrentPage, filter.Trim(), ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            if (!LoadData_FunctionGroup(ref errMsg))
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
            int page = 1;
            if (!LoadData_EmpyData(page,"", ref errMsg))
            {
                return false;
            }
            if (!LoadData_FunctionGroup(ref errMsg))
            {
                return false;
            }
            return true;
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
        private bool LoadData_EmpyData(int page,string filter, ref string errMsg)
        {
            PageFilterValue = filter;

            List<VewEmployWithFunctionGroup> empyList = null;
            long pageCount = 0;
            long rowCount = 0;
            if (!BaseDataMng.GetEmpyWithFuncGroupDataList(page, pageSize, filter, ref pageCount, ref rowCount, ref empyList, ref errMsg))
            {
                return false;
            }

            c_UPage.ShowPage(page, (int)pageCount);
            foreach (var item in empyList)
            {
                PageEmployDataList.Add(new PageEmployData()
                {
                    EmpyCode = item.EmpyCode,
                    EmpyName = item.EmpyName,
                    EmpyPassword = SqlCommonFn.DecryptString(item.Password),
                    EmpyType = BizHelper.GetEmpyType(item.EmpyType),
                    FuncGroup = item.FuncGroupId < 0 ? PermitMng.GetSysDefaultFuncGroupName(item.FuncGroupId) : item.FuncGroupName,
                    IsActive = item.Status.Equals(TblMWEmploy.STATUS_ENUM_Void) ? false : true
                });
            }

            return true;
        }

        #endregion

        #region PageDatas
        protected string PageFilterValue = "";
        protected List<PageEmployData> PageEmployDataList = new List<PageEmployData>();
        protected List<TblMWFunctionGroup> PageFuncGroupDataList = new List<TblMWFunctionGroup>();
        #endregion

        #region Common
        private class LngRes
        {
            public const string MSG_FormName = "";
        }

        protected class PageEmployData
        {
            public string EmpyCode { get; set; }
            public string EmpyName { get; set; }
            public string EmpyPassword { get; set; }
            public string FuncGroup { get; set; }
            public string EmpyType { get; set; }
            public bool IsActive { get; set; }
           
        }
        #endregion
    }
}