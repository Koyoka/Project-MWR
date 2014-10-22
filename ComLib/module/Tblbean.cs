using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tblbean : BaseDataModule
    {

        private static string TableName = "bean";
        public Tblbean()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,true,false,"id",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"colNull",SqlCommonFn.DataColumnType.STRING,1),
            new DataColumnInfo(false,true,false,false,"colStr",SqlCommonFn.DataColumnType.STRING,64),
            new DataColumnInfo(false,true,false,false,"colInt",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"colDT",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"colFloat",SqlCommonFn.DataColumnType.FLOAT,11),
            new DataColumnInfo(false,true,false,false,"colBit",SqlCommonFn.DataColumnType.BOOL,1),
            new DataColumnInfo(false,true,false,false,"colText",SqlCommonFn.DataColumnType.STRING,65535),
            new DataColumnInfo(true,false,false,false,"colNotNull",SqlCommonFn.DataColumnType.STRING,255),
            new DataColumnInfo(false,true,false,false,"colStr2",SqlCommonFn.DataColumnType.STRING,128)
        };

        public static DataColumnInfo getIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getColNullColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getColStrColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getColIntColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getColDTColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getColFloatColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getColBitColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getColTextColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getColNotNullColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getColStr2Column()
        {
            return Columns[9];
        }

        private int _id = 0;
        private string _colNull = "";
        private string _colStr = "";
        private int _colInt = 0;
        private DateTime _colDT = DateTime.MinValue;
        private float _colFloat = 0;
        private bool _colBit = false;
        private string _colText = "";
        private string _colNotNull = "";
        private string _colStr2 = "";

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
        public string colNull
        {
            get
            {
                return _colNull;
            }
            set
            {
                _colNull = value;
            }
        }
        public string colStr
        {
            get
            {
                return _colStr;
            }
            set
            {
                _colStr = value;
            }
        }
        public int colInt
        {
            get
            {
                return _colInt;
            }
            set
            {
                _colInt = value;
            }
        }
        public DateTime colDT
        {
            get
            {
                return _colDT;
            }
            set
            {
                _colDT = value;
            }
        }
        public float colFloat
        {
            get
            {
                return _colFloat;
            }
            set
            {
                _colFloat = value;
            }
        }
        public bool colBit
        {
            get
            {
                return _colBit;
            }
            set
            {
                _colBit = value;
            }
        }
        public string colText
        {
            get
            {
                return _colText;
            }
            set
            {
                _colText = value;
            }
        }
        public string colNotNull
        {
            get
            {
                return _colNotNull;
            }
            set
            {
                _colNotNull = value;
            }
        }
        public string colStr2
        {
            get
            {
                return _colStr2;
            }
            set
            {
                _colStr2 = value;
            }
        }


        public const string COLSTR_ENUM_PER = "1";//个人用户;
        public const string COLSTR_ENUM_BUS = "2";//企业用户;

    }
}
