using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Configuration;
using ComLib.db;
using YRKJ.MWR.Business.BO;
using YRKJ.MWR.Business.BaseData;

namespace YRKJ.MWR.BackOffice.Services.FileUpload
{
    /// <summary>
    /// MWWebPageHandler 的摘要说明
    /// </summary>
    public class MWFileUploadHandler : IHttpHandler
    {
        public const string ClassName = "YRKJ.MWR.BackOffice.Services.FileUpload";
             

        private readonly JavaScriptSerializer js = new JavaScriptSerializer();

        private string _storageRoot = "";
        public string StorageRoot
        {
            get {
                if (string.IsNullOrEmpty(_storageRoot))
                    return ComLib.ComFn.GetAppExePath() + "UploadFile//";
                else
                    return _storageRoot;
                //return ConfigurationManager.AppSettings["StorageRoot"]; 
            }
        }
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.AddHeader("Pragma", "no-cache");
            context.Response.AddHeader("Cache-Control", "private, no-cache");


            //context.Response.AddHeader("X-Content-Type-Options", "nosniff");

            //context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            //context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
           

            HandleMethod(context);
        }

        // Handle request based on method
        private void HandleMethod(HttpContext context)
        {
           

            switch (context.Request.HttpMethod)
            {
                case "HEAD":
                case "GET":
                    if (GivenFilename(context)) DeliverFile(context);
                    else ListCurrentFiles(context);
                    break;

                case "POST":
                case "PUT":
                    UploadFile(context);
                    break;

                case "DELETE":
                    DeleteFile(context);
                    break;

                case "OPTIONS":
                    ReturnOptions(context);
                    break;

                default:
                    context.Response.ClearHeaders();
                    context.Response.StatusCode = 405;
                    break;
            }
        }

        private static void ReturnOptions(HttpContext context)
        {
            context.Response.AddHeader("Allow", "DELETE,GET,HEAD,POST,PUT,OPTIONS");
            context.Response.StatusCode = 200;
        }

        // Delete file from the server
        private void DeleteFile(HttpContext context)
        {
            var d = context.Request["d"];
            d = string.IsNullOrEmpty(d) ? "" : d+"//";
            var filePath = StorageRoot + d + context.Request["f"];

            List<string> fileNames = new List<string>();
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                string fileName = Path.GetFileName(filePath);
                fileNames.Add(fileName);
            }
            //string invauthid = context.Request.Form["invauthid"];
            
            string errMsg = "";

