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
