using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.BaseModule;

namespace ComLib.db.BaseSys
{
    public class NextIdMng
    {
        #region Base

        public static bool GetNextId(DataCtrlInfo dcf, string key, ref int nextId, ref string errMsg)
        {
            return GetNextId(dcf, key, 1, ref nextId, ref errMsg);
        }
        public static bool GetNextId(DataCtrlInfo dcf, string key, int count, ref int nextId, ref string errMsg)
        {
            //if (count == 1)
            //{
            //    if (!GetNextId_FromDelPool(key, ref nextId, ref errMsg))
            //    {
            //        return false;
            //    }

            //    if (nextId != int.MinValue)
            //    {
            //        return true;
            //    }
            //}

            TblSysNextId oldItem = null;

            SqlWhere queryNextIdSW = new SqlWhere();
            queryNextIdSW.AddCompareValue(TblSysNextId.getIdNameColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, key);

            if(!TblSysNextIdCtrl.QueryOne(dcf, queryNextIdSW, ref oldItem, ref errMsg))
            {
                return false;
            }

            if (oldItem == null)
            {
                TblSysNextId newItem = new TblSysNextId();
                newItem.IdName = key;
                newItem.MinValue = 1;
                newItem.Increment = 1;
                newItem.MaxValue = 99999999;
                newItem.IdValue = 1 + count;

                string insertErrMsg = "";
                int defineCount = 0;

                if (!TblSysNextIdCtrl.Insert(dcf, newItem, ref defineCount, ref errMsg))
                {
                    //maybe data exist jsut this time.
                }
                else
                {
                    nextId = 1;
                    return true;
                }

                if (!TblSysNextIdCtrl.QueryOne(dcf, queryNextIdSW, ref oldItem, ref errMsg))
                {
                    return false;
                }

                if (oldItem == null)
                {
                    errMsg = insertErrMsg;
                    return false;
                }
            }

            int retryTimes = 0;

            while (true)
            {
                bool updated = false;

                if (!GetNextId_Update(dcf,oldItem, count, ref updated, ref errMsg))
                {
                    return false;
                }

                if (updated && oldItem.IdValue > 0)
                {
                    nextId = oldItem.IdValue;
                    return true;
                }

                retryTimes = retryTimes + 1;
                //LogMng.GetLog().PrintWarning(ClassName, "GetNextId", "DB is too busy to get next id[" + key + "].");

                if (retryTimes > 30)
                {
                    errMsg = "DB is very busy,please try later.";
                    return false;
                }

                System.Threading.Thread.Sleep(100);

                if (!TblSysNextIdCtrl.QueryOne(dcf, queryNextIdSW, ref oldItem, ref errMsg))
                {
                    return false;
                }

                if (oldItem == null)
                {
                    errMsg = "SysNextId record deleted[" + key + "].";
                    return false;
                }
            }


        }
        private static bool GetNextId_Update(DataCtrlInfo dcf, TblSysNextId oldItem, int count, ref bool updated, ref string errMsg)
        {
            //TblSysNextId updItem = new TblSysNextId();
            //updItem.IdValue = oldItem.IdValue + count;

            //SqlUpdateColumnList ucl = new SqlUpdateColumnList();
            //ucl.Add(TblQWSysNextId.GetIdValueColumn());

            //SqlWhere wl = new SqlWhere(DbInfoMng.GetDataDb());
            //wl.AddStringCompareValue(TblQWSysNextId.GetIdNameColumn(), SqlWhereCompareEnum.Equals, oldItem.IdName);
            //wl.AddIntCompareValue(TblQWSysNextId.GetIdValueColumn(), SqlWhereCompareEnum.Equals, oldItem.IdValue);

            //if (!TblQWSysNextIdCtrl.Update(DbInfoMng.GetDataDb(), null, ucl, updItem, wl, ref updCnt, ref errMsg))
            //{
            //    return false;
            //}

            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblSysNextId.getIdValueColumn(), oldItem.IdValue + count);

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblSysNextId.getIdNameColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, oldItem.IdName);
            sw.AddCompareValue(TblSysNextId.getIdValueColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, oldItem.IdValue);

            int updCnt = 0;
            if (!TblSysNextIdCtrl.Update(dcf, suc, sw, ref updCnt, ref errMsg))
            {
                return false;
            }
            updated = (updCnt > 0);
            return true;
        }

        #endregion
    }
}
