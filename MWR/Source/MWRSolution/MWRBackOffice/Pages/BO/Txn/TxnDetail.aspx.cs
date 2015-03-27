using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using YRKJ.MWR.Business.Report;
using YRKJ.MWR.Business;
using YRKJ.MWR.Business.WS;

namespace YRKJ.MWR.BackOffice.Pages.BO.Txn
{
    public partial class TxnDetail : System.Web.UI.Page
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Txn.TxnDetail";

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
            if (!LoadData_TxnData(ref errMsg))
            {
                return false;
            }
            return true;
        }
        private bool LoadData_TxnData(ref string errMsg)
        {


            string txnNum = WebAppFn.SafeQueryString("txnNum");
            if (string.IsNullOrEmpty(txnNum))
            {
                errMsg = "无效的交易编号";
                return false;
            }
            string txnType = "";
            if (!ReportDataMng.GetTxnType(txnNum, ref txnType, ref errMsg))
            {
                return false;
            }
            if (txnType.Equals(TblMWTxnDetail.TXNTYPE_ENUM_Recover))
            {
                TblMWTxnRecoverHeader header = null;
                if (!ReportDataMng.GetTxnRecoverHeader(txnNum, ref header, ref errMsg))
                {
                    return false;
                }

                PageTxnStartDateData = ComLib.ComFn.DateTimeToString(header.StartDate, BizBase.GetInstance().DateTimeFormatString);
                PageTxnEndDateData = ComLib.ComFn.DateTimeToString(header.EndDate,BizBase.GetInstance().DateTimeFormatString);

                PageTxnInfoData += "操作类型: 回收入库" ;
                PageTxnInfoData += "<br/>";
                PageTxnInfoData += "提交终端: "+header.RecoMWSCode;
                PageTxnInfoData += "<br/>";
                PageTxnInfoData += "回收终端: " + header.RecoWSCode;
                PageTxnInfoData += "<br/>";
                PageTxnInfoData += "操作员工: " + header.RecoEmpyName;

                PageTotalQtyData = header.TotalCrateQty;
                PageTotalSubWeightData = header.TotalSubWeight;
                PageTotalTxnWeightData = header.TotalTxnWeight;
                PageTotalDiffWeightData = header.TotalSubWeight - header.TotalTxnWeight;

                PageTxnStatusData = BizHelper.GetTxnRecoverHeaderStatus(header.Status);
            }
            else if (txnType.Equals(TblMWTxnDetail.TXNTYPE_ENUM_Post))
            {
                TblMWTxnPostHeader header = null;
                if (!ReportDataMng.GetTxnPostHeader(txnNum, ref header, ref errMsg))
                {
                    return false;
                }

                PageTxnStartDateData = ComLib.ComFn.DateTimeToString(header.StartDate, BizBase.GetInstance().DateTimeFormatString);
                PageTxnEndDateData = ComLib.ComFn.DateTimeToString(header.EndDate, BizBase.GetInstance().DateTimeFormatString);

                PageTxnInfoData += "操作类型: 废品出库";
                PageTxnInfoData += "<br/>";
                PageTxnInfoData += "回收终端: " + header.PostWSCode;
                PageTxnInfoData += "<br/>";
                PageTxnInfoData += "操作员工: " + header.PostEmpyName;

                PageTotalQtyData = header.TotalCrateQty;
                PageTotalSubWeightData = header.TotalSubWeight;
                PageTotalTxnWeightData = header.TotalTxnWeight;
                PageTotalDiffWeightData = header.TotalSubWeight - header.TotalTxnWeight;

                PageTxnStatusData = BizHelper.GetTxnPostHeaderStatus(header.Status);
            }
            else if (txnType.Equals(TblMWTxnDetail.TXNTYPE_ENUM_Destroy))
            {
                TblMWTxnDestroyHeader header = null;
                if (!ReportDataMng.GetTxnDestroyHeader(txnNum, ref header, ref errMsg))
                {
                    return false;
                }

                PageTxnStartDateData = ComLib.ComFn.DateTimeToString(header.StartDate, BizBase.GetInstance().DateTimeFormatString);
                PageTxnEndDateData = ComLib.ComFn.DateTimeToString(header.EndDate, BizBase.GetInstance().DateTimeFormatString);

                PageTxnInfoData += "操作类型: 废品处置";
                PageTxnInfoData += "<br/>";
                PageTxnInfoData += "回收终端: " + header.DestWSCode;
                PageTxnInfoData += "<br/>";
                PageTxnInfoData += "操作员工: " + header.DestEmpyName;

                PageTotalQtyData = header.TotalCrateQty;
                PageTotalSubWeightData = header.TotalSubWeight;
                PageTotalTxnWeightData = header.TotalTxnWeight;
                PageTotalDiffWeightData = header.TotalSubWeight - header.TotalTxnWeight;

                PageTxnStatusData = BizHelper.GetTxnDestroyHeaderStatus(header.Status);
            }
            PageTxnNumData = txnNum;

            if (!TxnMng.GetDetailList(txnNum, ref PageDetailDataList, ref errMsg))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region PageDatas
        protected string PageTxnInfoData = "";
        protected string PageTxnEndDateData = "";

        protected string PageTxnStatusData = "";
        protected string PageTxnNumData = "";
        protected string PageTxnStartDateData = "";
        

        protected int PageTotalQtyData = 0;
        protected decimal PageTotalSubWeightData = 0;
        protected decimal PageTotalTxnWeightData = 0;
        protected decimal PageTotalDiffWeightData = 0;
             

        protected List<TblMWTxnDetail> PageDetailDataList = new List<TblMWTxnDetail>();
        #endregion

        #region Common

        #endregion
    }
}