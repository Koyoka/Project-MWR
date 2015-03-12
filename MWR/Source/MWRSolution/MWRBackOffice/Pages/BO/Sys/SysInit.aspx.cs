using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;
using Newtonsoft.Json;
using ComLib.db;
using LinqToExcel;
using YRKJ.MWR.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.BO.Sys
{
    public partial class SysInit : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Sys.SysInit";

        protected void Page_Load(object sender, EventArgs e)
        {
            string s = SqlCommonFn.EncryptString("1");
            if (!IsPostBack)
            {
                string errMsg = "";
                if (!InitPage(ref errMsg))
                {
                    // do error thing
                    RedirectHelper.GotoErrPage(errMsg, RedirectHelper.BOMain, RedirectHelper.BackType.include);
                }
            }
        }

        #region Events

        public bool AjaxGetInitData(string fileName)
        {
            string errMsg = "";
            if (!ReadInitDataExcel(fileName,ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }
            return true;
        }

        public bool AjaxImportInitData(string fileName, string dataName)
        {
            List<TblMWEmploy>           empyList = new List<TblMWEmploy>();
            List<TblMWVendor>           vendorList = new List<TblMWVendor>();
            List<TblMWWasteCategory>    wasteList = new List<TblMWWasteCategory>();
            List<TblMWCar>              carList = new List<TblMWCar>();
            List<TblMWDepot>            depotList = new List<TblMWDepot>();
            List<TblMWCrate>            crateList = new List<TblMWCrate>();

            string errMsg = "";
            if (!ReadInitDataExcel(fileName, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }

            foreach (var item in PageInitGroupDataList)
            {
                if (item.GroupName.Equals(dataName)
                    || string.IsNullOrEmpty(dataName))
                {
                    foreach (var subItem in item.dataList)
                    {
                        switch (item.GroupName)
                        {
                            case EXCEL_WORKSHEET_EMPLOY:
                                empyList.Add(new TblMWEmploy()
                                {
                                    EmpyCode = subItem.code,
                                    EmpyName = subItem.desc1,
                                    Password = subItem.desc2
                                });
                                break;
                            case EXCEL_WORKSHEET_VENDOR:
                                vendorList.Add(new TblMWVendor()
                                {
                                    VendorCode = subItem.code,
                                    Vendor = subItem.desc1,
                                    Address = subItem.desc2
                                });
                                break;
                            case EXCEL_WORKSHEET_CAR:
                                carList.Add(new TblMWCar()
                                {
                                    CarCode = subItem.code,
                                    Desc = subItem.desc1
                                });
                                break;
                            case EXCEL_WORKSHEET_WASTE:
                                wasteList.Add(new TblMWWasteCategory()
                                {
                                    WasteCode = subItem.code,
                                    Waste = subItem.desc1
                                });
                                break;
                            case EXCEL_WORKSHEET_CRATE:
                                crateList.Add(new TblMWCrate()
                                {
                                    CrateCode = subItem.code,
                                    Desc = subItem.desc1
                                });
                                break;
                            case EXCEL_WORKSHEET_DEPOT:
                                depotList.Add(new TblMWDepot()
                                {
                                    DeptCode = subItem.code,
                                    Desc = subItem.desc1
                                });
                                break;
                        }
                    }
                }
            }
           
            if (!MWSysTable.InitSysBaseData(empyList,
            vendorList,
            wasteList,
            carList,
            depotList,
            crateList, ref errMsg))
            {
                ReturnAjaxError(errMsg);
                return false;
            }

            return false;
        }

        #endregion

        #region Functions

        private bool InitPage(ref string errMsg)
        {
            if (!LoadData(ref errMsg))
            {
                return false;
            }

            return true;
        }

        private bool LoadData(ref string errMsg)
        {
           
            var file = Request.Files["files[]"];
            if (file != null)
            {
                string[] arry = file.FileName.Split('.');
                if (arry.Length == 0)
                {
                    return true;
                }
                DateTime now = SqlDBMng.GetDBNow();
                string filename = now.ToString("yyyyMMddHHmmss")+"." + arry[arry.Length - 1];// file.FileName;

                //string s = ComLib.ComFn.GetAppExePath() + @"\UploadFile\1.xlsx";
                //ReadInitDataExcel(ref filename);

                file.SaveAs(ComLib.ComFn.GetAppExePath() + "UploadFile//" + filename);
                Files f = new Files();
                f.error = false;
                f.result = filename;// "eleven";


                string strJson = JsonConvert.SerializeObject(f);
                Response.Clear();
                Response.ContentEncoding = System.Text.Encoding.UTF8;
                Response.ContentType = "appliction/json";
                Response.Write(strJson);
                Response.Flush();
                Response.End();
            }
            return true;
        }

        private bool ReadInitDataExcel(string fileName,ref string errMsg)
        {
            try
            {
                

                string s = ComLib.ComFn.GetAppExePath() + @"\UploadFile\" + fileName;//\1.xlsx";
                if (!System.IO.File.Exists(s))
                {
                    errMsg = "模板文件不知去向! :(..";
                    return false;
                }
                var excelfile = new ExcelQueryFactory(s);

                #region employ
                {
                    var tsheet = excelfile.Worksheet(EXCEL_WORKSHEET_EMPLOY);
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = EXCEL_WORKSHEET_EMPLOY;
                    groupData.title1 = "员工编号";
                    groupData.title2 = "员工姓名";
                    groupData.title3 = "密码";
                    var query = from p in tsheet
                                //where p["Age"].Cast<int>() > 30
                                select p;
                    foreach (var item in query)
                    {
                        PageInitData data = new PageInitData()
                        {
                            code = item["员工编号"],
                            desc1 = item["员工姓名"],
                            desc2 = item["密码"]
                        };
                        groupData.dataList.Add(data);
                    }
                    PageInitGroupDataList.Add(groupData);
                }
                #endregion

                #region vendor
                {
                    var tsheet = excelfile.Worksheet(EXCEL_WORKSHEET_VENDOR);
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = EXCEL_WORKSHEET_VENDOR;
                    groupData.title1 = "医院编号";
                    groupData.title2 = "医院名称";
                    groupData.title3 = "医院坐标";
                    var query = from p in tsheet
                                //where p["Age"].Cast<int>() > 30
                                select p;
                    foreach (var item in query)
                    {
                        PageInitData data = new PageInitData()
                        {
                            code = item["医院编号"],
                            desc1 = item["医院名称"],
                            desc2 = item["医院坐标"]
                        };
                        groupData.dataList.Add(data);
                    }
                    PageInitGroupDataList.Add(groupData);

                }
                #endregion

                #region wastercategory
                {
                    var tsheet = excelfile.Worksheet(EXCEL_WORKSHEET_WASTE);
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = EXCEL_WORKSHEET_WASTE;
                    groupData.title1 = "类型编号";
                    groupData.title2 = "类型名称";
                    groupData.title3 = "";
                    var query = from p in tsheet
                                select p;
                    foreach (var item in query)
                    {
                        PageInitData data = new PageInitData()
                        {
                            code = item["类型编号"],
                            desc1 = item["类型名称"]
                        };
                        groupData.dataList.Add(data);
                    }
                    PageInitGroupDataList.Add(groupData);
                }
                #endregion

                #region car
                {
                    var tsheet = excelfile.Worksheet(EXCEL_WORKSHEET_CAR);
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = EXCEL_WORKSHEET_CAR;
                    groupData.title1 = "车辆编号";
                    groupData.title2 = "车辆名称";
                    groupData.title3 = "";
                    var query = from p in tsheet
                                select p;
                    foreach (var item in query)
                    {
                        PageInitData data = new PageInitData()
                        {
                            code = item["车辆编号"],
                            desc1 = item["车辆名称"]
                        };
                        groupData.dataList.Add(data);
                    }
                    PageInitGroupDataList.Add(groupData);

                }
                #endregion

                #region depot
                {
                    var tsheet = excelfile.Worksheet(EXCEL_WORKSHEET_DEPOT);
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = EXCEL_WORKSHEET_DEPOT;
                    groupData.title1 = "仓库编号";
                    groupData.title2 = "仓库名称";
                    groupData.title3 = "";
                    var query = from p in tsheet
                                select p;
                    foreach (var item in query)
                    {
                        PageInitData data = new PageInitData()
                        {
                            code = item["仓库编号"],
                            desc1 = item["仓库名称"]
                        };
                        groupData.dataList.Add(data);
                    }
                    PageInitGroupDataList.Add(groupData);

                }
                #endregion

                #region crate
                {
                    var tsheet = excelfile.Worksheet(EXCEL_WORKSHEET_CRATE);
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = EXCEL_WORKSHEET_CRATE;
                    groupData.title1 = "货箱编号";
                    groupData.title2 = "货箱名称";
                    groupData.title3 = "";
                    var query = from p in tsheet
                                select p;
                    foreach (var item in query)
                    {
                        PageInitData data = new PageInitData()
                        {
                            code = item["货箱编号"],
                            desc1 = item["货箱名称"]
                        };
                        groupData.dataList.Add(data);
                    }
                    PageInitGroupDataList.Add(groupData);
                }
                #endregion
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region PageDatas
        protected List<PageInitGroupData> PageInitGroupDataList = new List<PageInitGroupData>();
        #endregion

        #region Common

        const string EXCEL_WORKSHEET_EMPLOY = "员工信息";
        const string EXCEL_WORKSHEET_VENDOR = "医院信息";
        const string EXCEL_WORKSHEET_WASTE = "废料类型";
        const string EXCEL_WORKSHEET_CAR = "车辆信息";
        const string EXCEL_WORKSHEET_DEPOT = "仓库信息";
        const string EXCEL_WORKSHEET_CRATE = "货箱信息";

        class Files
        {
            public bool error = false;
            public string result = "";
        }
        protected class PageInitData
        {
            public string code { get; set; }
            public string desc1 { get; set; }
            public string desc2 { get; set; }

        }
        protected class PageInitGroupData
        {
            public string GroupName { get; set; }
            public string title1 { get; set; }
            public string title2 { get; set; }
            public string title3 { get; set; }
            public List<PageInitData> dataList = new List<PageInitData>();
        }
       
        #endregion
    }
}