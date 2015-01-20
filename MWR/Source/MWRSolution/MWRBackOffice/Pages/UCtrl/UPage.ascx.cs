using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YRKJ.MWR.BackOffice.Pages.UCtrl
{
    public partial class UPage : System.Web.UI.UserControl
    {
        protected int CurrentPage = 0;
        protected int PageCount = 0;
        protected int NextPage = 0;
        protected int PrePage = 0;
        protected string DisPre = "";
        protected string DisNext = "";

        const string DisClass = "disabled";
        const int p = 10;

        protected void Page_Load(object sender, EventArgs e)
        {
            //CurrentPage = 1;// ComLib.ComFn.StringToInt(page);
            //PageCount = p;
            //NextPage = CurrentPage + 1;//> PageCount ? PageCount : CurrentPage + 1;
            //PrePage = CurrentPage - 1;//< 0 ? 0 : CurrentPage - 1;
            //DisNext = NextPage > PageCount ? DisClass : "";
            //DisPre = PrePage < 1 ? DisClass : "";
        }

        public void ShowPage(int curPage,int pageCount)
        {
            CurrentPage = curPage;// 1;// ComLib.ComFn.StringToInt(page);
            PageCount = pageCount;// p;
            NextPage = CurrentPage + 1;//> PageCount ? PageCount : CurrentPage + 1;
            PrePage = CurrentPage - 1;//< 0 ? 0 : CurrentPage - 1;
            DisNext = NextPage > PageCount ? DisClass : "";
            DisPre = PrePage < 1 ? DisClass : "";
        }
    }
}