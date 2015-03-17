using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Report;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.BackOffice.Pages.BO.Report
{
    public partial class IntegratedReport : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Report.IntegratedReport";
        protected const int topCount = 5;
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

            if (!ReportDataMng.GetInventoryWeightReportData(ref PageInventoryReortData, ref errMsg))
            {
                return false;
            }
            if (PageInventoryReortData == null)
            {
                errMsg = "coding error";
                return false;
            }

            List<TblMWInventory> invDataList = null;
            if (!ReportDataMng.GetInventoryGroupByVendorAndWasteReportData(ref invDataList, ref errMsg))
            {
                return false;
            }

            {
                var q = from x in invDataList
                        group x by x.VendorCode into g
                        select g;
                foreach (var item in q)
                {

                    PageVendorInfoData data = new PageVendorInfoData();
                    data.RecoverWeight = item.Sum(x =>
                    {
                        return x.RecoWeight;
                    });
                    data.Code = item.First().VendorCode;
                    data.Vendor = item.First().Vendor;
                    foreach (var subItem in item)
                    {
                        data.TopWasteDataList.Add(new PageVendorIncludeWasteData()
                        {
                            Waste = subItem.Waste,
                            RecoverWeight = subItem.RecoWeight
                        });
                    }
                    PageVendorInfoDataList.Add(data);
                }
                PageVendorInfoDataList = PageVendorInfoDataList.OrderByDescending(x => { return x.RecoverWeight; }).ToList();
            }

            {
                var q = from x in invDataList
                        group x by x.WasteCode into g
                        select g;
                foreach (var item in q)
                {

                    PageVendorIncludeWasteData data = new PageVendorIncludeWasteData();
                    data.RecoverWeight = item.Sum(x =>
                    {
                        return x.RecoWeight;
                    });
                    data.Code = item.First().WasteCode;
                    data.Waste = item.First().Waste;
                    foreach (var subItem in item)
                    {
                        data.TopVendorDataList.Add(new PageVendorInfoData()
                        {
                            Vendor = subItem.Vendor,
                            RecoverWeight = subItem.RecoWeight
                        });
                    }
                    PageWasteInfoDataList.Add(data);
                }
                PageWasteInfoDataList = PageWasteInfoDataList.OrderByDescending(x => { return x.RecoverWeight; }).ToList();
            }

            return true;
        }

        #endregion

        #region PageDatas
        protected TblMWInventory PageInventoryReortData = null;
        protected List<PageVendorInfoData> PageVendorInfoDataList = new List<PageVendorInfoData>();
        protected List<PageVendorIncludeWasteData> PageWasteInfoDataList = new List<PageVendorIncludeWasteData>();
        #endregion

        #region Common
        protected class PageVendorInfoData
        {
            public string Code { get; set; }
            public string Vendor { get; set; }
            public decimal RecoverWeight { get; set; }
            public List<PageVendorIncludeWasteData> TopWasteDataList = new List<PageVendorIncludeWasteData>();
        }
        protected class PageVendorIncludeWasteData
        {
            public string Code { get; set; }
            public string Waste { get; set; }
            public decimal RecoverWeight { get; set; }
            public List<PageVendorInfoData> TopVendorDataList = new List<PageVendorInfoData>();
        }
        #endregion
    }
}