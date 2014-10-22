using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{
    public class TblarbizcustomerdetailCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<Tblarbizcustomerdetail> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(Tblarbizcustomerdetail.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblarbizcustomerdetail(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<Tblarbizcustomerdetail> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<Tblarbizcustomerdetail> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(Tblarbizcustomerdetail.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblarbizcustomerdetail(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref Tblarbizcustomerdetail item,ref string errMsg)
        {
            List<Tblarbizcustomerdetail> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref Tblarbizcustomerdetail item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, Tblarbizcustomerdetail item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.userId,
                item.companyName,
                item.industry,
                item.address,
                item.phoneNum,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            string userId,
            string companyName,
            string industry,
            string address,
            string phoneNum,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarbizcustomerdetail.getFormatTableName());
            sum.Add(Tblarbizcustomerdetail.getUserIdColumn(), userId);
            sum.Add(Tblarbizcustomerdetail.getCompanyNameColumn(), companyName);
            sum.Add(Tblarbizcustomerdetail.getIndustryColumn(), industry);
            sum.Add(Tblarbizcustomerdetail.getAddressColumn(), address);
            sum.Add(Tblarbizcustomerdetail.getPhoneNumColumn(), phoneNum);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, Tblarbizcustomerdetail item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(Tblarbizcustomerdetail.getUserIdColumn(), item.userId);
            suc.Add(Tblarbizcustomerdetail.getCompanyNameColumn(), item.companyName);
            suc.Add(Tblarbizcustomerdetail.getIndustryColumn(), item.industry);
            suc.Add(Tblarbizcustomerdetail.getAddressColumn(), item.address);
            suc.Add(Tblarbizcustomerdetail.getPhoneNumColumn(), item.phoneNum);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarbizcustomerdetail.getFormatTableName());
            string sql = sum.getUpdateSql(suc, sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }

        public static bool Delete(DataCtrlInfo dcf, SqlWhere sw, ref int count, ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblarbizcustomerdetail.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
