using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComLib.db.BaseSys;
using ComLib.db;
using ComLib.Log;

namespace YRKJ.MWR.Business.Sys
{
    public class MWNextIdMng
    {
        public const string ClassName = "YRKJ.MWR.Business.Sys.MWNextIdMng";

        public static int GetCarDispatchNextId()
        {
            DataCtrlInfo dcf = new DataCtrlInfo();;
            string errMsg = "";
            int nextId = 0;
            if (!NextIdMng.GetNextId(dcf, "CarDispatch", ref nextId, ref errMsg))
            {
                LogMng.GetLog().PrintError(ClassName, "GetCarDispatchNextId", new Exception(errMsg));
                return 0;
            }

            return nextId;
        }
    }
}
