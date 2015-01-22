using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWInventoryCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWInventory> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWInventory> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWInventory.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInventory(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWInventory> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWInventory> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWInventory.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInventory(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWInventory item,ref string errMsg)
        {
            List<TblMWInventory> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWInventory item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWInventory item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.InvRecordId,
                item.CrateCode,
                item.DepotCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.RecoWeight,
                item.InvWeight,
                item.PostWeight,
                item.DestWeight,
                item.EntryDate,
                item.Status,
                item.DailyClose,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int invRecordId,
            string crateCode,
            string depotCode,
            string vendor,
            string vendorCode,
            string waste,
            string wasteCode,
            decimal recoWeight,
            decimal invWeight,
            decimal postWeight,
            decimal destWeight,
            DateTime entryDate,
            string status,
            bool dailyClose,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInventory.getFormatTableName());
            sum.Add(TblMWInventory.getInvRecordIdColumn(), invRecordId);
            sum.Add(TblMWInventory.getCrateCodeColumn(), crateCode);
            sum.Add(TblMWInventory.getDepotCodeColumn(), depotCode);
            sum.Add(TblMWInventory.getVendorColumn(), vendor);
            sum.Add(TblMWInventory.getVendorCodeColumn(), vendorCode);
            sum.Add(TblMWInventory.getWasteColumn(), waste);
            sum.Add(TblMWInventory.getWasteCodeColumn(), wasteCode);
            sum.Add(TblMWInventory.getRecoWeightColumn(), recoWeight);
            sum.Add(TblMWInventory.getInvWeightColumn(), invWeight);
            sum.Add(TblMWInventory.getPostWeightColumn(), postWeight);
            sum.Add(TblMWInventory.getDestWeightColumn(), destWeight);
            sum.Add(TblMWInventory.getEntryDateColumn(), entryDate);
            sum.Add(TblMWInventory.getStatusColumn(), status);
            sum.Add(TblMWInventory.getDailyCloseColumn(), dailyClose);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInventory item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWInventory.getInvRecordIdColumn(), item.InvRecordId);
            suc.Add(TblMWInventory.getCrateCodeColumn(), item.CrateCode);
            suc.Add(TblMWInventory.getDepotCodeColumn(), item.DepotCode);
            suc.Add(TblMWInventory.getVendorColumn(), item.Vendor);
            suc.Add(TblMWInventory.getVendorCodeColumn(), item.VendorCode);
            suc.Add(TblMWInventory.getWasteColumn(), item.Waste);
            suc.Add(TblMWInventory.getWasteCodeColumn(), item.WasteCode);
            suc.Add(TblMWInventory.getRecoWeightColumn(), item.RecoWeight);
            suc.Add(TblMWInventory.getInvWeightColumn(), item.InvWeight);
            suc.Add(TblMWInventory.getPostWeightColumn(), item.PostWeight);
            suc.Add(TblMWInventory.getDestWeightColumn(), item.DestWeight);
            suc.Add(TblMWInventory.getEntryDateColumn(), item.EntryDate);
            suc.Add(TblMWInventory.getStatusColumn(), item.Status);
            suc.Add(TblMWInventory.getDailyCloseColumn(), item.DailyClose);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInventory item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInventory.getFormatTableName());
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
            sum.setQueryTableName(TblMWInventory.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
