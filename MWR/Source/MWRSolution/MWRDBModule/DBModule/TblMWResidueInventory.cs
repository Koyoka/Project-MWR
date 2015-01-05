using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{

    public class TblMWResidueInventory : BaseDataModule
    {

        private static string TableName = "MWResidueInventory";
        public TblMWResidueInventory()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"ResdInvId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"InvWeight",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"EntryDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"RecoWSCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"RecoEmpyCode",SqlCommonFn.DataColumnType.STRING,20),
            new DataColumnInfo(false,true,false,false,"HandlingType",SqlCommonFn.DataColumnType.STRING,2)
        };

        public static DataColumnInfo getResdInvIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getInvWeightColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getEntryDateColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getRecoWSCodeColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getRecoEmpyCodeColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getHandlingTypeColumn()
        {
            return Columns[5];
        }

        private int _ResdInvId = 0;
        private float _InvWeight = 0;
        private DateTime _EntryDate = DateTime.MinValue;
        private string _RecoWSCode = "";
        private string _RecoEmpyCode = "";
        private string _HandlingType = "";

        public int ResdInvId
        {
            get
            {
                return _ResdInvId;
            }
            set
            {
                _ResdInvId = value;
            }
        }
        public float InvWeight
        {
            get
            {
                return _InvWeight;
            }
            set
            {
                _InvWeight = value;
            }
        }
        public DateTime EntryDate
        {
            get
            {
                return _EntryDate;
            }
            set
            {
                _EntryDate = value;
            }
        }
        public string RecoWSCode
        {
            get
            {
                return _RecoWSCode;
            }
            set
            {
                _RecoWSCode = value;
            }
        }
        public string RecoEmpyCode
        {
            get
            {
                return _RecoEmpyCode;
            }
            set
            {
                _RecoEmpyCode = value;
            }
        }
        public string HandlingType
        {
            get
            {
                return _HandlingType;
            }
            set
            {
                _HandlingType = value;
            }
        }



    }
}
