using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class DataColumnInfo
    {
        public string ColumnName = "";
        public SqlCommonFn.DataColumnType ColumnType = SqlCommonFn.DataColumnType.STRING;
        public int ColumnSize = 0;
        public bool IsPK = false;
        public bool AllowNull = false;
        public bool IsIncrement = false;
        public bool EncryptAble = false;

        public DataColumnInfo(bool isPk, bool allowNull, bool isIncrement, bool encryptAble, string name, SqlCommonFn.DataColumnType type, int size)
        {
            IsPK = isPk;
            AllowNull = isPk ? false : allowNull;
            ColumnName = name;
            ColumnType = type;
            ColumnSize = size;
            IsIncrement = isIncrement;
            if (type == SqlCommonFn.DataColumnType.STRING)
            {
                EncryptAble = encryptAble;
            }
        }

        public DataColumnInfo(bool isPk, bool allowNull, bool isIncrement, string name, SqlCommonFn.DataColumnType type, int size)
        {
            IsPK = isPk;
            AllowNull = isPk ? false : allowNull;
            ColumnName = name;
            ColumnType = type;
            ColumnSize = size;
            IsIncrement = isIncrement;

        }
    }
}
