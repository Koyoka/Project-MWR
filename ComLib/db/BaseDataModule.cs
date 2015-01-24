using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ComLib.db
{
    public abstract class BaseDataModule
    {
        private long _TEM_COLUMN_COUNT = 0;
        public long TEM_COLUMN_COUNT
        {
            get
            {
                return _TEM_COLUMN_COUNT;
            }
            set
            {
                _TEM_COLUMN_COUNT = value;
            }
            
        }

        protected void SetValue(ref string val,object dataVal)
        {
            if (dataVal == DBNull.Value)
                return;
            val = dataVal.ToString();
        }
        protected void SetValue(ref bool val, object dataVal)
        {
            if (dataVal == DBNull.Value)
                return;
            val = (bool)dataVal;
        }
        protected void SetValue(ref int val, object dataVal)
        {
            if (dataVal == DBNull.Value)
                return;
            val = (int)dataVal;
        }
        protected void SetValue(ref decimal val, object dataVal)
        {
            if (dataVal == DBNull.Value)
                return;
            val = (decimal)dataVal;
        }
        protected void SetValue(ref DateTime val, object dataVal)
        {
            if (dataVal == DBNull.Value)
                return;
            val = (DateTime)dataVal;
        }
        protected void SetValue(ref float val, object dataVal)
        {
            if (dataVal == DBNull.Value)
                return;
            val = (float)dataVal;
        }
        public abstract void SetValue(System.Data.DataRow row);

        //public abstract string GetTableName();
        //public abstract DataColumnInfo[] GetColumns();
        //{
        //    return SqlCommonFn.FormatSqlTableNameString(TableName);
        //}
        //{
        //    return true;
        //}


        //	public int PageCount = 0;

        //public int getTEM_COLUMN_COUNT()
        //{
        //    return TEM_COLUMN_COUNT;
        //}


        //public void setTEM_COLUMN_COUNT(int tEM_COLUMN_COUNT)
        //{
        //    TEM_COLUMN_COUNT = tEM_COLUMN_COUNT;
        //}
    }
}
