using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace ComLib.module
{

    public class Tblartargetitem : BaseDataModule
    {

        private static string TableName = "artargetitem";
        public Tblartargetitem()
        {
        }
        public static string getFormatTableName()
        {
            return SqlCommonFn.FormatSqlTableNameString(TableName);
        }

        public static DataColumnInfo[] Columns = 
                new DataColumnInfo[]{
            new DataColumnInfo(true,false,false,false,"id",SqlCommonFn.DataColumnType.STRING,32),
            new DataColumnInfo(false,true,false,false,"targetGroupId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,false,false,false,"userId",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"targetMetaDataId",SqlCommonFn.DataColumnType.INT,10),
            new DataColumnInfo(false,true,false,false,"target_id",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"active_flag",SqlCommonFn.DataColumnType.BOOL,1),
            new DataColumnInfo(false,true,false,false,"name",SqlCommonFn.DataColumnType.STRING,64),
            new DataColumnInfo(false,true,false,false,"width",SqlCommonFn.DataColumnType.FLOAT,12),
            new DataColumnInfo(false,true,false,false,"tracking_rating",SqlCommonFn.DataColumnType.INT,5),
            new DataColumnInfo(false,true,false,false,"reco_rating",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"imageLocName",SqlCommonFn.DataColumnType.STRING,128),
            new DataColumnInfo(false,true,false,false,"createDate",SqlCommonFn.DataColumnType.DATETIME,0),
            new DataColumnInfo(false,true,false,false,"status",SqlCommonFn.DataColumnType.STRING,2),
            new DataColumnInfo(false,true,false,false,"targetMetaData",SqlCommonFn.DataColumnType.STRING,65535)
        };

        public static DataColumnInfo getIdColumn()
        {
            return Columns[0];
        }
        public static DataColumnInfo getTargetGroupIdColumn()
        {
            return Columns[1];
        }
        public static DataColumnInfo getUserIdColumn()
        {
            return Columns[2];
        }
        public static DataColumnInfo getTargetMetaDataIdColumn()
        {
            return Columns[3];
        }
        public static DataColumnInfo getTarget_idColumn()
        {
            return Columns[4];
        }
        public static DataColumnInfo getActive_flagColumn()
        {
            return Columns[5];
        }
        public static DataColumnInfo getNameColumn()
        {
            return Columns[6];
        }
        public static DataColumnInfo getWidthColumn()
        {
            return Columns[7];
        }
        public static DataColumnInfo getTracking_ratingColumn()
        {
            return Columns[8];
        }
        public static DataColumnInfo getReco_ratingColumn()
        {
            return Columns[9];
        }
        public static DataColumnInfo getImageLocNameColumn()
        {
            return Columns[10];
        }
        public static DataColumnInfo getCreateDateColumn()
        {
            return Columns[11];
        }
        public static DataColumnInfo getStatusColumn()
        {
            return Columns[12];
        }
        public static DataColumnInfo getTargetMetaDataColumn()
        {
            return Columns[13];
        }

        private string _id = "";
        private int _targetGroupId = 0;
        private string _userId = "";
        private int _targetMetaDataId = 0;
        private string _target_id = "";
        private bool _active_flag = false;
        private string _name = "";
        private float _width = 0;
        private int _tracking_rating = 0;
        private string _reco_rating = "";
        private string _imageLocName = "";
        private DateTime _createDate = DateTime.MinValue;
        private string _status = "";
        private string _targetMetaData = "";

        public string id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public int targetGroupId
        {
            get
            {
                return _targetGroupId;
            }
            set
            {
                _targetGroupId = value;
            }
        }
        public string userId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        public int targetMetaDataId
        {
            get
            {
                return _targetMetaDataId;
            }
            set
            {
                _targetMetaDataId = value;
            }
        }
        public string target_id
        {
            get
            {
                return _target_id;
            }
            set
            {
                _target_id = value;
            }
        }
        public bool active_flag
        {
            get
            {
                return _active_flag;
            }
            set
            {
                _active_flag = value;
            }
        }
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public float width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int tracking_rating
        {
            get
            {
                return _tracking_rating;
            }
            set
            {
                _tracking_rating = value;
            }
        }
        public string reco_rating
        {
            get
            {
                return _reco_rating;
            }
            set
            {
                _reco_rating = value;
            }
        }
        public string imageLocName
        {
            get
            {
                return _imageLocName;
            }
            set
            {
                _imageLocName = value;
            }
        }
        public DateTime createDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate = value;
            }
        }
        public string status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public string targetMetaData
        {
            get
            {
                return _targetMetaData;
            }
            set
            {
                _targetMetaData = value;
            }
        }


        public const string STATUS_ENUM_COMPLETE = "C";//完成;
        public const string STATUS_ENUM_PENDING = "P";//提交创建中;
        public const string STATUS_ENUM_FAILURE = "F";//失败;
        public const string STATUS_ENUM_UPDATE = "U";//更新中;
        public const string STATUS_ENUM_DELETE = "D";//删除中;

    }
}
