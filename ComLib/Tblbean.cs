using System;
using System.Collections.Generic;
using System.Text;

using ComLib.db;

namespace ComLib
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
            new DataColumnInfo(false,true,false,false,"colDT",SqlCommonFn.DataColumnType.STRING,0),
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



        public int id = 0;
        public string colNull = "";
        public string colStr = "";
        public int colInt = 0;
        public string colDT = "";
        public float colFloat = 0;
        public bool colBit = false;
        public string colText = "";
        public string colNotNull = "";
        public string colStr2 = "";

        public int getId()
        {
            return id;
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public string getColNull()
        {
            return colNull;
        }
        public void setColNull(string colNull)
        {
            this.colNull = colNull;
        }
        public string getColStr()
        {
            return colStr;
        }
        public void setColStr(string colStr)
        {
            this.colStr = colStr;
        }
        public int getColInt()
        {
            return colInt;
        }
        public void setColInt(int colInt)
        {
            this.colInt = colInt;
        }
        public string getColDT()
        {
            return colDT;
        }
        public void setColDT(string colDT)
        {
            this.colDT = colDT;
        }
        public float getColFloat()
        {
            return colFloat;
        }
        public void setColFloat(float colFloat)
        {
            this.colFloat = colFloat;
        }
        public bool getColBit()
        {
            return colBit;
        }
        public void setColBit(bool colBit)
        {
            this.colBit = colBit;
        }
        public string getColText()
        {
            return colText;
        }
        public void setColText(string colText)
        {
            this.colText = colText;
        }
        public string getColNotNull()
        {
            return colNotNull;
        }
        public void setColNotNull(string colNotNull)
        {
            this.colNotNull = colNotNull;
        }
        public string getColStr2()
        {
            return colStr2;
        }
        public void setColStr2(string colStr2)
        {
            this.colStr2 = colStr2;
        }


        public const string COLSTR_ENUM_PER = "1";//�����û�;
        public const string COLSTR_ENUM_BUS = "2";//��ҵ�û�;

    }
}
