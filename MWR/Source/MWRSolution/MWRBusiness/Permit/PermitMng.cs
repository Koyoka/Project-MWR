using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using ComLib.db;
using YRKJ.MWR.Business.BaseData;

namespace YRKJ.MWR.Business.Permit
{
    public class PermitMng
    {
        public const string ClassName = "YRKJ.MWR.Business.Permit.PermitMng";

        private const int ADMINISTRATOR_DEFAULT_GROUPID = -1;
        private const int BACKOFFICE_DEFAULT_GROUPDID = -2;
        private const int INVENTORY_DEFAULT_GROUPID = -3;
        private const int DESTROY_DEFAULT_GROUPID = -4;
        #region Common
        public static string GetWSIFuncTag(string tag)
        {
            return "Inventory-" + tag;
        }
        public static string GetWSDFuncTag(string tag)
        {
            return "Destroy-" + tag;
        }
        public static string GetBOFuncTag(string tag)
        {
            return "BackOffice" + tag;
        }

        #endregion

        public static bool GetEmployFunctionPremiess(string empyCode, ref List<VewEmployFunctionGroupDetail> funcs, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            TblMWEmploy empy = null;
            #region valid data
            if (!BaseDataMng.GetEmpyData(empyCode, ref empy, ref errMsg))
            {
                return false;
            }
            if (empy == null)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyCode;
                return false;
            }
            #endregion

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getUserGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.UserGroupId);
            if (!VewEmployFunctionGroupDetailCtrl.QueryMore(dcf, sqm, ref funcs, ref errMsg))
            {
                return false;
            }

            return true;
        }

        public static bool CheckEmployFunctionPremiess(string empyCode, string funcTag, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            TblMWEmploy empy = null;
            #region valid data
            if (!BaseDataMng.GetEmpyData(empyCode, ref empy, ref errMsg))
            {
                return false;
            }
            if (empy == null)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyCode;
                return false;
            }
            #endregion

            SqlQueryMng sqm = new SqlQueryMng();
            sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getUserGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.UserGroupId);
            sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, funcTag);

            VewEmployFunctionGroupDetail data = null;
            if (!VewEmployFunctionGroupDetailCtrl.QueryOne(dcf,sqm,ref data,ref errMsg))
            {
                return false;
            }
            if (data == null)
            {
                errMsg = LngRes.MSG_Valid_NoPremiess;
                return false;
            }
            return true;
        }

        #region WS
        public static bool WSILogin(string empyCode, string password, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWEmploy empy = null;
            #region valid data
            if (!BaseDataMng.GetEmpyData(empyCode, ref empy, ref errMsg))
            {
                return false;
            }
            if (empy == null)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyCode;
                return false;
            }

            string encrytPassword = "";
#if DEBUG
            encrytPassword = password;
#else
            encrytPassword = SqlCommonFn.EncryptString(password);
#endif
            if (empy.Password != encrytPassword)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyPassword;
                return false;
            }
            #endregion

            //check system default premit administrator
            if (empy.UserGroupId == ADMINISTRATOR_DEFAULT_GROUPID)
            {
                return true;
            }

            //check system default premit wsi
            if (empy.UserGroupId == INVENTORY_DEFAULT_GROUPID)
            {
                return true;
            }

            string FUNC_NAME = GetWSIFuncTag("Main");

            VewEmployFunctionGroupDetail funcDetail = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getUserGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.UserGroupId);
                sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, FUNC_NAME);
                if(!VewEmployFunctionGroupDetailCtrl.QueryOne(dcf,sqm,ref funcDetail,ref errMsg))
                {
                    return false;
                }

                if (funcDetail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoPremiess;
                    return false;
                }
            }

            return true;
        }
        public static bool WSDLogin(string empyCode, string password, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWEmploy empy = null;
            #region valid data
            if (!BaseDataMng.GetEmpyData(empyCode, ref empy, ref errMsg))
            {
                return false;
            }
            if (empy == null)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyCode;
                return false;
            }
            
            string encrytPassword = "";
