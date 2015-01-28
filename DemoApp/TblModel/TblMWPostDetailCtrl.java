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

public class TblMWPostDetailCtrl extends BaseDataCtrl {

    public static List<TblMWPostDetail> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWPostDetail> itemList = null;
        try{
            sqm.setQueryTableName(TblMWPostDetail.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWPostDetail.class,sqm.getParamsArray());
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

    public static List<TblMWPostDetail> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWPostDetail> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWPostDetail> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWPostDetail> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWPostDetail.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWPostDetail.class,sqm.getParamsArray());
    }

    public static List<TblMWPostDetail> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWPostDetail> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWPostDetail QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWPostDetail> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWPostDetail QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWPostDetail item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWPostDetail QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWPostDetail QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWPostDetail item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWPostDetail item) {
        return Insert(dcf,
                item.PostDtlId,
                item.PostHeaderId,
                item.CrateCode,
                item.PostNum,
                item.DepotCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.InvWeight,
                item.PostWeight,
                item.Status,
                item.InvRecordId,
                item.InvAuthId
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int postDtlId,
            int postHeaderId,
            String crateCode,
            String postNum,
            String depotCode,
            String vendor,
            String vendorCode,
            String waste,
            String wasteCode,
            float invWeight,
            float postWeight,
            String status,
            int invRecordId,
            int invAuthId
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWPostDetail.getFormatTableName());
        sum.Add(TblMWPostDetail.getPostDtlIdColumn(), postDtlId);
        sum.Add(TblMWPostDetail.getPostHeaderIdColumn(), postHeaderId);
        sum.Add(TblMWPostDetail.getCrateCodeColumn(), crateCode);
        sum.Add(TblMWPostDetail.getPostNumColumn(), postNum);
        sum.Add(TblMWPostDetail.getDepotCodeColumn(), depotCode);
        sum.Add(TblMWPostDetail.getVendorColumn(), vendor);
        sum.Add(TblMWPostDetail.getVendorCodeColumn(), vendorCode);
        sum.Add(TblMWPostDetail.getWasteColumn(), waste);
        sum.Add(TblMWPostDetail.getWasteCodeColumn(), wasteCode);
        sum.Add(TblMWPostDetail.getInvWeightColumn(), invWeight);
        sum.Add(TblMWPostDetail.getPostWeightColumn(), postWeight);
        sum.Add(TblMWPostDetail.getStatusColumn(), status);
        sum.Add(TblMWPostDetail.getInvRecordIdColumn(), invRecordId);
        sum.Add(TblMWPostDetail.getInvAuthIdColumn(), invAuthId);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWPostDetail item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWPostDetail.getPostDtlIdColumn(), item.PostDtlId);
        suc.Add(TblMWPostDetail.getPostHeaderIdColumn(), item.PostHeaderId);
        suc.Add(TblMWPostDetail.getCrateCodeColumn(), item.CrateCode);
        suc.Add(TblMWPostDetail.getPostNumColumn(), item.PostNum);
        suc.Add(TblMWPostDetail.getDepotCodeColumn(), item.DepotCode);
        suc.Add(TblMWPostDetail.getVendorColumn(), item.Vendor);
        suc.Add(TblMWPostDetail.getVendorCodeColumn(), item.VendorCode);
        suc.Add(TblMWPostDetail.getWasteColumn(), item.Waste);
        suc.Add(TblMWPostDetail.getWasteCodeColumn(), item.WasteCode);
        suc.Add(TblMWPostDetail.getInvWeightColumn(), item.InvWeight);
        suc.Add(TblMWPostDetail.getPostWeightColumn(), item.PostWeight);
        suc.Add(TblMWPostDetail.getStatusColumn(), item.Status);
        suc.Add(TblMWPostDetail.getInvRecordIdColumn(), item.InvRecordId);
        suc.Add(TblMWPostDetail.getInvAuthIdColumn(), item.InvAuthId);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWPostDetail.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWPostDetail.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
