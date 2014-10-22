using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tblarcustomeraccount : BaseDataModule
    {

        private static string TableName = "arcustomeraccount";
        public Tblarcustomeraccount()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,true,false,"accountId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,false,false,false,"userName",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"targetBuildCount",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"addDate",SqlCommonFn.DataColumnType.DATETIME,0)
        };

        public static DataColumnInfo getAccountIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getUserNameColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getTargetBuildCountColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getAddDateColumn()
        {
            return Columns[3];
        }

        private int _accountId = 0;
        private string _userName = "";
        private int _targetBuildCount = 0;
        private DateTime _addDate = DateTime.MinValue;

        public int accountId
        {
            get
            {
                return _accountId;
            }
            set
            {
                _accountId = value;
            }
        }
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
        public int targetBuildCount
        {
            get
            {
                return _targetBuildCount;
            }
            set
            {
                _targetBuildCount = value;
            }
        }
        public DateTime addDate
        {
            get
            {
                return _addDate;
            }
            set
            {
                _addDate = value;
            }
        }



    }
}
