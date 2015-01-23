using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{
    public class VewTxnHeaderWithCarDispatchCtrl : BaseDataCtrl
    {
         public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,
             ref List<VewTxnHeaderWithCarDispatch> itemList,ref string errMsg)
         {
             SqlQueryMng sqm = new SqlQueryMng();
             sqm.Condition.Where.AddWhere(sw);
             return QueryMore(dcf, sqm,ref itemList,ref errMsg);
         }

         public static bool QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm,
             ref List<VewTxnHeaderWithCarDispatch> itemList,ref string errMsg){
                 if (itemList == null)
                 {
                     itemList = new List<VewTxnHeaderWithCarDispatch>();
                 }
                 itemList = new List<VewTxnHeaderWithCarDispatch>();
                 string sql = sqm.getVewSql(VewTxnHeaderWithCarDispatch.getSql());
                //System.out.println(sql);
                 try {
                     itemList = SqlDBMng.getInstance().query(sql, new VewTxnHeaderWithCarDispatch(),sqm.getParamsArray());
             
                 } catch (Exception e) {
                
                     errMsg = e.Message;
                     return false;
                 }

                 return true;
         }

         public static bool QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm,ref VewTxnHeaderWithCarDispatch item,ref string errMsg){
              List<VewTxnHeaderWithCarDispatch> itemList = new List<VewTxnHeaderWithCarDispatch>();
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

         public static bool QueryOne(DataCtrlInfo dcf,SqlWhere sw,ref VewTxnHeaderWithCarDispatch item,ref string errMsg){
             List<VewTxnHeaderWithCarDispatch> itemList = new List<VewTxnHeaderWithCarDispatch>();
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
