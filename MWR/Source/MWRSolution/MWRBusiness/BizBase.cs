using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRKJ.MWR.Business
{
    public class BizBase
    {
        private const string defaultTxnNumMask = "##########";
        private string _txnNumMask = null;
        public string TxnNumMask
        {
            get {

                return string.IsNullOrEmpty(_txnNumMask) ? defaultTxnNumMask : _txnNumMask;
            }
        }

        private const string defaultWSCodeMask = "MWS####";
        private string _wsCodeMask = null;
        public string WSCodeMask
        {
            get { return _wsCodeMask; }
            set { _wsCodeMask = value; }
        }

        private string _decimalFormatString = "f2";
        public string DecimalFormatString
        {
            get { return _decimalFormatString; }
        }

        private string _dateTimeFormatString = "yyyy-MM-dd HH:mm";
        public string DateTimeFormatString
        {
            get { return _dateTimeFormatString; }
        }


        private static BizBase _bizBase = null;
        public static BizBase GetInstance()
        {
            if (_bizBase == null)
            {
                _bizBase = new BizBase();
            }

            return _bizBase;
        }
             

    }
}
