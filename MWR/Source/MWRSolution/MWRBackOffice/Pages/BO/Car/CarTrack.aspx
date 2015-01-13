<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOMain.master" AutoEventWireup="true" CodeBehind="CarTrack.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Car.CarTrack" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <script type="text/javascript">
     jQuery(document).ready(function () {
         MW_AppHelper.SetCurMenu("MW_Car", "MW_Car_Track");


     });
    </script>

</asp:Content>
