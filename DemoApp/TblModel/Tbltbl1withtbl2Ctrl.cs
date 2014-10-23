using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace DemoApp.TblModel
{
    public class Tbltbl1withtbl2Ctrl : BaseDataCtrl
    {
         public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,
             ref List<Tbltbl1withtbl2> itemList,ref string errMsg)
         {
             SqlQueryMng sqm = new SqlQueryMng();
             sqm.Condition.Where.AddWhere(sw);
             return QueryMore(dcf, sqm,ref itemList,ref errMsg);
         }

         public static bool QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm,
             ref List<Tbltbl1withtbl2> itemList,ref string errMsg){
                 if (itemList == null)
                 {
                     itemList = new List<Tbltbl1withtbl2>();
                 }
                 itemList = new List<Tbltbl1withtbl2>();
                 string sql = sqm.getVewSql(Tbltbl1withtbl2.getSql());
                //System.out.println(sql);
                 try {
                     itemList = SqlDBMng.getInstance().query(sql, new Tbltbl1withtbl2(),sqm.getParamsArray());
             
                 } catch (Exception e) {
                
                     errMsg = e.Message;
                     return false;
                 }

                 return true;
         }

         public static bool QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm,ref Tbltbl1withtbl2 item,ref string errMsg){
              List<Tbltbl1withtbl2> itemList = new List<Tbltbl1withtbl2>();
             if (!QueryMore(dcf, sqm, ref itemList, ref errMsg))
             {
                 return false;
             }

             if (itemList.Count > 0)
             {
                 item = itemList[0];
             }
             else
             {
                 item = null;
             }
             return true;
         }

         public static bool QueryOne(DataCtrlInfo dcf,SqlWhere sw,ref Tbltbl1withtbl2 item,ref string errMsg){
             List<Tbltbl1withtbl2> itemList = new List<Tbltbl1withtbl2>();
             if (!QueryMore(dcf, sw, ref itemList, ref errMsg))
             {
                 return false;
             }

             if (itemList.Count > 0)
             {
                 item = itemList[0];
             }
             else
             {
                 item = null;
             }
             return true;
         }
     }
}
