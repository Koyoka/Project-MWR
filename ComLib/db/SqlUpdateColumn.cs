using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class SqlUpdateColumn : SqlQueryBase
    {
        private bool hasErr = false;
        private DataColumnInfo[] _columns;
        public DataColumnInfo[] Columns
        {
            get
            {
                return _columns;
            }
        }
        public String ErrMsg = "";
        //	private ArrayList<String> buildSqlList = new ArrayList<String>();

        public void AddByParams(DataColumnInfo column, Object val)
        {
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
            string defineUpdateParam =
                   SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                   " = " +
                   //new p(
                    "@" + column.ColumnName + paramsIndex//buildParamsList.Count
                    ;
                   //);
             buildParamsList.Add(
                    new object[] { column.ColumnName + paramsIndex, 
                    (column.EncryptAble && column.ColumnType == SqlCommonFn.DataColumnType.STRING ?
                               SqlCommonFn.EncryptString(val.ToString()) :
                               val)
                    , paramsIndex }
                    );
            buildSqlList.Add(defineUpdateParam);
        }
        
        public void Add(params DataColumnInfo[] columns)
        {
            _columns = columns;
        }

        public void Add(DataColumnInfo column, Object val)
        {

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

            String defineUpdateParam =
                    SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                    " = " +
                    SqlCommonFn.FormatSqlValueString(
                        (column.EncryptAble && column.ColumnType == SqlCommonFn.DataColumnType.STRING ?
                                SqlCommonFn.EncryptString(val.ToString()) :
                                val)
                    );
            //				SqlCommonFn.FormatSqlValueString(val);
            buildSqlList.Add(defineUpdateParam);

        }
        public void AddJoinSelf(DataColumnInfo column, Object val)
        {
            if (column.ColumnType == SqlCommonFn.DataColumnType.STRING)
            {
                throw new Exception(Error.ErrorMng.GetCodingError("", "AddJoinSelf", "AddJoinSelf method need use unstring column"));
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
            String defineUpdateParam =
                   SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) +
                   " = " +
                   SqlCommonFn.FormatSqlColumnNameString(column.ColumnName) + " + " +
                   val;
            //				SqlCommonFn.FormatSqlValueString(val);
            buildSqlList.Add(defineUpdateParam);
        }

        public string getSql(){
		    if(hasErr){
			    return null;
		    }

            if (buildSqlList.Count == 0)
            {
                ErrMsg = "no column add to update";
                return null;
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
