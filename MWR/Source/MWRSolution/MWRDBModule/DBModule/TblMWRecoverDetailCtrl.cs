using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace MWRDBModule.DBModule
{
    public class TblMWRecoverDetailCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWRecoverDetail> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWRecoverDetail> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWRecoverDetail(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWRecoverDetail> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWRecoverDetail> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWRecoverDetail(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWRecoverDetail item,ref string errMsg)
        {
            List<TblMWRecoverDetail> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWRecoverDetail item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWRecoverDetail item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.RecoDtlId,
                item.RecoHeaderId,
                item.CrateCode,
                item.RecoNum,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.RecoWeight,
                item.RecoDate,
                item.InvAuthId,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int recoDtlId,
            int recoHeaderId,
            string crateCode,
            string recoNum,
            string vendor,
            string vendorCode,
            string waste,
            string wasteCode,
            float recoWeight,
            DateTime recoDate,
            int invAuthId,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
            sum.Add(TblMWRecoverDetail.getRecoDtlIdColumn(), recoDtlId);
            sum.Add(TblMWRecoverDetail.getRecoHeaderIdColumn(), recoHeaderId);
            sum.Add(TblMWRecoverDetail.getCrateCodeColumn(), crateCode);
            sum.Add(TblMWRecoverDetail.getRecoNumColumn(), recoNum);
            sum.Add(TblMWRecoverDetail.getVendorColumn(), vendor);
            sum.Add(TblMWRecoverDetail.getVendorCodeColumn(), vendorCode);
            sum.Add(TblMWRecoverDetail.getWasteColumn(), waste);
            sum.Add(TblMWRecoverDetail.getWasteCodeColumn(), wasteCode);
            sum.Add(TblMWRecoverDetail.getRecoWeightColumn(), recoWeight);
            sum.Add(TblMWRecoverDetail.getRecoDateColumn(), recoDate);
            sum.Add(TblMWRecoverDetail.getInvAuthIdColumn(), invAuthId);
            sum.Add(TblMWRecoverDetail.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWRecoverDetail item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWRecoverDetail.getRecoDtlIdColumn(), item.RecoDtlId);
            suc.Add(TblMWRecoverDetail.getRecoHeaderIdColumn(), item.RecoHeaderId);
            suc.Add(TblMWRecoverDetail.getCrateCodeColumn(), item.CrateCode);
            suc.Add(TblMWRecoverDetail.getRecoNumColumn(), item.RecoNum);
            suc.Add(TblMWRecoverDetail.getVendorColumn(), item.Vendor);
            suc.Add(TblMWRecoverDetail.getVendorCodeColumn(), item.VendorCode);
            suc.Add(TblMWRecoverDetail.getWasteColumn(), item.Waste);
            suc.Add(TblMWRecoverDetail.getWasteCodeColumn(), item.WasteCode);
            suc.Add(TblMWRecoverDetail.getRecoWeightColumn(), item.RecoWeight);
            suc.Add(TblMWRecoverDetail.getRecoDateColumn(), item.RecoDate);
            suc.Add(TblMWRecoverDetail.getInvAuthIdColumn(), item.InvAuthId);
            suc.Add(TblMWRecoverDetail.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWRecoverDetail item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
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
            sum.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
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
            sum.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
