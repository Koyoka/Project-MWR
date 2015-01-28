package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWWorkStation extends BaseDataModule {
    private static String TableName = "MWWorkStation";
    public TblMWWorkStation(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"WSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Desc",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"WSType",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"AccessKey",DataColumnType.STRING,40),
        new DataColumnInfo(false,true,false,false,"SecretKey",DataColumnType.STRING,40)
    };

    public static DataColumnInfo getWSCodeColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getDescColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getWSTypeColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getAccessKeyColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getSecretKeyColumn(){
        return Columns[4];
    }

    public String WSCode = "";
    public String Desc = "";
    public String WSType = "";
    public String AccessKey = "";
    public String SecretKey = "";

    public String getWSCode() {
        return  WSCode;
    }
    public void setWSCode(String WSCode) {
        this.WSCode = WSCode;
    }
    public String getDesc() {
        return  Desc;
    }
    public void setDesc(String Desc) {
        this.Desc = Desc;
    }
    public String getWSType() {
        return  WSType;
    }
    public void setWSType(String WSType) {
        this.WSType = WSType;
    }
    public String getAccessKey() {
        return  AccessKey;
    }
    public void setAccessKey(String AccessKey) {
        this.AccessKey = AccessKey;
    }
    public String getSecretKey() {
        return  SecretKey;
    }
    public void setSecretKey(String SecretKey) {
        this.SecretKey = SecretKey;
    }


    public static final String WSTYPE_ENUM_InvWorkStation = "I";//出入库工作站;
    public static final String WSTYPE_ENUM_DesWorkStation = "D";//处置工作站;
    public static final String WSTYPE_ENUM_MobWorkStation = "M";//手机终端;

}
