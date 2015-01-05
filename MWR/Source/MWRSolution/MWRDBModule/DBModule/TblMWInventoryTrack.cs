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
            new DataColumnInfo(false,true,false,false,"PostHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"PostNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DepotCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Source",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"VendorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Waste",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"WasteCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"InvWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"PostWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"PostWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"PostEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"ReceiveDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"PostDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"InvRecordId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"InvAuthId",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getInvTrackRecordIdColumn()
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
        public static DataColumnInfo getSourceColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getVendorColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getVendorCodeColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getWasteColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getWasteCodeColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getInvWeightColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getPostWeightColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getPostWSCodeColumn()
        {
            return Columns[12];
        }
        public static DataColumnInfo getPostEmpyCodeColumn()
        {
            return Columns[13];
        }
        public static DataColumnInfo getReceiveDateColumn()
        {
            return Columns[14];
        }
        public static DataColumnInfo getPostDateColumn()
        {
            return Columns[15];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[16];
        }
        public static DataColumnInfo getInvRecordIdColumn()
        {
            return Columns[17];
        }
        public static DataColumnInfo getInvAuthIdColumn()
        {
            return Columns[18];
        }

        private int _InvTrackRecordId = 0;
        private int _PostHeaderId = 0;
        private string _CrateCode = "";
        private string _PostNum = "";
        private string _DepotCode = "";
        private string _Source = "";
        private string _Vendor = "";
        private string _VendorCode = "";
        private string _Waste = "";
        private string _WasteCode = "";
        private float _InvWeight = 0;
        private float _PostWeight = 0;
        private string _PostWSCode = "";
        private string _PostEmpyCode = "";
        private DateTime _ReceiveDate = DateTime.MinValue;
        private DateTime _PostDate = DateTime.MinValue;
        private string _Status = "";
        private int _InvRecordId = 0;
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
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
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
        public DateTime ReceiveDate
        {
            get
            {
                return _ReceiveDate;
            }
            set
            {
                _ReceiveDate = value;
            }
        }
        public DateTime PostDate
        {
            get
            {
                return _PostDate;
            }
            set
            {
                _PostDate = value;
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



    }
}
