package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWResidueInventory extends BaseDataModule {
    private static String TableName = "MWResidueInventory";
    public TblMWResidueInventory(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"ResdInvId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"InvWeight",DataColumnType.FLOAT,12),
        new DataColumnInfo(false,true,false,false,"EntryDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"HandlingDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"RecoWSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"RecoEmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"HandlingType",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getResdInvIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getInvWeightColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getEntryDateColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getHandlingDateColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getRecoWSCodeColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getRecoEmpyCodeColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getHandlingTypeColumn(){
        return Columns[6];
    }

    public int ResdInvId = 0;
    public float InvWeight = 0;
    public String EntryDate = "";
    public String HandlingDate = "";
    public String RecoWSCode = "";
    public String RecoEmpyCode = "";
    public String HandlingType = "";

    public int getResdInvId() {
        return  ResdInvId;
    }
    public void setResdInvId(int ResdInvId) {
        this.ResdInvId = ResdInvId;
    }
    public float getInvWeight() {
        return  InvWeight;
    }
    public void setInvWeight(float InvWeight) {
        this.InvWeight = InvWeight;
    }
    public String getEntryDate() {
        return  EntryDate;
    }
    public void setEntryDate(String EntryDate) {
        this.EntryDate = EntryDate;
    }
    public String getHandlingDate() {
        return  HandlingDate;
    }
    public void setHandlingDate(String HandlingDate) {
        this.HandlingDate = HandlingDate;
    }
    public String getRecoWSCode() {
        return  RecoWSCode;
    }
    public void setRecoWSCode(String RecoWSCode) {
        this.RecoWSCode = RecoWSCode;
    }
    public String getRecoEmpyCode() {
        return  RecoEmpyCode;
    }
    public void setRecoEmpyCode(String RecoEmpyCode) {
        this.RecoEmpyCode = RecoEmpyCode;
    }
    public String getHandlingType() {
        return  HandlingType;
    }
    public void setHandlingType(String HandlingType) {
        this.HandlingType = HandlingType;
    }



}
