using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRKJ.MWR.Business.BaseData;

namespace YRKJ.MWR.WSInventory.Business.Sys
{
    public class SysCacheData
    {
        private List<TblMWDepot> _depotList = null;
        public bool GetDepotList(ref List<TblMWDepot> dataList,ref string errMsg)
        {
            if (_depotList == null)
            {
                if (!BaseDataMng.GetAllDepotList(ref _depotList, ref errMsg))
                {
                    return false;
                }
            }
            dataList = _depotList;
            return true;

        }

        private static SysCacheData _sysCacheData = null;
        public static SysCacheData GetInstance()
        {
            if (_sysCacheData == null)
            {
                _sysCacheData = new SysCacheData();
            }

            return _sysCacheData;
        }
        
    }
}
