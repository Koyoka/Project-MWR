using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWFunctionGroupDetailCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWFunctionGroupDetail> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWFunctionGroupDetail> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWFunctionGroupDetail(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWFunctionGroupDetail> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWFunctionGroupDetail> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWFunctionGroupDetail(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWFunctionGroupDetail item,ref string errMsg)
        {
            List<TblMWFunctionGroupDetail> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWFunctionGroupDetail item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWFunctionGroupDetail item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.FuncGroupDtlId,
                item.FuncGroupId,
                item.FuncTag,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int funcGroupDtlId,
            int funcGroupId,
            string funcTag,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
            sum.Add(TblMWFunctionGroupDetail.getFuncGroupDtlIdColumn(), funcGroupDtlId);
            sum.Add(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), funcGroupId);
            sum.Add(TblMWFunctionGroupDetail.getFuncTagColumn(), funcTag);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWFunctionGroupDetail item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWFunctionGroupDetail.getFuncGroupDtlIdColumn(), item.FuncGroupDtlId);
            suc.Add(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), item.FuncGroupId);
            suc.Add(TblMWFunctionGroupDetail.getFuncTagColumn(), item.FuncTag);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWFunctionGroupDetail item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
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
            sum.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
