using System;
using System.Collections.Generic;
using System.Text;

namespace ComLib.db
{
    public class BaseDataCtrl
    {
        

        //protected static bool doUpdateCtrl()
        //{
            
        //    return true;
        //}

        protected static bool doUpdateCtrl(DataCtrlInfo dcf, string sql,ref int count,ref string errMsg)
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
                        count = SqlDBMng.getInstance().update(sql);
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