            if (!MWRWorkflowMng.DelAuthorizeAttach(fileNames, ref errMsg))
            { 
                
            }
        }

        // Upload file to the server
        private void UploadFile(HttpContext context)
        {
            string action = context.Request.Form["action"];
            if (string.IsNullOrEmpty(action))
            {
                return;
            }

            var statuses = new List<FilesStatus>();
            var headers = context.Request.Headers;
            string errMsg = "";

            if (string.IsNullOrEmpty(headers["X-File-Name"]))
            {
                //UploadWholeFile(context, statuses);
                UploadAuthorizeWholeFile(context, statuses,ref errMsg);
            }
            else
            {
                UploadPartialFile(headers["X-File-Name"], context, statuses);
            }

            WriteJsonIframeSafe(context, statuses);
        }

        // Upload partial file
        private void UploadPartialFile(string fileName, HttpContext context, List<FilesStatus> statuses)
        {
            if (context.Request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var inputStream = context.Request.Files[0].InputStream;
            var fullName = StorageRoot + Path.GetFileName(fileName);

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new FilesStatus(new FileInfo(fullName)));
        }

        // Upload entire file
        //private void UploadWholeFile(HttpContext context, List<FilesStatus> statuses)
        //{
        //    for (int i = 0; i < context.Request.Files.Count; i++)
        //    {
        //        var file = context.Request.Files[i];
        //        //file.SaveAs(StorageRoot + Path.GetFileName(file.FileName));
        //        //string fullName = Path.GetFileName(file.FileName);

        //        string fullName = FileSave(context, file);
        //        statuses.Add(new FilesStatus(fullName, file.ContentLength));
        //    }
        //}

        private bool UploadAuthorizeWholeFile(HttpContext context, List<FilesStatus> statuses,ref string errMsg)
        {
            string txnNum = context.Request.Form["txnNum"];
            string crateCode = context.Request.Form["crateCode"];
            string invauthid = context.Request.Form["invauthid"];

            if (string.IsNullOrEmpty(txnNum)
                || string.IsNullOrEmpty(txnNum)
                || string.IsNullOrEmpty(txnNum))
            {
                errMsg = "No txnnum";
                return false;
            }

            string UploadFileRoot = StorageRoot + GetSaveDirectory(txnNum, crateCode);// txnNum + "//" + crateCode + "//";
            if (!Directory.Exists(UploadFileRoot))
            {
                Directory.CreateDirectory(UploadFileRoot);
            }

            List<string> filePaths = new List<string>();
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                var file = context.Request.Files[i];
                string fileName = GetAuthorizeFileName(txnNum, crateCode, file);

                string fullName = FileSave(context, file, UploadFileRoot, fileName); // FileSave(context, file);
                statuses.Add(new FilesStatus(fullName, file.ContentLength,  GetSaveDirectory(txnNum, crateCode)));
                filePaths.Add("UploadFile//" + GetSaveDirectory(txnNum, crateCode) + fullName);
                //GetSaveDirectory(txnNum, crateCode);
            }
           
            if (!MWRWorkflowMng.AddAuthorizeAttach(ComLib.ComFn.StringToInt(invauthid), filePaths, ref errMsg))
            {
                return false;
            }

            return true;
        }

        private string GetSaveDirectory(string txnNum,string crateCode)
        {
            return txnNum + "//" + crateCode + "//";
        }
        private string GetAuthorizeFileName(string txnNum,string crateCode,HttpPostedFile file)
        {
            DateTime now = SqlDBMng.GetDBNow();
            return txnNum + "_" + crateCode + "_" + now.ToString("yyyyMMddHHmmssff") + "_" + file.FileName;
        }
        private string FileSave(HttpContext context, HttpPostedFile file)
        {
            return FileSave(context, file, StorageRoot, file.FileName);
        }
        private string FileSave(HttpContext context,HttpPostedFile file,string storageRoot,string fileName)
        {
            file.SaveAs(storageRoot + Path.GetFileName(fileName));
            return Path.GetFileName(fileName);
        }

        private void WriteJsonIframeSafe(HttpContext context, List<FilesStatus> statuses)
        {
            context.Response.AddHeader("Vary", "Accept");
            try
            {
                if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                    context.Response.ContentType = "application/json";
                else
                    context.Response.ContentType = "text/plain";
            }
            catch
            {
                context.Response.ContentType = "text/plain";
            }

            var jsonObj = js.Serialize(Files.GetFiles(statuses.ToArray()));
            context.Response.Write(jsonObj);
        }

        private static bool GivenFilename(HttpContext context)
        {
            return !string.IsNullOrEmpty(context.Request["f"]);
        }

        private void DeliverFile(HttpContext context)
        {
            var filename = context.Request["f"];
            var d = context.Request["d"];
            d = string.IsNullOrEmpty(d) ? "" : d + "//";
            var filePath = StorageRoot + d  + filename;

            if (File.Exists(filePath))
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ClearContent();
                context.Response.WriteFile(filePath);
            }
            else
                context.Response.StatusCode = 404;
        }

        private void ListCurrentFiles(HttpContext context)
        {
            if (string.IsNullOrEmpty(context.Request.QueryString["action"]))
            {
                return;
            }
            string txnNum = context.Request.QueryString["txnnum"];
            string crateCode = context.Request.QueryString["crateCode"];
            string UploadFileRoot = StorageRoot + txnNum + "//" + crateCode + "//";

            string jsonObj = "";
            if (!Directory.Exists(UploadFileRoot))
            {
                //string[] files = new string[] { };
                Files f = new Files();
                f.files = new string[] { };
                jsonObj = js.Serialize(f);
            }
            else
            {
                var files =
                    //new DirectoryInfo(StorageRoot)
               new DirectoryInfo(UploadFileRoot)
                   .GetFiles("*", SearchOption.TopDirectoryOnly)
                   .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
                   .Select(f => new FilesStatus(f, txnNum + @"//" + crateCode + "//"))
                   .ToArray();

                jsonObj = js.Serialize(Files.GetFiles(files));
            }
           
            context.Response.AddHeader("Content-Disposition", "inline; filename=\"files.json\"");
            context.Response.Write(jsonObj);
            context.Response.ContentType = "application/json";
        }

        class Files
        {
            public object files = null;
            public static Files GetFiles(FilesStatus[] fs)
            {
                Files f = new Files();
                f.files = fs;
                return f;
            }
        }
        class FilesStatus
        {
            public const string HandlerPath = "/";

          
            public string group { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public int size { get; set; }
            public string progress { get; set; }
            public string url { get; set; }
            public string thumbnail_url { get; set; }
            public string delete_url { get; set; }
            public string delete_type { get; set; }
            public string error { get; set; }

            public FilesStatus() { }
            public FilesStatus(FileInfo fileInfo,string d) { SetValues(d,fileInfo.Name, (int)fileInfo.Length); }
            public FilesStatus(FileInfo fileInfo) { SetValues(fileInfo.Name, (int)fileInfo.Length); }

            public FilesStatus(string fileName, int fileLength,string d) { SetValues(d,fileName, fileLength); }
            private void SetValues(string fileName, int fileLength)
            {
                SetValues("", fileName, fileLength);
            }
            private void SetValues(string directory,string fileName, int fileLength)
            {
                string d = string.IsNullOrEmpty(directory) ? "" : "&d="+directory;
                name = fileName;
                type = "image/png";
                size = fileLength;
                progress = "1.0";
                url = HandlerPath + "Services/FileUpload/MWFileUploadHandler.ashx?f=" + fileName+d;
                thumbnail_url = HandlerPath + "Services/FileUpload/Thumbnail.ashx?f=" + fileName+d;
                delete_url = HandlerPath + "Services/FileUpload/MWFileUploadHandler.ashx?f=" + fileName+d;
                delete_type = "DELETE";
            }
        }

    }
}