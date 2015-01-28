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

public class TblMWInvAuthorizeCtrl extends BaseDataCtrl {

    public static List<TblMWInvAuthorize> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWInvAuthorize> itemList = null;
        try{
            sqm.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWInvAuthorize.class,sqm.getParamsArray());
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

    public static List<TblMWInvAuthorize> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWInvAuthorize> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWInvAuthorize> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWInvAuthorize> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWInvAuthorize.class,sqm.getParamsArray());
    }

    public static List<TblMWInvAuthorize> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWInvAuthorize> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWInvAuthorize QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWInvAuthorize> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWInvAuthorize QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWInvAuthorize item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWInvAuthorize QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWInvAuthorize QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWInvAuthorize item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWInvAuthorize item) {
        return Insert(dcf,
                item.InvAuthId,
                item.TxnNum,
                item.TxnDetailId,
                item.EmpyCode,
                item.EmpyName,
                item.WSCode,
                item.AuthEmpyCode,
                item.AuthEmpyName,
                item.Remark,
                item.SubWeight,
                item.TxnWeight,
                item.DiffWeight,
                item.EntryDate,
                item.CompDate,
                item.Status
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int invAuthId,
            String txnNum,
            int txnDetailId,
            String empyCode,
            String empyName,
            String wSCode,
            String authEmpyCode,
            String authEmpyName,
            String remark,
            decimal subWeight,
            decimal txnWeight,
            decimal diffWeight,
            String entryDate,
            String compDate,
            String status
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
        sum.Add(TblMWInvAuthorize.getInvAuthIdColumn(), invAuthId);
        sum.Add(TblMWInvAuthorize.getTxnNumColumn(), txnNum);
        sum.Add(TblMWInvAuthorize.getTxnDetailIdColumn(), txnDetailId);
        sum.Add(TblMWInvAuthorize.getEmpyCodeColumn(), empyCode);
        sum.Add(TblMWInvAuthorize.getEmpyNameColumn(), empyName);
        sum.Add(TblMWInvAuthorize.getWSCodeColumn(), wSCode);
        sum.Add(TblMWInvAuthorize.getAuthEmpyCodeColumn(), authEmpyCode);
        sum.Add(TblMWInvAuthorize.getAuthEmpyNameColumn(), authEmpyName);
        sum.Add(TblMWInvAuthorize.getRemarkColumn(), remark);
        sum.Add(TblMWInvAuthorize.getSubWeightColumn(), subWeight);
        sum.Add(TblMWInvAuthorize.getTxnWeightColumn(), txnWeight);
        sum.Add(TblMWInvAuthorize.getDiffWeightColumn(), diffWeight);
        sum.Add(TblMWInvAuthorize.getEntryDateColumn(), entryDate);
        sum.Add(TblMWInvAuthorize.getCompDateColumn(), compDate);
        sum.Add(TblMWInvAuthorize.getStatusColumn(), status);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWInvAuthorize item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWInvAuthorize.getInvAuthIdColumn(), item.InvAuthId);
        suc.Add(TblMWInvAuthorize.getTxnNumColumn(), item.TxnNum);
        suc.Add(TblMWInvAuthorize.getTxnDetailIdColumn(), item.TxnDetailId);
        suc.Add(TblMWInvAuthorize.getEmpyCodeColumn(), item.EmpyCode);
        suc.Add(TblMWInvAuthorize.getEmpyNameColumn(), item.EmpyName);
        suc.Add(TblMWInvAuthorize.getWSCodeColumn(), item.WSCode);
        suc.Add(TblMWInvAuthorize.getAuthEmpyCodeColumn(), item.AuthEmpyCode);
        suc.Add(TblMWInvAuthorize.getAuthEmpyNameColumn(), item.AuthEmpyName);
        suc.Add(TblMWInvAuthorize.getRemarkColumn(), item.Remark);
        suc.Add(TblMWInvAuthorize.getSubWeightColumn(), item.SubWeight);
        suc.Add(TblMWInvAuthorize.getTxnWeightColumn(), item.TxnWeight);
        suc.Add(TblMWInvAuthorize.getDiffWeightColumn(), item.DiffWeight);
        suc.Add(TblMWInvAuthorize.getEntryDateColumn(), item.EntryDate);
        suc.Add(TblMWInvAuthorize.getCompDateColumn(), item.CompDate);
        suc.Add(TblMWInvAuthorize.getStatusColumn(), item.Status);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInvAuthorize.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
