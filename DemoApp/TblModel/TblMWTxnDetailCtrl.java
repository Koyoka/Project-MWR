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

public class TblMWTxnDetailCtrl extends BaseDataCtrl {

    public static List<TblMWTxnDetail> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWTxnDetail> itemList = null;
        try{
            sqm.setQueryTableName(TblMWTxnDetail.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWTxnDetail.class,sqm.getParamsArray());
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

    public static List<TblMWTxnDetail> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWTxnDetail> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWTxnDetail> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWTxnDetail> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWTxnDetail.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWTxnDetail.class,sqm.getParamsArray());
    }

    public static List<TblMWTxnDetail> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWTxnDetail> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWTxnDetail QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWTxnDetail> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWTxnDetail QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWTxnDetail item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWTxnDetail QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWTxnDetail QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWTxnDetail item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWTxnDetail item) {
        return Insert(dcf,
                item.TxnDetailId,
                item.TxnType,
                item.TxnNum,
                item.WSCode,
                item.EmpyName,
                item.EmpyCode,
                item.CrateCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.SubWeight,
                item.TxnWeight,
                item.EntryDate,
                item.InvRecordId,
                item.InvAuthId,
                item.Status
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int txnDetailId,
            String txnType,
            String txnNum,
            String wSCode,
            String empyName,
            String empyCode,
            String crateCode,
            String vendor,
            String vendorCode,
            String waste,
            String wasteCode,
            decimal subWeight,
            decimal txnWeight,
            String entryDate,
            int invRecordId,
            int invAuthId,
            String status
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnDetail.getFormatTableName());
        sum.Add(TblMWTxnDetail.getTxnDetailIdColumn(), txnDetailId);
        sum.Add(TblMWTxnDetail.getTxnTypeColumn(), txnType);
        sum.Add(TblMWTxnDetail.getTxnNumColumn(), txnNum);
        sum.Add(TblMWTxnDetail.getWSCodeColumn(), wSCode);
        sum.Add(TblMWTxnDetail.getEmpyNameColumn(), empyName);
        sum.Add(TblMWTxnDetail.getEmpyCodeColumn(), empyCode);
        sum.Add(TblMWTxnDetail.getCrateCodeColumn(), crateCode);
        sum.Add(TblMWTxnDetail.getVendorColumn(), vendor);
        sum.Add(TblMWTxnDetail.getVendorCodeColumn(), vendorCode);
        sum.Add(TblMWTxnDetail.getWasteColumn(), waste);
        sum.Add(TblMWTxnDetail.getWasteCodeColumn(), wasteCode);
        sum.Add(TblMWTxnDetail.getSubWeightColumn(), subWeight);
        sum.Add(TblMWTxnDetail.getTxnWeightColumn(), txnWeight);
        sum.Add(TblMWTxnDetail.getEntryDateColumn(), entryDate);
        sum.Add(TblMWTxnDetail.getInvRecordIdColumn(), invRecordId);
        sum.Add(TblMWTxnDetail.getInvAuthIdColumn(), invAuthId);
        sum.Add(TblMWTxnDetail.getStatusColumn(), status);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWTxnDetail item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWTxnDetail.getTxnDetailIdColumn(), item.TxnDetailId);
        suc.Add(TblMWTxnDetail.getTxnTypeColumn(), item.TxnType);
        suc.Add(TblMWTxnDetail.getTxnNumColumn(), item.TxnNum);
        suc.Add(TblMWTxnDetail.getWSCodeColumn(), item.WSCode);
        suc.Add(TblMWTxnDetail.getEmpyNameColumn(), item.EmpyName);
        suc.Add(TblMWTxnDetail.getEmpyCodeColumn(), item.EmpyCode);
        suc.Add(TblMWTxnDetail.getCrateCodeColumn(), item.CrateCode);
        suc.Add(TblMWTxnDetail.getVendorColumn(), item.Vendor);
        suc.Add(TblMWTxnDetail.getVendorCodeColumn(), item.VendorCode);
        suc.Add(TblMWTxnDetail.getWasteColumn(), item.Waste);
        suc.Add(TblMWTxnDetail.getWasteCodeColumn(), item.WasteCode);
        suc.Add(TblMWTxnDetail.getSubWeightColumn(), item.SubWeight);
        suc.Add(TblMWTxnDetail.getTxnWeightColumn(), item.TxnWeight);
        suc.Add(TblMWTxnDetail.getEntryDateColumn(), item.EntryDate);
        suc.Add(TblMWTxnDetail.getInvRecordIdColumn(), item.InvRecordId);
        suc.Add(TblMWTxnDetail.getInvAuthIdColumn(), item.InvAuthId);
        suc.Add(TblMWTxnDetail.getStatusColumn(), item.Status);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnDetail.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnDetail.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
