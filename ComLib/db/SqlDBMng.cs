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
            initDBMng(type);
            setConnectionString(connstr);
        }
        public static void initDBMng(DBTypeEnum type)
        {
            DBType = type;
        }
        public static void setConnectionString(string connstr)
        {
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

        #region Common DB Operate Function

        public static bool GetDBNow(string connStr,ref DateTime value, ref string errMsg)
        {
            try
            {
                string sql = "";
                switch (DBType)
                {
                    case DBTypeEnum.MySQl:
                        sql = "SELECT NOW()";
                        value = ComFn.GetDBFieldDateTime(
                            getInstance(connStr == null ? _constr : connStr).query(sql).Tables[0].Rows[0][0]);
                        //mysql
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;

        }

        public static bool DetectDBServer(string dbname, string server, string uid, string pwd,ref string errMsg)
        {
            try
            {
                DateTime d = DateTime.MinValue;
                if (!GetDBNow(GetConnStr(dbname, server, uid, pwd), ref d, ref errMsg))
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;
        }

        #endregion


    }
}
