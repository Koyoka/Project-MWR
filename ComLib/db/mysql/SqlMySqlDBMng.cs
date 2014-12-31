using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Data;

namespace ComLib.db.mysql
{
    public class SqlMySqlDBMng : ISqlDBMng
    {

        private static string connstr = "Database='yrkjar';Data Source='127.0.0.1';User Id='root';Password='-101868';charset='utf8'";

        #region ISqlDBMng 成员

        public List<T> query<T>(string sql, T clazz, params object[][] ps) where T : class,new()
        {
            System.Diagnostics.Debug.WriteLine(sql);

            MySql.Data.MySqlClient.MySqlParameter[] sqlParams = null;
            if (ps != null && ps.Length != 0)
            { 
                sqlParams = new MySql.Data.MySqlClient.MySqlParameter[ps.Length];
                for (int i = 0; i < ps.Length;i++ )
                {
                    object[] item = ps[i];
                    if (item != null && item.Length == 2)
                    {
                        sqlParams[i] = new MySql.Data.MySqlClient.MySqlParameter("@" + item[0].ToString(), item[1]);
                    }
                    else
                    {
                        throw new Exception("Sql params error");
                    }
                }
            }

            System.Data.DataSet ds = MySqlHelper2.GetDataSet(connstr, System.Data.CommandType.Text, sql, sqlParams);

            List<T> ts = null;
            if (ds != null && ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                ConvertToModel(ds.Tables[0], ref ts);
            }
            else
            {
                ts = new List<T>();
            }

            return ts;
        }

        public List<T> query<T>(string sql, T clazz) where T : class,new()
        {
            System.Diagnostics.Debug.WriteLine(sql);
            System.Data.DataSet ds = MySqlHelper2.GetDataSet(connstr, System.Data.CommandType.Text, sql);
            List<T> ts = null;
            if (ds != null && ds.Tables.Count == 1 && ds.Tables[0].Rows.Count > 0)
            {
                ConvertToModel(ds.Tables[0], ref ts);
            }
            else 
            {
                ts = new List<T>();
            }
                
            return ts;
        }

        public int update(string sql) 
        {
            System.Diagnostics.Debug.WriteLine(sql);
            return MySqlHelper2.ExecuteNonQuery(connstr, System.Data.CommandType.Text, sql);
        }

        public int update(string sql, params object[][] ps) 
        {
            System.Diagnostics.Debug.WriteLine(sql);

            MySql.Data.MySqlClient.MySqlParameter[] sqlParams = null;
            if (ps != null && ps.Length != 0)
            {
                sqlParams = new MySql.Data.MySqlClient.MySqlParameter[ps.Length];
                for (int i = 0; i < ps.Length; i++)
                {
                    object[] item = ps[i];
                    if (item != null && item.Length == 3)
                    {
                        sqlParams[i] = new MySql.Data.MySqlClient.MySqlParameter("@" + item[0].ToString(), item[1]);
                    }
                    else
                    {
                        throw new Exception("Sql params error");
                    }
                }
            }

            return MySqlHelper2.ExecuteNonQuery(connstr, System.Data.CommandType.Text, sql, sqlParams);

            //throw new Exception("The method or operation is not implemented.");
        }

        public int[] doSql(List<string> sqlList, params object[][] ps) 
        {
            int[] count = new int[sqlList.Count];

            MySql.Data.MySqlClient.MySqlParameter[] sqlParams = null;
            using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connstr))
            {
                connection.Open();
                MySql.Data.MySqlClient.MySqlTransaction trans = connection.BeginTransaction();
                int i = 0;
                foreach(string sql in sqlList)
                {
                    System.Diagnostics.Debug.WriteLine(sql);

                    count[i] = MySqlHelper2.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, sqlParams);
                    i++;
                }
                trans.Commit();
            }

            return count;
            //throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        public bool ConvertToModel<T>(DataTable dt,ref List<T> ts) where T : class,new()
        {
            try
            {
                //定义集合
                ts = new List<T>();
                T t = new T();
                string tempName = "";
                //获取此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (DataRow row in dt.Rows)
                {
                    t = new T();
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;
                        //检查DataTable是否包含此列
                        if (dt.Columns.Contains(tempName))
                        {
                            //判断此属性是否有set
                            if (!pi.CanWrite)
                                continue;
                            object value = row[tempName];
                            if (value != DBNull.Value)
                            {
                                if (pi.PropertyType.FullName == "System.Boolean"
                                    && value.GetType().FullName == "System.UInt64"
                                    )
                                {
                                    pi.SetValue(t, value.ToString().Equals("1"), null);
                                }
                                else
                                {
                                    pi.SetValue(t, value, null);
                                }
                            }
                        }
                    }
                    ts.Add(t);
                }
                //return ts;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public SqlMySqlDBMng(string database, string datasource, string uid, string password)
        //{
        //    connstr = string.Format("Database='{0}';Data Source='{1}';User Id='{2}';Password='{3}';charset='utf8'", 
        //        database,datasource,uid,password);
        //}
        
        public SqlMySqlDBMng(string s)
        {
            connstr = s; 
        }
    }
}
