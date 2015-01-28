package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWInvAuthorize extends BaseDataModule {
    private static String TableName = "MWInvAuthorize";
    public TblMWInvAuthorize(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"InvAuthId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TxnNum",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"TxnDetailId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"EmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"EmpyName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"WSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"AuthEmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"AuthEmpyName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"Remark",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"SubWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"TxnWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"DiffWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"EntryDate",DataColumnType.STRING,10),
        new DataColumnInfo(false,true,false,false,"CompDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getInvAuthIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getTxnNumColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getTxnDetailIdColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getEmpyCodeColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getEmpyNameColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getWSCodeColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getAuthEmpyCodeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getAuthEmpyNameColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getRemarkColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getSubWeightColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getTxnWeightColumn(){
        return Columns[10];
    }
    public static DataColumnInfo getDiffWeightColumn(){
        return Columns[11];
    }
    public static DataColumnInfo getEntryDateColumn(){
        return Columns[12];
    }
    public static DataColumnInfo getCompDateColumn(){
        return Columns[13];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[14];
    }

    public int InvAuthId = 0;
    public String TxnNum = "";
    public int TxnDetailId = 0;
    public String EmpyCode = "";
    public String EmpyName = "";
    public String WSCode = "";
    public String AuthEmpyCode = "";
    public String AuthEmpyName = "";
    public String Remark = "";
    public decimal SubWeight = 0;
    public decimal TxnWeight = 0;
    public decimal DiffWeight = 0;
    public String EntryDate = "";
    public String CompDate = "";
    public String Status = "";

    public int getInvAuthId() {
        return  InvAuthId;
    }
    public void setInvAuthId(int InvAuthId) {
        this.InvAuthId = InvAuthId;
    }
    public String getTxnNum() {
        return  TxnNum;
    }
    public void setTxnNum(String TxnNum) {
        this.TxnNum = TxnNum;
    }
    public int getTxnDetailId() {
        return  TxnDetailId;
    }
    public void setTxnDetailId(int TxnDetailId) {
        this.TxnDetailId = TxnDetailId;
    }
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
    public String getWSCode() {
        return  WSCode;
    }
    public void setWSCode(String WSCode) {
        this.WSCode = WSCode;
    }
    public String getAuthEmpyCode() {
        return  AuthEmpyCode;
    }
    public void setAuthEmpyCode(String AuthEmpyCode) {
        this.AuthEmpyCode = AuthEmpyCode;
    }
    public String getAuthEmpyName() {
        return  AuthEmpyName;
    }
    public void setAuthEmpyName(String AuthEmpyName) {
        this.AuthEmpyName = AuthEmpyName;
    }
    public String getRemark() {
        return  Remark;
    }
    public void setRemark(String Remark) {
        this.Remark = Remark;
    }
    public decimal getSubWeight() {
        return  SubWeight;
    }
    public void setSubWeight(decimal SubWeight) {
        this.SubWeight = SubWeight;
    }
    public decimal getTxnWeight() {
        return  TxnWeight;
    }
    public void setTxnWeight(decimal TxnWeight) {
        this.TxnWeight = TxnWeight;
    }
    public decimal getDiffWeight() {
        return  DiffWeight;
    }
    public void setDiffWeight(decimal DiffWeight) {
        this.DiffWeight = DiffWeight;
    }
    public String getEntryDate() {
        return  EntryDate;
    }
    public void setEntryDate(String EntryDate) {
        this.EntryDate = EntryDate;
    }
    public String getCompDate() {
        return  CompDate;
    }
    public void setCompDate(String CompDate) {
        this.CompDate = CompDate;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }



}
