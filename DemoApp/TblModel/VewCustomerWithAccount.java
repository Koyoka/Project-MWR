package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class VewCustomerWithAccount extends BaseDataModule {

    public VewCustomerWithAccount(){
    }
    public static String getSql(){
        String[] sqlAry = new String[]{
                "SELECT arcustomer.*,arcustomeraccount.targetBuildCount,arcustomeraccount.addDate",
                "FROM arcustomer",
                "LEFT JOIN arcustomeraccount",
                "ON arcustomer.userName = arcustomeraccount.userName",
                ""
        };
        StringBuilder sb = new StringBuilder();
        for(String s : sqlAry){
            sb.append(s);
            sb.append(" ");
        }
        return sb.toString();
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"userName",DataColumnType.STRING,128),
        new DataColumnInfo(false,true,false,true,"password",DataColumnType.STRING,128),
        new DataColumnInfo(false,true,false,false,"nickName",DataColumnType.STRING,128),
        new DataColumnInfo(false,true,false,false,"createDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"userType",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"sex",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"age",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"interest",DataColumnType.STRING,128),
        new DataColumnInfo(true,false,true,false,"accountId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"targetBuildCount",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"addDate",DataColumnType.STRING,0)
    };

    public static DataColumnInfo getUserNameColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getPasswordColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getNickNameColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getCreateDateColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getUserTypeColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getSexColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getAgeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getInterestColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getAccountIdColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getTargetBuildCountColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getAddDateColumn(){
        return Columns[10];
    }

    public String userName = "";
    public String password = "";
    public String nickName = "";
    public String createDate = "";
    public String userType = "";
    public String sex = "";
    public int age = 0;
    public String interest = "";
    public int accountId = 0;
    public int targetBuildCount = 0;
    public String addDate = "";

    public String getUserName() {
        return  userName;
    }
    public void setUserName(String userName) {
        this.userName = userName;
    }
    public String getPassword() {
        return  password;
    }
    public void setPassword(String password) {
        this.password = password;
    }
    public String getNickName() {
        return  nickName;
    }
    public void setNickName(String nickName) {
        this.nickName = nickName;
    }
    public String getCreateDate() {
        return  createDate;
    }
    public void setCreateDate(String createDate) {
        this.createDate = createDate;
    }
    public String getUserType() {
        return  userType;
    }
    public void setUserType(String userType) {
        this.userType = userType;
    }
    public String getSex() {
        return  sex;
    }
    public void setSex(String sex) {
        this.sex = sex;
    }
    public int getAge() {
        return  age;
    }
    public void setAge(int age) {
        this.age = age;
    }
    public String getInterest() {
        return  interest;
    }
    public void setInterest(String interest) {
        this.interest = interest;
    }
    public int getAccountId() {
        return  accountId;
    }
    public void setAccountId(int accountId) {
        this.accountId = accountId;
    }
    public int getTargetBuildCount() {
        return  targetBuildCount;
    }
    public void setTargetBuildCount(int targetBuildCount) {
        this.targetBuildCount = targetBuildCount;
    }
    public String getAddDate() {
        return  addDate;
    }
    public void setAddDate(String addDate) {
        this.addDate = addDate;
    }


    public static final String USERTYPE_ENUM_PER = "2";//个人用户;
    public static final String USERTYPE_ENUM_BUS = "1";//企业用户;
    public static final String SEX_ENUM_Male = "M";//男 ;
    public static final String SEX_ENUM_Female = "F";//女;

}
