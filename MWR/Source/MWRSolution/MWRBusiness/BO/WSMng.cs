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

        #region get data
        public static bool GetWorkstation(int page, int pageSize, ref long pageCount, ref long rowCount, ref List<TblMWWorkStation> wsList, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            SqlQueryMng sqm = new SqlQueryMng();

            if (!TblMWWorkStationCtrl.QueryPage(dcf,sqm,page,pageSize,ref wsList,ref errMsg))
            {
                return false;
            }
            rowCount = dcf.RowCount;
            pageCount = dcf.PageCount;
            return true;
        }

        #endregion

        #region update

        public static bool CreateMWSAccessKeyAndSecretKey(ref string accessKey, ref string secretKey, ref string errMsg)
        {
            string ak = Guid.NewGuid().ToString();
            string ek = Guid.NewGuid().ToString();

            accessKey = ak.Replace("-","");
            secretKey = ek.Replace("-", "");
            return true;
        }

        public static bool CreateMWSInitInformation(ref string code,ref string accessKey,ref string secretKey,ref string errMsg)
        {
            string ak = "", sk = "";

            DataCtrlInfo dcf = new DataCtrlInfo();

            #region valid db exist un use MobileCode
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWWorkStation.getWSTypeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, TblMWWorkStation.WSTYPE_ENUM_WaitWorkStation);

                List<TblMWWorkStation> itemList = null;
                if (!TblMWWorkStationCtrl.QueryMore(dcf, sqm, ref itemList, ref errMsg))
                {
                    return false;
                }

                if (itemList.Count != 0)
                {
                    TblMWWorkStation ws = itemList[0];
                    code = ws.WSCode;
                    accessKey = ws.AccessKey;
                    secretKey = ws.SecretKey;
                    return true;
                }
            }
            #endregion

            #region add new mobilecode
            {
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

                
                int updCount = 0;
                if (!TblMWWorkStationCtrl.Insert(dcf, ws, ref updCount, ref errMsg))
                {
                    return false;
                }

                code = ws.WSCode;
                accessKey = ws.AccessKey;
                secretKey = ws.SecretKey;
            }
            #endregion

            return true;
        }
        public static bool RegistMWSInitInformation(string wsCode,string accessKey,string secretKey,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWWorkStation.getWSTypeColumn(), TblMWWorkStation.WSTYPE_ENUM_MobWorkStation);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWWorkStation.getWSCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, wsCode);
            sw.AddCompareValue(TblMWWorkStation.getAccessKeyColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, accessKey);
            sw.AddCompareValue(TblMWWorkStation.getSecretKeyColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, secretKey);
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

        #endregion

    }
}
