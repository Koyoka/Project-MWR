using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.BackOffice.Business.Sys;

namespace YRKJ.MWR.BackOffice.Pages.BO.Car
{
    public partial class CarDispatch : BasePage
    {

        public const string ClassName = "YRKJ.MWR.BackOffice.Pages.BO.Car.CarDispatch";

        const string DisClass = "disabled";
        const int p = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(!InitPage())
                {
                    // do error thing
                }
            }
        }

        #region Events

        public string AjaxGetCarDispstch(string page)
        {

            CurrentPage = ComLib.ComFn.StringToInt(page);
            PageCount = p;
            NextPage = CurrentPage + 1 ;//> PageCount ? PageCount : CurrentPage + 1;
            PrePage = CurrentPage - 1 ;//< 0 ? 0 : CurrentPage - 1;
            DisNext = NextPage > PageCount ? DisClass : "";
            DisPre = PrePage < 1 ? DisClass : "";


            for (int i = 0; i < 5; i++)
            {
                PageCarInOutData item = new PageCarInOutData();
                item.CarDesc = "re_鄂A0000" + i;
                item.DriverName = "re_张" + i;
                item.InspectorName = "re_李" + i;
                item.OutTime = "re_10:3" + i;
                item.InTime = "re_第"+ CurrentPage + "页";

                PageCarInOutDataList.Add(item);
            }
            return null;
        }

        public string AjaxSubCarDispstch(string data1,string data2,string data3)
        {
            string s = "eleven: " + data1 + " " + data2 + " " + data3;
            //EmplList = new List<string>();
            //for (int i = 0; i < 4; i++)
            //{
            //    EmplList.Add("eleven" + i);
            //}
            //RedirectHelper.Redirect("/pages/bo/block/blocksendcardispatch.aspx?container=1");

            #region test data

            PageCarDataList = new List<PageCarData>();
            {
                for (int i = 0; i < 4; i++)
                {
                    PageCarData item = new PageCarData();
                    item.CarCode = "00" + i;
                    item.CarDesc = "鄂B0000" + i;
                    PageCarDataList.Add(item);
                }
            }
            PageEmplDriverDataList = new List<PageEmplData>();
            {
                for (int i = 0; i < 4; i++)
                {
                    PageEmplData item = new PageEmplData();
                    item.EmplCode = "e00" + i;
                    item.EmplName = "ELEVEN_" + i;

                    PageEmplDriverDataList.Add(item);
                }
            }

            PageEmplInspectorDataList = new List<PageEmplData>();
            {
                for (int i = 0; i < 4; i++)
                {
                    PageEmplData item = new PageEmplData();
                    item.EmplCode = "e00" + i;
                    item.EmplName = "SEVEN_" + i;

                    PageEmplInspectorDataList.Add(item);
                }
            }

            #endregion


            return null;
            //return s;
        }

        #endregion

        #region Functions

        private bool InitPage()
        {
            if (!LoadData())
            {
                return false;
            }

            return true;
        }

        private bool LoadData()
        {

            #region test data

            //PageCarDataList = new List<PageCarData>();
            {
                for (int i = 0; i < 5; i++)
                {
                    PageCarData item = new PageCarData();
                    item.CarCode = "00" + i;
                    item.CarDesc = "鄂A0000" + i;
                    PageCarDataList.Add(item);
                }
            }
            //PageEmplDriverDataList = new List<PageEmplData>();
            {
                for (int i = 0; i < 5; i++)
                {
                    PageEmplData item = new PageEmplData();
                    item.EmplCode = "e00" + i;
                    item.EmplName = "eleven_" + i;

                    PageEmplDriverDataList.Add(item);
                }
            }

            //PageEmplInspectorDataList = new List<PageEmplData>();
            {
                for (int i = 0; i < 5; i++)
                {
                    PageEmplData item = new PageEmplData();
                    item.EmplCode = "e00" + i;
                    item.EmplName = "seven_" + i;

                    PageEmplInspectorDataList.Add(item);
                }
            }

            //PageCarInOutDataList = new List<PageCarInOutData>();
            {
                CurrentPage = 1;// ComLib.ComFn.StringToInt(page);
                PageCount = p;
                NextPage = CurrentPage + 1 ;//> PageCount ? PageCount : CurrentPage + 1;
                PrePage = CurrentPage - 1 ;//< 0 ? 0 : CurrentPage - 1;
                DisNext = NextPage > PageCount ? DisClass : "";
                DisPre = PrePage < 1 ? DisClass : "";

                for (int i = 0; i < 5; i++)
                {
                    PageCarInOutData item = new PageCarInOutData();
                    item.CarDesc = "鄂A0000" + i;
                    item.DriverName = "张" + i;
                    item.InspectorName = "李" + i;
                    item.OutTime = "10:3" + i;
                    item.InTime = "";

                    PageCarInOutDataList.Add(item);
                }
            }

            #endregion

            return true;
        }

        #endregion

        #region Page Datas
        protected List<PageCarData> PageCarDataList = new List<PageCarData>();
        protected List<PageEmplData> PageEmplDriverDataList = new List<PageEmplData>();
        protected List<PageEmplData> PageEmplInspectorDataList = new List<PageEmplData>();
        protected List<PageCarInOutData> PageCarInOutDataList = new List<PageCarInOutData>();

        protected int CurrentPage = 0;
        protected int PageCount = 0;
        protected int NextPage = 0;
        protected int PrePage = 0;
        protected string DisPre = "";
        protected string DisNext = "";

        #endregion

        #region Common

       
        protected class PageCarData
        {
            public string CarCode = "";
            public string CarDesc = "";
        }

        protected class PageEmplData
        {
            public string EmplCode = "";
            public string EmplName = "";
        }

        protected class PageCarInOutData
        {
            public string CarDesc = "";
            public string DriverName = "";
            public string InspectorName = "";
            public string OutTime = "";
            public string InTime = "";
        }

        #endregion


    }
}