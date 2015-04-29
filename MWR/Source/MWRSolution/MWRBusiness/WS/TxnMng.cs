using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using YRKJ.MWR.Business.Sys;
using ComLib.Error;

namespace YRKJ.MWR.Business.WS
{
    public class TxnMng
    {
        public const string ClassName = "YRKJ.MWR.Business.WS.TxnMng";

        #region txn

        #region common
        #region public 
        public static bool GetTodayIWSTxnDetail(ref List<TblMWTxnDetail> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            DateTime today = SqlDBMng.GetDBNow();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddDateTimeCompareValue(TblMWTxnDetail.getEntryDateColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, today, SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);

            SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
            sw.AddCompareValue(TblMWTxnDetail.getTxnTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWTxnDetail.TXNTYPE_ENUM_Recover);
            sw.AddCompareValue(TblMWTxnDetail.getTxnTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWTxnDetail.TXNTYPE_ENUM_Post);
            sqm.Condition.Where.AddWhere(sw);
            sqm.Condition.OrderBy.Add(TblMWTxnDetail.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);
            if (!TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool GetTodayDWSTxnDetail(ref List<TblMWTxnDetail> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            DateTime today = SqlDBMng.GetDBNow();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddDateTimeCompareValue(TblMWTxnDetail.getEntryDateColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, today, SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWTxnDetail.TXNTYPE_ENUM_Destroy);
            sqm.Condition.OrderBy.Add(TblMWTxnDetail.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.DESC);

            if (!TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetDetailList(string txnNum,ref  List<TblMWTxnDetail> detailList,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
            if (!TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref detailList, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetInventoryTxnDetail(int invRecordId, string txnNum, ref TblMWTxnDetail detail, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

            if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref detail, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool GetRecoveredInventory(string crateCode, ref TblMWInventory inv, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getCrateCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, crateCode);
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInventory.STATUS_ENUM_Recovered);

            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            //if (inv == null)
            //{
            //    errMsg = "没有找到当前货箱的库存记录";
            //    return false;
            //}

            return true;
        }
        public static bool GetInventroy(int invRecordId,ref TblMWInventory inv,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetRecoverHeaderAndDetail(string txnNum,
            ref VewTxnHeaderWithCarDispatch header,
            ref List<TblMWTxnDetail> detailList,
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(VewTxnHeaderWithCarDispatch.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                if (!VewTxnHeaderWithCarDispatchCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                {
                    return false;
                }
                if (header == null)
                {
                    detailList = new List<TblMWTxnDetail>();
                    //errMsg = "没有找到当前编号的回收计划单";
                    return true;
                }
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                if (!TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref detailList, ref errMsg))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region private 
        public static bool GetTxnDetail(int txnDetailId, ref TblMWTxnDetail detail, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnDetailId);

            if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref detail, ref errMsg))
            {
                return false;
            }

            return true;
        }
       
        private static bool ValidWSAndEmploy(string wsCode, string empyCode, ref TblMWWorkStation ws, ref TblMWEmploy empy, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);
                if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref empy, ref errMsg))
                {
                    return false;
                }
                if (empy == null)
                {
                    errMsg = LngRes.MSG_Valid_NoEmploy;
                    return false;
                }
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWWorkStation.getWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wsCode);
                if (!TblMWWorkStationCtrl.QueryOne(dcf, sqm, ref ws, ref errMsg))
                {
                    return false;
                }
                if (ws == null)
                {
                    errMsg = LngRes.MSG_Valid_NoWorkstation;
                    return false;
                }
            }
            return true;
        }

        private enum ValidWeightType
        { 
            Recover,Post,Destroy
        }
        private static bool ValidCrateWeight(decimal subWeight, decimal txnWeight,ValidWeightType type, ref string errMsg)
        {
            bool pDiffWeightAsIdentical = MWParams.GetAllowDiffWeightAsIdentical();
            decimal defineDiffWeight = 0;
            if (pDiffWeightAsIdentical)
            {
                defineDiffWeight = MWParams.GetAllowDiffWeight_All();
            }
            else {
                if (type == ValidWeightType.Destroy)
                {
                    defineDiffWeight = MWParams.GetAllowDiffWeight_Destory();
                }
                else if (type == ValidWeightType.Post)
                {
                    defineDiffWeight = MWParams.GetAllowDiffWeight_Post();
                }
                else if (type == ValidWeightType.Recover)
                {
                    defineDiffWeight = MWParams.GetAllowDiffWeight_Recover();
                }
            }

#if DEBUG
            decimal diffWeight = 100m;
#else
            decimal diffWeight = defineDiffWeight;// MWParams.GetAllowDiffWeight();
#endif
            if (Math.Abs(subWeight - txnWeight) > diffWeight)
            {
                errMsg = "重量不符";
                return false;
            }
            return true;
        }
        #endregion
        #endregion

        #region recover txn list

        #region get data
        public static bool GetRecoverToInvTxnList(string wscode, ref List<VewTxnHeaderWithCarDispatch> header, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            {
                SqlWhere sw = new SqlWhere( SqlCommonFn.SqlWhereLinkType.OR);
                sw.AddCompareValue(VewTxnHeaderWithCarDispatch.getRecoWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wscode);
                sw.AddCompareValue(VewTxnHeaderWithCarDispatch.getRecoWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, string.Empty);
                sqm.Condition.Where.AddWhere(sw);
            }
            sqm.Condition.Where.AddCompareValue(VewTxnHeaderWithCarDispatch.getOperateTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals,
                    VewTxnHeaderWithCarDispatch.OPERATETYPE_ENUM_ToInventory);
            sqm.Condition.Where.AddCompareValue(VewTxnHeaderWithCarDispatch.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals,
                   VewTxnHeaderWithCarDispatch.STATUS_ENUM_Complete);

            sqm.Condition.OrderBy.Add(VewTxnHeaderWithCarDispatch.getInDateColumn(), SqlCommonFn.SqlOrderByType.ASC);

            if (!VewTxnHeaderWithCarDispatchCtrl.QueryMore(dcf, sqm, ref header, ref errMsg))
            {
                header = new List<VewTxnHeaderWithCarDispatch>();
                return false;
            }

            return true;
        }
        
        public static bool GetRecoverLeftDetailCount(string txnNum,ref int count, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWTxnDetail.STATUS_ENUM_Complete);
            sqm.QueryColumn.AddCount(TblMWTxnDetail.getTxnDetailIdColumn());

            TblMWTxnDetail item = null;
            if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
            {
                return false;
            }

            if(item == null)
            {
                count = 0;
                return true;
            }
            count = item.TxnDetailId;

            return true;
        }
        #endregion

        #region recover txn operate
        public static bool BeginOperateRecoverTxn(string txnNum, string wsCode, string empyCode, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnRecoverHeader header = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            #region valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                sqm.Condition.Where.AddCompareValue(TblMWTxnRecoverHeader.getRecoWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, ws.WSCode);
                if (!TblMWTxnRecoverHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                {
                    return false;
                }
                if (header != null)
                {
                    //process by this workstation
                    return true;
                }
            }
            #endregion

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWTxnRecoverHeader.getRecoWSCodeColumn(), ws.WSCode);
            suc.Add(TblMWTxnRecoverHeader.getRecoEmpyCodeColumn(), empy.EmpyCode);
            suc.Add(TblMWTxnRecoverHeader.getRecoEmpyNameColumn(), empy.EmpyName);
            suc.Add(TblMWTxnRecoverHeader.getStartDateColumn(), SqlDBMng.GetDBNow());
            suc.Add(TblMWTxnRecoverHeader.getStatusColumn(),TblMWTxnRecoverHeader.STATUS_ENUM_Process);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals,
                txnNum);
            sw.AddCompareValue(TblMWTxnRecoverHeader.getRecoWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, "");

            int updCount = 0;
            if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            if (updCount == 0)
            {
                errMsg = "已被其他工作站处理";
                return false;
            }

            return true;
        }

        #region workflow 1
        public static bool ConfirmCrateToInventory(int txnDetailId,
            decimal txnWeight, string wsCode, string empyCode, 
            string depotCode,
            ref string errMsg)
        {

            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnDetail detail = null;
            TblMWWorkStation ws = null;
            TblMWEmploy empy = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                if (!GetTxnDetail(txnDetailId, ref detail, ref errMsg))
                {
                    return false;
                }
                if (detail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoTxnDetail; //"没有找到当前ID的货箱交易详情";
                    return false;
                }

                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
                {
                    errMsg = LngRes.MSG_Valid_TxnComplete; //"当前货箱已完成入库";
                    return false;
                }
                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Authorize)
                {
                    errMsg = LngRes.MSG_Valid_TxnInAuthorize; //"当前货箱正在审核中";
                    return false;
                }
            }
#if !DEBUG 
            {
                TblMWInventory inv = null;
                if (!GetRecoveredInventory(detail.CrateCode, ref inv, ref errMsg))
                {
                    return false;
                }

                if (inv != null)
                {
                    errMsg = LngRes.MSG_Valid_CrateIsInvData;
                    return false;
                }
            }
