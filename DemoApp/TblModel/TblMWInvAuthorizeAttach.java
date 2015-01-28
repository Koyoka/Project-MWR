package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWInvAuthorizeAttach extends BaseDataModule {
    private static String TableName = "MWInvAuthorizeAttach";
    public TblMWInvAuthorizeAttach(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"InvAttachId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"InvAuthId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"Path",DataColumnType.STRING,128)
    };

    public static DataColumnInfo getInvAttachIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getInvAuthIdColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getPathColumn(){
        return Columns[2];
    }

    public int InvAttachId = 0;
    public int InvAuthId = 0;
    public String Path = "";

    public int getInvAttachId() {
        return  InvAttachId;
    }
    public void setInvAttachId(int InvAttachId) {
        this.InvAttachId = InvAttachId;
    }
    public int getInvAuthId() {
        return  InvAuthId;
    }
    public void setInvAuthId(int InvAuthId) {
        this.InvAuthId = InvAuthId;
    }
    public String getPath() {
        return  Path;
    }
    public void setPath(String Path) {
        this.Path = Path;
    }



}
