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
        public static bool CheckCarOutToRecover(string carCode, string driverCode, string inspectorCode,ref bool hasBeenOut, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            #region check async submit, use this employ
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWCarDispatch.STATUS_ENUM_ShiftStrat);
                {
                    SqlWhere sw = new SqlWhere(SqlCommonFn.SqlWhereLinkType.OR);
                    sw.AddCompareValue(TblMWCarDispatch.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carCode);
                    sw.AddCompareValue(TblMWCarDispatch.getDriverCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, driverCode);
                    sw.AddCompareValue(TblMWCarDispatch.getInspectorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inspectorCode);
                    sqm.Condition.Where.AddWhere(sw);
                }

                List<TblMWCarDispatch> carDispDataList = null;
                if (!TblMWCarDispatchCtrl.QueryMore(dcf, sqm, ref carDispDataList, ref errMsg))
                {
                    return false;
                }

                if (carDispDataList.Count > 0)
                {
                    hasBeenOut = true;
                    //errMsg = "当前选择的[车辆][跟车员][司机][终端]已被其他人员派出，请重新选择";
                    return false;
                }
                else
                    hasBeenOut = false;

            }
            #endregion
            return true;
        }

        static object _lockCarOut = new object();
        public static bool CarOutToRecover(
           string carCode,
           string driverCode,
           string inspectorCode,
           string MWSCode,
           ref string errMsg)
        {
            TblMWCarDispatch carDispatch = null;
            return CarOutToRecover(carCode, driverCode, inspectorCode, MWSCode, ref carDispatch, ref errMsg);
        }
        public static bool CarOutToRecover(
            string carCode,
            string driverCode,
            string inspectorCode,
            string MWSCode,
            ref TblMWCarDispatch carDispatch,
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
                carDispatch = item;
                #endregion
            }

            return true;
        }
        #endregion

        #region 2.1 send txnheader,car recover resposne inv workstation
        public static bool RecoverToDestroy(string carCode,
            string driverCode,
            string inspectorCode,
            string mwsCode,
            List<TblMWTxnDetail> txnDetailList,
            ref string errMsg)
        { 
            return CarInRecover(carCode, driverCode, inspectorCode, mwsCode, txnDetailList, TblMWTxnRecoverHeader.OPERATETYPE_ENUM_ToDestroy, ref errMsg);
        }
        public static bool RecoverToInventory(string carCode,
            string driverCode,
            string inspectorCode,
            string mwsCode,
            List<TblMWTxnDetail> txnDetailList,
            ref string errMsg)
        {
            return CarInRecover(carCode, driverCode, inspectorCode, mwsCode, txnDetailList, TblMWTxnRecoverHeader.OPERATETYPE_ENUM_ToInventory, ref errMsg);
        }
        private static bool CarInRecover(string carCode,
            string driverCode,
            string inspectorCode,
            string mwsCode,
            List<TblMWTxnDetail> txnDetailList,
            string OperateType,
            ref string errMsg)
        {

            string driver = "";
            string inspector = "";

            decimal totalSubWeight = 0;
            int totalCrateQty = 0;
            TblMWCarDispatch carDispatchInfo = null;

            #region no recover data
            if (txnDetailList.Count == 0)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                DateTime now = SqlDBMng.GetDBNow();
                //直接完成
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

                return true;
            }
            #endregion



            #region valid & get moblie workstation base data
            {
                //if (txnDetailList.Count == 0)
                //{
                //    errMsg = "没有数据，请添加数据后再次提交。";
                //    return false;
                //}

                DataCtrlInfo dcf = new DataCtrlInfo();
                totalCrateQty = txnDetailList.Count;
                List<string> crateCodes = new List<string>();
                foreach (TblMWTxnDetail dtl in txnDetailList)
                {
                    totalSubWeight += dtl.SubWeight;
                    crateCodes.Add(dtl.CrateCode);
                }

                #region valid crateCode
                {
                    
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.QueryColumn.AddCount(TblMWCrate.getCrateCodeColumn());
                    sqm.Condition.Where.AddInValues(TblMWCrate.getCrateCodeColumn(), crateCodes.ToArray());

                    TblMWCrate item = null;
                    if (!TblMWCrateCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
                    {
                        return false;
                    }
                    if (item == null)
                    {
                        return false;
                    }

                    int defineCount = ComLib.ComFn.StringToInt(item.CrateCode);
                    if (defineCount != txnDetailList.Count)
                    {
                        errMsg = "提交货箱中，有无效货箱编号。请检查再次提交！";
                        return false;
                    }

                    
                }
                #endregion

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

//#if !DEBUG
//                    if (carDispatchInfo.InDate != DateTime.MinValue)
//                    {
//                        errMsg = "该回收计划已经提交";
//                        return false;
//                    }
//#endif
                }
                #endregion

                #region valid txn
                {
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.SetLinkType(SqlCommonFn.SqlWhereLinkType.OR);

                    foreach (TblMWTxnDetail detail in txnDetailList)
                    {
                        SqlWhere sw = new SqlWhere();

                        sw.AddCompareValue(TblMWTxnDetail.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWTxnDetail.STATUS_ENUM_Complete);
                        sw.AddCompareValue(TblMWTxnDetail.getCrateCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.CrateCode);
                        sqm.Condition.Where.AddWhere(sw);
                    }
                    sqm.QueryColumn.AddCount(TblMWTxnDetail.getTxnDetailIdColumn());

                    TblMWTxnDetail item = null;
                    if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
                    {
                        return false;
                    }

                    if (item != null && item.TxnDetailId != 0)
                    {
                        errMsg = "当前货箱中有未完成的交易货箱，请验证货箱来源。";
                        return false;
                    }
                }
                #endregion

                #region valid inventory
                {
                    SqlQueryMng sqm = new SqlQueryMng();
                    sqm.Condition.Where.SetLinkType(SqlCommonFn.SqlWhereLinkType.OR);

                    foreach (TblMWTxnDetail detail in txnDetailList)
                    {
                        SqlWhere sw = new SqlWhere();
                        sw.AddCompareValue(TblMWInventory.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWInventory.STATUS_ENUM_Destroyed);
                        sw.AddCompareValue(TblMWInventory.getCrateCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, detail.CrateCode);
                        sqm.Condition.Where.AddWhere(sw);
                    }

                    sqm.QueryColumn.AddCount(TblMWInventory.getInvRecordIdColumn());

                    TblMWInventory item = null;
                    if (!TblMWInventoryCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
                    {
                        return false;
                    }
                    if (item != null && item.InvRecordId != 0)
                    {
                        errMsg = "当前提交计划中有库存货箱，请验证货箱来源。";
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

                    string nextTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
                    if (nextTxnNum == null)
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "recoverToInventory", "TxnNum增长列添加错误");
                        return false;
                    }

                    #region add header
                    int nextId = MWNextIdMng.GetTxnRecoverHeaderNextId();
                    if (nextId == 0)
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "recoverToInventory", "Id增长列添加错误");
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


                    //header.RecoWSCode = mwsCode;
                    //header.RecoEmpyName = inspector;
                    //header.RecoEmpyCode = inspectorCode;

                    //header.StratDate = DateTime.MinValue;
                    //header.EndDate = DateTime.MinValue;
                    header.EntryDate = now;
                    header.OperateType = OperateType;// TblMWTxnRecoverHeader.OPERATETYPE_ENUM_ToInventory;
                    header.TotalCrateQty = totalCrateQty;
                    header.TotalSubWeight = totalSubWeight;
                    header.TotalTxnWeight = 0;
                    header.CarDisId = carDispatchInfo.CarDisId;
                    header.Status = TblMWTxnRecoverHeader.STATUS_ENUM_Send;

                    int updCount = 0;
                    if (!TblMWTxnRecoverHeaderCtrl.Insert(dcf, header, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                    #endregion

                    #region add detail
                    int dtlNextId = MWNextIdMng.GetTxnDetailNextId(txnDetailList.Count);
                    int txnLogNextId = MWNextIdMng.GetTxnLogNextId(txnDetailList.Count);
                    if (dtlNextId == 0
                        && txnLogNextId == 0)
                    {
                        errMsg = ErrorMng.GetDBError(ClassName, "recoverToInventory", "Id增长列添加错误");
                        return false;
                    }
                    foreach (TblMWTxnDetail dtl in txnDetailList)
                    {
                        dtl.TxnDetailId = dtlNextId;
                        dtl.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Recover;
                        dtl.TxnNum = header.TxnNum;
                        //dtl.WSCode = mwsCode;
                        //dtl.EmpyName = inspector;
                        //dtl.EmpyCode = inspectorCode;
                        //dtl.CrateCode = "";
                        //dtl.Vendor = "";
                        //dtl.VendorCode = "";
                        //dtl.Waste = "";
                        //dtl.WasteCode = "";
                        //dtl.SubWeight = "";
                        //dtl.TxnWeight = dtl.SubWeight;
                        //dtl.EntryDate = now;
                        //dtl.InvRecordId = "";
                        //dtl.InvAuthId = "";
                        dtl.Status = TblMWTxnDetail.STATUS_ENUM_Process;

                        if (!TblMWTxnDetailCtrl.Insert(dcf, dtl, ref updCount, ref errMsg))
                        {
                            return false;
                        }

                        #region add txn log
                        {
                            TblMWTxnLog item = new TblMWTxnLog();
                            item.TxnLogId = txnLogNextId;
                            item.TxnNum = dtl.TxnNum;
                            item.TxnDetailId = dtl.TxnDetailId;
                            item.WSCode = mwsCode;
                            item.EmpyName = inspector;
                            item.EmpyCode = inspectorCode;
                            item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubRecover;
                            item.OptDate = now;
                            item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Recover;
                            //item.InvRecordId = invRecordNextId;

                            if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                            {
                                return false;
                            }
                        }
                        #endregion

                        dtlNextId++;
                        txnLogNextId++;
                    }
                    #endregion
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
        //static bool RecoverToInventory(string a,
        //    string carCode,
        //    string driverCode,
        //    string inspectorCode,
        //    string mwsCode,
        //    List<TblMWTxnDetail> txnDetailList,
        //    ref string errMsg)
        //{

        //    string driver = "";
        //    string inspector = "";

        //    decimal totalSubWeight = 0;
        //    int totalCrateQty = 0;
        //    TblMWCarDispatch carDispatchInfo = null;
        //    #region get moblie workstation base data
        //    {
        //        DataCtrlInfo dcf = new DataCtrlInfo();
        //        totalCrateQty = txnDetailList.Count;
        //        foreach (TblMWTxnDetail dtl in txnDetailList)
        //        {
        //            totalSubWeight += dtl.SubWeight;
        //        }

        //        #region CarDispatch
        //        {
        //            SqlQueryMng sqm = new SqlQueryMng();
        //            sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carCode);
        //            sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWCarDispatch.STATUS_ENUM_ShiftStrat);
        //            //sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getInDateColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, DateTime.MinValue);
        //            sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getDriverCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, driverCode);
        //            sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getInspectorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inspectorCode);
        //            sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getRecoMWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, mwsCode);

        //            if (!TblMWCarDispatchCtrl.QueryOne(dcf, sqm, ref carDispatchInfo, ref errMsg))
        //            {
        //                return false;
        //            }
        //            if (carDispatchInfo == null)
        //            {
        //                errMsg = "没有找到当前车辆的出车记录,是否已被完成？";
        //                return false;
        //            }
        //            //if (carDispatchInfo.Status != TblMWCarDispatch.STATUS_ENUM_ShiftStrat)
        //            //{
        //            //    errMsg = "该回收计划已经被管理员关闭";
        //            //    return false;
        //            //}
        //            if (carDispatchInfo.InDate != DateTime.MinValue)
        //            {
        //                errMsg = "该回收计划已经提交";
        //                return false;
        //            }
        //        }
        //        #endregion

        //        #region driver
        //        {
        //            TblMWEmploy data = null;
        //            SqlQueryMng sqm = new SqlQueryMng();
        //            sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, driverCode);
        //            if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref data, ref errMsg))
        //            {
        //                return false;
        //            }
        //            if (data == null)
        //            {
        //                errMsg = "没有当前编号的司机";
        //                return false;
        //            }
        //            driver = data.EmpyName;
        //        }
        //        #endregion

        //        #region inspector
        //        {
        //            TblMWEmploy data = null;
        //            SqlQueryMng sqm = new SqlQueryMng();
        //            sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, inspectorCode);
        //            if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref data, ref errMsg))
        //            {
        //                return false;
        //            }
        //            if (data == null)
        //            {
        //                errMsg = "没有当前编号的跟车员";
        //                return false;
        //            }
        //            inspector = data.EmpyName;
        //        }
        //        #endregion
        //    }
        //    #endregion

        //    #region add data
        //    {
        //        DataCtrlInfo dcf = new DataCtrlInfo();
        //        dcf.BeginTrans();

        //        DateTime now = SqlDBMng.GetDBNow();
        //        #region add txn data
        //        {
                    
        //            string nextTxnNum = MWNextIdMng.GetTxnNextNum(BizBase.GetInstance().TxnNumMask);
        //            if (nextTxnNum == null)
        //            {
        //                errMsg = ErrorMng.GetDBError(ClassName, "recoverToInventory", "TxnNum增长列添加错误");
        //                return false;
        //            }

        //            #region add header
        //            int nextId = MWNextIdMng.GetTxnRecoverHeaderNextId();
        //            if (nextId == 0)
        //            {
        //                errMsg = ErrorMng.GetDBError(ClassName, "recoverToInventory", "Id增长列添加错误");
        //                return false;
        //            }
        //            TblMWTxnRecoverHeader header = new TblMWTxnRecoverHeader();
        //            header.RecoHeaderId = nextId;
        //            header.TxnNum = nextTxnNum;

        //            header.CarCode = carCode;
        //            header.Driver = driver;
        //            header.DriverCode = driverCode;
        //            header.Inspector = inspector;
        //            header.InspectorCode = inspectorCode;
        //            header.RecoMWSCode = mwsCode;


        //            //header.RecoWSCode = mwsCode;
        //            //header.RecoEmpyName = inspector;
        //            //header.RecoEmpyCode = inspectorCode;

        //            //header.StratDate = DateTime.MinValue;
        //            //header.EndDate = DateTime.MinValue;
        //            header.OperateType = TblMWTxnRecoverHeader.OPERATETYPE_ENUM_ToInventory;
        //            header.TotalCrateQty = totalCrateQty;
        //            header.TotalSubWeight = totalSubWeight;
        //            header.TotalTxnWeight = 0;
        //            header.CarDisId = carDispatchInfo.CarDisId;
        //            header.Status = TblMWTxnRecoverHeader.STATUS_ENUM_Send;

        //            int updCount = 0;
        //            if (!TblMWTxnRecoverHeaderCtrl.Insert(dcf, header, ref updCount, ref errMsg))
        //            {
        //                return false;
        //            }
        //            #endregion

        //            #region add detail
        //            int dtlNextId = MWNextIdMng.GetTxnDetailNextId(txnDetailList.Count);
        //            int txnLogNextId = MWNextIdMng.GetTxnLogNextId(txnDetailList.Count);
        //            if (dtlNextId == 0
        //                && txnLogNextId == 0)
        //            {
        //                errMsg = ErrorMng.GetDBError(ClassName, "recoverToInventory", "Id增长列添加错误");
        //                return false;
        //            }
        //            foreach (TblMWTxnDetail dtl in txnDetailList)
        //            {
        //                dtl.TxnDetailId = dtlNextId;
        //                dtl.TxnType = TblMWTxnDetail.TXNTYPE_ENUM_Recover;
        //                dtl.TxnNum = header.TxnNum;
        //                //dtl.WSCode = mwsCode;
        //                //dtl.EmpyName = inspector;
        //                //dtl.EmpyCode = inspectorCode;
        //                //dtl.CrateCode = "";
        //                //dtl.Vendor = "";
        //                //dtl.VendorCode = "";
        //                //dtl.Waste = "";
        //                //dtl.WasteCode = "";
        //                //dtl.SubWeight = "";
        //                //dtl.TxnWeight = dtl.SubWeight;
        //                //dtl.EntryDate = now;
        //                //dtl.InvRecordId = "";
        //                //dtl.InvAuthId = "";
        //                dtl.Status = TblMWTxnDetail.STATUS_ENUM_Process;

        //                if (!TblMWTxnDetailCtrl.Insert(dcf, dtl, ref updCount, ref errMsg))
        //                {
        //                    return false;
        //                }

        //                #region add txn log
        //                {
        //                    TblMWTxnLog item = new TblMWTxnLog();
        //                    item.TxnLogId = txnLogNextId;
        //                    item.TxnNum = dtl.TxnNum;
        //                    item.TxnDetailId = dtl.TxnDetailId;
        //                    item.WSCode = mwsCode;
        //                    item.EmpyName = inspector;
        //                    item.EmpyCode = inspectorCode;
        //                    item.OptType = TblMWTxnLog.OPTTYPE_ENUM_SubRecover;
        //                    item.OptDate = now;
        //                    item.TxnLogType = TblMWTxnLog.TXNLOGTYPE_ENUM_Recover;
        //                    //item.InvRecordId = invRecordNextId;

        //                    if (!TblMWTxnLogCtrl.Insert(dcf, item, ref updCount, ref errMsg))
        //                    {
        //                        return false;
        //                    }
        //                }
        //                #endregion

        //                dtlNextId++;
        //                txnLogNextId++;
        //            }
        //            #endregion
        //        }
        //        #endregion

        //        #region update cardisptch indate
        //        {
        //            int updCount = 0;

        //            SqlWhere sw = new SqlWhere();
        //            sw.AddCompareValue(TblMWCarDispatch.getCarDisIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carDispatchInfo.CarDisId);

        //            SqlUpdateColumn suc = new SqlUpdateColumn();
        //            suc.Add(TblMWCarDispatch.getInDateColumn(), now);

        //            if (!TblMWCarDispatchCtrl.Update(dcf, carDispatchInfo, suc, sw, ref updCount, ref errMsg))
        //            {
        //                return false;
        //            }
        //        }
        //        #endregion

        //        int[] updCounts = null;
        //        if (!dcf.Commit(ref updCounts, ref errMsg))
        //        {
        //            return false;
        //        }

        //    }
        //    #endregion

        //    return true;
        //}

        public static bool PassAuthorize(int invAuthId,string authEmpyCode, string remark, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWEmploy empy = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, authEmpyCode);


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
            TblMWTxnDetail detail = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWTxnDetail.getInvAuthIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invAuthId);
                if (!TblMWTxnDetailCtrl.QueryOne(dcf, sqm, ref detail, ref errMsg))
                {
                    return false;
                }
                if (detail == null)
                {
                    errMsg = "没有审核的交易详情";
                    return false;
                }
            }

            dcf.BeginTrans();
            DateTime now = SqlDBMng.GetDBNow();
            #region update current authorize
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWInvAuthorize.getRemarkColumn(), remark);
                suc.Add(TblMWInvAuthorize.getStatusColumn(), TblMWInvAuthorize.STATUS_ENUM_Complete);
                suc.Add(TblMWInvAuthorize.getCompDateColumn(), now);
                suc.Add(TblMWInvAuthorize.getAuthEmpyCodeColumn(), empy.EmpyCode);
                suc.Add(TblMWInvAuthorize.getAuthEmpyNameColumn(), empy.EmpyName);
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWInvAuthorize.getInvAuthIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invAuthId);

                int updCount = 0;
                if (!TblMWInvAuthorizeCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region update txndetail
            {
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblMWTxnDetail.getStatusColumn(), TblMWTxnDetail.STATUS_ENUM_Wait);

                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWTxnDetail.getInvAuthIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invAuthId);

                int updCount = 0;
                if (!TblMWTxnDetailCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            #endregion

            #region add txn log
            {
                int txnLogNextId = MWNextIdMng.GetTxnLogNextId();
                
                TblMWTxnLog item = new TblMWTxnLog();
                item.TxnLogId = txnLogNextId;
                item.TxnNum = detail.TxnNum;
                item.TxnDetailId = detail.TxnDetailId;
                item.WSCode = "BO";
                item.EmpyName = empy.EmpyName;
                item.EmpyCode = empy.EmpyCode;
                item.OptType = TblMWTxnLog.OPTTYPE_ENUM_AuthorizeDone;
                item.OptDate = now;
                item.TxnLogType = detail.TxnType;//TblMWTxnLog.TXNLOGTYPE_ENUM_Post;
                item.InvRecordId = detail.InvRecordId;

                int updCount = 0;
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
        public static bool AddAuthorizeAttach(int InvAuthId, List<string> filePaths, ref string errMsg)
        {
            int invAttachNextId = 0;

            invAttachNextId = MWNextIdMng.GetInvAuthorizeAttachNextId(filePaths.Count);
            if (invAttachNextId == 0)
            {
                errMsg = "ID编号生成出错";
                return false;
            }
            List<TblMWInvAuthorizeAttach> itemList = new List<TblMWInvAuthorizeAttach>();
            foreach (string path in filePaths)
            {
                TblMWInvAuthorizeAttach item = new TblMWInvAuthorizeAttach();
                item.InvAttachId = invAttachNextId;
                item.InvAuthId = InvAuthId;
                item.Path = path;
                itemList.Add(item);
                invAttachNextId++;
            }

            DataCtrlInfo dcf = new DataCtrlInfo();
            dcf.BeginTrans();

            int updCount = 0;
            foreach (TblMWInvAuthorizeAttach item in itemList)
            {
                if (!TblMWInvAuthorizeAttachCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                {
                    return false;
                }
            }

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool DelAuthorizeAttach(List<string> fileNames, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            dcf.BeginTrans();

            foreach (string fileName in fileNames)
            {
                SqlWhere sw = new SqlWhere();
                //sw.AddCompareValue(TblMWInvAuthorizeAttach.getInvAuthIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invAuthId);
                sw.AddLikeValue(TblMWInvAuthorizeAttach.getPathColumn(), SqlCommonFn.SqlWhereLikeEnum.AfterLike, fileName);

                int updCount = 0;
                if (!TblMWInvAuthorizeAttachCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }

            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region end. car complete the workflow, complete shift, close cardispatch

        public static bool CloseCarDispatch(int disId,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();


            #region valid data
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWCarDispatch.getCarDisIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, disId);

                TblMWCarDispatch item = null;
                if (!TblMWCarDispatchCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
                {
                    return false;
                }

                if (item == null)
                {
                    errMsg = ErrorMng.GetDBError(ClassName, "CloseCarDispatch", "没有找到当前的出车班次。");
                    return false;
                }

                if (item.InDate == DateTime.MinValue)
                {
                    //errMsg = ErrorMng.GetDBError(ClassName, "CloseCarDispatch", "当前车辆还未回场，不能完成本班次。");
                    errMsg = "当前车辆还未回场，不能完成本班次。";
                    return false;
                }
            }
            #endregion

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCarDispatch.getStatusColumn(), TblMWCarDispatch.STATUS_ENUM_ShiftEnd);
            //suc.Add(TblMWCarDispatch.getInDateColumn(), SqlDBMng.GetDBNow());

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
