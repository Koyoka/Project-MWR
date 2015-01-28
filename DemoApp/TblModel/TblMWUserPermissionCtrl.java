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

public class TblMWUserPermissionCtrl extends BaseDataCtrl {

    public static List<TblMWUserPermission> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWUserPermission> itemList = null;
        try{
            sqm.setQueryTableName(TblMWUserPermission.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWUserPermission.class,sqm.getParamsArray());
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

    public static List<TblMWUserPermission> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWUserPermission> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWUserPermission> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWUserPermission> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWUserPermission.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWUserPermission.class,sqm.getParamsArray());
    }

    public static List<TblMWUserPermission> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWUserPermission> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWUserPermission QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWUserPermission> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWUserPermission QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWUserPermission item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWUserPermission QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWUserPermission QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWUserPermission item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWUserPermission item) {
        return Insert(dcf,
                item.id,
                item.UserGroupId,
                item.FuncGroupId
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int id,
            int userGroupId,
            int funcGroupId
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWUserPermission.getFormatTableName());
        sum.Add(TblMWUserPermission.getIdColumn(), id);
        sum.Add(TblMWUserPermission.getUserGroupIdColumn(), userGroupId);
        sum.Add(TblMWUserPermission.getFuncGroupIdColumn(), funcGroupId);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWUserPermission item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWUserPermission.getIdColumn(), item.id);
        suc.Add(TblMWUserPermission.getUserGroupIdColumn(), item.UserGroupId);
        suc.Add(TblMWUserPermission.getFuncGroupIdColumn(), item.FuncGroupId);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWUserPermission.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWUserPermission.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
