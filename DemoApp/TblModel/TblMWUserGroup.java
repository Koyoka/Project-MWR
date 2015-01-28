package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWUserGroup extends BaseDataModule {
    private static String TableName = "MWUserGroup";
    public TblMWUserGroup(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"UserGroupId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"GroupName",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getUserGroupIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getGroupNameColumn(){
        return Columns[1];
    }

    public int UserGroupId = 0;
    public String GroupName = "";

    public int getUserGroupId() {
        return  UserGroupId;
    }
    public void setUserGroupId(int UserGroupId) {
        this.UserGroupId = UserGroupId;
    }
    public String getGroupName() {
        return  GroupName;
    }
    public void setGroupName(String GroupName) {
        this.GroupName = GroupName;
    }



}
