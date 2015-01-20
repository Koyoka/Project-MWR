using System;
using System.Collections.Generic;
using System.Text;


namespace ComLib.db
{
    public class SqlWhere : SqlQueryBase
    {
        private SqlCommonFn.SqlWhereLinkType _linkType = SqlCommonFn.SqlWhereLinkType.AND;

        public SqlWhere()
        { }

        public SqlWhere(SqlCommonFn.SqlWhereLinkType lt)
        {
            _linkType = lt;
        }

        public void SetLinkType(SqlCommonFn.SqlWhereLinkType lt)
        {
            _linkType = lt;
        }

        public void AddWhere(SqlWhere sw)
        {
            if (sw != null)
            {
                buildSqlList.Add(sw.getGroupSql());
            }

        }

        public SqlWhere AddIsNull(DataColumnInfo column)
        {
            string defineWhereStr = "";

            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    " IS NULL";

            buildSqlList.Add(defineWhereStr);
            return this;
        }

        public SqlWhere AddCompareValue(DataColumnInfo column, SqlCommonFn.SqlWhereCompareEnum compareType, object val)
        {

            string defineWhereStr = "";

            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    SqlCommonFn.FormatSqlCompareEnumString(compareType) +
                    SqlCommonFn.FormatSqlValueString(val);

            buildSqlList.Add(defineWhereStr);
            return this;
        }
        public SqlWhere AddDateTimeCompareValue(DataColumnInfo column, SqlCommonFn.SqlWhereCompareEnum compareType, DateTime val,SqlCommonFn.SqlWhereDateTimeFormatEnum dateFormat)
        {
            string defineWhereStr = "";

            defineWhereStr =
                    SqlCommonFn.FormatSqlDateTimeColumnString(column.ColumnName, dateFormat) +
                    SqlCommonFn.FormatSqlCompareEnumString(compareType) +
                    SqlCommonFn.FormatSqlDateTimeString(val,dateFormat);

            buildSqlList.Add(defineWhereStr);
            return this;
        }


        public SqlWhere AddInValues(DataColumnInfo column,params object[] vals)
        {
            string defineWhereStr = "";
            StringBuilder defineInWhere = new StringBuilder();
            foreach(object v in vals)
            {
                defineInWhere.Append(SqlCommonFn.FormatSqlValueString(v)+",");
            }
            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    " IN (" + defineInWhere.ToString().TrimEnd(',') + ")";
            buildSqlList.Add(defineWhereStr);
            return this;
        }
        public SqlWhere AddInValues(DataColumnInfo column, string sql)
        {
            string defineWhereStr = "";
           
            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    " IN (" + sql + ")";
            buildSqlList.Add(defineWhereStr);
            return this;
        }
        public SqlWhere AddInValues(DataColumnInfo column, SqlQueryMng sqm)
        {
            string defineWhereStr = "";

            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    " IN (" + sqm.getInSql() + ")";
            buildSqlList.Add(defineWhereStr);
            return this;
        }
        public SqlWhere AddNotInValues(DataColumnInfo column, params object[] vals)
        {
            string defineWhereStr = "";
            StringBuilder defineInWhere = new StringBuilder();
            foreach (object v in vals)
            {
                defineInWhere.Append(SqlCommonFn.FormatSqlValueString(v) + ",");
            }
            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    " NOT IN (" + defineInWhere.ToString().TrimEnd(',') + ")";
            buildSqlList.Add(defineWhereStr);
            return this;
        }
        public SqlWhere AddNotInValues(DataColumnInfo column, string sql)
        {
            string defineWhereStr = "";

            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    " NOT IN (" + sql + ")";
            buildSqlList.Add(defineWhereStr);
            return this;
        }
        public SqlWhere AddNotInValues(DataColumnInfo column, SqlQueryMng sqm)
        {
            string defineWhereStr = "";

            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    " NOT IN (" + sqm.getInSql() + ")";
            buildSqlList.Add(defineWhereStr);
            return this;
        }

        //public void AddCompareParams(DataColumnInfo column, SqlCommonFn.SqlWhereCompareEnum compareType, Object val)
        //{
        //    string defineWhereStr = "";

        //    int paramsIndex = getParamsIndex();

        //    defineWhereStr =
        //            SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
        //            SqlCommonFn.FormatSqlCompareEnumString(compareType) +
        //            "@" + column.ColumnName + paramsIndex;
           
        //    //"?";
        //    buildSqlList.Add(defineWhereStr);
        //    //buildParamsList.Add(val);
        //    buildParamsList.Add(new object[] { column.ColumnName + paramsIndex, val, paramsIndex });

        //}

        public SqlWhere AddLikeValue(DataColumnInfo column, SqlCommonFn.SqlWhereLikeEnum likeType, string val)
        {
            string defineWhereStr = "";

            defineWhereStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    SqlCommonFn.FormatSqlLikeEnumString(likeType, val);

            buildSqlList.Add(defineWhereStr);
            return this;
        }

        public string getSql(){
		
		    if(buildSqlList.Count == 0){
			    return "";
		    }
    		
		    bool hasBeanAppend = false;
		    StringBuilder sb = new StringBuilder();
		    foreach(string s in buildSqlList){
    			
			    if(hasBeanAppend){
                    sb.Append(_linkType == SqlCommonFn.SqlWhereLinkType.AND ? " AND " : " OR ");
                    
			    }
			    sb.Append(s);
			    hasBeanAppend = true;
    			
		    }
		    return sb.ToString();
	    }

        public string getGroupSql()
        {
            string s = getSql();
            if(string.IsNullOrEmpty(s))
            {
                return "";
            }

            return "(" + s + ")";
        }

        //public List<object[]> getParams(){
        //    return buildParamsList;
        //}
    }
}
