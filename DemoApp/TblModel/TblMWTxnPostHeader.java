package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWTxnPostHeader extends BaseDataModule {
    private static String TableName = "MWTxnPostHeader";
    public TblMWTxnPostHeader(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"PostHeaderId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TxnNum",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"PostWSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"PostEmpyName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"PostEmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"StratDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"EndDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"PostType",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"TotalCrateQty",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TotalSubWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"TotalTxnWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getPostHeaderIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getTxnNumColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getPostWSCodeColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getPostEmpyNameColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getPostEmpyCodeColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getStratDateColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getEndDateColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getPostTypeColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getTotalCrateQtyColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getTotalSubWeightColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getTotalTxnWeightColumn(){
        return Columns[10];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[11];
    }

    public int PostHeaderId = 0;
    public String TxnNum = "";
    public String PostWSCode = "";
    public String PostEmpyName = "";
    public String PostEmpyCode = "";
    public String StratDate = "";
    public String EndDate = "";
    public String PostType = "";
    public int TotalCrateQty = 0;
    public decimal TotalSubWeight = 0;
    public decimal TotalTxnWeight = 0;
    public String Status = "";

    public int getPostHeaderId() {
        return  PostHeaderId;
    }
    public void setPostHeaderId(int PostHeaderId) {
        this.PostHeaderId = PostHeaderId;
    }
    public String getTxnNum() {
        return  TxnNum;
    }
    public void setTxnNum(String TxnNum) {
        this.TxnNum = TxnNum;
    }
    public String getPostWSCode() {
        return  PostWSCode;
    }
    public void setPostWSCode(String PostWSCode) {
        this.PostWSCode = PostWSCode;
    }
    public String getPostEmpyName() {
        return  PostEmpyName;
    }
    public void setPostEmpyName(String PostEmpyName) {
        this.PostEmpyName = PostEmpyName;
    }
    public String getPostEmpyCode() {
        return  PostEmpyCode;
    }
    public void setPostEmpyCode(String PostEmpyCode) {
        this.PostEmpyCode = PostEmpyCode;
    }
    public String getStratDate() {
        return  StratDate;
    }
    public void setStratDate(String StratDate) {
        this.StratDate = StratDate;
    }
    public String getEndDate() {
        return  EndDate;
    }
    public void setEndDate(String EndDate) {
        this.EndDate = EndDate;
    }
    public String getPostType() {
        return  PostType;
    }
    public void setPostType(String PostType) {
        this.PostType = PostType;
    }
    public int getTotalCrateQty() {
        return  TotalCrateQty;
    }
    public void setTotalCrateQty(int TotalCrateQty) {
        this.TotalCrateQty = TotalCrateQty;
    }
    public decimal getTotalSubWeight() {
        return  TotalSubWeight;
    }
    public void setTotalSubWeight(decimal TotalSubWeight) {
        this.TotalSubWeight = TotalSubWeight;
    }
    public decimal getTotalTxnWeight() {
        return  TotalTxnWeight;
    }
    public void setTotalTxnWeight(decimal TotalTxnWeight) {
        this.TotalTxnWeight = TotalTxnWeight;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }



}
