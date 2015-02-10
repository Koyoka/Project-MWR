using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRKJ.MWR.Business.BO
{
    public class WSMng
    {
        #region MWS

        public static bool CreateMWSAccessKeyAndSecretKey(ref string accessKey, ref string secretKey, ref string errMsg)
        {
            string ak = Guid.NewGuid().ToString();
            string ek = Guid.NewGuid().ToString();

            accessKey = ak.Replace("-","");
            secretKey = ek.Replace("-", "");
            return true;
        }

        #endregion

    }
}
