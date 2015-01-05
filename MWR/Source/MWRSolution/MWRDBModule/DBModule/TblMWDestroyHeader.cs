using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWDestroyHeader : BaseDataModule
    {

        private static string TableName = "MWDestroyHeader";
        public TblMWDestroyHeader()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"DestHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"DestNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"StratDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"EndDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"DestWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DestEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getDestHeaderIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getDestNumColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getStratDateColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getEndDateColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getDestWSCodeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getDestEmpyCodeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[6];
        }

        private int _DestHeaderId = 0;
        private string _DestNum = "";
        private DateTime _StratDate = DateTime.MinValue;
        private DateTime _EndDate = DateTime.MinValue;
        private string _DestWSCode = "";
        private string _DestEmpyCode = "";
        private string _Status = "";

        public int DestHeaderId
        {
            get
            {
                return _DestHeaderId;
            }
            set
            {
                _DestHeaderId = value;
            }
        }
        public string DestNum
        {
            get
            {
                return _DestNum;
            }
            set
            {
                _DestNum = value;
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
        public string DestWSCode
        {
            get
            {
                return _DestWSCode;
            }
            set
            {
                _DestWSCode = value;
            }
        }
        public string DestEmpyCode
        {
            get
            {
                return _DestEmpyCode;
            }
            set
            {
                _DestEmpyCode = value;
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



    }
}
