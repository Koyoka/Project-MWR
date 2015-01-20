using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWTxnDetail : BaseDataModule
    {

        private static string TableName = "MWTxnDetail";
        public TblMWTxnDetail()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"TxnDetailId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TxnType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"WSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"EmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"EmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Waste",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"SubWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"TxnWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"InvRecordId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"InvAuthId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getTxnDetailIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getTxnTypeColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getTxnNumColumn()
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
        public static DataColumnInfo getCrateCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getVendorColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getWasteColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getSubWeightColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getTxnWeightColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getInvRecordIdColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getInvAuthIdColumn()
        {
            return Columns[12];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[13];
        }

        private int _TxnDetailId = 0;
        private string _TxnType = "";
        private string _TxnNum = "";
        private string _WSCode = "";
        private string _EmpyName = "";
        private string _EmpyCode = "";
        private string _CrateCode = "";
        private string _Vendor = "";
        private string _Waste = "";
        private float _SubWeight = 0;
        private float _TxnWeight = 0;
        private int _InvRecordId = 0;
        private int _InvAuthId = 0;
        private string _Status = "";

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
        public float SubWeight
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
        public float TxnWeight
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



    }
}
