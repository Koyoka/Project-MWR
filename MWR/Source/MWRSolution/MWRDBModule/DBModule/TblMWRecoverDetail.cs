using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWRecoverDetail : BaseDataModule
    {

        private static string TableName = "MWRecoverDetail";
        public TblMWRecoverDetail()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"RecoDtlId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"RecoHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"RecoNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"VendorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Waste",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"WasteCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"RecoWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"RecoDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"InvAuthId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getRecoDtlIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getRecoHeaderIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getCrateCodeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getRecoNumColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getVendorColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getVendorCodeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getWasteColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getWasteCodeColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getRecoWeightColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getRecoDateColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getInvAuthIdColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[11];
        }

        private int _RecoDtlId = 0;
        private int _RecoHeaderId = 0;
        private string _CrateCode = "";
        private string _RecoNum = "";
        private string _Vendor = "";
        private string _VendorCode = "";
        private string _Waste = "";
        private string _WasteCode = "";
        private float _RecoWeight = 0;
        private DateTime _RecoDate = DateTime.MinValue;
        private int _InvAuthId = 0;
        private string _Status = "";

        public int RecoDtlId
        {
            get
            {
                return _RecoDtlId;
            }
            set
            {
                _RecoDtlId = value;
            }
        }
        public int RecoHeaderId
        {
            get
            {
                return _RecoHeaderId;
            }
            set
            {
                _RecoHeaderId = value;
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
        public string RecoNum
        {
            get
            {
                return _RecoNum;
            }
            set
            {
                _RecoNum = value;
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
        public float RecoWeight
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
        public DateTime RecoDate
        {
            get
            {
                return _RecoDate;
            }
            set
            {
                _RecoDate = value;
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
             SetValue(ref _RecoDtlId, row["RecoDtlId"]);
             SetValue(ref _RecoHeaderId, row["RecoHeaderId"]);
             SetValue(ref _CrateCode, row["CrateCode"]);
             SetValue(ref _RecoNum, row["RecoNum"]);
             SetValue(ref _Vendor, row["Vendor"]);
             SetValue(ref _VendorCode, row["VendorCode"]);
             SetValue(ref _Waste, row["Waste"]);
             SetValue(ref _WasteCode, row["WasteCode"]);
             SetValue(ref _RecoWeight, row["RecoWeight"]);
             SetValue(ref _RecoDate, row["RecoDate"]);
             SetValue(ref _InvAuthId, row["InvAuthId"]);
             SetValue(ref _Status, row["Status"]);
         }


    }
}
