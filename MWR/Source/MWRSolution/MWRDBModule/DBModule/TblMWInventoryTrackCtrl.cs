using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWInventoryTrackCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWInventoryTrack> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWInventoryTrack> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInventoryTrack(), sqm.getParamsArray());
                if (itemList.Count != 0)
                {
                    dcf.RowCount = itemList[0].TEM_COLUMN_COUNT;
                    dcf.PageCount = ComFn.getPageCount(pageSize, dcf.RowCount);
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true ;
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWInventoryTrack> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWInventoryTrack> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInventoryTrack(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWInventoryTrack item,ref string errMsg)
        {
            List<TblMWInventoryTrack> itemList = null;
            if (!QueryMore(dcf, sqm, ref itemList, ref errMsg))
            {
                return false;
            }

            if (itemList.Count > 0)
            {
                item = itemList[0];
            }
            else
            {
                item = null;
            }

            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWInventoryTrack item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWInventoryTrack item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.InvTrackRecordId,
                item.InvRecordId,
                item.TxnNum,
                item.TxnType,
                item.TxnDetailId,
                item.CrateCode,
                item.DepotCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.SubWeight,
                item.TxnWeight,
                item.WSCode,
                item.EmpyName,
                item.EmpyCode,
                item.EntryDate,
                item.Status,
                item.InvAuthId,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int invTrackRecordId,
            int invRecordId,
            string txnNum,
            string txnType,
            int txnDetailId,
            string crateCode,
            string depotCode,
            string vendor,
            string vendorCode,
            string waste,
            string wasteCode,
            decimal subWeight,
            decimal txnWeight,
            string wSCode,
            string empyName,
            string empyCode,
            DateTime entryDate,
            string status,
            int invAuthId,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
            sum.Add(TblMWInventoryTrack.getInvTrackRecordIdColumn(), invTrackRecordId);
            sum.Add(TblMWInventoryTrack.getInvRecordIdColumn(), invRecordId);
            sum.Add(TblMWInventoryTrack.getTxnNumColumn(), txnNum);
            sum.Add(TblMWInventoryTrack.getTxnTypeColumn(), txnType);
            sum.Add(TblMWInventoryTrack.getTxnDetailIdColumn(), txnDetailId);
            sum.Add(TblMWInventoryTrack.getCrateCodeColumn(), crateCode);
            sum.Add(TblMWInventoryTrack.getDepotCodeColumn(), depotCode);
            sum.Add(TblMWInventoryTrack.getVendorColumn(), vendor);
            sum.Add(TblMWInventoryTrack.getVendorCodeColumn(), vendorCode);
            sum.Add(TblMWInventoryTrack.getWasteColumn(), waste);
            sum.Add(TblMWInventoryTrack.getWasteCodeColumn(), wasteCode);
            sum.Add(TblMWInventoryTrack.getSubWeightColumn(), subWeight);
            sum.Add(TblMWInventoryTrack.getTxnWeightColumn(), txnWeight);
            sum.Add(TblMWInventoryTrack.getWSCodeColumn(), wSCode);
            sum.Add(TblMWInventoryTrack.getEmpyNameColumn(), empyName);
            sum.Add(TblMWInventoryTrack.getEmpyCodeColumn(), empyCode);
            sum.Add(TblMWInventoryTrack.getEntryDateColumn(), entryDate);
            sum.Add(TblMWInventoryTrack.getStatusColumn(), status);
            sum.Add(TblMWInventoryTrack.getInvAuthIdColumn(), invAuthId);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInventoryTrack item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWInventoryTrack.getInvTrackRecordIdColumn(), item.InvTrackRecordId);
            suc.Add(TblMWInventoryTrack.getInvRecordIdColumn(), item.InvRecordId);
            suc.Add(TblMWInventoryTrack.getTxnNumColumn(), item.TxnNum);
            suc.Add(TblMWInventoryTrack.getTxnTypeColumn(), item.TxnType);
            suc.Add(TblMWInventoryTrack.getTxnDetailIdColumn(), item.TxnDetailId);
            suc.Add(TblMWInventoryTrack.getCrateCodeColumn(), item.CrateCode);
            suc.Add(TblMWInventoryTrack.getDepotCodeColumn(), item.DepotCode);
            suc.Add(TblMWInventoryTrack.getVendorColumn(), item.Vendor);
            suc.Add(TblMWInventoryTrack.getVendorCodeColumn(), item.VendorCode);
            suc.Add(TblMWInventoryTrack.getWasteColumn(), item.Waste);
            suc.Add(TblMWInventoryTrack.getWasteCodeColumn(), item.WasteCode);
            suc.Add(TblMWInventoryTrack.getSubWeightColumn(), item.SubWeight);
            suc.Add(TblMWInventoryTrack.getTxnWeightColumn(), item.TxnWeight);
            suc.Add(TblMWInventoryTrack.getWSCodeColumn(), item.WSCode);
            suc.Add(TblMWInventoryTrack.getEmpyNameColumn(), item.EmpyName);
            suc.Add(TblMWInventoryTrack.getEmpyCodeColumn(), item.EmpyCode);
            suc.Add(TblMWInventoryTrack.getEntryDateColumn(), item.EntryDate);
            suc.Add(TblMWInventoryTrack.getStatusColumn(), item.Status);
            suc.Add(TblMWInventoryTrack.getInvAuthIdColumn(), item.InvAuthId);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInventoryTrack item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
            string sql = sum.getUpdateSql(suc, sw);
            if (sql == null)
            {
                errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }

        public static bool Delete(DataCtrlInfo dcf, SqlWhere sw, ref int count, ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
