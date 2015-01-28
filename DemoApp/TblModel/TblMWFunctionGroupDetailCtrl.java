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

public class TblMWFunctionGroupDetailCtrl extends BaseDataCtrl {

    public static List<TblMWFunctionGroupDetail> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWFunctionGroupDetail> itemList = null;
        try{
            sqm.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWFunctionGroupDetail.class,sqm.getParamsArray());
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

    public static List<TblMWFunctionGroupDetail> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWFunctionGroupDetail> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWFunctionGroupDetail> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWFunctionGroupDetail> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWFunctionGroupDetail.class,sqm.getParamsArray());
    }

    public static List<TblMWFunctionGroupDetail> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWFunctionGroupDetail> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWFunctionGroupDetail QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWFunctionGroupDetail> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWFunctionGroupDetail QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWFunctionGroupDetail item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWFunctionGroupDetail QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWFunctionGroupDetail QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWFunctionGroupDetail item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWFunctionGroupDetail item) {
        return Insert(dcf,
                item.FuncGroupDtlId,
                item.FuncGroupId,
                item.FuncTag
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int funcGroupDtlId,
            int funcGroupId,
            String funcTag
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
        sum.Add(TblMWFunctionGroupDetail.getFuncGroupDtlIdColumn(), funcGroupDtlId);
        sum.Add(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), funcGroupId);
        sum.Add(TblMWFunctionGroupDetail.getFuncTagColumn(), funcTag);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWFunctionGroupDetail item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWFunctionGroupDetail.getFuncGroupDtlIdColumn(), item.FuncGroupDtlId);
        suc.Add(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), item.FuncGroupId);
        suc.Add(TblMWFunctionGroupDetail.getFuncTagColumn(), item.FuncTag);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
