<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="CarRound.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Car.CarRound" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">

<% = YRKJ.MWR.Business.Sys.MWParams.GetCarGPSMapCode()%>
 </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
 <script>
     jQuery(document).ready(function () {
         $('iframe').height($(document).height()-200);
     });
 </script>

</asp:Content>
