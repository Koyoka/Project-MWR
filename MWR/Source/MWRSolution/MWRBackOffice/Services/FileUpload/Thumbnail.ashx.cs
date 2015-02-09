using System.Web;

namespace YRKJ.MWR.BackOffice.Services.FileUpload
{
	public class Thumbnail : IHttpHandler {
        private string _storageRoot = "";
        public string StorageRoot
        {
            get
            {
                if (string.IsNullOrEmpty(_storageRoot))
                    return ComLib.ComFn.GetAppExePath() + "UploadFile//";
                else
                    return _storageRoot;
                //return ConfigurationManager.AppSettings["StorageRoot"]; 
            }
        }
		public void ProcessRequest (HttpContext context) {
			context.Response.ContentType = "image/jpg";
            string fileName = context.Request.QueryString["f"];
            string directory = context.Request.QueryString["d"];
            directory = string.IsNullOrEmpty(directory) ? "" : directory + "//";


            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"(\.|\/)(gif|jpe?g|png)");
            if (reg.IsMatch(fileName))
            {
                context.Response.WriteFile(context.Server.MapPath("/UploadFile/" + directory + fileName));
            }else
                context.Response.WriteFile(context.Server.MapPath("/Assets/images/default_thumb.jpg"));
            
		}
        private string GetSaveDirectory(string txnNum, string crateCode)
        {
            return txnNum + "//" + crateCode + "//";
        }

		public bool IsReusable { get { return false; } }
	}

}
