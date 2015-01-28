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

public class TblMWTxnPostHeaderCtrl extends BaseDataCtrl {

    public static List<TblMWTxnPostHeader> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWTxnPostHeader> itemList = null;
        try{
            sqm.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWTxnPostHeader.class,sqm.getParamsArray());
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

    public static List<TblMWTxnPostHeader> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWTxnPostHeader> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWTxnPostHeader> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWTxnPostHeader> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWTxnPostHeader.class,sqm.getParamsArray());
    }

    public static List<TblMWTxnPostHeader> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWTxnPostHeader> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWTxnPostHeader QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWTxnPostHeader> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWTxnPostHeader QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWTxnPostHeader item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWTxnPostHeader QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWTxnPostHeader QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWTxnPostHeader item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWTxnPostHeader item) {
        return Insert(dcf,
                item.PostHeaderId,
                item.TxnNum,
                item.PostWSCode,
                item.PostEmpyName,
                item.PostEmpyCode,
                item.StratDate,
                item.EndDate,
                item.PostType,
                item.TotalCrateQty,
                item.TotalSubWeight,
                item.TotalTxnWeight,
                item.Status
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int postHeaderId,
            String txnNum,
            String postWSCode,
            String postEmpyName,
            String postEmpyCode,
            String stratDate,
            String endDate,
            String postType,
            int totalCrateQty,
            decimal totalSubWeight,
            decimal totalTxnWeight,
            String status
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
        sum.Add(TblMWTxnPostHeader.getPostHeaderIdColumn(), postHeaderId);
        sum.Add(TblMWTxnPostHeader.getTxnNumColumn(), txnNum);
        sum.Add(TblMWTxnPostHeader.getPostWSCodeColumn(), postWSCode);
        sum.Add(TblMWTxnPostHeader.getPostEmpyNameColumn(), postEmpyName);
        sum.Add(TblMWTxnPostHeader.getPostEmpyCodeColumn(), postEmpyCode);
        sum.Add(TblMWTxnPostHeader.getStratDateColumn(), stratDate);
        sum.Add(TblMWTxnPostHeader.getEndDateColumn(), endDate);
        sum.Add(TblMWTxnPostHeader.getPostTypeColumn(), postType);
        sum.Add(TblMWTxnPostHeader.getTotalCrateQtyColumn(), totalCrateQty);
        sum.Add(TblMWTxnPostHeader.getTotalSubWeightColumn(), totalSubWeight);
        sum.Add(TblMWTxnPostHeader.getTotalTxnWeightColumn(), totalTxnWeight);
        sum.Add(TblMWTxnPostHeader.getStatusColumn(), status);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWTxnPostHeader item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWTxnPostHeader.getPostHeaderIdColumn(), item.PostHeaderId);
        suc.Add(TblMWTxnPostHeader.getTxnNumColumn(), item.TxnNum);
        suc.Add(TblMWTxnPostHeader.getPostWSCodeColumn(), item.PostWSCode);
        suc.Add(TblMWTxnPostHeader.getPostEmpyNameColumn(), item.PostEmpyName);
        suc.Add(TblMWTxnPostHeader.getPostEmpyCodeColumn(), item.PostEmpyCode);
        suc.Add(TblMWTxnPostHeader.getStratDateColumn(), item.StratDate);
        suc.Add(TblMWTxnPostHeader.getEndDateColumn(), item.EndDate);
        suc.Add(TblMWTxnPostHeader.getPostTypeColumn(), item.PostType);
        suc.Add(TblMWTxnPostHeader.getTotalCrateQtyColumn(), item.TotalCrateQty);
        suc.Add(TblMWTxnPostHeader.getTotalSubWeightColumn(), item.TotalSubWeight);
        suc.Add(TblMWTxnPostHeader.getTotalTxnWeightColumn(), item.TotalTxnWeight);
        suc.Add(TblMWTxnPostHeader.getStatusColumn(), item.Status);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnPostHeader.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
