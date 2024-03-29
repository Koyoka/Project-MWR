using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWInvAuthorizeCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWInvAuthorize> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWInvAuthorize> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInvAuthorize(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWInvAuthorize> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWInvAuthorize> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInvAuthorize(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWInvAuthorize item,ref string errMsg)
        {
            List<TblMWInvAuthorize> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWInvAuthorize item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWInvAuthorize item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.InvAuthId,
                item.TxnNum,
                item.TxnDetailId,
                item.EmpyCode,
                item.EmpyName,
                item.WSCode,
                item.AuthEmpyCode,
                item.AuthEmpyName,
                item.Remark,
                item.SubWeight,
                item.TxnWeight,
                item.DiffWeight,
                item.EntryDate,
                item.CompDate,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int invAuthId,
            string txnNum,
            int txnDetailId,
            string empyCode,
            string empyName,
            string wSCode,
            string authEmpyCode,
            string authEmpyName,
            string remark,
            decimal subWeight,
            decimal txnWeight,
            decimal diffWeight,
            DateTime entryDate,
            DateTime compDate,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
            sum.Add(TblMWInvAuthorize.getInvAuthIdColumn(), invAuthId);
            sum.Add(TblMWInvAuthorize.getTxnNumColumn(), txnNum);
            sum.Add(TblMWInvAuthorize.getTxnDetailIdColumn(), txnDetailId);
            sum.Add(TblMWInvAuthorize.getEmpyCodeColumn(), empyCode);
            sum.Add(TblMWInvAuthorize.getEmpyNameColumn(), empyName);
            sum.Add(TblMWInvAuthorize.getWSCodeColumn(), wSCode);
            sum.Add(TblMWInvAuthorize.getAuthEmpyCodeColumn(), authEmpyCode);
            sum.Add(TblMWInvAuthorize.getAuthEmpyNameColumn(), authEmpyName);
            sum.Add(TblMWInvAuthorize.getRemarkColumn(), remark);
            sum.Add(TblMWInvAuthorize.getSubWeightColumn(), subWeight);
            sum.Add(TblMWInvAuthorize.getTxnWeightColumn(), txnWeight);
            sum.Add(TblMWInvAuthorize.getDiffWeightColumn(), diffWeight);
            sum.Add(TblMWInvAuthorize.getEntryDateColumn(), entryDate);
            sum.Add(TblMWInvAuthorize.getCompDateColumn(), compDate);
            sum.Add(TblMWInvAuthorize.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInvAuthorize item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWInvAuthorize.getInvAuthIdColumn(), item.InvAuthId);
            suc.Add(TblMWInvAuthorize.getTxnNumColumn(), item.TxnNum);
            suc.Add(TblMWInvAuthorize.getTxnDetailIdColumn(), item.TxnDetailId);
            suc.Add(TblMWInvAuthorize.getEmpyCodeColumn(), item.EmpyCode);
            suc.Add(TblMWInvAuthorize.getEmpyNameColumn(), item.EmpyName);
            suc.Add(TblMWInvAuthorize.getWSCodeColumn(), item.WSCode);
            suc.Add(TblMWInvAuthorize.getAuthEmpyCodeColumn(), item.AuthEmpyCode);
            suc.Add(TblMWInvAuthorize.getAuthEmpyNameColumn(), item.AuthEmpyName);
            suc.Add(TblMWInvAuthorize.getRemarkColumn(), item.Remark);
            suc.Add(TblMWInvAuthorize.getSubWeightColumn(), item.SubWeight);
            suc.Add(TblMWInvAuthorize.getTxnWeightColumn(), item.TxnWeight);
            suc.Add(TblMWInvAuthorize.getDiffWeightColumn(), item.DiffWeight);
            suc.Add(TblMWInvAuthorize.getEntryDateColumn(), item.EntryDate);
            suc.Add(TblMWInvAuthorize.getCompDateColumn(), item.CompDate);
            suc.Add(TblMWInvAuthorize.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInvAuthorize item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
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
            sum.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