#endif
            #endregion

            #region valid Biz
            if (!ValidCrateWeight(detail.SubWeight, txnWeight, ValidWeightType.Recover, ref errMsg))
            {
                return false;
            }
            #endregion

            dcf.BeginTrans();

            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            #region add data

            int invRecordNextId = 0;
            int invTrackNextId = 0;
            int txnLogNextId = 0;
            #region get next id
            invRecordNextId = MWNextIdMng.GetInventoryNextId();
            invTrackNextId = MWNextIdMng.GetInventoryTrackNextId();
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();

            bool validNextId = true;
            validNextId = invRecordNextId != 0 && validNextId;
            validNextId = invTrackNextId != 0 && validNextId;
            validNextId = txnLogNextId != 0 && validNextId;

            if (!validNextId)
            {
                errMsg = MWNextIdMng.NextIdErrMsg;
                return false;
            }
            #endregion

            #region update txn header
            {
                string txnNum = detail.TxnNum;
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.AddJoinSelf(TblMWTxnRecoverHeader.getTotalTxnWeightColumn(), txnWeight);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

                if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update current txn detail
            {
                //TblMWTxnDetail item = new TblMWTxnDetail();
                detail.WSCode = ws.WSCode;
                detail.EmpyCode = empyCode;
                detail.EmpyName = empy.EmpyName;
                //dtl.CrateCode = "";
                //dtl.Vendor = "";
                //dtl.VendorCode = "";
                //dtl.Waste = "";
                //dtl.WasteCode = "";
                //dtl.SubWeight = "";
                detail.TxnWeight = txnWeight;
                detail.EntryDate = now;
                detail.InvRecordId = invRecordNextId;
                //dtl.InvAuthId = "";
                detail.Status = TblMWTxnDetail.STATUS_ENUM_Complete;

                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(
                    TblMWTxnDetail.getWSCodeColumn(),
                    TblMWTxnDetail.getEmpyCodeColumn(),
                    TblMWTxnDetail.getEmpyNameColumn(),
                    TblMWTxnDetail.getTxnWeightColumn(),
                    TblMWTxnDetail.getEntryDateColumn(),
                    TblMWTxnDetail.getInvRecordIdColumn(),
                    TblMWTxnDetail.getStatusColumn()
                    );
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnDetailId);

                if (!TblMWTxnDetailCtrl.Update(dcf, detail, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add inventory
            {
                TblMWInventory item = new TblMWInventory();
                item.InvRecordId = invRecordNextId;
                item.CrateCode = detail.CrateCode;
                item.DepotCode = depotCode;
                item.Vendor = detail.Vendor;
                item.VendorCode = detail.VendorCode;
                item.Waste = detail.Waste;
                item.WasteCode = detail.WasteCode;
                item.RecoWeight = detail.SubWeight;
                item.InvWeight = detail.TxnWeight;
                //item.PostWeight = detail.PostWeight;
                //item.DestWeight = detail.DestWeight;
                item.EntryDate = now;

                //item.Status = TblMWInventory.STATUS_ENUM_Recovered;
                item.Status = TblMWInventory.STATUS_ENUM_Recovering;

                //item.DailyClose = detail.DailyClose;


                if (!TblMWInventoryCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add inventory track
            {
                TblMWInventoryTrack item = new TblMWInventoryTrack();
                item.InvTrackRecordId = invTrackNextId;
                item.InvRecordId = invRecordNextId;
                item.TxnNum = detail.TxnNum;
                item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Recover;
                item.TxnDetailId = detail.TxnDetailId;
                item.CrateCode = detail.CrateCode;
                item.DepotCode = depotCode;
                item.Vendor = detail.Vendor;
                item.VendorCode = detail.VendorCode;
                item.Waste = detail.Waste;
                item.WasteCode = detail.WasteCode;
                item.SubWeight = detail.SubWeight;
                item.TxnWeight = txnWeight;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.EntryDate = now;
                item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
                item.InvAuthId = detail.InvAuthId;

                if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;

                item.TxnNum = detail.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.WSCode = ws.WSCode;// detail.WSCode;
                item.EmpyName = empy.EmpyName;// detail.EmpyName;
                item.EmpyCode = empy.EmpyCode;//detail.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubComplete;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Recover;

                item.InvRecordId = invRecordNextId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region workflow 2
        public static bool ConfirmCrareToAuthorize(int txnDetailId,
            decimal txnWeight,
            string wsCode, string empyCode, 
            ref int reInvAuthId,
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnDetail detail = null;
            TblMWWorkStation ws = null;
            TblMWEmploy empy = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                if (!GetTxnDetail(txnDetailId, ref detail, ref errMsg))
                {
                    return false;
                }
                if (detail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoTxnDetail; //"没有找到当前ID的货箱交易详情";
                    return false;
                }

                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
                {
                    errMsg = LngRes.MSG_Valid_TxnComplete; //"当前货箱已完成入库";
                    return false;
                }
                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Authorize)
                {
                    errMsg = LngRes.MSG_Valid_TxnInAuthorize; //"当前货箱正在审核中";
                    return false;
                }
            }
#if !DEBUG
            {
                TblMWInventory inv = null;
                if (!GetRecoveredInventory(detail.CrateCode, ref inv, ref errMsg))
                {
                    return false;
                }

                if (inv != null)
                {
                    errMsg = LngRes.MSG_Valid_CrateIsInvData;
                    return false;
                }
            }
#endif
            #endregion
            
            dcf.BeginTrans();

            #region add data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;
            int txnLogNextId = 0;
            int invAuthId = 0;
            #region next id
            bool validNextId = true;
            invAuthId = MWNextIdMng.GetInvAuthorizeNextId();
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();

            validNextId = txnLogNextId != 0 && validNextId;
            validNextId = invAuthId != 0 && validNextId;
            if (!validNextId)
            {
                errMsg = MWNextIdMng.NextIdErrMsg;
                return false;
            }
            #endregion

            #region authorize data
            {
                TblMWInvAuthorize item = new TblMWInvAuthorize();
                item.InvAuthId = invAuthId;
                item.TxnNum = detail.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.EmpyCode = empy.EmpyCode;
                item.EmpyName = empy.EmpyName;
                item.WSCode = ws.WSCode;
                //item.AuthEmpyCode = detail.AuthEmpyCode;
                //item.AuthEmpyName = detail.AuthEmpyName;
                //item.Remark = detail.Remark;
                item.SubWeight = detail.SubWeight;
                item.TxnWeight = txnWeight;
                item.DiffWeight = detail.SubWeight - txnWeight;
                item.EntryDate = now;
                //item.CompDate = detail.CompDate;
                item.Status = TblMWInvAuthorize.STATUS_ENUM_Precess;

                if (!TblMWInvAuthorizeCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region txnheader data
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), TblMWTxnRecoverHeader.STATUS_ENUM_Authorize);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnNum);
                if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region txndetail data
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDetail.getInvAuthIdColumn(), invAuthId);
                suc.Add(TblMWTxnDetail.getStatusColumn(), TblMWTxnDetail.STATUS_ENUM_Authorize);
                suc.Add(TblMWTxnDetail.getTxnWeightColumn(), txnWeight);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnDetailId);

                if (!TblMWTxnDetailCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = detail.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.WSCode = ws.WSCode;// detail.WSCode;
                item.EmpyName = empy.EmpyName;// detail.EmpyName;
                item.EmpyCode = empy.EmpyCode;//detail.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubAuthorize;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Recover;
                //item.InvRecordId = invRecordNextId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion
            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            reInvAuthId = invAuthId;

            return true;
        }

        public static bool AuthorizeCrareToInventory(int txnDetailId,
            string wsCode, string empyCode,
            string depotCode, 
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnDetail detail = null;
            TblMWWorkStation ws = null;
            TblMWEmploy empy = null;
            int curTxnPresseAuthCount = 0;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                if (!GetTxnDetail(txnDetailId, ref detail, ref errMsg))
                {
                    return false;
                }
                if (detail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoTxnDetail; 
                    return false;
                }
                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
                {
                    errMsg = LngRes.MSG_Valid_TxnComplete; 
                    return false;
                }
            }
#if !DEBUG
            {
                TblMWInventory inv = null;
                if (!GetRecoveredInventory(detail.CrateCode, ref inv, ref errMsg))
                {
                    return false;
                }

                if (inv != null)
                {
                    errMsg = LngRes.MSG_Valid_CrateIsInvData;
                    return false;
                }
            }
#endif
            {
                List<TblMWInvAuthorize> itemList = null;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInvAuthorize.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInvAuthorize.STATUS_ENUM_Precess);
                sqm.Condition.Where.AddCompareValue(TblMWInvAuthorize.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnNum);
                if (!TblMWInvAuthorizeCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
                {
                    return false;
                }
                curTxnPresseAuthCount = itemList.Count;
                itemList = itemList.Where(x => x.TxnDetailId == detail.TxnDetailId).ToList();
               
                TblMWInvAuthorize invAuth = null;
                if (itemList.Count != 0)
                {
                    invAuth = itemList[0];
                }
                if (invAuth != null)
                {
                    errMsg = LngRes.MSG_Valid_TxnInAuthorize; 
                    return false;
                }
            }
            #endregion

            dcf.BeginTrans();

            #region add data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            int invRecordNextId = 0;
            int invTrackNextId = 0;
            int txnLogNextId = 0;
            #region get next id
            invRecordNextId = MWNextIdMng.GetInventoryNextId();
            invTrackNextId = MWNextIdMng.GetInventoryTrackNextId();
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();

            bool validNextId = true;
            validNextId = invRecordNextId != 0 && validNextId;
            validNextId = invTrackNextId != 0 && validNextId;
            validNextId = txnLogNextId != 0 && validNextId;

            if (!validNextId)
            {
                errMsg = MWNextIdMng.NextIdErrMsg;
                return false;
            }
            #endregion

            #region update current txn header to process if this txn detail all Complete authoize
            if (curTxnPresseAuthCount == 0)
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), TblMWTxnRecoverHeader.STATUS_ENUM_Process);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnNum);

                if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update txn header
            {
                string txnNum = detail.TxnNum;
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.AddJoinSelf(TblMWTxnRecoverHeader.getTotalTxnWeightColumn(), detail.TxnWeight);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

                if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update current txn detail
            {
                //TblMWTxnDetail item = new TblMWTxnDetail();
                detail.WSCode = ws.WSCode;
                detail.EmpyCode = empy.EmpyCode;
                detail.EmpyName = empy.EmpyName;
                //dtl.CrateCode = "";
                //dtl.Vendor = "";
                //dtl.VendorCode = "";
                //dtl.Waste = "";
                //dtl.WasteCode = "";
                //dtl.SubWeight = "";
                //detail.TxnWeight = txnWeight;
                detail.EntryDate = now;
                detail.InvRecordId = invRecordNextId;
                //dtl.InvAuthId = "";
                detail.Status = TblMWTxnDetail.STATUS_ENUM_Complete;

                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(
                    TblMWTxnDetail.getWSCodeColumn(),
                    TblMWTxnDetail.getEmpyCodeColumn(),
                    TblMWTxnDetail.getEmpyNameColumn(),
                    //TblMWTxnDetail.getTxnWeightColumn(),
                    TblMWTxnDetail.getEntryDateColumn(),
                    TblMWTxnDetail.getInvRecordIdColumn(),
                    TblMWTxnDetail.getStatusColumn()
                    );
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnDetailId);

                if (!TblMWTxnDetailCtrl.Update(dcf, detail, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add inventory
            {
                TblMWInventory item = new TblMWInventory();
                item.InvRecordId = invRecordNextId;
                item.CrateCode = detail.CrateCode;
                item.DepotCode = depotCode;
                item.Vendor = detail.Vendor;
                item.VendorCode = detail.VendorCode;
                item.Waste = detail.Waste;
                item.WasteCode = detail.WasteCode;
                item.RecoWeight = detail.SubWeight;
                item.InvWeight = detail.TxnWeight;
                //item.PostWeight = detail.PostWeight;
                //item.DestWeight = detail.DestWeight;
                item.EntryDate = now;
                item.Status = TblMWInventory.STATUS_ENUM_Recovering;
                //item.DailyClose = detail.DailyClose;


                if (!TblMWInventoryCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add inventory track
            {
                TblMWInventoryTrack item = new TblMWInventoryTrack();
                item.InvTrackRecordId = invTrackNextId;

                item.InvRecordId = invRecordNextId;

                item.TxnNum = detail.TxnNum;
                item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Recover;//detail.TxnType;
                item.TxnDetailId = detail.TxnDetailId;
                item.CrateCode = detail.CrateCode;
                item.DepotCode = depotCode;
                item.Vendor = detail.Vendor;
                item.VendorCode = detail.VendorCode;
                item.Waste = detail.Waste;
                item.WasteCode = detail.WasteCode;
                item.SubWeight = detail.SubWeight;
                item.TxnWeight = detail.TxnWeight;
                item.WSCode = ws.WSCode;// detail.WSCode;
                item.EmpyName = empy.EmpyName;//detail.EmpyName;
                item.EmpyCode = empy.EmpyCode;// detail.EmpyCode;
                item.EntryDate = now;
                item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
                item.InvAuthId = detail.InvAuthId;

                if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;

                item.TxnNum = detail.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_AuthorizeComplete;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Recover;

                item.InvRecordId = invRecordNextId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        public static bool EndConfirmRecoverTxn(string txnNum,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            List<TblMWTxnDetail> detailList = null;
            #region check txn has been complete all txndetail
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals,
                TblMWTxnDetail.STATUS_ENUM_Complete);
            if (!TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref detailList, ref errMsg))
            {
                return false;
            }
            if (detailList.Count > 0)
            {
                errMsg = LngRes.MSG_Valid_ExistUnCompleteTxnDetail;
                return false;
            }

            if(!GetDetailList(txnNum,ref detailList,ref errMsg))
            {
                return false;
            }
            #endregion

            dcf.BeginTrans();

            #region update data
            int updCount = 0;
            #region update txn data
            {
                DateTime now = SqlDBMng.GetDBNow();

                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), TblMWTxnRecoverHeader.STATUS_ENUM_Complete);
                suc.Add(TblMWTxnRecoverHeader.getEndDateColumn(), now);
                decimal totalTxnWeight = 0;
                foreach (var item in detailList)
                {
                    totalTxnWeight += item.TxnWeight;
                }
                suc.Add(TblMWTxnRecoverHeader.getTotalTxnWeightColumn(), totalTxnWeight);
                
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

                if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update inventory to end
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Recovered);

                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                foreach (TblMWTxnDetail detail in detailList)
                {
                    sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.InvRecordId);
                }

                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion
            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }
        #endregion
        
        #endregion

        #region post txn list

        #region get data
        public static bool GetProcessingPostTxnList(string wscode, ref List<TblMWTxnPostHeader> header, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnPostHeader.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWTxnPostHeader.STATUS_ENUM_Complete);
            sqm.Condition.Where.AddCompareValue(TblMWTxnPostHeader.getPostTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWTxnPostHeader.POSTTYPE_ENUM_Auto);
            sqm.Condition.Where.AddCompareValue(TblMWTxnPostHeader.getPostWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wscode);

            if (!TblMWTxnPostHeaderCtrl.QueryMore(dcf, sqm, ref header, ref errMsg))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region post txn operate

        #region workflow 1
        public static bool ConfirmInventoryToPostNew(int invRecordId,  decimal txnWeight, string wsCode, string empyCode,ref string newTxnNum, ref string errMsg)
        {
            return ConfirmInventoryToPost(invRecordId, null, txnWeight, wsCode, empyCode, ref newTxnNum,ref errMsg);
        }

        public static bool ConfirmInventoryToPostEdit(int invRecordId,string txnNum,  decimal txnWeight, string wsCode, string empyCode, ref string errMsg)
        {
            string newTxnNum = "";
            return ConfirmInventoryToPost(invRecordId, txnNum, txnWeight, wsCode, empyCode, ref newTxnNum, ref errMsg); ;
        }

        private static bool ConfirmInventoryToPost(int invRecordId, string txnNum,decimal txnWeight, string wsCode, string empyCode,ref string newTxnNum, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWInventory inv = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
                if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
                {
                    return false;
                }
                if (inv == null)
                {
                    errMsg = LngRes.MSG_Valid_NoInventory;
                    return false;
                }
            }
            #endregion

            #region valid Biz
            if (!ValidCrateWeight(inv.InvWeight, txnWeight,ValidWeightType.Post, ref errMsg))
            {
                return false;
            }
            #endregion

            dcf.BeginTrans();

            #region add data
            DateTime now = SqlDBMng.GetDBNow();
            int dtlNextId = MWNextIdMng.GetTxnDetailNextId();
            int txnLogNextId = MWNextIdMng.GetTxnLogNextId();
            int invTrackNextId = MWNextIdMng.GetInventoryTrackNextId();

            bool valid = true;
            valid = dtlNextId != 0 && valid;
            valid = txnLogNextId != 0 && valid;
            valid = invTrackNextId != 0 && valid;

            if (!valid)
            {
                ErrorMng.GetDBError(ClassName, "ConfirmInventoryToPost", MWNextIdMng.NextIdErrMsg);
                return false;
            }

            TblMWTxnPostHeader header = null;
            if (string.IsNullOrEmpty(txnNum))
            {
                #region newTxnHeader
                {
                    newTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
                    if (string.IsNullOrEmpty(newTxnNum))
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "ConfirmInventoryToPost", MWNextIdMng.NextIdErrMsg);
                        return false;
                    }

                    int headerNextId = MWNextIdMng.GetTxnPostHeaderNextId();
                    if (headerNextId == 0)
                    {
                        ErrorMng.GetDBError(ClassName, "ConfirmInventoryToPost", MWNextIdMng.NextIdErrMsg);
                        return false;
                    }

                    TblMWTxnPostHeader item = new TblMWTxnPostHeader();
                    item.PostHeaderId = headerNextId;
                    item.TxnNum = newTxnNum;
                    item.PostWSCode = ws.WSCode;
                    item.PostEmpyName = empy.EmpyName;
                    item.PostEmpyCode = empy.EmpyCode;
                    item.StartDate = now;
                    //item.EndDate = data.EndDate;
                    item.PostType = TblMWTxnPostHeader.POSTTYPE_ENUM_Nomarl;
                    item.TotalCrateQty = 1;
                    item.TotalSubWeight = inv.InvWeight;
                    item.TotalTxnWeight = txnWeight;
                    item.Status = TblMWTxnPostHeader.STATUS_ENUM_Process;

                    int updCount = 0;
                    if (!TblMWTxnPostHeaderCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                    header = item;
                }
                #endregion
            }
            else
            {
                #region valid txn header
                {
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                    if (!TblMWTxnPostHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                    {
                        return false;
                    }
                    if (header == null)
                    {
                        errMsg = LngRes.MSG_Valid_NoTxnHeader;
                        return false;
                    }
                }
                #endregion

                #region updateTxnHeader
                {
                    SqlUpdateColumn suc = new SqlUpdateColumn();
                    suc.Add(TblMWTxnPostHeader.getTotalCrateQtyColumn(), header.TotalCrateQty + 1);
                    suc.Add(TblMWTxnPostHeader.getTotalSubWeightColumn(), header.TotalSubWeight + inv.InvWeight);
                    suc.Add(TblMWTxnPostHeader.getTotalTxnWeightColumn(), header.TotalTxnWeight + txnWeight);

                    SqlWhere sw = new SqlWhere();
                    sw.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

                    int updCount = 0;
                    if (!TblMWTxnPostHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                    {
                        return false;
                    }

                }
                #endregion
            }

            #region add txndetail
            {
                TblMWTxnDetail detail = new TblMWTxnDetail();
                detail.TxnDetailId = dtlNextId;
                detail.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Post;
                detail.TxnNum = header.TxnNum;
                detail.WSCode = ws.WSCode;
                detail.EmpyName = empy.EmpyName;
                detail.EmpyCode = empy.EmpyCode;
                detail.CrateCode = inv.CrateCode;
                detail.Vendor = inv.Vendor;
                detail.VendorCode = inv.VendorCode;
                detail.Waste = inv.Waste;
                detail.WasteCode = inv.WasteCode;
                detail.SubWeight = inv.InvWeight;
                detail.TxnWeight = txnWeight;
                detail.EntryDate = now;
                detail.InvRecordId = inv.InvRecordId;
                //detail.InvAuthId = inv.InvAuthId;
                detail.Status = TblMWTxnDetail.STATUS_ENUM_Complete;

                int updCount = 0;
                if (!TblMWTxnDetailCtrl.Insert(dcf, detail, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region inventory
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInventory.getPostWeightColumn(), txnWeight);
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Posting);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inv.InvRecordId);
                
                int updCount = 0;
                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region inventory track
            {
                TblMWInventoryTrack item = new TblMWInventoryTrack();
                item.InvTrackRecordId = invTrackNextId;
                item.InvRecordId = inv.InvRecordId;
                item.TxnNum = header.TxnNum;
                item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Post;//detail.TxnType;
                item.TxnDetailId = dtlNextId;
                item.CrateCode = inv.CrateCode;
                item.DepotCode = inv.DepotCode;
                item.Vendor = inv.Vendor;
                item.VendorCode = inv.VendorCode;
                item.Waste = inv.Waste;
                item.WasteCode = inv.WasteCode;
                item.SubWeight = inv.InvWeight;
                item.TxnWeight = txnWeight;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.EntryDate = now;
                item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
                //item.InvAuthId = detail.InvAuthId;

                int updCount = 0;
                if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = dtlNextId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubComplete;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Post;
                item.InvRecordId = inv.InvRecordId;

                int updCount = 0;
                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region workflow 2
        public static bool ConfirmInventoryPostToAuthorizeNew(int invRecordId,  decimal txnWeight, string wsCode, string empyCode,
            ref int reInvAuthId,
            ref string newTxnNum,
            ref string errMsg)
        {
            return ConfirmInventoryPostToAuthorize(invRecordId, null, txnWeight, wsCode, empyCode, ref reInvAuthId, ref newTxnNum, ref errMsg);
        }

        public static bool ConfirmInventoryPostToAuthorizeEdit(int invRecordId, string txnNum, decimal txnWeight, string wsCode, string empyCode,
            ref int reInvAuthId,
            ref string errMsg)
        {
            string newTxnNum = null;
            return ConfirmInventoryPostToAuthorize(invRecordId,txnNum,txnWeight,wsCode,empyCode,ref reInvAuthId,ref newTxnNum,ref errMsg);
        }

        private static bool ConfirmInventoryPostToAuthorize(int invRecordId, string txnNum, decimal txnWeight, string wsCode, string empyCode, 
            ref int reInvAuthId, 
            ref string newTxnNum,
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWInventory inv = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
                if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
                {
                    return false;
                }
                if (inv == null)
                {
                    errMsg = LngRes.MSG_Valid_NoInventory;
                    return false;
                }
            }
            #endregion

            dcf.BeginTrans();

            #region add data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;
           
            int txnLogNextId = 0;
            int invAuthId = 0;
            int dtlNextId = 0;
            #region next id
            bool validNextId = true;
            invAuthId = MWNextIdMng.GetInvAuthorizeNextId();
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();
            dtlNextId = MWNextIdMng.GetTxnDetailNextId();

            validNextId = txnLogNextId != 0 && validNextId;
            validNextId = invAuthId != 0 && validNextId;
            validNextId = dtlNextId != 0 && validNextId;
            if (!validNextId)
            {
                errMsg = MWNextIdMng.NextIdErrMsg;
                return false;
            }
            #endregion

            TblMWTxnPostHeader header = null;
            if (string.IsNullOrEmpty(txnNum))
            {
                #region newTxnHeader
                {
                    newTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
                    if (string.IsNullOrEmpty(newTxnNum))
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "ConfirmInventoryToAuthorize", MWNextIdMng.NextIdErrMsg);
                        return false;
                    }

                    int headerNextId = MWNextIdMng.GetTxnPostHeaderNextId();
                    if (headerNextId == 0)
                    {
                        ErrorMng.GetDBError(ClassName, "ConfirmInventoryToAuthorize", MWNextIdMng.NextIdErrMsg);
                        return false;
                    }

                    TblMWTxnPostHeader item = new TblMWTxnPostHeader();
                    item.PostHeaderId = headerNextId;
                    item.TxnNum = newTxnNum;
                    item.PostWSCode = ws.WSCode;
                    item.PostEmpyName = empy.EmpyName;
                    item.PostEmpyCode = empy.EmpyCode;
                    item.StartDate = now;
                    //item.EndDate = data.EndDate;
                    item.PostType = TblMWTxnPostHeader.POSTTYPE_ENUM_Nomarl;
                    item.TotalCrateQty = 1;
                    item.TotalSubWeight = inv.InvWeight;
                    item.TotalTxnWeight = txnWeight;
                    item.Status = TblMWTxnPostHeader.STATUS_ENUM_Process;

                    if (!TblMWTxnPostHeaderCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                    header = item;
                }
                #endregion
            }
            else
            {
                #region valid txnheader
                {
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                    if (!TblMWTxnPostHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                    {
                        return false;
                    }
                    if (header == null)
                    {
                        errMsg = LngRes.MSG_Valid_NoTxnHeader;
                        return false;
                    }
                }
                #endregion

                #region txnheader data
                {
                    SqlUpdateColumn suc = new SqlUpdateColumn();
                    suc.Add(TblMWTxnPostHeader.getStatusColumn(), TblMWTxnPostHeader.STATUS_ENUM_Authorize);
                    suc.Add(TblMWTxnPostHeader.getTotalCrateQtyColumn(), header.TotalCrateQty + 1);
                    suc.Add(TblMWTxnPostHeader.getTotalSubWeightColumn(), header.TotalSubWeight + inv.InvWeight);
                    suc.Add(TblMWTxnPostHeader.getTotalTxnWeightColumn(), header.TotalTxnWeight + txnWeight);

                    SqlWhere sw = new SqlWhere();
                    sw.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                    if (!TblMWTxnPostHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                    {
                        return false;
                    }

                }
                #endregion
            }

            #region add authorize data
            {
                TblMWInvAuthorize item = new TblMWInvAuthorize();
                item.InvAuthId = invAuthId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = dtlNextId;
                item.EmpyCode = empy.EmpyCode;
                item.EmpyName = empy.EmpyName;
                item.WSCode = ws.WSCode;
                //item.AuthEmpyCode = detail.AuthEmpyCode;
                //item.AuthEmpyName = detail.AuthEmpyName;
                //item.Remark = detail.Remark;
                item.SubWeight = inv.InvWeight;
                item.TxnWeight = txnWeight;
                item.DiffWeight = item.SubWeight - txnWeight;
                item.EntryDate = now;
                //item.CompDate = detail.CompDate;
                item.Status = TblMWInvAuthorize.STATUS_ENUM_Precess;

                if (!TblMWInvAuthorizeCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txndetail
            {
                TblMWTxnDetail detail = new TblMWTxnDetail();
                detail.TxnDetailId = dtlNextId;
                detail.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Post;
                detail.TxnNum = header.TxnNum;
                detail.WSCode = ws.WSCode;
                detail.EmpyName = empy.EmpyName;
                detail.EmpyCode = empy.EmpyCode;
                detail.CrateCode = inv.CrateCode;
                detail.Vendor = inv.Vendor;
                detail.VendorCode = inv.VendorCode;
                detail.Waste = inv.Waste;
                detail.WasteCode = inv.WasteCode;
                detail.SubWeight = inv.InvWeight;
                detail.TxnWeight = txnWeight;
                detail.EntryDate = now;
                detail.InvRecordId = inv.InvRecordId;
                detail.InvAuthId = invAuthId;
                detail.Status = TblMWTxnDetail.STATUS_ENUM_Authorize;
                
                if (!TblMWTxnDetailCtrl.Insert(dcf, detail, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update inventory
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInventory.getPostWeightColumn(), txnWeight);
                suc.Add(TblMWInventory.getStatusColumn(),TblMWInventory.STATUS_ENUM_Posting);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inv.InvRecordId);
               
                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = dtlNextId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubAuthorize;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Post;
                item.InvRecordId = inv.InvRecordId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            reInvAuthId = invAuthId;

            return true;
        }

        public static bool AuthorizeCrateToPost(int invRecordId, string txnNum, string wsCode, string empyCode, ref string errMsg)
        {

            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWInventory inv = null;
            TblMWTxnPostHeader header = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            TblMWTxnDetail detail = null;
            int curTxnPresseAuthCount = 0;
            #region valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                if (!GetInventoryTxnDetail(invRecordId, txnNum, ref detail, ref errMsg))
                {
                    return false;
                }
                if (detail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoTxnDetail;
                    return false;
                }
                if (detail.Status != TblMWTxnDetail.STATUS_ENUM_Wait)
                {
                    errMsg = LngRes.MSG_Valid_TxnUnAuthorizeWait;
                    return false;
                }
            }
            {
                List<TblMWInvAuthorize> itemList = null;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInvAuthorize.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInvAuthorize.STATUS_ENUM_Precess);
                sqm.Condition.Where.AddCompareValue(TblMWInvAuthorize.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                if (!TblMWInvAuthorizeCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
                {
                    return false;
                }
                curTxnPresseAuthCount = itemList.Count;
                itemList = itemList.Where(x => x.TxnDetailId == detail.TxnDetailId).ToList();

                TblMWInvAuthorize invAuth = null;
                if (itemList.Count != 0)
                {
                    invAuth = itemList[0];
                }
                if (invAuth != null)
                {
                    errMsg = LngRes.MSG_Valid_TxnInAuthorize; 
                    return false;
                }
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                if (!TblMWTxnPostHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                {
                    return false;
                }
                if (header == null)
                {
                    errMsg = LngRes.MSG_Valid_NoTxnHeader;
                    return false;
                }
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
                if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
                {
                    return false;
                }
                if (inv == null)
                {
                    errMsg = LngRes.MSG_Valid_NoInventory;
                    return false;
                }
            }
            
            #endregion

            dcf.BeginTrans();

            #region update data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            int txnLogNextId = 0;
            int invTrackNextId = 0;
            #region next id
            bool validNextId = true;
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();
            invTrackNextId = MWNextIdMng.GetInventoryTrackNextId();

            validNextId = txnLogNextId != 0 && validNextId;
            validNextId = invTrackNextId != 0 && validNextId;
            if (!validNextId)
            {
                errMsg = MWNextIdMng.NextIdErrMsg;
                return false;
            }
            #endregion

            #region update current txn header to process if this txn detail all Complete authoize
            if (curTxnPresseAuthCount == 0)
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnPostHeader.getStatusColumn(), TblMWTxnPostHeader.STATUS_ENUM_Process);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnNum);

                if (!TblMWTxnPostHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update txndetail
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDetail.getStatusColumn(), TblMWTxnDetail.STATUS_ENUM_Complete);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnDetailId);
                if (!TblMWTxnDetailCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region _del inventory
            //{
            //    SqlUpdateColumn suc = new SqlUpdateColumn();
            //    suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Posted);
            //    SqlWhere sw = new SqlWhere();
            //    sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inv.InvRecordId);

            //    if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            //    {
            //        return false;
            //    }
            //}
            #endregion

            #region inventory track
            {
                TblMWInventoryTrack item = new TblMWInventoryTrack();
                item.InvTrackRecordId = invTrackNextId;
                item.InvRecordId = inv.InvRecordId;
                item.TxnNum = header.TxnNum;
                item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Post;
                item.TxnDetailId = detail.TxnDetailId;
                item.CrateCode = inv.CrateCode;
                item.DepotCode = inv.DepotCode;
                item.Vendor = inv.Vendor;
                item.VendorCode = inv.VendorCode;
                item.Waste = inv.Waste;
                item.WasteCode = inv.WasteCode;
                item.SubWeight = inv.InvWeight;
                item.TxnWeight = detail.TxnWeight;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.EntryDate = now;
                item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
                item.InvAuthId = detail.InvAuthId;

                if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_AuthorizeComplete;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Post;
                item.InvRecordId = inv.InvRecordId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion
            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }
        #endregion

        public static bool EndConfirmPostTxn(string txnNum,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            List<TblMWTxnDetail> detailList = null;
            #region check txn has been complete all txndetail
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
            sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals,
                TblMWTxnDetail.STATUS_ENUM_Complete);

            if (!TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref detailList, ref errMsg))
            {
                return false;
            }
            if (detailList.Count > 0)
            {
                errMsg = LngRes.MSG_Valid_ExistUnCompleteTxnDetail;
                return false;
            }

            if (!GetDetailList(txnNum, ref detailList, ref errMsg))
            {
                return false;
            }
            #endregion

            dcf.BeginTrans();
            #region update data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            #region update txn data
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();

                suc.Add(TblMWTxnPostHeader.getStatusColumn(), TblMWTxnPostHeader.STATUS_ENUM_Complete);
                suc.Add(TblMWTxnPostHeader.getEndDateColumn(), now);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);


                if (!TblMWTxnPostHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
                //if (updCount == 0)
                //{
                //    errMsg = LngRes.MSG_Valid_NoDataUpdate;
                //    return false;
                //}
            }
            #endregion

            #region update inventory to end
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Posted);

                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                foreach (TblMWTxnDetail detail in detailList)
                {
                    sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.InvRecordId);
                }
                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }

        #endregion

        #endregion

        #region destroy txn list

        #region get data
        public static bool GetGetRecoverToDestroyTxnCount(string wscode, ref int count, ref string errMsg)
        {

            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            {
                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                sw.AddCompareValue(VewTxnHeaderWithCarDispatch.getRecoWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wscode);
                sw.AddCompareValue(VewTxnHeaderWithCarDispatch.getRecoWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, string.Empty);
                sqm.Condition.Where.AddWhere(sw);
            }
            sqm.Condition.Where.AddCompareValue(VewTxnHeaderWithCarDispatch.getOperateTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals,
                    VewTxnHeaderWithCarDispatch.OPERATETYPE_ENUM_ToDestroy);
            sqm.Condition.Where.AddCompareValue(VewTxnHeaderWithCarDispatch.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals,
                   VewTxnHeaderWithCarDispatch.STATUS_ENUM_Complete);

            sqm.Condition.OrderBy.Add(VewTxnHeaderWithCarDispatch.getInDateColumn(), SqlCommonFn.SqlOrderByType.ASC);

            sqm.QueryColumn.AddCount(VewTxnHeaderWithCarDispatch.getRecoHeaderIdColumn());

            VewTxnHeaderWithCarDispatch item = null;
            if (!VewTxnHeaderWithCarDispatchCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
            {
                return false;
            }

            if (item == null)
            {
                count = 0;
                return true;
            }
            count = item.RecoHeaderId;

            //if (!VewTxnHeaderWithCarDispatchCtrl.QueryMore(dcf, sqm, ref header, ref errMsg))
            //{
            //    header = new List<VewTxnHeaderWithCarDispatch>();
            //    return false;
            //}

            return true;
        }

        public static bool GetRecoverToDestroyTxnList(string wscode, ref List<VewTxnHeaderWithCarDispatch> header, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            {
                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                sw.AddCompareValue(VewTxnHeaderWithCarDispatch.getRecoWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wscode);
                sw.AddCompareValue(VewTxnHeaderWithCarDispatch.getRecoWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, string.Empty);
                sqm.Condition.Where.AddWhere(sw);
            }
            sqm.Condition.Where.AddCompareValue(VewTxnHeaderWithCarDispatch.getOperateTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals,
                    VewTxnHeaderWithCarDispatch.OPERATETYPE_ENUM_ToDestroy);
            sqm.Condition.Where.AddCompareValue(VewTxnHeaderWithCarDispatch.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals,
                   VewTxnHeaderWithCarDispatch.STATUS_ENUM_Complete);

            sqm.Condition.OrderBy.Add(VewTxnHeaderWithCarDispatch.getInDateColumn(), SqlCommonFn.SqlOrderByType.ASC);

            if (!VewTxnHeaderWithCarDispatchCtrl.QueryMore(dcf, sqm, ref header, ref errMsg))
            {
                header = new List<VewTxnHeaderWithCarDispatch>();
                return false;
            }

            return true;
        }

        public static bool GetDestroyTxnHeaderList(string wscode, ref List<TblMWTxnDestroyHeader> headerList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWTxnDestroyHeader.getDestWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wscode);
            sqm.Condition.Where.AddCompareValue(TblMWTxnDestroyHeader.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWTxnDestroyHeader.STATUS_ENUM_Complete);

            if (!TblMWTxnDestroyHeaderCtrl.QueryMore(dcf, sqm, ref headerList, ref errMsg))
            {
                return false;
            }

            return true;

        }

        public static bool GetDestroyInventory(string crateCode,ref TblMWInventory inv,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWInventory.getCrateCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, crateCode);
            SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
            sw.AddCompareValue(TblMWInventory.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInventory.STATUS_ENUM_Posted);
            sw.AddCompareValue(TblMWInventory.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals,TblMWInventory.STATUS_ENUM_Recovered);
            sqm.Condition.Where.AddWhere(sw);

            if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
            {
                return false;
            }

            return true;
        }
       
        #endregion

        #region destroy operate
        #region workflow 1 recover to destroy

        public static bool BeginConfirmRecoverToDestroy(string recoverTxnNum,string wsCode,string empyCode,ref string newDestroyTxnNum,ref string errMsg)
        {

            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            List<TblMWTxnDetail> recoverDetailList = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, recoverTxnNum);

                if (!TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref recoverDetailList, ref errMsg))
                {
                    return false;
                }

                if (recoverDetailList.Count == 0)
                {
                    errMsg = LngRes.MSG_Valid_DetailIsEmpty;
                    return false;
                }
            }
            #endregion

            dcf.BeginTrans();
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            #region add data

            int invRecordNextId = 0;
            int invTrackNextId = 0;
            int txnLogNextId = 0;

            string destroyTxnNum = "";
            int destroyTxnHeaderNextId = 0;
            int destroyTxnDetailNextId = 0;
            #region get next id
            int detailCount = recoverDetailList.Count;
            invRecordNextId = MWNextIdMng.GetInventoryNextId(detailCount);
            invTrackNextId = MWNextIdMng.GetInventoryTrackNextId(detailCount);
            txnLogNextId = MWNextIdMng.GetTxnLogNextId(detailCount);

            destroyTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
            destroyTxnHeaderNextId = MWNextIdMng.GetTxnDestroyHeaderNextId();
            destroyTxnDetailNextId = MWNextIdMng.GetTxnDetailNextId(detailCount);

            bool validNextId = true;
            validNextId = invRecordNextId != 0 && validNextId;
            validNextId = invTrackNextId != 0 && validNextId;
            validNextId = txnLogNextId != 0 && validNextId;

            validNextId = !string.IsNullOrEmpty(destroyTxnNum) && validNextId;
            validNextId = destroyTxnHeaderNextId != 0 && validNextId;
            validNextId = destroyTxnDetailNextId != 0 && validNextId;

            if (!validNextId)
            {
                errMsg = MWNextIdMng.NextIdErrMsg;
                return false;
            }
            #endregion

            //auto recover to inventory and post to destroy
            decimal totalSubWeight = 0;
            int totalQty = 0;
            #region auto recover to inventory & create new destroy txn

            foreach (TblMWTxnDetail data in recoverDetailList)
            {

                TblMWTxnDetail recoverDetail = data;
                totalSubWeight += data.SubWeight;
                totalQty++;

                #region update recover txn detail
                {
                    SqlUpdateColumn suc = new SqlUpdateColumn();
                    suc.Add(TblMWTxnDetail.getWSCodeColumn(), ws.WSCode);
                    suc.Add(TblMWTxnDetail.getEmpyNameColumn(), empy.EmpyName);
                    suc.Add(TblMWTxnDetail.getEmpyCodeColumn(), empy.EmpyCode);
                    suc.Add(TblMWTxnDetail.getTxnWeightColumn(), recoverDetail.SubWeight);

                    suc.Add(TblMWTxnDetail.getInvRecordIdColumn(), invRecordNextId);
                    suc.Add(TblMWTxnDetail.getStatusColumn(), TblMWTxnDetail.STATUS_ENUM_Complete);

                    SqlWhere sw = new SqlWhere();
                    sw.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, recoverDetail.TxnDetailId);

                    if (!TblMWTxnDetailCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
                #endregion

                #region add new destroy txn detail
                {
                    TblMWTxnDetail destroyDetail = data;
                    destroyDetail.TxnDetailId = destroyTxnDetailNextId;
                    destroyDetail.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Destroy;
                    destroyDetail.TxnNum = destroyTxnNum;
                    destroyDetail.WSCode = ws.WSCode;
                    destroyDetail.EmpyName = empy.EmpyName;
                    destroyDetail.EmpyCode = empy.EmpyCode;
                    //destroyDetail.CrateCode = inv.CrateCode;
                    //destroyDetail.Vendor = inv.Vendor;
                    //destroyDetail.VendorCode = inv.VendorCode;
                    //destroyDetail.Waste = inv.Waste;
                    //destroyDetail.WasteCode = inv.WasteCode;
                    //destroyDetail.SubWeight = inv.SubWeight;
                    destroyDetail.TxnWeight = 0;
                    destroyDetail.EntryDate = now;
                    destroyDetail.InvRecordId = invRecordNextId;
                    //destroyDetail.InvAuthId = inv.InvAuthId;
                    destroyDetail.Status = TblMWTxnDetail.STATUS_ENUM_Process;

                    if (!TblMWTxnDetailCtrl.Insert(dcf, destroyDetail, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
                #endregion

                #region auto add recover inventory to destroy
                {
                    TblMWInventory item = new TblMWInventory();
                    item.InvRecordId = invRecordNextId;
                    item.CrateCode = recoverDetail.CrateCode;
                    item.DepotCode = ""; ;
                    item.Vendor = recoverDetail.Vendor;
                    item.VendorCode = recoverDetail.VendorCode;
                    item.Waste = recoverDetail.Waste;
                    item.WasteCode = recoverDetail.WasteCode;
                    item.RecoWeight = recoverDetail.SubWeight;
                    item.InvWeight = recoverDetail.SubWeight;
                    item.PostWeight = recoverDetail.SubWeight;
                    //item.DestWeight = detail.DestWeight;
                    item.EntryDate = now;
                    item.Status = TblMWInventory.STATUS_ENUM_Destroying;
                    //item.DailyClose = detail.DailyClose;


                    if (!TblMWInventoryCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
                #endregion

                #region auto add recover inventory track
                {
                    TblMWInventoryTrack item = new TblMWInventoryTrack();
                    item.InvTrackRecordId = invTrackNextId;

                    item.InvRecordId = invRecordNextId;

                    item.TxnNum = recoverDetail.TxnNum;
                    item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Recover;//detail.TxnType;
                    item.TxnDetailId = recoverDetail.TxnDetailId;
                    item.CrateCode = recoverDetail.CrateCode;
                    item.DepotCode = "";
                    item.Vendor = recoverDetail.Vendor;
                    item.VendorCode = recoverDetail.VendorCode;
                    item.Waste = recoverDetail.Waste;
                    item.WasteCode = recoverDetail.WasteCode;
                    item.SubWeight = recoverDetail.SubWeight;
                    item.TxnWeight = recoverDetail.SubWeight;
                    item.WSCode = ws.WSCode;
                    item.EmpyName = empy.EmpyName;
                    item.EmpyCode = empy.EmpyCode;
                    item.EntryDate = now;
                    item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
                    //item.InvAuthId = detail.InvAuthId;

                    if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
                #endregion

                #region auto add recover txn log
                {
                    TblMWTxnLog item = new TblMWTxnLog();
                    item.TxnLogId = txnLogNextId;

                    item.TxnNum = recoverDetail.TxnNum;
                    item.TxnDetailId = recoverDetail.TxnDetailId;
                    item.WSCode = ws.WSCode;
                    item.EmpyName = empy.EmpyName;
                    item.EmpyCode = empy.EmpyCode;
                    item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubComplete;
                    item.OptDate = now;
                    item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Recover;
                    item.InvRecordId = invRecordNextId;

                    if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
                #endregion
                invRecordNextId++;
                invTrackNextId++;
                txnLogNextId++;
                destroyTxnDetailNextId++;
            }

            #region add new destroy txn header
            {
                TblMWTxnDestroyHeader item = new TblMWTxnDestroyHeader();
                item.DestHeaderId = destroyTxnHeaderNextId;
                item.TxnNum = destroyTxnNum;
                item.DestType = TblMWTxnDestroyHeader.DESTTYPE_ENUM_RecoverDestroy;
                item.StartDate = now;
                //item.EndDate = inv.EndDate;
                item.DestWSCode = ws.WSCode;
                item.DestEmpyName = empy.EmpyName;
                item.DestEmpyCode = empy.EmpyCode;
                item.TotalCrateQty = totalQty;
                item.TotalSubWeight = totalSubWeight;
                item.TotalTxnWeight = 0;
                item.Status = TblMWTxnDestroyHeader.STATUS_ENUM_Process;

                if (!TblMWTxnDestroyHeaderCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update recover txn header
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), TblMWTxnRecoverHeader.STATUS_ENUM_Complete);
                suc.Add(TblMWTxnRecoverHeader.getTotalTxnWeightColumn(), totalSubWeight);
                suc.Add(TblMWTxnRecoverHeader.getStartDateColumn(), now);
                suc.Add(TblMWTxnRecoverHeader.getEndDateColumn(), now);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, recoverTxnNum);
                if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion


            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            newDestroyTxnNum = destroyTxnNum;
            return true;
        }

        public static bool ConfirmRecoverCrateToDestroy(int txnDetailId, decimal txnWeight,
           string wsCode, string empyCode,
           ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnDetail detail = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            TblMWTxnDestroyHeader header = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            if (!GetTxnDetail(txnDetailId, ref detail, ref errMsg))
            {
                return false;
            }
            if (detail == null)
            {
                errMsg = LngRes.MSG_Valid_NoTxnDetail;
                return false;
            }
            if (detail.Status != TblMWTxnDetail.STATUS_ENUM_Process)
            {
                errMsg = LngRes.MSG_Valid_TxnDetailNotProcess;
                return false;
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnNum);

                if (!TblMWTxnDestroyHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                {
                    return false;
                }
                if (header == null)
                {
                    errMsg = LngRes.MSG_Valid_NoDestTxnHeader;
                    return false;
                }
            }
           
            #endregion

            #region valid Biz
            if (!ValidCrateWeight(detail.SubWeight, txnWeight,  ValidWeightType.Destroy, ref errMsg))
            {
                return false;
            }
            #endregion

            dcf.BeginTrans();
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            #region add data

            int txnLogNextId = 0;
            int invTrackNextId = 0;
            #region nextId
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();
            invTrackNextId = MWNextIdMng.GetInventoryTrackNextId();

            bool valid = true;
            valid = txnLogNextId != 0 && valid;
            valid = invTrackNextId != 0 && valid;

            if (!valid)
            {
                ErrorMng.GetDBError(ClassName, "ConfirmExistCrateToDestroy", MWNextIdMng.NextIdErrMsg);
                return false;
            }
            #endregion

            #region update header
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDestroyHeader.getTotalTxnWeightColumn(), header.TotalTxnWeight + txnWeight);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, header.TxnNum);
                if (!TblMWTxnDestroyHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update detail
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDetail.getTxnWeightColumn(), txnWeight);
                suc.Add(TblMWTxnDetail.getStatusColumn(), TblMWTxnDetail.STATUS_ENUM_Complete);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnDetailId);
                if (!TblMWTxnDetailCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update inventory
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInventory.getDestWeightColumn(), txnWeight);
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Destroying);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.InvRecordId);
                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region  add inventory track
            {
                TblMWInventoryTrack item = new TblMWInventoryTrack();
                item.InvTrackRecordId = invTrackNextId;
                item.InvRecordId = detail.InvRecordId;
                item.TxnNum = detail.TxnNum;
                item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Destroy;//detail.TxnType;
                item.TxnDetailId = detail.TxnDetailId;
                item.CrateCode = detail.CrateCode;
                item.DepotCode = "";
                item.Vendor = detail.Vendor;
                item.VendorCode = detail.VendorCode;
                item.Waste = detail.Waste;
                item.WasteCode = detail.WasteCode;
                item.SubWeight = detail.SubWeight;
                item.TxnWeight = txnWeight;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.EntryDate = now;
                item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
                //item.InvAuthId = detail.InvAuthId;

                if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = detail.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubComplete;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Destroy;
                item.InvRecordId = detail.InvRecordId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool ConfirmDestroyRecoverCrateToAuthorize(int txnDetailId,  decimal txnWeight,
            string wsCode, string empyCode,
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnDetail detail = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            TblMWTxnDestroyHeader header = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            if (!GetTxnDetail(txnDetailId, ref detail, ref errMsg))
            {
                return false;
            }
            if (detail == null)
            {
                errMsg = LngRes.MSG_Valid_NoTxnDetail;
                return false;
            }
            if (detail.Status != TblMWTxnDetail.STATUS_ENUM_Process)
            {
                errMsg = LngRes.MSG_Valid_TxnDetailNotProcess;
                return false;
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnNum);

                if (!TblMWTxnDestroyHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                {
                    return false;
                }
                if (header == null)
                {
                    errMsg = LngRes.MSG_Valid_NoDestTxnHeader;
                    return false;
                }
            }
            #endregion

            dcf.BeginTrans();
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            #region add data

            int txnLogNextId = 0;
            int invAuthId = 0;
            #region nextId
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();
            invAuthId = MWNextIdMng.GetInvAuthorizeNextId();
            bool valid = true;
            valid = txnLogNextId != 0 && valid;
            valid = invAuthId != 0 && valid;

            if (!valid)
            {
                ErrorMng.GetDBError(ClassName, "ConfirmDestroyExistCrateToAuthorize", MWNextIdMng.NextIdErrMsg);
                return false;
            }
            #endregion

            #region add authorize data
            {
                TblMWInvAuthorize item = new TblMWInvAuthorize();
                item.InvAuthId = invAuthId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.EmpyCode = empy.EmpyCode;
                item.EmpyName = empy.EmpyName;
                item.WSCode = ws.WSCode;
                //item.AuthEmpyCode = detail.AuthEmpyCode;
                //item.AuthEmpyName = detail.AuthEmpyName;
                //item.Remark = detail.Remark;
                item.SubWeight = detail.SubWeight;
                item.TxnWeight = txnWeight;
                item.DiffWeight = item.SubWeight - txnWeight;
                item.EntryDate = now;
                //item.CompDate = detail.CompDate;
                item.Status = TblMWInvAuthorize.STATUS_ENUM_Precess;

                if (!TblMWInvAuthorizeCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update header
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDestroyHeader.getStatusColumn(), TblMWTxnDestroyHeader.STATUS_ENUM_Authorize);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, header.TxnNum);
                if (!TblMWTxnDestroyHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update detail
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDetail.getTxnWeightColumn(), txnWeight);
                suc.Add(TblMWTxnDetail.getInvAuthIdColumn(), invAuthId);
                suc.Add(TblMWTxnDetail.getStatusColumn(), TblMWTxnDetail.STATUS_ENUM_Authorize);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnDetailId);
                if (!TblMWTxnDetailCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update inventory
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInventory.getDestWeightColumn(), txnWeight);
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Destroying);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.InvRecordId);
                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = detail.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubAuthorize;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Destroy;
                item.InvRecordId = detail.InvRecordId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool ConfirmAuthorizeRecoverCrateToDestroy(int invRecordId, string txnNum, string wsCode, string empyCode, ref string errMsg)
        {
            return ConfirmAuthorizeCrateToDestroy(invRecordId, txnNum, wsCode, empyCode, ref errMsg);
        }
        
        #endregion

        #region workflow 2 destroy crate

        public static bool ConfirmCrateToDestroyNew(int invRecordId,decimal txnWeight, string wsCode, string empyCode,ref string newTxnNum, ref string errMsg)
        {
            return ConfirmCrateToDestroy(invRecordId, null, txnWeight, wsCode, empyCode, ref newTxnNum, ref errMsg);
        }
        public static bool ConfirmCrateToDestroyEdit(int invRecordId, string txnNum, decimal txnWeight, string wsCode, string empyCode, ref string errMsg)
        {
            string defineNewTxnNum = "";
            return ConfirmCrateToDestroy(invRecordId, txnNum, txnWeight, wsCode, empyCode, ref defineNewTxnNum, ref errMsg);
        }
        private static bool ConfirmCrateToDestroy(int invRecordId, string txnNum, decimal txnWeight, string wsCode, string empyCode, ref string newTxnNum, ref string errMsg)
        {

            DataCtrlInfo dcf = new DataCtrlInfo();
            TblMWInventory inv = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
                if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
                {
                    return false;
                }
                if (inv == null)
                {
                    errMsg = LngRes.MSG_Valid_NoInventory;
                    return false;
                }
            }
            #endregion

            decimal subTxnWeight = 0;
            bool invHasPost = false;
            #region valid Biz
            //no post to destroy
            if (inv.Status == TblMWInventory.STATUS_ENUM_Recovered)
            {
                subTxnWeight = inv.InvWeight;
            }
            //post to destroy
            else if (inv.Status == TblMWInventory.STATUS_ENUM_Posted)
            {
                subTxnWeight = inv.PostWeight;
                invHasPost = true;
            }
            else
            {
                errMsg = LngRes.MSG_Valid_UnvalidInvDataToDestroy;
                return false;
            }
            if (!ValidCrateWeight(subTxnWeight, txnWeight, ValidWeightType.Destroy, ref errMsg))
            {
                return false;
            }
            #endregion

            dcf.BeginTrans();

            #region add data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

           
            int dtlNextId = 0;
            int invTrackNextId = 0;
            int txnLogNextId = 0;
            #region nextId
            dtlNextId = MWNextIdMng.GetTxnDetailNextId();
            invTrackNextId = MWNextIdMng.GetInventoryTrackNextId();
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();

            bool valid = true;
            valid = dtlNextId != 0 && valid;
            valid = invTrackNextId != 0 && valid;
            valid = txnLogNextId != 0 && valid;
            if (!valid)
            {
                ErrorMng.GetDBError(ClassName, "ConfirmCrateToDestroy", MWNextIdMng.NextIdErrMsg);
                return false;
            }
            #endregion

            TblMWTxnDestroyHeader header = null;
            if (string.IsNullOrEmpty(txnNum))
            {
                #region newTxnHeader
                {
                    newTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
                    if (string.IsNullOrEmpty(newTxnNum))
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "confirmCrateToDestroy", MWNextIdMng.NextIdErrMsg);
                        return false;
                    }

                    int headerNextId = MWNextIdMng.GetTxnDestroyHeaderNextId();
                    if (headerNextId == 0)
                    {
                        ErrorMng.GetDBError(ClassName, "confirmCrateToDestroy", MWNextIdMng.NextIdErrMsg);
                        return false;
                    }

                    TblMWTxnDestroyHeader item = new TblMWTxnDestroyHeader();
                    item.DestHeaderId = headerNextId;
                    item.TxnNum = newTxnNum;
                    item.DestType = TblMWTxnDestroyHeader.DESTTYPE_ENUM_PostDestroy;
                    item.StartDate = now;
                    //item.EndDate = detail.EndDate;
                    item.DestWSCode = ws.WSCode;
                    item.DestEmpyName = empy.EmpyName;
                    item.DestEmpyCode = empy.EmpyCode;
                    item.TotalCrateQty = 1;
                    item.TotalSubWeight = subTxnWeight;
                    item.TotalTxnWeight = txnWeight;
                    item.Status = TblMWTxnDestroyHeader.STATUS_ENUM_Process;

                    if (!TblMWTxnDestroyHeaderCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                    header = item;
                }
                #endregion
            }
            else 
            {
                #region valid txn header
                {
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                    if (!TblMWTxnDestroyHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                    {
                        return false;
                    }
                    if (header == null)
                    {
                        errMsg = LngRes.MSG_Valid_NoTxnHeader;
                        return false;
                    }
                }
                #endregion

                #region updateTxnHeader
                {
                    SqlUpdateColumn suc = new SqlUpdateColumn();
                    suc.Add(TblMWTxnDestroyHeader.getTotalCrateQtyColumn(), header.TotalCrateQty + 1);
                    suc.Add(TblMWTxnDestroyHeader.getTotalSubWeightColumn(), header.TotalSubWeight + subTxnWeight);
                    suc.Add(TblMWTxnDestroyHeader.getTotalTxnWeightColumn(), header.TotalTxnWeight + txnWeight);

                    SqlWhere sw = new SqlWhere();
                    sw.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

                    if (!TblMWTxnDestroyHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                    {
                        return false;
                    }

                }
                #endregion
            }

            #region add txndetail
            {
                TblMWTxnDetail detail = new TblMWTxnDetail();
                detail.TxnDetailId = dtlNextId;
                detail.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Destroy;
                detail.TxnNum = header.TxnNum;
                detail.WSCode = ws.WSCode;
                detail.EmpyName = empy.EmpyName;
                detail.EmpyCode = empy.EmpyCode;
                detail.CrateCode = inv.CrateCode;
                detail.Vendor = inv.Vendor;
                detail.VendorCode = inv.VendorCode;
                detail.Waste = inv.Waste;
                detail.WasteCode = inv.WasteCode;
                detail.SubWeight = subTxnWeight;
                detail.TxnWeight = txnWeight;
                detail.EntryDate = now;
                detail.InvRecordId = inv.InvRecordId;
                //detail.InvAuthId = inv.InvAuthId;
                detail.Status = TblMWTxnDetail.STATUS_ENUM_Complete;

                if (!TblMWTxnDetailCtrl.Insert(dcf, detail, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region inventory
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                if (!invHasPost)
                {
                    suc.Add(TblMWInventory.getPostWeightColumn(), txnWeight);
                }
                suc.Add(TblMWInventory.getDestWeightColumn(), txnWeight);
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Destroying);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inv.InvRecordId);

                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region inventory track
            {
                TblMWInventoryTrack item = new TblMWInventoryTrack();
                item.InvTrackRecordId = invTrackNextId;
                item.InvRecordId = inv.InvRecordId;
                item.TxnNum = header.TxnNum;
                item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Destroy;
                item.TxnDetailId = dtlNextId;
                item.CrateCode = inv.CrateCode;
                item.DepotCode = inv.DepotCode;
                item.Vendor = inv.Vendor;
                item.VendorCode = inv.VendorCode;
                item.Waste = inv.Waste;
                item.WasteCode = inv.WasteCode;
                item.SubWeight = subTxnWeight;
                item.TxnWeight = txnWeight;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.EntryDate = now;
                item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
                //item.InvAuthId = detail.InvAuthId;

                if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = dtlNextId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubComplete;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Destroy;
                item.InvRecordId = inv.InvRecordId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region workflow 3 Authorize crate

        public static bool ConfirmDestroyToAuthorizeNew(int invRecordId, decimal txnWeight, string wsCode, string empyCode, ref int reInvAuthId, ref string newTxnNum, ref string errMsg)
        {
            return ConfirmDestroyToAuthorize(invRecordId, null, txnWeight, wsCode, empyCode, ref reInvAuthId, ref newTxnNum, ref errMsg);
        }
        public static bool ConfirmDestroyToAuthorizeEdit(int invRecordId, string txnNum, decimal txnWeight, string wsCode, string empyCode, ref int reInvAuthId, ref string errMsg)
        {
            string defineNewTxnNum = "";
            return ConfirmDestroyToAuthorize(invRecordId, txnNum, txnWeight, wsCode, empyCode, ref reInvAuthId, ref defineNewTxnNum, ref errMsg);
        }
        private static bool ConfirmDestroyToAuthorize(int invRecordId, string txnNum, decimal txnWeight, string wsCode, string empyCode, ref int reInvAuthId, ref string newTxnNum, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWInventory inv = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            #region get & valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
                if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
                {
                    return false;
                }
                if (inv == null)
                {
                    errMsg = LngRes.MSG_Valid_NoInventory;
                    return false;
                }
            }
            #endregion

            decimal subTxnWeight = 0;
            bool invHasPost = false;
            #region valid Biz
            //no post to destroy
            if (inv.Status == TblMWInventory.STATUS_ENUM_Recovered)
            {
                subTxnWeight = inv.InvWeight;
                invHasPost = false;
            }
            //post to destroy
            else if (inv.Status == TblMWInventory.STATUS_ENUM_Posted)
            {
                subTxnWeight = inv.PostWeight;
                invHasPost = true;
            }
            else
            {
                errMsg = LngRes.MSG_Valid_UnvalidInvDataToDestroy;
                return false;
            }
            #endregion

            dcf.BeginTrans();

            #region add data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            int txnLogNextId = 0;
            int invAuthId = 0;
            int dtlNextId = 0;
            #region next id
            bool validNextId = true;
            invAuthId = MWNextIdMng.GetInvAuthorizeNextId();
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();
            dtlNextId = MWNextIdMng.GetTxnDetailNextId();

            validNextId = txnLogNextId != 0 && validNextId;
            validNextId = invAuthId != 0 && validNextId;
            validNextId = dtlNextId != 0 && validNextId;
            if (!validNextId)
            {
                errMsg = MWNextIdMng.NextIdErrMsg;
                return false;
            }
            #endregion

            TblMWTxnDestroyHeader header = null;
            if (string.IsNullOrEmpty(txnNum))
            {
                #region newTxnHeader
                {
                    newTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
                    if (string.IsNullOrEmpty(newTxnNum))
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "ConfirmDestroyToAuthorize", MWNextIdMng.NextIdErrMsg);
                        return false;
                    }

                    int headerNextId = MWNextIdMng.GetTxnDestroyHeaderNextId();
                    if (headerNextId == 0)
                    {
                        ErrorMng.GetDBError(ClassName, "ConfirmDestroyToAuthorize", MWNextIdMng.NextIdErrMsg);
                        return false;
                    }

                    TblMWTxnDestroyHeader item = new TblMWTxnDestroyHeader();
                    item.DestHeaderId = headerNextId;
                    item.TxnNum = newTxnNum;
                    item.DestType = TblMWTxnDestroyHeader.DESTTYPE_ENUM_PostDestroy;
                    item.StartDate = now;
                    //item.EndDate = detail.EndDate;
                    item.DestWSCode = ws.WSCode;
                    item.DestEmpyName = empy.EmpyName;
                    item.DestEmpyCode = empy.EmpyCode;
                    item.TotalCrateQty = 1;
                    item.TotalSubWeight = subTxnWeight;
                    item.TotalTxnWeight = txnWeight;
                    item.Status = TblMWTxnDestroyHeader.STATUS_ENUM_Process;

                    if (!TblMWTxnDestroyHeaderCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                    header = item;
                }
                #endregion
            }
            else
            {
                #region valid txn header
                {
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                    if (!TblMWTxnDestroyHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                    {
                        return false;
                    }
                    if (header == null)
                    {
                        errMsg = LngRes.MSG_Valid_NoTxnHeader;
                        return false;
                    }
                }
                #endregion

                #region updateTxnHeader
                {
                    SqlUpdateColumn suc = new SqlUpdateColumn();
                    suc.Add(TblMWTxnDestroyHeader.getTotalCrateQtyColumn(), header.TotalCrateQty + 1);
                    suc.Add(TblMWTxnDestroyHeader.getTotalSubWeightColumn(), header.TotalSubWeight + subTxnWeight);
                    suc.Add(TblMWTxnDestroyHeader.getTotalTxnWeightColumn(), header.TotalTxnWeight + txnWeight);

                    SqlWhere sw = new SqlWhere();
                    sw.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

                    if (!TblMWTxnDestroyHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                    {
                        return false;
                    }

                }
                #endregion
            }

            #region add authorize data
            {
                TblMWInvAuthorize item = new TblMWInvAuthorize();
                item.InvAuthId = invAuthId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = dtlNextId;
                item.EmpyCode = empy.EmpyCode;
                item.EmpyName = empy.EmpyName;
                item.WSCode = ws.WSCode;
                //item.AuthEmpyCode = detail.AuthEmpyCode;
                //item.AuthEmpyName = detail.AuthEmpyName;
                //item.Remark = detail.Remark;
                item.SubWeight = subTxnWeight;
                item.TxnWeight = txnWeight;
                item.DiffWeight = item.SubWeight - txnWeight;
                item.EntryDate = now;
                //item.CompDate = detail.CompDate;
                item.Status = TblMWInvAuthorize.STATUS_ENUM_Precess;

                if (!TblMWInvAuthorizeCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txndetail
            {
                TblMWTxnDetail detail = new TblMWTxnDetail();
                detail.TxnDetailId = dtlNextId;
                detail.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Destroy;
                detail.TxnNum = header.TxnNum;
                detail.WSCode = ws.WSCode;
                detail.EmpyName = empy.EmpyName;
                detail.EmpyCode = empy.EmpyCode;
                detail.CrateCode = inv.CrateCode;
                detail.Vendor = inv.Vendor;
                detail.VendorCode = inv.VendorCode;
                detail.Waste = inv.Waste;
                detail.WasteCode = inv.WasteCode;
                detail.SubWeight = subTxnWeight;
                detail.TxnWeight = txnWeight;
                detail.EntryDate = now;
                detail.InvRecordId = inv.InvRecordId;
                detail.InvAuthId = invAuthId;
                detail.Status = TblMWTxnDetail.STATUS_ENUM_Authorize;

                if (!TblMWTxnDetailCtrl.Insert(dcf, detail, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update inventory
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                if (!invHasPost)
                {
                    suc.Add(TblMWInventory.getPostWeightColumn(), txnWeight);
                }
                suc.Add(TblMWInventory.getDestWeightColumn(), txnWeight);
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Destroying);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inv.InvRecordId);

                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = dtlNextId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubAuthorize;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Destroy;
                item.InvRecordId = inv.InvRecordId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion


            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            reInvAuthId = invAuthId;
            return true;
        }

        public static bool ConfirmAuthorizeCrateToDestroy(int invRecordId, string txnNum,string wsCode, string empyCode,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWInventory inv = null;
            TblMWTxnDestroyHeader header = null;
            TblMWEmploy empy = null;
            TblMWWorkStation ws = null;
            TblMWTxnDetail detail = null;
            int curTxnPresseAuthCount = 0;
            #region valid data
            if (!ValidWSAndEmploy(wsCode, empyCode, ref ws, ref empy, ref errMsg))
            {
                return false;
            }
            {
                if (!GetInventoryTxnDetail(invRecordId, txnNum, ref detail, ref errMsg))
                {
                    return false;
                }
                if (detail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoTxnDetail;
                    return false;
                }
                if (detail.Status != TblMWTxnDetail.STATUS_ENUM_Wait)
                {
                    errMsg = LngRes.MSG_Valid_TxnUnAuthorizeWait;
                    return false;
                }
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
                if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref inv, ref errMsg))
                {
                    return false;
                }
                if (inv == null)
                {
                    errMsg = LngRes.MSG_Valid_NoInventory;
                    return false;
                }
            }
            {
                List<TblMWInvAuthorize> itemList = null;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWInvAuthorize.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWInvAuthorize.STATUS_ENUM_Precess);
                sqm.Condition.Where.AddCompareValue(TblMWInvAuthorize.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                if (!TblMWInvAuthorizeCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
                {
                    return false;
                }
                curTxnPresseAuthCount = itemList.Count;
                itemList = itemList.Where(x => x.TxnDetailId == detail.TxnDetailId).ToList();

                TblMWInvAuthorize invAuth = null;
                if (itemList.Count != 0)
                {
                    invAuth = itemList[0];
                }
                if (invAuth != null)
                {
                    errMsg = LngRes.MSG_Valid_TxnInAuthorize;
                    return false;
                }
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                if (!TblMWTxnDestroyHeaderCtrl.QueryOne(dcf, sqm, ref header, ref errMsg))
                {
                    return false;
                }
                if (header == null)
                {
                    errMsg = LngRes.MSG_Valid_NoTxnHeader;
                    return false;
                }
            }
            
            #endregion

            dcf.BeginTrans();

            #region update data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            int txnLogNextId = 0;
            int invTrackNextId = 0;
            #region next id
            bool validNextId = true;
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();
            invTrackNextId = MWNextIdMng.GetInventoryTrackNextId();

            validNextId = txnLogNextId != 0 && validNextId;
            validNextId = invTrackNextId != 0 && validNextId;
            if (!validNextId)
            {
                errMsg = MWNextIdMng.NextIdErrMsg;
                return false;
            }
            #endregion

            #region update current txn header to process if this txn detail all Complete authoize
            if (curTxnPresseAuthCount == 0)
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDestroyHeader.getStatusColumn(), TblMWTxnDestroyHeader.STATUS_ENUM_Process);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnNum);

                if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update txndetail
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDetail.getStatusColumn(), TblMWTxnDetail.STATUS_ENUM_Complete);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnDetailId);
                if (!TblMWTxnDetailCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region _del update inventory
            //{
            //    SqlUpdateColumn suc = new SqlUpdateColumn();
            //    suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Destroyed);
            //    SqlWhere sw = new SqlWhere();
            //    sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inv.InvRecordId);

            //    if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            //    {
            //        return false;
            //    }
            //}
            #endregion

            #region add inventory track
            {
                TblMWInventoryTrack item = new TblMWInventoryTrack();
                item.InvTrackRecordId = invTrackNextId;
                item.InvRecordId = inv.InvRecordId;
                item.TxnNum = header.TxnNum;
                item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Destroy;
                item.TxnDetailId = detail.TxnDetailId;
                item.CrateCode = inv.CrateCode;
                item.DepotCode = inv.DepotCode;
                item.Vendor = inv.Vendor;
                item.VendorCode = inv.VendorCode;
                item.Waste = inv.Waste;
                item.WasteCode = inv.WasteCode;
                item.SubWeight = inv.DestWeight;
                item.TxnWeight = detail.TxnWeight;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.EntryDate = now;
                item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
                item.InvAuthId = detail.InvAuthId;

                if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = header.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.WSCode = ws.WSCode;
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_AuthorizeComplete;
                item.OptDate = now;
                item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Destroy;
                item.InvRecordId = inv.InvRecordId;

                if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion
            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }

        #endregion

        public static bool EndConfirmDestroyTxn(string txnNum,ref string errMsg)
        {

            DataCtrlInfo dcf = new DataCtrlInfo();

            List<TblMWTxnDetail> detailList = null;
            #region check txn has been complete all txndetail
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals,
                    TblMWTxnDetail.STATUS_ENUM_Complete);

                if (!TblMWTxnDetailCtrl.QueryMore(dcf, sqm, ref detailList, ref errMsg))
                {
                    return false;
                }
                if (detailList.Count > 0)
                {
                    errMsg = LngRes.MSG_Valid_ExistUnCompleteTxnDetail;
                    return false;
                }
            }
            if (!GetDetailList(txnNum, ref detailList, ref errMsg))
            {
                return false;
            }
            #endregion

            dcf.BeginTrans();

            #region update data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;

            #region update txn data
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();

                suc.Add(TblMWTxnDestroyHeader.getStatusColumn(), TblMWTxnDestroyHeader.STATUS_ENUM_Complete);
                suc.Add(TblMWTxnDestroyHeader.getEndDateColumn(), now);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDestroyHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

                if (!TblMWTxnDestroyHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update inventory data
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Destroyed);

                SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                foreach (TblMWTxnDetail detail in detailList)
                {
                    sw.AddCompareValue(TblMWInventory.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.InvRecordId);
                }

                if (!TblMWInventoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #endregion

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }
        #endregion

        #endregion

        #endregion

        public static bool TestUpdate()
        {
            string errMsg = "";
            DataCtrlInfo dcf = new DataCtrlInfo();
            TblMWCarDispatch car = null;

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getCarDisIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, 1);

            if (!TblMWCarDispatchCtrl.QueryOne(dcf, sqm, ref car, ref errMsg))
            {
                return false;
            }
            if (car == null)
            {
                return false;
            }
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCarDispatch.getCarCodeColumn());

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCarDispatch.getCarDisIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, car.CarDisId);
            int updCount = 0;
            if (!TblMWCarDispatchCtrl.Update(dcf,car, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }

            return true;
        }

        class LngRes
        {
            public const string MSG_Valid_UnvalidInvDataToDestroy = "警告！当前货箱没有入库或出库信息。请检查货箱来源！";
            public const string MSG_Valid_CrateIsInvData = "警告！当前货箱为库存数据，没有任何出库销毁记录。请检查货箱来源！";
            public const string MSG_Valid_NoTxnDetail = "没有找到当前ID的货箱交易详情";
            public const string MSG_Valid_TxnComplete = "当前货箱操作已完成";
            public const string MSG_Valid_TxnInAuthorize = "当前货箱正在审核中";
            public const string MSG_Valid_NoEmploy = "没有找到当前编号的员工";
            public const string MSG_Valid_NoWorkstation = "没有当前编号的工作站";
            public const string MSG_Valid_NoTxnHeader = "没有找到当前流水号的计划单";
            public const string MSG_Valid_NoInventory = "没有找到当前的库存信息";
            public const string MSG_Valid_ExistUnCompleteTxnDetail = "计划交易，有未审核完成货箱";
            public const string MSG_Valid_DetailIsEmpty = "当前计划单中货箱数量为0";
            public const string MSG_Valid_TxnDetailNotProcess = "当前货箱状态不能被提交";
            public const string MSG_Valid_NoDestTxnHeader = "没有找到当前流水号的处置计划单";
            public const string MSG_Valid_TxnUnAuthorizeWait = "当前不是审核完成货箱";

            public const string MSG_Valid_NoDataUpdate = "数据没有被跟新，请稍后重试。";
        }
    }

}
