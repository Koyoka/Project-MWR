using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace MWRDBModule.DBModule
{
    public class TblMWPostDetailCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWPostDetail> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWPostDetail> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWPostDetail.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWPostDetail(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWPostDetail> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWPostDetail> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWPostDetail.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWPostDetail(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWPostDetail item,ref string errMsg)
        {
            List<TblMWPostDetail> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWPostDetail item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWPostDetail item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.PostDtlId,
                item.PostHeaderId,
                item.CrateCode,
                item.PostNum,
                item.DepotCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.InvWeight,
                item.PostWeight,
                item.Status,
                item.InvRecordId,
                item.InvAuthId,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int postDtlId,
            int postHeaderId,
            string crateCode,
            string postNum,
            string depotCode,
            string vendor,
            string vendorCode,
            string waste,
            string wasteCode,
            float invWeight,
            float postWeight,
            string status,
            int invRecordId,
            int invAuthId,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWPostDetail.getFormatTableName());
            sum.Add(TblMWPostDetail.getPostDtlIdColumn(), postDtlId);
            sum.Add(TblMWPostDetail.getPostHeaderIdColumn(), postHeaderId);
            sum.Add(TblMWPostDetail.getCrateCodeColumn(), crateCode);
            sum.Add(TblMWPostDetail.getPostNumColumn(), postNum);
            sum.Add(TblMWPostDetail.getDepotCodeColumn(), depotCode);
            sum.Add(TblMWPostDetail.getVendorColumn(), vendor);
            sum.Add(TblMWPostDetail.getVendorCodeColumn(), vendorCode);
            sum.Add(TblMWPostDetail.getWasteColumn(), waste);
            sum.Add(TblMWPostDetail.getWasteCodeColumn(), wasteCode);
            sum.Add(TblMWPostDetail.getInvWeightColumn(), invWeight);
            sum.Add(TblMWPostDetail.getPostWeightColumn(), postWeight);
            sum.Add(TblMWPostDetail.getStatusColumn(), status);
            sum.Add(TblMWPostDetail.getInvRecordIdColumn(), invRecordId);
            sum.Add(TblMWPostDetail.getInvAuthIdColumn(), invAuthId);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWPostDetail item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWPostDetail.getPostDtlIdColumn(), item.PostDtlId);
            suc.Add(TblMWPostDetail.getPostHeaderIdColumn(), item.PostHeaderId);
            suc.Add(TblMWPostDetail.getCrateCodeColumn(), item.CrateCode);
            suc.Add(TblMWPostDetail.getPostNumColumn(), item.PostNum);
            suc.Add(TblMWPostDetail.getDepotCodeColumn(), item.DepotCode);
            suc.Add(TblMWPostDetail.getVendorColumn(), item.Vendor);
            suc.Add(TblMWPostDetail.getVendorCodeColumn(), item.VendorCode);
            suc.Add(TblMWPostDetail.getWasteColumn(), item.Waste);
            suc.Add(TblMWPostDetail.getWasteCodeColumn(), item.WasteCode);
            suc.Add(TblMWPostDetail.getInvWeightColumn(), item.InvWeight);
            suc.Add(TblMWPostDetail.getPostWeightColumn(), item.PostWeight);
            suc.Add(TblMWPostDetail.getStatusColumn(), item.Status);
            suc.Add(TblMWPostDetail.getInvRecordIdColumn(), item.InvRecordId);
            suc.Add(TblMWPostDetail.getInvAuthIdColumn(), item.InvAuthId);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWPostDetail item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns == null)
                 return true;
            if (suc.Columns.Length == 0)
                 return true;
            SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWPostDetail.getFormatTableName());
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
            sum.setQueryTableName(TblMWPostDetail.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
