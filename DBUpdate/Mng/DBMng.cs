using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using System.Data;

namespace DBUpdate.Mng
{
    public class DBMng
    {
        public static bool DetectDBConn(string service,string uid,string password,string port,ref string errMsg)
        {
            if (!ComLib.db.SqlDBMng.DetectDBServer( service, uid, password, port, ref errMsg))
            {
                return false;
            }

            return true;
        }

        private string _connStr = "";
        public DBMng(string connstr)
        {
            _connStr = connstr;
        }
        public bool GetDBNameList(ref List<string> dbList, ref string errMsg)
        {
            try
            {
                string sql = "SHOW DATABASES;";
                DataSet ds =
                SqlDBMng.getInstance(_connStr).query(sql, null);

                dbList = new List<string>();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dbList.Add(row["Database"].ToString());
                }
                return true;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

    }
}
