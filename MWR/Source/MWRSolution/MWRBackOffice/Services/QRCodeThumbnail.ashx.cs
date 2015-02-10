using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRKJ.MWR.BackOffice.Services
{
    /// <summary>
    /// QRCodeThumbnail 的摘要说明
    /// </summary>
    public class QRCodeThumbnail : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.QueryString["content"] == null)
            {
                return;
            }
            string content = context.Request.QueryString["content"];
            System.Drawing.Bitmap bit = null;
            string errMsg = "";

            //string ak = "", ek = "";
            //YRKJ.MWR.Business.BO.WSMng.CreateMWSAccessKeyAndSecretKey(ref ak, ref ek, ref errMsg);
            //content = ak + " " + ek;
            ComLib.Utility.BarCodeHelper.GetInstance().CreateDefaultQRCode(content, ref bit, ref errMsg);
            if (bit == null)
            {
                return;
            }

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {

                bit.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                context.Response.ContentType = "image/jpg";
                context.Response.BinaryWrite(ms.ToArray());
                
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}