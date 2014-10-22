using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class SqlCondition : SqlQueryBase
    {
        public SqlWhere Where = null;
        public SqlGroupBy GroupBy = null;
        public SqlOrderBy OrderBy = null;

        public SqlCondition()
        {
            Where = new SqlWhere();
            GroupBy = new SqlGroupBy();
            OrderBy = new SqlOrderBy();
        }

        public string getSql()
        {
            StringBuilder sb = new StringBuilder();
            string sqlwhere = Where.getSql();
            if (!string.IsNullOrEmpty(sqlwhere))
            {
                sb.Append("WHERE");
                putSpace(sb);
                sb.Append(sqlwhere);
                buildParamsList.AddRange(Where.getParams());
            }
            sb.Append(OrderBy.getSql());

            return sb.ToString();
        }
    }
}
