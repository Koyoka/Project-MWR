using System;
using System.Collections.Generic;
using System.Text;
using ComLib;
using ComLib.db;

namespace YRKJ.MWR
{
    public class TblMWCarDispatchCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWCarDispatch> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWCarDispatch> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
                string sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWCarDispatch(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWCarDispatch> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWCarDispatch> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
                string sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new TblMWCarDispatch(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWCarDispatch item,ref string errMsg)
        {
            List<TblMWCarDispatch> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWCarDispatch item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, TblMWCarDispatch item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                item.CarDisId,
                item.CarCode,
                item.Driver,
                item.DriverCode,
                item.Inspector,
                item.InspectorCode,
                item.RecoMWSCode,
                item.OutDate,
                item.InDate,
                item.Status,
                    ref count,
                    ref errMsg
                    );
        }

        public static bool Insert(DataCtrlInfo dcf,
            int carDisId,
            string carCode,
            string driver,
            string driverCode,
            string inspector,
            string inspectorCode,
            string recoMWSCode,
            DateTime outDate,
            DateTime inDate,
            string status,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWCarDispatch.getFormatTableName());
            sum.Add(TblMWCarDispatch.getCarDisIdColumn(), carDisId);
            sum.Add(TblMWCarDispatch.getCarCodeColumn(), carCode);
            sum.Add(TblMWCarDispatch.getDriverColumn(), driver);
            sum.Add(TblMWCarDispatch.getDriverCodeColumn(), driverCode);
            sum.Add(TblMWCarDispatch.getInspectorColumn(), inspector);
            sum.Add(TblMWCarDispatch.getInspectorCodeColumn(), inspectorCode);
            sum.Add(TblMWCarDispatch.getRecoMWSCodeColumn(), recoMWSCode);
            sum.Add(TblMWCarDispatch.getOutDateColumn(), outDate);
            sum.Add(TblMWCarDispatch.getInDateColumn(), inDate);
            sum.Add(TblMWCarDispatch.getStatusColumn(), status);
            string sql = sum.getInsertSql();
            if (sql == null)
            {
                _errMsg = sum.ErrMsg;
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWCarDispatch item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCarDispatch.getCarDisIdColumn(), item.CarDisId);
            suc.Add(TblMWCarDispatch.getCarCodeColumn(), item.CarCode);
            suc.Add(TblMWCarDispatch.getDriverColumn(), item.Driver);
            suc.Add(TblMWCarDispatch.getDriverCodeColumn(), item.DriverCode);
            suc.Add(TblMWCarDispatch.getInspectorColumn(), item.Inspector);
            suc.Add(TblMWCarDispatch.getInspectorCodeColumn(), item.InspectorCode);
            suc.Add(TblMWCarDispatch.getRecoMWSCodeColumn(), item.RecoMWSCode);
            suc.Add(TblMWCarDispatch.getOutDateColumn(), item.OutDate);
            suc.Add(TblMWCarDispatch.getInDateColumn(), item.InDate);
            suc.Add(TblMWCarDispatch.getStatusColumn(), item.Status);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, TblMWCarDispatch item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            if (suc.Columns != null)
                 SetUpdateColumnValue(suc, item);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(TblMWCarDispatch.getFormatTableName());
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
            sum.setQueryTableName(TblMWCarDispatch.getFormatTableName());
            string sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }




    }
}
