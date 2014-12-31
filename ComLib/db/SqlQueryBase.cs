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
        public object[][] getParamsArray()
        {
            if (buildParamsList.Count == 0)
            {
                return null;
            }
            return buildParamsList.ToArray();
        }

        protected int getParamsIndex()
        {
            if (buildParamsList != null && buildParamsList.Count != 0)
            {
                return (int)buildParamsList[buildParamsList.Count - 1][2] + 1;
            }
            else
            {
                return 0;
            }
        }

        protected class p
        {
            private string _name = "";
            public string Name
            {
                get { return _name; }
            }
            public p(string s)
            {
                _name = s;
            }
        }
        
    }
}
