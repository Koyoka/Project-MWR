using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWCarDispatch : BaseDataModule
    {

        private static string TableName = "MWCarDispatch";
        public TblMWCarDispatch()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"CarDisId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"CarCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Driver",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"DriverCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Inspector",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"InspectorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"RecoMWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"OutDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"InDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getCarDisIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getCarCodeColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getDriverColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getDriverCodeColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getInspectorColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getInspectorCodeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getRecoMWSCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getOutDateColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getInDateColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[9];
        }

        private int _CarDisId = 0;
        private string _CarCode = "";
        private string _Driver = "";
        private string _DriverCode = "";
        private string _Inspector = "";
        private string _InspectorCode = "";
        private string _RecoMWSCode = "";
        private DateTime _OutDate = DateTime.MinValue;
        private DateTime _InDate = DateTime.MinValue;
        private string _Status = "";

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

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("CarDisId"))
                 SetValue(ref _CarDisId, row["CarDisId"]);
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
             if(dataCols.Contains("OutDate"))
                 SetValue(ref _OutDate, row["OutDate"]);
             if(dataCols.Contains("InDate"))
                 SetValue(ref _InDate, row["InDate"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string STATUS_ENUM_ShiftStrat = "S";//班次开始了;
        public const string STATUS_ENUM_ShiftEnd = "E";//班次完成了;

    }
}
