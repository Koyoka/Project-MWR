<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="YRKJ.MWR.BackOffice.WebForm1" %>
{"Orders":[{"OrderNumber":"","CustomerHxUserName":"","VendorHxUserName":"","OrderStatus":0,"PaymentStatus":0,"CustomerRemark":"","OrderRemark":"","ShipAddress":"","ShipContactName":"","ShipContactPhone":"","Id":0}]}

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
        Response.Write("count:"+files.Length);
        return;
    }
     %>

<%--<div style="display:none;">
<% = HttpRuntime.AppDomainAppPath  %>
<br />
<% = Server.MapPath("")%>
<br />// ComLib.ComFn.AESDecrypt(ss)
<% = Request.ApplicationPath %><br />
<% string s = ComLib.ComFn.EncryptDBPassword("1ADSFADF11", "eleveneleveneleveneleveneleveneleveneleveneleveneleven"); %><br />
<% = s %><br />
</div>
<% = s %>
<br />

<br />
<%
    string DBKey = "pMwrdbWORDTaBlE01234567890123456";
    string ss = ComLib.ComFn.AESEncrypt(DBKey,"-101868");
     %>
     <% = ss %><br />
     <%
         string DBKey1 = "pMwrdbWORD";
    string sss = ComLib.ComFn.AESEncrypt(DBKey1, "yrkj@1q2w3e");
     %>
     <% = sss  %><br />
     <% = ComLib.ComFn.DecryptDBPassword( DBKey1,sss)%>

     <% 
         
         string dbName = System.Configuration.ConfigurationManager.AppSettings["DBName"].ToString();
         string dbService = System.Configuration.ConfigurationManager.AppSettings["DBService"].ToString();
         string dbUser = System.Configuration.ConfigurationManager.AppSettings["DBUser"].ToString();
         string dbPassword = System.Configuration.ConfigurationManager.AppSettings["DBPassword"].ToString();
         string dbKey = System.Configuration.ConfigurationManager.AppSettings["Key"].ToString();
         dbPassword = ComLib.ComFn.DecryptDBPassword(dbKey, dbPassword);
         %><br />
         ================1111<br />
         <% = dbName %><br />
         <% = dbService%><br />
         <% = dbUser%><br />
         <% = dbPassword%><br />--%>