package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWTxnDestroyHeader extends BaseDataModule {
    private static String TableName = "MWTxnDestroyHeader";
    public TblMWTxnDestroyHeader(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"DestHeaderId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TxnNum",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"StratDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"EndDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"DestWSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"DestEmpyName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"DestEmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"TotalCrateQty",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TotalSubWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"TotalTxnWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getDestHeaderIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getTxnNumColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getStratDateColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getEndDateColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getDestWSCodeColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getDestEmpyNameColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getDestEmpyCodeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getTotalCrateQtyColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getTotalSubWeightColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getTotalTxnWeightColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[10];
    }

    public int DestHeaderId = 0;
    public String TxnNum = "";
    public String StratDate = "";
    public String EndDate = "";
    public String DestWSCode = "";
    public String DestEmpyName = "";
    public String DestEmpyCode = "";
    public int TotalCrateQty = 0;
    public decimal TotalSubWeight = 0;
    public decimal TotalTxnWeight = 0;
    public String Status = "";

    public int getDestHeaderId() {
        return  DestHeaderId;
    }
    public void setDestHeaderId(int DestHeaderId) {
        this.DestHeaderId = DestHeaderId;
    }
    public String getTxnNum() {
        return  TxnNum;
    }
    public void setTxnNum(String TxnNum) {
        this.TxnNum = TxnNum;
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
    public String getDestWSCode() {
        return  DestWSCode;
    }
    public void setDestWSCode(String DestWSCode) {
        this.DestWSCode = DestWSCode;
    }
    public String getDestEmpyName() {
        return  DestEmpyName;
    }
    public void setDestEmpyName(String DestEmpyName) {
        this.DestEmpyName = DestEmpyName;
    }
    public String getDestEmpyCode() {
        return  DestEmpyCode;
    }
    public void setDestEmpyCode(String DestEmpyCode) {
        this.DestEmpyCode = DestEmpyCode;
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
