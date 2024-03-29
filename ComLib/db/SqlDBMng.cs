﻿using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.mysql;
using ComLib.Log;

namespace ComLib.db
{
    public class SqlDBMng
    {
        public static string ClassName = "ComLib.db.SqlDBMng";
        private static ISqlDBMng dbmng = null;
        public static bool IsDebug = false;

        public enum DBTypeEnum
        { 
            MySQl,
            SqlServer
        }

        public static DBTypeEnum DBType = DBTypeEnum.MySQl;
        private static string _constr = "";

        public static string GetConnStr(string dbname,string dbsource,string uid,string password,string port)
        {
            return string.Format("Database='{0}';Port={4};Data Source='{1}';User Id='{2}';Password='{3}';charset='utf8'"
                ,dbname,dbsource,uid,password,port);

        }
        public static string GetConnStr(string dbsource, string uid, string password, string port)
        {
            return string.Format("Port={3};Data Source='{0}';User Id='{1}';Password='{2}';charset='utf8'"
                ,  dbsource, uid, password, port);

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
                    LogMng.GetLog().PrintError(ClassName, "doSql", e);
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
        public static DateTime GetDBNow()
        {
            return getInstance().getDBDateTime();
        }
        private static bool GetDBNow(string connStr,ref DateTime value, ref string errMsg)
        {
            try
            {
                //string sql = "";
                //switch (DBType)
                //{
                //    case DBTypeEnum.MySQl:
                //        sql = "SELECT NOW()";
                //        value = ComFn.GetDBFieldDateTime(
                //            getInstance(connStr == null ? _constr : connStr).query(sql).Tables[0].Rows[0][0]);
                //        //mysql
                //        break;
                //}
                value = getInstance(connStr).getDBDateTime();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;

        }
        public static bool DetectDBServer( string server, string uid, string pwd, string port, ref string errMsg)
        {
            try
            {
                DateTime d = DateTime.MinValue;
                if (!GetDBNow(GetConnStr(server, uid, pwd, port), ref d, ref errMsg))
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
        public static bool DetectDBServer(string dbname, string server, string uid, string pwd,string port,ref string errMsg)
        {
            try
            {
                DateTime d = DateTime.MinValue;
                if (!GetDBNow(GetConnStr(dbname, server, uid, pwd, port), ref d, ref errMsg))
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

        public static void DebugPrint(string s)
        {
            if (IsDebug)
                System.Diagnostics.Debug.WriteLine(s);
        }
        #endregion


    }
}
