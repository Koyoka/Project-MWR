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
        public static bool GetDetailList(string txnNum,
           ref  List<TblMWTxnDetail> detailList,
           ref string errMsg)
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
                    errMsg = "没有找到当前编号的回收计划单";
                    return false;
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

            TblMWEmploy empy = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);

                if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref empy, ref errMsg))
                {
                    return false;
                }
                if (empy == null)
                {
                    errMsg = "没有当前编号的员工";
                    return false;
                }
            }

            TblMWWorkStation ws = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWWorkStation.getWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wsCode);
                if (!TblMWWorkStationCtrl.QueryOne(dcf, sqm, ref ws, ref errMsg))
                {
                    return false;
                }
                if(ws == null)
                {
                    errMsg = "没有当前编号的工作站";
                    return false;
                }
            }

            TblMWTxnRecoverHeader header = null;
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
            decimal txnWeight, string empyCode, string wscode, 
            string depotCode,
            ref string errMsg)
        {

            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnDetail detail = null;
            TblMWEmploy empy = null;
            #region get & valid data
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnDetailId);

                if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref detail, ref errMsg))
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
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);
                if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref empy, ref errMsg))
                {
                    return false;
                }
                if (empy == null)
                {
                    errMsg = LngRes.MSG_Valid_NoEmploy; //"没有找到当前编号的员工";
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

            #region update current txn
            {
                //TblMWTxnDetail item = new TblMWTxnDetail();
                detail.WSCode = empyCode;
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
                item.Status = TblMWInventory.STATUS_ENUM_Recovered;
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
                item.WSCode = detail.WSCode;
                item.EmpyName = detail.EmpyName;
                item.EmpyCode = detail.EmpyCode;
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
                item.WSCode = detail.WSCode;
                item.EmpyName = detail.EmpyName;
                item.EmpyCode = detail.EmpyCode;
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
            string empyCode, string wscode,
            ref int reInvAuthId,
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnDetail detail = null;
            TblMWEmploy empy = null;

            #region get & valid data
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnDetailId);

                if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref detail, ref errMsg))
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
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);
                if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref empy, ref errMsg))
                {
                    return false;
                }
                if (empy == null)
                {
                    errMsg = LngRes.MSG_Valid_NoEmploy; //"没有找到当前编号的员工";
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
                item.WSCode = wscode;
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
                item.WSCode = detail.WSCode;
                item.EmpyName = detail.EmpyName;
                item.EmpyCode = detail.EmpyCode;
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
            string empyCode, string wscode,
            string depotCode, 
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWTxnDetail detail = null;
            TblMWEmploy empy = null;
            int curTxnPresseAuthCount = 0;
            #region get & valid data
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnDetailId);

                if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref detail, ref errMsg))
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

                //sqm.Condition.Where.AddCompareValue(TblMWInvAuthorize.getTxnDetailIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.TxnDetailId);
                //if (!TblMWInvAuthorizeCtrl.QueryOne(dcf, sqm, ref InvAuth, ref errMsg))
                //{
                //    return false;
                //}
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
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);
                if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref empy, ref errMsg))
                {
                    return false;
                }
                if (empy == null)
                {
                    errMsg = LngRes.MSG_Valid_NoEmploy; //"没有找到当前编号的员工";
                    return false;
                }
            }
            #endregion

            dcf.BeginTrans();

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

            #region update current txn detail
            {
                //TblMWTxnDetail item = new TblMWTxnDetail();
                detail.WSCode = empyCode;
                detail.EmpyCode = empyCode;
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
                item.Status = TblMWInventory.STATUS_ENUM_Recovered;
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
                item.WSCode = detail.WSCode;
                item.EmpyName = detail.EmpyName;
                item.EmpyCode = detail.EmpyCode;
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
                item.WSCode = detail.WSCode;
                item.EmpyName = detail.EmpyName;
                item.EmpyCode = detail.EmpyCode;
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

            #region check txn has been complete all txndetail
            {
                List<TblMWTxnDetail> detailList = null;

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
            #endregion

            #region update txn data
            DateTime now = SqlDBMng.GetDBNow();

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), TblMWTxnRecoverHeader.STATUS_ENUM_Complete);
            suc.Add(TblMWTxnRecoverHeader.getEndDateColumn(), now);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWTxnRecoverHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

            int updCount = 0;
            if (!TblMWTxnRecoverHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }

            if (updCount == 0)
            {
                errMsg = LngRes.MSG_Valid_NoDataUpdate;
                return false;
            }
            #endregion

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

        public static bool GetPostInventoryTxnDetail(int invRecordId, string txnNum, ref TblMWTxnDetail detail, ref string errMsg)
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
       
        #endregion

        #region post txn operate
        //private static bool CheckBeginOperatePostTxn(string wsCode, string empyCode, ref string newTxnNum, ref string errMsg)
        //{
        //    DataCtrlInfo dcf = new DataCtrlInfo();

        //    #region valid data
        //    TblMWEmploy empy = null;
        //    {
        //        SqlQueryMng sqm = new SqlQueryMng();
        //        sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);

        //        if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref empy, ref errMsg))
        //        {
        //            return false;
        //        }
        //        if (empy == null)
        //        {
        //            errMsg = LngRes.MSG_Valid_NoEmploy;
        //            return false;
        //        }
        //    }
        //    TblMWWorkStation ws = null;
        //    {
        //        SqlQueryMng sqm = new SqlQueryMng();
        //        sqm.Condition.Where.AddCompareValue(TblMWWorkStation.getWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wsCode);
        //        if (!TblMWWorkStationCtrl.QueryOne(dcf, sqm, ref ws, ref errMsg))
        //        {
        //            return false;
        //        }
        //        if (ws == null)
        //        {
        //            errMsg = LngRes.MSG_Valid_NoWorkstation;
        //            return false;
        //        }
        //    }
        //    #endregion

        //    #region add data
        //    newTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
        //    if (string.IsNullOrEmpty(newTxnNum))
        //    {
        //        errMsg = ErrorMng.GetDBError(ClassName, "BeginOperatePostTxn", MWNextIdMng.NextIdErrMsg);
        //        return false;
        //    }

        //    int headerNextId = MWNextIdMng.GetTxnPostHeaderNextId();
        //    int txnLogNextId = MWNextIdMng.GetTxnLogNextId();
        //    bool validNextId = true;

        //    validNextId = headerNextId != 0 && validNextId;
        //    validNextId = txnLogNextId != 0 && validNextId;

        //    if (!validNextId)
        //    {
        //        errMsg = ErrorMng.GetDBError(ClassName, "BeginOperatePostTxn", MWNextIdMng.NextIdErrMsg);
        //        return false;
        //    }

        //    DateTime now = SqlDBMng.GetDBNow();

        //    #region add header
        //    {
        //        TblMWTxnPostHeader item = new TblMWTxnPostHeader();
        //        item.PostHeaderId = headerNextId;
        //        item.TxnNum = newTxnNum;
        //        item.PostWSCode = ws.WSCode;
        //        item.PostEmpyName = empy.EmpyName;
        //        item.PostEmpyCode = empy.EmpyCode;
        //        item.StartDate = now;
        //        //item.EndDate = data.EndDate;
        //        item.PostType = TblMWTxnPostHeader.POSTTYPE_ENUM_Nomarl;
        //        item.TotalCrateQty = 0;
        //        item.TotalSubWeight = 0;
        //        item.TotalTxnWeight = 0;
        //        item.Status = TblMWTxnPostHeader.STATUS_ENUM_Process;

        //        int updCount = 0;
        //        if (!TblMWTxnPostHeaderCtrl.Insert(dcf, item, ref updCount, ref errMsg))
        //        {
        //            return false;
        //        }
        //    }
        //    #endregion

        //    #region add txn log
        //    {
        //        TblMWTxnLog item = new TblMWTxnLog();
        //        item.TxnLogId = txnLogNextId;

        //        item.TxnNum = newTxnNum;
        //        item.TxnDetailId = 0;
        //        item.WSCode = ws.WSCode;
        //        item.EmpyName = empy.EmpyName;
        //        item.EmpyCode = empy.EmpyCode;
        //        item.OptType = TblMWTxnLog.OPTTYPE_ENUM_NewTxn;;
        //        item.OptDate = now;
        //        item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Post;

        //        item.InvRecordId = 0;

        //        int updCount = 0;
        //        if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
        //        {
        //            return false;
        //        }
        //    }
        //    #endregion

        //    #endregion

        //    return true;
        //}

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
            
            #region valid data
           
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
            TblMWEmploy empy = null;
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
            TblMWWorkStation ws = null;
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
            valid = txnLogNextId != 0 && valid;

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
                        errMsg = ErrorMng.GetDBError(ClassName, "BeginOperatePostTxn", MWNextIdMng.NextIdErrMsg);
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
                        errMsg = LngRes.MSG_Valid_NoInvTxnHeader;
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
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Posted);
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
        public static bool ConfirmInventoryToAuthorizeNew(int invRecordId,  decimal txnWeight, string wsCode, string empyCode,
            ref int reInvAuthId,
            ref string newTxnNum,
            ref string errMsg)
        {
            return ConfirmInventoryToAuthorize(invRecordId, null, txnWeight, wsCode, empyCode, ref reInvAuthId, ref newTxnNum, ref errMsg);
        }

        public static bool ConfirmInventoryToAuthorizeEdit(int invRecordId, string txnNum, decimal txnWeight, string wsCode, string empyCode,
            ref int reInvAuthId,
            ref string errMsg)
        {
            string newTxnNum = null;
            return ConfirmInventoryToAuthorize(invRecordId,txnNum,txnWeight,wsCode,empyCode,ref reInvAuthId,ref newTxnNum,ref errMsg);
        }

        private static bool ConfirmInventoryToAuthorize(int invRecordId, string txnNum, decimal txnWeight, string wsCode, string empyCode, 
            ref int reInvAuthId, 
            ref string newTxnNum,
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWEmploy empy = null;
            TblMWInventory inv = null;
            //TblMWTxnPostHeader header = null;
            TblMWWorkStation ws = null;
            #region get & valid data
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
            #endregion

            dcf.BeginTrans();

            #region add data
            DateTime now = SqlDBMng.GetDBNow();
            int updCount = 0;
           
            int txnLogNextId = 0;
            int invAuthId = 0;
            int dtlNextId = 0;
            int invTrackNextId = 0;
            #region next id
            bool validNextId = true;
            invAuthId = MWNextIdMng.GetInvAuthorizeNextId();
            txnLogNextId = MWNextIdMng.GetTxnLogNextId();
            dtlNextId = MWNextIdMng.GetTxnDetailNextId();
            invTrackNextId = MWNextIdMng.GetInventoryTrackNextId();

            validNextId = txnLogNextId != 0 && validNextId;
            validNextId = invAuthId != 0 && validNextId;
            validNextId = dtlNextId != 0 && validNextId;
            validNextId = invTrackNextId != 0 && validNextId;
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
                        errMsg = LngRes.MSG_Valid_NoInvTxnHeader;
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

            #region authorize data
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

            #region inventory
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

            #region _del inventory track
            //{
            //    TblMWInventoryTrack item = new TblMWInventoryTrack();
            //    item.InvTrackRecordId = invTrackNextId;

            //    item.InvRecordId = inv.InvRecordId;

            //    item.TxnNum = header.TxnNum;
            //    item.TxnType = TblMWInventoryTrack.TXNTYPE_ENUM_Post;//detail.TxnType;
            //    item.TxnDetailId = dtlNextId;
            //    item.CrateCode = inv.CrateCode;
            //    item.DepotCode = inv.DepotCode;
            //    item.Vendor = inv.Vendor;
            //    item.VendorCode = inv.VendorCode;
            //    item.Waste = inv.Waste;
            //    item.WasteCode = inv.WasteCode;
            //    item.SubWeight = inv.InvWeight;
            //    item.TxnWeight = txnWeight;
            //    item.WSCode = ws.WSCode;
            //    item.EmpyName = empy.EmpyName;
            //    item.EmpyCode = empy.EmpyCode;
            //    item.EntryDate = now;
            //    item.Status = TblMWInventoryTrack.STATUS_ENUM_Normal;
            //    item.InvAuthId = invAuthId;

            //    if (!TblMWInventoryTrackCtrl.Insert(dcf, item, ref updCount, ref errMsg))
            //    {
            //        return false;
            //    }
            //}
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
                    errMsg = LngRes.MSG_Valid_NoInvTxnHeader;
                    return false;
                }
            }
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getInvRecordIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invRecordId);
                if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref detail, ref errMsg))
                {
                    return false;
                }
                if (detail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoTxnDetail;
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
                suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), TblMWTxnRecoverHeader.STATUS_ENUM_Process);
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

            #region inventory
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInventory.getStatusColumn(), TblMWInventory.STATUS_ENUM_Posted);
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

            #region check txn has been complete all txndetail
            {
                List<TblMWTxnDetail> detailList = null;

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
            #endregion

            #region update txn data
            DateTime now = SqlDBMng.GetDBNow();

            SqlUpdateColumn suc = new SqlUpdateColumn();

            suc.Add(TblMWTxnPostHeader.getStatusColumn(), TblMWTxnPostHeader.STATUS_ENUM_Complete);
            suc.Add(TblMWTxnPostHeader.getEndDateColumn(), now);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWTxnPostHeader.getTxnNumColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, txnNum);

            int updCount = 0;
            if (!TblMWTxnPostHeaderCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            if (updCount == 0)
            {
                errMsg = LngRes.MSG_Valid_NoDataUpdate;
                return false;
            }
            #endregion

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
            public const string MSG_Valid_CrateIsInvData = "警告！当前货箱为库存数据，没有任何出库销毁记录。请检查货箱来源！";
            public const string MSG_Valid_NoTxnDetail = "没有找到当前ID的货箱交易详情";
            public const string MSG_Valid_TxnComplete = "当前货箱已完成入库";
            public const string MSG_Valid_TxnInAuthorize = "当前货箱正在审核中";
            public const string MSG_Valid_NoEmploy = "没有找到当前编号的员工";
            public const string MSG_Valid_NoWorkstation = "没有当前编号的工作站";
            public const string MSG_Valid_NoInvTxnHeader = "没有找到当前订单号的出库计划单";
            public const string MSG_Valid_NoInventory = "没有找到当前的库存信息";
            public const string MSG_Valid_ExistUnCompleteTxnDetail = "计划交易，有未审核完成货箱";

            public const string MSG_Valid_NoDataUpdate = "数据没有被跟新，请稍后重试。";
        }
    }

}
