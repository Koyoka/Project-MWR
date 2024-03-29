using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWTxnDestroyHeaderCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWTxnDestroyHeader> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWTxnDestroyHeader> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnDestroyHeader(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWTxnDestroyHeader> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWTxnDestroyHeader> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnDestroyHeader(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWTxnDestroyHeader item,ref string errMsg)
        {
            List<TblMWTxnDestroyHeader> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWTxnDestroyHeader item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWTxnDestroyHeader item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.DestHeaderId,
                item.TxnNum,
                item.DestType,
                item.StartDate,
                item.EndDate,
                item.DestWSCode,
                item.DestEmpyName,
                item.DestEmpyCode,
                item.TotalCrateQty,
                item.TotalSubWeight,
                item.TotalTxnWeight,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int destHeaderId,
            string txnNum,
            string destType,
            DateTime startDate,
            DateTime endDate,
            string destWSCode,
            string destEmpyName,
            string destEmpyCode,
            int totalCrateQty,
            decimal totalSubWeight,
            decimal totalTxnWeight,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
            sum.Add(TblMWTxnDestroyHeader.getDestHeaderIdColumn(), destHeaderId);
            sum.Add(TblMWTxnDestroyHeader.getTxnNumColumn(), txnNum);
            sum.Add(TblMWTxnDestroyHeader.getDestTypeColumn(), destType);
            sum.Add(TblMWTxnDestroyHeader.getStartDateColumn(), startDate);
            sum.Add(TblMWTxnDestroyHeader.getEndDateColumn(), endDate);
            sum.Add(TblMWTxnDestroyHeader.getDestWSCodeColumn(), destWSCode);
            sum.Add(TblMWTxnDestroyHeader.getDestEmpyNameColumn(), destEmpyName);
            sum.Add(TblMWTxnDestroyHeader.getDestEmpyCodeColumn(), destEmpyCode);
            sum.Add(TblMWTxnDestroyHeader.getTotalCrateQtyColumn(), totalCrateQty);
            sum.Add(TblMWTxnDestroyHeader.getTotalSubWeightColumn(), totalSubWeight);
            sum.Add(TblMWTxnDestroyHeader.getTotalTxnWeightColumn(), totalTxnWeight);
            sum.Add(TblMWTxnDestroyHeader.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnDestroyHeader item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWTxnDestroyHeader.getDestHeaderIdColumn(), item.DestHeaderId);
            suc.Add(TblMWTxnDestroyHeader.getTxnNumColumn(), item.TxnNum);
            suc.Add(TblMWTxnDestroyHeader.getDestTypeColumn(), item.DestType);
            suc.Add(TblMWTxnDestroyHeader.getStartDateColumn(), item.StartDate);
            suc.Add(TblMWTxnDestroyHeader.getEndDateColumn(), item.EndDate);
            suc.Add(TblMWTxnDestroyHeader.getDestWSCodeColumn(), item.DestWSCode);
            suc.Add(TblMWTxnDestroyHeader.getDestEmpyNameColumn(), item.DestEmpyName);
            suc.Add(TblMWTxnDestroyHeader.getDestEmpyCodeColumn(), item.DestEmpyCode);
            suc.Add(TblMWTxnDestroyHeader.getTotalCrateQtyColumn(), item.TotalCrateQty);
            suc.Add(TblMWTxnDestroyHeader.getTotalSubWeightColumn(), item.TotalSubWeight);
            suc.Add(TblMWTxnDestroyHeader.getTotalTxnWeightColumn(), item.TotalTxnWeight);
            suc.Add(TblMWTxnDestroyHeader.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnDestroyHeader item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
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
            sum.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
