using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using ComLib;

namespace YRKJ.MWR.BackOffice.Services
{
    public partial class MWRecoverServer : System.Web.UI.Page
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Services.MWRecoverServer";
        
        private string _action = "";
        private string _value = "";
        private string _accessKey = "[ server access key ]";
        private string _secretKey = "[ server secret key ]";

        private const string RequestMethod_RecoverInventorySubmit = "RecoverInventorySubmit";

        protected void Page_Load(object sender, EventArgs e)
        {
            string errMsg = "";
            if (!IsPostBack)
            {
                if (!InitPage(ref errMsg))
                {
                    // do error thing

                    //Request.Headers.Get(
                }
            }

            //Request.HttpMethod
        }

        #region Events

        #endregion

        #region Functions

        private bool InitPage(ref string errMsg)
        {
            if (!LoadData(ref errMsg))
            {
                return false;
            }

            if (_action.Equals(RequestMethod_RecoverInventorySubmit))
            {
                return RecoverInventorySubmit(ref errMsg);
            }

            return true;
        }

        private bool LoadData(ref string errMsg)
        {
            _action = WebAppFn.SafeFormString("action");
            _value = WebAppFn.SafeFormString("value");

            if (string.IsNullOrEmpty(_action) || string.IsNullOrEmpty(_value))
            {
                errMsg = LngRes.MSG_InvalidParams;
                return false;
            }
            return true;
        }

        private bool RecoverInventorySubmit(ref string errMsg)
        {
            //_value;
            string defineVal = ComFn.DecryptStringBy64(_value);

            return true;
            
        }

        #endregion

        #region PageDatas

        #endregion

        #region Common
        

        private class LngRes
        {
            public const string MSG_FormName = "";
            public const string MSG_InvalidParams = "无效的提交参数";
        }

        public class HttpRequestHelper
        {
            public static bool Post(string p,ref string errMsg)
            {

                return true;
            }
        }

        #endregion
    }
}