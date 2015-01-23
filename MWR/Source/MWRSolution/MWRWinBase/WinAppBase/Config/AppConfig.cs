using System;
using System.Collections.Generic;
using System.Text;

namespace YRKJ.MWR.WinBase.WinAppBase.Config
{
    public class AppConfig
    {
        #region WebService

        private string _serviceRoot = "";
        public string ServiceRoot
        {
            get { return _serviceRoot; }
            set { _serviceRoot = value; }
        }

        #endregion

        private string _wsCode = "";
        public string WSCode
        {
            get { return _wsCode; }
            set { _wsCode = value; }
        }


        #region DataBase

        private string _dBServerName = "";
        public string DBServerName
        {
            get
            {
                return _dBServerName;
            }
            set
            {
                _dBServerName = value;
            }
        }

        private string _dBUserName = "";
        public string DBUserName
        {
            get
            {
                return _dBUserName;
            }
            set
            {
                _dBUserName = value;
            }
        }

        private string _dBPassword = "";
        public string DBPassword
        {
            get
            {
                return _dBPassword;
            }
            set
            {
                _dBPassword = value;
            }
        }

        //private string _dBDatabaseNumber = "";
        //public string DBDatabaseNumber
        //{
        //    get
        //    {
        //        return _dBDatabaseNumber;
        //    }
        //    set
        //    {
        //        _dBDatabaseNumber = value;
        //    }
        //}
        #endregion

    }
}
