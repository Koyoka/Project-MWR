using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRKJ.MWR.WSDestory.Business.Sys
{
    public class SysInfo
    {
        public int SystemVersion = 1;
        public TblMWEmploy Employ = null;

        private SysInfo _sysInfo = null;
        public SysInfo GetInstance()
        {
            if (_sysInfo == null)
            {
                _sysInfo = new SysInfo();
            }
            return _sysInfo;
        }
    }
}
