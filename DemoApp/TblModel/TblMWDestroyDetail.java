package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWDestroyDetail extends BaseDataModule {
    private static String TableName = "MWDestroyDetail";
    public TblMWDestroyDetail(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"DestroyDtlId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"CrateCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"DestHeaderId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"DestNum",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"DepotCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Vendor",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"VendorCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Waste",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"WasteCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"PostWeight",DataColumnType.FLOAT,12),
        new DataColumnInfo(false,true,false,false,"DestWeight",DataColumnType.FLOAT,12),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"PostHeaderId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"InvRecordId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"InvAuthId",DataColumnType.INT,10)
    };

    public static DataColumnInfo getDestroyDtlIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getCrateCodeColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getDestHeaderIdColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getDestNumColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getDepotCodeColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getVendorColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getVendorCodeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getWasteColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getWasteCodeColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getPostWeightColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getDestWeightColumn(){
        return Columns[10];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[11];
    }
    public static DataColumnInfo getPostHeaderIdColumn(){
        return Columns[12];
    }
    public static DataColumnInfo getInvRecordIdColumn(){
        return Columns[13];
    }
    public static DataColumnInfo getInvAuthIdColumn(){
        return Columns[14];
    }

    public int DestroyDtlId = 0;
    public String CrateCode = "";
    public int DestHeaderId = 0;
    public String DestNum = "";
    public String DepotCode = "";
    public String Vendor = "";
    public String VendorCode = "";
    public String Waste = "";
    public String WasteCode = "";
    public float PostWeight = 0;
    public float DestWeight = 0;
    public String Status = "";
    public int PostHeaderId = 0;
    public int InvRecordId = 0;
    public int InvAuthId = 0;

    public int getDestroyDtlId() {
        return  DestroyDtlId;
    }
    public void setDestroyDtlId(int DestroyDtlId) {
        this.DestroyDtlId = DestroyDtlId;
    }
    public String getCrateCode() {
        return  CrateCode;
    }
    public void setCrateCode(String CrateCode) {
        this.CrateCode = CrateCode;
    }
    public int getDestHeaderId() {
        return  DestHeaderId;
    }
    public void setDestHeaderId(int DestHeaderId) {
        this.DestHeaderId = DestHeaderId;
    }
    public String getDestNum() {
        return  DestNum;
    }
    public void setDestNum(String DestNum) {
        this.DestNum = DestNum;
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
    public float getPostWeight() {
        return  PostWeight;
    }
    public void setPostWeight(float PostWeight) {
        this.PostWeight = PostWeight;
    }
    public float getDestWeight() {
        return  DestWeight;
    }
    public void setDestWeight(float DestWeight) {
        this.DestWeight = DestWeight;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }
    public int getPostHeaderId() {
        return  PostHeaderId;
    }
    public void setPostHeaderId(int PostHeaderId) {
        this.PostHeaderId = PostHeaderId;
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



}
