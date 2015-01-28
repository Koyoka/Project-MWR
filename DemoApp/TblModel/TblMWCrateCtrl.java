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

public class TblMWCrateCtrl extends BaseDataCtrl {

    public static List<TblMWCrate> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWCrate> itemList = null;
        try{
            sqm.setQueryTableName(TblMWCrate.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWCrate.class,sqm.getParamsArray());
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

    public static List<TblMWCrate> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWCrate> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWCrate> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWCrate> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWCrate.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWCrate.class,sqm.getParamsArray());
    }

    public static List<TblMWCrate> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWCrate> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWCrate QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWCrate> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWCrate QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWCrate item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWCrate QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWCrate QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWCrate item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWCrate item) {
        return Insert(dcf,
                item.CrateCode,
                item.Desc,
                item.Status
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            String crateCode,
            String desc,
            String status
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWCrate.getFormatTableName());
        sum.Add(TblMWCrate.getCrateCodeColumn(), crateCode);
        sum.Add(TblMWCrate.getDescColumn(), desc);
        sum.Add(TblMWCrate.getStatusColumn(), status);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWCrate item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWCrate.getCrateCodeColumn(), item.CrateCode);
        suc.Add(TblMWCrate.getDescColumn(), item.Desc);
        suc.Add(TblMWCrate.getStatusColumn(), item.Status);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWCrate.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWCrate.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
