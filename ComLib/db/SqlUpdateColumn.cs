using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class SqlUpdateColumn : SqlQueryBase
    {
        private bool hasErr = false;
        public String ErrMsg = "";
        //	private ArrayList<String> buildSqlList = new ArrayList<String>();

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

        public string getSql(){
		    if(hasErr){
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
