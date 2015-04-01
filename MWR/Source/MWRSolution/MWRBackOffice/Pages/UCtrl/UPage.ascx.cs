using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComLib;

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
        protected int ShowPageCount = 0;

        protected int fPage = 0;
        const int PageCountSize = 10;
        const int tabCount = 5;


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
            ShowPageCount = pageCount;
            CurrentPage = curPage;// 1;// ComLib.ComFn.StringToInt(page);
            PageCount = pageCount;// p;
            NextPage = CurrentPage + 1;//> PageCount ? PageCount : CurrentPage + 1;
            PrePage = CurrentPage - 1;//< 0 ? 0 : CurrentPage - 1;
            DisNext = NextPage > PageCount ? DisClass : "";
            DisPre = PrePage < 1 ? DisClass : "";

            if (PageCount < PageCountSize)
            {
                return;
            }

            if (curPage >= PageCountSize)
            {
                fPage = (curPage - tabCount);
            }
            else if (curPage >= tabCount)
            {
                fPage = (curPage - tabCount);
            }
            else
            {
                fPage = 0;
            }

            if (fPage + PageCountSize > PageCount)
            {
                fPage = PageCount - PageCountSize;
                PageCount = PageCountSize;
            }
            else
            {
                PageCount = PageCountSize;
            }

            //CurrentPage = curPage;// 1;// ComLib.ComFn.StringToInt(page);
            //PageCount = pageCount;// p;
            //NextPage = CurrentPage + 1;//> PageCount ? PageCount : CurrentPage + 1;
            //PrePage = CurrentPage - 1;//< 0 ? 0 : CurrentPage - 1;
            //DisNext = NextPage > PageCount ? DisClass : "";
            //DisPre = PrePage < 1 ? DisClass : "";

            //int tabCount = 5;
            //long pageGroupCount  = ComFn.getPageCount(PageCountSize, pageCount);
            //int pageIndex = curPage % PageCountSize;

            
            ////int lpage = 0;
            //if (pageIndex > tabCount)
            //{
            //    fPage = curPage - (pageIndex - tabCount);   
            //}


            //if (pageCount > PageCountSize) {
            //    PageCount = PageCountSize;
                
            //}
        }
    }
}