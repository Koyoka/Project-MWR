using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWInvAuthorize : BaseDataModule
    {

        private static string TableName = "MWInvAuthorize";
        public TblMWInvAuthorize()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"InvAuthId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"TxnDetailId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"EmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"EmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"WSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"AuthEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"AuthEmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"Remark",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"SubWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"TxnWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"DiffWeight",SqlCommonFn.DataColumnType.DECIMAL,10),
            new DataColumnInfo(false,true,false,false,"EntryDate",SqlCommonFn.DataColumnType.DATETIME,10),
            new DataColumnInfo(false,true,false,false,"CompDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getInvAuthIdColumn()
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
        public static DataColumnInfo getEmpyCodeColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getEmpyNameColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getWSCodeColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getAuthEmpyCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getAuthEmpyNameColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getRemarkColumn()
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
        public static DataColumnInfo getDiffWeightColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getEntryDateColumn()
        {
            return Columns[12];
        }
        public static DataColumnInfo getCompDateColumn()
        {
            return Columns[13];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[14];
        }

        private int _InvAuthId = 0;
        private string _TxnNum = "";
        private int _TxnDetailId = 0;
        private string _EmpyCode = "";
        private string _EmpyName = "";
        private string _WSCode = "";
        private string _AuthEmpyCode = "";
        private string _AuthEmpyName = "";
        private string _Remark = "";
        private decimal _SubWeight = 0;
        private decimal _TxnWeight = 0;
        private decimal _DiffWeight = 0;
        private DateTime _EntryDate = DateTime.MinValue;
        private DateTime _CompDate = DateTime.MinValue;
        private string _Status = "";

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
        public string AuthEmpyCode
        {
            get
            {
                return _AuthEmpyCode;
            }
            set
            {
                _AuthEmpyCode = value;
            }
        }
        public string AuthEmpyName
        {
            get
            {
                return _AuthEmpyName;
            }
            set
            {
                _AuthEmpyName = value;
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
        public decimal DiffWeight
        {
            get
            {
                return _DiffWeight;
            }
            set
            {
                _DiffWeight = value;
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
        public DateTime CompDate
        {
            get
            {
                return _CompDate;
            }
            set
            {
                _CompDate = value;
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
             SetValue(ref _InvAuthId, row["InvAuthId"]);
             SetValue(ref _TxnNum, row["TxnNum"]);
             SetValue(ref _TxnDetailId, row["TxnDetailId"]);
             SetValue(ref _EmpyCode, row["EmpyCode"]);
             SetValue(ref _EmpyName, row["EmpyName"]);
             SetValue(ref _WSCode, row["WSCode"]);
             SetValue(ref _AuthEmpyCode, row["AuthEmpyCode"]);
             SetValue(ref _AuthEmpyName, row["AuthEmpyName"]);
             SetValue(ref _Remark, row["Remark"]);
             SetValue(ref _SubWeight, row["SubWeight"]);
             SetValue(ref _TxnWeight, row["TxnWeight"]);
             SetValue(ref _DiffWeight, row["DiffWeight"]);
             SetValue(ref _EntryDate, row["EntryDate"]);
             SetValue(ref _CompDate, row["CompDate"]);
             SetValue(ref _Status, row["Status"]);
         }


    }
}
