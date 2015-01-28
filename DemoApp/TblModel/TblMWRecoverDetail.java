package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWRecoverDetail extends BaseDataModule {
    private static String TableName = "MWRecoverDetail";
    public TblMWRecoverDetail(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"RecoDtlId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"RecoHeaderId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"CrateCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"RecoNum",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Vendor",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"VendorCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Waste",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"WasteCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"RecoWeight",DataColumnType.FLOAT,12),
        new DataColumnInfo(false,true,false,false,"RecoDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"InvAuthId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getRecoDtlIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getRecoHeaderIdColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getCrateCodeColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getRecoNumColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getVendorColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getVendorCodeColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getWasteColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getWasteCodeColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getRecoWeightColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getRecoDateColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getInvAuthIdColumn(){
        return Columns[10];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[11];
    }

    public int RecoDtlId = 0;
    public int RecoHeaderId = 0;
    public String CrateCode = "";
    public String RecoNum = "";
    public String Vendor = "";
    public String VendorCode = "";
    public String Waste = "";
    public String WasteCode = "";
    public float RecoWeight = 0;
    public String RecoDate = "";
    public int InvAuthId = 0;
    public String Status = "";

    public int getRecoDtlId() {
        return  RecoDtlId;
    }
    public void setRecoDtlId(int RecoDtlId) {
        this.RecoDtlId = RecoDtlId;
    }
    public int getRecoHeaderId() {
        return  RecoHeaderId;
    }
    public void setRecoHeaderId(int RecoHeaderId) {
        this.RecoHeaderId = RecoHeaderId;
    }
    public String getCrateCode() {
        return  CrateCode;
    }
    public void setCrateCode(String CrateCode) {
        this.CrateCode = CrateCode;
    }
    public String getRecoNum() {
        return  RecoNum;
    }
    public void setRecoNum(String RecoNum) {
        this.RecoNum = RecoNum;
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
    public float getRecoWeight() {
        return  RecoWeight;
    }
    public void setRecoWeight(float RecoWeight) {
        this.RecoWeight = RecoWeight;
    }
    public String getRecoDate() {
        return  RecoDate;
    }
    public void setRecoDate(String RecoDate) {
        this.RecoDate = RecoDate;
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



}
