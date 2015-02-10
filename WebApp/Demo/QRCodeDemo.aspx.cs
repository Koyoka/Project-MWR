using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using ComLib.Utility;

namespace WebApp.Demo
{
    public partial class QRCodeDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Bitmap bit = null;
            string errMsg = "";
            BarCodeHelper.GetInstance().CreateDefaultQRCode("eleven", ref bit, ref errMsg);
            if (bit == null)
            {
                return;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                bit.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                Response.ClearContent();
                Response.ContentType = "image/Gif";
                Response.BinaryWrite(ms.ToArray());//这里的Write改成BinaryWrite即可
                Response.End();
            }
        }
    }
}