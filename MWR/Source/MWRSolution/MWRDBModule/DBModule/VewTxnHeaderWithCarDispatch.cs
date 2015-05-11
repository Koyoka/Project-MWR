using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class VewTxnHeaderWithCarDispatch : BaseDataModule
    {
         public static string getSql(){
             string[] sqlAry = new string[]{
                "SELECT `mwtxnrecoverheader`.*,`mwcardispatch`.`OutDate`,`mwcardispatch`.`InDate`,`mwcardispatch`.`Status` AS `DisStatus`",
                "FROM `mwtxnrecoverheader` LEFT JOIN `mwcardispatch`",
                "ON `mwtxnrecoverheader`.`CarDisId` = `mwcardispatch`.`CarDisId`",
                ""
             };
             StringBuilder sb = new StringBuilder();
             foreach(string s in sqlAry){
                 sb.AppendLine(s);
                 
             }
             return sb.ToString();
         }

         public static DataColumnInfo[] Columns = 
            new DataColumnInfo[]{
             new DataColumnInfo(true,false,false,false,"RecoHeaderId",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"CarCode",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"Driver",SqlCommonFn.DataColumnType.STRING,45),
             new DataColumnInfo(false,true,false,false,"DriverCode",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"Inspector",SqlCommonFn.DataColumnType.STRING,45),
             new DataColumnInfo(false,true,false,false,"InspectorCode",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"RecoMWSCode",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"RecoWSCode",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"RecoEmpyName",SqlCommonFn.DataColumnType.STRING,45),
             new DataColumnInfo(false,true,false,false,"RecoEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
             new DataColumnInfo(false,true,false,false,"StratDate",SqlCommonFn.DataColumnType.STRING,0),
             new DataColumnInfo(false,true,false,false,"EndDate",SqlCommonFn.DataColumnType.STRING,0),
             new DataColumnInfo(false,true,false,false,"OperateType",SqlCommonFn.DataColumnType.STRING,2),
             new DataColumnInfo(false,true,false,false,"TotalCrateQty",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"TotalSubWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
             new DataColumnInfo(false,true,false,false,"TotalTxnWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
             new DataColumnInfo(false,true,false,false,"CarDisId",SqlCommonFn.DataColumnType.INT,10),
             new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
             new DataColumnInfo(false,true,false,false,"OutDate",SqlCommonFn.DataColumnType.STRING,0),
             new DataColumnInfo(false,true,false,false,"InDate",SqlCommonFn.DataColumnType.STRING,0),
             new DataColumnInfo(false,true,false,false,"DisStatus",SqlCommonFn.DataColumnType.STRING,2)
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
         public static DataColumnInfo getOutDateColumn(){
             return Columns[19];
         }
         public static DataColumnInfo getInDateColumn(){
             return Columns[20];
         }
         public static DataColumnInfo getDisStatusColumn(){
             return Columns[21];
         }
        private int _RecoHeaderId = 0;
        private string _TxnNum = "";
        private string _CarCode = "";
        private string _Driver = "";
        private string _DriverCode = "";
        private string _Inspector = "";
        private string _InspectorCode = "";
        private string _RecoMWSCode = "";
        private string _RecoWSCode = "";
        private string _RecoEmpyName = "";
        private string _RecoEmpyCode = "";
        private DateTime _StratDate = DateTime.MinValue;
        private DateTime _EndDate = DateTime.MinValue;
        private string _OperateType = "";
        private int _TotalCrateQty = 0;
        private decimal _TotalSubWeight = 0;
        private decimal _TotalTxnWeight = 0;
        private int _CarDisId = 0;
        private string _Status = "";
        private DateTime _OutDate = DateTime.MinValue;
        private DateTime _InDate = DateTime.MinValue;
        private string _DisStatus = "";

        public int RecoHeaderId
        {
            get
            {
                return _RecoHeaderId;
            }
            set
            {
                _RecoHeaderId = value;
            }
        }
        public string TxnNum
        {
            get
            {
                return _TxnNum;
            }
            set
            {
                _TxnNum = value;
            }
        }
        public string CarCode
        {
            get
            {
                return _CarCode;
            }
            set
            {
                _CarCode = value;
            }
        }
        public string Driver
        {
            get
            {
                return _Driver;
            }
            set
            {
                _Driver = value;
            }
        }
        public string DriverCode
        {
            get
            {
                return _DriverCode;
            }
            set
            {
                _DriverCode = value;
            }
        }
        public string Inspector
        {
            get
            {
                return _Inspector;
            }
            set
            {
                _Inspector = value;
            }
        }
        public string InspectorCode
        {
            get
            {
                return _InspectorCode;
            }
            set
            {
                _InspectorCode = value;
            }
        }
        public string RecoMWSCode
        {
            get
            {
                return _RecoMWSCode;
            }
            set
            {
                _RecoMWSCode = value;
            }
        }
        public string RecoWSCode
        {
            get
            {
                return _RecoWSCode;
            }
            set
            {
                _RecoWSCode = value;
            }
        }
        public string RecoEmpyName
        {
            get
            {
                return _RecoEmpyName;
            }
            set
            {
                _RecoEmpyName = value;
            }
        }
        public string RecoEmpyCode
        {
            get
            {
                return _RecoEmpyCode;
            }
            set
            {
                _RecoEmpyCode = value;
            }
        }
        public DateTime StratDate
        {
            get
            {
                return _StratDate;
            }
            set
            {
                _StratDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }
        public string OperateType
        {
            get
            {
                return _OperateType;
            }
            set
            {
                _OperateType = value;
            }
        }
        public int TotalCrateQty
        {
            get
            {
                return _TotalCrateQty;
            }
            set
            {
                _TotalCrateQty = value;
            }
        }
        public decimal TotalSubWeight
        {
            get
            {
                return _TotalSubWeight;
            }
            set
            {
                _TotalSubWeight = value;
            }
        }
        public decimal TotalTxnWeight
        {
            get
            {
                return _TotalTxnWeight;
            }
            set
            {
                _TotalTxnWeight = value;
            }
        }
        public int CarDisId
        {
            get
            {
                return _CarDisId;
            }
            set
            {
                _CarDisId = value;
            }
        }
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        public DateTime OutDate
        {
            get
            {
                return _OutDate;
            }
            set
            {
                _OutDate = value;
            }
        }
        public DateTime InDate
        {
            get
            {
                return _InDate;
            }
            set
            {
                _InDate = value;
            }
        }
        public string DisStatus
        {
            get
            {
                return _DisStatus;
            }
            set
            {
                _DisStatus = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("RecoHeaderId"))
                 SetValue(ref _RecoHeaderId, row["RecoHeaderId"]);
             if(dataCols.Contains("TxnNum"))
                 SetValue(ref _TxnNum, row["TxnNum"]);
             if(dataCols.Contains("CarCode"))
                 SetValue(ref _CarCode, row["CarCode"]);
             if(dataCols.Contains("Driver"))
                 SetValue(ref _Driver, row["Driver"]);
             if(dataCols.Contains("DriverCode"))
                 SetValue(ref _DriverCode, row["DriverCode"]);
             if(dataCols.Contains("Inspector"))
                 SetValue(ref _Inspector, row["Inspector"]);
             if(dataCols.Contains("InspectorCode"))
                 SetValue(ref _InspectorCode, row["InspectorCode"]);
             if(dataCols.Contains("RecoMWSCode"))
                 SetValue(ref _RecoMWSCode, row["RecoMWSCode"]);
             if(dataCols.Contains("RecoWSCode"))
                 SetValue(ref _RecoWSCode, row["RecoWSCode"]);
             if(dataCols.Contains("RecoEmpyName"))
                 SetValue(ref _RecoEmpyName, row["RecoEmpyName"]);
             if(dataCols.Contains("RecoEmpyCode"))
                 SetValue(ref _RecoEmpyCode, row["RecoEmpyCode"]);
             if(dataCols.Contains("StratDate"))
                 SetValue(ref _StratDate, row["StratDate"]);
             if(dataCols.Contains("EndDate"))
                 SetValue(ref _EndDate, row["EndDate"]);
             if(dataCols.Contains("OperateType"))
                 SetValue(ref _OperateType, row["OperateType"]);
             if(dataCols.Contains("TotalCrateQty"))
                 SetValue(ref _TotalCrateQty, row["TotalCrateQty"]);
             if(dataCols.Contains("TotalSubWeight"))
                 SetValue(ref _TotalSubWeight, row["TotalSubWeight"]);
             if(dataCols.Contains("TotalTxnWeight"))
                 SetValue(ref _TotalTxnWeight, row["TotalTxnWeight"]);
             if(dataCols.Contains("CarDisId"))
                 SetValue(ref _CarDisId, row["CarDisId"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("OutDate"))
                 SetValue(ref _OutDate, row["OutDate"]);
             if(dataCols.Contains("InDate"))
                 SetValue(ref _InDate, row["InDate"]);
             if(dataCols.Contains("DisStatus"))
                 SetValue(ref _DisStatus, row["DisStatus"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

         public const string OPERATETYPE_ENUM_ToInventory = "I";//回收入库操作;
         public const string OPERATETYPE_ENUM_ToDestroy = "D";//回收处置操作;
         public const string STATUS_ENUM_Process = "P";//操作中;
         public const string STATUS_ENUM_Complete = "C";//完成;
         public const string STATUS_ENUM_Authorize = "A";//提交审核;
         public const string STATUS_ENUM_Send = "S";//提交等待处理;
         public const string DISSTATUS_ENUM_ShiftStrat = "S";//班次开始了;
         public const string DISSTATUS_ENUM_ShiftEnd = "E";//班次完成了;
     }
}
