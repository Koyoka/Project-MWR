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

public class TblMWFunctionGroupCtrl extends BaseDataCtrl {

    public static List<TblMWFunctionGroup> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWFunctionGroup> itemList = null;
        try{
            sqm.setQueryTableName(TblMWFunctionGroup.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWFunctionGroup.class,sqm.getParamsArray());
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

    public static List<TblMWFunctionGroup> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWFunctionGroup> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWFunctionGroup> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWFunctionGroup> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWFunctionGroup.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWFunctionGroup.class,sqm.getParamsArray());
    }

    public static List<TblMWFunctionGroup> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWFunctionGroup> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWFunctionGroup QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWFunctionGroup> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWFunctionGroup QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWFunctionGroup item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWFunctionGroup QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWFunctionGroup QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWFunctionGroup item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWFunctionGroup item) {
        return Insert(dcf,
                item.FuncGroupId,
                item.FuncGroupName
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int funcGroupId,
            String funcGroupName
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWFunctionGroup.getFormatTableName());
        sum.Add(TblMWFunctionGroup.getFuncGroupIdColumn(), funcGroupId);
        sum.Add(TblMWFunctionGroup.getFuncGroupNameColumn(), funcGroupName);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWFunctionGroup item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWFunctionGroup.getFuncGroupIdColumn(), item.FuncGroupId);
        suc.Add(TblMWFunctionGroup.getFuncGroupNameColumn(), item.FuncGroupName);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWFunctionGroup.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWFunctionGroup.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
