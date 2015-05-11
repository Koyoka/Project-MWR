using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblSysLog : BaseDataModule
    {

        private static string TableName = "SysLog";
        public TblSysLog()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"LogId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Desc",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"Remark",SqlCommonFn.DataColumnType.STRING,65535),
            new DataColumnInfo(false,true,false,false,"LogDate",SqlCommonFn.DataColumnType.DATETIME,0)
        };

        public static DataColumnInfo getLogIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getDescColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getRemarkColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getLogDateColumn()
        {
            return Columns[3];
        }

        private int _LogId = 0;
        private string _Desc = "";
        private string _Remark = "";
        private DateTime _LogDate = DateTime.MinValue;

        public int LogId
        {
            get
            {
                return _LogId;
            }
            set
            {
                _LogId = value;
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
        public DateTime LogDate
        {
            get
            {
                return _LogDate;
            }
            set
            {
                _LogDate = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("LogId"))
                 SetValue(ref _LogId, row["LogId"]);
             if(dataCols.Contains("Desc"))
                 SetValue(ref _Desc, row["Desc"]);
             if(dataCols.Contains("Remark"))
                 SetValue(ref _Remark, row["Remark"]);
             if(dataCols.Contains("LogDate"))
                 SetValue(ref _LogDate, row["LogDate"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }


    }
}
