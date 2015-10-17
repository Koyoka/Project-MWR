using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWDestroyMCDetailCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWDestroyMCDetail> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWDestroyMCDetail> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWDestroyMCDetail.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWDestroyMCDetail(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWDestroyMCDetail> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWDestroyMCDetail> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWDestroyMCDetail.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWDestroyMCDetail(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWDestroyMCDetail item,ref string errMsg)
        {
            List<TblMWDestroyMCDetail> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWDestroyMCDetail item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWDestroyMCDetail item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.MCDetailId,
                item.DisiNum,
                item.TxnDetailId,
                item.WSCode,
                item.CrateCode,
                item.DestWeight,
                item.EntryDate,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int mCDetailId,
            int disiNum,
            int txnDetailId,
            string wSCode,
            string crateCode,
            decimal destWeight,
            DateTime entryDate,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWDestroyMCDetail.getFormatTableName());
            sum.Add(TblMWDestroyMCDetail.getMCDetailIdColumn(), mCDetailId);
            sum.Add(TblMWDestroyMCDetail.getDisiNumColumn(), disiNum);
            sum.Add(TblMWDestroyMCDetail.getTxnDetailIdColumn(), txnDetailId);
            sum.Add(TblMWDestroyMCDetail.getWSCodeColumn(), wSCode);
            sum.Add(TblMWDestroyMCDetail.getCrateCodeColumn(), crateCode);
            sum.Add(TblMWDestroyMCDetail.getDestWeightColumn(), destWeight);
            sum.Add(TblMWDestroyMCDetail.getEntryDateColumn(), entryDate);
            sum.Add(TblMWDestroyMCDetail.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWDestroyMCDetail item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWDestroyMCDetail.getMCDetailIdColumn(), item.MCDetailId);
            suc.Add(TblMWDestroyMCDetail.getDisiNumColumn(), item.DisiNum);
            suc.Add(TblMWDestroyMCDetail.getTxnDetailIdColumn(), item.TxnDetailId);
            suc.Add(TblMWDestroyMCDetail.getWSCodeColumn(), item.WSCode);
            suc.Add(TblMWDestroyMCDetail.getCrateCodeColumn(), item.CrateCode);
            suc.Add(TblMWDestroyMCDetail.getDestWeightColumn(), item.DestWeight);
            suc.Add(TblMWDestroyMCDetail.getEntryDateColumn(), item.EntryDate);
            suc.Add(TblMWDestroyMCDetail.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWDestroyMCDetail item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWDestroyMCDetail.getFormatTableName());
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
            sum.setQueryTableName(TblMWDestroyMCDetail.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
