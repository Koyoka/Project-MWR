﻿using System;
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
    }
}