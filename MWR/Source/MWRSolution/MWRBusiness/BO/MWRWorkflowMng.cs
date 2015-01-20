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
        public static bool CarOutToReover(
            string carCode,
            string driverCode,
            string inspectorCode,
            string MWSCode,
            ref string errMsg)
        {
            int updCount = 0;

            DataCtrlInfo dcf = new DataCtrlInfo();
            string driver = "";
            string inspector = "";

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

            if (!TblMWCarDispatchCtrl.Insert(dcf, item, ref updCount, ref errMsg))
            {
                return false;
            }

            if (updCount == 0)
            {
                errMsg = ErrorMng.GetDBError(ClassName, "CarOutToReover", "数据未添加");
                return false;
            }

            return true;
        }
        #endregion

        #region 2.1 car recover resposne inv workstation

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
        public static bool GetTodayCarDispatchDataList(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWCarDispatch> dataList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlQueryMng sqm = new SqlQueryMng();

            DateTime today = SqlDBMng.GetDBNow();
            sqm.Condition.Where.AddDateTimeCompareValue(
                TblMWCarDispatch.getOutDateColumn(), 
                SqlCommonFn.SqlWhereCompareEnum.Equals, 
                today, 
                SqlCommonFn.SqlWhereDateTimeFormatEnum.YMD);
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
