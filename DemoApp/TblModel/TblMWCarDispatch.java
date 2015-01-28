package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWCarDispatch extends BaseDataModule {
    private static String TableName = "MWCarDispatch";
    public TblMWCarDispatch(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"CarDisId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"CarCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Driver",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"DriverCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Inspector",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"InspectorCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"RecoMWSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"OutDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"InDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"Status",DataColumnType.STRING,2)
    };

    public static DataColumnInfo getCarDisIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getCarCodeColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getDriverColumn(){
        return Columns[2];
    }
    public static DataColumnInfo getDriverCodeColumn(){
        return Columns[3];
    }
    public static DataColumnInfo getInspectorColumn(){
        return Columns[4];
    }
    public static DataColumnInfo getInspectorCodeColumn(){
        return Columns[5];
    }
    public static DataColumnInfo getRecoMWSCodeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getOutDateColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getInDateColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getStatusColumn(){
        return Columns[9];
    }

    public int CarDisId = 0;
    public String CarCode = "";
    public String Driver = "";
    public String DriverCode = "";
    public String Inspector = "";
    public String InspectorCode = "";
    public String RecoMWSCode = "";
    public String OutDate = "";
    public String InDate = "";
    public String Status = "";

    public int getCarDisId() {
        return  CarDisId;
    }
    public void setCarDisId(int CarDisId) {
        this.CarDisId = CarDisId;
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
    public String getOutDate() {
        return  OutDate;
    }
    public void setOutDate(String OutDate) {
        this.OutDate = OutDate;
    }
    public String getInDate() {
        return  InDate;
    }
    public void setInDate(String InDate) {
        this.InDate = InDate;
    }
    public String getStatus() {
        return  Status;
    }
    public void setStatus(String Status) {
        this.Status = Status;
    }


    public static final String STATUS_ENUM_ShiftStrat = "S";//班次开始了;
    public static final String STATUS_ENUM_ShiftEnd = "E";//班次完成了;

}
