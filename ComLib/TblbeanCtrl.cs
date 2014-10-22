using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;


namespace ComLib
{
    public class TblbeanCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<Tblbean> itemList,ref string errMsg)
        {
            try
            {
                sqm.setQueryTableName(Tblbean.getFormatTableName());
                String sql = sqm.getPageSql(page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblbean(), sqm.getParamsArray());
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

        public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,ref List<Tblbean> itemList,ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryMore(dcf, sqm,ref itemList,ref errMsg);
        }

        public static bool QueryMore(DataCtrlInfo dcf, SqlQueryMng sqm,ref List<Tblbean> itemList,ref string errMsg)
        {
          
            try
            {
                sqm.setQueryTableName(Tblbean.getFormatTableName());
                String sql = sqm.getSql();
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new Tblbean(), sqm.getParamsArray());
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true;
        }

        public static bool QueryOne(DataCtrlInfo dcf, SqlQueryMng sqm,ref Tblbean item,ref string errMsg)
        {
            List<Tblbean> itemList = null;
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

        public static bool QueryOne(DataCtrlInfo dcf, SqlWhere sw,ref Tblbean item, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryOne(dcf, sqm, ref item, ref errMsg);
        }

        public static bool Insert(DataCtrlInfo dcf, Tblbean item, ref int count,ref string errMsg)
        {
            return Insert(dcf,
                    item.colNull,
                    item.colStr,
                    item.colInt,
                    item.colDT,
                    item.colFloat,
                    item.colBit,
                    item.colText,
                    item.colNotNull,
                    item.colStr2,
                    ref count,
                    ref errMsg
                    );
        }


        public static bool Insert(DataCtrlInfo dcf,
                String colNull,
                String colStr,
                int colInt,
                String colDT,
                float colFloat,
                bool colBit,
                String colText,
                String colNotNull,
                String colStr2,
                ref int _count,
                ref string _errMsg
                )
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblbean.getFormatTableName());
            sum.Add(Tblbean.getColNullColumn(), colNull);
            sum.Add(Tblbean.getColStrColumn(), colStr);
            sum.Add(Tblbean.getColIntColumn(), colInt);
            sum.Add(Tblbean.getColDTColumn(), colDT);
            sum.Add(Tblbean.getColFloatColumn(), colFloat);
            sum.Add(Tblbean.getColBitColumn(), colBit);
            sum.Add(Tblbean.getColTextColumn(), colText);
            sum.Add(Tblbean.getColNotNullColumn(), colNotNull);
            sum.Add(Tblbean.getColStr2Column(), colStr2);
            string sql = sum.getInsertSql();

            if (sql == null)
            {
                return false;
            }
            return doUpdateCtrl(dcf, sql,ref _count,ref _errMsg);
        }


        public static bool Update(DataCtrlInfo dcf, Tblbean item, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(Tblbean.getIdColumn(), item.id);
            suc.Add(Tblbean.getColNullColumn(), item.colNull);
            suc.Add(Tblbean.getColStrColumn(), item.colStr);
            suc.Add(Tblbean.getColIntColumn(), item.colInt);
            suc.Add(Tblbean.getColDTColumn(), item.colDT);
            suc.Add(Tblbean.getColFloatColumn(), item.colFloat);
            suc.Add(Tblbean.getColBitColumn(), item.colBit);
            suc.Add(Tblbean.getColTextColumn(), item.colText);
            suc.Add(Tblbean.getColNotNullColumn(), item.colNotNull);
            suc.Add(Tblbean.getColStr2Column(), item.colStr2);
            return Update(dcf, suc, sw, ref count, ref errMsg);
        }

        public static bool Update(DataCtrlInfo dcf, SqlUpdateColumn suc, SqlWhere sw,ref int count,ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblbean.getFormatTableName());
            String sql = sum.getUpdateSql(suc, sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }


        public static bool Delete(DataCtrlInfo dcf, SqlWhere sw, ref int count, ref string errMsg)
        {
            SqlUpdateMng sum = new SqlUpdateMng();
            sum.setQueryTableName(Tblbean.getFormatTableName());
            String sql = sum.getDeleteSql(sw);
            return doUpdateCtrl(dcf, sql, ref count,ref errMsg);
        }



    }
}
