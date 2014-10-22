using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{
    public class TblarcustomerCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<Tblarcustomer> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(Tblarcustomer.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblarcustomer(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<Tblarcustomer> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<Tblarcustomer> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(Tblarcustomer.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblarcustomer(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref Tblarcustomer item,ref string errMsg)
        {
            List<Tblarcustomer> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref Tblarcustomer item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, Tblarcustomer item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.userName,
                item.password,
                item.nickName,
                item.createDate,
                item.userType,
                item.sex,
                item.age,
                item.interest,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            string userName,
            string password,
            string nickName,
            DateTime createDate,
            string userType,
            string sex,
            int age,
            string interest,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarcustomer.getFormatTableName());
            sum.Add(Tblarcustomer.getUserNameColumn(), userName);
            sum.Add(Tblarcustomer.getPasswordColumn(), password);
            sum.Add(Tblarcustomer.getNickNameColumn(), nickName);
            sum.Add(Tblarcustomer.getCreateDateColumn(), createDate);
            sum.Add(Tblarcustomer.getUserTypeColumn(), userType);
            sum.Add(Tblarcustomer.getSexColumn(), sex);
            sum.Add(Tblarcustomer.getAgeColumn(), age);
            sum.Add(Tblarcustomer.getInterestColumn(), interest);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, Tblarcustomer item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(Tblarcustomer.getUserNameColumn(), item.userName);
            suc.Add(Tblarcustomer.getPasswordColumn(), item.password);
            suc.Add(Tblarcustomer.getNickNameColumn(), item.nickName);
            suc.Add(Tblarcustomer.getCreateDateColumn(), item.createDate);
            suc.Add(Tblarcustomer.getUserTypeColumn(), item.userType);
            suc.Add(Tblarcustomer.getSexColumn(), item.sex);
            suc.Add(Tblarcustomer.getAgeColumn(), item.age);
            suc.Add(Tblarcustomer.getInterestColumn(), item.interest);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarcustomer.getFormatTableName());
            string sql = sum.getUpdateSql(suc, sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }

        public static bool Delete(DataCtrlInfo dcf, SqlWhere sw, ref int count, ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarcustomer.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
