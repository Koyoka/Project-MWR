using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWCarDispatch : BaseDataModule
    {

        private static string TableName = "MWCarDispatch";
        public TblMWCarDispatch()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"CarDisId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"CarCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"OutDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"InDate",SqlCommonFn.DataColumnType.DATETIME,0)
        };

        public static DataColumnInfo getCarDisIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getCarCodeColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getOutDateColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getInDateColumn()
        {
            return Columns[3];
        }

        private int _CarDisId = 0;
        private string _CarCode = "";
        private DateTime _OutDate = DateTime.MinValue;
        private DateTime _InDate = DateTime.MinValue;

        public int CarDisId
        {
            get
            {
                return _CarDisId;
            }
            set
            {
                _CarDisId = value;
            }
        }
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
        public DateTime OutDate
        {
            get
            {
                return _OutDate;
            }
            set
            {
                _OutDate = value;
            }
        }
        public DateTime InDate
        {
            get
            {
                return _InDate;
            }
            set
            {
                _InDate = value;
            }
        }



    }
}
