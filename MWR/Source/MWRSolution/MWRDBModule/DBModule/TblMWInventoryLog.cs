using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace MWRDBModule.DBModule
{

    public class TblMWInventoryLog : BaseDataModule
    {

        private static string TableName = "MWInventoryLog";
        public TblMWInventoryLog()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"InvLogId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"WSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"EmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"OptType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"OptDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"InvLogType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"InvRecordId",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getInvLogIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getWSCodeColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getEmpyCodeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getOptTypeColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getOptDateColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getInvLogTypeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getInvRecordIdColumn()
        {
            return Columns[6];
        }

        private int _InvLogId = 0;
        private string _WSCode = "";
        private string _EmpyCode = "";
        private string _OptType = "";
        private DateTime _OptDate = DateTime.MinValue;
        private string _InvLogType = "";
        private int _InvRecordId = 0;

        public int InvLogId
        {
            get
            {
                return _InvLogId;
            }
            set
            {
                _InvLogId = value;
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
        public string EmpyCode
        {
            get
            {
                return _EmpyCode;
            }
            set
            {
                _EmpyCode = value;
            }
        }
        public string OptType
        {
            get
            {
                return _OptType;
            }
            set
            {
                _OptType = value;
            }
        }
        public DateTime OptDate
        {
            get
            {
                return _OptDate;
            }
            set
            {
                _OptDate = value;
            }
        }
        public string InvLogType
        {
            get
            {
                return _InvLogType;
            }
            set
            {
                _InvLogType = value;
            }
        }
        public int InvRecordId
        {
            get
            {
                return _InvRecordId;
            }
            set
            {
                _InvRecordId = value;
            }
        }



    }
}
