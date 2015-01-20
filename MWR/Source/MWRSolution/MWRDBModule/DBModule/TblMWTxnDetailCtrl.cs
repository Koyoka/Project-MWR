using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWTxnDetailCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWTxnDetail> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWTxnDetail> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWTxnDetail.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnDetail(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWTxnDetail> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWTxnDetail> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWTxnDetail.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnDetail(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWTxnDetail item,ref string errMsg)
        {
            List<TblMWTxnDetail> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWTxnDetail item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWTxnDetail item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.TxnDetailId,
                item.TxnType,
                item.TxnNum,
                item.WSCode,
                item.EmpyName,
                item.EmpyCode,
                item.CrateCode,
                item.Vendor,
                item.Waste,
                item.SubWeight,
                item.TxnWeight,
                item.InvRecordId,
                item.InvAuthId,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int txnDetailId,
            string txnType,
            string txnNum,
            string wSCode,
            string empyName,
            string empyCode,
            string crateCode,
            string vendor,
            string waste,
            float subWeight,
            float txnWeight,
            int invRecordId,
            int invAuthId,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWTxnDetail.getFormatTableName());
            sum.Add(TblMWTxnDetail.getTxnDetailIdColumn(), txnDetailId);
            sum.Add(TblMWTxnDetail.getTxnTypeColumn(), txnType);
            sum.Add(TblMWTxnDetail.getTxnNumColumn(), txnNum);
            sum.Add(TblMWTxnDetail.getWSCodeColumn(), wSCode);
            sum.Add(TblMWTxnDetail.getEmpyNameColumn(), empyName);
            sum.Add(TblMWTxnDetail.getEmpyCodeColumn(), empyCode);
            sum.Add(TblMWTxnDetail.getCrateCodeColumn(), crateCode);
            sum.Add(TblMWTxnDetail.getVendorColumn(), vendor);
            sum.Add(TblMWTxnDetail.getWasteColumn(), waste);
            sum.Add(TblMWTxnDetail.getSubWeightColumn(), subWeight);
            sum.Add(TblMWTxnDetail.getTxnWeightColumn(), txnWeight);
            sum.Add(TblMWTxnDetail.getInvRecordIdColumn(), invRecordId);
            sum.Add(TblMWTxnDetail.getInvAuthIdColumn(), invAuthId);
            sum.Add(TblMWTxnDetail.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnDetail item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWTxnDetail.getTxnDetailIdColumn(), item.TxnDetailId);
            suc.Add(TblMWTxnDetail.getTxnTypeColumn(), item.TxnType);
            suc.Add(TblMWTxnDetail.getTxnNumColumn(), item.TxnNum);
            suc.Add(TblMWTxnDetail.getWSCodeColumn(), item.WSCode);
            suc.Add(TblMWTxnDetail.getEmpyNameColumn(), item.EmpyName);
            suc.Add(TblMWTxnDetail.getEmpyCodeColumn(), item.EmpyCode);
            suc.Add(TblMWTxnDetail.getCrateCodeColumn(), item.CrateCode);
            suc.Add(TblMWTxnDetail.getVendorColumn(), item.Vendor);
            suc.Add(TblMWTxnDetail.getWasteColumn(), item.Waste);
            suc.Add(TblMWTxnDetail.getSubWeightColumn(), item.SubWeight);
            suc.Add(TblMWTxnDetail.getTxnWeightColumn(), item.TxnWeight);
            suc.Add(TblMWTxnDetail.getInvRecordIdColumn(), item.InvRecordId);
            suc.Add(TblMWTxnDetail.getInvAuthIdColumn(), item.InvAuthId);
            suc.Add(TblMWTxnDetail.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnDetail item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
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
            sum.setQueryTableName(TblMWTxnDetail.getFormatTableName());
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
            sum.setQueryTableName(TblMWTxnDetail.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
