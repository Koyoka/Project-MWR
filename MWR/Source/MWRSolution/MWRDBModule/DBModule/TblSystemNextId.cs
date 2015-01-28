using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblSystemNextId : BaseDataModule
    {

        private static string TableName = "SystemNextId";
        public TblSystemNextId()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"IdName",SqlCommonFn.DataColumnType.STRING,50),
            new DataColumnInfo(false,true,false,false,"MinValue",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Increment",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"MaxValue",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"IdValue",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getIdNameColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getMinValueColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getIncrementColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getMaxValueColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getIdValueColumn()
        {
            return Columns[4];
        }

        private string _IdName = "";
        private int _MinValue = 0;
        private int _Increment = 0;
        private int _MaxValue = 0;
        private int _IdValue = 0;

        public string IdName
        {
            get
            {
                return _IdName;
            }
            set
            {
                _IdName = value;
            }
        }
        public int MinValue
        {
            get
            {
                return _MinValue;
            }
            set
            {
                _MinValue = value;
            }
        }
        public int Increment
        {
            get
            {
                return _Increment;
            }
            set
            {
                _Increment = value;
            }
        }
        public int MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                _MaxValue = value;
            }
        }
        public int IdValue
        {
            get
            {
                return _IdValue;
            }
            set
            {
                _IdValue = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("IdName"))
                 SetValue(ref _IdName, row["IdName"]);
             if(dataCols.Contains("MinValue"))
                 SetValue(ref _MinValue, row["MinValue"]);
             if(dataCols.Contains("Increment"))
                 SetValue(ref _Increment, row["Increment"]);
             if(dataCols.Contains("MaxValue"))
                 SetValue(ref _MaxValue, row["MaxValue"]);
             if(dataCols.Contains("IdValue"))
                 SetValue(ref _IdValue, row["IdValue"]);
         }


    }
}
