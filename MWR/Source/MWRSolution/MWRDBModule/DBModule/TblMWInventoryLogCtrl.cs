using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace MWRDBModule.DBModule
{
    public class TblMWInventoryLogCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWInventoryLog> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWInventoryLog> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWInventoryLog.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInventoryLog(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWInventoryLog> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWInventoryLog> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWInventoryLog.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInventoryLog(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWInventoryLog item,ref string errMsg)
        {
            List<TblMWInventoryLog> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWInventoryLog item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWInventoryLog item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.InvLogId,
                item.WSCode,
                item.EmpyCode,
                item.OptType,
                item.OptDate,
                item.InvLogType,
                item.InvRecordId,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int invLogId,
            string wSCode,
            string empyCode,
            string optType,
            DateTime optDate,
            string invLogType,
            int invRecordId,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInventoryLog.getFormatTableName());
            sum.Add(TblMWInventoryLog.getInvLogIdColumn(), invLogId);
            sum.Add(TblMWInventoryLog.getWSCodeColumn(), wSCode);
            sum.Add(TblMWInventoryLog.getEmpyCodeColumn(), empyCode);
            sum.Add(TblMWInventoryLog.getOptTypeColumn(), optType);
            sum.Add(TblMWInventoryLog.getOptDateColumn(), optDate);
            sum.Add(TblMWInventoryLog.getInvLogTypeColumn(), invLogType);
            sum.Add(TblMWInventoryLog.getInvRecordIdColumn(), invRecordId);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInventoryLog item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWInventoryLog.getInvLogIdColumn(), item.InvLogId);
            suc.Add(TblMWInventoryLog.getWSCodeColumn(), item.WSCode);
            suc.Add(TblMWInventoryLog.getEmpyCodeColumn(), item.EmpyCode);
            suc.Add(TblMWInventoryLog.getOptTypeColumn(), item.OptType);
            suc.Add(TblMWInventoryLog.getOptDateColumn(), item.OptDate);
            suc.Add(TblMWInventoryLog.getInvLogTypeColumn(), item.InvLogType);
            suc.Add(TblMWInventoryLog.getInvRecordIdColumn(), item.InvRecordId);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInventoryLog item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
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
            sum.setQueryTableName(TblMWInventoryLog.getFormatTableName());
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
            sum.setQueryTableName(TblMWInventoryLog.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
