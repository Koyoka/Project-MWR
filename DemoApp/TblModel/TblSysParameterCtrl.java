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

public class TblSysParameterCtrl extends BaseDataCtrl {

    public static List<TblSysParameter> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblSysParameter> itemList = null;
        try{
            sqm.setQueryTableName(TblSysParameter.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblSysParameter.class,sqm.getParamsArray());
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

    public static List<TblSysParameter> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblSysParameter> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblSysParameter> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblSysParameter> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblSysParameter.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblSysParameter.class,sqm.getParamsArray());
    }

    public static List<TblSysParameter> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblSysParameter> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblSysParameter QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblSysParameter> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblSysParameter QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblSysParameter item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblSysParameter QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblSysParameter QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblSysParameter item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblSysParameter item) {
        return Insert(dcf,
                item.ParameterName,
                item.ParameterValue,
                item.Remark
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            String parameterName,
            String parameterValue,
            String remark
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSysParameter.getFormatTableName());
        sum.Add(TblSysParameter.getParameterNameColumn(), parameterName);
        sum.Add(TblSysParameter.getParameterValueColumn(), parameterValue);
        sum.Add(TblSysParameter.getRemarkColumn(), remark);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblSysParameter item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblSysParameter.getParameterNameColumn(), item.ParameterName);
        suc.Add(TblSysParameter.getParameterValueColumn(), item.ParameterValue);
        suc.Add(TblSysParameter.getRemarkColumn(), item.Remark);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSysParameter.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblSysParameter.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
