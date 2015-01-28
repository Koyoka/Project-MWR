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

public class TblMWEmployCtrl extends BaseDataCtrl {

    public static List<TblMWEmploy> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWEmploy> itemList = null;
        try{
            sqm.setQueryTableName(TblMWEmploy.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWEmploy.class,sqm.getParamsArray());
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

    public static List<TblMWEmploy> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWEmploy> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWEmploy> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWEmploy> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWEmploy.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWEmploy.class,sqm.getParamsArray());
    }

    public static List<TblMWEmploy> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWEmploy> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWEmploy QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWEmploy> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWEmploy QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWEmploy item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWEmploy QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWEmploy QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWEmploy item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWEmploy item) {
        return Insert(dcf,
                item.EmpyCode,
                item.EmpyName,
                item.UserGroupId,
                item.EmpyType,
                item.UserName,
                item.Password
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            String empyCode,
            String empyName,
            int userGroupId,
            String empyType,
            String userName,
            String password
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWEmploy.getFormatTableName());
        sum.Add(TblMWEmploy.getEmpyCodeColumn(), empyCode);
        sum.Add(TblMWEmploy.getEmpyNameColumn(), empyName);
        sum.Add(TblMWEmploy.getUserGroupIdColumn(), userGroupId);
        sum.Add(TblMWEmploy.getEmpyTypeColumn(), empyType);
        sum.Add(TblMWEmploy.getUserNameColumn(), userName);
        sum.Add(TblMWEmploy.getPasswordColumn(), password);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWEmploy item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWEmploy.getEmpyCodeColumn(), item.EmpyCode);
        suc.Add(TblMWEmploy.getEmpyNameColumn(), item.EmpyName);
        suc.Add(TblMWEmploy.getUserGroupIdColumn(), item.UserGroupId);
        suc.Add(TblMWEmploy.getEmpyTypeColumn(), item.EmpyType);
        suc.Add(TblMWEmploy.getUserNameColumn(), item.UserName);
        suc.Add(TblMWEmploy.getPasswordColumn(), item.Password);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWEmploy.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWEmploy.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
