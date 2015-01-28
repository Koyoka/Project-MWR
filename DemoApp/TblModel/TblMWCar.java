package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWCar extends BaseDataModule {
    private static String TableName = "MWCar";
    public TblMWCar(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"CarCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"Desc",DataColumnType.STRING,45)
    };

    public static DataColumnInfo getCarCodeColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getDescColumn(){
        return Columns[1];
    }

    public String CarCode = "";
    public String Desc = "";

    public String getCarCode() {
        return  CarCode;
    }
    public void setCarCode(String CarCode) {
        this.CarCode = CarCode;
    }
    public String getDesc() {
        return  Desc;
    }
    public void setDesc(String Desc) {
        this.Desc = Desc;
    }



}
