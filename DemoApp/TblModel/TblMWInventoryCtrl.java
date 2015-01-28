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

public class TblMWInventoryCtrl extends BaseDataCtrl {

    public static List<TblMWInventory> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWInventory> itemList = null;
        try{
            sqm.setQueryTableName(TblMWInventory.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWInventory.class,sqm.getParamsArray());
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

    public static List<TblMWInventory> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWInventory> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWInventory> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWInventory> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWInventory.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWInventory.class,sqm.getParamsArray());
    }

    public static List<TblMWInventory> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWInventory> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWInventory QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWInventory> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWInventory QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWInventory item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWInventory QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWInventory QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWInventory item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWInventory item) {
        return Insert(dcf,
                item.InvRecordId,
                item.CrateCode,
                item.DepotCode,
                item.Vendor,
                item.VendorCode,
                item.Waste,
                item.WasteCode,
                item.RecoWeight,
                item.InvWeight,
                item.PostWeight,
                item.DestWeight,
                item.EntryDate,
                item.Status,
                item.DailyClose
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int invRecordId,
            String crateCode,
            String depotCode,
            String vendor,
            String vendorCode,
            String waste,
            String wasteCode,
            decimal recoWeight,
            decimal invWeight,
            decimal postWeight,
            decimal destWeight,
            String entryDate,
            String status,
            boolean dailyClose
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInventory.getFormatTableName());
        sum.Add(TblMWInventory.getInvRecordIdColumn(), invRecordId);
        sum.Add(TblMWInventory.getCrateCodeColumn(), crateCode);
        sum.Add(TblMWInventory.getDepotCodeColumn(), depotCode);
        sum.Add(TblMWInventory.getVendorColumn(), vendor);
        sum.Add(TblMWInventory.getVendorCodeColumn(), vendorCode);
        sum.Add(TblMWInventory.getWasteColumn(), waste);
        sum.Add(TblMWInventory.getWasteCodeColumn(), wasteCode);
        sum.Add(TblMWInventory.getRecoWeightColumn(), recoWeight);
        sum.Add(TblMWInventory.getInvWeightColumn(), invWeight);
        sum.Add(TblMWInventory.getPostWeightColumn(), postWeight);
        sum.Add(TblMWInventory.getDestWeightColumn(), destWeight);
        sum.Add(TblMWInventory.getEntryDateColumn(), entryDate);
        sum.Add(TblMWInventory.getStatusColumn(), status);
        sum.Add(TblMWInventory.getDailyCloseColumn(), dailyClose);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWInventory item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWInventory.getInvRecordIdColumn(), item.InvRecordId);
        suc.Add(TblMWInventory.getCrateCodeColumn(), item.CrateCode);
        suc.Add(TblMWInventory.getDepotCodeColumn(), item.DepotCode);
        suc.Add(TblMWInventory.getVendorColumn(), item.Vendor);
        suc.Add(TblMWInventory.getVendorCodeColumn(), item.VendorCode);
        suc.Add(TblMWInventory.getWasteColumn(), item.Waste);
        suc.Add(TblMWInventory.getWasteCodeColumn(), item.WasteCode);
        suc.Add(TblMWInventory.getRecoWeightColumn(), item.RecoWeight);
        suc.Add(TblMWInventory.getInvWeightColumn(), item.InvWeight);
        suc.Add(TblMWInventory.getPostWeightColumn(), item.PostWeight);
        suc.Add(TblMWInventory.getDestWeightColumn(), item.DestWeight);
        suc.Add(TblMWInventory.getEntryDateColumn(), item.EntryDate);
        suc.Add(TblMWInventory.getStatusColumn(), item.Status);
        suc.Add(TblMWInventory.getDailyCloseColumn(), item.DailyClose);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInventory.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWInventory.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
