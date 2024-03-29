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
            new DataColumnInfo(false,true,false,false,"StartDate",SqlCommonFn.DataColumnType.DATETIME,0),
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
        public static DataColumnInfo getStartDateColumn()
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
        private DateTime _StartDate = DateTime.MinValue;
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
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
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

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("PostHeaderId"))
                 SetValue(ref _PostHeaderId, row["PostHeaderId"]);
             if(dataCols.Contains("TxnNum"))
                 SetValue(ref _TxnNum, row["TxnNum"]);
             if(dataCols.Contains("PostWSCode"))
                 SetValue(ref _PostWSCode, row["PostWSCode"]);
             if(dataCols.Contains("PostEmpyName"))
                 SetValue(ref _PostEmpyName, row["PostEmpyName"]);
             if(dataCols.Contains("PostEmpyCode"))
                 SetValue(ref _PostEmpyCode, row["PostEmpyCode"]);
             if(dataCols.Contains("StartDate"))
                 SetValue(ref _StartDate, row["StartDate"]);
             if(dataCols.Contains("EndDate"))
                 SetValue(ref _EndDate, row["EndDate"]);
             if(dataCols.Contains("PostType"))
                 SetValue(ref _PostType, row["PostType"]);
             if(dataCols.Contains("TotalCrateQty"))
                 SetValue(ref _TotalCrateQty, row["TotalCrateQty"]);
             if(dataCols.Contains("TotalSubWeight"))
                 SetValue(ref _TotalSubWeight, row["TotalSubWeight"]);
             if(dataCols.Contains("TotalTxnWeight"))
                 SetValue(ref _TotalTxnWeight, row["TotalTxnWeight"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string POSTTYPE_ENUM_Nomarl = "N";//1.正常-称重出库;
        public const string POSTTYPE_ENUM_Special = "S";//2.特殊-直接出库;
        public const string POSTTYPE_ENUM_Auto = "A";//3.自动-由处理工作站发起自动生成出库交易信息;
        public const string STATUS_ENUM_Process = "P";//操作中;
        public const string STATUS_ENUM_Complete = "C";//完成;
        public const string STATUS_ENUM_Authorize = "A";//提交审核;

    }
}
