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

public class TblMWResidueInventoryCtrl extends BaseDataCtrl {

    public static List<TblMWResidueInventory> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWResidueInventory> itemList = null;
        try{
            sqm.setQueryTableName(TblMWResidueInventory.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWResidueInventory.class,sqm.getParamsArray());
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

    public static List<TblMWResidueInventory> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWResidueInventory> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWResidueInventory> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWResidueInventory> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWResidueInventory.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWResidueInventory.class,sqm.getParamsArray());
    }

    public static List<TblMWResidueInventory> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWResidueInventory> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWResidueInventory QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWResidueInventory> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWResidueInventory QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWResidueInventory item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWResidueInventory QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWResidueInventory QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWResidueInventory item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWResidueInventory item) {
        return Insert(dcf,
                item.ResdInvId,
                item.InvWeight,
                item.EntryDate,
                item.HandlingDate,
                item.RecoWSCode,
                item.RecoEmpyCode,
                item.HandlingType
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int resdInvId,
            float invWeight,
            String entryDate,
            String handlingDate,
            String recoWSCode,
            String recoEmpyCode,
            String handlingType
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWResidueInventory.getFormatTableName());
        sum.Add(TblMWResidueInventory.getResdInvIdColumn(), resdInvId);
        sum.Add(TblMWResidueInventory.getInvWeightColumn(), invWeight);
        sum.Add(TblMWResidueInventory.getEntryDateColumn(), entryDate);
        sum.Add(TblMWResidueInventory.getHandlingDateColumn(), handlingDate);
        sum.Add(TblMWResidueInventory.getRecoWSCodeColumn(), recoWSCode);
        sum.Add(TblMWResidueInventory.getRecoEmpyCodeColumn(), recoEmpyCode);
        sum.Add(TblMWResidueInventory.getHandlingTypeColumn(), handlingType);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWResidueInventory item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWResidueInventory.getResdInvIdColumn(), item.ResdInvId);
        suc.Add(TblMWResidueInventory.getInvWeightColumn(), item.InvWeight);
        suc.Add(TblMWResidueInventory.getEntryDateColumn(), item.EntryDate);
        suc.Add(TblMWResidueInventory.getHandlingDateColumn(), item.HandlingDate);
        suc.Add(TblMWResidueInventory.getRecoWSCodeColumn(), item.RecoWSCode);
        suc.Add(TblMWResidueInventory.getRecoEmpyCodeColumn(), item.RecoEmpyCode);
        suc.Add(TblMWResidueInventory.getHandlingTypeColumn(), item.HandlingType);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWResidueInventory.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWResidueInventory.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
