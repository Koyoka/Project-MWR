using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using ComLib.Error;

namespace YRKJ.MWR.Business.BaseData
{
    public class BaseDataMng
    {
        public const string ClassName = "YRKJ.MWR.Business.BaseData.BaseDataMng";

        #region get data
        #region WasteCategory
        public static bool GetWasteCategoryDataList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWWasteCategory> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWWasteCategoryCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        public static bool GetWasteCategoryDataList(ref List<TblMWWasteCategory> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWWasteCategoryCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool GetWasteCategoryData(string wasteCode, ref TblMWWasteCategory data, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWWasteCategory.getWasteCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wasteCode);
            if (!TblMWWasteCategoryCtrl.QueryOne(dcf, sqm, ref data, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Vendor
        public static bool GetVendorData(string vendorCode,ref TblMWVendor data, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWVendor.getVendorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, vendorCode);
            if (!TblMWVendorCtrl.QueryOne(dcf,sqm, ref data, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool GetVendorData(ref List<TblMWVendor> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWVendorCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool GetVendorData(int page,int pageSize,ref long pageCount,ref long rowCount,ref List<TblMWVendor> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWVendorCtrl.QueryPage(dcf, sqm,page,pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;

            return true;
        }

        #endregion

        #region Car
        public static bool GetCarDatList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWCar> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();

            if (!TblMWCarCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }

        public static bool GetNoOutCarDataList(ref List<TblMWCar> dataList,ref string errMsg)
        {
            dataList = new List<TblMWCar>();

            DataCtrlInfo dcf = new DataCtrlInfo();
            
            SqlQueryMng sqm = new SqlQueryMng();
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCar.getStatusColumn(), SqlCommonFn.SqlWhereCompareEnum.UnEquals, TblMWCar.STATUS_ENUM_Void);
            {
                SqlQueryMng subSqm = new SqlQueryMng();
                subSqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
                subSqm.QueryColumn.Add(TblMWCarDispatch.getCarCodeColumn());
                subSqm.Condition.Where.AddCompareValue(
                    TblMWCarDispatch.getStatusColumn(), 
                    SqlCommonFn.SqlWhereCompareEnum.Equals, 
                    TblMWCarDispatch.STATUS_ENUM_ShiftStrat);
                
                sqm.Condition.Where.AddNotInValues(TblMWCar.getCarCodeColumn(), subSqm);
            }

            if (!TblMWCarCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Function
        public static bool GetFunctionList(string likeGroupTag,ref List<TblMWFunction> funcList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddLikeValue(TblMWFunction.getFuncTagColumn(), SqlCommonFn.SqlWhereLikeEnum.BeforeLike, likeGroupTag);

            if (!TblMWFunctionCtrl.QueryMore(dcf, sqm, ref funcList, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetFunctionList(int funcGrpId, ref List<TblMWFunction> funcList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            {
                SqlQueryMng subSqm = new SqlQueryMng();
                subSqm.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
                subSqm.QueryColumn.Add(TblMWFunctionGroupDetail.getFuncTagColumn());
                subSqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, funcGrpId);

                sqm.Condition.Where.AddInValues(TblMWFunction.getFuncTagColumn(), subSqm);
            }

            if (!TblMWFunctionCtrl.QueryMore(dcf, sqm, ref funcList, ref errMsg))
            {
                return true;
            }

            return true;
        }

        public static bool GetUnInGroupFunctionList(int funcGrpId, ref List<TblMWFunction> funcList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            {
                SqlQueryMng subSqm = new SqlQueryMng();
                subSqm.setQueryTableName(TblMWFunctionGroupDetail.getFormatTableName());
                subSqm.QueryColumn.Add(TblMWFunctionGroupDetail.getFuncTagColumn());
                subSqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, funcGrpId);

                sqm.Condition.Where.AddNotInValues(TblMWFunction.getFuncTagColumn(), subSqm);
            }

            if (!TblMWFunctionCtrl.QueryMore(dcf, sqm, ref funcList, ref errMsg))
            {
                return true;
            }
            return true;
        }

        #endregion

        #region FunctionGroup
        public static bool GetFunctionGroup(int funcGrpId, ref TblMWFunctionGroup funcGrp, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWFunctionGroup.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, funcGrpId);

            if (!TblMWFunctionGroupCtrl.QueryOne(dcf, sqm, ref funcGrp, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool GetFunctionGroupList(ref List<TblMWFunctionGroup> funcGrpList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();

            if (!TblMWFunctionGroupCtrl.QueryMore(dcf, sqm, ref funcGrpList, ref errMsg))
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Employ

        public static bool GetEmpyWithFuncGroupDataList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<VewEmployWithFunctionGroup> empyList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            if (!VewEmployWithFunctionGroupCtrl.QueryPage(dcf, sqm, page, pageSize, ref empyList, ref errMsg))
            {
                return false;
            }

            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }

        public static bool GetEmpyData(string code, ref TblMWEmploy empy, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, code);
            if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref empy, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool GetEmpyDataList(ref List<TblMWEmploy> empyList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWEmployCtrl.QueryMore(dcf, sqm, ref empyList, ref errMsg))
            { 
                return false;
            }
            return true;
        }

        public static bool GetEmpyInFuncGroup(int functionGroupId, ref List<TblMWEmploy> empyList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWEmploy.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, functionGroupId);
            //{
            //    SqlQueryMng subSqm = new SqlQueryMng();
            //    subSqm.setQueryTableName(TblMWUserPermission.getFormatTableName());
            //    subSqm.QueryColumn.Add(TblMWUserPermission.getUserGroupIdColumn());
            //    subSqm.Condition.Where.AddCompareValue(
            //        TblMWUserPermission.getFuncGroupIdColumn(), 
            //        SqlCommonFn.SqlWhereCompareEnum.Equals, 
            //        functionGroupId);
            //    sqm.Condition.Where.AddInValues(TblMWEmploy.getUserGroupIdColumn(), subSqm);
            //}

            if (!TblMWEmployCtrl.QueryMore(dcf, sqm, ref empyList, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool GetNoOutEmpyDataList(string empyType, ref List<TblMWEmploy> dataList, ref string errMsg)
        {
            dataList = new List<TblMWEmploy>();

            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyType);
            {
                SqlQueryMng subSqm = new SqlQueryMng();
                subSqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
                if (empyType == TblMWEmploy.EMPYTYPE_ENUM_Driver)
                {
                    subSqm.QueryColumn.Add(TblMWCarDispatch.getDriverCodeColumn());
                }
                else if (empyType == TblMWEmploy.EMPYTYPE_ENUM_Inspector)
                {
                    subSqm.QueryColumn.Add(TblMWCarDispatch.getInspectorCodeColumn());
                }
                else
                {
                    errMsg = ErrorMng.GetCodingError(ClassName, "GetNotOutEmpyDataList","只能使用司机和跟车员");
                    return false;
                }
                subSqm.Condition.Where.AddCompareValue(
                    TblMWCarDispatch.getStatusColumn(),
                    SqlCommonFn.SqlWhereCompareEnum.Equals,
                    TblMWCarDispatch.STATUS_ENUM_ShiftStrat);

                sqm.Condition.Where.AddNotInValues(TblMWEmploy.getEmpyCodeColumn(),subSqm);
            }

            if (!TblMWEmployCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region WS
        public static bool GetWSByAssessKey(string assessKey,ref TblMWWorkStation ws, ref string errMsg)
        {
            ws = null;

            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWWorkStation.getAccessKeyColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, assessKey);

            TblMWWorkStation item = null;
            if (!TblMWWorkStationCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
            {
                return false;
            }
            ws = item;

            return true;
        }

        public static bool GetNoOutMobileWSDataList(ref List<TblMWWorkStation> dataList, ref string errMsg)
        {
            dataList = new List<TblMWWorkStation>();

            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(
                   TblMWWorkStation.getWSTypeColumn(),
                   SqlCommonFn.SqlWhereCompareEnum.Equals,
                   TblMWWorkStation.WSTYPE_ENUM_MobWorkStation);
            {
                SqlQueryMng subSqm = new SqlQueryMng();
                subSqm.setQueryTableName(TblMWCarDispatch.getFormatTableName());
                subSqm.QueryColumn.Add(TblMWCarDispatch.getRecoMWSCodeColumn());
                subSqm.Condition.Where.AddCompareValue(
                    TblMWCarDispatch.getStatusColumn(), 
                    SqlCommonFn.SqlWhereCompareEnum.Equals, 
                    TblMWCarDispatch.STATUS_ENUM_ShiftStrat);

                sqm.Condition.Where.AddNotInValues(TblMWWorkStation.getWSCodeColumn(), subSqm);
            }

            if (!TblMWWorkStationCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Depot
        public static bool GetDepotDataList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWDepot> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWDepotCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }
        public static bool GetDepotDataList(ref List<TblMWDepot> depotList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWDepotCtrl.QueryMore(dcf, sqm, ref depotList, ref errMsg))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region Authorize

        public static bool GetProcessAuthorizeList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<VewIvnAuthorizeWithTxnDetail> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getStatusColumn(),
                 SqlCommonFn.SqlWhereCompareEnum.Equals, VewIvnAuthorizeWithTxnDetail.STATUS_ENUM_Precess);
            sqm.Condition.OrderBy.Add(VewIvnAuthorizeWithTxnDetail.getEntryDateColumn(), SqlCommonFn.SqlOrderByType.ASC);

            if (!VewIvnAuthorizeWithTxnDetailCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;

            return true;
        }

        public static bool GetAuthorize(int invAuthId, ref VewIvnAuthorizeWithTxnDetail item, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(VewIvnAuthorizeWithTxnDetail.getInvAuthIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, invAuthId);

            if (!VewIvnAuthorizeWithTxnDetailCtrl.QueryOne(dcf, sqm, ref item, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool DelAuthorizeAttach( List<string> fileNames,ref string errMsg)
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

        #region Crate
        public static bool GetCrateDataList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWCrate> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWCrateCtrl.QueryPage(dcf, sqm, page, pageSize, ref dataList, ref errMsg))
            {
                return false;
            }
            pageCount = dcf.PageCount;
            rowCount = dcf.RowCount;
            return true;
        }

        #endregion

        #endregion

        #region set data

        #region Employ
        public static bool EditEmpyInfo(string empyCode, string password, string empyName, string empyType, int funcGroup, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWEmploy.getPasswordColumn(), password);
            suc.Add(TblMWEmploy.getEmpyNameColumn(), empyName);
            suc.Add(TblMWEmploy.getEmpyTypeColumn(), empyType);
            suc.Add(TblMWEmploy.getFuncGroupIdColumn(), funcGroup);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);

            if (!TblMWEmployCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool AddNewEmploy(TblMWEmploy empy, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWEmploy defineEmpy = null;
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.EmpyCode);
            if (!TblMWEmployCtrl.QueryOne(dcf, sqm, ref defineEmpy, ref errMsg))
            {
                return false;
            }
            if (defineEmpy != null)
            {
                errMsg = "已有当前编号员工";
                return false;
            }

            int updCount = 0;
            if (!TblMWEmployCtrl.Insert(dcf, empy, ref updCount, ref errMsg))
            {
                return false;
            }
            if (updCount == 0)
            {
                errMsg = "用户添加失败";
                return false;
            }

            return true;
        }
        public static bool ActiveEmploy(string empyCode, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            int updCount = 0;
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWEmploy.getStatusColumn(), TblMWEmploy.STATUS_ENUM_Active);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);
            if (!TblMWEmployCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool VoidEmploy(string empyCode, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWEmploy.getStatusColumn(), TblMWEmploy.STATUS_ENUM_Void);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);
            if (!TblMWEmployCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Car
        public static bool EditCarInfo(string carCode, string desc, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCar.getDescColumn(), desc);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCar.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carCode);
            if (!TblMWCarCtrl.Update(dcf, suc, sw,ref updCount, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool AddNewCar(TblMWCar car, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWCar defineCar = null;
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWCar.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, car.CarCode);
            if (!TblMWCarCtrl.QueryOne(dcf, sqm, ref defineCar, ref errMsg))
            {
                return false;
            }
            if (defineCar != null)
            {
                errMsg = "已有当前编号车辆";
                return false;
            }

            int updCount = 0;
            if (!TblMWCarCtrl.Insert(dcf, car, ref updCount, ref errMsg))
            {
                return false;
            }
            if (updCount == 0)
            {
                errMsg = "数据添加失败";
                return false;
            }
            return true;
        }
        public static bool ActiveCar(string carCode, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCar.getStatusColumn(), TblMWCar.STATUS_ENUM_Active);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCar.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carCode);

            if (!TblMWCarCtrl.Update(dcf, suc, sw,ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool VoidCar(string carCode, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCar.getStatusColumn(), TblMWCar.STATUS_ENUM_Void);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCar.getCarCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, carCode);

            if (!TblMWCarCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Vendor
        public static bool EditVendorInfo(string vendorCode, string vendor, string address, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWVendor.getVendorColumn(), vendor);
            suc.Add(TblMWVendor.getAddressColumn(), address);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWVendor.getVendorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, vendorCode);
            if (!TblMWVendorCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool AddNewVendor(TblMWVendor item, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWVendor defineItem = null;
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWVendor.getVendorCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, item.VendorCode);
            if (!TblMWVendorCtrl.QueryOne(dcf, sqm, ref defineItem, ref errMsg))
            {
                return false;
            }
            if (defineItem != null)
            {
                errMsg = LngRes.MSG_ExistCodeData;
                return false;
            }

            int updCount = 0;
            if (!TblMWVendorCtrl.Insert(dcf, item, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Waste
        public static bool EditWasteInfo(string wasteCode, string waste, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWWasteCategory.getWasteColumn(), waste);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWWasteCategory.getWasteCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wasteCode);
            if (!TblMWWasteCategoryCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool AddNewWaste(TblMWWasteCategory item, ref string errMsg)
        {

            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWWasteCategory defineItem = null;
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWWasteCategory.getWasteCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, item.WasteCode);
            if (!TblMWWasteCategoryCtrl.QueryOne(dcf, sqm, ref defineItem, ref errMsg))
            {
                return false;
            }
            if (defineItem != null)
            {
                errMsg = LngRes.MSG_ExistCodeData;
                return false;
            }

            int updCount = 0;
            if(!TblMWWasteCategoryCtrl.Insert(dcf,item,ref updCount,ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Crate
        public static bool EditCrateInfo(string crateCode, string desc, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCrate.getDescColumn(), desc);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCrate.getCrateCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, crateCode);
            if (!TblMWCrateCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool AddNewCrate(TblMWCrate item, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWCrate defineItem = null;
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWCrate.getCrateCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, item.CrateCode);
            if (!TblMWCrateCtrl.QueryOne(dcf, sqm, ref defineItem, ref errMsg))
            {
                return false;
            }
            if (defineItem != null)
            {
                errMsg = LngRes.MSG_ExistCodeData;
                return false;
            }

            int updCount = 0;
            if (!TblMWCrateCtrl.Insert(dcf, item, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool ActiveCrate(string crateCode, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCrate.getStatusColumn(), TblMWCrate.STATUS_ENUM_Active);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCrate.getCrateCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, crateCode);
            if (!TblMWCrateCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool VoidCrate(string crateCode, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWCrate.getStatusColumn(), TblMWCrate.STATUS_ENUM_Void);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWCrate.getCrateCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, crateCode);
            if (!TblMWCrateCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Depot
        public static bool EditDepotInfo(string depotCode, string desc, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            int updCount = 0;
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWDepot.getDescColumn(), desc);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWDepot.getDeptCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, depotCode);
            if (!TblMWDepotCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool AddNewDepot(TblMWDepot item, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWDepot defineItem = null;
            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(TblMWDepot.getDeptCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, item.DeptCode);
            if (!TblMWDepotCtrl.QueryOne(dcf, sqm, ref defineItem, ref errMsg))
            {
                return false;
            }
            if (defineItem != null)
            {
                errMsg = LngRes.MSG_ExistCodeData;
                return false;
            }

            int updCount = 0;
            if (!TblMWDepotCtrl.Insert(dcf, item, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }

        #endregion

        #endregion

        #region Common
        class LngRes
        {
            public const string MSG_ExistCodeData = "已有当前编号数据";
        }
        #endregion
    }
}
