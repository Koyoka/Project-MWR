package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWCrate extends BaseDataModule {
    private static String TableName = "MWCrate";
    public TblMWCrate(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"CrateCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Desc",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getCrateCodeColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getDescColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[2];
    }

    public String CrateCode = "";
    public String Desc = "";
    public String Status = "";

    public String getCrateCode() {
        return  CrateCode;
    }
    public void setCrateCode(String CrateCode) {
        this.CrateCode = CrateCode;
    }
    public String getDesc() {
        return  Desc;
    }
    public void setDesc(String Desc) {
        this.Desc = Desc;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }


    public static final String STATUS_ENUM_Active = "A";//使用中;
    public static final String STATUS_ENUM_Void = "V";//作废;

}
