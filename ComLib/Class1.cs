//using System;
//using System.Collections.Generic;
//using System.Text;
//using ComLib.db;
//using ComLib.module;

//namespace ComLib
//{
//    public class Class1
//    {

//        DateTime d = new DateTime();

//        private void cust()
//        {
//            int count = 0;
//            string errMsg = "";
//            DataCtrlInfo dcf = new DataCtrlInfo();

//            Tblarcustomer item = new Tblarcustomer();
//            item.userName = "ccccccccc";
//            item.password = "121212";
//            item.createDate = DateTime.Now;
//            if (!TblarcustomerCtrl.Insert(dcf, item, ref count, ref errMsg))
//            { }

//            List<Tblarcustomer> itemList = null;
//            SqlWhere sw = new SqlWhere();

//            SqlQueryMng sqm = new SqlQueryMng();
//            sqm.Condition.OrderBy.Add(Tblarcustomer.getCreateDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
//            if (!TblarcustomerCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
//            { 
                
//            }
//        }

//        private void targetItem()
//        {
//            string errMsg = "";
//            List<Tblartargetitem> itemList = null;

//            DataCtrlInfo dcf = new DataCtrlInfo();
//            SqlWhere sw = new SqlWhere();
//            if (!TblartargetitemCtrl.QueryMore(dcf, sw, ref itemList, ref errMsg))
//            { 
            
//            }
//        }

//        public void t()
//        {
//            targetItem();
//            //cust();
//            //return;

//            int count = 0;
//            string errMsg = "";
            
//            DataCtrlInfo dcf = new DataCtrlInfo();
//            //dcf.IsTrans = true;

//            //for (int i = 0; i < 1; i++)
//            //{
//            Tblbean item = new Tblbean();
//            item.colBit = true;
//            item.colNotNull = DateTime.Now.ToString();
//            item.colDT = DateTime.Now;
//            if (!TblbeanCtrl.Insert(dcf, item, ref count, ref errMsg))
//            { }
//            //}
//            //SqlDBMng.doSql(dcf, ref errMsg);

//            SqlQueryMng sqm = new SqlQueryMng();
//            sqm.Condition.Where.AddCompareValue(Tblbean.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, "1");
//            sqm.Condition.Where.AddCompareValue(Tblbean.getIdColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, "2");
//            sqm.Condition.OrderBy.Add(Tblbean.getIdColumn(), SqlCommonFn.SqlOrderByType.DESC);

//            List<Tblbean> itemList = null;
//            if (!TblbeanCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
//            {
//                SqlCommonFn.DebugLog("err:  " + errMsg);
//            }
//            else
//            {
//                SqlCommonFn.DebugLog("asdfadf");
//            }

//            if (!TblbeanCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
//            {
//                SqlCommonFn.DebugLog("err:  " + errMsg);
//            }
//            else
//            {
//                SqlCommonFn.DebugLog("asdfadf");
//            }
//        }
//    }
//}
