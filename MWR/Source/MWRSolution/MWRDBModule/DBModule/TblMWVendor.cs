using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace MWRDBModule.DBModule
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
            new DataColumnInfo(true,false,false,false,"VendorId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"Vendor",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"VendorCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"Address",SqlCommonFn.DataColumnType.STRING,128)
        };

        public static DataColumnInfo getVendorIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getVendorColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getVendorCodeColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getAddressColumn()
        {
            return Columns[3];
        }

        private int _VendorId = 0;
        private string _Vendor = "";
        private string _VendorCode = "";
        private string _Address = "";

        public int VendorId
        {
            get
            {
                return _VendorId;
            }
            set
            {
                _VendorId = value;
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



    }
}
