using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWTxnDestroyHeader : BaseDataModule
    {

        private static string TableName = "MWTxnDestroyHeader";
        public TblMWTxnDestroyHeader()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"DestHeaderId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TxnNum",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"StratDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"EndDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"DestWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"DestEmpyName",SqlCommonFn.DataColumnType.STRING,45),
            new DataColumnInfo(false,true,false,false,"DestEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"TotalCrateQty",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"TotalSubWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"TotalTxnWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"Status",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getDestHeaderIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getTxnNumColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getStratDateColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getEndDateColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getDestWSCodeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getDestEmpyNameColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getDestEmpyCodeColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getTotalCrateQtyColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getTotalSubWeightColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getTotalTxnWeightColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[10];
        }

        private int _DestHeaderId = 0;
        private string _TxnNum = "";
        private DateTime _StratDate = DateTime.MinValue;
        private DateTime _EndDate = DateTime.MinValue;
        private string _DestWSCode = "";
        private string _DestEmpyName = "";
        private string _DestEmpyCode = "";
        private int _TotalCrateQty = 0;
        private float _TotalSubWeight = 0;
        private float _TotalTxnWeight = 0;
        private string _Status = "";

        public int DestHeaderId
        {
            get
            {
                return _DestHeaderId;
            }
            set
            {
                _DestHeaderId = value;
            }
        }
        public string TxnNum
        {
            get
            {
                return _TxnNum;
            }
            set
            {
                _TxnNum = value;
            }
        }
        public DateTime StratDate
        {
            get
            {
                return _StratDate;
            }
            set
            {
                _StratDate = value;
            }
        }
        public DateTime EndDate
        {
            get
            {
                return _EndDate;
            }
            set
            {
                _EndDate = value;
            }
        }
        public string DestWSCode
        {
            get
            {
                return _DestWSCode;
            }
            set
            {
                _DestWSCode = value;
            }
        }
        public string DestEmpyName
        {
            get
            {
                return _DestEmpyName;
            }
            set
            {
                _DestEmpyName = value;
            }
        }
        public string DestEmpyCode
        {
            get
            {
                return _DestEmpyCode;
            }
            set
            {
                _DestEmpyCode = value;
            }
        }
        public int TotalCrateQty
        {
            get
            {
                return _TotalCrateQty;
            }
            set
            {
                _TotalCrateQty = value;
            }
        }
        public float TotalSubWeight
        {
            get
            {
                return _TotalSubWeight;
            }
            set
            {
                _TotalSubWeight = value;
            }
        }
        public float TotalTxnWeight
        {
            get
            {
                return _TotalTxnWeight;
            }
            set
            {
                _TotalTxnWeight = value;
            }
        }
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }



    }
}
