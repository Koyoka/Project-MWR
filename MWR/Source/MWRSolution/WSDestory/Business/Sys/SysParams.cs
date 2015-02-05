using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.WSDestory.Business.Sys
{
    public class SysParams
    {
        public string GetSysWeightUnit()
        {
            return MWParams.GetWeightUnit();
        }
        public decimal GetAllowDiffWeight()
        {
            return MWParams.GetAllowDiffWeight();
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
