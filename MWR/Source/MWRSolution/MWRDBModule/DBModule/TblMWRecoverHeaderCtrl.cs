using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWRecoverHeaderCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWRecoverHeader> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWRecoverHeader> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWRecoverHeader.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWRecoverHeader(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWRecoverHeader> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWRecoverHeader> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWRecoverHeader.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWRecoverHeader(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWRecoverHeader item,ref string errMsg)
        {
            List<TblMWRecoverHeader> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWRecoverHeader item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWRecoverHeader item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.RecoHeaderId,
                item.RecoNum,
                item.CarCode,
                item.DriverCode,
                item.InspectorCode,
                item.CrateQty,
                item.RecoWSCode,
                item.RecoEmpyCode,
                item.StratDate,
                item.EndDate,
                item.OperateType,
                item.Status,
                item.CarDisId,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int recoHeaderId,
            string recoNum,
            string carCode,
            string driverCode,
            string inspectorCode,
            int crateQty,
            string recoWSCode,
            string recoEmpyCode,
            DateTime stratDate,
            DateTime endDate,
            string operateType,
            string status,
            int carDisId,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWRecoverHeader.getFormatTableName());
            sum.Add(TblMWRecoverHeader.getRecoHeaderIdColumn(), recoHeaderId);
            sum.Add(TblMWRecoverHeader.getRecoNumColumn(), recoNum);
            sum.Add(TblMWRecoverHeader.getCarCodeColumn(), carCode);
            sum.Add(TblMWRecoverHeader.getDriverCodeColumn(), driverCode);
            sum.Add(TblMWRecoverHeader.getInspectorCodeColumn(), inspectorCode);
            sum.Add(TblMWRecoverHeader.getCrateQtyColumn(), crateQty);
            sum.Add(TblMWRecoverHeader.getRecoWSCodeColumn(), recoWSCode);
            sum.Add(TblMWRecoverHeader.getRecoEmpyCodeColumn(), recoEmpyCode);
            sum.Add(TblMWRecoverHeader.getStratDateColumn(), stratDate);
            sum.Add(TblMWRecoverHeader.getEndDateColumn(), endDate);
            sum.Add(TblMWRecoverHeader.getOperateTypeColumn(), operateType);
            sum.Add(TblMWRecoverHeader.getStatusColumn(), status);
            sum.Add(TblMWRecoverHeader.getCarDisIdColumn(), carDisId);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWRecoverHeader item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWRecoverHeader.getRecoHeaderIdColumn(), item.RecoHeaderId);
            suc.Add(TblMWRecoverHeader.getRecoNumColumn(), item.RecoNum);
            suc.Add(TblMWRecoverHeader.getCarCodeColumn(), item.CarCode);
            suc.Add(TblMWRecoverHeader.getDriverCodeColumn(), item.DriverCode);
            suc.Add(TblMWRecoverHeader.getInspectorCodeColumn(), item.InspectorCode);
            suc.Add(TblMWRecoverHeader.getCrateQtyColumn(), item.CrateQty);
            suc.Add(TblMWRecoverHeader.getRecoWSCodeColumn(), item.RecoWSCode);
            suc.Add(TblMWRecoverHeader.getRecoEmpyCodeColumn(), item.RecoEmpyCode);
            suc.Add(TblMWRecoverHeader.getStratDateColumn(), item.StratDate);
            suc.Add(TblMWRecoverHeader.getEndDateColumn(), item.EndDate);
            suc.Add(TblMWRecoverHeader.getOperateTypeColumn(), item.OperateType);
            suc.Add(TblMWRecoverHeader.getStatusColumn(), item.Status);
            suc.Add(TblMWRecoverHeader.getCarDisIdColumn(), item.CarDisId);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWRecoverHeader item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
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
            sum.setQueryTableName(TblMWRecoverHeader.getFormatTableName());
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
            sum.setQueryTableName(TblMWRecoverHeader.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
