using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tblarusertargetkey : BaseDataModule
    {

        private static string TableName = "arusertargetkey";
        public Tblarusertargetkey()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,true,false,"id",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"userId",SqlCommonFn.DataColumnType.STRING,64),
            new DataColumnInfo(false,true,false,false,"cloudAKey",SqlCommonFn.DataColumnType.STRING,64),
            new DataColumnInfo(false,true,false,false,"cloudSKey",SqlCommonFn.DataColumnType.STRING,64)
        };

        public static DataColumnInfo getIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getUserIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getCloudAKeyColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getCloudSKeyColumn()
        {
            return Columns[3];
        }

        private int _id = 0;
        private string _userId = "";
        private string _cloudAKey = "";
        private string _cloudSKey = "";

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
        public string cloudAKey
        {
            get
            {
                return _cloudAKey;
            }
            set
            {
                _cloudAKey = value;
            }
        }
        public string cloudSKey
        {
            get
            {
                return _cloudSKey;
            }
            set
            {
                _cloudSKey = value;
            }
        }



    }
}
