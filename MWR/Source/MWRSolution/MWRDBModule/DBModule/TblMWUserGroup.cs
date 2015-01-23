using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWUserGroup : BaseDataModule
    {

        private static string TableName = "MWUserGroup";
        public TblMWUserGroup()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"UserGroupId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"GroupName",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getUserGroupIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getGroupNameColumn()
        {
            return Columns[1];
        }

        private int _UserGroupId = 0;
        private string _GroupName = "";

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
        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                _GroupName = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
             SetValue(ref _UserGroupId, row["UserGroupId"]);
             SetValue(ref _GroupName, row["GroupName"]);
         }


    }
}
