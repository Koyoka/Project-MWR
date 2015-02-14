using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.Business.BO
{
    public class WSMng
    {
        #region MWS

        public static bool CreateMWSAccessKeyAndSecretKey(ref string accessKey, ref string secretKey, ref string errMsg)
        {
            string ak = Guid.NewGuid().ToString();
            string ek = Guid.NewGuid().ToString();

            accessKey = ak.Replace("-","");
            secretKey = ek.Replace("-", "");
            return true;
        }

        public static bool CreateMWSInitInformation(ref string errMsg)
        {
            string ak = "", sk = "";
            if (!CreateMWSAccessKeyAndSecretKey(ref ak, ref sk, ref errMsg))
            {
                return false;
            }

            string wsCode = MWNextIdMng.getWSCode(BizBase.GetInstance().WSCodeMask);
            TblMWWorkStation ws = new TblMWWorkStation();
            ws.WSCode = wsCode;
            ws.WSType = TblMWWorkStation.WSTYPE_ENUM_WaitWorkStation;
            ws.Desc = "手机终端" + wsCode;
            ws.AccessKey = ak;
            ws.SecretKey = sk;

            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;
            if (!TblMWWorkStationCtrl.Insert(dcf, ws, ref updCount, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool RegistMWSInitInformation(string wsCode,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWWorkStation.getWSTypeColumn(), TblMWWorkStation.WSTYPE_ENUM_MobWorkStation);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWWorkStation.getWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wsCode);
            sw.AddCompareValue(TblMWWorkStation.getWSTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWWorkStation.WSTYPE_ENUM_WaitWorkStation);

            int updCount = 0;
            if (!TblMWWorkStationCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }

            if (updCount == 0)
            {
                errMsg = "该号已被注册，请重新生成注册号";
                return false;
            }

            return true;
        }

        #endregion

    }
}
