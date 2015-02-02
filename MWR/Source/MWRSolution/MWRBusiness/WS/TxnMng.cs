using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.Business.WS
{
    public class TxnMng
    {
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
        public static bool GetRecoverDetail(string txnNum,
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
        public static bool BeginOperateTxn(string txnNum, string wscode, string empyCode, ref string errMsg)
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
                sqm.Condition.Where.AddCompareValue(TblMWWorkStation.getWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wscode);
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
            suc.Add(TblMWTxnRecoverHeader.getStratDateColumn(), SqlDBMng.GetDBNow());
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
                    errMsg = "没有找到当前ID的货箱交易详情";
                    return false;
                }

                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
                {
                    errMsg = "当前货箱已完成入库";
                    return false;
                }
                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Authorize)
                {
                    errMsg = "当前货箱正在审核中";
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
                    errMsg = "没有找到当前编号的员工";
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
                errMsg = "ID生成出错";
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
                item.Status = TblMWInventory.STATUS_ENUM_Destroyed;
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
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubInventory;
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
                    errMsg = "没有找到当前ID的货箱交易详情";
                    return false;
                }

                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
                {
                    errMsg = "当前货箱已完成入库";
                    return false;
                }
                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Authorize)
                {
                    errMsg = "当前货箱正在审核中";
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
                    errMsg = "没有找到当前编号的员工";
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
                errMsg = "ID生成出错";
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
            TblMWInvAuthorize InvAuth = null;
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
                    errMsg = "没有找到当前ID的货箱交易详情";
                    return false;
                }

                if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Complete)
                {
                    errMsg = "当前货箱已完成入库";
                    return false;
                }
                //if (detail.Status == TblMWTxnDetail.STATUS_ENUM_Authorize)
                //{
                //    errMsg = "当前货箱正在审核中";
                //    return false;
                //}
            }
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
                if (itemList.Count != 0)
                {
                    InvAuth = itemList[0];
                }
                if (InvAuth != null)
                {
                    errMsg = "当前货箱审核未完成";
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
                    errMsg = "没有找到当前编号的员工";
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
                errMsg = "ID生成出错";
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
                item.Status = TblMWInventory.STATUS_ENUM_Destroyed;
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
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_AuthorizeInventory;
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

        public static bool EndConfirmTxn(string txnNum,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            DateTime now = SqlDBMng.GetDBNow();

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
                    errMsg = "计划交易，有未审核完成货箱";
                    return false;
                }
            }
            #endregion

            #region update txn data
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
                errMsg = "数据没有被跟新，请查看该单号是否已被修改";
                return false;
            }
            #endregion

            return true;
        }
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

    }

}
