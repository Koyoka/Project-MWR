using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWTxnDestroyHeader : BaseDataModule
    {

        private static string TableName = "MWTxnDestroyHeader";
        public TblMWTxnDestroyHeader()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"DestHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DestType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"StartDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"EndDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"DestWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DestEmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"DestEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"TotalCrateQty",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TotalSubWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"TotalTxnWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getDestHeaderIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getTxnNumColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getDestTypeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getStartDateColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getEndDateColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getDestWSCodeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getDestEmpyNameColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getDestEmpyCodeColumn()
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

        private int _DestHeaderId = 0;
        private string _TxnNum = "";
        private string _DestType = "";
        private DateTime _StartDate = DateTime.MinValue;
        private DateTime _EndDate = DateTime.MinValue;
        private string _DestWSCode = "";
        private string _DestEmpyName = "";
        private string _DestEmpyCode = "";
        private int _TotalCrateQty = 0;
        private decimal _TotalSubWeight = 0;
        private decimal _TotalTxnWeight = 0;
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
        public string DestType
        {
            get
            {
                return _DestType;
            }
            set
            {
                _DestType = value;
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
        public string DestEmpyName
        {
            get
            {
                return _DestEmpyName;
            }
            set
            {
                _DestEmpyName = value;
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
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("DestHeaderId"))
                 SetValue(ref _DestHeaderId, row["DestHeaderId"]);
             if(dataCols.Contains("TxnNum"))
                 SetValue(ref _TxnNum, row["TxnNum"]);
             if(dataCols.Contains("DestType"))
                 SetValue(ref _DestType, row["DestType"]);
             if(dataCols.Contains("StartDate"))
                 SetValue(ref _StartDate, row["StartDate"]);
             if(dataCols.Contains("EndDate"))
                 SetValue(ref _EndDate, row["EndDate"]);
             if(dataCols.Contains("DestWSCode"))
                 SetValue(ref _DestWSCode, row["DestWSCode"]);
             if(dataCols.Contains("DestEmpyName"))
                 SetValue(ref _DestEmpyName, row["DestEmpyName"]);
             if(dataCols.Contains("DestEmpyCode"))
                 SetValue(ref _DestEmpyCode, row["DestEmpyCode"]);
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

        public const string DESTTYPE_ENUM_RecoverDestroy = "RD";//1.回收处置 RD;
        public const string DESTTYPE_ENUM_PostDestroy = "PD";//2.出库处置 PD;
        public const string STATUS_ENUM_Process = "P";//操作中;
        public const string STATUS_ENUM_Complete = "C";//完成;
        public const string STATUS_ENUM_Authorize = "A";//提交审核;

    }
}
