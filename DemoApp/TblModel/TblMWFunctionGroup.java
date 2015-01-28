package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWFunctionGroup extends BaseDataModule {
    private static String TableName = "MWFunctionGroup";
    public TblMWFunctionGroup(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"FuncGroupId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"FuncGroupName",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getFuncGroupIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getFuncGroupNameColumn(){
        return Columns[1];
    }

    public int FuncGroupId = 0;
    public String FuncGroupName = "";

    public int getFuncGroupId() {
        return  FuncGroupId;
    }
    public void setFuncGroupId(int FuncGroupId) {
        this.FuncGroupId = FuncGroupId;
    }
    public String getFuncGroupName() {
        return  FuncGroupName;
    }
    public void setFuncGroupName(String FuncGroupName) {
        this.FuncGroupName = FuncGroupName;
    }



}
