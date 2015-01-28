package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWTxnRecoverHeader extends BaseDataModule {
    private static String TableName = "MWTxnRecoverHeader";
    public TblMWTxnRecoverHeader(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"RecoHeaderId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TxnNum",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"CarCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Driver",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"DriverCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Inspector",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"InspectorCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"RecoMWSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"RecoWSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"RecoEmpyName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"RecoEmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"StratDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"EndDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"OperateType",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"TotalCrateQty",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TotalSubWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"TotalTxnWeight",DataColumnType.DECIMAL,10),
        new DataColumnInfo(false,true,false,false,"CarDisId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getRecoHeaderIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getTxnNumColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getCarCodeColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getDriverColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getDriverCodeColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getInspectorColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getInspectorCodeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getRecoMWSCodeColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getRecoWSCodeColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getRecoEmpyNameColumn(){
        return Columns[9];
    }
    public static DataColumnInfo getRecoEmpyCodeColumn(){
        return Columns[10];
    }
    public static DataColumnInfo getStratDateColumn(){
        return Columns[11];
    }
    public static DataColumnInfo getEndDateColumn(){
        return Columns[12];
    }
    public static DataColumnInfo getOperateTypeColumn(){
        return Columns[13];
    }
    public static DataColumnInfo getTotalCrateQtyColumn(){
        return Columns[14];
    }
    public static DataColumnInfo getTotalSubWeightColumn(){
        return Columns[15];
    }
    public static DataColumnInfo getTotalTxnWeightColumn(){
        return Columns[16];
    }
    public static DataColumnInfo getCarDisIdColumn(){
        return Columns[17];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[18];
    }

    public int RecoHeaderId = 0;
    public String TxnNum = "";
    public String CarCode = "";
    public String Driver = "";
    public String DriverCode = "";
    public String Inspector = "";
    public String InspectorCode = "";
    public String RecoMWSCode = "";
    public String RecoWSCode = "";
    public String RecoEmpyName = "";
    public String RecoEmpyCode = "";
    public String StratDate = "";
    public String EndDate = "";
    public String OperateType = "";
    public int TotalCrateQty = 0;
    public decimal TotalSubWeight = 0;
    public decimal TotalTxnWeight = 0;
    public int CarDisId = 0;
    public String Status = "";

    public int getRecoHeaderId() {
        return  RecoHeaderId;
    }
    public void setRecoHeaderId(int RecoHeaderId) {
        this.RecoHeaderId = RecoHeaderId;
    }
    public String getTxnNum() {
        return  TxnNum;
    }
    public void setTxnNum(String TxnNum) {
        this.TxnNum = TxnNum;
    }
    public String getCarCode() {
        return  CarCode;
    }
    public void setCarCode(String CarCode) {
        this.CarCode = CarCode;
    }
    public String getDriver() {
        return  Driver;
    }
    public void setDriver(String Driver) {
        this.Driver = Driver;
    }
    public String getDriverCode() {
        return  DriverCode;
    }
    public void setDriverCode(String DriverCode) {
        this.DriverCode = DriverCode;
    }
    public String getInspector() {
        return  Inspector;
    }
    public void setInspector(String Inspector) {
        this.Inspector = Inspector;
    }
    public String getInspectorCode() {
        return  InspectorCode;
    }
    public void setInspectorCode(String InspectorCode) {
        this.InspectorCode = InspectorCode;
    }
    public String getRecoMWSCode() {
        return  RecoMWSCode;
    }
    public void setRecoMWSCode(String RecoMWSCode) {
        this.RecoMWSCode = RecoMWSCode;
    }
    public String getRecoWSCode() {
        return  RecoWSCode;
    }
    public void setRecoWSCode(String RecoWSCode) {
        this.RecoWSCode = RecoWSCode;
    }
    public String getRecoEmpyName() {
        return  RecoEmpyName;
    }
    public void setRecoEmpyName(String RecoEmpyName) {
        this.RecoEmpyName = RecoEmpyName;
    }
    public String getRecoEmpyCode() {
        return  RecoEmpyCode;
    }
    public void setRecoEmpyCode(String RecoEmpyCode) {
        this.RecoEmpyCode = RecoEmpyCode;
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
    public String getOperateType() {
        return  OperateType;
    }
    public void setOperateType(String OperateType) {
        this.OperateType = OperateType;
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
    public int getCarDisId() {
        return  CarDisId;
    }
    public void setCarDisId(int CarDisId) {
        this.CarDisId = CarDisId;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }


    public static final String OPERATETYPE_ENUM_ToInventory = "I";//回收入库操作;
    public static final String OPERATETYPE_ENUM_ToDestroy = "D";//回收处置操作;
    public static final String STATUS_ENUM_Process = "P";//操作中;
    public static final String STATUS_ENUM_Complete = "C";//完成;
    public static final String STATUS_ENUM_Authorize = "A";//提交审核;
    public static final String STATUS_ENUM_Send = "S";//提交等待处理;

}
