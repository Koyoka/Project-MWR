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

public class TblMWRecoverDetailCtrl extends BaseDataCtrl {

    public static List<TblMWRecoverDetail> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWRecoverDetail> itemList = null;
        try{
            sqm.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWRecoverDetail.class,sqm.getParamsArray());
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

    public static List<TblMWRecoverDetail> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWRecoverDetail> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWRecoverDetail> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWRecoverDetail> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWRecoverDetail.class,sqm.getParamsArray());
    }

    public static List<TblMWRecoverDetail> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWRecoverDetail> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWRecoverDetail QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWRecoverDetail> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWRecoverDetail QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWRecoverDetail item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWRecoverDetail QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWRecoverDetail QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWRecoverDetail item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWRecoverDetail item) {
        return Insert(dcf,
                item.RecoDtlId,
                item.RecoHeaderId,
                item.CrateCode,
                item.RecoNum,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.RecoWeight,
                item.RecoDate,
                item.InvAuthId,
                item.Status
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int recoDtlId,
            int recoHeaderId,
            String crateCode,
            String recoNum,
            String vendor,
            String vendorCode,
            String waste,
            String wasteCode,
            float recoWeight,
            String recoDate,
            int invAuthId,
            String status
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
        sum.Add(TblMWRecoverDetail.getRecoDtlIdColumn(), recoDtlId);
        sum.Add(TblMWRecoverDetail.getRecoHeaderIdColumn(), recoHeaderId);
        sum.Add(TblMWRecoverDetail.getCrateCodeColumn(), crateCode);
        sum.Add(TblMWRecoverDetail.getRecoNumColumn(), recoNum);
        sum.Add(TblMWRecoverDetail.getVendorColumn(), vendor);
        sum.Add(TblMWRecoverDetail.getVendorCodeColumn(), vendorCode);
        sum.Add(TblMWRecoverDetail.getWasteColumn(), waste);
        sum.Add(TblMWRecoverDetail.getWasteCodeColumn(), wasteCode);
        sum.Add(TblMWRecoverDetail.getRecoWeightColumn(), recoWeight);
        sum.Add(TblMWRecoverDetail.getRecoDateColumn(), recoDate);
        sum.Add(TblMWRecoverDetail.getInvAuthIdColumn(), invAuthId);
        sum.Add(TblMWRecoverDetail.getStatusColumn(), status);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWRecoverDetail item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWRecoverDetail.getRecoDtlIdColumn(), item.RecoDtlId);
        suc.Add(TblMWRecoverDetail.getRecoHeaderIdColumn(), item.RecoHeaderId);
        suc.Add(TblMWRecoverDetail.getCrateCodeColumn(), item.CrateCode);
        suc.Add(TblMWRecoverDetail.getRecoNumColumn(), item.RecoNum);
        suc.Add(TblMWRecoverDetail.getVendorColumn(), item.Vendor);
        suc.Add(TblMWRecoverDetail.getVendorCodeColumn(), item.VendorCode);
        suc.Add(TblMWRecoverDetail.getWasteColumn(), item.Waste);
        suc.Add(TblMWRecoverDetail.getWasteCodeColumn(), item.WasteCode);
        suc.Add(TblMWRecoverDetail.getRecoWeightColumn(), item.RecoWeight);
        suc.Add(TblMWRecoverDetail.getRecoDateColumn(), item.RecoDate);
        suc.Add(TblMWRecoverDetail.getInvAuthIdColumn(), item.InvAuthId);
        suc.Add(TblMWRecoverDetail.getStatusColumn(), item.Status);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWRecoverDetail.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
