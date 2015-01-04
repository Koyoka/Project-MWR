using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace MWRDBModule.DBModule
{
    public class TblMWDestroyHeaderCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWDestroyHeader> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWDestroyHeader> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWDestroyHeader.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWDestroyHeader(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWDestroyHeader> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWDestroyHeader> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWDestroyHeader.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWDestroyHeader(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWDestroyHeader item,ref string errMsg)
        {
            List<TblMWDestroyHeader> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWDestroyHeader item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWDestroyHeader item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.DestHeaderId,
                item.DestNum,
                item.StratDate,
                item.EndDate,
                item.DestWSCode,
                item.DestEmpyCode,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int destHeaderId,
            string destNum,
            DateTime stratDate,
            DateTime endDate,
            string destWSCode,
            string destEmpyCode,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWDestroyHeader.getFormatTableName());
            sum.Add(TblMWDestroyHeader.getDestHeaderIdColumn(), destHeaderId);
            sum.Add(TblMWDestroyHeader.getDestNumColumn(), destNum);
            sum.Add(TblMWDestroyHeader.getStratDateColumn(), stratDate);
            sum.Add(TblMWDestroyHeader.getEndDateColumn(), endDate);
            sum.Add(TblMWDestroyHeader.getDestWSCodeColumn(), destWSCode);
            sum.Add(TblMWDestroyHeader.getDestEmpyCodeColumn(), destEmpyCode);
            sum.Add(TblMWDestroyHeader.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWDestroyHeader item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWDestroyHeader.getDestHeaderIdColumn(), item.DestHeaderId);
            suc.Add(TblMWDestroyHeader.getDestNumColumn(), item.DestNum);
            suc.Add(TblMWDestroyHeader.getStratDateColumn(), item.StratDate);
            suc.Add(TblMWDestroyHeader.getEndDateColumn(), item.EndDate);
            suc.Add(TblMWDestroyHeader.getDestWSCodeColumn(), item.DestWSCode);
            suc.Add(TblMWDestroyHeader.getDestEmpyCodeColumn(), item.DestEmpyCode);
            suc.Add(TblMWDestroyHeader.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWDestroyHeader item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
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
            sum.setQueryTableName(TblMWDestroyHeader.getFormatTableName());
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
            sum.setQueryTableName(TblMWDestroyHeader.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
