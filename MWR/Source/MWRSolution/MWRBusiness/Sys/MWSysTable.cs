using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;

namespace YRKJ.MWR.Business.Sys
{
    public class MWSysTable
    {
        public static bool InitTxnTable(ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlWhere sw = new SqlWhere();
            int updCount = 0;

            dcf.BeginTrans();
            TblMWCarDispatchCtrl.Delete(dcf, sw, ref updCount, ref errMsg);
            TblMWTxnDetailCtrl.Delete(dcf, sw, ref updCount, ref errMsg);
            TblMWTxnRecoverHeaderCtrl.Delete(dcf, sw, ref updCount, ref errMsg);
            TblMWTxnPostHeaderCtrl.Delete(dcf, sw, ref updCount, ref errMsg);
            TblMWTxnDestroyHeaderCtrl.Delete(dcf, sw, ref updCount, ref errMsg);

            TblMWTxnLogCtrl.Delete(dcf, sw, ref updCount, ref errMsg);

            TblMWInventoryCtrl.Delete(dcf, sw, ref updCount, ref errMsg);
            TblMWInventoryTrackCtrl.Delete(dcf, sw, ref updCount, ref errMsg);
            TblMWInvAuthorizeCtrl.Delete(dcf, sw, ref updCount, ref errMsg);
            TblMWInvAuthorizeAttachCtrl.Delete(dcf, sw, ref updCount, ref errMsg);

            
            TblSysNextIdCtrl.Delete(dcf, sw, ref updCount, ref errMsg);
            int[] updCounts = null;
            if (!dcf.Commit(ref updCounts, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool InitSysBaseData(
            List<TblMWEmploy> empyList,
            List<TblMWVendor> vendorList,
            List<TblMWWasteCategory> wasteList,
            List<TblMWCar> carList,
            List<TblMWDepot> depotList,
            List<TblMWCrate> crateList,
            ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            dcf.BeginTrans();

            SqlWhere sw = new SqlWhere();
            #region employ
            if (empyList.Count > 0)
            {
                if (!TblMWEmployCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }

                List<TblMWEmploy> defineEmpyList = null;
                if (!TblMWEmployCtrl.QueryMore(dcf, new SqlQueryMng(), ref defineEmpyList, ref errMsg))
                {
                    return false;
                }

                foreach (var item in empyList)
                {
                    // keep exist employ's funcgroup
                    defineEmpyList.Find(x =>
                    {
                        if (x.EmpyCode.Equals(item.EmpyCode))
                        {
                            item.FuncGroupId = x.FuncGroupId;
                            return true;
                        }
                        return false;
                    });
                    if (!TblMWEmployCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region vendor
            if (vendorList.Count > 0)
            {
                if (!TblMWVendorCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
                foreach (var item in vendorList)
                {
                    if (!TblMWVendorCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region waste
            if (wasteList.Count > 0)
            {
                if (!TblMWWasteCategoryCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
                foreach (var item in wasteList)
                {
                    if (!TblMWWasteCategoryCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region car
            if (carList.Count > 0)
            {
                if (!TblMWCarCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
                foreach (var item in carList)
                {
                    if (!TblMWCarCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region depot
            if (depotList.Count > 0)
            {
                if (!TblMWDepotCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
                foreach (var item in depotList)
                {
                    if (!TblMWDepotCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
            }
            #endregion

            #region crate
            if (crateList.Count > 0)
            {
                if (!TblMWCrateCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
                foreach (var item in crateList)
                {
                    if (!TblMWCrateCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
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
    }
}
