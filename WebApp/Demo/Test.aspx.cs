using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.Demo
{
    public partial class Test : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void TestFunc(string a, string b)
        {
            //AjaxResponseMng.AJAXResultObj.EnumResult.Success
            AjaxResponseMng.ReturnAjaxResponse(this.Response, AjaxResponseMng.AJAXResultObj.EnumResult.Err, "Eleven_aaaa");
        }
    }
}