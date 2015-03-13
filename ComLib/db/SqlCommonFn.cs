using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.mysql;
using System.Diagnostics;

namespace ComLib.db
{
    public class SqlCommonFn
    {
        public enum SqlWhereDateTimeFormatEnum
        { 
            Y,
            YM,
            YMD,
            YMDH,
            YMDHM,
            YMDHMS
        }

        public enum SqlWhereCompareEnum
        {
            Equals,      //=
            MoreEquals,  //>=
            LessEquals,  //<=
            UnEquals,    //<>
            More,        //>
            Less        //<
        }

        public enum SqlWhereLikeEnum{
		    BeforeLike,		//Like 'xxx%'
	        AfterLike,		//Like '%xxx'
	        MidLike,		//Like '%xxx%'
	        LikeIt			//Like 'xxx'
	    }

        public enum DataColumnType
        {
            STRING, INT, DECIMAL, FLOAT, DOUBLE, BOOL,DATETIME
        }

        public enum SqlWhereLinkType
        {
            AND, OR
        }

        public enum SqlOrderByType
        {
            DESC, ASC
        }

        private static ISqlBaseFn sqlFnInstance = null;
        private static ISqlBaseFn createSqlFnInstance()
        {
            if (sqlFnInstance == null)
            {
                switch (SqlDBMng.DBType)
                {
                    case SqlDBMng.DBTypeEnum.MySQl:
                        //factory mysql
                        sqlFnInstance = new SqlMySqlFn();
                        break;
                    case SqlDBMng.DBTypeEnum.SqlServer:
                        //factory sqlserver
                        //			sqlFnInstance = new SqlSqlServerFn();
                        break;
                }
               
                
            }

            return sqlFnInstance;
        }

        public static string DecryptString(string s)
        {
            return createSqlFnInstance().DecryptString(s);
        }
        public static string EncryptString(string s)
        {
            return createSqlFnInstance().EncryptString(s);
        }

        public static string FormatTopSqlString(string sql, int topCount)
        {
            return createSqlFnInstance().FormatTopSqlString(sql, topCount);
        }

        public static string FormatSqlColumnNameString(string columnName)
        {
            return createSqlFnInstance().FormatSqlColumnNameString(columnName);
        }

        public static string FormatSqlTableNameString(string tableName)
        {
            return createSqlFnInstance().FormatSqlTableNameString(tableName);
        }

        public static string FormatSqlValueString(Object val)
        {
            return createSqlFnInstance().FormatSqlValueString(val);
        }

        public static string FormatSqlCompareEnumString(SqlWhereCompareEnum compareType)
        {
            return createSqlFnInstance().FormatSqlCompareEnumString(compareType);
        }

        public static string FormatSqlLikeEnumString(SqlWhereLikeEnum likeType, string val)
        {
            return createSqlFnInstance().FormatSqlLikeEnumString(likeType, val);
        }

        public static string FormatSqlOrderByEnumString(SqlOrderByType orderByType)
        {
            return createSqlFnInstance().FormatSqlOrderByEnumString(orderByType);
        }

        public static string FormatQuerySql(string sql)
        {
            return createSqlFnInstance().FormatQuerySql(sql);
        }

        public static string FormatQueryPageSql(string sql, int page, int pageSize)
        {
            return createSqlFnInstance().FormatQueryPageSql(sql, page, pageSize);
        }

        public static string FormatSqlDateTimeString(DateTime val,SqlCommonFn.SqlWhereDateTimeFormatEnum dateFormat)
        {
            return createSqlFnInstance().FormatSqlDateTimeString(val, dateFormat);
        }

        public static string FormatSqlDateTimeColumnString(string columnName, SqlCommonFn.SqlWhereDateTimeFormatEnum dateFormat)
        {
            return createSqlFnInstance().FormatSqlDateTimeColumnString(columnName, dateFormat);
        }

        /**
         *result code
         *1: val length failure
         *2: val can't NULL
         **/
        public static int CheckUpdateColumnValue(DataColumnInfo column, Object val)
        {
            return createSqlFnInstance().CheckUpdateColumnValue(column, val);
        }

        private static bool isDebug = true;
        public static void DebugLog(string s){
            if(isDebug)
                Debug.WriteLine(s);
	    }

       
    }
}
