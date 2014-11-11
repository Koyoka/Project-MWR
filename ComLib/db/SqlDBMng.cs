using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.mysql;

namespace ComLib.db
{
    public class SqlDBMng
    {
        private static ISqlDBMng dbmng = null;

        public enum DBTypeEnum
        { 
            MySQl,
            SqlServer
        }

        public static DBTypeEnum DBType = DBTypeEnum.MySQl;
        private static string _constr = "";

        public static string GetConnStr(string dbname,string dbsource,string uid,string password)
        {
            return string.Format("Database='{0}';Data Source='{1}';User Id='{2}';Password='{3}';charset='utf8'"
                ,dbname,dbsource,uid,password);

        }
        public static void initDBMng(string connstr,DBTypeEnum type)
        {
            DBType = type;
            _constr = connstr;
        }

        //public static void initDBMng(ISqlDBMng mng)
        //{
        //    dbmng = mng;
        //}
        public static ISqlDBMng getInstance()
        {
            if (dbmng == null)
            {
                switch (DBType)
                { 
                    case DBTypeEnum.MySQl:
                        //mysql
                        dbmng = new SqlMySqlDBMng(_constr);
                        break;
                    case DBTypeEnum.SqlServer:
                        //sqlserver
                        //dbmng = new SqlSqlServerDBMng();
                        break;
                }
               
               
            }
            return dbmng;
        }
        public static ISqlDBMng getInstance(string constr)
        {
            switch (DBType)
            {
                case DBTypeEnum.MySQl:
                    //mysql
                    return new SqlMySqlDBMng(constr);
                    break;
                case DBTypeEnum.SqlServer:
                    //sqlserver
                    //dbmng = new SqlSqlServerDBMng();
                    break;
            }
            return null;
        }

        public static bool doSql(DataCtrlInfo dcf,ref int[] counts,ref string errMsg)
        {

            if (dcf.IsTrans)
            {
                try
                {
                    counts = getInstance().doSql(dcf.sqlList);
                    dcf.set(true, "");
                }
                catch (Exception e)
                {
                    errMsg = e.Message;
                    return false;
                }
                finally
                {
                    dcf.IsTrans = false;
                    if (counts == null)
                    {
                        counts = new int[dcf.sqlList.Count];
                    }
                }
            }
            else
            {
                if (counts == null)
                {
                    counts = new int[dcf.sqlList.Count];
                }
            }
            return true;
        }
    }
}
