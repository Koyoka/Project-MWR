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

namespace YRKJ.MWR.BackOffice.Pages.BO.Sys
{
    public partial class SysInit : BasePage
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Sys.SysInit";

        protected void Page_Load(object sender, EventArgs e)
        {
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
            ReturnAjaxJson(fileName+" dataName:" + dataName);
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

            //if (!ReadInitDataExcel(ref errMsg))
            //{
            //    return false;
            //}
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
                var excelfile = new ExcelQueryFactory(s);

                #region employ
                {
                    var tsheet = excelfile.Worksheet("员工信息");
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = "员工信息";
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
                    var tsheet = excelfile.Worksheet("医院信息");
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = "医院信息";
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
                    var tsheet = excelfile.Worksheet("废料类型");
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = "废料类型";
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
                    var tsheet = excelfile.Worksheet("车辆信息");
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = "车辆信息";
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
                    var tsheet = excelfile.Worksheet("仓库信息");
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = "仓库信息";
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
                    var tsheet = excelfile.Worksheet("货箱信息");
                    PageInitGroupData groupData = new PageInitGroupData();
                    groupData.GroupName = "货箱信息";
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