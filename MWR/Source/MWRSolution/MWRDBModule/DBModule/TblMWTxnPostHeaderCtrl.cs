using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWTxnPostHeaderCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWTxnPostHeader> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWTxnPostHeader> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnPostHeader(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWTxnPostHeader> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWTxnPostHeader> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnPostHeader(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWTxnPostHeader item,ref string errMsg)
        {
            List<TblMWTxnPostHeader> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWTxnPostHeader item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWTxnPostHeader item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.PostHeaderId,
                item.TxnNum,
                item.PostWSCode,
                item.PostEmpyName,
                item.PostEmpyCode,
                item.StratDate,
                item.EndDate,
                item.PostType,
                item.TotalCrateQty,
                item.TotalSubWeight,
                item.TotalTxnWeight,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int postHeaderId,
            string txnNum,
            string postWSCode,
            string postEmpyName,
            string postEmpyCode,
            DateTime stratDate,
            DateTime endDate,
            string postType,
            int totalCrateQty,
            decimal totalSubWeight,
            decimal totalTxnWeight,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
            sum.Add(TblMWTxnPostHeader.getPostHeaderIdColumn(), postHeaderId);
            sum.Add(TblMWTxnPostHeader.getTxnNumColumn(), txnNum);
            sum.Add(TblMWTxnPostHeader.getPostWSCodeColumn(), postWSCode);
            sum.Add(TblMWTxnPostHeader.getPostEmpyNameColumn(), postEmpyName);
            sum.Add(TblMWTxnPostHeader.getPostEmpyCodeColumn(), postEmpyCode);
            sum.Add(TblMWTxnPostHeader.getStratDateColumn(), stratDate);
            sum.Add(TblMWTxnPostHeader.getEndDateColumn(), endDate);
            sum.Add(TblMWTxnPostHeader.getPostTypeColumn(), postType);
            sum.Add(TblMWTxnPostHeader.getTotalCrateQtyColumn(), totalCrateQty);
            sum.Add(TblMWTxnPostHeader.getTotalSubWeightColumn(), totalSubWeight);
            sum.Add(TblMWTxnPostHeader.getTotalTxnWeightColumn(), totalTxnWeight);
            sum.Add(TblMWTxnPostHeader.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnPostHeader item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWTxnPostHeader.getPostHeaderIdColumn(), item.PostHeaderId);
            suc.Add(TblMWTxnPostHeader.getTxnNumColumn(), item.TxnNum);
            suc.Add(TblMWTxnPostHeader.getPostWSCodeColumn(), item.PostWSCode);
            suc.Add(TblMWTxnPostHeader.getPostEmpyNameColumn(), item.PostEmpyName);
            suc.Add(TblMWTxnPostHeader.getPostEmpyCodeColumn(), item.PostEmpyCode);
            suc.Add(TblMWTxnPostHeader.getStratDateColumn(), item.StratDate);
            suc.Add(TblMWTxnPostHeader.getEndDateColumn(), item.EndDate);
            suc.Add(TblMWTxnPostHeader.getPostTypeColumn(), item.PostType);
            suc.Add(TblMWTxnPostHeader.getTotalCrateQtyColumn(), item.TotalCrateQty);
            suc.Add(TblMWTxnPostHeader.getTotalSubWeightColumn(), item.TotalSubWeight);
            suc.Add(TblMWTxnPostHeader.getTotalTxnWeightColumn(), item.TotalTxnWeight);
            suc.Add(TblMWTxnPostHeader.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnPostHeader item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
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
            sum.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
