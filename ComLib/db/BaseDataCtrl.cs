using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.mysql;
using System.Linq;
using System.Linq.Expressions;
using ComLib.Log;

namespace ComLib.db
{
    public class BaseDataCtrl
    {
        public static string ClassName = "ComLib.db.BaseDataCtrl";

        //protected static bool doUpdateCtrl()
        //{
            
        //    return true;
        //}
        public static void foo(IEnumerable<DataColumnInfo> datas)
        { 
            
        }

        
        protected static void SetUpdateColumnValue<T>(SqlUpdateColumn suc, T t) where T : BaseDataModule,new()
        {
            if (suc.Columns == null)
            {
                return;
            }
            
            foreach (DataColumnInfo dataInfo in suc.Columns)
            {
                object o = typeof(T).GetProperty(dataInfo.ColumnName).GetValue(t, null);
                suc.Add(dataInfo, o);
            }
            //typeof(T).GetProperty(dataInfo.ColumnName).ge

            ////foreach (System.Reflection.PropertyInfo pi in propertys)
            ////{
            ////    if (dataInfo.ColumnName.Contains(pi.Name))
            ////    {
            ////        object o =  pi.GetValue(t, null);
            ////        suc.Add(dataInfo, o);
            ////    }
            ////}
            //suc.Add(dataInfo, o);
        }

        public static bool doUpdateCtrl(DataCtrlInfo dcf, string sql, ref int count, ref string errMsg,params object[][] ps)
        {

            if (sql == null)
            {
                return true;
            }
            else
            {
                dcf.makeSql(sql);
                if (!dcf.IsTrans)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(dcf.GetDBSession()))
                        {
                            count = SqlDBMng.getInstance().update(sql,ps);
                        }
                        else
                        {
                            ISqlDBMng tempDBMng = SqlDBMng.getInstance(dcf.GetDBSession());
                            if (tempDBMng == null)
                            {
                                throw new Exception("dbsession is null.");
                            }
                            count = tempDBMng.update(sql);
                        }
                    }
                    catch (Exception ex)
                    {
                        errMsg = ex.Message;
                        LogMng.GetLog().PrintError(ClassName, "doUpdateCtrl", ex);
                        return false;
                    }
                }
                return true;
            }

        }

        public static bool doUpdateCtrl(DataCtrlInfo dcf, string sql,ref int count,ref string errMsg)
        {
           
            if (sql == null)
            {
                return true;
            }
            else
            {
                dcf.makeSql(sql);
                if (!dcf.IsTrans)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(dcf.GetDBSession()))
                        {
                            count = SqlDBMng.getInstance().update(sql);
                        }
                        else
                        {
                            ISqlDBMng tempDBMng = SqlDBMng.getInstance(dcf.GetDBSession());
                            if (tempDBMng == null)
                            {
                                throw new Exception("dbsession is null.");
                            }
                            count = tempDBMng.update(sql);
                        }
                    }
                    catch (Exception ex)
                    {
                        errMsg = ex.Message;
                        LogMng.GetLog().PrintError(ClassName, "doUpdateCtrl", ex);
                        return false;
                    }
                }
                return true;
            }
           
            //int count = 0;
            //if (sql == null)
            //{
            //    dcf.set(false, buildSqlErrMsg);
            //    return 0;
            //}
            //else
            //{
            //    dcf.makeSql(sql);
            //    if (!dcf.IsTrans)
            //    {
            //        try
            //        {
            //            count = SqlDBMng.getInstance().update(sql);
            //            dcf.set(true, "");
            //        }
            //        catch (Exception e)
            //        {
            //            dcf.set(false, e.getMessage());
            //        }
            //    }
            //}
            //return count;
        }
    }
}
