<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="BOIndex.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BOIndex" %>
<%@ Register src="~/Pages/UCtrl/UModal.ascx" tagname="UModal" tagprefix="uc1" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<%--header--%>
    <div class="header navbar navbar-inverse navbar-fixed-top">
        <!-- BEGIN TOP NAVIGATION BAR -->
        <div class="header-inner">
            <!-- BEGIN LOGO -->
            <a class="navbar-brand" href="index.html"><span class="mw-log">医疗废物回收管理系统</span>
            </a>
            <!-- END LOGO -->
            <!-- BEGIN RESPONSIVE MENU TOGGLER -->
            <a href="javascript:;" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                <img src="/assets/img/menu-toggler.png" alt="">
            </a>
            <!-- END RESPONSIVE MENU TOGGLER -->
            <!-- BEGIN TOP NAVIGATION MENU -->
            <ul class="nav navbar-nav pull-right">
                <!-- BEGIN NOTIFICATION DROPDOWN -->
                <%--<li class="dropdown" id="header_notification_bar"><a href="#" class="dropdown-toggle"
                    data-toggle="dropdown" data-hover="dropdown" data-close-others="true"><i class="fa fa-warning">
                    </i><span class="badge">6 </span></a>
                 
                </li>--%>
                <!-- END NOTIFICATION DROPDOWN -->
                <!-- BEGIN INBOX DROPDOWN -->
              <%--  <li class="dropdown" id="header_inbox_bar"><a href="#" class="dropdown-toggle" data-toggle="dropdown"
                    data-hover="dropdown" data-close-others="true"><i class="fa fa-envelope"></i><span
                        class="badge">5 </span></a>

                </li>--%>
                <!-- END INBOX DROPDOWN -->
                <!-- BEGIN TODO DROPDOWN -->
                <%--<li class="dropdown" id="header_task_bar"><a href="#" class="dropdown-toggle" data-toggle="dropdown"
                    data-hover="dropdown" data-close-others="true"><i class="fa fa-tasks"></i><span class="badge">
                        5 </span></a>
            
                </li>--%>
                <!-- END TODO DROPDOWN -->
                <!-- BEGIN USER LOGIN DROPDOWN -->
                <li class="dropdown user"><a href="#" class="dropdown-toggle" data-toggle="dropdown"
                    data-hover="dropdown" data-close-others="true">
                    <img alt="" src="/assets/img/avatar1_small.jpg">
                    <span class="username">
                    <% = PageEmpyNameData%>
                    
                    </span><i class="fa fa-angle-down"></i></a>
                    <ul class="dropdown-menu">
                        <%--<li><a href="extra_profile.html"><i class="fa fa-user"></i>My Profile</a> </li>--%>
                        <%--<li><a href="page_calendar.html"><i class="fa fa-calendar"></i>My Calendar</a> </li>--%>
                        <%--<li><a href="inbox.html"><i class="fa fa-envelope"></i>My Inbox <span class="badge badge-danger">
                            3 </span></a></li>
                        <li><a href="#"><i class="fa fa-tasks"></i>My Tasks <span class="badge badge-success">
                            7 </span></a></li>
                        <li class="divider"></li>--%>
                        <li><a href="javascript:;" id="trigger_fullscreen"><i class="fa fa-move"></i>全屏</a>
                        </li>
                     <%--   <li><a href="extra_lock.html"><i class="fa fa-lock"></i>Lock Screen</a> </li>--%>
                        <li><a href="index.html"><i class="fa fa-key"></i>登出</a> </li>
                    </ul>
                </li>
                <!-- END USER LOGIN DROPDOWN -->
            </ul>
            <!-- END TOP NAVIGATION MENU -->
        </div>
        <!-- END TOP NAVIGATION BAR -->
    </div>
    <div class="clearfix">
    </div>
<%--header end--%>

