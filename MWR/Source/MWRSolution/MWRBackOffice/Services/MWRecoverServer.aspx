<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MWRecoverServer.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Services.MWRecoverServer" %>




<% = Request.ContentType  %>
<br/ >
<% = Request.Headers.Get("Date")%>
<br/ >
<% = Request.Url %>
<br/ >
<% = Request.HttpMethod %>
<br/ >
<% = Request.RawUrl %> == 1
<br/ >
<% 
    string responseData = "";
    using (System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream, Encoding.UTF8))
    {
        responseData = sr.ReadToEnd();

        sr.Close();
    }
%>
<% = responseData %>  == 2
<br />
<% = Request.Headers.Get("Authorization")%>
<br />
<% 
    string _S_SECRET_KEY = ComLib.AuthorizationHelper.S_SECRET_KEY;
    string reqMethod = Request.HttpMethod;
    string contentType = Request.ContentType;
    string date = Request.Headers.Get("Date");
    string fullUrl = Request.Url.ToString();
    string encryptStr = "";
    encryptStr = ComLib.AuthorizationHelper.EncryptWebBody(_S_SECRET_KEY, reqMethod, contentType, date, fullUrl, responseData, Encoding.UTF8);
    
    %>
    <% = encryptStr %>