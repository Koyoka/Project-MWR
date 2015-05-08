using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWTxnRecoverHeaderCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWTxnRecoverHeader> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWTxnRecoverHeader> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnRecoverHeader(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWTxnRecoverHeader> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWTxnRecoverHeader> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWTxnRecoverHeader(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWTxnRecoverHeader item,ref string errMsg)
        {
            List<TblMWTxnRecoverHeader> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWTxnRecoverHeader item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWTxnRecoverHeader item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.RecoHeaderId,
                item.TxnNum,
                item.CarCode,
                item.Driver,
                item.DriverCode,
                item.Inspector,
                item.InspectorCode,
                item.RecoMWSCode,
                item.RecoWSCode,
                item.RecoEmpyName,
                item.RecoEmpyCode,
                item.StartDate,
                item.EndDate,
                item.EntryDate,
                item.OperateType,
                item.TotalCrateQty,
                item.TotalSubWeight,
                item.TotalTxnWeight,
                item.CarDisId,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int recoHeaderId,
            string txnNum,
            string carCode,
            string driver,
            string driverCode,
            string inspector,
            string inspectorCode,
            string recoMWSCode,
            string recoWSCode,
            string recoEmpyName,
            string recoEmpyCode,
            DateTime startDate,
            DateTime endDate,
            DateTime entryDate,
            string operateType,
            int totalCrateQty,
            decimal totalSubWeight,
            decimal totalTxnWeight,
            int carDisId,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
            sum.Add(TblMWTxnRecoverHeader.getRecoHeaderIdColumn(), recoHeaderId);
            sum.Add(TblMWTxnRecoverHeader.getTxnNumColumn(), txnNum);
            sum.Add(TblMWTxnRecoverHeader.getCarCodeColumn(), carCode);
            sum.Add(TblMWTxnRecoverHeader.getDriverColumn(), driver);
            sum.Add(TblMWTxnRecoverHeader.getDriverCodeColumn(), driverCode);
            sum.Add(TblMWTxnRecoverHeader.getInspectorColumn(), inspector);
            sum.Add(TblMWTxnRecoverHeader.getInspectorCodeColumn(), inspectorCode);
            sum.Add(TblMWTxnRecoverHeader.getRecoMWSCodeColumn(), recoMWSCode);
            sum.Add(TblMWTxnRecoverHeader.getRecoWSCodeColumn(), recoWSCode);
            sum.Add(TblMWTxnRecoverHeader.getRecoEmpyNameColumn(), recoEmpyName);
            sum.Add(TblMWTxnRecoverHeader.getRecoEmpyCodeColumn(), recoEmpyCode);
            sum.Add(TblMWTxnRecoverHeader.getStartDateColumn(), startDate);
            sum.Add(TblMWTxnRecoverHeader.getEndDateColumn(), endDate);
            sum.Add(TblMWTxnRecoverHeader.getEntryDateColumn(), entryDate);
            sum.Add(TblMWTxnRecoverHeader.getOperateTypeColumn(), operateType);
            sum.Add(TblMWTxnRecoverHeader.getTotalCrateQtyColumn(), totalCrateQty);
            sum.Add(TblMWTxnRecoverHeader.getTotalSubWeightColumn(), totalSubWeight);
            sum.Add(TblMWTxnRecoverHeader.getTotalTxnWeightColumn(), totalTxnWeight);
            sum.Add(TblMWTxnRecoverHeader.getCarDisIdColumn(), carDisId);
            sum.Add(TblMWTxnRecoverHeader.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnRecoverHeader item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWTxnRecoverHeader.getRecoHeaderIdColumn(), item.RecoHeaderId);
            suc.Add(TblMWTxnRecoverHeader.getTxnNumColumn(), item.TxnNum);
            suc.Add(TblMWTxnRecoverHeader.getCarCodeColumn(), item.CarCode);
            suc.Add(TblMWTxnRecoverHeader.getDriverColumn(), item.Driver);
            suc.Add(TblMWTxnRecoverHeader.getDriverCodeColumn(), item.DriverCode);
            suc.Add(TblMWTxnRecoverHeader.getInspectorColumn(), item.Inspector);
            suc.Add(TblMWTxnRecoverHeader.getInspectorCodeColumn(), item.InspectorCode);
            suc.Add(TblMWTxnRecoverHeader.getRecoMWSCodeColumn(), item.RecoMWSCode);
            suc.Add(TblMWTxnRecoverHeader.getRecoWSCodeColumn(), item.RecoWSCode);
            suc.Add(TblMWTxnRecoverHeader.getRecoEmpyNameColumn(), item.RecoEmpyName);
            suc.Add(TblMWTxnRecoverHeader.getRecoEmpyCodeColumn(), item.RecoEmpyCode);
            suc.Add(TblMWTxnRecoverHeader.getStartDateColumn(), item.StartDate);
            suc.Add(TblMWTxnRecoverHeader.getEndDateColumn(), item.EndDate);
            suc.Add(TblMWTxnRecoverHeader.getEntryDateColumn(), item.EntryDate);
            suc.Add(TblMWTxnRecoverHeader.getOperateTypeColumn(), item.OperateType);
            suc.Add(TblMWTxnRecoverHeader.getTotalCrateQtyColumn(), item.TotalCrateQty);
            suc.Add(TblMWTxnRecoverHeader.getTotalSubWeightColumn(), item.TotalSubWeight);
            suc.Add(TblMWTxnRecoverHeader.getTotalTxnWeightColumn(), item.TotalTxnWeight);
            suc.Add(TblMWTxnRecoverHeader.getCarDisIdColumn(), item.CarDisId);
            suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWTxnRecoverHeader item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
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
            sum.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
