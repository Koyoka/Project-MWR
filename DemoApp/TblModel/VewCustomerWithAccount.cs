using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace DemoApp.TblModel
{

    public class VewCustomerWithAccount : BaseDataModule
    {
         public static string getSql(){
             string[] sqlAry = new string[]{
                "SELECT arcustomer.*,arcustomeraccount.targetBuildCount,arcustomeraccount.addDate",
                "FROM arcustomer",
                "LEFT JOIN arcustomeraccount",
                "ON arcustomer.userName = arcustomeraccount.userName",
                ""
             };
             StringBuilder sb = new StringBuilder();
             foreach(string s in sqlAry){
                 sb.AppendLine(s);
                 
             }
             return sb.ToString();
         }

         public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
             new DataColumnInfo(true,false,false,false,"userName",SqlCommonFn.DataColumnType.STRING,128),
             new DataColumnInfo(false,true,false,true,"password",SqlCommonFn.DataColumnType.STRING,128),
             new DataColumnInfo(false,true,false,false,"nickName",SqlCommonFn.DataColumnType.STRING,128),
             new DataColumnInfo(false,true,false,false,"createDate",SqlCommonFn.DataColumnType.STRING,0),
             new DataColumnInfo(false,true,false,false,"userType",SqlCommonFn.DataColumnType.STRING,2),
             new DataColumnInfo(false,true,false,false,"sex",SqlCommonFn.DataColumnType.STRING,2),
             new DataColumnInfo(false,true,false,false,"age",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"interest",SqlCommonFn.DataColumnType.STRING,128),
             new DataColumnInfo(true,false,true,false,"accountId",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"targetBuildCount",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"addDate",SqlCommonFn.DataColumnType.STRING,0)
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

         public string userName = "";
         public string password = "";
         public string nickName = "";
         public DateTime createDate = DateTime.MinValue;
         public string userType = "";
         public string sex = "";
         public int age = 0;
         public string interest = "";
         public int accountId = 0;
         public int targetBuildCount = 0;
         public DateTime addDate = DateTime.MinValue;

         public string getUserName() {
             return  userName;
         }
         public void setUserName(string userName) {
             this.userName = userName;
         }
         public string getPassword() {
             return  password;
         }
         public void setPassword(string password) {
             this.password = password;
         }
         public string getNickName() {
             return  nickName;
         }
         public void setNickName(string nickName) {
             this.nickName = nickName;
         }
         public DateTime getCreateDate() {
             return  createDate;
         }
         public void setCreateDate(DateTime createDate) {
             this.createDate = createDate;
         }
         public string getUserType() {
             return  userType;
         }
         public void setUserType(string userType) {
             this.userType = userType;
         }
         public string getSex() {
             return  sex;
         }
         public void setSex(string sex) {
             this.sex = sex;
         }
         public int getAge() {
             return  age;
         }
         public void setAge(int age) {
             this.age = age;
         }
         public string getInterest() {
             return  interest;
         }
         public void setInterest(string interest) {
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
         public DateTime getAddDate() {
             return  addDate;
         }
         public void setAddDate(DateTime addDate) {
             this.addDate = addDate;
         }


         public const string USERTYPE_ENUM_PER = "2";//个人用户;
         public const string USERTYPE_ENUM_BUS = "1";//企业用户;
         public const string SEX_ENUM_Male = "M";//男 ;
         public const string SEX_ENUM_Female = "F";//女;
     }
}
