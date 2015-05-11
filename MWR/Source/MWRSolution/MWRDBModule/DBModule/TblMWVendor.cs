using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWVendor : BaseDataModule
    {

        private static string TableName = "MWVendor";
        public TblMWVendor()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"VendorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"Address",SqlCommonFn.DataColumnType.STRING,128)
        };

        public static DataColumnInfo getVendorCodeColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getVendorColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getAddressColumn()
        {
            return Columns[2];
        }

        private string _VendorCode = "";
        private string _Vendor = "";
        private string _Address = "";

        public string VendorCode
        {
            get
            {
                return _VendorCode;
            }
            set
            {
                _VendorCode = value;
            }
        }
        public string Vendor
        {
            get
            {
                return _Vendor;
            }
            set
            {
                _Vendor = value;
            }
        }
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }

         public override void SetValue(System.Data.DataRow row)
         {
              _dataRow = row;
             System.Data.DataColumnCollection dataCols = row.Table.Columns;
             if(dataCols.Contains("VendorCode"))
                 SetValue(ref _VendorCode, row["VendorCode"]);
             if(dataCols.Contains("Vendor"))
                 SetValue(ref _Vendor, row["Vendor"]);
             if(dataCols.Contains("Address"))
                 SetValue(ref _Address, row["Address"]);
             if(dataCols.Contains("TEM_COLUMN_COUNT"))
                 SetValue(ref _TEM_COLUMN_COUNT, row["TEM_COLUMN_COUNT"]);
         }


    }
}
