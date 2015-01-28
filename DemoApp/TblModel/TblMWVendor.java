package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWVendor extends BaseDataModule {
    private static String TableName = "MWVendor";
    public TblMWVendor(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"VendorCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Vendor",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"Address",DataColumnType.STRING,128)
    };

    public static DataColumnInfo getVendorCodeColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getVendorColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getAddressColumn(){
        return Columns[2];
    }

    public String VendorCode = "";
    public String Vendor = "";
    public String Address = "";

    public String getVendorCode() {
        return  VendorCode;
    }
    public void setVendorCode(String VendorCode) {
        this.VendorCode = VendorCode;
    }
    public String getVendor() {
        return  Vendor;
    }
    public void setVendor(String Vendor) {
        this.Vendor = Vendor;
    }
    public String getAddress() {
        return  Address;
    }
    public void setAddress(String Address) {
        this.Address = Address;
    }



}
