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

public class TblMWInvAuthorizeAttachCtrl extends BaseDataCtrl {

    public static List<TblMWInvAuthorizeAttach> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWInvAuthorizeAttach> itemList = null;
        try{
            sqm.setQueryTableName(TblMWInvAuthorizeAttach.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWInvAuthorizeAttach.class,sqm.getParamsArray());
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

    public static List<TblMWInvAuthorizeAttach> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWInvAuthorizeAttach> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWInvAuthorizeAttach> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWInvAuthorizeAttach> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWInvAuthorizeAttach.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWInvAuthorizeAttach.class,sqm.getParamsArray());
    }

    public static List<TblMWInvAuthorizeAttach> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWInvAuthorizeAttach> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWInvAuthorizeAttach QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWInvAuthorizeAttach> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWInvAuthorizeAttach QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWInvAuthorizeAttach item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWInvAuthorizeAttach QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWInvAuthorizeAttach QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWInvAuthorizeAttach item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWInvAuthorizeAttach item) {
        return Insert(dcf,
                item.InvAttachId,
                item.InvAuthId,
                item.Path
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int invAttachId,
            int invAuthId,
            String path
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInvAuthorizeAttach.getFormatTableName());
        sum.Add(TblMWInvAuthorizeAttach.getInvAttachIdColumn(), invAttachId);
        sum.Add(TblMWInvAuthorizeAttach.getInvAuthIdColumn(), invAuthId);
        sum.Add(TblMWInvAuthorizeAttach.getPathColumn(), path);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWInvAuthorizeAttach item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWInvAuthorizeAttach.getInvAttachIdColumn(), item.InvAttachId);
        suc.Add(TblMWInvAuthorizeAttach.getInvAuthIdColumn(), item.InvAuthId);
        suc.Add(TblMWInvAuthorizeAttach.getPathColumn(), item.Path);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInvAuthorizeAttach.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInvAuthorizeAttach.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
