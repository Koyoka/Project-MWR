package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblSysLog extends BaseDataModule {
    private static String TableName = "SysLog";
    public TblSysLog(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"LogId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"Desc",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"Remark",DataColumnType.STRING,65535),
        new DataColumnInfo(false,true,false,false,"LogDate",DataColumnType.STRING,0)
    };

    public static DataColumnInfo getLogIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getDescColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getRemarkColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getLogDateColumn(){
        return Columns[3];
    }

    public int LogId = 0;
    public String Desc = "";
    public String Remark = "";
    public String LogDate = "";

    public int getLogId() {
        return  LogId;
    }
    public void setLogId(int LogId) {
        this.LogId = LogId;
    }
    public String getDesc() {
        return  Desc;
    }
    public void setDesc(String Desc) {
        this.Desc = Desc;
    }
    public String getRemark() {
        return  Remark;
    }
    public void setRemark(String Remark) {
        this.Remark = Remark;
    }
    public String getLogDate() {
        return  LogDate;
    }
    public void setLogDate(String LogDate) {
        this.LogDate = LogDate;
    }



}
