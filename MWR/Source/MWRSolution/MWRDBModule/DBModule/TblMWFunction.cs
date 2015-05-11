using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWFunction : BaseDataModule
    {

        private static string TableName = "MWFunction";
        public TblMWFunction()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"FuncTag",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"FuncName",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getFuncTagColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getFuncNameColumn()
        {
            return Columns[1];
        }

        private string _FuncTag = "";
        private string _FuncName = "";

        public string FuncTag
        {
            get
            {
                return _FuncTag;
            }
            set
            {
                _FuncTag = value;
            }
        }
        public string FuncName
        {
            get
            {
                return _FuncName;
            }
            set
            {
                _FuncName = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("FuncTag"))
                 SetValue(ref _FuncTag, row["FuncTag"]);
             if(dataCols.Contains("FuncName"))
                 SetValue(ref _FuncName, row["FuncName"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }


    }
}
