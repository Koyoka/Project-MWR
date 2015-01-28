package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWWasteCategory extends BaseDataModule {
    private static String TableName = "MWWasteCategory";
    public TblMWWasteCategory(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"WasteCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Waste",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getWasteCodeColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getWasteColumn(){
        return Columns[1];
    }

    public String WasteCode = "";
    public String Waste = "";

    public String getWasteCode() {
        return  WasteCode;
    }
    public void setWasteCode(String WasteCode) {
        this.WasteCode = WasteCode;
    }
    public String getWaste() {
        return  Waste;
    }
    public void setWaste(String Waste) {
        this.Waste = Waste;
    }



}
