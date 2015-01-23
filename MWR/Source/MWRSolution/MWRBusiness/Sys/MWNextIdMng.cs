using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db.BaseSys;
using ComLib.db;
using ComLib.Log;
using ComLib;

namespace YRKJ.MWR.Business.Sys
{
    public class MWNextIdMng
    {
        public const string ClassName = "YRKJ.MWR.Business.Sys.MWNextIdMng";


        #region base data
        public static int GetCarDispatchNextId()
        {
            DataCtrlInfo dcf = new DataCtrlInfo();;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "CarDispatch", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetCarDispatchNextId", new Exception(errMsg));
                return 0;
            }

            return nextId;
        }
        #endregion
        
        #region txn
        public static int GetTxnDetailNextId(int count)
        {
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "TxnDetail", count, ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetTxnDetailNextId", new Exception(errMsg));
                return 0;
            }

            return nextId;
        }

        public static int GetTxnRecoverHeaderNextId()
        {
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "TxnRecoverHeader", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetTxnRecoverHeaderNextId", new Exception(errMsg));
                return 0;
            }

            return nextId;
        }
        
        public static string GetTxnNextNum(string TxnNumMask)
        {
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "TxnNum", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetTxnNextNum", new Exception(errMsg));
                return null;
            }

            if (nextId == 0)
            {
                LogMng.GetLog().PrintError(ClassName, "GetTxnNextNum", new Exception("获取txnnum出错"));
                return null;
            }
            string defineNextNum = ComFn.GetMaskNumString(nextId,TxnNumMask);
            return defineNextNum;

            string prefix = TxnNumMask.Replace("#", "");
            string num = TxnNumMask.TrimStart(prefix.ToCharArray());
            int len = num.Length;
            int nextIdLen = nextId.ToString().Length;
            if (nextIdLen > len)
            {
                LogMng.GetLog().PrintError(ClassName, "GetTxnNextNum", new Exception("编号超出界限"));
                return null;
            }
            defineNextNum = prefix + defineNextNum.PadLeft(len - nextIdLen, '0') + nextId;

            return defineNextNum;
        }

       
        #endregion
    }
}