<%--container--%>
<div class="page-container">
        <!-- BEGIN SIDEBAR -->
        <div class="page-sidebar-wrapper">
            <div class="page-sidebar navbar-collapse collapse">
                <!-- BEGIN SIDEBAR MENU -->
                <ul class="page-sidebar-menu">
                    <li class="sidebar-toggler-wrapper">
                        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                        <div class="sidebar-toggler hidden-phone">
                        </div>
                        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                    </li>
                    <li class="sidebar-search-wrapper">
                        <!-- BEGIN RESPONSIVE QUICK SEARCH FORM -->
                        <form class="sidebar-search" action="extra_search.html" method="POST">
                        <div class="form-container">
                            <div class="input-box">
                                <a href="javascript:;" class="remove"></a>
                                <input type="text" placeholder="货箱号...">
                                <input type="button" class="submit" value=" ">
                            </div>
                        </div>
                        </form>
                        <!-- END RESPONSIVE QUICK SEARCH FORM -->
                    </li>
                    <li id="MW_Home" class="start "><a class=""  href="#BOMain.aspx">
                        <i class="fa fa-home"></i><span class="title">首页 </span><span class="selected"></span>
                    </a></li>
                    <li id="MW_Car" class=" "><a href="javascript:void;"><i class="fa fa-truck "></i><span
                        class="title">车辆管理 </span><span class="arrow "></span><span class="selected"></span>
                    </a>
                        <ul class="sub-menu">
                            <li id="MW_Car_Dispatch" class=""><a href="#<% = RedirectHelper.CarDispatch %>">
                                车辆调度管理</a> </li>
                            <li id="MW_Car_Track" class=""><a href="#<% = RedirectHelper.CarTrack %>">
                                车辆行驶跟踪</a> </li>
                           <%-- <li id="MW_Car_Locus" class=""><a href="#<% = RedirectHelper.CarLocus %>">
                                车辆历史轨迹</a> </li>
                            <li id="MW_Car_Round" class=""><a href="#<% = RedirectHelper.CarRound %>">
                                地理围栏设置</a> </li>--%>
                        </ul>
                    </li>
                    <li id="MW_Inventory" class=""><a href="javascript:void;"><i class="fa fa-shopping-cart">
                    </i><span class="title">库存管理 </span><span class="arrow "></span><span class="selected">
                    </span></a>
                        <ul class="sub-menu">
                            <li id="MW_Inventory_Auth" class=""><a href="#<% = RedirectHelper.InvAuthorize %>">货损审核</a> </li>
                             <li id="MW_Inventory_Auth_Log" class=""><a href="#<% = RedirectHelper.InvAuthorizelog %>">审核日志</a> </li>
                            <li id="MW_Recover_Log" class=""><a href="#<% = RedirectHelper.RecoverLog %>">回收入库日志</a> </li>
                            <li id="MW_Post_Log" class=""><a href="#<% = RedirectHelper.PostLog %>">废品出库日志</a> </li>
                            <li id="MW_Residue_Log" class=""><a href="#<% = RedirectHelper.DestroyLog %>">废品处理日志</a> </li>
                        </ul>
                    </li>
                    <li id="MW_Report" class=" "><a href="javascript:;"><i class="fa fa-bar-chart-o"></i>
                        <span class="title">统计报告 </span><span class="arrow "></span><span class="selected">
                        </span></a>
                        <ul class="sub-menu">
                            <li><a href="#<% = RedirectHelper.IntegratedReport %>">综合报告</a> </li>
                            <li><a href="#<% = RedirectHelper.RecoverReport %>">运量报告</a> </li>
                            <li><a href="#<% = RedirectHelper.PostReport %>">出库报告</a> </li>
                            <li><a href="#<% = RedirectHelper.DestroyReport %>">处置量报告</a> </li>
                          <%--  <li><a href="javascript:void;">厂区产量报告</a> </li>--%>
                        </ul>
                    </li>
                  <%--  <li id="MW_DailyClose" class=" "><a href="javascript:;"><i class="fa fa-pencil-square-o">
                    </i><span class="title">结算上报</span> <span class="selected"></span></a></li>--%>
                    <li id="MW_BaseData" class=" "><a href="javascript:;"><i class="fa fa-folder-open-o">
                    </i><span class="title">基础档案管理 </span><span class="arrow "></span><span class="selected">
                    </span></a>
                        <ul class="sub-menu">
                            <li class=""><a href="#<% = RedirectHelper.BDEmploy %>">员工档案</a> </li>
                            <li class=""><a href="#<% = RedirectHelper.BDCar %>">车辆档案</a> </li>
                            <li><a href="#<% = RedirectHelper.BDCrate %>">货箱档案</a> </li>
                            <li><a href="#<% = RedirectHelper.BDDepot %>">仓库档案</a> </li>
                            <li><a href="#<% = RedirectHelper.BDVendor %>">医院档案</a> </li>
                            <li><a href="#<% = RedirectHelper.BDWaste %>">医疗废物档案</a> </li>
                        </ul>
                    </li>
                    <li id="MW_Sys" class="last "><a href="javascript:;"><i class="fa fa-cogs"></i><span
                        class="title">系统管理 </span><span class="arrow "></span><span class="selected"></span>
                    </a>
                        <ul class="sub-menu">
                            <li class=""><a href="#<% = RedirectHelper.WSManage %>">工作站管理</a> </li>
                            <li class=""><a href="#<% = RedirectHelper.UserPermit %>">权限管理</a> </li>
                            <li class=""><a href="#<% = RedirectHelper.SysParams %>">参数设置</a> </li>
                           
                            <li class=""><a href="#<% = RedirectHelper.SysInit %>">数据初始化</a> </li>
                            <li class=""><a href="#<% = RedirectHelper.SysAdmin %>">超级管理员</a> </li>
                        </ul>
                    </li>
                </ul>
                <!-- END SIDEBAR MENU -->
            </div>
        </div>
         <!-- END SIDEBAR -->
        <!-- BEGIN CONTENT -->
         <div class="page-content-wrapper">
            <div class="page-content" style="">
                   <uc1:UModal ID="UModal1" runat="server" />
                <%--<span id="cc" data-wgt="t">Eleven</span>--%>
                <div class="page-content-body" data-default="<% = RedirectHelper.BOMain %>" data-wgt="mw-loadpage">                 </div>
            </div>
        </div>
        <!-- END CONTENT -->
</div>
<%--container end--%>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="foot" runat="server">

<script src="/assets/boindex.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        IndexHelper.init();
    });
</script>
</asp:Content>
