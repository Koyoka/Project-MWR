<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="CarTrack.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Car.CarTrack" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">

<% = YRKJ.MWR.Business.Sys.MWParams.GetCarGPSMapCode()%>
<iframe src="http://121.199.17.68:8081/cardispath.html" width="100%" height="100%" frameborder="0"></iframe>

 </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script>
        jQuery(document).ready(function () {
            $('iframe').height($(document).height());
        });
 </script>

</asp:Content>
