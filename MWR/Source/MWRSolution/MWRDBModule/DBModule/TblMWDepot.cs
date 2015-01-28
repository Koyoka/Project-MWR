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
            new DataColumnInfo(true,false,false,false,"DeptCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Total",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Desc",SqlCommonFn.DataColumnType.STRING,45)
        };

        public static DataColumnInfo getDeptCodeColumn()
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

        private string _DeptCode = "";
        private int _Total = 0;
        private string _Desc = "";

        public string DeptCode
        {
            get
            {
                return _DeptCode;
            }
            set
            {
                _DeptCode = value;
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

         public override void SetValue(System.Data.DataRow row)
         {
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("DeptCode"))
                 SetValue(ref _DeptCode, row["DeptCode"]);
             if(dataCols.Contains("Total"))
                 SetValue(ref _Total, row["Total"]);
             if(dataCols.Contains("Desc"))
                 SetValue(ref _Desc, row["Desc"]);
         }


    }
}
