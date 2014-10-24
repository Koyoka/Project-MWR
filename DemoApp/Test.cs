using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
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

            //dcf.BeginTrans();
            {
                Tbltbl_1 item = new Tbltbl_1();
                item.int1 = 3;
                item.str1 = "eleven";
                if (!Tbltbl_1Ctrl.Insert(dcf, item, ref count, ref errMsg))
                {
                    Debug.WriteLine("===========" + errMsg);
                    return false;
                }
            }

            return true;

            //{
            //    Tbltbl_2 item = new Tbltbl_2();
            //    item.str1 = "koyoka1";
            //    if (!Tbltbl_2Ctrl.Insert(dcf, item, ref count, ref errMsg))
            //    {
            //        return false;
            //    }
            //}

            //{

            //    //SqlQueryMng sqm = new SqlQueryMng();
            //    //sqm.Condition.OrderBy.Add(Tbltbl_1.getIdColumn());
            //    //sqm.QueryColumn.Add(


            //    SqlWhere sw = new SqlWhere();
            //    sw.AddCompareValue(Tbltbl_1.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, 1)
            //        .AddCompareValue(Tbltbl_1.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, 2)
            //        .AddCompareValue(Tbltbl_1.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, 3)
            //        .AddCompareValue(Tbltbl_1.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, 4)
            //        .SetLinkType(SqlCommonFn.SqlWhereLinkType.OR);

            //    SqlUpdateColumn suc = new SqlUpdateColumn();
            //    suc.Add(Tbltbl_1.getStr1Column(), "cccc");

            //    if (!Tbltbl_1Ctrl.Update(dcf, suc, sw, ref count, ref errMsg))
            //    {
            //        return false;
            //    }
            //}

            //int[] counts = null;
            //if (!dcf.Commit(ref counts, ref errMsg))
            //{
            //    Debug.WriteLine("===========" + errMsg);
            //}
            //else
            //{
            //    foreach (int c in counts)
            //    {
            //        Debug.WriteLine("---------- count[" + c + "]");
            //    }
            //}


            {
                //SqlQueryMng sqm = new SqlQueryMng();
                SqlWhere sw = new SqlWhere();

                List<Tbltbl_1> itemList = new List<Tbltbl_1>();

                if (!Tbltbl_1Ctrl.QueryPage(dcf, sw, 1, 2, ref itemList, ref errMsg))
                {
                    return false;
                }
                else
                {
                    Debug.WriteLine("----------- pageCount[" + dcf.PageCount + "] rowCount[" + dcf.RowCount + "]");

                    foreach (Tbltbl_1 item in itemList)
                    {
                        Debug.WriteLine("-----------" + item.id + " " + item.str1);
                    }
                }
            }
            return true;

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
