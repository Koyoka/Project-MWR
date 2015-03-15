using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.BaseData;

namespace YRKJ.MWR.BackOffice.Pages.BO.BaseData
{
    public partial class BDCar : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDCar";

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
        public bool AjaxEditCar(string carCode, string desc, string opyType)
        {
            string errMsg = "";
            if (opyType.ToLower().Equals("new"))
            {
                TblMWCar item = new TblMWCar();
                item.CarCode = carCode.Trim();
                item.Desc = desc.Trim();
                if (!BaseDataMng.AddNewCar(item, ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }
            else if (opyType.ToLower().Equals("edit"))
            {
                if (!BaseDataMng.EditCarInfo(carCode.Trim(), desc.Trim(), ref errMsg))
                {
                    ReturnAjaxError(errMsg);
                    return false;
                }
            }

            return false;
        }

        public bool AjaxSubCar(string opyCode, string opyType,string page)
        {
            string errMsg = "";
            if (opyType.ToLower().Equals("void"))
            {
                if (!BaseDataMng.VoidCar(opyCode, ref errMsg))
                {
                    return false;
                }
            }
            else if (opyType.ToLower().Equals("active"))
            {
                if (!BaseDataMng.ActiveCar(opyCode, ref errMsg))
                {
                    return false;
                }
            }

            int curPage = ComLib.ComFn.StringToInt(page);
            if (!LoadData_CarData(curPage, ref errMsg))
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
            if (!LoadData_CarData(1, ref errMsg))
            {
                return false;
            }
            return true;
        }
        private bool LoadData_CarData(int page, ref string errMsg)
        {
            int pageSize = 20;
            long pageCount = 0;
            long rowCount = 0;
            if (!BaseDataMng.GetCarDatList(page, pageSize, ref pageCount, ref rowCount, ref PageCarDataList, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(page, (int)pageCount);
            return true;
        }

        #endregion

        #region PageDatas
        protected List<TblMWCar> PageCarDataList = new List<TblMWCar>();
        #endregion

        #region Common

        #endregion
    }
}