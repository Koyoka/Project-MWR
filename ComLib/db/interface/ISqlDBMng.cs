using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ComLib.db.mysql
{
    public interface ISqlDBMng
    {
        DateTime getDBDateTime();
        DataSet query(string sql, params object[][] ps);
        List<T> query<T>(String sql, T clazz, params object[][] ps) where T : class,new();
        List<T> query<T>(String sql, T clazz) where T : class,new();
	    int		update(String sql);
	    int		update(String sql,params object[][] ps);
        int[]   doSql(List<string> sqlList, params object[][] ps);
    }
}
