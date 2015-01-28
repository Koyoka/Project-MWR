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

public class TblMWInventoryTrackCtrl extends BaseDataCtrl {

    public static List<TblMWInventoryTrack> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWInventoryTrack> itemList = null;
        try{
            sqm.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWInventoryTrack.class,sqm.getParamsArray());
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

    public static List<TblMWInventoryTrack> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWInventoryTrack> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWInventoryTrack> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWInventoryTrack> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWInventoryTrack.class,sqm.getParamsArray());
    }

    public static List<TblMWInventoryTrack> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWInventoryTrack> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWInventoryTrack QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWInventoryTrack> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWInventoryTrack QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWInventoryTrack item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWInventoryTrack QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWInventoryTrack QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWInventoryTrack item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWInventoryTrack item) {
        return Insert(dcf,
                item.InvTrackRecordId,
                item.InvRecordId,
                item.TxnNum,
                item.TxnType,
                item.TxnDetailId,
                item.CrateCode,
                item.DepotCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.SubWeight,
                item.TxnWeight,
                item.WSCode,
                item.EmpyName,
                item.EmpyCode,
                item.EntryDate,
                item.Status,
                item.InvAuthId
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int invTrackRecordId,
            int invRecordId,
            String txnNum,
            String txnType,
            int txnDetailId,
            String crateCode,
            String depotCode,
            String vendor,
            String vendorCode,
            String waste,
            String wasteCode,
            decimal subWeight,
            decimal txnWeight,
            String wSCode,
            String empyName,
            String empyCode,
            String entryDate,
            String status,
            int invAuthId
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
        sum.Add(TblMWInventoryTrack.getInvTrackRecordIdColumn(), invTrackRecordId);
        sum.Add(TblMWInventoryTrack.getInvRecordIdColumn(), invRecordId);
        sum.Add(TblMWInventoryTrack.getTxnNumColumn(), txnNum);
        sum.Add(TblMWInventoryTrack.getTxnTypeColumn(), txnType);
        sum.Add(TblMWInventoryTrack.getTxnDetailIdColumn(), txnDetailId);
        sum.Add(TblMWInventoryTrack.getCrateCodeColumn(), crateCode);
        sum.Add(TblMWInventoryTrack.getDepotCodeColumn(), depotCode);
        sum.Add(TblMWInventoryTrack.getVendorColumn(), vendor);
        sum.Add(TblMWInventoryTrack.getVendorCodeColumn(), vendorCode);
        sum.Add(TblMWInventoryTrack.getWasteColumn(), waste);
        sum.Add(TblMWInventoryTrack.getWasteCodeColumn(), wasteCode);
        sum.Add(TblMWInventoryTrack.getSubWeightColumn(), subWeight);
        sum.Add(TblMWInventoryTrack.getTxnWeightColumn(), txnWeight);
        sum.Add(TblMWInventoryTrack.getWSCodeColumn(), wSCode);
        sum.Add(TblMWInventoryTrack.getEmpyNameColumn(), empyName);
        sum.Add(TblMWInventoryTrack.getEmpyCodeColumn(), empyCode);
        sum.Add(TblMWInventoryTrack.getEntryDateColumn(), entryDate);
        sum.Add(TblMWInventoryTrack.getStatusColumn(), status);
        sum.Add(TblMWInventoryTrack.getInvAuthIdColumn(), invAuthId);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWInventoryTrack item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWInventoryTrack.getInvTrackRecordIdColumn(), item.InvTrackRecordId);
        suc.Add(TblMWInventoryTrack.getInvRecordIdColumn(), item.InvRecordId);
        suc.Add(TblMWInventoryTrack.getTxnNumColumn(), item.TxnNum);
        suc.Add(TblMWInventoryTrack.getTxnTypeColumn(), item.TxnType);
        suc.Add(TblMWInventoryTrack.getTxnDetailIdColumn(), item.TxnDetailId);
        suc.Add(TblMWInventoryTrack.getCrateCodeColumn(), item.CrateCode);
        suc.Add(TblMWInventoryTrack.getDepotCodeColumn(), item.DepotCode);
        suc.Add(TblMWInventoryTrack.getVendorColumn(), item.Vendor);
        suc.Add(TblMWInventoryTrack.getVendorCodeColumn(), item.VendorCode);
        suc.Add(TblMWInventoryTrack.getWasteColumn(), item.Waste);
        suc.Add(TblMWInventoryTrack.getWasteCodeColumn(), item.WasteCode);
        suc.Add(TblMWInventoryTrack.getSubWeightColumn(), item.SubWeight);
        suc.Add(TblMWInventoryTrack.getTxnWeightColumn(), item.TxnWeight);
        suc.Add(TblMWInventoryTrack.getWSCodeColumn(), item.WSCode);
        suc.Add(TblMWInventoryTrack.getEmpyNameColumn(), item.EmpyName);
        suc.Add(TblMWInventoryTrack.getEmpyCodeColumn(), item.EmpyCode);
        suc.Add(TblMWInventoryTrack.getEntryDateColumn(), item.EntryDate);
        suc.Add(TblMWInventoryTrack.getStatusColumn(), item.Status);
        suc.Add(TblMWInventoryTrack.getInvAuthIdColumn(), item.InvAuthId);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInventoryTrack.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
