package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWFunctionGroupDetail extends BaseDataModule {
    private static String TableName = "MWFunctionGroupDetail";
    public TblMWFunctionGroupDetail(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"FuncGroupDtlId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"FuncGroupId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"FuncTag",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getFuncGroupDtlIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getFuncGroupIdColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getFuncTagColumn(){
        return Columns[2];
    }

    public int FuncGroupDtlId = 0;
    public int FuncGroupId = 0;
    public String FuncTag = "";

    public int getFuncGroupDtlId() {
        return  FuncGroupDtlId;
    }
    public void setFuncGroupDtlId(int FuncGroupDtlId) {
        this.FuncGroupDtlId = FuncGroupDtlId;
    }
    public int getFuncGroupId() {
        return  FuncGroupId;
    }
    public void setFuncGroupId(int FuncGroupId) {
        this.FuncGroupId = FuncGroupId;
    }
    public String getFuncTag() {
        return  FuncTag;
    }
    public void setFuncTag(String FuncTag) {
        this.FuncTag = FuncTag;
    }



}
