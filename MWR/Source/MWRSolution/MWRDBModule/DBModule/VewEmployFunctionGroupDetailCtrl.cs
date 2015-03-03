using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR
{
    public class VewEmployFunctionGroupDetailCtrl : BaseDataCtrl
    {
        public static bool QueryPage(DataCtrlInfo dcf, SqlWhere sw, int page, int pageSize, ref List<VewEmployFunctionGroupDetail> itemList, ref string errMsg)
        {
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddWhere(sw);
            return QueryPage(dcf, sqm, page, pageSize, ref itemList, ref errMsg);
        }
 
        public static bool QueryPage(DataCtrlInfo dcf, SqlQueryMng sqm, int page, int pageSize,ref List<VewEmployFunctionGroupDetail> itemList,ref string errMsg)
        {
            try
            {
                string sql = sqm.getVewPageSql(VewEmployFunctionGroupDetail.getSql(),page, pageSize);
                SqlCommonFn.DebugLog(sql);
                itemList = SqlDBMng.getInstance().query(sql, new VewEmployFunctionGroupDetail(), sqm.getParamsArray());
                if (itemList.Count != 0)
                {
                    dcf.RowCount = itemList[0].TEM_COLUMN_COUNT;
                    dcf.PageCount = ComLib.ComFn.getPageCount(pageSize, dcf.RowCount);
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                return false;
            }
            return true ;
        }

         public static bool QueryMore(DataCtrlInfo dcf, SqlWhere sw,
             ref List<VewEmployFunctionGroupDetail> itemList,ref string errMsg)
         {
             SqlQueryMng sqm = new SqlQueryMng();
             sqm.Condition.Where.AddWhere(sw);
             return QueryMore(dcf, sqm,ref itemList,ref errMsg);
         }

         public static bool QueryMore(DataCtrlInfo dcf,SqlQueryMng sqm,
             ref List<VewEmployFunctionGroupDetail> itemList,ref string errMsg){
                 if (itemList == null)
                 {
                     itemList = new List<VewEmployFunctionGroupDetail>();
                 }
                 itemList = new List<VewEmployFunctionGroupDetail>();
                 string sql = sqm.getVewSql(VewEmployFunctionGroupDetail.getSql());
                //System.out.println(sql);
                 try {
                     itemList = SqlDBMng.getInstance().query(sql, new VewEmployFunctionGroupDetail(),sqm.getParamsArray());
             
                 } catch (Exception e) {
                
                     errMsg = e.Message;
                     return false;
                 }

                 return true;
         }

         public static bool QueryOne(DataCtrlInfo dcf,SqlQueryMng sqm,ref VewEmployFunctionGroupDetail item,ref string errMsg){
              List<VewEmployFunctionGroupDetail> itemList = new List<VewEmployFunctionGroupDetail>();
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

         public static bool QueryOne(DataCtrlInfo dcf,SqlWhere sw,ref VewEmployFunctionGroupDetail item,ref string errMsg){
             List<VewEmployFunctionGroupDetail> itemList = new List<VewEmployFunctionGroupDetail>();
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
