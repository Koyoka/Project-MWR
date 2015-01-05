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



    }
}
