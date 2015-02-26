using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.Business.BO;
using ComLib;

namespace YRKJ.MWR.BackOffice.Pages.BO.Car
{
    public partial class CarDispatch : BasePage
    {

        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Car.CarDispatch";

        const string DisClass = "disabled";
        const int p = 10;
        const int PageSize = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            string errMsg = "";
            if (!IsPostBack)
            {
                if(!InitPage(ref errMsg))
                {
                    // do error thing
                }
            }
        }

        #region Events

        public bool AjaxGetCarDispstch(string page, string disId)
        {
            string errMsg = "";

            if (!string.IsNullOrEmpty(disId))
            {
                int defineDisId = 0;
                if (!ComFn.StringToIntUnSafe(disId, ref defineDisId))
                {
                    ReturnAjaxError(LngRes.MSG_InvalidDisId);
                    return false;
                }
                if (!MWRWorkflowMng.CloseCarDispatch(defineDisId, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }

                if (!LoadEditCarDispatchData(ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            CurrentPage = ComLib.ComFn.StringToInt(page);
            if (!LoadListCarDispatchData(CurrentPage,ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }

            return true;
        }

        public bool AjaxStartShift(string carCode, string driverCode, string inspectorCode, string mwsCode, string issubmit)
        {
            if (carCode.Equals("0")
                      || driverCode.Equals("0")
                      || inspectorCode.Equals("0"))
            {
                ReturnAjaxError(LngRes.MSG_ValidData);
                return false;
            }

            string errMsg = "";

            bool hasBeenOut = false;
            if (!MWRWorkflowMng.CheckCarOutToRecover(carCode, driverCode, inspectorCode, ref hasBeenOut, ref errMsg))
            {
                ReturnAjaxError(errMsg); 
                return false;
            }

            if (hasBeenOut)
            {
                ReturnAjaxError(LngRes.MSG_ValidData);
                return false;
            }
            string formatStr = "MWR-STARTSHIFT {0} {1} {2}";
            string reEncryt = ComLib.ComFn.EncryptStringBy64(string.Format(formatStr, carCode, driverCode, inspectorCode));
            ReturnAjaxJson(reEncryt);
            return false;
        }

        public bool AjaxSubCarDispstch(string carCode, string driverCode, string inspectorCode, string mwsCode, string issubmit)
        {
            string errMsg = "";
            if (!string.IsNullOrEmpty(issubmit))
            {
                if (carCode.Equals("0")
                    || driverCode.Equals("0")
                    || inspectorCode.Equals("0")
                    || mwsCode.Equals("0"))
                {
                    ReturnAjaxError(LngRes.MSG_ValidData);
                    return false;
                }

                
                if (!MWRWorkflowMng.CarOutToRecover(
                    carCode,
                    driverCode,
                    inspectorCode,
                    mwsCode,
                    ref errMsg
                    ))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            if (!LoadEditCarDispatchData(ref errMsg))
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

            if (!LoadEditCarDispatchData(ref errMsg))
            {
                return false;
            }

            if (!LoadListCarDispatchData(1,ref errMsg))
            {
                return false;
            }

            return true;
        }

        private bool LoadEditCarDispatchData(ref string errMsg)
        {
            List<TblMWCar> carDataList = null;
            if (!BaseDataMng.GetNoOutCarDataList(ref carDataList, ref errMsg))
            {
                return false;
            }
            foreach (TblMWCar data in carDataList)
            {
                PageCarData item = new PageCarData();
                item.CarCode = data.CarCode;
                item.CarDesc = data.Desc;
                PageCarDataList.Add(item);
            }


            List<TblMWEmploy> driverDataList = null;
            if (!BaseDataMng.GetNoOutEmpyDataList(TblMWEmploy.EMPYTYPE_ENUM_Driver, ref driverDataList, ref errMsg))
            {
                return false;
            }
            foreach (TblMWEmploy data in driverDataList)
            {
                PageEmplData item = new PageEmplData();
                item.EmplCode = data.EmpyCode;
                item.EmplName = data.EmpyName;
                PageEmplDriverDataList.Add(item);
            }

            List<TblMWEmploy> inspectorDataList = null;
            if (!BaseDataMng.GetNoOutEmpyDataList(TblMWEmploy.EMPYTYPE_ENUM_Inspector, ref inspectorDataList, ref errMsg))
            {
                return false;
            }
            foreach (TblMWEmploy data in inspectorDataList)
            {
                PageEmplData item = new PageEmplData();
                item.EmplCode = data.EmpyCode;
                item.EmplName = data.EmpyName;
                PageEmplInspectorDataList.Add(item);
            }

            List<TblMWWorkStation> mobileWSDataList = null;
            if (!BaseDataMng.GetNoOutMobileWSDataList(ref mobileWSDataList, ref errMsg))
            {
                return false;
            }
            foreach (TblMWWorkStation data in mobileWSDataList)
            {
                PageMobileWSDataList.Add(data.WSCode);
            }

            return true;
        }

        private bool LoadListCarDispatchData(int page,ref string errMsg)
        {
            int curPage = page;
            long pageCount = 0;
            long rowCount = 0;
            List<TblMWCarDispatch> carDispatchDataList = null;
            if (!MWRWorkflowMng.GetNoCloseCarDispatchDataList(curPage, PageSize, ref pageCount, ref rowCount, ref carDispatchDataList, ref errMsg))
            {
                return false;
            }

            c_UPage.ShowPage(curPage, (int)pageCount);
            foreach (TblMWCarDispatch data in carDispatchDataList)
            {
                PageCarInOutData item = new PageCarInOutData();
                item.DisId = data.CarDisId+"";
                item.CarDesc = data.CarCode;
                item.DriverName = data.Driver;
                item.InspectorName = data.Inspector;
                item.OutTime = ComFn.DateTimeToString(data.OutDate, "yyyy-MM-dd HH:mm");
                item.InTime = ComFn.DateTimeToString(data.InDate, "yyyy-MM-dd HH:mm"); 
                item.MWSCode = data.RecoMWSCode;

                PageCarInOutDataList.Add(item);
            }
            return true;
        }
        #endregion

        #region Page Datas
        protected List<PageCarData> PageCarDataList = new List<PageCarData>();
        protected List<PageEmplData> PageEmplDriverDataList = new List<PageEmplData>();
        protected List<PageEmplData> PageEmplInspectorDataList = new List<PageEmplData>();
        protected List<PageCarInOutData> PageCarInOutDataList = new List<PageCarInOutData>();
        protected List<string> PageMobileWSDataList = new List<string>();

        protected int CurrentPage = 0;
        #endregion

        #region Common

       
        protected class PageCarData
        {
            public string CarCode = "";
            public string CarDesc = "";
        }

        protected class PageEmplData
        {
            public string EmplCode = "";
            public string EmplName = "";
        }

        protected class PageCarInOutData
        {
            public string DisId = "";
            public string CarDesc = "";
            public string DriverName = "";
            public string InspectorName = "";
            public string OutTime = "";
            public string InTime = "";
            public string MWSCode = "";
        }

        //protected class PageMobileWSData
        //{
        //    public string WSCode = "";
        //    public string 
        //}
        private class LngRes
        {
            public const string MSG_FormName = "";
            public const string MSG_ValidData = "请选择需要提交的信息";
            public const string MSG_InvalidDisId = "当前调度使用了无效的ID";
        }
        #endregion

    }
}