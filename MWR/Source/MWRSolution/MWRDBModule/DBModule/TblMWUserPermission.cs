using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWUserPermission : BaseDataModule
    {

        private static string TableName = "MWUserPermission";
        public TblMWUserPermission()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"id",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"UserGroupId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"FuncGroupId",SqlCommonFn.DataColumnType.INT,10)
        };

        public static DataColumnInfo getIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getUserGroupIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getFuncGroupIdColumn()
        {
            return Columns[2];
        }

        private int _id = 0;
        private int _UserGroupId = 0;
        private int _FuncGroupId = 0;

        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public int UserGroupId
        {
            get
            {
                return _UserGroupId;
            }
            set
            {
                _UserGroupId = value;
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

         public override void SetValue(System.Data.DataRow row)
         {
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("id"))
                 SetValue(ref _id, row["id"]);
             if(dataCols.Contains("UserGroupId"))
                 SetValue(ref _UserGroupId, row["UserGroupId"]);
             if(dataCols.Contains("FuncGroupId"))
                 SetValue(ref _FuncGroupId, row["FuncGroupId"]);
         }


    }
}
