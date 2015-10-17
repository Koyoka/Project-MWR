using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YRKJ.MWR.Business.Permit;
using System.Text;

namespace YRKJ.MWR.BackOffice
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string requestData = "";
            #region get response data
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream, Encoding.UTF8))
            {
                requestData = sr.ReadToEnd();
                sr.Close();
            }
            #endregion

            Response.SetCookie(new HttpCookie("Eleven","ElevenSetCookie"));
            Response.SetCookie(new HttpCookie("Rayment", "RaymentSetCookie"));

            //Response.Write("");

            /*
             
             账号： mateware01
            密码：123456 
            http://121.199.17.68:8081
            您的appkey为：9de1313e6fa0fb5e7617f3030789a914
             */
            //string errMsg = "";
            //string path = ComLib.ComFn.GetAppExePath() + @"Setting\function.xml";
            //if (!PermitMng.InitSysFuncPermit(path, ref errMsg))
            //{
            //    Response.Write(errMsg + "<p>" + path + "<p>");
            //}
            //else {
            //    Response.Write("success" + "<p>");
            //}
        }
    }
}