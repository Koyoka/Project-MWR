using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWTxnPostHeader : BaseDataModule
    {

        private static string TableName = "MWTxnPostHeader";
        public TblMWTxnPostHeader()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"PostHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"PostWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"PostEmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"PostEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"StratDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"EndDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"PostType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"TotalCrateQty",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TotalSubWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"TotalTxnWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getPostHeaderIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getTxnNumColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getPostWSCodeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getPostEmpyNameColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getPostEmpyCodeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getStratDateColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getEndDateColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getPostTypeColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getTotalCrateQtyColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getTotalSubWeightColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getTotalTxnWeightColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[11];
        }

        private int _PostHeaderId = 0;
        private string _TxnNum = "";
        private string _PostWSCode = "";
        private string _PostEmpyName = "";
        private string _PostEmpyCode = "";
        private DateTime _StratDate = DateTime.MinValue;
        private DateTime _EndDate = DateTime.MinValue;
        private string _PostType = "";
        private int _TotalCrateQty = 0;
        private decimal _TotalSubWeight = 0;
        private decimal _TotalTxnWeight = 0;
        private string _Status = "";

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
        public string PostEmpyName
        {
            get
            {
                return _PostEmpyName;
            }
            set
            {
                _PostEmpyName = value;
            }
        }
        public string PostEmpyCode
        {
            get
            {
                return _PostEmpyCode;
            }
            set
            {
                _PostEmpyCode = value;
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
