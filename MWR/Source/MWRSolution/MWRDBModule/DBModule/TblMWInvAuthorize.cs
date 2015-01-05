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
            new DataColumnInfo(false,true,false,false,"EmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Remark",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"EntryDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"DiffWeight",SqlCommonFn.DataColumnType.FLOAT,12)
        };

        public static DataColumnInfo getInvAuthIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getEmpyCodeColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getRemarkColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getEntryDateColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getDiffWeightColumn()
        {
            return Columns[4];
        }

        private int _InvAuthId = 0;
        private string _EmpyCode = "";
        private string _Remark = "";
        private DateTime _EntryDate = DateTime.MinValue;
        private float _DiffWeight = 0;

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
        public float DiffWeight
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



    }
}
