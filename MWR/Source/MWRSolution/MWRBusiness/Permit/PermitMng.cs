using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using ComLib.db;
using YRKJ.MWR.Business.BaseData;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.Business.Permit
{
    public class PermitMng
    {
        public const string ClassName = "YRKJ.MWR.Business.Permit.PermitMng";

        public const int ADMINISTRATOR_DEFAULT_GROUPID = -1;
        public const int BACKOFFICE_DEFAULT_GROUPDID = -2;
        public const int INVENTORY_DEFAULT_GROUPID = -3;
        public const int DESTROY_DEFAULT_GROUPID = -4;
        #region Common
        public static string GetFuncGroupPerfix(int id)
        {
            string s = "";
            switch (id)
            { 
                case ADMINISTRATOR_DEFAULT_GROUPID:
                    s = "";
                    break;
                case BACKOFFICE_DEFAULT_GROUPDID:
                    s = "BackOffice-";
                    break;
                case INVENTORY_DEFAULT_GROUPID:
                    s = "Inventory-";
                    break;
                case DESTROY_DEFAULT_GROUPID:
                    s = "Destroy-";
                    break;
            }
            return s;
        }

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
            return "BackOffice-" + tag;
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
        public static string GetSysDefaultFuncGroupName(int id)
        {
            string s = "";
            switch (id)
            { 
                case ADMINISTRATOR_DEFAULT_GROUPID:
                    s = "Administrator";
                    break;
                case BACKOFFICE_DEFAULT_GROUPDID:
                    s = "管理中心";
                    break;
                case INVENTORY_DEFAULT_GROUPID:
                    s = "库存工作站";
                    break;
                case DESTROY_DEFAULT_GROUPID:
                    s = "处置工作站";
                    break;
            }
            return s;
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

        private static bool SysAdminPremit(string empyCode, string password, ref string errMsg)
        {
            string adminAccount = MWParams.GetAdministrator();
            string adminPassword = MWParams.GetAdministratorPassword();
            if (empyCode.Equals(adminAccount) && password.Equals(adminPassword))
            {
                DataCtrlInfo dcf = new DataCtrlInfo();
                TblMWEmploy adminEmpy = null;
                SqlQueryMng sqm = new SqlQueryMng();
                sqm.Condition.Where.AddCompareValue(TblMWEmploy.getEmpyCodeColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, empyCode);
                if (!TblMWEmployCtrl.QueryOne(dcf, sqm,ref adminEmpy, ref errMsg))
                {
                    return false;
                }

                if (adminEmpy == null)
                {
                    int updCount = 0;
                    adminEmpy = new TblMWEmploy();
                    adminEmpy.EmpyCode = empyCode;
                    adminEmpy.EmpyName = adminAccount;
                    adminEmpy.EmpyType = TblMWEmploy.EMPYTYPE_ENUM_WorkStation;
                    adminEmpy.Password = password;
                    adminEmpy.Status = TblMWEmploy.STATUS_ENUM_Active;
                    adminEmpy.UserName = adminAccount;
                    adminEmpy.FuncGroupId = ADMINISTRATOR_DEFAULT_GROUPID;

                    if (!TblMWEmployCtrl.Insert(dcf, adminEmpy, ref updCount, ref errMsg))
                    {
                        return false;
                    }
                }
                return true;
            }
            else {
                return false;
            }
        }

        #endregion

        #region WS
        public static bool WSILogin(string empyCode, string password, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();

            TblMWEmploy empy = null;
            #region valid data
            if (SysAdminPremit(empyCode, password, ref errMsg))
            {
                return true;
            }

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

            encrytPassword = SqlCommonFn.EncryptString(password);

            if (empy.Password != encrytPassword)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyPassword;
                return false;
            }
            if (empy.Status == TblMWEmploy.STATUS_ENUM_Void)
            {
                errMsg = LngRes.MSG_Valid_EmpyVoid;
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
            if (SysAdminPremit(empyCode, password, ref errMsg))
            {
                return true;
            }

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

            encrytPassword = SqlCommonFn.EncryptString(password);

            if (empy.Password != encrytPassword)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyPassword;
                return false;
            }
            if (empy.Status == TblMWEmploy.STATUS_ENUM_Void)
            {
                errMsg = LngRes.MSG_Valid_EmpyVoid;
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
            if (SysAdminPremit(empyCode,password,ref errMsg))
            {
                return true;
            }

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

            encrytPassword = SqlCommonFn.EncryptString(password);

            if (empy.Password != encrytPassword)
            {
                errMsg = LngRes.MSG_Valid_InValidEmpyPassword;
                return false;
            }
            if (empy.Status == TblMWEmploy.STATUS_ENUM_Void)
            {
                errMsg = LngRes.MSG_Valid_EmpyVoid;
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

        public static bool AddNewFunctionGroup(string grpName,ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            int funcGrpNextId = MWNextIdMng.GetFunctionGroupNextId();
            if (funcGrpNextId == 0)
            {
                errMsg = "NextId生成失败,请重试";
                return false;
            }
            if (!TblMWFunctionGroupCtrl.Insert(dcf, funcGrpNextId, grpName, ref updCount, ref errMsg))
            {
                return false;
            }
            return true;
        }
        public static bool RemoveFunctionGroup(int grpId, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            dcf.BeginTrans();
            {
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWFunctionGroup.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, grpId);
                if (!TblMWFunctionGroupCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
                {
                    return false;
                }
            }
            {
                SqlWhere sw = new SqlWhere();
                sw.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, grpId);
                if (!TblMWFunctionGroupDetailCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
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

        public static bool AddFunctionToGroup(int grpId, string funcTag, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            int funcGrpDetailNextId = MWNextIdMng.GetFunctionGroupDetailNextId();
            if (funcGrpDetailNextId == 0)
            {
                errMsg = "NextId生成失败,请重试";
                return false;
            }
            if (!TblMWFunctionGroupDetailCtrl.Insert(dcf, funcGrpDetailNextId, grpId, funcTag, ref updCount, ref errMsg))
            {
                return false;
            }

            return true;
        }
        public static bool RemoveFunctionFromGroup(int grpId, string funcTag, ref string errMsg)
        {
            DataCtrlInfo dcf = new DataCtrlInfo();
            int updCount = 0;

            SqlWhere sw = new SqlWhere();
            sw.AddCompareValue(TblMWFunctionGroupDetail.getFuncGroupIdColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, grpId);
            sw.AddCompareValue(TblMWFunctionGroupDetail.getFuncTagColumn(), SqlCommonFn.SqlWhereCompareEnum.Equals, funcTag);

            if (!TblMWFunctionGroupDetailCtrl.Delete(dcf, sw, ref updCount, ref errMsg))
            {
                return false;
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
            public const string MSG_Valid_EmpyVoid = "账户已被注销";
           
        }
        #endregion

     
    }
}
