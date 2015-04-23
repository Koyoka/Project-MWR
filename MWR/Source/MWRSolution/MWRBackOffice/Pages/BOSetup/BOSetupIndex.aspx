<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="BOSetupIndex.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BOInit.BOInitIndex" %>
<%@ Register src="~/Pages/UCtrl/UModal.ascx" tagname="UModal" tagprefix="uc1" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<div class="header navbar navbar-inverse navbar-fixed-top">
    <div class="header-inner">
        <a class="navbar-brand" href="index.html"><span class="mw-log">医废回收管理系统</span>
        </a>
        <a href="javascript:;" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <img src="/assets/img/menu-toggler.png" alt="">
        </a>
        <ul class="nav navbar-nav pull-right">
               
        </ul>
    </div>
</div>
<div class="page-container">
    
        <div class="page-sidebar-wrapper">
            <div class="page-sidebar navbar-collapse collapse">
                <ul class="page-sidebar-menu">
                   <li class="sidebar-toggler-wrapper">
                        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                       <%-- <div class=""><br />
                        系统初始化<br />
                        </div>--%>
                        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                    </li>
                   <li id="step1" class="start "><a class="active" href="#SetupAdmin.aspx">
                        <i class="fa fa-home"></i><span class="title">1.配置超级管理员 </span><span class="selected"></span>
                    </a></li>
                    <li id="step2" class=" disabled-link"><a class="" href="#SetupParams.aspx">
                        <i class="fa fa-home"></i><span class="title">2.基础参数设置 </span><span class="selected"></span>
                    </a></li>
                    <li id="step3" class=" disabled-link"><a class="active" href="#SetupInitBaseData.aspx">
                        <i class="fa fa-home"></i><span class="title">3.初始化基础数据 </span><span class="selected"></span>
                    </a></li>
                    <li id="Li5" class="last disabled-link"><a class="active" href="#SetupComplete.aspx">
                        <i class="fa fa-home"></i><span class="title">完成 </span><span class=""></span>
                    </a></li>

                </ul>
            </div>
        </div>

    <div class="page-content-wrapper">
            <div class="page-content" style="">
                   <uc1:UModal ID="UModal1" runat="server" />
                   <div class="page-content-body" data-default="SetupAdmin.aspx" data-wgt="mw-loadpage">                    </div>
               
            </div>
        </div>

</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">


<script src="/assets/bosetupindex.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        SetupIndexHelper.init();
    });
</script>
</asp:Content>
