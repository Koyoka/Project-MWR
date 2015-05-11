using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWSynclog : BaseDataModule
    {

        private static string TableName = "MWSynclog";
        public TblMWSynclog()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"SyncDateTime",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"Remark",SqlCommonFn.DataColumnType.STRING,128)
        };

        public static DataColumnInfo getSyncDateTimeColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getRemarkColumn()
        {
            return Columns[2];
        }

        private DateTime _SyncDateTime = DateTime.MinValue;
        private string _Status = "";
        private string _Remark = "";

        public DateTime SyncDateTime
        {
            get
            {
                return _SyncDateTime;
            }
            set
            {
                _SyncDateTime = value;
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
        public string Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("SyncDateTime"))
                 SetValue(ref _SyncDateTime, row["SyncDateTime"]);
             if(dataCols.Contains("Status"))
                 SetValue(ref _Status, row["Status"]);
             if(dataCols.Contains("Remark"))
                 SetValue(ref _Remark, row["Remark"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string STATUS_ENUM_Complete = "C";//同步完成;
        public const string STATUS_ENUM_Error = "E";//同步出错;

    }
}
