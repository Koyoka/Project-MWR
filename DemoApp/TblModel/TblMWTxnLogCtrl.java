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

public class TblMWTxnLogCtrl extends BaseDataCtrl {

    public static List<TblMWTxnLog> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWTxnLog> itemList = null;
        try{
            sqm.setQueryTableName(TblMWTxnLog.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWTxnLog.class,sqm.getParamsArray());
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

    public static List<TblMWTxnLog> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWTxnLog> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWTxnLog> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWTxnLog> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWTxnLog.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWTxnLog.class,sqm.getParamsArray());
    }

    public static List<TblMWTxnLog> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWTxnLog> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWTxnLog QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWTxnLog> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWTxnLog QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWTxnLog item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWTxnLog QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWTxnLog QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWTxnLog item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWTxnLog item) {
        return Insert(dcf,
                item.TxnLogId,
                item.TxnNum,
                item.TxnDetailId,
                item.WSCode,
                item.EmpyName,
                item.EmpyCode,
                item.OptType,
                item.OptDate,
                item.TxnLogType,
                item.InvRecordId
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int txnLogId,
            String txnNum,
            int txnDetailId,
            String wSCode,
            String empyName,
            String empyCode,
            String optType,
            String optDate,
            String txnLogType,
            int invRecordId
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnLog.getFormatTableName());
        sum.Add(TblMWTxnLog.getTxnLogIdColumn(), txnLogId);
        sum.Add(TblMWTxnLog.getTxnNumColumn(), txnNum);
        sum.Add(TblMWTxnLog.getTxnDetailIdColumn(), txnDetailId);
        sum.Add(TblMWTxnLog.getWSCodeColumn(), wSCode);
        sum.Add(TblMWTxnLog.getEmpyNameColumn(), empyName);
        sum.Add(TblMWTxnLog.getEmpyCodeColumn(), empyCode);
        sum.Add(TblMWTxnLog.getOptTypeColumn(), optType);
        sum.Add(TblMWTxnLog.getOptDateColumn(), optDate);
        sum.Add(TblMWTxnLog.getTxnLogTypeColumn(), txnLogType);
        sum.Add(TblMWTxnLog.getInvRecordIdColumn(), invRecordId);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWTxnLog item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWTxnLog.getTxnLogIdColumn(), item.TxnLogId);
        suc.Add(TblMWTxnLog.getTxnNumColumn(), item.TxnNum);
        suc.Add(TblMWTxnLog.getTxnDetailIdColumn(), item.TxnDetailId);
        suc.Add(TblMWTxnLog.getWSCodeColumn(), item.WSCode);
        suc.Add(TblMWTxnLog.getEmpyNameColumn(), item.EmpyName);
        suc.Add(TblMWTxnLog.getEmpyCodeColumn(), item.EmpyCode);
        suc.Add(TblMWTxnLog.getOptTypeColumn(), item.OptType);
        suc.Add(TblMWTxnLog.getOptDateColumn(), item.OptDate);
        suc.Add(TblMWTxnLog.getTxnLogTypeColumn(), item.TxnLogType);
        suc.Add(TblMWTxnLog.getInvRecordIdColumn(), item.InvRecordId);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnLog.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnLog.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
