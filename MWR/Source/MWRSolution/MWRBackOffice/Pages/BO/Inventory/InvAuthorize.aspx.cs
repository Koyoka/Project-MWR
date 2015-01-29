using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.BaseData;
using ComLib;
using YRKJ.MWR.Business;

namespace YRKJ.MWR.BackOffice.Pages.BO.Inventory
{
    public partial class InvAuthorize : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Inventory.InvAuthorize";
        //const int p = 10;
        const int PageSize = 2;

        
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            string errMsg = "";
            if (!IsPostBack)
            {
                if (!InitPage(ref errMsg))
                {
                    // do error thing
                }
            }
        }

        public bool AjaxGetAuthorize(string page)
        {
            string errMsg = "";
            int curPage = ComFn.StringToInt(page);
            long pageCount = 0;
            long rowCount = 0;
            List<VewIvnAuthorizeWithTxnDetail> dataList = null;

            if (!BaseDataMng.GetProcessAuthorizeList(curPage, PageSize, ref pageCount, ref rowCount, ref dataList, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            c_UPage.ShowPage(curPage, (int)pageCount);
            foreach (VewIvnAuthorizeWithTxnDetail data in dataList)
            {
                PageInvAuthorizeData item = new PageInvAuthorizeData();
                item.AuthId = data.InvAuthId + "";
                item.TxnNum = data.TxnNum;
                item.CrateCode = data.CrateCode;
                item.SubWSCode = data.WSCode;
                item.SubEmpyName = data.EmpyName;
                item.SubWeight = data.SubWeight.ToString(BizBase.GetInstance().DecimalFormatString);
                item.TxnWeight = data.TxnWeight.ToString(BizBase.GetInstance().DecimalFormatString);
                item.DiffWeight = data.DiffWeight.ToString(BizBase.GetInstance().DecimalFormatString);
                item.EntryDate = data.EntryDate.ToString(BizBase.GetInstance().DateTimeFormatString);
                item.TxnType = BizHelper.GetTxnDetailTxnType(data.TxnType);

                PageInAuthorizeDataList.Add(item);
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
            
            int curPage = 1;
            long pageCount = 0;
            long rowCount = 0;

            List<VewIvnAuthorizeWithTxnDetail> dataList = null;
           
            if (!BaseDataMng.GetProcessAuthorizeList(curPage, PageSize, ref pageCount, ref rowCount, ref dataList, ref errMsg))
            {
                return false;
            }
            c_UPage.ShowPage(curPage, (int)pageCount);
            foreach (VewIvnAuthorizeWithTxnDetail data in dataList)
            {
                PageInvAuthorizeData item = new PageInvAuthorizeData();
                item.AuthId = data.InvAuthId + "";
                item.TxnNum = data.TxnNum;
                item.CrateCode = data.CrateCode;
                item.SubWSCode = data.WSCode;
                item.SubEmpyName = data.EmpyName;
                item.SubWeight = data.SubWeight.ToString(BizBase.GetInstance().DecimalFormatString);
                item.TxnWeight = data.TxnWeight.ToString(BizBase.GetInstance().DecimalFormatString);
                item.DiffWeight = data.DiffWeight.ToString(BizBase.GetInstance().DecimalFormatString);
                item.EntryDate = data.EntryDate.ToString(BizBase.GetInstance().DateTimeFormatString);
                item.TxnType = BizHelper.GetTxnDetailTxnType(data.TxnType);

                PageInAuthorizeDataList.Add(item);
            }

            return true;
        }

        #endregion

        #region PageDatas
        protected List<PageInvAuthorizeData> PageInAuthorizeDataList = new List<PageInvAuthorizeData>();
       
        #endregion

        #region Common

        protected class PageInvAuthorizeData
        {
            public string AuthId = "";
            public string TxnNum = "";
            public string CrateCode = "";
            public string SubWSCode = "";
            public string SubEmpyName = "";
            public string SubWeight = "";
            public string TxnWeight = "";
            public string DiffWeight = "";
            public string EntryDate = "";
            public string TxnType = "";
        }

        #endregion
    }
}