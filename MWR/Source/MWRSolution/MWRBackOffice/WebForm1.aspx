﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="YRKJ.MWR.BackOffice.WebForm1" %>
<div style="display:none;">
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
         <% = dbPassword%><br />