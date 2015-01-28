package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWTxnDetail extends BaseDataModule {
    private static String TableName = "MWTxnDetail";
    public TblMWTxnDetail(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"TxnDetailId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TxnType",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"TxnNum",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"WSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"EmpyName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"EmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"CrateCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Vendor",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"VendorCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Waste",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"WasteCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"SubWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"TxnWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"EntryDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"InvRecordId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"InvAuthId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getTxnDetailIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getTxnTypeColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getTxnNumColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getWSCodeColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getEmpyNameColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getEmpyCodeColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getCrateCodeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getVendorColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getVendorCodeColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getWasteColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getWasteCodeColumn(){
        return Columns[10];
    }
    public static DataColumnInfo getSubWeightColumn(){
        return Columns[11];
    }
    public static DataColumnInfo getTxnWeightColumn(){
        return Columns[12];
    }
    public static DataColumnInfo getEntryDateColumn(){
        return Columns[13];
    }
    public static DataColumnInfo getInvRecordIdColumn(){
        return Columns[14];
    }
    public static DataColumnInfo getInvAuthIdColumn(){
        return Columns[15];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[16];
    }

    public int TxnDetailId = 0;
    public String TxnType = "";
    public String TxnNum = "";
    public String WSCode = "";
    public String EmpyName = "";
    public String EmpyCode = "";
    public String CrateCode = "";
    public String Vendor = "";
    public String VendorCode = "";
    public String Waste = "";
    public String WasteCode = "";
    public decimal SubWeight = 0;
    public decimal TxnWeight = 0;
    public String EntryDate = "";
    public int InvRecordId = 0;
    public int InvAuthId = 0;
    public String Status = "";

    public int getTxnDetailId() {
        return  TxnDetailId;
    }
    public void setTxnDetailId(int TxnDetailId) {
        this.TxnDetailId = TxnDetailId;
    }
    public String getTxnType() {
        return  TxnType;
    }
    public void setTxnType(String TxnType) {
        this.TxnType = TxnType;
    }
    public String getTxnNum() {
        return  TxnNum;
    }
    public void setTxnNum(String TxnNum) {
        this.TxnNum = TxnNum;
    }
    public String getWSCode() {
        return  WSCode;
    }
    public void setWSCode(String WSCode) {
        this.WSCode = WSCode;
    }
    public String getEmpyName() {
        return  EmpyName;
    }
    public void setEmpyName(String EmpyName) {
        this.EmpyName = EmpyName;
    }
    public String getEmpyCode() {
        return  EmpyCode;
    }
    public void setEmpyCode(String EmpyCode) {
        this.EmpyCode = EmpyCode;
    }
    public String getCrateCode() {
        return  CrateCode;
    }
    public void setCrateCode(String CrateCode) {
        this.CrateCode = CrateCode;
    }
    public String getVendor() {
        return  Vendor;
    }
    public void setVendor(String Vendor) {
        this.Vendor = Vendor;
    }
    public String getVendorCode() {
        return  VendorCode;
    }
    public void setVendorCode(String VendorCode) {
        this.VendorCode = VendorCode;
    }
    public String getWaste() {
        return  Waste;
    }
    public void setWaste(String Waste) {
        this.Waste = Waste;
    }
    public String getWasteCode() {
        return  WasteCode;
    }
    public void setWasteCode(String WasteCode) {
        this.WasteCode = WasteCode;
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
    public String getEntryDate() {
        return  EntryDate;
    }
    public void setEntryDate(String EntryDate) {
        this.EntryDate = EntryDate;
    }
    public int getInvRecordId() {
        return  InvRecordId;
    }
    public void setInvRecordId(int InvRecordId) {
        this.InvRecordId = InvRecordId;
    }
    public int getInvAuthId() {
        return  InvAuthId;
    }
    public void setInvAuthId(int InvAuthId) {
        this.InvAuthId = InvAuthId;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }


    public static final String TXNTYPE_ENUM_Recover = "R";//回收入库交易;
    public static final String TXNTYPE_ENUM_Post = "P";//出库交易;
    public static final String TXNTYPE_ENUM_Destroy = "D";//处置销毁交易;
    public static final String STATUS_ENUM_Complete = "C";//1.交易完成 ;
    public static final String STATUS_ENUM_Authorize = "A";//2.交易货箱审核中 ;
    public static final String STATUS_ENUM_Wait = "W";//3.交易货箱审核完成，等待确认;
    public static final String STATUS_ENUM_Process = "P";//交易处理中;

}
