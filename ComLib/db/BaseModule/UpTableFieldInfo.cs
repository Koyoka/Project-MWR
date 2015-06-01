using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComLib.db.BaseModule
{
    public class TableFieldInfo
    {
        public string FieldName { get; set; }
        public string ColumnType { get; set; }//varchar(45) or decimal(10,2)
        public bool NullAble { get; set; }
        public bool IsPRIKey { get; set; }
        public string DetaultValue { get; set; }
        

        //public string GetTableOptions()
        //{
        //    return "";
        //}

       
        public string DataType { get; set; }
    }
}
