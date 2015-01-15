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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Events

        #endregion

        #region Ajax Events

        public string AjaxSubCarDispstch(string data1,string data2,string data3)
        {
            string s = "eleven: " + data1 + " " + data2 + " " + data3;

            return s;
        }

        #endregion

        #region Functions

        #endregion
    }
}