﻿using System;
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
        public const string NextIdErrMsg = "系统忙，请稍候重试。";

        #region permit
        public static int GetFunctionGroupNextId()
        {
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "FunctionGroup", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetFunctionGroupNextId", new Exception(errMsg));
                return 0;
            }

            return nextId;
        }

        public static int GetFunctionGroupDetailNextId()
        {
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "FunctionGroupDetail", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetFunctionGroupDetailNextId", new Exception(errMsg));
                return 0;
            }

            return nextId;
        }

        #endregion

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

        public static string getWSCode(string wsCodeMask)
        {
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "WSCode", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "getWSCode", new Exception(errMsg));
                return null;
            }

            if (nextId == 0)
            {
                LogMng.GetLog().PrintError(ClassName, "getWSCode", new Exception("获取WSCode出错"));
                return null;
            }
            string defineNextNum = ComFn.GetMaskNumString(nextId, wsCodeMask);
            return defineNextNum;
            //string prefix = wsCodeMask.Replace("#", "");
            //string num = wsCodeMask.TrimStart(prefix.ToCharArray());
            //int len = num.Length;
            //int nextIdLen = nextId.ToString().Length;
            //if (nextIdLen > len)
            //{
            //    LogMng.GetLog().PrintError(ClassName, "getWSCode", new Exception("编号超出界限"));
            //    return null;
            //}
            //defineNextNum = prefix + defineNextNum.PadLeft(len - nextIdLen, '0') + nextId;

            //return defineNextNum;
        }
        #endregion
        
        #region txn
        public static int GetTxnDetailNextId()
        {
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "TxnDetail", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetTxnDetailNextId", new Exception(errMsg));
                return 0;
            }

            return nextId;
        }
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

        public static int GetTxnPostHeaderNextId()
        {
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "TxnPostHeader", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetTxnPostHeaderNextId", new Exception(errMsg));
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
        public static int GetTxnDestroyHeaderNextId()
        {
            return GetNextId("TxnDestroyHeader");
        }

        public static int GetInventoryNextId()
        {
            return GetNextId("Inventory");
        }
        public static int GetInventoryNextId(int count)
        {
            return GetNextId(count,"Inventory");
        }

        public static int GetInventoryTrackNextId()
        {
            return GetNextId("InventoryTrack");
        }
        public static int GetInventoryTrackNextId(int count)
        {
            return GetNextId(count,"InventoryTrack");
        }
        
        public static int GetTxnLogNextId()
        {
            return GetNextId("TxnLog");
        }
        public static int GetTxnLogNextId(int count)
        {
            return GetNextId(count,"TxnLog");
        }

        public static int GetInvAuthorizeNextId()
        {
            return GetNextId("InvAuthorize");
        }

        public static int GetInvAuthorizeAttachNextId(int count)
        {
            return GetNextId(count, "InvAuthorizeAttach");
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

            //string prefix = TxnNumMask.Replace("#", "");
            //string num = TxnNumMask.TrimStart(prefix.ToCharArray());
            //int len = num.Length;
            //int nextIdLen = nextId.ToString().Length;
            //if (nextIdLen > len)
            //{
            //    LogMng.GetLog().PrintError(ClassName, "GetTxnNextNum", new Exception("编号超出界限"));
            //    return null;
            //}
            //defineNextNum = prefix + defineNextNum.PadLeft(len - nextIdLen, '0') + nextId;

            //return defineNextNum;
        }

        public static int GetDestroyMCDetailId()
        {
            return GetNextId("DestroyMCDetail");
        }
        public static int GetDestroyMCDetailId(int count)
        {
            return GetNextId(count, "DestroyMCDetail");
        }
        #endregion

        private static int GetNextId(string tableName)
        {
            string errMsg = "";
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, tableName, ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, tableName, new Exception(errMsg));
                return 0;
            }

            return nextId;
        }
        private static int GetNextId(int count,string tableName)
        {
            string errMsg = "";
            DataCtrlInfo dcf = new DataCtrlInfo(); ;
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, tableName, count, ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, tableName, new Exception(errMsg));
                return 0;
            }

            return nextId;
        }

    }
}
