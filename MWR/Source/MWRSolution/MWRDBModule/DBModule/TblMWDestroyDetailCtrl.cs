using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWDestroyDetailCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWDestroyDetail> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWDestroyDetail> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWDestroyDetail(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWDestroyDetail> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWDestroyDetail> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWDestroyDetail(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWDestroyDetail item,ref string errMsg)
        {
            List<TblMWDestroyDetail> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWDestroyDetail item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWDestroyDetail item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.DestroyDtlId,
                item.CrateCode,
                item.DestHeaderId,
                item.DestNum,
                item.DepotCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.PostWeight,
                item.DestWeight,
                item.Status,
                item.PostHeaderId,
                item.InvRecordId,
                item.InvAuthId,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int destroyDtlId,
            string crateCode,
            int destHeaderId,
            string destNum,
            string depotCode,
            string vendor,
            string vendorCode,
            string waste,
            string wasteCode,
            float postWeight,
            float destWeight,
            string status,
            int postHeaderId,
            int invRecordId,
            int invAuthId,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
            sum.Add(TblMWDestroyDetail.getDestroyDtlIdColumn(), destroyDtlId);
            sum.Add(TblMWDestroyDetail.getCrateCodeColumn(), crateCode);
            sum.Add(TblMWDestroyDetail.getDestHeaderIdColumn(), destHeaderId);
            sum.Add(TblMWDestroyDetail.getDestNumColumn(), destNum);
            sum.Add(TblMWDestroyDetail.getDepotCodeColumn(), depotCode);
            sum.Add(TblMWDestroyDetail.getVendorColumn(), vendor);
            sum.Add(TblMWDestroyDetail.getVendorCodeColumn(), vendorCode);
            sum.Add(TblMWDestroyDetail.getWasteColumn(), waste);
            sum.Add(TblMWDestroyDetail.getWasteCodeColumn(), wasteCode);
            sum.Add(TblMWDestroyDetail.getPostWeightColumn(), postWeight);
            sum.Add(TblMWDestroyDetail.getDestWeightColumn(), destWeight);
            sum.Add(TblMWDestroyDetail.getStatusColumn(), status);
            sum.Add(TblMWDestroyDetail.getPostHeaderIdColumn(), postHeaderId);
            sum.Add(TblMWDestroyDetail.getInvRecordIdColumn(), invRecordId);
            sum.Add(TblMWDestroyDetail.getInvAuthIdColumn(), invAuthId);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWDestroyDetail item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWDestroyDetail.getDestroyDtlIdColumn(), item.DestroyDtlId);
            suc.Add(TblMWDestroyDetail.getCrateCodeColumn(), item.CrateCode);
            suc.Add(TblMWDestroyDetail.getDestHeaderIdColumn(), item.DestHeaderId);
            suc.Add(TblMWDestroyDetail.getDestNumColumn(), item.DestNum);
            suc.Add(TblMWDestroyDetail.getDepotCodeColumn(), item.DepotCode);
            suc.Add(TblMWDestroyDetail.getVendorColumn(), item.Vendor);
            suc.Add(TblMWDestroyDetail.getVendorCodeColumn(), item.VendorCode);
            suc.Add(TblMWDestroyDetail.getWasteColumn(), item.Waste);
            suc.Add(TblMWDestroyDetail.getWasteCodeColumn(), item.WasteCode);
            suc.Add(TblMWDestroyDetail.getPostWeightColumn(), item.PostWeight);
            suc.Add(TblMWDestroyDetail.getDestWeightColumn(), item.DestWeight);
            suc.Add(TblMWDestroyDetail.getStatusColumn(), item.Status);
            suc.Add(TblMWDestroyDetail.getPostHeaderIdColumn(), item.PostHeaderId);
            suc.Add(TblMWDestroyDetail.getInvRecordIdColumn(), item.InvRecordId);
            suc.Add(TblMWDestroyDetail.getInvAuthIdColumn(), item.InvAuthId);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWDestroyDetail item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
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
            sum.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
