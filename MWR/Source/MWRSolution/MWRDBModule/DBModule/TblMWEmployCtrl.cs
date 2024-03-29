using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWEmployCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWEmploy> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWEmploy> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWEmploy.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWEmploy(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWEmploy> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWEmploy> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWEmploy.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWEmploy(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWEmploy item,ref string errMsg)
        {
            List<TblMWEmploy> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWEmploy item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWEmploy item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.EmpyCode,
                item.EmpyName,
                item.FuncGroupId,
                item.EmpyType,
                item.UserName,
                item.Password,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            string empyCode,
            string empyName,
            int funcGroupId,
            string empyType,
            string userName,
            string password,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWEmploy.getFormatTableName());
            sum.Add(TblMWEmploy.getEmpyCodeColumn(), empyCode);
            sum.Add(TblMWEmploy.getEmpyNameColumn(), empyName);
            sum.Add(TblMWEmploy.getFuncGroupIdColumn(), funcGroupId);
            sum.Add(TblMWEmploy.getEmpyTypeColumn(), empyType);
            sum.Add(TblMWEmploy.getUserNameColumn(), userName);
            sum.Add(TblMWEmploy.getPasswordColumn(), password);
            sum.Add(TblMWEmploy.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWEmploy item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWEmploy.getEmpyCodeColumn(), item.EmpyCode);
            suc.Add(TblMWEmploy.getEmpyNameColumn(), item.EmpyName);
            suc.Add(TblMWEmploy.getFuncGroupIdColumn(), item.FuncGroupId);
            suc.Add(TblMWEmploy.getEmpyTypeColumn(), item.EmpyType);
            suc.Add(TblMWEmploy.getUserNameColumn(), item.UserName);
            suc.Add(TblMWEmploy.getPasswordColumn(), item.Password);
            suc.Add(TblMWEmploy.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWEmploy item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWEmploy.getFormatTableName());
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
            sum.setQueryTableName(TblMWEmploy.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