#if DEBUG
            encrytPassword = password;
#else
            encrytPassword = SqlCommonFn.EncryptString(password);
#endif
            if (empy.Password != encrytPassword)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyPassword;
                return false;
            }
            #endregion
                      
            //check system default premit administrator
            if (empy.UserGroupId == ADMINISTRATOR_DEFAULT_GROUPID)
            {
                return true;
            }

            //check system default premit wsi
            if (empy.UserGroupId == DESTROY_DEFAULT_GROUPID)
            {
                return true;
            }

            string FUNC_NAME = GetWSDFuncTag("Main");

            VewEmployFunctionGroupDetail funcDetail = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getUserGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.UserGroupId);
                sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, FUNC_NAME);
                if (!VewEmployFunctionGroupDetailCtrl.QueryOne(dcf, sqm, ref funcDetail, ref errMsg))
                {
                    return false;
                }

                if (funcDetail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoPremiess;
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region BO
        public static bool BOLogin(string empyCode, string password, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWEmploy empy = null;
            #region valid data
            if (!BaseDataMng.GetEmpyData(empyCode, ref empy, ref errMsg))
            {
                return false;
            }
            if (empy == null)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyCode;
                return false;
            }

            string encrytPassword = "";
#if DEBUG
            encrytPassword = password;
#else
            encrytPassword = SqlCommonFn.EncryptString(password);
#endif
            if (empy.Password != encrytPassword)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyPassword;
                return false;
            }
            #endregion

            //check system default premit administrator
            if (empy.UserGroupId == ADMINISTRATOR_DEFAULT_GROUPID)
            {
                return true;
            }

            //check system default premit wsi
            if (empy.UserGroupId == BACKOFFICE_DEFAULT_GROUPDID)
            {
                return true;
            }

            string FUNC_NAME = GetBOFuncTag("Main");

            VewEmployFunctionGroupDetail funcDetail = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getUserGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.UserGroupId);
                sqm.Condition.Where.AddCompareValue(VewEmployFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, FUNC_NAME);
                if (!VewEmployFunctionGroupDetailCtrl.QueryOne(dcf, sqm, ref funcDetail, ref errMsg))
                {
                    return false;
                }

                if (funcDetail == null)
                {
                    errMsg = LngRes.MSG_Valid_NoPremiess;
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Sys function
       
        public static bool InitSysFuncPermit(string path,ref string errMsg)
        {
            if (!System.IO.File.Exists(path))
            {
                errMsg = "未找到功能列表文件";
                return false;
            }
            else
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                dcf.BeginTrans();

                int updCount = 0;

                SqlWhere sw = new SqlWhere();
                if (!TblMWFunctionCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }

                XElement rootE = XElement.Load(path);

                List<TblMWFunction> dataList = new List<TblMWFunction>();

                #region convent xml to module
                {
                    var query =
                           from ele in rootE.Elements("package")
                           select
                               from cele in ele.Elements("item")
                               select
                                   new TblMWFunction()
                                   {
                                       FuncTag = ele.Attribute("tag").Value + "-" + cele.Element("tag").Value,
                                       FuncName = ele.Attribute("name").Value + "-" + cele.Element("name").Value
                                   }
                           ;

                    StringBuilder sb = new StringBuilder();
                    foreach (var item in query)
                    {
                        dataList.AddRange(item.ToArray());
                    }
                    rootE = null;
                }
                #endregion

                foreach (TblMWFunction item in dataList)
                {
                    if (!TblMWFunctionCtrl.Insert(dcf, item, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
                int[] updCounts = null;
                if (!dcf.Commit(ref updCounts, ref errMsg))
                {
                    return false;
                }
                
                return true;
            }
        }

        #endregion

        #region common data

        class LngRes
        {
            public const string MSG_Valid_InValidEmpyCode = "当前用户编号无效";
            public const string MSG_Valid_InValidEmpyPassword = "无效的用户密码";
            public const string MSG_Valid_NoPremiess = "当前用户没有使用权限";
           
        }
        #endregion

     
    }
}
