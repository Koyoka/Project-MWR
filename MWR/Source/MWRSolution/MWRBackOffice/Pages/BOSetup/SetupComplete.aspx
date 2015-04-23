<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="SetupComplete.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BOSetup.SetupComplete" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="note note-success">
	<p>
        系统完成初始化，<a href="<% = WebAppFn.GetBoFullPageUrl("index.html") %>">点我</a>开始使用！
	</p>
</div>
<center>
<img src="../../Assets/images/complete.png" />
</center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
