using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tblarcustomer : BaseDataModule
    {

        private static string TableName = "arcustomer";
        public Tblarcustomer()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"userName",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,true,"password",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"nickName",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"createDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"userType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"sex",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"age",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"interest",SqlCommonFn.DataColumnType.STRING,128)
        };

        public static DataColumnInfo getUserNameColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getPasswordColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getNickNameColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getCreateDateColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getUserTypeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getSexColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getAgeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getInterestColumn()
        {
            return Columns[7];
        }

        private string _userName = "";
        private string _password = "";
        private string _nickName = "";
        private DateTime _createDate = DateTime.MinValue;
        private string _userType = "";
        private string _sex = "";
        private int _age = 0;
        private string _interest = "";

        public string userName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string nickName
        {
            get
            {
                return _nickName;
            }
            set
            {
                _nickName = value;
            }
        }
        public DateTime createDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }
        public string userType
        {
            get
            {
                return _userType;
            }
            set
            {
                _userType = value;
            }
        }
        public string sex
        {
            get
            {
                return _sex;
            }
            set
            {
                _sex = value;
            }
        }
        public int age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
        public string interest
        {
            get
            {
                return _interest;
            }
            set
            {
                _interest = value;
            }
        }


        public const string USERTYPE_ENUM_PER = "2";//个人用户;
        public const string USERTYPE_ENUM_BUS = "1";//企业用户;
        public const string SEX_ENUM_Male = "M";//男 ;
        public const string SEX_ENUM_Female = "F";//女;

    }
}
