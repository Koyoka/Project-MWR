using System;
using System.Collections.Generic;
using System.Text;
using ComLib.db.BaseModule;

namespace ComLib.db.BaseSys
{
    public class SysParams
    {
        private static object _instanceLocker = new object();
        private static SysParams _sysparams;
        public static SysParams GetInstance()
        {
            if (_sysparams == null)
            {
                lock (_instanceLocker)
                {
                    _sysparams = new SysParams();
                }
            }

            return _sysparams;
        }

        #region Base
        private object _locker = new object();
        private Dictionary<string, string> _allParaList = null;

        public string GetValue(DataCtrlInfo dcf,string key)
        {
            if (_allParaList == null)
            {
                lock (_locker)
                {
                    if (_allParaList == null)
                    {
                        string errMsg = "";
                        
                        SqlQueryMng sqm = new SqlQueryMng();
                        sqm.QueryColumn.Add(TblSysParameter.getParameterNameColumn());
                        sqm.QueryColumn.Add(TblSysParameter.getParameterValueColumn());
                        sqm.Condition.OrderBy.Add(TblSysParameter.getParameterNameColumn());

                        List<TblSysParameter> itemList = new List<TblSysParameter>();

                        if (!TblSysParameterCtrl.QueryMore(dcf, new SqlQueryMng(), ref itemList, ref errMsg))
                        {
                            return "";
                        }

                        _allParaList = new Dictionary<string, string>();

                        foreach (TblSysParameter item in itemList)
                        {
                            _allParaList.Add(item.ParameterName.ToUpper(), item.ParameterValue);
                        }
                    }
                }
            }

            {
                try
                {
                    string value = _allParaList[key.ToUpper()];
                    return value;
                }
                catch
                {
                    return "";
                }
            }
        }

        public bool SetValue(DataCtrlInfo dcf,string key, string value, ref string errMsg)
        {
            GetValue(dcf, key);
            lock (_locker)
            {
                key = key.ToUpper();

                TblSysParameter item = new TblSysParameter();
                item.ParameterName = key;
                item.ParameterValue = value;

                int updateCnt = 0;
                SqlUpdateColumn suc = new SqlUpdateColumn();
                suc.Add(TblSysParameter.getParameterValueColumn());
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblSysParameter.getParameterNameColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, key);
                if (!TblSysParameterCtrl.Update(dcf, item, suc, sw, ref updateCnt, ref errMsg))
                {
                    return false;
                }

                if (updateCnt != 0)
                {
                    if (_allParaList.ContainsKey(key))
                    {
                        _allParaList[key] = value;
                    }
                    else
                    {
                        _allParaList.Add(key, value);
                    }
                    return true;
                }

                if (!TblSysParameterCtrl.Insert(dcf, item, ref updateCnt, ref errMsg))
                {
                    return false;
                }

                if (_allParaList.ContainsKey(key))
                {
                    _allParaList[key] = value;
                }
                else
                {
                    _allParaList.Add(key, value);
                }

                return true;
            }
        }

        //private bool GetValueByRealTime(string key, ref string value, ref string errMsg)
        //{
        //    TblQWSysParameter item = null;

        //    if (!TblQWSysParameterCtrl.QueryOneByPK(DbInfoMng.GetDataDb(), null, key, ref item, ref errMsg))
        //    {
        //        return false;
        //    }

        //    if (item == null)
        //    {
        //        value = "";
        //        return true;
        //    }
        //    else
        //    {
        //        value = item.ParameterValue;
        //        return true;
        //    }
        //}

        //public bool RefreshAllData(ref string errMsg)
        //{
        //    lock (_locker)
        //    {
        //        TblQWSysParameter[] list = null;

        //        SqlQuerySqlMng qsm = new SqlQuerySqlMng(DbInfoMng.GetDataDb());
        //        qsm.Column.AddColumn(TblQWSysParameter.GetParameterNameColumn());
        //        qsm.Column.AddColumn(TblQWSysParameter.GetParameterValueColumn());
        //        qsm.Condition.OrderBy.AddColumn(TblQWSysParameter.GetParameterNameColumn());

        //        if (!TblQWSysParameterCtrl.QueryMore(DbInfoMng.GetDataDb(), null, qsm, ref list, ref errMsg))
        //        {
        //            return false;
        //        }

        //        _allParaList = new Dictionary<string, string>();

        //        foreach (TblQWSysParameter item in list)
        //        {
        //            _allParaList.Add(item.ParameterName.ToUpper(), item.ParameterValue);
        //        }
        //    }

        //    return true;
        //}

        #endregion

    }
}
