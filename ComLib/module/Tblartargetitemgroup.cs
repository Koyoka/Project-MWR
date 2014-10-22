using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tblartargetitemgroup : BaseDataModule
    {

        private static string TableName = "artargetitemgroup";
        public Tblartargetitemgroup()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,true,false,"id",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"userId",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"title",SqlCommonFn.DataColumnType.STRING,64),
            new DataColumnInfo(false,true,false,false,"createDate",SqlCommonFn.DataColumnType.DATETIME,0)
        };

        public static DataColumnInfo getIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getUserIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getTitleColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getCreateDateColumn()
        {
            return Columns[3];
        }

        private int _id = 0;
        private string _userId = "";
        private string _title = "";
        private DateTime _createDate = DateTime.MinValue;

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
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
        public string title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
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



    }
}
