using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRKJ.MWR.Business
{
    public class BizHelper
    {

        #region get status language 
        public static string GetTxnRecoverHeaderStatus(string s)
        {
            string defineStr = "";
            switch (s)
            { 
                case TblMWTxnRecoverHeader.STATUS_ENUM_Process:
                    defineStr = LngRes.Status_RHeader_Process;
                    break;
                case TblMWTxnRecoverHeader.STATUS_ENUM_Complete:
                    defineStr = LngRes.Status_RHeader_Complete;
                    break;
                case TblMWTxnRecoverHeader.STATUS_ENUM_Authorize:
                    defineStr = LngRes.Status_RHeader_Authorize;
                    break;
                case TblMWTxnRecoverHeader.STATUS_ENUM_Send:
                    defineStr = LngRes.Status_RHeader_Send;
                    break;
            }
            return defineStr;
        }

        public static string GetTxnDetailStatus(string s)
        { 
            string defineStr = "";
            switch (s)
            {
                case TblMWTxnDetail.STATUS_ENUM_Authorize:
                    defineStr = LngRes.Status_Detail_Authorize;
                    break;
                case TblMWTxnDetail.STATUS_ENUM_Complete:
                    defineStr = LngRes.Status_Detail_Complete;
                    break;
                case TblMWTxnDetail.STATUS_ENUM_Process:
                    defineStr = LngRes.Status_Detail_Process;
                    break;
                case TblMWTxnDetail.STATUS_ENUM_Wait:
                    defineStr = LngRes.Status_Detail_Wait;
                    break;
            }
            return defineStr;
        }
        #endregion

        public class LngRes
        {
            public const string Status_RHeader_Process = "处理中";
            public const string Status_RHeader_Complete = "完成";
            public const string Status_RHeader_Authorize = "审核中";
            public const string Status_RHeader_Send = "新计划提交";

            public const string Status_Detail_Authorize = "审核中";
            public const string Status_Detail_Complete = "完成";
            public const string Status_Detail_Process = "提交处理中";
            public const string Status_Detail_Wait = "审核完成";

        }

    }
}
