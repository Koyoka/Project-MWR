using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWDestroyMCDetail : BaseDataModule
    {

        private static string TableName = "MWDestroyMCDetail";
        public TblMWDestroyMCDetail()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"MCDetailId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"DisiNum",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TxnDetailId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"WSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"DestWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"EntryDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getMCDetailIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getDisiNumColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getTxnDetailIdColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getWSCodeColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getCrateCodeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getDestWeightColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getEntryDateColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[7];
        }

        private int _MCDetailId = 0;
        private int _DisiNum = 0;
        private int _TxnDetailId = 0;
        private string _WSCode = "";
        private string _CrateCode = "";
        private decimal _DestWeight = 0;
        private DateTime _EntryDate = DateTime.MinValue;
        private string _Status = "";

        public int MCDetailId
        {
            get
            {
                return _MCDetailId;
            }
            set
            {
                _MCDetailId = value;
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
        public int TxnDetailId
        {
            get
            {
                return _TxnDetailId;
            }
            set
            {
                _TxnDetailId = value;
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
        public string CrateCode
        {
            get
            {
                return _CrateCode;
            }
            set
            {
                _CrateCode = value;
            }
        }
        public decimal DestWeight
        {
            get
            {
                return _DestWeight;
            }
            set
            {
                _DestWeight = value;
            }
        }
        public DateTime EntryDate
        {
            get
            {
                return _EntryDate;
            }
            set
            {
                _EntryDate = value;
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
             if(dataCols.Contains("MCDetailId"))
                 SetValue(ref _MCDetailId, row["MCDetailId"]);
             if(dataCols.Contains("DisiNum"))
                 SetValue(ref _DisiNum, row["DisiNum"]);
             if(dataCols.Contains("TxnDetailId"))
                 SetValue(ref _TxnDetailId, row["TxnDetailId"]);
             if(dataCols.Contains("WSCode"))
                 SetValue(ref _WSCode, row["WSCode"]);
             if(dataCols.Contains("CrateCode"))
                 SetValue(ref _CrateCode, row["CrateCode"]);
             if(dataCols.Contains("DestWeight"))
                 SetValue(ref _DestWeight, row["DestWeight"]);
             if(dataCols.Contains("EntryDate"))
                 SetValue(ref _EntryDate, row["EntryDate"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string STATUS_ENUM_Wait = "W"; // wait 机器处理等待;
        public const string STATUS_ENUM_Complete = "C"; //Complete 机器处理完成;

    }
}
