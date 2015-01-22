using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using ComLib.Error;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.Business.BO
{
    public class MWRWorkflowMng
    {
        public const string ClassName = "YRKJ.MWR.Business.BO.MWRWorkflowMng";

        #region 1.car out
        static object _lockCarOut = new object();
        public static bool CarOutToReover(
            string carCode,
            string driverCode,
            string inspectorCode,
            string MWSCode,
            ref string errMsg)
        {
            

            DataCtrlInfo dcf = new DataCtrlInfo();
            string driver = "";
            string inspector = "";

            lock (_lockCarOut)
            {
                #region check async submit, use this employ
                {
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWCarDispatch.STATUS_ENUM_ShiftStrat);
                    {
                        SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                        sw.AddCompareValue(TblMWCarDispatch.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carCode);
                        sw.AddCompareValue(TblMWCarDispatch.getDriverCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, driverCode);
                        sw.AddCompareValue(TblMWCarDispatch.getInspectorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inspectorCode);
                        sw.AddCompareValue(TblMWCarDispatch.getRecoMWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, MWSCode);
                        sqm.Condition.Where.AddWhere(sw);
                    }

                    List<TblMWCarDispatch> carDispDataList = null;
                    if (!TblMWCarDispatchCtrl.QueryMore(dcf, sqm, ref carDispDataList, ref errMsg))
                    {
                        return false;
                    }

                    if (carDispDataList.Count > 0)
                    {
                        errMsg = "当前选择的[车辆][跟车员][司机][终端]已被其他人员派出，请重新选择";
                        return false;
                    }

                }
                #endregion

                #region check exist employ
                {
                    List<TblMWEmploy> empyDataList = null;
                    {
                        SqlQueryMng sqm = new SqlQueryMng();
                        sqm.Condition.Where.SetLinkType(SqlCommonFn.SqlWhereLinkType.OR);
                        sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, driverCode);
                        sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inspectorCode);

                        if (!TblMWEmployCtrl.QueryMore(dcf, sqm, ref empyDataList, ref errMsg))
                        {
                            return false;
                        }
                    }
                    foreach (TblMWEmploy data in empyDataList)
                    {
                        if (data.EmpyType == TblMWEmploy.EMPYTYPE_ENUM_Driver)
                        {
                            driver = data.EmpyName;
                        }
                        else if (data.EmpyType == TblMWEmploy.EMPYTYPE_ENUM_Inspector)
                        {
                            inspector = data.EmpyName;
                        }
                    }
                    if (string.IsNullOrEmpty(driver) || string.IsNullOrEmpty(inspector))
                    {
                        errMsg = "当前选择的跟车员或司机信息不存在";
                        return false;
                    }
                }
                #endregion
              
                #region add data
                int carDisId = MWNextIdMng.GetCarDispatchNextId();
                if (carDisId == 0)
                {
                    errMsg = ErrorMng.GetDBError(ClassName, "CarOutToReover", "Id增长列添加错误");
                    return false;
                }
                TblMWCarDispatch item = new TblMWCarDispatch();
                item.CarDisId = carDisId;
                item.CarCode = carCode;
                item.Driver = driver;
                item.DriverCode = driverCode;
                item.Inspector = inspector;
                item.InspectorCode = inspectorCode;
                item.RecoMWSCode = MWSCode;
                item.OutDate = SqlDBMng.GetDBNow();
                item.Status = TblMWCarDispatch.STATUS_ENUM_ShiftStrat;

                int updCount = 0;
                if (!TblMWCarDispatchCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
                if (updCount == 0)
                {
                    errMsg = ErrorMng.GetDBError(ClassName, "CarOutToReover", "数据未添加");
                    return false;
                }
                #endregion
            }

            return true;
        }
        #endregion

        #region 2.1 send txnheader,car recover resposne inv workstation

        public static bool RecoverToInventory(
            string carCode,
            string driverCode,
            string inspectorCode,
            string mwsCode,
            List<TblMWTxnDetail> txnDetailList,
            ref string errMsg)
        {

            if (txnDetailList == null)
            {
                errMsg = "没有扫描的货箱数据";
                return false;
            }
            if (txnDetailList.Count == 0)
            {
                errMsg = "没有扫描的货箱数据";
                return false;
            }

            string driver = "";
            string inspector = "";

            decimal totalSubWeight = 0;
            decimal totalCrateQty = 0;
            TblMWCarDispatch carDispatchInfo = null;
            #region get moblie workstation base data
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                totalCrateQty = txnDetailList.Count;
                foreach (TblMWTxnDetail dtl in txnDetailList)
                {
                    totalSubWeight += dtl.SubWeight;
                }

                #region CarDispatch
                {
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carCode);
                    sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWCarDispatch.STATUS_ENUM_ShiftStrat);
                    //sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getInDateColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, DateTime.MinValue);
                    sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getDriverCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, driverCode);
                    sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getInspectorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inspectorCode);
                    sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getRecoMWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, mwsCode);

                    if (!TblMWCarDispatchCtrl.QueryOne(dcf, sqm, ref carDispatchInfo, ref errMsg))
                    {
                        return false;
                    }
                    if (carDispatchInfo == null)
                    {
                        errMsg = "没有找到当前车辆的出车记录,是否已被完成？";
                        return false;
                    }
                    //if (carDispatchInfo.Status != TblMWCarDispatch.STATUS_ENUM_ShiftStrat)
                    //{
                    //    errMsg = "该回收计划已经被管理员关闭";
                    //    return false;
                    //}
                    if (carDispatchInfo.InDate != DateTime.MinValue)
                    {
                        errMsg = "该回收计划已经提交";
                        return false;
                    }
                }
                #endregion

                #region driver
                {
                    TblMWEmploy data = null;
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, driverCode);
                    if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref data, ref errMsg))
                    {
                        return false;
                    }
                    if (data == null)
                    {
                        errMsg = "没有当前编号的司机";
                        return false;
                    }
                    driver = data.EmpyName;
                }
                #endregion

                #region inspector
                {
                    TblMWEmploy data = null;
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inspectorCode);
                    if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref data, ref errMsg))
                    {
                        return false;
                    }
                    if (data == null)
                    {
                        errMsg = "没有当前编号的跟车员";
                        return false;
                    }
                    inspector = data.EmpyName;
                }
                #endregion
            }
            #endregion

            #region add data
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                dcf.BeginTrans();

                DateTime now = SqlDBMng.GetDBNow();
                #region add txn data
                {
                    int nextId = MWNextIdMng.GetTxnRecoverHeaderNextId();
                    if (nextId == 0)
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "recoverToInventory", "Id增长列添加错误");
                        return false;
                    }
                    string nextTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
                    if (nextTxnNum == null)
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "recoverToInventory", "TxnNum增长列添加错误");
                        return false;
                    }
                    TblMWTxnRecoverHeader header = new TblMWTxnRecoverHeader();
                    header.RecoHeaderId = nextId;
                    header.TxnNum = nextTxnNum;

                    header.CarCode = carCode;
                    header.Driver = driver;
                    header.DriverCode = driverCode;
                    header.Inspector = inspector;
                    header.InspectorCode = inspectorCode;
                    header.RecoMWSCode = mwsCode;


                    header.RecoWSCode = mwsCode;
                    header.RecoEmpyName = inspector;
                    header.RecoEmpyCode = inspectorCode;

                    header.StratDate = now;
                    header.EndDate = DateTime.MinValue;
                    header.OperateType = TblMWTxnRecoverHeader.OPERATETYPE_ENUM_ToInventory;
                    header.TotalCrateQty = 0;
                    header.TotalSubWeight = 0;
                    header.TotalTxnWeight = 0;
                    header.CarDisId = carDispatchInfo.CarDisId;
                    header.Status = TblMWTxnRecoverHeader.STATUS_ENUM_Process;

                    int updCount = 0;
                    if (!TblMWTxnRecoverHeaderCtrl.Insert(dcf, header, ref updCount, ref errMsg))
                    {
                        return false;
                    }


                    int dtlNextId = MWNextIdMng.GetTxnDetailNextId(txnDetailList.Count);
                    foreach (TblMWTxnDetail dtl in txnDetailList)
                    {
                        dtl.TxnDetailId = dtlNextId;
                        dtl.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Submit;
                        dtl.TxnNum = header.TxnNum;
                        dtl.WSCode = mwsCode;
                        dtl.EmpyName = inspector;
                        dtl.EmpyCode = inspectorCode;
                        
                        dtl.EntryDate = now;

                        dtl.TxnDetailId = dtlNextId;
                        dtl.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Submit;
                        dtl.TxnNum = header.TxnNum;
                        dtl.WSCode = mwsCode;
                        dtl.EmpyName = inspector;
                        dtl.EmpyCode = inspectorCode;
                        //dtl.CrateCode = "";
                        //dtl.Vendor = "";
                        //dtl.VendorCode = "";
                        //dtl.Waste = "";
                        //dtl.WasteCode = "";
                        //dtl.SubWeight = "";
                        dtl.TxnWeight = dtl.SubWeight;
                        dtl.EntryDate = now;
                        //dtl.InvRecordId = "";
                        //dtl.InvAuthId = "";
                        dtl.Status = TblMWTxnDetail.STATUS_ENUM_Complete;

                        if (!TblMWTxnDetailCtrl.Insert(dcf, dtl, ref updCount, ref errMsg))
                        {
                            return false;
                        }
                        dtlNextId++;
                    }
                }
                #endregion

                #region update cardisptch indate
                {
                    int updCount = 0;

                    SqlWhere sw = new SqlWhere();
                    sw.AddCompareValue(TblMWCarDispatch.getCarDisIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carDispatchInfo.CarDisId);

                    SqlUpdateColumn suc = new SqlUpdateColumn();
                    suc.Add(TblMWCarDispatch.getInDateColumn(), now);

                    if (!TblMWCarDispatchCtrl.Update(dcf, carDispatchInfo, suc, sw, ref updCount, ref errMsg))
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

            }
            #endregion

            return true;
        }

        #endregion

        #region end. car finish the workflow, complete shift, close cardispatch

        public static bool CloseCarDispatch(int disId,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCarDispatch.getStatusColumn(), TblMWCarDispatch.STATUS_ENUM_ShiftEnd);
            suc.Add(TblMWCarDispatch.getInDateColumn(), SqlDBMng.GetDBNow());

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCarDispatch.getCarDisIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, disId);

            int updCount = 0;
            if (!TblMWCarDispatchCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }

            if (updCount == 0)
            {
                errMsg = ErrorMng.GetDBError(ClassName, "CloseCarDispatch", "数据未更新");
                return false;
            }

            return true;
        }

        #endregion

        #region data search
        public static bool GetNoCloseCarDispatchDataList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWCarDispatch> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();

            //DateTime today = SqlDBMng.GetDBNow();
            //sqm.Condition.Where.AddDateTimeCompareValue(
            //    TblMWCarDispatch.getOutDateColumn(), 
            //    SqlCommonFn.SqlWhereCompareEnum.Equals, 
            //    today, 
            //    SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
            sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWCarDispatch.STATUS_ENUM_ShiftStrat);
            
            if (!TblMWCarDispatchCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        #endregion

    }
}
