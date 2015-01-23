using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWEmploy : BaseDataModule
    {

        private static string TableName = "MWEmploy";
        public TblMWEmploy()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"EmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"EmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"UserGroupId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"EmpyType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"UserName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,true,"Password",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getEmpyCodeColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getEmpyNameColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getUserGroupIdColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getEmpyTypeColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getUserNameColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getPasswordColumn()
        {
            return Columns[5];
        }

        private string _EmpyCode = "";
        private string _EmpyName = "";
        private int _UserGroupId = 0;
        private string _EmpyType = "";
        private string _UserName = "";
        private string _Password = "";

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
        public int UserGroupId
        {
            get
            {
                return _UserGroupId;
            }
            set
            {
                _UserGroupId = value;
            }
        }
        public string EmpyType
        {
            get
            {
                return _EmpyType;
            }
            set
            {
                _EmpyType = value;
            }
        }
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
             SetValue(ref _EmpyCode, row["EmpyCode"]);
             SetValue(ref _EmpyName, row["EmpyName"]);
             SetValue(ref _UserGroupId, row["UserGroupId"]);
             SetValue(ref _EmpyType, row["EmpyType"]);
             SetValue(ref _UserName, row["UserName"]);
             SetValue(ref _Password, row["Password"]);
         }

        public const string EMPYTYPE_ENUM_Driver = "D";//司机;
        public const string EMPYTYPE_ENUM_Inspector = "I";//跟车员;
        public const string EMPYTYPE_ENUM_WorkStation = "S";//工作站操作员;

    }
}
