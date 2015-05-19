using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWSynclog : BaseDataModule
    {

        private static string TableName = "MWSynclog";
        public TblMWSynclog()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"SyncDateTime",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"Remark",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"InCarWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"RecoSubWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"RecoTxnWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"InvWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"PostTxnWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"DestTxnWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"EntryDate",SqlCommonFn.DataColumnType.DATETIME,0)
        };

        public static DataColumnInfo getSyncDateTimeColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getRemarkColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getInCarWeightColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getRecoSubWeightColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getRecoTxnWeightColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getInvWeightColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getPostTxnWeightColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getDestTxnWeightColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getEntryDateColumn()
        {
            return Columns[9];
        }

        private DateTime _SyncDateTime = DateTime.MinValue;
        private string _Status = "";
        private string _Remark = "";
        private decimal _InCarWeight = 0;
        private decimal _RecoSubWeight = 0;
        private decimal _RecoTxnWeight = 0;
        private decimal _InvWeight = 0;
        private decimal _PostTxnWeight = 0;
        private decimal _DestTxnWeight = 0;
        private DateTime _EntryDate = DateTime.MinValue;

        public DateTime SyncDateTime
        {
            get
            {
                return _SyncDateTime;
            }
            set
            {
                _SyncDateTime = value;
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
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }
        public decimal InCarWeight
        {
            get
            {
                return _InCarWeight;
            }
            set
            {
                _InCarWeight = value;
            }
        }
        public decimal RecoSubWeight
        {
            get
            {
                return _RecoSubWeight;
            }
            set
            {
                _RecoSubWeight = value;
            }
        }
        public decimal RecoTxnWeight
        {
            get
            {
                return _RecoTxnWeight;
            }
            set
            {
                _RecoTxnWeight = value;
            }
        }
        public decimal InvWeight
        {
            get
            {
                return _InvWeight;
            }
            set
            {
                _InvWeight = value;
            }
        }
        public decimal PostTxnWeight
        {
            get
            {
                return _PostTxnWeight;
            }
            set
            {
                _PostTxnWeight = value;
            }
        }
        public decimal DestTxnWeight
        {
            get
            {
                return _DestTxnWeight;
            }
            set
            {
                _DestTxnWeight = value;
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

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("SyncDateTime"))
                 SetValue(ref _SyncDateTime, row["SyncDateTime"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("Remark"))
                 SetValue(ref _Remark, row["Remark"]);
             if(dataCols.Contains("InCarWeight"))
                 SetValue(ref _InCarWeight, row["InCarWeight"]);
             if(dataCols.Contains("RecoSubWeight"))
                 SetValue(ref _RecoSubWeight, row["RecoSubWeight"]);
             if(dataCols.Contains("RecoTxnWeight"))
                 SetValue(ref _RecoTxnWeight, row["RecoTxnWeight"]);
             if(dataCols.Contains("InvWeight"))
                 SetValue(ref _InvWeight, row["InvWeight"]);
             if(dataCols.Contains("PostTxnWeight"))
                 SetValue(ref _PostTxnWeight, row["PostTxnWeight"]);
             if(dataCols.Contains("DestTxnWeight"))
                 SetValue(ref _DestTxnWeight, row["DestTxnWeight"]);
             if(dataCols.Contains("EntryDate"))
                 SetValue(ref _EntryDate, row["EntryDate"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string STATUS_ENUM_Complete = "C";//同步完成;
        public const string STATUS_ENUM_Error = "E";//同步出错;
        public const string STATUS_ENUM_Wait = "W";//wait;

    }
}
