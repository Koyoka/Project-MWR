using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db.mysql
{
    public class SqlMySqlFn : ISqlBaseFn
    {
        public string sqlColumnNamePrefix = "`";//mysql
        public string sqlColumnNameSuffix = "`";//mysql

	    public override string FormatSqlColumnNameString(string columnName) {
		    return sqlColumnNamePrefix + columnName + sqlColumnNameSuffix ;
	    }

        public override string FormatSqlTableNameString(string tableName)
        {
		    return sqlColumnNamePrefix + tableName + sqlColumnNameSuffix ;
	    }

        public override string FormatTopSqlString(string sql, int topCount)
        {
		    if(topCount == -1){
			    return sql;
		    }
		    StringBuilder sb = new StringBuilder();
		    sb.Append("SELECT * FROM ");
            sb.Append("(");
            sb.Append(sql);
            sb.Append(") AS TEP_TABLE_TOP LIMIT 0," + topCount);
    		
		    return sb.ToString();
	    }

        public override string FormatQuerySql(string sql)
        {
		    return sql+";";
	    }

        public override string FormatQueryPageSql(string sql, int page, int pageSize)
        {
		    StringBuilder sb = new StringBuilder();
            sb.Append("SELECT *, ");
            sb.Append("(SELECT count(*) FROM (" + sql + ") AS TEM_COLUMN_TABLE) AS TEM_COLUMN_COUNT ");
            sb.Append("FROM  ");
            sb.Append("(");
            sb.Append(sql);
            sb.Append(") AS TEP_TABLE_PAGE LIMIT " + (page - 1) * pageSize + "," + pageSize);
    		
		    return sb.ToString();
	    }

        public override string FormatSqlDateTimeString(DateTime val, SqlCommonFn.SqlWhereDateTimeFormatEnum dateFormat)
        {
            string defineFormatString = "";
            
            if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.Y)
            {
                defineFormatString = " DATE_FORMAT('" + ComLib.ComFn.DateTimeToString(val, "yyyy-MM-dd HH:mm:ss") + "','%Y') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YM)
            {
                defineFormatString = " DATE_FORMAT('" + ComLib.ComFn.DateTimeToString(val, "yyyy-MM-dd HH:mm:ss") + "','%Y%m') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD)
            {
                defineFormatString = " DATE_FORMAT('" + ComLib.ComFn.DateTimeToString(val, "yyyy-MM-dd HH:mm:ss") + "','%Y%m%d') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YMDH)
            {
                defineFormatString = " DATE_FORMAT('" + ComLib.ComFn.DateTimeToString(val, "yyyy-MM-dd HH:mm:ss") + "','%Y%m%d%H') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YMDHM)
            {
                defineFormatString = " DATE_FORMAT('" + ComLib.ComFn.DateTimeToString(val, "yyyy-MM-dd HH:mm:ss") + "','%Y%m%d%H%i') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YMDHMS)
            {
                defineFormatString = " DATE_FORMAT('" + ComLib.ComFn.DateTimeToString(val, "yyyy-MM-dd HH:mm:ss") + "','%Y%m%d%H%i%S') ";
            }
            else
            {
                defineFormatString = " DATE_FORMAT('" + ComLib.ComFn.DateTimeToString(val, "yyyy-MM-dd HH:mm:ss") + "','%Y%m%d%H%i%S') ";
            }

            return defineFormatString;
        }

        public override string FormatSqlDateTimeColumnString(string columnName, SqlCommonFn.SqlWhereDateTimeFormatEnum dateFormat)
        {
            string defineFormatString = "";

            if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.Y)
            {
                defineFormatString = " DATE_FORMAT(" + FormatSqlColumnNameString(columnName) + ",'%Y') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YM)
            {
                defineFormatString = " DATE_FORMAT(" + FormatSqlColumnNameString(columnName) + ",'%Y%m') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD)
            {
                defineFormatString = " DATE_FORMAT(" + FormatSqlColumnNameString(columnName) + ",'%Y%m%d') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YMDH)
            {
                defineFormatString = " DATE_FORMAT(" + FormatSqlColumnNameString(columnName) + ",'%Y%m%d%H') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YMDHM)
            {
                defineFormatString = " DATE_FORMAT(" + FormatSqlColumnNameString(columnName) + ",'%Y%m%d%H%i') ";
            }
            else if (dateFormat == SqlCommonFn.SqlWhereDateTimeFormatEnum.YMDHMS)
            {
                defineFormatString = " DATE_FORMAT(" + FormatSqlColumnNameString(columnName) + ",'%Y%m%d%H%i%S') ";
            }
            else
            {
                defineFormatString = " DATE_FORMAT(" + FormatSqlColumnNameString(columnName) + ",'%Y%m%d%H%i%S') ";
            }

            return defineFormatString;
        }
    }
}
