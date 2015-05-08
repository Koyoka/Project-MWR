package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWSynclog extends BaseDataModule {
    private static String TableName = "MWSynclog";
    public TblMWSynclog(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"SyncDateTime",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"Remark",DataColumnType.STRING,128)
    };

    public static DataColumnInfo getSyncDateTimeColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getRemarkColumn(){
        return Columns[2];
    }

    public String SyncDateTime = "";
    public String Status = "";
    public String Remark = "";

    public String getSyncDateTime() {
        return  SyncDateTime;
    }
    public void setSyncDateTime(String SyncDateTime) {
        this.SyncDateTime = SyncDateTime;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }
    public String getRemark() {
        return  Remark;
    }
    public void setRemark(String Remark) {
        this.Remark = Remark;
    }


    public static final String STATUS_ENUM_Complete = "C";//同步完成;
    public static final String STATUS_ENUM_Error = "E";//同步出错;

}
