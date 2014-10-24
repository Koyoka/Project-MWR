using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace DemoApp.TblModel
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
            new DataColumnInfo(false,true,false,false,"str1",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"int1",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getStr1Column()
        {
            return Columns[1];
        }
        public static DataColumnInfo getInt1Column()
        {
            return Columns[2];
        }

        private int _id = 0;
        private string _str1 = "";
        private int _int1 = 0;

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
        public int int1
        {
            get
            {
                return _int1;
            }
            set
            {
                _int1 = value;
            }
        }


        public const string STR1_ENUM_PER = "2";//个人用户;
        public const string STR1_ENUM_BUS = "1";//企业用户;

    }
}
