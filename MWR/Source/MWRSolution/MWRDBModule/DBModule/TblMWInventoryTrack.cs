using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWInventoryTrack : BaseDataModule
    {

        private static string TableName = "MWInventoryTrack";
        public TblMWInventoryTrack()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"InvTrackRecordId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"InvRecordId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"TxnType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"TxnDetailId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DepotCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"VendorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Waste",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"WasteCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"SubWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"TxnWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"WSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"EmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"EmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"EntryDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"InvAuthId",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getInvTrackRecordIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getInvRecordIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getTxnNumColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getTxnTypeColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getTxnDetailIdColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getCrateCodeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getDepotCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getVendorColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getVendorCodeColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getWasteColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getWasteCodeColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getSubWeightColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getTxnWeightColumn()
        {
            return Columns[12];
        }
        public static DataColumnInfo getWSCodeColumn()
        {
            return Columns[13];
        }
        public static DataColumnInfo getEmpyNameColumn()
        {
            return Columns[14];
        }
        public static DataColumnInfo getEmpyCodeColumn()
        {
            return Columns[15];
        }
        public static DataColumnInfo getEntryDateColumn()
        {
            return Columns[16];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[17];
        }
        public static DataColumnInfo getInvAuthIdColumn()
        {
            return Columns[18];
        }

        private int _InvTrackRecordId = 0;
        private int _InvRecordId = 0;
        private string _TxnNum = "";
        private string _TxnType = "";
        private int _TxnDetailId = 0;
        private string _CrateCode = "";
        private string _DepotCode = "";
        private string _Vendor = "";
        private string _VendorCode = "";
        private string _Waste = "";
        private string _WasteCode = "";
        private decimal _SubWeight = 0;
        private decimal _TxnWeight = 0;
        private string _WSCode = "";
        private string _EmpyName = "";
        private string _EmpyCode = "";
        private DateTime _EntryDate = DateTime.MinValue;
        private string _Status = "";
        private int _InvAuthId = 0;

        public int InvTrackRecordId
        {
            get
            {
                return _InvTrackRecordId;
            }
            set
            {
                _InvTrackRecordId = value;
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
        public string TxnType
        {
            get
            {
                return _TxnType;
            }
            set
            {
                _TxnType = value;
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
        public string DepotCode
        {
            get
            {
                return _DepotCode;
            }
            set
            {
                _DepotCode = value;
            }
        }
        public string Vendor
        {
            get
            {
                return _Vendor;
            }
            set
            {
                _Vendor = value;
            }
        }
        public string VendorCode
        {
            get
            {
                return _VendorCode;
            }
            set
            {
                _VendorCode = value;
            }
        }
        public string Waste
        {
            get
            {
                return _Waste;
            }
            set
            {
                _Waste = value;
            }
        }
        public string WasteCode
        {
            get
            {
                return _WasteCode;
            }
            set
            {
                _WasteCode = value;
            }
        }
        public decimal SubWeight
        {
            get
            {
                return _SubWeight;
            }
            set
            {
                _SubWeight = value;
            }
        }
        public decimal TxnWeight
        {
            get
            {
                return _TxnWeight;
            }
            set
            {
                _TxnWeight = value;
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
        public int InvAuthId
        {
            get
            {
                return _InvAuthId;
            }
            set
            {
                _InvAuthId = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("InvTrackRecordId"))
                 SetValue(ref _InvTrackRecordId, row["InvTrackRecordId"]);
             if(dataCols.Contains("InvRecordId"))
                 SetValue(ref _InvRecordId, row["InvRecordId"]);
             if(dataCols.Contains("TxnNum"))
                 SetValue(ref _TxnNum, row["TxnNum"]);
             if(dataCols.Contains("TxnType"))
                 SetValue(ref _TxnType, row["TxnType"]);
             if(dataCols.Contains("TxnDetailId"))
                 SetValue(ref _TxnDetailId, row["TxnDetailId"]);
             if(dataCols.Contains("CrateCode"))
                 SetValue(ref _CrateCode, row["CrateCode"]);
             if(dataCols.Contains("DepotCode"))
                 SetValue(ref _DepotCode, row["DepotCode"]);
             if(dataCols.Contains("Vendor"))
                 SetValue(ref _Vendor, row["Vendor"]);
             if(dataCols.Contains("VendorCode"))
                 SetValue(ref _VendorCode, row["VendorCode"]);
             if(dataCols.Contains("Waste"))
                 SetValue(ref _Waste, row["Waste"]);
             if(dataCols.Contains("WasteCode"))
                 SetValue(ref _WasteCode, row["WasteCode"]);
             if(dataCols.Contains("SubWeight"))
                 SetValue(ref _SubWeight, row["SubWeight"]);
             if(dataCols.Contains("TxnWeight"))
                 SetValue(ref _TxnWeight, row["TxnWeight"]);
             if(dataCols.Contains("WSCode"))
                 SetValue(ref _WSCode, row["WSCode"]);
             if(dataCols.Contains("EmpyName"))
                 SetValue(ref _EmpyName, row["EmpyName"]);
             if(dataCols.Contains("EmpyCode"))
                 SetValue(ref _EmpyCode, row["EmpyCode"]);
             if(dataCols.Contains("EntryDate"))
                 SetValue(ref _EntryDate, row["EntryDate"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("InvAuthId"))
                 SetValue(ref _InvAuthId, row["InvAuthId"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string TXNTYPE_ENUM_Recover = "R";//回收入库交易;
        public const string TXNTYPE_ENUM_Post = "P";//出库交易;
        public const string TXNTYPE_ENUM_Destroy = "D";//处置销毁交易;
        public const string STATUS_ENUM_Normal = "N";//1.Normal 该跟踪数据正常;
        public const string STATUS_ENUM_Void = "V";//2.Void 该跟踪数据无效;

    }
}
