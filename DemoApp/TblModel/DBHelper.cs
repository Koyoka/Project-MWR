using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db.mysql;

namespace DemoApp.TblModel
{
    public class DBHelper
    {
        public static ISqlDBMng GetDB()
        {
            return new SqlMySqlDBMng("test","127.0.0.1","root","-101868");
        }
    }

    
}
