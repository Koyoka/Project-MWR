using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWFunctionGroup : BaseDataModule
    {

        private static string TableName = "MWFunctionGroup";
        public TblMWFunctionGroup()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"FuncGroupId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"FuncGroupName",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getFuncGroupIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getFuncGroupNameColumn()
        {
            return Columns[1];
        }

        private int _FuncGroupId = 0;
        private string _FuncGroupName = "";

        public int FuncGroupId
        {
            get
            {
                return _FuncGroupId;
            }
            set
            {
                _FuncGroupId = value;
            }
        }
        public string FuncGroupName
        {
            get
            {
                return _FuncGroupName;
            }
            set
            {
                _FuncGroupName = value;
            }
        }



    }
}
