using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class SqlGroupBy : SqlQueryBase
    {
      
        public SqlGroupBy Add(DataColumnInfo column)
        {
            string defineOrderByStr = "";
            defineOrderByStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName);
            buildSqlList.Add(defineOrderByStr);
            return this;
        }
        public SqlGroupBy Add(string columnName)
        {
            string defineOrderByStr = "";
            defineOrderByStr =
                    SqlCommonFn.FormatSqlColumnNameString(columnName);
            buildSqlList.Add(defineOrderByStr);
            return this;
        }

        public string getSql()
        {
            if (buildSqlList.Count == 0)
            {
                return "";
            }

            bool hasBeanAppend = false;
            StringBuilder sb = new StringBuilder();
            sb.Append(" GROUP BY ");
            foreach (string s in buildSqlList)
            {
                if (hasBeanAppend)
                {
                    sb.Append(",");
                }
                sb.Append(s);
                hasBeanAppend = true;
            }
            return sb.ToString();
        }
    }
}
