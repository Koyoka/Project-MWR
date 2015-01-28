package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWFunction extends BaseDataModule {
    private static String TableName = "MWFunction";
    public TblMWFunction(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"FuncTag",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"FuncName",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getFuncTagColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getFuncNameColumn(){
        return Columns[1];
    }

    public String FuncTag = "";
    public String FuncName = "";

    public String getFuncTag() {
        return  FuncTag;
    }
    public void setFuncTag(String FuncTag) {
        this.FuncTag = FuncTag;
    }
    public String getFuncName() {
        return  FuncName;
    }
    public void setFuncName(String FuncName) {
        this.FuncName = FuncName;
    }



}
