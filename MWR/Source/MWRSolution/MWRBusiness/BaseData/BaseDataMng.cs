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

        #region Employ
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

        #endregion
    }
}
