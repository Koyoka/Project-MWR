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

public class TblMWWorkStationCtrl extends BaseDataCtrl {

    public static List<TblMWWorkStation> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWWorkStation> itemList = null;
        try{
            sqm.setQueryTableName(TblMWWorkStation.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWWorkStation.class,sqm.getParamsArray());
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

    public static List<TblMWWorkStation> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWWorkStation> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWWorkStation> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWWorkStation> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWWorkStation.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWWorkStation.class,sqm.getParamsArray());
    }

    public static List<TblMWWorkStation> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWWorkStation> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWWorkStation QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWWorkStation> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWWorkStation QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWWorkStation item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWWorkStation QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWWorkStation QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWWorkStation item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWWorkStation item) {
        return Insert(dcf,
                item.WSCode,
                item.Desc,
                item.WSType,
                item.AccessKey,
                item.SecretKey
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            String wSCode,
            String desc,
            String wSType,
            String accessKey,
            String secretKey
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWWorkStation.getFormatTableName());
        sum.Add(TblMWWorkStation.getWSCodeColumn(), wSCode);
        sum.Add(TblMWWorkStation.getDescColumn(), desc);
        sum.Add(TblMWWorkStation.getWSTypeColumn(), wSType);
        sum.Add(TblMWWorkStation.getAccessKeyColumn(), accessKey);
        sum.Add(TblMWWorkStation.getSecretKeyColumn(), secretKey);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWWorkStation item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWWorkStation.getWSCodeColumn(), item.WSCode);
        suc.Add(TblMWWorkStation.getDescColumn(), item.Desc);
        suc.Add(TblMWWorkStation.getWSTypeColumn(), item.WSType);
        suc.Add(TblMWWorkStation.getAccessKeyColumn(), item.AccessKey);
        suc.Add(TblMWWorkStation.getSecretKeyColumn(), item.SecretKey);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWWorkStation.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWWorkStation.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
