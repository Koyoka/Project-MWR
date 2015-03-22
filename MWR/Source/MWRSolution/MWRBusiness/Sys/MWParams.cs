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
       


        #region recover
        private static decimal _allowDiffWeight_recover = -1;
        public static bool SetAllowDiffWeight_Recover(decimal value, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            if (!SysParams.GetInstance().SetValue(dcf, "AllowDiffWeight_Recover", value + "", ref errMsg))
            {
                return false;
            }
            _allowDiffWeight_recover = value;
            return true;
        }
        public static decimal GetAllowDiffWeight_Recover()
        {
            if (_allowDiffWeight_recover == -1)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                string defineVal = SysParams.GetInstance().GetValue(dcf, "AllowDiffWeight_Recover");
                _allowDiffWeight_recover = ComLib.ComFn.StringToDecimal(defineVal);
            }
            return _allowDiffWeight_recover;
        }
        #endregion

        #region post
        private static decimal _allowDiffWeight_post = -1;
        public static bool SetAllowDiffWeight_Post(decimal value, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            if (!SysParams.GetInstance().SetValue(dcf, "AllowDiffWeight_Post", value + "", ref errMsg))
            {
                return false;
            }
            _allowDiffWeight_post = value;
            return true;
        }
        public static decimal GetAllowDiffWeight_Post()
        {
            if (_allowDiffWeight_post == -1)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                string defineVal = SysParams.GetInstance().GetValue(dcf, "AllowDiffWeight_Post");
                _allowDiffWeight_post = ComLib.ComFn.StringToDecimal(defineVal);
            }
            return _allowDiffWeight_post;
        }
        #endregion

        #region destory
        private static decimal _allowDiffWeight_destory = -1;
        public static bool SetAllowDiffWeight_Destory(decimal value, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            if (!SysParams.GetInstance().SetValue(dcf, "AllowDiffWeight_Destory", value + "", ref errMsg))
            {
                return false;
            }
            _allowDiffWeight_destory = value;
            return true;
        }
        public static decimal GetAllowDiffWeight_Destory()
        {
            if (_allowDiffWeight_destory == -1)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                string defineVal = SysParams.GetInstance().GetValue(dcf, "AllowDiffWeight_Destory");
                _allowDiffWeight_destory = ComLib.ComFn.StringToDecimal(defineVal);
            }
            return _allowDiffWeight_destory;
        }
        #endregion

        #region Identical
        private static int _allowDiffWeightAsIdentical = -1;
        public static bool SetAllowDiffWeightAsIdentical(bool value, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int defineSaveValue = value ? 1 : 0;
            if (!SysParams.GetInstance().SetValue(dcf, "AllowDiffWeightAsIdentical", defineSaveValue + "", ref errMsg))
            {
                return false;
            }
            _allowDiffWeightAsIdentical = defineSaveValue;
            return true;
        }
        public static bool GetAllowDiffWeightAsIdentical()
        {
            string defineVal = "";
            if (_allowDiffWeightAsIdentical == -1)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                defineVal = SysParams.GetInstance().GetValue(dcf, "AllowDiffWeightAsIdentical");
                _allowDiffWeightAsIdentical = ComLib.ComFn.StringToInt(defineVal);
            }
            return _allowDiffWeightAsIdentical == 0 ? false : true;
        }

        private static decimal _allowDiffWeight = -1;
        public static bool SetAllowDiffWeight_All(decimal value, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            if (!SysParams.GetInstance().SetValue(dcf, "AllowDiffWeight", value + "", ref errMsg))
            {
                return false;
            }
            _allowDiffWeight = value;
            return true;
        }
        public static decimal GetAllowDiffWeight_All()
        {
            string defineVal = "";
            if (_allowDiffWeight == -1)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                defineVal = SysParams.GetInstance().GetValue(dcf, "AllowDiffWeight");
                _allowDiffWeight = ComLib.ComFn.StringToDecimal(defineVal);
            }
            return _allowDiffWeight;
        }

        #endregion

       
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

        #region permit
        private const string _defaultAdministrator = "administrator";
        private static string _administrator = null;
        public static bool SetAdministrator(string value, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            if (!SysParams.GetInstance().SetValue(dcf, "Administrator", value, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static string GetAdministrator()
        {
            if (_administrator == null)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                _administrator = SysParams.GetInstance().GetValue(dcf, "Administrator");
            }

            if (string.IsNullOrEmpty(_administrator))
            {
                string errMsg = "";
                if (!SetAdministrator(_defaultAdministrator, ref errMsg))
                {
                    // nothing
                }
                _administrator = _defaultAdministrator;
            }
            return _administrator;
        }

        private const string _defulatAdministratorPassword = "-101868";
        private static string _administratorPassword = null;
        public static bool SetAdministratorPassword(string value, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            value = ComLib.db.SqlCommonFn.EncryptString(value);
            if (!SysParams.GetInstance().SetValue(dcf, "AdministratorPassword", value, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static string GetAdministratorPassword()
        {
            if (_administratorPassword == null)
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                _administratorPassword = SysParams.GetInstance().GetValue(dcf, "AdministratorPassword");
                _administratorPassword = ComLib.db.SqlCommonFn.DecryptString(_administratorPassword);
            }

            if (string.IsNullOrEmpty(_administratorPassword))
            {
                string errMsg = "";
                if (!SetAdministratorPassword(_defulatAdministratorPassword, ref errMsg))
                {
                    // nothing
                }
                _administratorPassword = _defulatAdministratorPassword;
            }
            return _administratorPassword;
        }

        #endregion
    }
}
