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
    }
}
