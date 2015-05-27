using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRKJ.MWR.WinBase.WinAppBase.Config;

namespace MWRSyncMng
{
    public class SysInfo
    {
        public const int SystemVersion = 1;
        public AppConfig Config = null;

        private static SysInfo _sysInfo = null;
        public static SysInfo GetInstance()
        {
            if (_sysInfo == null)
            {
                _sysInfo = new SysInfo();
            }
            return _sysInfo;
        }
    }
}
