using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWEmploy : BaseDataModule
    {

        private static string TableName = "MWEmploy";
        public TblMWEmploy()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"EmpyId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"EmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Name",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"UserGroupId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"EmpyType",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getEmpyIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getEmpyCodeColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getNameColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getUserGroupIdColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getEmpyTypeColumn()
        {
            return Columns[4];
        }

        private int _EmpyId = 0;
        private string _EmpyCode = "";
        private string _Name = "";
        private int _UserGroupId = 0;
        private string _EmpyType = "";

        public int EmpyId
        {
            get
            {
                return _EmpyId;
            }
            set
            {
                _EmpyId = value;
            }
        }
        public string EmpyCode
        {
            get
            {
                return _EmpyCode;
            }
            set
            {
                _EmpyCode = value;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
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
        public string EmpyType
        {
            get
            {
                return _EmpyType;
            }
            set
            {
                _EmpyType = value;
            }
        }



    }
}
