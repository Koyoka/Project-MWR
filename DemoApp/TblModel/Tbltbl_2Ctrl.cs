using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace DemoApp.TblModel
{
    public class Tbltbl_2Ctrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<Tbltbl_2> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(Tbltbl_2.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tbltbl_2(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<Tbltbl_2> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<Tbltbl_2> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(Tbltbl_2.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tbltbl_2(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref Tbltbl_2 item,ref string errMsg)
        {
            List<Tbltbl_2> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref Tbltbl_2 item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, Tbltbl_2 item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.str1,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            string str1,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tbltbl_2.getFormatTableName());
            sum.Add(Tbltbl_2.getStr1Column(), str1);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, Tbltbl_2 item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(Tbltbl_2.getIdColumn(), item.id);
            suc.Add(Tbltbl_2.getStr1Column(), item.str1);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tbltbl_2.getFormatTableName());
            string sql = sum.getUpdateSql(suc, sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }

        public static bool Delete(DataCtrlInfo dcf, SqlWhere sw, ref int count, ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tbltbl_2.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
