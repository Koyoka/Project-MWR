using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWTxnLog : BaseDataModule
    {

        private static string TableName = "MWTxnLog";
        public TblMWTxnLog()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"TxnLogId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"TxnDetailId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"WSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"EmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"EmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"OptType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"OptDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"TxnLogType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"InvRecordId",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getTxnLogIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getTxnNumColumn()
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
        public static DataColumnInfo getEmpyNameColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getEmpyCodeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getOptTypeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getOptDateColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getTxnLogTypeColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getInvRecordIdColumn()
        {
            return Columns[9];
        }

        private int _TxnLogId = 0;
        private string _TxnNum = "";
        private int _TxnDetailId = 0;
        private string _WSCode = "";
        private string _EmpyName = "";
        private string _EmpyCode = "";
        private string _OptType = "";
        private DateTime _OptDate = DateTime.MinValue;
        private string _TxnLogType = "";
        private int _InvRecordId = 0;

        public int TxnLogId
        {
            get
            {
                return _TxnLogId;
            }
            set
            {
                _TxnLogId = value;
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
        public string EmpyName
        {
            get
            {
                return _EmpyName;
            }
            set
            {
                _EmpyName = value;
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
        public string TxnLogType
        {
            get
            {
                return _TxnLogType;
            }
            set
            {
                _TxnLogType = value;
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

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("TxnLogId"))
                 SetValue(ref _TxnLogId, row["TxnLogId"]);
             if(dataCols.Contains("TxnNum"))
                 SetValue(ref _TxnNum, row["TxnNum"]);
             if(dataCols.Contains("TxnDetailId"))
                 SetValue(ref _TxnDetailId, row["TxnDetailId"]);
             if(dataCols.Contains("WSCode"))
                 SetValue(ref _WSCode, row["WSCode"]);
             if(dataCols.Contains("EmpyName"))
                 SetValue(ref _EmpyName, row["EmpyName"]);
             if(dataCols.Contains("EmpyCode"))
                 SetValue(ref _EmpyCode, row["EmpyCode"]);
             if(dataCols.Contains("OptType"))
                 SetValue(ref _OptType, row["OptType"]);
             if(dataCols.Contains("OptDate"))
                 SetValue(ref _OptDate, row["OptDate"]);
             if(dataCols.Contains("TxnLogType"))
                 SetValue(ref _TxnLogType, row["TxnLogType"]);
             if(dataCols.Contains("InvRecordId"))
                 SetValue(ref _InvRecordId, row["InvRecordId"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string OPTTYPE_ENUM_SubComplete = "SC";//1.交易提交完成操作库存 SC  submit inventory;
        public const string OPTTYPE_ENUM_SubAuthorize = "SA";//2.交易提交审核 SA submit authorize;
        public const string OPTTYPE_ENUM_AuthorizeDone = "AD";//管理中心审核通过;
        public const string OPTTYPE_ENUM_AuthorizeComplete = "AC";//3.确认审核并完成操作库存 AC authorize inventory;
        public const string OPTTYPE_ENUM_SubRecover = "SR";//4.车辆回场提交回收;
        public const string OPTTYPE_ENUM_NewTxn = "NT";//新建交易;
        public const string TXNLOGTYPE_ENUM_Recover = "R";//回收入库交易;
        public const string TXNLOGTYPE_ENUM_Post = "P";//出库交易;
        public const string TXNLOGTYPE_ENUM_Destroy = "D";//处置销毁交易;

    }
}
