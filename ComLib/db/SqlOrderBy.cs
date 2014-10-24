using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class SqlOrderBy : SqlQueryBase
    {
        public SqlOrderBy Add(DataColumnInfo column)
        {
            Add(column, SqlCommonFn.SqlOrderByType.DESC);
            return this;
        }
        public SqlOrderBy Add(DataColumnInfo column, SqlCommonFn.SqlOrderByType orderByType)
        {
            string defineOrderByStr = "";
            defineOrderByStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    SqlCommonFn.FormatSqlOrderByEnumString(orderByType);
            buildSqlList.Add(defineOrderByStr);
            return this;
        }

        public string getSql()
        {
		    if(buildSqlList.Count == 0){
			    return "";
		    }
    		
		    bool hasBeanAppend = false;
		    StringBuilder sb = new StringBuilder();
		    sb.Append(" ORDER BY ");
		    foreach(string s in buildSqlList){
			    if(hasBeanAppend){
				    sb.Append(",");
			    }
			    sb.Append(s);
			    hasBeanAppend = true;
		    }
		    return sb.ToString();
	    }

    }
}
