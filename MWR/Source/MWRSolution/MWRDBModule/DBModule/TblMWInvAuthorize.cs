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
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("InvAuthId"))
                 SetValue(ref _InvAuthId, row["InvAuthId"]);
             if(dataCols.Contains("TxnNum"))
                 SetValue(ref _TxnNum, row["TxnNum"]);
             if(dataCols.Contains("TxnDetailId"))
                 SetValue(ref _TxnDetailId, row["TxnDetailId"]);
             if(dataCols.Contains("EmpyCode"))
                 SetValue(ref _EmpyCode, row["EmpyCode"]);
             if(dataCols.Contains("EmpyName"))
                 SetValue(ref _EmpyName, row["EmpyName"]);
             if(dataCols.Contains("WSCode"))
                 SetValue(ref _WSCode, row["WSCode"]);
             if(dataCols.Contains("AuthEmpyCode"))
                 SetValue(ref _AuthEmpyCode, row["AuthEmpyCode"]);
             if(dataCols.Contains("AuthEmpyName"))
                 SetValue(ref _AuthEmpyName, row["AuthEmpyName"]);
             if(dataCols.Contains("Remark"))
                 SetValue(ref _Remark, row["Remark"]);
             if(dataCols.Contains("SubWeight"))
                 SetValue(ref _SubWeight, row["SubWeight"]);
             if(dataCols.Contains("TxnWeight"))
                 SetValue(ref _TxnWeight, row["TxnWeight"]);
             if(dataCols.Contains("DiffWeight"))
                 SetValue(ref _DiffWeight, row["DiffWeight"]);
             if(dataCols.Contains("EntryDate"))
                 SetValue(ref _EntryDate, row["EntryDate"]);
             if(dataCols.Contains("CompDate"))
                 SetValue(ref _CompDate, row["CompDate"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string STATUS_ENUM_Precess = "P";//1.提交等待审核中;
        public const string STATUS_ENUM_Complete = "C";//2.审核完成;

    }
}
