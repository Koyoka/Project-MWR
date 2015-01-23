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
            new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.INT,10),
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
        private int _TxnNum = 0;
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
        public int TxnNum
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
             SetValue(ref _InvTrackRecordId, row["InvTrackRecordId"]);
             SetValue(ref _InvRecordId, row["InvRecordId"]);
             SetValue(ref _TxnNum, row["TxnNum"]);
             SetValue(ref _TxnType, row["TxnType"]);
             SetValue(ref _TxnDetailId, row["TxnDetailId"]);
             SetValue(ref _CrateCode, row["CrateCode"]);
             SetValue(ref _DepotCode, row["DepotCode"]);
             SetValue(ref _Vendor, row["Vendor"]);
             SetValue(ref _VendorCode, row["VendorCode"]);
             SetValue(ref _Waste, row["Waste"]);
             SetValue(ref _WasteCode, row["WasteCode"]);
             SetValue(ref _SubWeight, row["SubWeight"]);
             SetValue(ref _TxnWeight, row["TxnWeight"]);
             SetValue(ref _WSCode, row["WSCode"]);
             SetValue(ref _EmpyName, row["EmpyName"]);
             SetValue(ref _EmpyCode, row["EmpyCode"]);
             SetValue(ref _EntryDate, row["EntryDate"]);
             SetValue(ref _Status, row["Status"]);
             SetValue(ref _InvAuthId, row["InvAuthId"]);
         }


    }
}
