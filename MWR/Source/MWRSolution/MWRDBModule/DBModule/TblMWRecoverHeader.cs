using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace MWRDBModule.DBModule
{

    public class TblMWRecoverHeader : BaseDataModule
    {

        private static string TableName = "MWRecoverHeader";
        public TblMWRecoverHeader()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"RecoHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"RecoNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"CarCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DriverCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"InspectorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"CrateQty",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"RecoWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"RecoEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"StratDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"EndDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"OperateType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"CarDisId",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getRecoHeaderIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getRecoNumColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getCarCodeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getDriverCodeColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getInspectorCodeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getCrateQtyColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getRecoWSCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getRecoEmpyCodeColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getStratDateColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getEndDateColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getOperateTypeColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getCarDisIdColumn()
        {
            return Columns[12];
        }

        private int _RecoHeaderId = 0;
        private string _RecoNum = "";
        private string _CarCode = "";
        private string _DriverCode = "";
        private string _InspectorCode = "";
        private int _CrateQty = 0;
        private string _RecoWSCode = "";
        private string _RecoEmpyCode = "";
        private DateTime _StratDate = DateTime.MinValue;
        private DateTime _EndDate = DateTime.MinValue;
        private string _OperateType = "";
        private string _Status = "";
        private int _CarDisId = 0;

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
        public string RecoNum
        {
            get
            {
                return _RecoNum;
            }
            set
            {
                _RecoNum = value;
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
        public int CrateQty
        {
            get
            {
                return _CrateQty;
            }
            set
            {
                _CrateQty = value;
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



    }
}
