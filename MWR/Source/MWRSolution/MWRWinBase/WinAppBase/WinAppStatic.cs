using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRKJ.MWR.WinBase.WinAppBase
{
    public class WinAppBase
    {
           
        public const string DBKey = "pMwrdbWORD";
        public const string DefaultEPassword = "/94dTLB68wkUqTRJasVIdg==";
        private static string _dbName = "MWRDATA";
        public static string DBName {
            get { return _dbName; }
            set { _dbName = value; }
        }
        //public const string BarCodeMask = "HX#####";

        //public static string CrateBarCodeMask = "HX###";
    }
}
