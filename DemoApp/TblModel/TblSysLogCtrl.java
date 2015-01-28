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

public class TblSysLogCtrl extends BaseDataCtrl {

    public static List<TblSysLog> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblSysLog> itemList = null;
        try{
            sqm.setQueryTableName(TblSysLog.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblSysLog.class,sqm.getParamsArray());
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

    public static List<TblSysLog> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblSysLog> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblSysLog> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblSysLog> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblSysLog.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblSysLog.class,sqm.getParamsArray());
    }

    public static List<TblSysLog> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblSysLog> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblSysLog QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblSysLog> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblSysLog QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblSysLog item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblSysLog QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblSysLog QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblSysLog item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblSysLog item) {
        return Insert(dcf,
                item.LogId,
                item.Desc,
                item.Remark,
                item.LogDate
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int logId,
            String desc,
            String remark,
            String logDate
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSysLog.getFormatTableName());
        sum.Add(TblSysLog.getLogIdColumn(), logId);
        sum.Add(TblSysLog.getDescColumn(), desc);
        sum.Add(TblSysLog.getRemarkColumn(), remark);
        sum.Add(TblSysLog.getLogDateColumn(), logDate);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblSysLog item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblSysLog.getLogIdColumn(), item.LogId);
        suc.Add(TblSysLog.getDescColumn(), item.Desc);
        suc.Add(TblSysLog.getRemarkColumn(), item.Remark);
        suc.Add(TblSysLog.getLogDateColumn(), item.LogDate);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSysLog.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSysLog.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
