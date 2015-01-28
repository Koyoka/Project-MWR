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

public class TblMWDestroyDetailCtrl extends BaseDataCtrl {

    public static List<TblMWDestroyDetail> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWDestroyDetail> itemList = null;
        try{
            sqm.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWDestroyDetail.class,sqm.getParamsArray());
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

    public static List<TblMWDestroyDetail> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWDestroyDetail> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWDestroyDetail> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWDestroyDetail> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWDestroyDetail.class,sqm.getParamsArray());
    }

    public static List<TblMWDestroyDetail> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWDestroyDetail> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWDestroyDetail QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWDestroyDetail> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWDestroyDetail QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWDestroyDetail item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWDestroyDetail QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWDestroyDetail QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWDestroyDetail item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWDestroyDetail item) {
        return Insert(dcf,
                item.DestroyDtlId,
                item.CrateCode,
                item.DestHeaderId,
                item.DestNum,
                item.DepotCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.PostWeight,
                item.DestWeight,
                item.Status,
                item.PostHeaderId,
                item.InvRecordId,
                item.InvAuthId
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int destroyDtlId,
            String crateCode,
            int destHeaderId,
            String destNum,
            String depotCode,
            String vendor,
            String vendorCode,
            String waste,
            String wasteCode,
            float postWeight,
            float destWeight,
            String status,
            int postHeaderId,
            int invRecordId,
            int invAuthId
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
        sum.Add(TblMWDestroyDetail.getDestroyDtlIdColumn(), destroyDtlId);
        sum.Add(TblMWDestroyDetail.getCrateCodeColumn(), crateCode);
        sum.Add(TblMWDestroyDetail.getDestHeaderIdColumn(), destHeaderId);
        sum.Add(TblMWDestroyDetail.getDestNumColumn(), destNum);
        sum.Add(TblMWDestroyDetail.getDepotCodeColumn(), depotCode);
        sum.Add(TblMWDestroyDetail.getVendorColumn(), vendor);
        sum.Add(TblMWDestroyDetail.getVendorCodeColumn(), vendorCode);
        sum.Add(TblMWDestroyDetail.getWasteColumn(), waste);
        sum.Add(TblMWDestroyDetail.getWasteCodeColumn(), wasteCode);
        sum.Add(TblMWDestroyDetail.getPostWeightColumn(), postWeight);
        sum.Add(TblMWDestroyDetail.getDestWeightColumn(), destWeight);
        sum.Add(TblMWDestroyDetail.getStatusColumn(), status);
        sum.Add(TblMWDestroyDetail.getPostHeaderIdColumn(), postHeaderId);
        sum.Add(TblMWDestroyDetail.getInvRecordIdColumn(), invRecordId);
        sum.Add(TblMWDestroyDetail.getInvAuthIdColumn(), invAuthId);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWDestroyDetail item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWDestroyDetail.getDestroyDtlIdColumn(), item.DestroyDtlId);
        suc.Add(TblMWDestroyDetail.getCrateCodeColumn(), item.CrateCode);
        suc.Add(TblMWDestroyDetail.getDestHeaderIdColumn(), item.DestHeaderId);
        suc.Add(TblMWDestroyDetail.getDestNumColumn(), item.DestNum);
        suc.Add(TblMWDestroyDetail.getDepotCodeColumn(), item.DepotCode);
        suc.Add(TblMWDestroyDetail.getVendorColumn(), item.Vendor);
        suc.Add(TblMWDestroyDetail.getVendorCodeColumn(), item.VendorCode);
        suc.Add(TblMWDestroyDetail.getWasteColumn(), item.Waste);
        suc.Add(TblMWDestroyDetail.getWasteCodeColumn(), item.WasteCode);
        suc.Add(TblMWDestroyDetail.getPostWeightColumn(), item.PostWeight);
        suc.Add(TblMWDestroyDetail.getDestWeightColumn(), item.DestWeight);
        suc.Add(TblMWDestroyDetail.getStatusColumn(), item.Status);
        suc.Add(TblMWDestroyDetail.getPostHeaderIdColumn(), item.PostHeaderId);
        suc.Add(TblMWDestroyDetail.getInvRecordIdColumn(), item.InvRecordId);
        suc.Add(TblMWDestroyDetail.getInvAuthIdColumn(), item.InvAuthId);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWDestroyDetail.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
