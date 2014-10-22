using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public abstract class SqlQueryBase
    {
        protected List<string> buildSqlList = new List<string>();
        protected List<object[]> buildParamsList = new List<object[]>();

        protected void putSpace(StringBuilder sb)
        {
            sb.Append(" ");
        }

        public List<object[]> getParams() {
		    return buildParamsList;
	    }
	    public object[][] getParamsArray(){
		    if(buildParamsList.Count == 0){
			    return null;
		    }
		    return buildParamsList.ToArray();
	    }

        
    }
}
