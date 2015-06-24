using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWDestroyMCParamsLogCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWDestroyMCParamsLog> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWDestroyMCParamsLog> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWDestroyMCParamsLog.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWDestroyMCParamsLog(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWDestroyMCParamsLog> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWDestroyMCParamsLog> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWDestroyMCParamsLog.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWDestroyMCParamsLog(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWDestroyMCParamsLog item,ref string errMsg)
        {
            List<TblMWDestroyMCParamsLog> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWDestroyMCParamsLog item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWDestroyMCParamsLog item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.MCCode,
                item.RunDate,
                item.WSCode,
                item.DisiNum,
                item.Pressure,
                item.InTemperature,
                item.ExTemperature,
                item.EC1,
                item.EC2,
                item.WordStatus,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            string mCCode,
            DateTime runDate,
            string wSCode,
            int disiNum,
            float pressure,
            float inTemperature,
            float exTemperature,
            float eC1,
            float eC2,
            string wordStatus,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWDestroyMCParamsLog.getFormatTableName());
            sum.Add(TblMWDestroyMCParamsLog.getMCCodeColumn(), mCCode);
            sum.Add(TblMWDestroyMCParamsLog.getRunDateColumn(), runDate);
            sum.Add(TblMWDestroyMCParamsLog.getWSCodeColumn(), wSCode);
            sum.Add(TblMWDestroyMCParamsLog.getDisiNumColumn(), disiNum);
            sum.Add(TblMWDestroyMCParamsLog.getPressureColumn(), pressure);
            sum.Add(TblMWDestroyMCParamsLog.getInTemperatureColumn(), inTemperature);
            sum.Add(TblMWDestroyMCParamsLog.getExTemperatureColumn(), exTemperature);
            sum.Add(TblMWDestroyMCParamsLog.getEC1Column(), eC1);
            sum.Add(TblMWDestroyMCParamsLog.getEC2Column(), eC2);
            sum.Add(TblMWDestroyMCParamsLog.getWordStatusColumn(), wordStatus);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWDestroyMCParamsLog item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWDestroyMCParamsLog.getMCCodeColumn(), item.MCCode);
            suc.Add(TblMWDestroyMCParamsLog.getRunDateColumn(), item.RunDate);
            suc.Add(TblMWDestroyMCParamsLog.getWSCodeColumn(), item.WSCode);
            suc.Add(TblMWDestroyMCParamsLog.getDisiNumColumn(), item.DisiNum);
            suc.Add(TblMWDestroyMCParamsLog.getPressureColumn(), item.Pressure);
            suc.Add(TblMWDestroyMCParamsLog.getInTemperatureColumn(), item.InTemperature);
            suc.Add(TblMWDestroyMCParamsLog.getExTemperatureColumn(), item.ExTemperature);
            suc.Add(TblMWDestroyMCParamsLog.getEC1Column(), item.EC1);
            suc.Add(TblMWDestroyMCParamsLog.getEC2Column(), item.EC2);
            suc.Add(TblMWDestroyMCParamsLog.getWordStatusColumn(), item.WordStatus);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWDestroyMCParamsLog item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWDestroyMCParamsLog.getFormatTableName());
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
            sum.setQueryTableName(TblMWDestroyMCParamsLog.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
