using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR.Business.Report
{
    public class ReportDataMng
    {
        public const string ClassName = "YRKJ.MWR.Business.Report.ReportDataMng";

        #region Inventory
        public static bool GetInventoryGroupByVendorAndWasteReportData(ref List<TblMWInventory> invDataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(TblMWInventory.getRecoWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getInvWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
            sqm.QueryColumn.Add(TblMWInventory.getVendorColumn());
            sqm.QueryColumn.Add(TblMWInventory.getVendorCodeColumn());
            sqm.QueryColumn.Add(TblMWInventory.getWasteColumn());
            sqm.QueryColumn.Add(TblMWInventory.getWasteCodeColumn());

            sqm.Condition.GroupBy.Add(TblMWInventory.getVendorCodeColumn());
            sqm.Condition.GroupBy.Add(TblMWInventory.getWasteCodeColumn());
            if (!TblMWInventoryCtrl.QueryMore(dcf, sqm, ref invDataList, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool GetInventoryWeightReportData(ref TblMWInventory inv, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(TblMWInventory.getRecoWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getInvWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
           
            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetInventoryVendorWeightReportData(string vendorCode,ref TblMWInventory inv, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(TblMWInventory.getRecoWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getInvWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getVendorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, vendorCode);
            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetInventoryWasteWeightReportData(string wasteCode, ref TblMWInventory inv, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddSum(TblMWInventory.getRecoWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getInvWeightColumn());
            sqm.QueryColumn.AddSum(TblMWInventory.getDestWeightColumn());
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getWasteCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wasteCode);
            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetInventoryByVendor(string vendorCode, int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWInventory> invDataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getVendorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, vendorCode);
            sqm.Condition.OrderBy.Add(TblMWInventory.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            if (!TblMWInventoryCtrl.QueryPage(dcf, sqm, page, pageSize, ref invDataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }

        public static bool GetInventoryByWaste(string wasteCode, int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWInventory> invDataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getWasteCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wasteCode);
            sqm.Condition.OrderBy.Add(TblMWInventory.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            if (!TblMWInventoryCtrl.QueryPage(dcf, sqm, page, pageSize, ref invDataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        
        
        #endregion

        #region InventoryTrack
        public static bool GetInventoryTrack(int invRecordId,ref List<TblMWInventoryTrack> dataList,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventoryTrack.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
            sqm.Condition.OrderBy.Add(TblMWInventoryTrack.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.ASC);
            if (!TblMWInventoryTrackCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region TxnRecover
        public static bool GetTxnRecoverReportData(ref TblMWTxnRecoverHeader recHeader, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.QueryColumn.AddCount(TblMWTxnRecoverHeader.getRecoHeaderIdColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalSubWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalTxnWeightColumn());
            sqm.QueryColumn.AddSum(TblMWTxnRecoverHeader.getTotalCrateQtyColumn());
            if (!TblMWTxnRecoverHeaderCtrl.QueryOne(dcf, sqm, ref recHeader, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetTxnRecoverDataList(string filter,int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWTxnRecoverHeader> recHeaderList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!string.IsNullOrEmpty(filter.Trim()))
            {
                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                string[] filterGroup = filter.Trim().Split(' ');
                foreach (var f in filterGroup)
                {
                    if (f.Trim() == "")
                    {
                        continue;
                    }
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getCarCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getDriverColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getDriverCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getInspectorColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                    sw.AddLikeValue(TblMWTxnRecoverHeader.getInspectorCodeColumn(), SqlCommonFn.SqlWhereLikeEnum.MidLike, f.Trim());
                }
                sqm.Condition.Where.AddWhere(sw);
            }

            sqm.Condition.OrderBy.Add(TblMWTxnRecoverHeader.getStartDateColumn(), SqlCommonFn.SqlOrderByType.DESC);

            if (!TblMWTxnRecoverHeaderCtrl.QueryPage(dcf, sqm, page, pageSize, ref recHeaderList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;

            return true;
        }
        #endregion
    }
}
