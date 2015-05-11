using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWWorkStation : BaseDataModule
    {

        private static string TableName = "MWWorkStation";
        public TblMWWorkStation()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"WSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Desc",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"WSType",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"AccessKey",SqlCommonFn.DataColumnType.STRING,40),
            new DataColumnInfo(false,true,false,false,"SecretKey",SqlCommonFn.DataColumnType.STRING,40)
        };

        public static DataColumnInfo getWSCodeColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getDescColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getWSTypeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getAccessKeyColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getSecretKeyColumn()
        {
            return Columns[4];
        }

        private string _WSCode = "";
        private string _Desc = "";
        private string _WSType = "";
        private string _AccessKey = "";
        private string _SecretKey = "";

        public string WSCode
        {
            get
            {
                return _WSCode;
            }
            set
            {
                _WSCode = value;
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
        public string WSType
        {
            get
            {
                return _WSType;
            }
            set
            {
                _WSType = value;
            }
        }
        public string AccessKey
        {
            get
            {
                return _AccessKey;
            }
            set
            {
                _AccessKey = value;
            }
        }
        public string SecretKey
        {
            get
            {
                return _SecretKey;
            }
            set
            {
                _SecretKey = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("WSCode"))
                 SetValue(ref _WSCode, row["WSCode"]);
             if(dataCols.Contains("Desc"))
                 SetValue(ref _Desc, row["Desc"]);
             if(dataCols.Contains("WSType"))
                 SetValue(ref _WSType, row["WSType"]);
             if(dataCols.Contains("AccessKey"))
                 SetValue(ref _AccessKey, row["AccessKey"]);
             if(dataCols.Contains("SecretKey"))
                 SetValue(ref _SecretKey, row["SecretKey"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }

        public const string WSTYPE_ENUM_InvWorkStation = "I";//出入库工作站;
        public const string WSTYPE_ENUM_DesWorkStation = "D";//处置工作站;
        public const string WSTYPE_ENUM_MobWorkStation = "M";//手机终端;
        public const string WSTYPE_ENUM_WaitWorkStation = "W";//等待验证的手机终端号;

    }
}
