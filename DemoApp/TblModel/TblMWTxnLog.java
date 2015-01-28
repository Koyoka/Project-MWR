package com.yrkj.ar.bean;
import com.yrkj.lib.db.BaseDataModule;
import com.yrkj.lib.db.DataColumnInfo;
import com.yrkj.lib.db.SqlCommonFn;
import com.yrkj.lib.db.SqlCommonFn.DataColumnType;

public class TblMWTxnLog extends BaseDataModule {
    private static String TableName = "MWTxnLog";
    public TblMWTxnLog(){
    }
    public static String getFormatTableName(){
        return SqlCommonFn.FormatSqlTableNameString(TableName);
    }

    public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
        new DataColumnInfo(true,false,false,false,"TxnLogId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"TxnNum",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"TxnDetailId",DataColumnType.INT,10),
        new DataColumnInfo(false,true,false,false,"WSCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"EmpyName",DataColumnType.STRING,45),
        new DataColumnInfo(false,true,false,false,"EmpyCode",DataColumnType.STRING,20),
        new DataColumnInfo(false,true,false,false,"OptType",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"OptDate",DataColumnType.STRING,0),
        new DataColumnInfo(false,true,false,false,"TxnLogType",DataColumnType.STRING,2),
        new DataColumnInfo(false,true,false,false,"InvRecordId",DataColumnType.INT,10)
    };

    public static DataColumnInfo getTxnLogIdColumn(){
        return Columns[0];
    }
    public static DataColumnInfo getTxnNumColumn(){
        return Columns[1];
    }
    public static DataColumnInfo getTxnDetailIdColumn(){
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
    public static DataColumnInfo getOptTypeColumn(){
        return Columns[6];
    }
    public static DataColumnInfo getOptDateColumn(){
        return Columns[7];
    }
    public static DataColumnInfo getTxnLogTypeColumn(){
        return Columns[8];
    }
    public static DataColumnInfo getInvRecordIdColumn(){
        return Columns[9];
    }

    public int TxnLogId = 0;
    public String TxnNum = "";
    public int TxnDetailId = 0;
    public String WSCode = "";
    public String EmpyName = "";
    public String EmpyCode = "";
    public String OptType = "";
    public String OptDate = "";
    public String TxnLogType = "";
    public int InvRecordId = 0;

    public int getTxnLogId() {
        return  TxnLogId;
    }
    public void setTxnLogId(int TxnLogId) {
        this.TxnLogId = TxnLogId;
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
    public String getOptType() {
        return  OptType;
    }
    public void setOptType(String OptType) {
        this.OptType = OptType;
    }
    public String getOptDate() {
        return  OptDate;
    }
    public void setOptDate(String OptDate) {
        this.OptDate = OptDate;
    }
    public String getTxnLogType() {
        return  TxnLogType;
    }
    public void setTxnLogType(String TxnLogType) {
        this.TxnLogType = TxnLogType;
    }
    public int getInvRecordId() {
        return  InvRecordId;
    }
    public void setInvRecordId(int InvRecordId) {
        this.InvRecordId = InvRecordId;
    }


    public static final String OPTTYPE_ENUM_SubInventory = "SI";//1.提交入库 SC  submit inventory;
    public static final String OPTTYPE_ENUM_SubAuthorize = "SA";//2.提交审核 SA submit authorize;
    public static final String OPTTYPE_ENUM_AuthorizeInventory = "AI";//3.确认审核并入库 AC authorize inventory;
    public static final String TXNLOGTYPE_ENUM_Recover = "R";//回收入库交易;
    public static final String TXNLOGTYPE_ENUM_Post = "P";//出库交易;
    public static final String TXNLOGTYPE_ENUM_Destroy = "D";//处置销毁交易;

}
