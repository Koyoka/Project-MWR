<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
error<br />
<% = string.IsNullOrEmpty(Request.QueryString["Msg"]) ? "" : Request.QueryString["Msg"].ToString()%>
<script>
//    window.alert(window.location.search)
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
