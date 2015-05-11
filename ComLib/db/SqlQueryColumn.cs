using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class SqlQueryColumn
    {
        private int topCount = -1;
        private List<string> buildSqlList = new List<string>();

        public void AddAllColumns()
        {
            buildSqlList.Add("*");
        }
        public void Add(DataColumnInfo column)
        {
            Add(column, "");
        }
        public void Add(DataColumnInfo column, string asName)
        {
            string defineQueryColumnStr = "";

            defineQueryColumnStr =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    (string.IsNullOrEmpty(asName.Trim())
                    ? "" : " AS " + asName);
            
            buildSqlList.Add(defineQueryColumnStr);
        }
        public void Add(string columnName, string asName)
        {
            string defineQueryColumnStr = "";
            defineQueryColumnStr =
                    columnName +
                    (string.IsNullOrEmpty(asName.Trim())
                    ? "" : " AS " + asName);

            buildSqlList.Add(defineQueryColumnStr);
        }

        public void AddCount(DataColumnInfo column)
        {
            string defineQueryColumnStr = "";

            defineQueryColumnStr =
                    "COUNT(" + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) + ")" +
                    " AS " + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName);
            buildSqlList.Add(defineQueryColumnStr);
        }

        public void AddSum(DataColumnInfo column)
        {
            string defineQueryColumnStr = "";

            defineQueryColumnStr =
                    "SUM(" + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) + ")" +
                    " AS " + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName);
            buildSqlList.Add(defineQueryColumnStr);
        }

        public void AddMin(DataColumnInfo column)
        {
            string defineQueryColumnStr = "";
            defineQueryColumnStr =
                    "MIN(" + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) + ")" +
                    " AS " + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName);
            buildSqlList.Add(defineQueryColumnStr);
        }

        public void AddMax(DataColumnInfo column)
        {
            string defineQueryColumnStr = "";

            defineQueryColumnStr =
                    "MAX(" + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) + ")" +
                    " AS " + SqlCommonFn.FormatSqlColumnNameString(column.ColumnName);
            buildSqlList.Add(defineQueryColumnStr);
        }

        public void AddTop(int count)
        {
            topCount = count;
        }
        public int GetTopCount()
        {
            return topCount;
        }

        public string getSql()
        {
		
		    if(buildSqlList.Count == 0){
			    return "*";
		    }
    		
		    bool hasBeanAppend = false;
		    StringBuilder sb = new StringBuilder();
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
