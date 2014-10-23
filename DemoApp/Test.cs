using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using ComLib.module;
using System.Diagnostics;
using DemoApp.TblModel;

namespace DemoApp
{
    public static class Test
    {
        public static bool do1(ref string errMsg)
        {
            int count = 0;
            DataCtrlInfo dcf = new DataCtrlInfo();

            {
                Tbltbl_1 item = new Tbltbl_1();

                item.str1 = "eleven";
                if (!Tbltbl_1Ctrl.Insert(dcf, item, ref count, ref errMsg))
                {
                    Debug.WriteLine("===========" + errMsg);
                    return false;
                }
            }

            {
                Tbltbl_2 item = new Tbltbl_2();
                item.str1 = "koyoka";
                if (!Tbltbl_2Ctrl.Insert(dcf, item, ref count, ref errMsg))
                {
                    return false;
                }
            }

            {
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(Tbltbl_1.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, 1);
                Tbltbl_1 item = new Tbltbl_1();
                if (!Tbltbl_1Ctrl.QueryOne(dcf, sw, ref item, ref errMsg))
                {
                    Debug.WriteLine("===========" + errMsg);
                    return false;
                }
                else
                {
                    if (item != null)
                    {
                        Debug.WriteLine("-----------" + item.id + " " + item.str1);
                    }
                }
            }

            {
                SqlWhere sw = new SqlWhere();
                List<Tbltbl_1> itemList = new List<Tbltbl_1>();

                if (!Tbltbl_1Ctrl.QueryMore(dcf, sw, ref itemList, ref errMsg))
                {
                    Debug.WriteLine("===========" + errMsg);
                    return false;
                }
                else
                {
                    foreach (Tbltbl_1 item in itemList)
                    {
                        Debug.WriteLine("-----------" + item.id + " " + item.str1);
                    }
                }
            }

            {
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(Tbltbl_1.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.LessEquals, 5);
                List<Vewtbl1withtbl2> itemList = new List<Vewtbl1withtbl2>();

                if (!Vewtbl1withtbl2Ctrl.QueryMore(dcf, sw, ref itemList, ref errMsg))
                {
                    return false;
                }
                else
                {
                    foreach (Vewtbl1withtbl2 item in itemList)
                        Debug.WriteLine("Vewtbl1withtbl2 -----------" + item.id + " " + item.t1str1 + " " + item.t2str2);
                }
            }

            Debug.WriteLine("---------");
            return true;

        }

    }
}
