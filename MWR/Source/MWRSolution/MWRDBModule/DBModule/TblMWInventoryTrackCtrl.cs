using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWInventoryTrackCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWInventoryTrack> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWInventoryTrack> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInventoryTrack(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWInventoryTrack> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWInventoryTrack> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWInventoryTrack(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWInventoryTrack item,ref string errMsg)
        {
            List<TblMWInventoryTrack> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWInventoryTrack item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWInventoryTrack item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.InvTrackRecordId,
                item.PostHeaderId,
                item.CrateCode,
                item.PostNum,
                item.DepotCode,
                item.Source,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.InvWeight,
                item.PostWeight,
                item.PostWSCode,
                item.PostEmpyCode,
                item.ReceiveDate,
                item.PostDate,
                item.Status,
                item.InvRecordId,
                item.InvAuthId,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int invTrackRecordId,
            int postHeaderId,
            string crateCode,
            string postNum,
            string depotCode,
            string source,
            string vendor,
            string vendorCode,
            string waste,
            string wasteCode,
            float invWeight,
            float postWeight,
            string postWSCode,
            string postEmpyCode,
            DateTime receiveDate,
            DateTime postDate,
            string status,
            int invRecordId,
            int invAuthId,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
            sum.Add(TblMWInventoryTrack.getInvTrackRecordIdColumn(), invTrackRecordId);
            sum.Add(TblMWInventoryTrack.getPostHeaderIdColumn(), postHeaderId);
            sum.Add(TblMWInventoryTrack.getCrateCodeColumn(), crateCode);
            sum.Add(TblMWInventoryTrack.getPostNumColumn(), postNum);
            sum.Add(TblMWInventoryTrack.getDepotCodeColumn(), depotCode);
            sum.Add(TblMWInventoryTrack.getSourceColumn(), source);
            sum.Add(TblMWInventoryTrack.getVendorColumn(), vendor);
            sum.Add(TblMWInventoryTrack.getVendorCodeColumn(), vendorCode);
            sum.Add(TblMWInventoryTrack.getWasteColumn(), waste);
            sum.Add(TblMWInventoryTrack.getWasteCodeColumn(), wasteCode);
            sum.Add(TblMWInventoryTrack.getInvWeightColumn(), invWeight);
            sum.Add(TblMWInventoryTrack.getPostWeightColumn(), postWeight);
            sum.Add(TblMWInventoryTrack.getPostWSCodeColumn(), postWSCode);
            sum.Add(TblMWInventoryTrack.getPostEmpyCodeColumn(), postEmpyCode);
            sum.Add(TblMWInventoryTrack.getReceiveDateColumn(), receiveDate);
            sum.Add(TblMWInventoryTrack.getPostDateColumn(), postDate);
            sum.Add(TblMWInventoryTrack.getStatusColumn(), status);
            sum.Add(TblMWInventoryTrack.getInvRecordIdColumn(), invRecordId);
            sum.Add(TblMWInventoryTrack.getInvAuthIdColumn(), invAuthId);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInventoryTrack item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWInventoryTrack.getInvTrackRecordIdColumn(), item.InvTrackRecordId);
            suc.Add(TblMWInventoryTrack.getPostHeaderIdColumn(), item.PostHeaderId);
            suc.Add(TblMWInventoryTrack.getCrateCodeColumn(), item.CrateCode);
            suc.Add(TblMWInventoryTrack.getPostNumColumn(), item.PostNum);
            suc.Add(TblMWInventoryTrack.getDepotCodeColumn(), item.DepotCode);
            suc.Add(TblMWInventoryTrack.getSourceColumn(), item.Source);
            suc.Add(TblMWInventoryTrack.getVendorColumn(), item.Vendor);
            suc.Add(TblMWInventoryTrack.getVendorCodeColumn(), item.VendorCode);
            suc.Add(TblMWInventoryTrack.getWasteColumn(), item.Waste);
            suc.Add(TblMWInventoryTrack.getWasteCodeColumn(), item.WasteCode);
            suc.Add(TblMWInventoryTrack.getInvWeightColumn(), item.InvWeight);
            suc.Add(TblMWInventoryTrack.getPostWeightColumn(), item.PostWeight);
            suc.Add(TblMWInventoryTrack.getPostWSCodeColumn(), item.PostWSCode);
            suc.Add(TblMWInventoryTrack.getPostEmpyCodeColumn(), item.PostEmpyCode);
            suc.Add(TblMWInventoryTrack.getReceiveDateColumn(), item.ReceiveDate);
            suc.Add(TblMWInventoryTrack.getPostDateColumn(), item.PostDate);
            suc.Add(TblMWInventoryTrack.getStatusColumn(), item.Status);
            suc.Add(TblMWInventoryTrack.getInvRecordIdColumn(), item.InvRecordId);
            suc.Add(TblMWInventoryTrack.getInvAuthIdColumn(), item.InvAuthId);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWInventoryTrack item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
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
            sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
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
            sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
