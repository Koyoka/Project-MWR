using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.mysql;
using System.Diagnostics;

namespace ComLib.db
{
    public class SqlCommonFn
    {
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
                //factory mysql
                sqlFnInstance = new SqlMySqlFn();
                //factory sqlserver
                //			sqlFnInstance = new SqlSqlServerFn();
            }

            return sqlFnInstance;
        }

        public static String EncryptString(string s)
        {
            return createSqlFnInstance().EncryptString(s);
        }

        public static String FormatTopSqlString(string sql, int topCount)
        {
            return createSqlFnInstance().FormatTopSqlString(sql, topCount);
        }

        public static String FormatSqlColumnNameString(string columnName)
        {
            return createSqlFnInstance().FormatSqlColumnNameString(columnName);
        }

        public static String FormatSqlTableNameString(string tableName)
        {
            return createSqlFnInstance().FormatSqlTableNameString(tableName);
        }

        public static String FormatSqlValueString(Object val)
        {
            return createSqlFnInstance().FormatSqlValueString(val);
        }

        public static String FormatSqlCompareEnumString(SqlWhereCompareEnum compareType)
        {
            return createSqlFnInstance().FormatSqlCompareEnumString(compareType);
        }

        public static String FormatSqlLikeEnumString(SqlWhereLikeEnum likeType, string val)
        {
            return createSqlFnInstance().FormatSqlLikeEnumString(likeType, val);
        }

        public static String FormatSqlOrderByEnumString(SqlOrderByType orderByType)
        {
            return createSqlFnInstance().FormatSqlOrderByEnumString(orderByType);
        }

        public static String FormatQuerySql(string sql)
        {
            return createSqlFnInstance().FormatQuerySql(sql);
        }

        public static String FormatQueryPageSql(string sql, int page, int pageSize)
        {
            return createSqlFnInstance().FormatQueryPageSql(sql, page, pageSize);
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
