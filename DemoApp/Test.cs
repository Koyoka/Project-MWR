using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using ComLib.module;
using System.Diagnostics;

namespace DemoApp
{
    public static class Test
    {
        public static bool do1(ref string errMsg) 
        {
            int count = 0;
            DataCtrlInfo dcf = new DataCtrlInfo();
         
            Tbltbl_1 item = new Tbltbl_1();
            item.id = 1;
            item.str1 = "eleven";
            if (!Tbltbl_1Ctrl.Insert(dcf, item, ref count, ref errMsg))
            {
                Debug.WriteLine("===========" + errMsg);
                return false;
            }

            Debug.WriteLine("---------");
            return true;

        }

    }
}
