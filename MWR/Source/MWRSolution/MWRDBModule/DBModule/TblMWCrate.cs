using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWCrate : BaseDataModule
    {

        private static string TableName = "MWCrate";
        public TblMWCrate()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"CrateCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Desc",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getCrateCodeColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getDescColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[2];
        }

        private string _CrateCode = "";
        private string _Desc = "";
        private string _Status = "";

        public string CrateCode
        {
            get
            {
                return _CrateCode;
            }
            set
            {
                _CrateCode = value;
            }
        }
        public string Desc
        {
            get
            {
                return _Desc;
            }
            set
            {
                _Desc = value;
            }
        }
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("CrateCode"))
                 SetValue(ref _CrateCode, row["CrateCode"]);
             if(dataCols.Contains("Desc"))
                 SetValue(ref _Desc, row["Desc"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string STATUS_ENUM_Active = "A";//使用中;
        public const string STATUS_ENUM_Void = "V";//作废;

    }
}
