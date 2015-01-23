﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;

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

        #endregion

    }
}
