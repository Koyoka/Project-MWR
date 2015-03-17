using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Report;
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.BackOffice.Pages.BO.Report
{
    public partial class VendorReport : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Report.VendorReport";

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
        public bool AjaxGetInvTrack(string invRecordId)
        {
            int defineId = ComLib.ComFn.StringToInt(invRecordId);
            string errMsg = "";
            List<TblMWInventoryTrack> dataList = null;
            if(!ReportDataMng.GetInventoryTrack(defineId,ref dataList,ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            List<JsonInvTrackData> jsonObjList = new List<JsonInvTrackData>();
            foreach (var item in dataList)
            {
                JsonInvTrackData data = new JsonInvTrackData()
                {
                    EmpyName = item.EmpyName,
                    WSCode = item.WSCode,
                    EntryDate = item.EntryDate.ToString(BizBase.GetInstance().DateTimeFormatString),
                    TxnType = BizHelper.GetInventoryTrackTxnType(item.TxnType),
                    SubWeight = item.SubWeight,
                    TxnWeight = item.TxnWeight,
                    DiffWeight = item.TxnWeight - item.SubWeight,
                    HasAuthorize = item.InvAuthId == 0 ? false : true

                };
                jsonObjList.Add(data);
            }
            ReturnAjaxJsonObj(jsonObjList);
            return false;
        }
        class JsonInvTrackData
        {
            public string WSCode { get; set; }
            public string EmpyName { get; set; }
            public string EntryDate { get; set; }
            public string TxnType { get; set; }
            public decimal SubWeight { get; set; }
            public decimal TxnWeight { get; set; }
            public decimal DiffWeight { get; set; }
            public bool HasAuthorize { get; set; }

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
            string vendorCode = "";

            vendorCode = WebAppFn.SafeQueryString("code");

            TblMWVendor vendorData = null;
            if (!BaseDataMng.GetVendorData(vendorCode,ref vendorData, ref errMsg))
            {
                return false;
            }
            if (vendorData == null)
            {
                errMsg = "无效的医院编号";
                return false;
            }
            PageVendorNameData = vendorData.Vendor;

            if (!ReportDataMng.GetInventoryVendorWeightReportData(vendorCode, ref PageInventoryVendorReportData, ref errMsg))
            {
                return false;
            }

            if (!LoadData_InventoryData(vendorCode, 1, ref errMsg))
            {
                return false;
            }
          
            return true;
        }

        private bool LoadData_InventoryData(string vendorCode, int page, ref string errMsg)
        {
            int pageSize = 10;
            long pageCount = 0;
            long rowCount = 0;
            if (!ReportDataMng.GetInventoryByVendor(vendorCode, page, pageSize, ref pageCount, ref rowCount, ref PageInventoryDataList, ref errMsg))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region PageDatas
        protected string PageVendorNameData = "";
        protected TblMWInventory PageInventoryVendorReportData = null;
        protected List<TblMWInventory> PageInventoryDataList = new List<TblMWInventory>();
        #endregion

        #region Common

        #endregion
    }
}