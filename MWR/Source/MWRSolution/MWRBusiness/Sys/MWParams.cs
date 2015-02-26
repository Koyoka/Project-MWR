using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db.BaseSys;
using ComLib.db;

namespace YRKJ.MWR.Business.Sys
{
    public class MWParams
    {
        #region Weight Unit
        private static string _weightUnit = null;
        public static bool SetWeightUnit(string value,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            if(!SysParams.GetInstance().SetValue(dcf, "WeightUnit", value, ref errMsg))
            {
                return false;
            }
            _weightUnit = value;
            return true;
        }
        public static string GetWeightUnit()
        {
            if (_weightUnit == null)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                _weightUnit = SysParams.GetInstance().GetValue(dcf, "WeightUnit");

            }
            if (string.IsNullOrEmpty(_weightUnit))
            {
                _weightUnit = "kg";
            }
            return _weightUnit;
        }
        #endregion

        #region Allow Diff Weight
        private static decimal _allowDiffWeight = -1;
        public static bool SetAllowDiffWeight(decimal value,ref string errMsg)
        {
             DataCtrlInfo dcf = new DataCtrlInfo();

             if (!SysParams.GetInstance().SetValue(dcf, "AllowDiffWeight", value + "", ref errMsg))
            {
                return false;
            }
            _allowDiffWeight = value;
            return true;
        }
        public static decimal GetAllowDiffWeight()
        {
            string defineVal = "";
            if (_allowDiffWeight == -1)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                defineVal = SysParams.GetInstance().GetValue(dcf, "AllowDiffWeight");
                _allowDiffWeight = ComLib.ComFn.StringToDecimal(defineVal);
            }
            if (string.IsNullOrEmpty(defineVal))
            {
                _allowDiffWeight = 0;
            }
            return _allowDiffWeight;
        }

        #endregion

        #region CrateCodeMask
        private const string _defaultCrateCodeMask = "HX###";
        private static string _crateCodeMask = null;
        public static bool SetCrateCodeMask(string value, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            if (!SysParams.GetInstance().SetValue(dcf, "CrateCodeMask", value, ref errMsg))
            {
                return false;
            }
            _crateCodeMask = value;
            return true;
        }
        public static string GetCrateCodeMask()
        {
            if (_crateCodeMask == null)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                _crateCodeMask = SysParams.GetInstance().GetValue(dcf, "CrateCodeMask");
                
            }

            if (string.IsNullOrEmpty(_crateCodeMask))
            {
                string errMsg = "";
                if (!SetCrateCodeMask(_defaultCrateCodeMask, ref errMsg))
                {
                    // nothing
                }
                _crateCodeMask = _defaultCrateCodeMask;
            }
            return _crateCodeMask;
        }
        #endregion
    }
}
