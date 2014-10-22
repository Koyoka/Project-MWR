using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tblartargetmetadata : BaseDataModule
    {

        private static string TableName = "artargetmetadata";
        public Tblartargetmetadata()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,true,false,"id",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"data",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"type",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getDataColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getTypeColumn()
        {
            return Columns[2];
        }

        private int _id = 0;
        private string _data = "";
        private string _type = "";

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
        public string data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        public string type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }



    }
}
