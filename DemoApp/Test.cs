using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using System.Diagnostics;
using DemoApp.TblModel;
using ComLib.db.BaseSys;
using ComLib.db.mysql;

namespace DemoApp
{
    public static class Test
    {

        private static void Log(string s)
        {
            Debug.WriteLine(s);
        }

        private static bool doSqlParams()
        {
            //string sql = "INSERT INTO tbl_1(`str1`,`int1`)  VALUES('eleven',100);";
            string sql = "INSERT INTO tbl_1(`str1`,`int1`)  VALUES(@P1,@P2);";
            string connstr = SqlDBMng.GetConnStr("test", "127.0.0.1", "root", "-101868");
            MySql.Data.MySqlClient.MySqlParameter[] sqlParams = new MySql.Data.MySqlClient.MySqlParameter[2];
            sqlParams[0] = new MySql.Data.MySqlClient.MySqlParameter("@P1", "TestEleven");
            sqlParams[1] = new MySql.Data.MySqlClient.MySqlParameter("@P2", 233);
            MySqlHelper2.ExecuteNonQuery(connstr, System.Data.CommandType.Text, sql, sqlParams);
            return true;
        }

        private static bool doParamA(DataCtrlInfo dcf,ref string errMsg)
        {
            string value = SysParams.GetInstance().GetValue(dcf, "Param_A");
            Log("====== value[" + value + "]");
            if (!SysParams.GetInstance().SetValue(dcf, "Param_A", "1", ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool do2(ref string errMsg)
        {
            int count = 0;
            DataCtrlInfo dcf = new DataCtrlInfo();
            if (!doParamA(dcf, ref errMsg))
            {
                return false;
            }

            Tbltbl_1 item = new Tbltbl_1();
            item.str1 = "jsc11";
            item.int1 = 2;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(
                Tbltbl_1.getStr1Column(),
                Tbltbl_1.getInt1Column()
                );
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(Tbltbl_1.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, 1);
            if (!Tbltbl_1Ctrl.Update(dcf, item, suc, sw, ref count, ref errMsg))
            {
                return false;
            }

            Log("====== updCount["+count+"]");

            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "Eleven", ref nextId, ref errMsg))
            {
                return false;
            }

            Log("====== Next is is [" + nextId + "]");

            return true;
        }

        public static bool do1(ref string errMsg)
        {
            //string formatStr = "HHmmssffffff";
            //Log(DateTime.Now.ToString(formatStr));
            //Log(DateTime.Now.ToString(formatStr));
            //Log(DateTime.Now.ToString(formatStr));
            //Log(DateTime.Now.ToString(formatStr));
            //Log(DateTime.Now.ToString(formatStr));
            //return true;
            //return doSqlParams();
            //return do2(ref errMsg);

            int count = 0;
            DataCtrlInfo dcf = new DataCtrlInfo();

            //dcf.BeginTrans();
            //{
            //    Tbltbl_1 item = new Tbltbl_1();
            //    item.int1 = 3;
            //    item.str1 = "eleven";
            //    if (!Tbltbl_1Ctrl.Insert(dcf, item, ref count, ref errMsg))
            //    {
            //        Debug.WriteLine("===========" + errMsg);
            //        return false;
            //    }
            //}

            {
                SqlUpdateMng sum = new SqlUpdateMng();
                sum.setQueryTableName(Tbltbl_1.getFormatTableName());
                sum.AddByParams(Tbltbl_1.getStr1Column(), "aaa");
                sum.AddByParams(Tbltbl_1.getInt1Column(), 222);
                string sql = sum.getInsertSql();
               
                if (sql == null)
                {
                    errMsg = sum.ErrMsg;
                    return false;
                }
                int _count = 0;
                return BaseDataCtrl.doUpdateCtrl(dcf, sql, ref _count, ref errMsg, sum.getParamsArray());
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
