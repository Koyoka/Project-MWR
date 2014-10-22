using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class SqlQueryMng : SqlQueryBase
    {
        private string queryTableName = "";

        public SqlQueryColumn QueryColumn = null;
        public SqlCondition Condition = null;

        public SqlQueryMng()
        {
            QueryColumn = new SqlQueryColumn();
            Condition = new SqlCondition();
        }

        public void setQueryTableName(string tabName)
        {
            queryTableName = tabName;
        }

        public string getSql()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT");
            putSpace(sb);
            sb.Append(QueryColumn.getSql());
            putSpace(sb);
            sb.Append("FROM");
            putSpace(sb);
            sb.Append(queryTableName);

            string sqlcondition = Condition.getSql();
            if (!string.IsNullOrEmpty(sqlcondition))
            {
                putSpace(sb);
                sb.Append(sqlcondition);
                buildParamsList.AddRange(Condition.getParams());
            }

            string topSql = SqlCommonFn.FormatTopSqlString(sb.ToString(), QueryColumn.GetTopCount());

            return SqlCommonFn.FormatQuerySql(topSql);
        }


        public string getVewSql(string vewSql)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT");
            putSpace(sb);
            sb.Append(QueryColumn.getSql());
            putSpace(sb);
            sb.Append("FROM");
            putSpace(sb);
            sb.Append("(");
            putSpace(sb);
            sb.Append(vewSql);
            putSpace(sb);
            sb.Append(") AS _TEP_TABLE_VEW");

            string sqlcondition = Condition.getSql();
            if(!string.IsNullOrEmpty(sqlcondition))
            {
                putSpace(sb);
                sb.Append(sqlcondition);
                buildParamsList.AddRange(Condition.getParams());
            }

            string topSql = SqlCommonFn.FormatTopSqlString(sb.ToString(), QueryColumn.GetTopCount());
            return SqlCommonFn.FormatQuerySql(topSql);

        }

        public string getPageSql(int page, int pageSize)
        {
            if (page <= 0)
            {
                page = 1;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT");
            putSpace(sb);
            sb.Append(QueryColumn.getSql());
            putSpace(sb);
            sb.Append("FROM");
            putSpace(sb);
            sb.Append(queryTableName);

            string sqlcondition = Condition.getSql();
            if(!string.IsNullOrEmpty(sqlcondition))
            {
                putSpace(sb);
                sb.Append(sqlcondition);
                buildParamsList.AddRange(Condition.getParams());
            }

            string sql = SqlCommonFn.FormatQueryPageSql(sb.ToString(), page, pageSize);
            return SqlCommonFn.FormatQuerySql(sql);
          
        }

    }
}
