//using System;
//using System.Collections.Generic;
//using System.Text;
//using ComLib;
//using ComLib.db;

//namespace YRKJ.MWR
//{
//    public class TblMWCarCtrl : BaseDataCtrl
//    {
//        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<TblMWCar> itemList, ref string errMsg)
//        {
//            SqlQueryMng sqm = new SqlQueryMng();
//            sqm.Condition.Where.AddWhere(sw);
//            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
//        }
 
//        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<TblMWCar> itemList,ref string errMsg)
//        {
//            try
//            {
//                sqm.setQueryTableName(TblMWCar.getFormatTableName());
//                string sql = sqm.getPageSql(page, pageSize);
//                SqlCommonFn.DebugLog(sql);
//                itemList = SqlDBMng.getInstance().query(sql, new TblMWCar(), sqm.getParamsArray());
//                if (itemList.Count != 0)
//                {
//                    dcf.RowCount = itemList[0].TEM_COLUMN_COUNT;
//                    dcf.PageCount = ComFn.getPageCount(pageSize, dcf.RowCount);
//                }
//            }
//            catch (Exception e)
//            {
//                errMsg = e.Message;
//                return false;
//            }
//            return true ;
//        }

//        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<TblMWCar> itemList,ref string errMsg)
//        {
//            SqlQueryMng sqm = new SqlQueryMng();
//            sqm.Condition.Where.AddWhere(sw);
//            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
//        }

//        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<TblMWCar> itemList,ref string errMsg)
//        {
          
//            try
//            {
//                sqm.setQueryTableName(TblMWCar.getFormatTableName());
//                string sql = sqm.getSql();
//                SqlCommonFn.DebugLog(sql);
//                itemList = SqlDBMng.getInstance().query(sql, new TblMWCar(), sqm.getParamsArray());
//            }
//            catch (Exception e)
//            {
//                errMsg = e.Message;
//                return false;
//            }
//            return true;
//        }

//        //public static bool QueryMoreJoin<T>(DataCtrlInfo dcf, SqlQueryMng sqm, SqlJoinOn<T> sjm, ref List<TblMWCar> itemList, ref string errMsg) where T : BaseDataModule,new()
//        //{

//        //    return false;
//        //}

//        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref TblMWCar item,ref string errMsg)
//        {
//            List<TblMWCar> itemList = null;
//            if (!QueryMore(dcf, sqm, ref itemList, ref errMsg))
//            {
//                return false;
//            }

//            if (itemList.Count > 0)
//            {
//                item = itemList[0];
//            }
//            else
//            {
//                item = null;
//            }

//            return true;
//        }

//        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref TblMWCar item, ref string errMsg)
//        {
//            SqlQueryMng sqm = new SqlQueryMng();
//            sqm.Condition.Where.AddWhere(sw);
//            return QueryOne(dcf, sqm, ref item, ref errMsg);
//        }

//        public static bool Insert(DataCtrlInfo dcf, TblMWCar item, ref int count,ref string errMsg)
//        {
//            return Insert(dcf,
//                item.CarCode,
//                item.Desc,
//                    ref count,
//                    ref errMsg
//                    );
//        }

//        public static bool Insert(DataCtrlInfo dcf,
//            string carCode,
//            string desc,
//                ref int _count,
//                ref string _errMsg
//                )
//        {
//            SqlUpdateMng sum = new SqlUpdateMng();
//            sum.setQueryTableName(TblMWCar.getFormatTableName());
//            sum.Add(TblMWCar.getCarCodeColumn(), carCode);
//            sum.Add(TblMWCar.getDescColumn(), desc);
//            string sql = sum.getInsertSql();
//            if (sql == null)
//            {
//                _errMsg = sum.ErrMsg;
//                return false;
//            }
//            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
//        }

//        public static bool Update(DataCtrlInfo dcf, TblMWCar item, SqlWhere sw,ref int count,ref string errMsg)
//        {
//            SqlUpdateColumn suc = new SqlUpdateColumn();
//            suc.Add(TblMWCar.getCarCodeColumn(), item.CarCode);
//            suc.Add(TblMWCar.getDescColumn(), item.Desc);
//            return Update(dcf, suc, sw, ref count, ref errMsg);
//        }

//        public static bool Update(DataCtrlInfo dcf, TblMWCar item, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
//        {
//            if (suc.Columns != null)
//                 SetUpdateColumnValue(suc, item);
//            return Update(dcf, suc, sw, ref count, ref errMsg);
//        }

//        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
//        {
//            SqlUpdateMng sum = new SqlUpdateMng();
//            sum.setQueryTableName(TblMWCar.getFormatTableName());
//            string sql = sum.getUpdateSql(suc, sw);
//            if (sql == null)
//            {
//                errMsg = sum.ErrMsg;
//                return false;
//            }
//            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
//        }

//        public static bool Delete(DataCtrlInfo dcf, SqlWhere sw, ref int count, ref string errMsg)
//        {
//            SqlUpdateMng sum = new SqlUpdateMng();
//            sum.setQueryTableName(TblMWCar.getFormatTableName());
//            string sql = sum.getDeleteSql(sw);
//            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
//        }




//    }
//}
