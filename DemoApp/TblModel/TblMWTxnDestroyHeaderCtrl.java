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

public class TblMWTxnDestroyHeaderCtrl extends BaseDataCtrl {

    public static List<TblMWTxnDestroyHeader> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWTxnDestroyHeader> itemList = null;
        try{
            sqm.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWTxnDestroyHeader.class,sqm.getParamsArray());
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

    public static List<TblMWTxnDestroyHeader> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWTxnDestroyHeader> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWTxnDestroyHeader> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWTxnDestroyHeader> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWTxnDestroyHeader.class,sqm.getParamsArray());
    }

    public static List<TblMWTxnDestroyHeader> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWTxnDestroyHeader> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWTxnDestroyHeader QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWTxnDestroyHeader> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWTxnDestroyHeader QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWTxnDestroyHeader item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWTxnDestroyHeader QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWTxnDestroyHeader QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWTxnDestroyHeader item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWTxnDestroyHeader item) {
        return Insert(dcf,
                item.DestHeaderId,
                item.TxnNum,
                item.StratDate,
                item.EndDate,
                item.DestWSCode,
                item.DestEmpyName,
                item.DestEmpyCode,
                item.TotalCrateQty,
                item.TotalSubWeight,
                item.TotalTxnWeight,
                item.Status
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int destHeaderId,
            String txnNum,
            String stratDate,
            String endDate,
            String destWSCode,
            String destEmpyName,
            String destEmpyCode,
            int totalCrateQty,
            decimal totalSubWeight,
            decimal totalTxnWeight,
            String status
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
        sum.Add(TblMWTxnDestroyHeader.getDestHeaderIdColumn(), destHeaderId);
        sum.Add(TblMWTxnDestroyHeader.getTxnNumColumn(), txnNum);
        sum.Add(TblMWTxnDestroyHeader.getStratDateColumn(), stratDate);
        sum.Add(TblMWTxnDestroyHeader.getEndDateColumn(), endDate);
        sum.Add(TblMWTxnDestroyHeader.getDestWSCodeColumn(), destWSCode);
        sum.Add(TblMWTxnDestroyHeader.getDestEmpyNameColumn(), destEmpyName);
        sum.Add(TblMWTxnDestroyHeader.getDestEmpyCodeColumn(), destEmpyCode);
        sum.Add(TblMWTxnDestroyHeader.getTotalCrateQtyColumn(), totalCrateQty);
        sum.Add(TblMWTxnDestroyHeader.getTotalSubWeightColumn(), totalSubWeight);
        sum.Add(TblMWTxnDestroyHeader.getTotalTxnWeightColumn(), totalTxnWeight);
        sum.Add(TblMWTxnDestroyHeader.getStatusColumn(), status);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWTxnDestroyHeader item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWTxnDestroyHeader.getDestHeaderIdColumn(), item.DestHeaderId);
        suc.Add(TblMWTxnDestroyHeader.getTxnNumColumn(), item.TxnNum);
        suc.Add(TblMWTxnDestroyHeader.getStratDateColumn(), item.StratDate);
        suc.Add(TblMWTxnDestroyHeader.getEndDateColumn(), item.EndDate);
        suc.Add(TblMWTxnDestroyHeader.getDestWSCodeColumn(), item.DestWSCode);
        suc.Add(TblMWTxnDestroyHeader.getDestEmpyNameColumn(), item.DestEmpyName);
        suc.Add(TblMWTxnDestroyHeader.getDestEmpyCodeColumn(), item.DestEmpyCode);
        suc.Add(TblMWTxnDestroyHeader.getTotalCrateQtyColumn(), item.TotalCrateQty);
        suc.Add(TblMWTxnDestroyHeader.getTotalSubWeightColumn(), item.TotalSubWeight);
        suc.Add(TblMWTxnDestroyHeader.getTotalTxnWeightColumn(), item.TotalTxnWeight);
        suc.Add(TblMWTxnDestroyHeader.getStatusColumn(), item.Status);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnDestroyHeader.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
