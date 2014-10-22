using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tblarbizcustomerdetail : BaseDataModule
    {

        private static string TableName = "arbizcustomerdetail";
        public Tblarbizcustomerdetail()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"userId",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"companyName",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"industry",SqlCommonFn.DataColumnType.STRING,32),
            new DataColumnInfo(false,true,false,false,"address",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"phoneNum",SqlCommonFn.DataColumnType.STRING,32)
        };

        public static DataColumnInfo getUserIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getCompanyNameColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getIndustryColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getAddressColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getPhoneNumColumn()
        {
            return Columns[4];
        }

        private string _userId = "";
        private string _companyName = "";
        private string _industry = "";
        private string _address = "";
        private string _phoneNum = "";

        public string userId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        public string companyName
        {
            get
            {
                return _companyName;
            }
            set
            {
                _companyName = value;
            }
        }
        public string industry
        {
            get
            {
                return _industry;
            }
            set
            {
                _industry = value;
            }
        }
        public string address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string phoneNum
        {
            get
            {
                return _phoneNum;
            }
            set
            {
                _phoneNum = value;
            }
        }



    }
}
