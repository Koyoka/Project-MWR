using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{
    public class TblarusertargetkeyCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<Tblarusertargetkey> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(Tblarusertargetkey.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblarusertargetkey(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<Tblarusertargetkey> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<Tblarusertargetkey> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(Tblarusertargetkey.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblarusertargetkey(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref Tblarusertargetkey item,ref string errMsg)
        {
            List<Tblarusertargetkey> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref Tblarusertargetkey item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, Tblarusertargetkey item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.userId,
                item.cloudAKey,
                item.cloudSKey,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            string userId,
            string cloudAKey,
            string cloudSKey,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarusertargetkey.getFormatTableName());
            sum.Add(Tblarusertargetkey.getUserIdColumn(), userId);
            sum.Add(Tblarusertargetkey.getCloudAKeyColumn(), cloudAKey);
            sum.Add(Tblarusertargetkey.getCloudSKeyColumn(), cloudSKey);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, Tblarusertargetkey item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(Tblarusertargetkey.getIdColumn(), item.id);
            suc.Add(Tblarusertargetkey.getUserIdColumn(), item.userId);
            suc.Add(Tblarusertargetkey.getCloudAKeyColumn(), item.cloudAKey);
            suc.Add(Tblarusertargetkey.getCloudSKeyColumn(), item.cloudSKey);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarusertargetkey.getFormatTableName());
            string sql = sum.getUpdateSql(suc, sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }

        public static bool Delete(DataCtrlInfo dcf, SqlWhere sw, ref int count, ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarusertargetkey.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
