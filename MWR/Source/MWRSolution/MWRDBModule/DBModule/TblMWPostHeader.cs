using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace MWRDBModule.DBModule
{

    public class TblMWPostHeader : BaseDataModule
    {

        private static string TableName = "MWPostHeader";
        public TblMWPostHeader()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"PostHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"PostNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"StratDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"EndDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"PostWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"PostEmpCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"PostType",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getPostHeaderIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getPostNumColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getStratDateColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getEndDateColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getPostWSCodeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getPostEmpCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getPostTypeColumn()
        {
            return Columns[7];
        }

        private int _PostHeaderId = 0;
        private string _PostNum = "";
        private string _Status = "";
        private DateTime _StratDate = DateTime.MinValue;
        private DateTime _EndDate = DateTime.MinValue;
        private string _PostWSCode = "";
        private string _PostEmpCode = "";
        private string _PostType = "";

        public int PostHeaderId
        {
            get
            {
                return _PostHeaderId;
            }
            set
            {
                _PostHeaderId = value;
            }
        }
        public string PostNum
        {
            get
            {
                return _PostNum;
            }
            set
            {
                _PostNum = value;
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
        public string PostWSCode
        {
            get
            {
                return _PostWSCode;
            }
            set
            {
                _PostWSCode = value;
            }
        }
        public string PostEmpCode
        {
            get
            {
                return _PostEmpCode;
            }
            set
            {
                _PostEmpCode = value;
            }
        }
        public string PostType
        {
            get
            {
                return _PostType;
            }
            set
            {
                _PostType = value;
            }
        }



    }
}
