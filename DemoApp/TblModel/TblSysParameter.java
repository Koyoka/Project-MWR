package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblSysParameter extends BaseDataModule {
    private static String TableName = "SysParameter";
    public TblSysParameter(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"ParameterName",DataColumnType.STRING,128),
        new DataColumnInfo(false,true,false,false,"ParameterValue",DataColumnType.STRING,128),
        new DataColumnInfo(false,true,false,false,"Remark",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getParameterNameColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getParameterValueColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getRemarkColumn(){
        return Columns[2];
    }

    public String ParameterName = "";
    public String ParameterValue = "";
    public String Remark = "";

    public String getParameterName() {
        return  ParameterName;
    }
    public void setParameterName(String ParameterName) {
        this.ParameterName = ParameterName;
    }
    public String getParameterValue() {
        return  ParameterValue;
    }
    public void setParameterValue(String ParameterValue) {
        this.ParameterValue = ParameterValue;
    }
    public String getRemark() {
        return  Remark;
    }
    public void setRemark(String Remark) {
        this.Remark = Remark;
    }



}
