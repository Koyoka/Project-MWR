using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.mysql;

namespace ComLib.db
{
    public class BaseDataCtrl
    {
        

        //protected static bool doUpdateCtrl()
        //{
            
        //    return true;
        //}

        protected static void SetUpdateColumnValue<T>(SqlUpdateColumn suc, T t) where T : BaseDataModule,new()
        {
            if (suc.Columns == null)
            {
                return;
            }
            System.Reflection.PropertyInfo[] propertys = t.GetType().GetProperties();
            foreach (DataColumnInfo dataInfo in suc.Columns)
            {
                foreach (System.Reflection.PropertyInfo pi in propertys)
                {
                    if (dataInfo.ColumnName.Contains(pi.Name))
                    {
                        object o =  pi.GetValue(t, null);
                        suc.Add(dataInfo, o);
                    }
                }
            }
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
                    catch (Exception e)
                    {
                        errMsg = e.Message;
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
                    catch (Exception e)
                    {
                        errMsg = e.Message;
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
