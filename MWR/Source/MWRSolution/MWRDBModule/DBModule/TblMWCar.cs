using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWCar : BaseDataModule
    {

        private static string TableName = "MWCar";
        public TblMWCar()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"CarCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Desc",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getCarCodeColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getDescColumn()
        {
            return Columns[1];
        }

        private string _CarCode = "";
        private string _Desc = "";

        public string CarCode
        {
            get
            {
                return _CarCode;
            }
            set
            {
                _CarCode = value;
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

         public override void SetValue(System.Data.DataRow row)
         {
             SetValue(ref _CarCode, row["CarCode"]);
             SetValue(ref _Desc, row["Desc"]);
         }


    }
}
