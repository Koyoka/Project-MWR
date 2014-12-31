using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class SqlUpdateMng : SqlQueryBase
    {

        private string updateTableName = "";
        private bool hasErr = false;
        public string ErrMsg = "";
        private List<string> buildColumnList = new List<string>();
        private List<Object> buildValuesList = new List<Object>();

        public void setQueryTableName(string tabName)
        {
            updateTableName = tabName;
        }

        public void AddByParams(DataColumnInfo column, Object val)
        {
            if (column.IsIncrement && column.ColumnType == SqlCommonFn.DataColumnType.INT)
            {
                return;
            }

            switch (SqlCommonFn.CheckUpdateColumnValue(column, val))
            {
                case 1:
                    hasErr = true;
                    ErrMsg += "[" + column.ColumnName + "] value length failure ";
                    return;
                case 2:
                    hasErr = true;
                    ErrMsg += "[" + column.ColumnName + "] value can't NULL ";
                    return;
                default:
                    break;
            }

            int paramsIndex = getParamsIndex();

            buildColumnList.Add(
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName)
                    );
            buildValuesList.Add(
                    new p(
                    "@" + column.ColumnName + paramsIndex//buildParamsList.Count
                    )
                    );
            buildParamsList.Add(
                    new object[] { column.ColumnName + paramsIndex, val, paramsIndex }
                    );
        }
        public void Add(DataColumnInfo column, Object val)
        {
            if (column.IsIncrement && column.ColumnType == SqlCommonFn.DataColumnType.INT)
            {
                return;
            }

            switch (SqlCommonFn.CheckUpdateColumnValue(column, val))
            {
                case 1:
                    hasErr = true;
                    ErrMsg += "[" + column.ColumnName + "] value length failure ";
                    return;
                case 2:
                    hasErr = true;
                    ErrMsg += "[" + column.ColumnName + "] value can't NULL ";
                    return;
                default:
                    break;
            }

            buildColumnList.Add(
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName)
                    );

            buildValuesList.Add(
                    column.EncryptAble && column.ColumnType == SqlCommonFn.DataColumnType.STRING ?
                            SqlCommonFn.EncryptString(val.ToString()) :
                            val
                    );
        }

        public string getSql()
        {
            return "";
        }

        public string getUpdateSql(SqlUpdateColumn suc, SqlWhere sw)
        {
            string sqlupdatecolumns = suc.getSql();
            if (sqlupdatecolumns == null)
            {
                hasErr = true;
                ErrMsg = suc.ErrMsg;
                return null;
            }

            if (string.IsNullOrEmpty(sqlupdatecolumns))
            //if (sqlupdatecolumns.isEmpty())
            {
                hasErr = true;
                ErrMsg = suc.ErrMsg;
                return null;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE");
            putSpace(sb);
            sb.Append(updateTableName);
            putSpace(sb);
            sb.Append("SET");
            putSpace(sb);
            sb.Append(sqlupdatecolumns);

            buildParamsList.AddRange(suc.getParams());

            String sqlwhere = sw.getSql();
            if (!string.IsNullOrEmpty(sqlwhere))
            //if (!sqlwhere.isEmpty())
            {
                putSpace(sb);
                sb.Append("WHERE");
                putSpace(sb);
                sb.Append(sqlwhere);
                //buildParamsList.addAll(sw.getParams());
                //buildParamsList.AddRange(sw.getParams());
            }

            return SqlCommonFn.FormatQuerySql(sb.ToString());//sb.toString();
        }

        public string getInsertSql()
        {
            if (hasErr)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("INSERT INTO");
            putSpace(sb);
            sb.Append(updateTableName);
            sb.Append("(");
            sb.Append(getInsertColumnsSql());
            sb.Append(")");
            putSpace(sb);
            sb.Append("VALUES");
            sb.Append("(");
            sb.Append(getInsertParamsSql());
            sb.Append(")");
            return SqlCommonFn.FormatQuerySql(sb.ToString());//sb.toString();
        }
        private string getInsertColumnsSql(){
		    bool hasBeanAppend = false;
		    StringBuilder sb = new StringBuilder();
		    foreach(string s in buildColumnList){
			    if(hasBeanAppend){
				    sb.Append(",");
			    }
			    sb.Append(s);
			    hasBeanAppend = true;
		    }
		    return sb.ToString();
	    }
        private string getInsertParamsSql(){
		    bool hasBeanAppend = false;
		    StringBuilder sb = new StringBuilder();
		    foreach(Object o in buildValuesList){
			    if(hasBeanAppend){
				    sb.Append(",");
			    }
			    if(o is p){
                    sb.Append(((p)o).Name);
			    }else{
                    sb.Append(
						    SqlCommonFn.FormatSqlValueString(o)
						    );
			    }
    			
			    hasBeanAppend = true;
		    }
    		
		    return sb.ToString();
	    }

        public string getDeleteSql(SqlWhere sw)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE");
            putSpace(sb);
            sb.Append("FROM");
            putSpace(sb);
            sb.Append(updateTableName);
            putSpace(sb);

            String sqlwhere = sw.getSql();
            if (!string.IsNullOrEmpty(sqlwhere))
            //if (!sqlwhere.isEmpty())
            {
                putSpace(sb);
                sb.Append("WHERE");
                putSpace(sb);
                sb.Append(sw.getSql());
                //buildParamsList.addAll(sw.getParams());
                buildParamsList.AddRange(sw.getParams());
            }

            return SqlCommonFn.FormatQuerySql(sb.ToString());
        }


       
    }
}
