
<%@ Page Language="C#" %>
<%
    string path = Server.MapPath("~/Setting");
    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
    if (di.Exists)
    {
        System.IO.FileInfo[] files = di.GetFiles();
        foreach (var item in files)
        {
            Response.Write("count:" + item.Name);
        }
        return;
    }
     %>