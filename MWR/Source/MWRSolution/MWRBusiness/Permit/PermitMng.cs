﻿using System;
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
        public static void GetSysDefaultFuncGroup(ref List<TblMWFunctionGroup> funcGrp)
        {
            funcGrp = new List<TblMWFunctionGroup>();
            funcGrp.Add(new TblMWFunctionGroup() {
                FuncGroupId = ADMINISTRATOR_DEFAULT_GROUPID,
                FuncGroupName = "Administrator"
                
            });
            funcGrp.Add(new TblMWFunctionGroup()
            {
                FuncGroupId = BACKOFFICE_DEFAULT_GROUPDID,
                FuncGroupName = "管理中心"

            });
            funcGrp.Add(new TblMWFunctionGroup()
            {
                FuncGroupId = INVENTORY_DEFAULT_GROUPID,
                FuncGroupName = "库存工作站"

            });
            funcGrp.Add(new TblMWFunctionGroup()
            {
                FuncGroupId = DESTROY_DEFAULT_GROUPID,
                FuncGroupName = "处置工作站"
            });
        }

        public static bool GetEmployPremiessFunctionDetail(string empyCode, ref List<TblMWFunctionGroupDetail> funcs, ref string errMsg)
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
            sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.FuncGroupId);
            if (!TblMWFunctionGroupDetailCtrl.QueryMore(dcf, sqm, ref funcs, ref errMsg))
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
            sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.FuncGroupId);
            sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, funcTag);

            TblMWFunctionGroupDetail data = null;
            if (!TblMWFunctionGroupDetailCtrl.QueryOne(dcf, sqm, ref data, ref errMsg))
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

        #endregion

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
            if (empy.FuncGroupId == ADMINISTRATOR_DEFAULT_GROUPID)
            {
                return true;
            }

            //check system default premit wsi
            if (empy.FuncGroupId == INVENTORY_DEFAULT_GROUPID)
            {
                return true;
            }

            string FUNC_NAME = GetWSIFuncTag("Main");

            TblMWFunctionGroupDetail funcDetail = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.FuncGroupId);
                sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, FUNC_NAME);
                if (!TblMWFunctionGroupDetailCtrl.QueryOne(dcf, sqm, ref funcDetail, ref errMsg))
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
            if (empy.FuncGroupId == ADMINISTRATOR_DEFAULT_GROUPID)
            {
                return true;
            }

            //check system default premit wsi
            if (empy.FuncGroupId == DESTROY_DEFAULT_GROUPID)
            {
                return true;
            }

            string FUNC_NAME = GetWSDFuncTag("Main");

            TblMWFunctionGroupDetail funcDetail = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.FuncGroupId);
                sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, FUNC_NAME);
                if (!TblMWFunctionGroupDetailCtrl.QueryOne(dcf, sqm, ref funcDetail, ref errMsg))
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
            if (empy.FuncGroupId == ADMINISTRATOR_DEFAULT_GROUPID)
            {
                return true;
            }

            //check system default premit wsi
            if (empy.FuncGroupId == BACKOFFICE_DEFAULT_GROUPDID)
            {
                return true;
            }

            string FUNC_NAME = GetBOFuncTag("Main");

            TblMWFunctionGroupDetail funcDetail = null;
            {
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.FuncGroupId);
                sqm.Condition.Where.AddCompareValue(TblMWFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, FUNC_NAME);
                if (!TblMWFunctionGroupDetailCtrl.QueryOne(dcf, sqm, ref funcDetail, ref errMsg))
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

        public static bool RemoveUserPermit(string empyCode, ref string errMsg)
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

            int updCount = 0;
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWEmploy.getFuncGroupIdColumn(), 0);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.EmpyCode);

            if (!TblMWEmployCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }

        public static bool AddUserPermit(string empyCode, int funcGrpId, ref string errMsg)
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

            int updCount = 0;
            SqlUpdateColumn suc = new SqlUpdateColumn();
            suc.Add(TblMWEmploy.getFuncGroupIdColumn(), funcGrpId);
            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empy.EmpyCode);

            if (!TblMWEmployCtrl.Update(dcf, suc, sw, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;

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