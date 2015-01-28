package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWEmploy extends BaseDataModule {
    private static String TableName = "MWEmploy";
    public TblMWEmploy(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"EmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"EmpyName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"UserGroupId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"EmpyType",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"UserName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,true,"Password",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getEmpyCodeColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getEmpyNameColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getUserGroupIdColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getEmpyTypeColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getUserNameColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getPasswordColumn(){
        return Columns[5];
    }

    public String EmpyCode = "";
    public String EmpyName = "";
    public int UserGroupId = 0;
    public String EmpyType = "";
    public String UserName = "";
    public String Password = "";

    public String getEmpyCode() {
        return  EmpyCode;
    }
    public void setEmpyCode(String EmpyCode) {
        this.EmpyCode = EmpyCode;
    }
    public String getEmpyName() {
        return  EmpyName;
    }
    public void setEmpyName(String EmpyName) {
        this.EmpyName = EmpyName;
    }
    public int getUserGroupId() {
        return  UserGroupId;
    }
    public void setUserGroupId(int UserGroupId) {
        this.UserGroupId = UserGroupId;
    }
    public String getEmpyType() {
        return  EmpyType;
    }
    public void setEmpyType(String EmpyType) {
        this.EmpyType = EmpyType;
    }
    public String getUserName() {
        return  UserName;
    }
    public void setUserName(String UserName) {
        this.UserName = UserName;
    }
    public String getPassword() {
        return  Password;
    }
    public void setPassword(String Password) {
        this.Password = Password;
    }


    public static final String EMPYTYPE_ENUM_Driver = "D";//司机;
    public static final String EMPYTYPE_ENUM_Inspector = "I";//跟车员;
    public static final String EMPYTYPE_ENUM_WorkStation = "S";//工作站操作员;

}
