using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace MWRDBModule.DBModule
{

    public class TblMWDestroyDetail : BaseDataModule
    {

        private static string TableName = "MWDestroyDetail";
        public TblMWDestroyDetail()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"DestroyDtlId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DestHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"DestNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DepotCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"VendorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Waste",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"WasteCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"PostWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"DestWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,false,false,false,"PostHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"InvRecordId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,false,false,false,"InvAuthId",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getDestroyDtlIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getCrateCodeColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getDestHeaderIdColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getDestNumColumn()
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
        public static DataColumnInfo getPostWeightColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getDestWeightColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getPostHeaderIdColumn()
        {
            return Columns[12];
        }
        public static DataColumnInfo getInvRecordIdColumn()
        {
            return Columns[13];
        }
        public static DataColumnInfo getInvAuthIdColumn()
        {
            return Columns[14];
        }

        private int _DestroyDtlId = 0;
        private string _CrateCode = "";
        private int _DestHeaderId = 0;
        private string _DestNum = "";
        private string _DepotCode = "";
        private string _Vendor = "";
        private string _VendorCode = "";
        private string _Waste = "";
        private string _WasteCode = "";
        private float _PostWeight = 0;
        private float _DestWeight = 0;
        private string _Status = "";
        private int _PostHeaderId = 0;
        private int _InvRecordId = 0;
        private int _InvAuthId = 0;

        public int DestroyDtlId
        {
            get
            {
                return _DestroyDtlId;
            }
            set
            {
                _DestroyDtlId = value;
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
        public string DestNum
        {
            get
            {
                return _DestNum;
            }
            set
            {
                _DestNum = value;
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
        public float DestWeight
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
