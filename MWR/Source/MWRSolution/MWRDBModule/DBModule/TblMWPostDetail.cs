using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWPostDetail : BaseDataModule
    {

        private static string TableName = "MWPostDetail";
        public TblMWPostDetail()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"PostDtlId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"PostHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"PostNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DepotCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"VendorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Waste",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"WasteCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"InvWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"PostWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"InvRecordId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"InvAuthId",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getPostDtlIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getPostHeaderIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getCrateCodeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getPostNumColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getDepotCodeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getVendorColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getVendorCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getWasteColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getWasteCodeColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getInvWeightColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getPostWeightColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getInvRecordIdColumn()
        {
            return Columns[12];
        }
        public static DataColumnInfo getInvAuthIdColumn()
        {
            return Columns[13];
        }

        private int _PostDtlId = 0;
        private int _PostHeaderId = 0;
        private string _CrateCode = "";
        private string _PostNum = "";
        private string _DepotCode = "";
        private string _Vendor = "";
        private string _VendorCode = "";
        private string _Waste = "";
        private string _WasteCode = "";
        private float _InvWeight = 0;
        private float _PostWeight = 0;
        private string _Status = "";
        private int _InvRecordId = 0;
        private int _InvAuthId = 0;

        public int PostDtlId
        {
            get
            {
                return _PostDtlId;
            }
            set
            {
                _PostDtlId = value;
            }
        }
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
        public string PostNum
        {
            get
            {
                return _PostNum;
            }
            set
            {
                _PostNum = value;
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
        public float InvWeight
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
        public float PostWeight
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
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("PostDtlId"))
                 SetValue(ref _PostDtlId, row["PostDtlId"]);
             if(dataCols.Contains("PostHeaderId"))
                 SetValue(ref _PostHeaderId, row["PostHeaderId"]);
             if(dataCols.Contains("CrateCode"))
                 SetValue(ref _CrateCode, row["CrateCode"]);
             if(dataCols.Contains("PostNum"))
                 SetValue(ref _PostNum, row["PostNum"]);
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
             if(dataCols.Contains("InvWeight"))
                 SetValue(ref _InvWeight, row["InvWeight"]);
             if(dataCols.Contains("PostWeight"))
                 SetValue(ref _PostWeight, row["PostWeight"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("InvRecordId"))
                 SetValue(ref _InvRecordId, row["InvRecordId"]);
             if(dataCols.Contains("InvAuthId"))
                 SetValue(ref _InvAuthId, row["InvAuthId"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }


    }
}
