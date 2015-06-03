using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.db.BaseModule
{
    public class UpTableInfo
    {
        public string TableName { get; set; }
        public List<UpTableFieldInfo> TableFieldInfoList { get; set; }
    }
}
