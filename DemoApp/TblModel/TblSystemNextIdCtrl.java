package com.yrkj.ar.bean;
import java.util.List;

import com.yrkj.lib.ComFn;
import com.yrkj.lib.db.BaseDataCtrl;
import com.yrkj.lib.db.DataCtrlInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlDBMng;
import com.yrkj.lib.db.SqlQueryMng;
import com.yrkj.lib.db.SqlUpdateColumn;
import com.yrkj.lib.db.SqlUpdateMng;
import com.yrkj.lib.db.SqlWhere;

public class TblSystemNextIdCtrl extends BaseDataCtrl {

    public static List<TblSystemNextId> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblSystemNextId> itemList = null;
        try{
            sqm.setQueryTableName(TblSystemNextId.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblSystemNextId.class,sqm.getParamsArray());
            if(itemList.size() != 0){
                dcf.RowCount = itemList.get(0).TEM_COLUMN_COUNT;
                dcf.PageCount = ComFn.getPageCount(pageSize, dcf.RowCount);
            }
            dcf.set(true, "");
        }catch (Exception e) {
            dcf.set(false,e.getMessage());
        }
        return  itemList;
    }

    public static List<TblSystemNextId> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblSystemNextId> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblSystemNextId> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblSystemNextId> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblSystemNextId.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblSystemNextId.class,sqm.getParamsArray());
    }

    public static List<TblSystemNextId> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblSystemNextId> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblSystemNextId QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblSystemNextId> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblSystemNextId QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblSystemNextId item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblSystemNextId QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblSystemNextId QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblSystemNextId item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblSystemNextId item) {
        return Insert(dcf,
                item.IdName,
                item.MinValue,
                item.Increment,
                item.MaxValue,
                item.IdValue
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            String idName,
            int minValue,
            int increment,
            int maxValue,
            int idValue
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSystemNextId.getFormatTableName());
        sum.Add(TblSystemNextId.getIdNameColumn(), idName);
        sum.Add(TblSystemNextId.getMinValueColumn(), minValue);
        sum.Add(TblSystemNextId.getIncrementColumn(), increment);
        sum.Add(TblSystemNextId.getMaxValueColumn(), maxValue);
        sum.Add(TblSystemNextId.getIdValueColumn(), idValue);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblSystemNextId item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblSystemNextId.getIdNameColumn(), item.IdName);
        suc.Add(TblSystemNextId.getMinValueColumn(), item.MinValue);
        suc.Add(TblSystemNextId.getIncrementColumn(), item.Increment);
        suc.Add(TblSystemNextId.getMaxValueColumn(), item.MaxValue);
        suc.Add(TblSystemNextId.getIdValueColumn(), item.IdValue);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSystemNextId.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSystemNextId.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
