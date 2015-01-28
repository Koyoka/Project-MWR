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

public class TblMWTxnRecoverHeaderCtrl extends BaseDataCtrl {

    public static List<TblMWTxnRecoverHeader> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWTxnRecoverHeader> itemList = null;
        try{
            sqm.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWTxnRecoverHeader.class,sqm.getParamsArray());
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

    public static List<TblMWTxnRecoverHeader> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWTxnRecoverHeader> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWTxnRecoverHeader> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWTxnRecoverHeader> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWTxnRecoverHeader.class,sqm.getParamsArray());
    }

    public static List<TblMWTxnRecoverHeader> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWTxnRecoverHeader> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWTxnRecoverHeader QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWTxnRecoverHeader> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWTxnRecoverHeader QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWTxnRecoverHeader item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWTxnRecoverHeader QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWTxnRecoverHeader QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWTxnRecoverHeader item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWTxnRecoverHeader item) {
        return Insert(dcf,
                item.RecoHeaderId,
                item.TxnNum,
                item.CarCode,
                item.Driver,
                item.DriverCode,
                item.Inspector,
                item.InspectorCode,
                item.RecoMWSCode,
                item.RecoWSCode,
                item.RecoEmpyName,
                item.RecoEmpyCode,
                item.StratDate,
                item.EndDate,
                item.OperateType,
                item.TotalCrateQty,
                item.TotalSubWeight,
                item.TotalTxnWeight,
                item.CarDisId,
                item.Status
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int recoHeaderId,
            String txnNum,
            String carCode,
            String driver,
            String driverCode,
            String inspector,
            String inspectorCode,
            String recoMWSCode,
            String recoWSCode,
            String recoEmpyName,
            String recoEmpyCode,
            String stratDate,
            String endDate,
            String operateType,
            int totalCrateQty,
            decimal totalSubWeight,
            decimal totalTxnWeight,
            int carDisId,
            String status
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
        sum.Add(TblMWTxnRecoverHeader.getRecoHeaderIdColumn(), recoHeaderId);
        sum.Add(TblMWTxnRecoverHeader.getTxnNumColumn(), txnNum);
        sum.Add(TblMWTxnRecoverHeader.getCarCodeColumn(), carCode);
        sum.Add(TblMWTxnRecoverHeader.getDriverColumn(), driver);
        sum.Add(TblMWTxnRecoverHeader.getDriverCodeColumn(), driverCode);
        sum.Add(TblMWTxnRecoverHeader.getInspectorColumn(), inspector);
        sum.Add(TblMWTxnRecoverHeader.getInspectorCodeColumn(), inspectorCode);
        sum.Add(TblMWTxnRecoverHeader.getRecoMWSCodeColumn(), recoMWSCode);
        sum.Add(TblMWTxnRecoverHeader.getRecoWSCodeColumn(), recoWSCode);
        sum.Add(TblMWTxnRecoverHeader.getRecoEmpyNameColumn(), recoEmpyName);
        sum.Add(TblMWTxnRecoverHeader.getRecoEmpyCodeColumn(), recoEmpyCode);
        sum.Add(TblMWTxnRecoverHeader.getStratDateColumn(), stratDate);
        sum.Add(TblMWTxnRecoverHeader.getEndDateColumn(), endDate);
        sum.Add(TblMWTxnRecoverHeader.getOperateTypeColumn(), operateType);
        sum.Add(TblMWTxnRecoverHeader.getTotalCrateQtyColumn(), totalCrateQty);
        sum.Add(TblMWTxnRecoverHeader.getTotalSubWeightColumn(), totalSubWeight);
        sum.Add(TblMWTxnRecoverHeader.getTotalTxnWeightColumn(), totalTxnWeight);
        sum.Add(TblMWTxnRecoverHeader.getCarDisIdColumn(), carDisId);
        sum.Add(TblMWTxnRecoverHeader.getStatusColumn(), status);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWTxnRecoverHeader item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWTxnRecoverHeader.getRecoHeaderIdColumn(), item.RecoHeaderId);
        suc.Add(TblMWTxnRecoverHeader.getTxnNumColumn(), item.TxnNum);
        suc.Add(TblMWTxnRecoverHeader.getCarCodeColumn(), item.CarCode);
        suc.Add(TblMWTxnRecoverHeader.getDriverColumn(), item.Driver);
        suc.Add(TblMWTxnRecoverHeader.getDriverCodeColumn(), item.DriverCode);
        suc.Add(TblMWTxnRecoverHeader.getInspectorColumn(), item.Inspector);
        suc.Add(TblMWTxnRecoverHeader.getInspectorCodeColumn(), item.InspectorCode);
        suc.Add(TblMWTxnRecoverHeader.getRecoMWSCodeColumn(), item.RecoMWSCode);
        suc.Add(TblMWTxnRecoverHeader.getRecoWSCodeColumn(), item.RecoWSCode);
        suc.Add(TblMWTxnRecoverHeader.getRecoEmpyNameColumn(), item.RecoEmpyName);
        suc.Add(TblMWTxnRecoverHeader.getRecoEmpyCodeColumn(), item.RecoEmpyCode);
        suc.Add(TblMWTxnRecoverHeader.getStratDateColumn(), item.StratDate);
        suc.Add(TblMWTxnRecoverHeader.getEndDateColumn(), item.EndDate);
        suc.Add(TblMWTxnRecoverHeader.getOperateTypeColumn(), item.OperateType);
        suc.Add(TblMWTxnRecoverHeader.getTotalCrateQtyColumn(), item.TotalCrateQty);
        suc.Add(TblMWTxnRecoverHeader.getTotalSubWeightColumn(), item.TotalSubWeight);
        suc.Add(TblMWTxnRecoverHeader.getTotalTxnWeightColumn(), item.TotalTxnWeight);
        suc.Add(TblMWTxnRecoverHeader.getCarDisIdColumn(), item.CarDisId);
        suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), item.Status);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWTxnRecoverHeader.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
