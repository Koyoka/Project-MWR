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

public class TblMWCarDispatchCtrl extends BaseDataCtrl {

    public static List<TblMWCarDispatch> QueryPage(DataCtrlInfo dcf,SqlQueryMng sqm,int page,int pageSize){
        List<TblMWCarDispatch> itemList = null;
        try{
            sqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
            String sql = sqm.getPageSql(page, pageSize);
            SqlCommonFn.DebugLog(sql);
            itemList = SqlDBMng.getInstance().query(sql, TblMWCarDispatch.class,sqm.getParamsArray());
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

    public static List<TblMWCarDispatch> QueryMore(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryMore(sqm);
    }

    public static List<TblMWCarDispatch> QueryMore(DataCtrlInfo dcf,SqlWhere sw) {

        List<TblMWCarDispatch> itemList = null;
        try {
            itemList = QueryMore(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static List<TblMWCarDispatch> QueryMore(SqlQueryMng sqm) throws Exception {
        sqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
        String sql = sqm.getSql();
        SqlCommonFn.DebugLog(sql);//System.out.println(sql);
        return SqlDBMng.getInstance().query(sql, TblMWCarDispatch.class,sqm.getParamsArray());
    }

    public static List<TblMWCarDispatch> QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm){
        List<TblMWCarDispatch> itemList = null;
        try {
            itemList = QueryMore(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return itemList;
    }

    public static TblMWCarDispatch QueryOne(SqlQueryMng sqm) throws Exception {
        List<TblMWCarDispatch> itemList = QueryMore(sqm);
        if(itemList.size() > 0){
            return itemList.get(0);
        }
        return null;
    }

    public static TblMWCarDispatch QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm) {
        TblMWCarDispatch item = null;
        try {
            item = QueryOne(sqm);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }
    public static TblMWCarDispatch QueryOne(SqlWhere sw) throws Exception {
        SqlQueryMng sqm = new SqlQueryMng();
        sqm.Condition.Where.AddWhere(sw);
        return QueryOne(sqm);
    }

    public static TblMWCarDispatch QueryOne(DataCtrlInfo dcf,SqlWhere sw) {
        TblMWCarDispatch item = null;
        try {
            item = QueryOne(sw);
            dcf.set(true, "");
        } catch (Exception e) {
            dcf.set(false, e.getMessage());
        }
        return item;
    }

    public static int Insert(DataCtrlInfo dcf,TblMWCarDispatch item) {
        return Insert(dcf,
                item.CarDisId,
                item.CarCode,
                item.Driver,
                item.DriverCode,
                item.Inspector,
                item.InspectorCode,
                item.RecoMWSCode,
                item.OutDate,
                item.InDate,
                item.Status
                );
    }


    public static int Insert(DataCtrlInfo dcf,
            int carDisId,
            String carCode,
            String driver,
            String driverCode,
            String inspector,
            String inspectorCode,
            String recoMWSCode,
            String outDate,
            String inDate,
            String status
            ) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWCarDispatch.getFormatTableName());
        sum.Add(TblMWCarDispatch.getCarDisIdColumn(), carDisId);
        sum.Add(TblMWCarDispatch.getCarCodeColumn(), carCode);
        sum.Add(TblMWCarDispatch.getDriverColumn(), driver);
        sum.Add(TblMWCarDispatch.getDriverCodeColumn(), driverCode);
        sum.Add(TblMWCarDispatch.getInspectorColumn(), inspector);
        sum.Add(TblMWCarDispatch.getInspectorCodeColumn(), inspectorCode);
        sum.Add(TblMWCarDispatch.getRecoMWSCodeColumn(), recoMWSCode);
        sum.Add(TblMWCarDispatch.getOutDateColumn(), outDate);
        sum.Add(TblMWCarDispatch.getInDateColumn(), inDate);
        sum.Add(TblMWCarDispatch.getStatusColumn(), status);
        String sql = sum.getInsertSql();
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Update(DataCtrlInfo dcf,TblMWCarDispatch item,SqlWhere sw) {
        SqlUpdateColumn suc = new SqlUpdateColumn();
        suc.Add(TblMWCarDispatch.getCarDisIdColumn(), item.CarDisId);
        suc.Add(TblMWCarDispatch.getCarCodeColumn(), item.CarCode);
        suc.Add(TblMWCarDispatch.getDriverColumn(), item.Driver);
        suc.Add(TblMWCarDispatch.getDriverCodeColumn(), item.DriverCode);
        suc.Add(TblMWCarDispatch.getInspectorColumn(), item.Inspector);
        suc.Add(TblMWCarDispatch.getInspectorCodeColumn(), item.InspectorCode);
        suc.Add(TblMWCarDispatch.getRecoMWSCodeColumn(), item.RecoMWSCode);
        suc.Add(TblMWCarDispatch.getOutDateColumn(), item.OutDate);
        suc.Add(TblMWCarDispatch.getInDateColumn(), item.InDate);
        suc.Add(TblMWCarDispatch.getStatusColumn(), item.Status);
        return Update(dcf,suc,sw);
    }

    public static int Update(DataCtrlInfo dcf,SqlUpdateColumn suc,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWCarDispatch.getFormatTableName());
        String sql = sum.getUpdateSql(suc,sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }


    public static int Delete(DataCtrlInfo dcf,SqlWhere sw) {
        SqlUpdateMng sum = new SqlUpdateMng();
        sum.setQueryTableName(TblMWCarDispatch.getFormatTableName());
        String sql = sum.getDeleteSql(sw);
        return doUpdateCtrl(dcf,sql,sum.ErrMsg);
    }



}
