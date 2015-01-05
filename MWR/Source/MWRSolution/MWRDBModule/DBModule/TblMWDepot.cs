using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWDepot : BaseDataModule
    {

        private static string TableName = "MWDepot";
        public TblMWDepot()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"DepotId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Total",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Desc",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getDepotIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getTotalColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getDescColumn()
        {
            return Columns[2];
        }

        private int _DepotId = 0;
        private int _Total = 0;
        private string _Desc = "";

        public int DepotId
        {
            get
            {
                return _DepotId;
            }
            set
            {
                _DepotId = value;
            }
        }
        public int Total
        {
            get
            {
                return _Total;
            }
            set
            {
                _Total = value;
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



    }
}
