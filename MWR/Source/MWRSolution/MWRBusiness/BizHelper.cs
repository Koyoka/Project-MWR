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
        public static string GetTxnDestroyHeaderStatus(string s)
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

        public static string GetInventoryStatus(string s)
        {
            string defineStr = "";

            switch (s)
            { 
                case TblMWInventory.STATUS_ENUM_Recovered:
                    defineStr = LngRes.Status_Inventory_Destroyed;
                    break;
                case TblMWInventory.STATUS_ENUM_Posted:
                    defineStr = LngRes.Status_Inventory_Posted;
                    break;
                case TblMWInventory.STATUS_ENUM_Destroyed:
                    defineStr = LngRes.Status_Inventory_Destroyed;
                    break;
                case TblMWInventory.STATUS_ENUM_Recovering:
                    defineStr = LngRes.Status_Inventory_Recovering;
                    break;
                case TblMWInventory.STATUS_ENUM_Posting:
                    defineStr = LngRes.Status_Inventory_Posting;
                    break;
                case TblMWInventory.STATUS_ENUM_Destroying:
                    defineStr = LngRes.Status_Inventory_Destroying;
                    break;
            }
            return defineStr;
        }
        public static string GetInventoryTrackTxnType(string s)
        {
            string defineStr = "";
            switch (s)
            { 
                case TblMWInventoryTrack.TXNTYPE_ENUM_Destroy:
                    defineStr = LngRes.TxnType_Detail_Destroy;
                    break;
                case TblMWInventoryTrack.TXNTYPE_ENUM_Post:
                    defineStr = LngRes.TxnType_Detial_Post;
                    break;
                case TblMWInventoryTrack.TXNTYPE_ENUM_Recover:
                    defineStr = LngRes.TxnType_Detail_Recover;
                    break;
            }
            return defineStr;
        }

        public static string GetDestroyType(string s)
        {
            string defineStr = "";
            switch (s)
            {
                case TblMWTxnDestroyHeader.DESTTYPE_ENUM_PostDestroy:
                    defineStr = LngRes.DestType_PostDestroy;
                    break;
                case TblMWTxnDestroyHeader.DESTTYPE_ENUM_RecoverDestroy:
                    defineStr = LngRes.DestType_RecoverDestroy;
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

        public static string GetEmpyType(string s)
        {
            string defineStr = "";

            switch (s)
            { 
                case TblMWEmploy.EMPYTYPE_ENUM_Driver:
                    defineStr = LngRes.Empy_Driver;
                    break;
                case TblMWEmploy.EMPYTYPE_ENUM_Inspector:
                    defineStr = LngRes.Empy_Inspector;
                    break;
                //case TblMWEmploy.EMPYTYPE_ENUM_Void:
                //    defineStr = LngRes.Empy_Void;
                //    break;
                case TblMWEmploy.EMPYTYPE_ENUM_WorkStation:
                    defineStr = LngRes.Empy_WS;
                    break;
                default:
                    defineStr = LngRes.Empy_WS;
                    break;
            }

            return defineStr;
        }

        public static string GetTxnLogOptType(string s)
        {
            string defineStr = "";
          
            switch (s)
            {
                case TblMWTxnLog.OPTTYPE_ENUM_SubComplete:
                    defineStr = LngRes.OPTTYPE_SubComplete;
                    break;
                case TblMWTxnLog.OPTTYPE_ENUM_SubAuthorize:
                    defineStr = LngRes.OPTTYPE_SubAuthorize;
                    break;
                case TblMWTxnLog.OPTTYPE_ENUM_AuthorizeDone:
                    defineStr = LngRes.OPTTYPE_AuthorizeDone;
                    break;
                case TblMWTxnLog.OPTTYPE_ENUM_AuthorizeComplete:
                    defineStr = LngRes.OPTTYPE_AuthorizeComplete;
                    break;
                case TblMWTxnLog.OPTTYPE_ENUM_SubRecover:
                    defineStr = LngRes.OPTTYPE_SubRecover;
                    break;
                case TblMWTxnLog.OPTTYPE_ENUM_NewTxn:
                    defineStr = LngRes.OPTTYPE_NewTxn;
                    break;
            }

            return defineStr;

        }

        public static string GetAuthorizeStatus(string s)
        {
            string defineStr = "";
            switch (s)
            { 
                case TblMWInvAuthorize.STATUS_ENUM_Complete:
                    defineStr = LngRes.Status_Authorize_Complete;
                    break;
                case TblMWInvAuthorize.STATUS_ENUM_Precess:
                    defineStr = LngRes.Statuc_Authorize_Precess;
                    break;
            }
            return defineStr;
        }
        #endregion

        public class LngRes
        {
            public const string Status_Authorize_Complete = "审核完成";
            public const string Statuc_Authorize_Precess = "等待审核";

            public const string OPTTYPE_SubComplete = "提交完成";//1.交易提交完成操作库存 SC  submit inventory;
            public const string OPTTYPE_SubAuthorize = "提交审核";//2.交易提交审核 SA submit authorize;
            public const string OPTTYPE_AuthorizeDone = "审核通过";//管理中心审核通过;
            public const string OPTTYPE_AuthorizeComplete = "审核完成";//3.确认审核并完成操作库存 AC authorize inventory;
            public const string OPTTYPE_SubRecover = "提交回收";//4.车辆回场提交回收;
            public const string OPTTYPE_NewTxn = "新建交易";//新建交易;
             

            public const string Status_Inventory_Recovered = "已入库";
            public const string Status_Inventory_Posted = "已出库";
            public const string Status_Inventory_Destroyed = "已处置";
            public const string Status_Inventory_Recovering = "入库中";
            public const string Status_Inventory_Posting = "出库中";
            public const string Status_Inventory_Destroying = "处置中";

            public const string DestType_PostDestroy = "库存出库处置";
            public const string DestType_RecoverDestroy = "车辆回收处置";

            public const string Empy_Driver = "司机";
            public const string Empy_Inspector = "跟车员";
            public const string Empy_Void = "注销员工";
            public const string Empy_WS = "一般员工";

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
            public const string Status_Detail_Process = "处理中";
            public const string Status_Detail_Wait = "审核完成";

            public const string TxnType_Detail_Recover = "回收入库";
            public const string TxnType_Detial_Post = "废物出库";
            public const string TxnType_Detail_Destroy = "废物处置";
        }

    }
}
