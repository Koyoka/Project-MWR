using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWInvAuthorizeAttach : BaseDataModule
    {

        private static string TableName = "MWInvAuthorizeAttach";
        public TblMWInvAuthorizeAttach()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"InvAttachId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"InvAuthId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Path",SqlCommonFn.DataColumnType.STRING,128)
        };

        public static DataColumnInfo getInvAttachIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getInvAuthIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getPathColumn()
        {
            return Columns[2];
        }

        private int _InvAttachId = 0;
        private int _InvAuthId = 0;
        private string _Path = "";

        public int InvAttachId
        {
            get
            {
                return _InvAttachId;
            }
            set
            {
                _InvAttachId = value;
            }
        }
        public int InvAuthId
        {
            get
            {
                return _InvAuthId;
            }
            set
            {
                _InvAuthId = value;
            }
        }
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("InvAttachId"))
                 SetValue(ref _InvAttachId, row["InvAttachId"]);
             if(dataCols.Contains("InvAuthId"))
                 SetValue(ref _InvAuthId, row["InvAuthId"]);
             if(dataCols.Contains("Path"))
                 SetValue(ref _Path, row["Path"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }


    }
}
