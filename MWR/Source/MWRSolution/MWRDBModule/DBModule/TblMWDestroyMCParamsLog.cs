using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWDestroyMCParamsLog : BaseDataModule
    {

        private static string TableName = "MWDestroyMCParamsLog";
        public TblMWDestroyMCParamsLog()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"MCCode",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(true,false,false,false,"RunDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"WSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DisiNum",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Pressure",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"InTemperature",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"ExTemperature",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"EC1",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"EC2",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"WordStatus",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getMCCodeColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getRunDateColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getWSCodeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getDisiNumColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getPressureColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getInTemperatureColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getExTemperatureColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getEC1Column()
        {
            return Columns[7];
        }
        public static DataColumnInfo getEC2Column()
        {
            return Columns[8];
        }
        public static DataColumnInfo getWordStatusColumn()
        {
            return Columns[9];
        }

        private string _MCCode = "";
        private DateTime _RunDate = DateTime.MinValue;
        private string _WSCode = "";
        private int _DisiNum = 0;
        private float _Pressure = 0;
        private float _InTemperature = 0;
        private float _ExTemperature = 0;
        private float _EC1 = 0;
        private float _EC2 = 0;
        private string _WordStatus = "";

        public string MCCode
        {
            get
            {
                return _MCCode;
            }
            set
            {
                _MCCode = value;
            }
        }
        public DateTime RunDate
        {
            get
            {
                return _RunDate;
            }
            set
            {
                _RunDate = value;
            }
        }
        public string WSCode
        {
            get
            {
                return _WSCode;
            }
            set
            {
                _WSCode = value;
            }
        }
        public int DisiNum
        {
            get
            {
                return _DisiNum;
            }
            set
            {
                _DisiNum = value;
            }
        }
        public float Pressure
        {
            get
            {
                return _Pressure;
            }
            set
            {
                _Pressure = value;
            }
        }
        public float InTemperature
        {
            get
            {
                return _InTemperature;
            }
            set
            {
                _InTemperature = value;
            }
        }
        public float ExTemperature
        {
            get
            {
                return _ExTemperature;
            }
            set
            {
                _ExTemperature = value;
            }
        }
        public float EC1
        {
            get
            {
                return _EC1;
            }
            set
            {
                _EC1 = value;
            }
        }
        public float EC2
        {
            get
            {
                return _EC2;
            }
            set
            {
                _EC2 = value;
            }
        }
        public string WordStatus
        {
            get
            {
                return _WordStatus;
            }
            set
            {
                _WordStatus = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("MCCode"))
                 SetValue(ref _MCCode, row["MCCode"]);
             if(dataCols.Contains("RunDate"))
                 SetValue(ref _RunDate, row["RunDate"]);
             if(dataCols.Contains("WSCode"))
                 SetValue(ref _WSCode, row["WSCode"]);
             if(dataCols.Contains("DisiNum"))
                 SetValue(ref _DisiNum, row["DisiNum"]);
             if(dataCols.Contains("Pressure"))
                 SetValue(ref _Pressure, row["Pressure"]);
             if(dataCols.Contains("InTemperature"))
                 SetValue(ref _InTemperature, row["InTemperature"]);
             if(dataCols.Contains("ExTemperature"))
                 SetValue(ref _ExTemperature, row["ExTemperature"]);
             if(dataCols.Contains("EC1"))
                 SetValue(ref _EC1, row["EC1"]);
             if(dataCols.Contains("EC2"))
                 SetValue(ref _EC2, row["EC2"]);
             if(dataCols.Contains("WordStatus"))
                 SetValue(ref _WordStatus, row["WordStatus"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }


    }
}
