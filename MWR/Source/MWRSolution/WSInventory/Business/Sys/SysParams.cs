﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.WSInventory.Business.Sys
{
    public class SysParams
    {
        public string GetSysWeightUnit()
        {
            return MWParams.GetWeightUnit();
        }
        //public decimal GetAllowDiffWeight()
        //{
        //    return MWParams.GetAllowDiffWeight();
        //}
        public string GetCrateCodeMask()
        {
            return MWParams.GetCrateCodeMask();
        }

        private static SysParams _sysParams = null;
        public static SysParams GetInstance()
        {
            if (_sysParams == null)
            {
                _sysParams = new SysParams();
            }
            return _sysParams;
        }
    }
}
