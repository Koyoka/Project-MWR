package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWDepot extends BaseDataModule {
    private static String TableName = "MWDepot";
    public TblMWDepot(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"DeptCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Total",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"Desc",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getDeptCodeColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getTotalColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getDescColumn(){
        return Columns[2];
    }

    public String DeptCode = "";
    public int Total = 0;
    public String Desc = "";

    public String getDeptCode() {
        return  DeptCode;
    }
    public void setDeptCode(String DeptCode) {
        this.DeptCode = DeptCode;
    }
    public int getTotal() {
        return  Total;
    }
    public void setTotal(int Total) {
        this.Total = Total;
    }
    public String getDesc() {
        return  Desc;
    }
    public void setDesc(String Desc) {
        this.Desc = Desc;
    }



}
