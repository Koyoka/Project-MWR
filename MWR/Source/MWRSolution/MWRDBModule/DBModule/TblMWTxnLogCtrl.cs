using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWTxnLogCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWTxnLog> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWTxnLog> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWTxnLog.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnLog(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWTxnLog> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWTxnLog> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWTxnLog.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnLog(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWTxnLog item,ref string errMsg)
        {
            List<TblMWTxnLog> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWTxnLog item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWTxnLog item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.TxnLogId,
                item.TxnNum,
                item.TxnDetailId,
                item.WSCode,
                item.EmpyName,
                item.EmpyCode,
                item.OptType,
                item.OptDate,
                item.TxnLogType,
                item.InvRecordId,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int txnLogId,
            string txnNum,
            int txnDetailId,
            string wSCode,
            string empyName,
            string empyCode,
            string optType,
            DateTime optDate,
            string txnLogType,
            int invRecordId,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWTxnLog.getFormatTableName());
            sum.Add(TblMWTxnLog.getTxnLogIdColumn(), txnLogId);
            sum.Add(TblMWTxnLog.getTxnNumColumn(), txnNum);
            sum.Add(TblMWTxnLog.getTxnDetailIdColumn(), txnDetailId);
            sum.Add(TblMWTxnLog.getWSCodeColumn(), wSCode);
            sum.Add(TblMWTxnLog.getEmpyNameColumn(), empyName);
            sum.Add(TblMWTxnLog.getEmpyCodeColumn(), empyCode);
            sum.Add(TblMWTxnLog.getOptTypeColumn(), optType);
            sum.Add(TblMWTxnLog.getOptDateColumn(), optDate);
            sum.Add(TblMWTxnLog.getTxnLogTypeColumn(), txnLogType);
            sum.Add(TblMWTxnLog.getInvRecordIdColumn(), invRecordId);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnLog item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWTxnLog.getTxnLogIdColumn(), item.TxnLogId);
            suc.Add(TblMWTxnLog.getTxnNumColumn(), item.TxnNum);
            suc.Add(TblMWTxnLog.getTxnDetailIdColumn(), item.TxnDetailId);
            suc.Add(TblMWTxnLog.getWSCodeColumn(), item.WSCode);
            suc.Add(TblMWTxnLog.getEmpyNameColumn(), item.EmpyName);
            suc.Add(TblMWTxnLog.getEmpyCodeColumn(), item.EmpyCode);
            suc.Add(TblMWTxnLog.getOptTypeColumn(), item.OptType);
            suc.Add(TblMWTxnLog.getOptDateColumn(), item.OptDate);
            suc.Add(TblMWTxnLog.getTxnLogTypeColumn(), item.TxnLogType);
            suc.Add(TblMWTxnLog.getInvRecordIdColumn(), item.InvRecordId);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnLog item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
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
            sum.setQueryTableName(TblMWTxnLog.getFormatTableName());
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
            sum.setQueryTableName(TblMWTxnLog.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
