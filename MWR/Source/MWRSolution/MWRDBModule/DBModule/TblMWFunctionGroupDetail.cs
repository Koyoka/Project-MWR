using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWFunctionGroupDetail : BaseDataModule
    {

        private static string TableName = "MWFunctionGroupDetail";
        public TblMWFunctionGroupDetail()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"FuncGroupDtlId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"FuncGroupId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"FuncTag",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getFuncGroupDtlIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getFuncGroupIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getFuncTagColumn()
        {
            return Columns[2];
        }

        private int _FuncGroupDtlId = 0;
        private int _FuncGroupId = 0;
        private string _FuncTag = "";

        public int FuncGroupDtlId
        {
            get
            {
                return _FuncGroupDtlId;
            }
            set
            {
                _FuncGroupDtlId = value;
            }
        }
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

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("FuncGroupDtlId"))
                 SetValue(ref _FuncGroupDtlId, row["FuncGroupDtlId"]);
             if(dataCols.Contains("FuncGroupId"))
                 SetValue(ref _FuncGroupId, row["FuncGroupId"]);
             if(dataCols.Contains("FuncTag"))
                 SetValue(ref _FuncTag, row["FuncTag"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }


    }
}
