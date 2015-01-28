package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWUserPermission extends BaseDataModule {
    private static String TableName = "MWUserPermission";
    public TblMWUserPermission(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"id",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"UserGroupId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"FuncGroupId",DataColumnType.INT,10)
    };

    public static DataColumnInfo getIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getUserGroupIdColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getFuncGroupIdColumn(){
        return Columns[2];
    }

    public int id = 0;
    public int UserGroupId = 0;
    public int FuncGroupId = 0;

    public int getId() {
        return  id;
    }
    public void setId(int id) {
        this.id = id;
    }
    public int getUserGroupId() {
        return  UserGroupId;
    }
    public void setUserGroupId(int UserGroupId) {
        this.UserGroupId = UserGroupId;
    }
    public int getFuncGroupId() {
        return  FuncGroupId;
    }
    public void setFuncGroupId(int FuncGroupId) {
        this.FuncGroupId = FuncGroupId;
    }



}
