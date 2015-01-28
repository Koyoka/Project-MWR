package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblSystemNextId extends BaseDataModule {
    private static String TableName = "SystemNextId";
    public TblSystemNextId(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"IdName",DataColumnType.STRING,50),
        new DataColumnInfo(false,true,false,false,"MinValue",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"Increment",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"MaxValue",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"IdValue",DataColumnType.INT,10)
    };

    public static DataColumnInfo getIdNameColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getMinValueColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getIncrementColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getMaxValueColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getIdValueColumn(){
        return Columns[4];
    }

    public String IdName = "";
    public int MinValue = 0;
    public int Increment = 0;
    public int MaxValue = 0;
    public int IdValue = 0;

    public String getIdName() {
        return  IdName;
    }
    public void setIdName(String IdName) {
        this.IdName = IdName;
    }
    public int getMinValue() {
        return  MinValue;
    }
    public void setMinValue(int MinValue) {
        this.MinValue = MinValue;
    }
    public int getIncrement() {
        return  Increment;
    }
    public void setIncrement(int Increment) {
        this.Increment = Increment;
    }
    public int getMaxValue() {
        return  MaxValue;
    }
    public void setMaxValue(int MaxValue) {
        this.MaxValue = MaxValue;
    }
    public int getIdValue() {
        return  IdValue;
    }
    public void setIdValue(int IdValue) {
        this.IdValue = IdValue;
    }



}
