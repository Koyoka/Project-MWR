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
