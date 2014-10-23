using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace DemoApp.TblModel
{
    public class VewCustomerWithAccountCtrl : BaseDataCtrl
    {
         public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,
             ref List<VewCustomerWithAccount> itemList,ref string errMsg)
         {
             SqlQueryMng sqm = new SqlQueryMng();
             sqm.Condition.Where.AddWhere(sw);
             return QueryMore(dcf, sqm,ref itemList,ref errMsg);
         }

         public static bool QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm,
             ref List<VewCustomerWithAccount> itemList,ref string errMsg){
                 if (itemList == null)
                 {
                     itemList = new List<VewCustomerWithAccount>();
                 }
                 itemList = new List<VewCustomerWithAccount>();
                 string sql = sqm.getVewSql(VewCustomerWithAccount.getSql());
                //System.out.println(sql);
                 try {
                     itemList = SqlDBMng.getInstance().query(sql, new VewCustomerWithAccount(),sqm.getParamsArray());
             
                 } catch (Exception e) {
                
                     errMsg = e.Message;
                     return false;
                 }

                 return true;
         }

         public static bool QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm,ref VewCustomerWithAccount item,ref string errMsg){
              List<VewCustomerWithAccount> itemList = new List<VewCustomerWithAccount>();
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

         public static bool QueryOne(DataCtrlInfo dcf,SqlWhere sw,ref VewCustomerWithAccount item,ref string errMsg){
             List<VewCustomerWithAccount> itemList = new List<VewCustomerWithAccount>();
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
