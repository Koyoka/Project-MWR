using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWInventory : BaseDataModule
    {

        private static string TableName = "MWInventory";
        public TblMWInventory()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"InvRecordId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DepotCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"VendorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Waste",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"WasteCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"RecoWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"InvWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"PostWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"DestWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"EntryDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,3),
            new DataColumnInfo(false,true,false,false,"DailyClose",SqlCommonFn.DataColumnType.BOOL,1)
        };

        public static DataColumnInfo getInvRecordIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getCrateCodeColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getDepotCodeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getVendorColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getVendorCodeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getWasteColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getWasteCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getRecoWeightColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getInvWeightColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getPostWeightColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getDestWeightColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getEntryDateColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[12];
        }
        public static DataColumnInfo getDailyCloseColumn()
        {
            return Columns[13];
        }

        private int _InvRecordId = 0;
        private string _CrateCode = "";
        private string _DepotCode = "";
        private string _Vendor = "";
        private string _VendorCode = "";
        private string _Waste = "";
        private string _WasteCode = "";
        private decimal _RecoWeight = 0;
        private decimal _InvWeight = 0;
        private decimal _PostWeight = 0;
        private decimal _DestWeight = 0;
        private DateTime _EntryDate = DateTime.MinValue;
        private string _Status = "";
        private bool _DailyClose = false;

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
        public decimal RecoWeight
        {
            get
            {
                return _RecoWeight;
            }
            set
            {
                _RecoWeight = value;
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
        public decimal PostWeight
        {
            get
            {
                return _PostWeight;
            }
            set
            {
                _PostWeight = value;
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
        public bool DailyClose
        {
            get
            {
                return _DailyClose;
            }
            set
            {
                _DailyClose = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("InvRecordId"))
                 SetValue(ref _InvRecordId, row["InvRecordId"]);
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
             if(dataCols.Contains("RecoWeight"))
                 SetValue(ref _RecoWeight, row["RecoWeight"]);
             if(dataCols.Contains("InvWeight"))
                 SetValue(ref _InvWeight, row["InvWeight"]);
             if(dataCols.Contains("PostWeight"))
                 SetValue(ref _PostWeight, row["PostWeight"]);
             if(dataCols.Contains("DestWeight"))
                 SetValue(ref _DestWeight, row["DestWeight"]);
             if(dataCols.Contains("EntryDate"))
                 SetValue(ref _EntryDate, row["EntryDate"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("DailyClose"))
                 SetValue(ref _DailyClose, row["DailyClose"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string STATUS_ENUM_Recovered = "RED"; //1.已入库 RED;
        public const string STATUS_ENUM_Posted = "PED"; //2.已出库PED;
        public const string STATUS_ENUM_Destroyed = "DED";//3.已销毁DED;
        public const string STATUS_ENUM_Recovering = "RIN";//4.入库中RIN;
        public const string STATUS_ENUM_Posting = "PIN";//5.出库中PIN;
        public const string STATUS_ENUM_Destroying = "DIN";//6.销毁中DIN;

    }
}
