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
            decimal txnWeight, string empyCode, string wscode,
            ref string errMsg)
        {

            return true;
        }

        public static bool EndOperateTxn(string txnNum,ref string errMsg)
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
                    errMsg = "计划交易，有未审核完成货箱";
                    return false;
                }
            }
            #endregion

            #region update txn data
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWTxnRecoverHeader.getStatusColumn(), TblMWTxnRecoverHeader.STATUS_ENUM_Complete);

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
