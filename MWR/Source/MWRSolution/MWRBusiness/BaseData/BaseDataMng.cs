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

        #region WasteCategory
        public static bool GetWasteCategoryData(ref List<TblMWWasteCategory> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();
            if (!TblMWWasteCategoryCtrl.QueryMore(dcf, sqm, ref dataList, ref errMsg))
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Vendor

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

        #endregion

        #region Car
        public static bool GetNoOutCarDataList(ref List<TblMWCar> dataList,ref string errMsg)
        {
            dataList = new List<TblMWCar>();

            DataCtrlInfo dcf = new DataCtrlInfo();
            
            SqlQueryMng sqm = new SqlQueryMng();
            SqlWhere sw = new SqlWhere();
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

        public static bool GetAllDepotList(ref List<TblMWDepot> depotList, ref string errMsg)
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
    }
}
