using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.mysql;

namespace ComLib.db
{
    public class SqlDBMng
    {
        private static ISqlDBMng dbmng = null;

        public static void initDBMng(ISqlDBMng mng)
        {
            dbmng = mng;
        }
        public static ISqlDBMng getInstance()
        {
            if (dbmng == null)
            {
                //mysql
                dbmng = new SqlMySqlDBMng();
                //sqlserver
                //dbmng = new SqlSqlServerDBMng();
            }
            return dbmng;
        }

        public static int[] doSql(DataCtrlInfo dcf,ref string errMsg)
        {
            int[] count = null;
            if (dcf.IsTrans)
            {
                try
                {
                    count = getInstance().doSql(dcf.sqlList);
                    dcf.set(true, "");
                }
                catch (Exception e)
                {
                    errMsg = e.Message;
                }
                finally
                {
                    dcf.IsTrans = false;
                    if (count == null)
                    {
                        count = new int[dcf.sqlList.Count];
                    }
                }
            }
            return count;
        }
    }
}
