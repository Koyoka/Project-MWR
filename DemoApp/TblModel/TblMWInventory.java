package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWInventory extends BaseDataModule {
    private static String TableName = "MWInventory";
    public TblMWInventory(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"InvRecordId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"CrateCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"DepotCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Vendor",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"VendorCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Waste",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"WasteCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"RecoWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"InvWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"PostWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"DestWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"EntryDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,3),
        new DataColumnInfo(false,true,false,false,"DailyClose",DataColumnType.BOOLEAN,1)
    };

    public static DataColumnInfo getInvRecordIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getCrateCodeColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getDepotCodeColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getVendorColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getVendorCodeColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getWasteColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getWasteCodeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getRecoWeightColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getInvWeightColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getPostWeightColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getDestWeightColumn(){
        return Columns[10];
    }
    public static DataColumnInfo getEntryDateColumn(){
        return Columns[11];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[12];
    }
    public static DataColumnInfo getDailyCloseColumn(){
        return Columns[13];
    }

    public int InvRecordId = 0;
    public String CrateCode = "";
    public String DepotCode = "";
    public String Vendor = "";
    public String VendorCode = "";
    public String Waste = "";
    public String WasteCode = "";
    public decimal RecoWeight = 0;
    public decimal InvWeight = 0;
    public decimal PostWeight = 0;
    public decimal DestWeight = 0;
    public String EntryDate = "";
    public String Status = "";
    public boolean DailyClose = false;

    public int getInvRecordId() {
        return  InvRecordId;
    }
    public void setInvRecordId(int InvRecordId) {
        this.InvRecordId = InvRecordId;
    }
    public String getCrateCode() {
        return  CrateCode;
    }
    public void setCrateCode(String CrateCode) {
        this.CrateCode = CrateCode;
    }
    public String getDepotCode() {
        return  DepotCode;
    }
    public void setDepotCode(String DepotCode) {
        this.DepotCode = DepotCode;
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
    public decimal getRecoWeight() {
        return  RecoWeight;
    }
    public void setRecoWeight(decimal RecoWeight) {
        this.RecoWeight = RecoWeight;
    }
    public decimal getInvWeight() {
        return  InvWeight;
    }
    public void setInvWeight(decimal InvWeight) {
        this.InvWeight = InvWeight;
    }
    public decimal getPostWeight() {
        return  PostWeight;
    }
    public void setPostWeight(decimal PostWeight) {
        this.PostWeight = PostWeight;
    }
    public decimal getDestWeight() {
        return  DestWeight;
    }
    public void setDestWeight(decimal DestWeight) {
        this.DestWeight = DestWeight;
    }
    public String getEntryDate() {
        return  EntryDate;
    }
    public void setEntryDate(String EntryDate) {
        this.EntryDate = EntryDate;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }
    public boolean getDailyClose() {
        return  DailyClose;
    }
    public void setDailyClose(boolean DailyClose) {
        this.DailyClose = DailyClose;
    }


    public static final String STATUS_ENUM_Recovered = "RED"; //1.已入库 RED;
    public static final String STATUS_ENUM_Posted = "PED"; //2.已出库PED;
    public static final String STATUS_ENUM_Destroyed = "DED";//3.已销毁DED;
    public static final String STATUS_ENUM_Recovering = "RIN";//4.入库中RIN;
    public static final String STATUS_ENUM_Posting = "PIN";//5.出库中PIN;
    public static final String STATUS_ENUM_Destroying = "DIN";//6.销毁中DIN;

}
