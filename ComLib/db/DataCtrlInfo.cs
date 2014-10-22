using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class DataCtrlInfo
    {

        public bool IsTrans = false;
        public bool Success = false;
        public int RowCount = 0;
        public int PageCount = 0;

        public List<string> sqlList = new List<string>();
        public String makeSql(String sql)
        {
            if (!IsTrans)
            {
                //			sqlList.add("");//add use database
            }
            sqlList.Add(sql);
            return sql;
        }
        public string getSql()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in sqlList)
            {
                sb.AppendLine(s);
                //sb.Append("\r\n");
            }
            return sb.ToString();
        }

       
        public String ErrMsg = "";

        public void set(bool isSuccess, string errMsg)
        { 
            
        }
    }
}
