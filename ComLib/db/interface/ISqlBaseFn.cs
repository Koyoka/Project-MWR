﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db.mysql
{
    public abstract class ISqlBaseFn
    {
        public abstract string FormatSqlColumnNameString(string columnName);
        public abstract string FormatSqlTableNameString(string tableName);
        public abstract string FormatTopSqlString(string sql, int topCount);
        public abstract string FormatQuerySql(string sql);
        public abstract string FormatQueryPageSql(string sql, int page, int pageSize);
        public abstract string FormatSqlDateTimeString(DateTime val, SqlCommonFn.SqlWhereDateTimeFormatEnum dateFormat);
        public abstract string FormatSqlDateTimeColumnString(string columnName,SqlCommonFn.SqlWhereDateTimeFormatEnum dateFormat);
        public abstract string FormatSqlDateTimeColumnString2(string columnName, SqlCommonFn.SqlWhereDateTimeFormatEnum dateFormat);

        private const string key = "pMwrdbWORDTaBlE";
        public String DecryptString(string s)
        {
            return ComFn.DecryptDBPassword(key, s);
        }
        public String EncryptString(String s)
        {

            return ComFn.EncryptDBPassword(key, s);
        }

        //public string FormatSqlValueString(Object val){
        //    string formatString = "";
        //    if (val is string)
        //    {
        //        formatString = "N'" + val + "'";
        //    }
        //    else if (val is bool)
        //    {
        //        formatString = ((bool)val ? 1 : 0) + "";
        //    }
        //    else if (val is DateTime)
        //    {
        //        formatString = "N'" + val + "'";
        //    }
        //    else
        //    {
        //        formatString = val + "";
        //    }
    		
        //    return formatString;
        //}
        public abstract string FormatSqlValueString(Object val);

        public string FormatSqlCompareEnumString(SqlCommonFn.SqlWhereCompareEnum compareType)
        {

            string formatString = "";
            if (compareType == SqlCommonFn.SqlWhereCompareEnum.Equals)
            {
                formatString = "=";
            }
            else if (compareType == SqlCommonFn.SqlWhereCompareEnum.Less)
            {
                formatString = "<";
            }
            else if (compareType == SqlCommonFn.SqlWhereCompareEnum.LessEquals)
            {
                formatString = "<=";
            }
            else if (compareType == SqlCommonFn.SqlWhereCompareEnum.More)
            {
                formatString = ">";
            }
            else if (compareType == SqlCommonFn.SqlWhereCompareEnum.MoreEquals)
            {
                formatString = ">=";
            }
            else if (compareType == SqlCommonFn.SqlWhereCompareEnum.UnEquals)
            {
                formatString = "<>";
            }
            else
            {
                formatString = "=";
            }
            return " " + formatString + " ";
            //		return formatString ;
        }

        public abstract string FormatSqlLikeEnumString(SqlCommonFn.SqlWhereLikeEnum likeType, string val);
        //public string FormatSqlLikeEnumString(SqlCommonFn.SqlWhereLikeEnum likeType, string val)
        //{

        //    string formatString = "";
        //    if (likeType == SqlCommonFn.SqlWhereLikeEnum.BeforeLike)
        //    {
        //        formatString = " LIKE " + "N'" + val + "%'";
        //    }
        //    else if (likeType == SqlCommonFn.SqlWhereLikeEnum.AfterLike)
        //    {
        //        formatString = " LIKE " + "N'%" + val + "'";
        //    }
        //    else if (likeType == SqlCommonFn.SqlWhereLikeEnum.MidLike)
        //    {
        //        formatString = " LIKE " + "N'%" + val + "%'";
        //    }
        //    else if (likeType == SqlCommonFn.SqlWhereLikeEnum.LikeIt)
        //    {
        //        formatString = " LIKE " + "N'" + val + "'";
        //    }
        //    else
        //    {
        //        formatString = " LIKE " + "N'%" + val + "%'";
        //    }

        //    return formatString;
        //}

        public string FormatSqlOrderByEnumString(SqlCommonFn.SqlOrderByType orderByType)
        {
            string formatString = "";
            if (orderByType == SqlCommonFn.SqlOrderByType.DESC)
            {
                formatString = " DESC ";
            }
            else
            {
                formatString = " ASC ";
            }

            return formatString;
        }



        /**
         *result code
         *1: val length failure
         *2: val can't NULL
         **/
        public int CheckUpdateColumnValue(DataColumnInfo column, Object val)
        {

            if (!column.AllowNull && val == null)
            {
                return 2;
            }

            if (val == null)
            {
                return 0;
            }

            if (column.ColumnType == SqlCommonFn.DataColumnType.STRING)
            {

                return val.ToString().Length > column.ColumnSize ? (column.ColumnSize == 0 ? 0 : 1) : 0;
            }
            //else if (column.ColumnType == SqlCommonFn.DataColumnType.DECIMAL)
            //{
            //    decimal d = 1;
               
            //}

            //		if(!column.AllowNull && val == null){
            //			return 2;
            //		}



            return 0;
        }
    }
}
