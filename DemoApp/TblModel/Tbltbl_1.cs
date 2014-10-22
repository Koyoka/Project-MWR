using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tbltbl_1 : BaseDataModule
    {

        private static string TableName = "tbl_1";
        public Tbltbl_1()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,true,false,"id",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"str1",SqlCommonFn.DataColumnType.STRING,20)
        };

        public static DataColumnInfo getIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getStr1Column()
        {
            return Columns[1];
        }

        private int _id = 0;
        private string _str1 = "";

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
        public string str1
        {
            get
            {
                return _str1;
            }
            set
            {
                _str1 = value;
            }
        }



    }
}
