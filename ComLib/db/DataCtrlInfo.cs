using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class DataCtrlInfo
    {

        public bool IsTrans = false;
        public bool Success = false;
        public long RowCount = 0;
        public long PageCount = 0;

        public List<string> sqlList = new List<string>();
        public string makeSql(String sql)
        {
            //if (!IsTrans)
            //{
            //    //			sqlList.add("");//add use database
            //}
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

        public void BeginTrans()
        {
            IsTrans = true;
        }
        public bool Commit(ref int[] counts,ref string errMsg)
        {
            return SqlDBMng.doSql(this, ref counts, ref errMsg);
        }

        public void set(bool isSuccess, string errMsg)
        { 
            
        }
    }
}
