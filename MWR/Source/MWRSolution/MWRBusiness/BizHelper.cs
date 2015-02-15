using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRKJ.MWR.Business
{
    public class BizHelper
    {
        #region biz utility

        public static decimal ConventToSysUnitWeight(decimal orgWeight,string orgUnit,string sysUnit)
        {
            decimal KgWeight = 0;
            switch (sysUnit.ToLower())
            { 
                case "kg":
                    KgWeight = orgWeight;
                    break;
                case "g":
                    KgWeight = orgWeight * 1000;
                    break;
                default://"kg"
                    KgWeight = orgWeight;
                    break;
            }

            decimal weight = 0;
            switch (sysUnit.ToLower())
            {
                case "kg":
                    weight = KgWeight;
                    break;
                case "g":
                    weight = KgWeight / 1000;
                    break;
                default://"kg"
                    weight = KgWeight;
                    break;
            }

            return weight;
            
        }

        #endregion

        #region get status language
        public static string GetTxnRecoverHeaderStatus(string s)
        {
            string defineStr = "";
            switch (s)
            { 
                case TblMWTxnRecoverHeader.STATUS_ENUM_Process:
                    defineStr = LngRes.Status_TxnHeader_Process;
                    break;
                case TblMWTxnRecoverHeader.STATUS_ENUM_Complete:
                    defineStr = LngRes.Status_TxnHeader_Complete;
                    break;
                case TblMWTxnRecoverHeader.STATUS_ENUM_Authorize:
                    defineStr = LngRes.Status_TxnHeader_Authorize;
                    break;
                case TblMWTxnRecoverHeader.STATUS_ENUM_Send:
                    defineStr = LngRes.Status_TxnHeader_Send;
                    break;
            }
            return defineStr;
        }
        public static string GetTxnPostHeaderStatus(string s)
        {
            string defineStr = "";
            switch (s)
            { 
                case TblMWTxnPostHeader.STATUS_ENUM_Authorize:
                    defineStr = LngRes.Status_TxnHeader_Authorize;
                    break;
                case TblMWTxnPostHeader.STATUS_ENUM_Complete:
                    defineStr = LngRes.Status_TxnHeader_Complete;
                    break;
                case TblMWTxnPostHeader.STATUS_ENUM_Process:
                    defineStr = LngRes.Status_TxnHeader_Process;
                    break;
            }

            return defineStr;
        }
        public static string GetTxnDetroyHeaderStatus(string s)
        {
            string defineStr = "";
            switch (s)
            {
                case TblMWTxnPostHeader.STATUS_ENUM_Authorize:
                    defineStr = LngRes.Status_TxnHeader_Authorize;
                    break;
                case TblMWTxnPostHeader.STATUS_ENUM_Complete:
                    defineStr = LngRes.Status_TxnHeader_Complete;
                    break;
                case TblMWTxnPostHeader.STATUS_ENUM_Process:
                    defineStr = LngRes.Status_TxnHeader_Process;
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
        public static string GetTxnDetailTxnType(string s)
        {
            string defineStr = "";
            switch (s)
            { 
                case TblMWTxnDetail.TXNTYPE_ENUM_Recover:
                    defineStr = LngRes.TxnType_Detail_Recover;
                    break;
                case TblMWTxnDetail.TXNTYPE_ENUM_Post:
                    defineStr = LngRes.TxnType_Detial_Post;
                    break;
                case TblMWTxnDetail.TXNTYPE_ENUM_Destroy:
                    defineStr = LngRes.TxnType_Detail_Destroy;
                    break;
            }
            return defineStr;
        }

        public static string GetWSType(string s)
        {
            string defineStr = "";

            switch (s)
            {
                case TblMWWorkStation.WSTYPE_ENUM_DesWorkStation:
                    defineStr = LngRes.WSType_Des;
                    break;
                case TblMWWorkStation.WSTYPE_ENUM_InvWorkStation:
                    defineStr = LngRes.WSType_Inv;
                    break;
                case TblMWWorkStation.WSTYPE_ENUM_MobWorkStation:
                    defineStr = LngRes.WSType_Mob;
                    break;
                case TblMWWorkStation.WSTYPE_ENUM_WaitWorkStation:
                    defineStr = LngRes.WSType_Wait;
                    break;


            }

            return defineStr;
        }
        #endregion

        public class LngRes
        {
            public const string WSType_Des = "处置工作站";
            public const string WSType_Inv = "出入库工作站";
            public const string WSType_Mob = "手机终端";
            public const string WSType_Wait = "手机终端-等待初始化";

            public const string Status_TxnHeader_Process = "处理中";
            public const string Status_TxnHeader_Complete = "完成";
            public const string Status_TxnHeader_Authorize = "审核中";
            public const string Status_TxnHeader_Send = "新计划提交";

            public const string Status_Detail_Authorize = "审核中";
            public const string Status_Detail_Complete = "完成";
            public const string Status_Detail_Process = "提交处理中";
            public const string Status_Detail_Wait = "审核完成";

            public const string TxnType_Detail_Recover = "回收入库";
            public const string TxnType_Detial_Post = "废物出库";
            public const string TxnType_Detail_Destroy = "废物处置";
        }

    }
}
