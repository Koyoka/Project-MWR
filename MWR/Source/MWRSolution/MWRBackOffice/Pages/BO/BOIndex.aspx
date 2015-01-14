<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="BOIndex.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BOIndex" %>
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
                <li class="dropdown" id="header_notification_bar"><a href="#" class="dropdown-toggle"
                    data-toggle="dropdown" data-hover="dropdown" data-close-others="true"><i class="fa fa-warning">
                    </i><span class="badge">6 </span></a>
                    <ul class="dropdown-menu extended notification">
                        <li>
                            <p>
                                You have 14 new notifications
                            </p>
                        </li>
                        <li>
                            <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto;
                                height: 250px;">
                                <ul class="dropdown-menu-list scroller" style="height: 250px; overflow: hidden; width: auto;">
                                    <li><a href="#"><span class="label label-icon label-success"><i class="fa fa-plus"></i>
                                    </span>New user registered. <span class="time">Just now </span></a></li>
                                    <li><a href="#"><span class="label label-icon label-danger"><i class="fa fa-bolt"></i>
                                    </span>Server #12 overloaded. <span class="time">15 mins </span></a></li>
                                    <li><a href="#"><span class="label label-icon label-warning"><i class="fa fa-bell-o">
                                    </i></span>Server #2 not responding. <span class="time">22 mins </span></a></li>
                                    <li><a href="#"><span class="label label-icon label-info"><i class="fa fa-bullhorn">
                                    </i></span>Application error. <span class="time">40 mins </span></a></li>
                                    <li><a href="#"><span class="label label-icon label-danger"><i class="fa fa-bolt"></i>
                                    </span>Database overloaded 68%. <span class="time">2 hrs </span></a></li>
                                    <li><a href="#"><span class="label label-icon label-danger"><i class="fa fa-bolt"></i>
                                    </span>2 user IP blocked. <span class="time">5 hrs </span></a></li>
                                    <li><a href="#"><span class="label label-icon label-warning"><i class="fa fa-bell-o">
                                    </i></span>Storage Server #4 not responding. <span class="time">45 mins </span></a>
                                    </li>
                                    <li><a href="#"><span class="label label-icon label-info"><i class="fa fa-bullhorn">
                                    </i></span>System Error. <span class="time">55 mins </span></a></li>
                                    <li><a href="#"><span class="label label-icon label-danger"><i class="fa fa-bolt"></i>
                                    </span>Database overloaded 68%. <span class="time">2 hrs </span></a></li>
                                </ul>
                                <div class="slimScrollBar" style="width: 7px; position: absolute; top: 0px; opacity: 0.4;
                                    display: block; border-radius: 7px; z-index: 99; right: 1px; background: rgb(161, 178, 189);">
                                </div>
                                <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute;
                                    top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px;
                                    background: rgb(51, 51, 51);">
                                </div>
                            </div>
                        </li>
                        <li class="external"><a href="#">See all notifications <i class="m-icon-swapright"></i>
                        </a></li>
                    </ul>
                </li>
                <!-- END NOTIFICATION DROPDOWN -->
                <!-- BEGIN INBOX DROPDOWN -->
                <li class="dropdown" id="header_inbox_bar"><a href="#" class="dropdown-toggle" data-toggle="dropdown"
                    data-hover="dropdown" data-close-others="true"><i class="fa fa-envelope"></i><span
                        class="badge">5 </span></a>
                    <ul class="dropdown-menu extended inbox">
                        <li>
                            <p>
                                You have 12 new messages
                            </p>
                        </li>
                        <li>
                            <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto;
                                height: 250px;">
                                <ul class="dropdown-menu-list scroller" style="height: 250px; overflow: hidden; width: auto;">
                                    <li><a href="inbox.html?a=view"><span class="photo">
                                        <img src="/assets/img/avatar2.jpg" alt="">
                                    </span><span class="subject"><span class="from">Lisa Wong </span><span class="time">
                                        Just Now </span></span><span class="message">Vivamus sed auctor nibh congue nibh. auctor
                                            nibh auctor nibh... </span></a></li>
                                    <li><a href="inbox.html?a=view"><span class="photo">
                                        <img src="/assets/img/avatar3.jpg" alt="">
                                    </span><span class="subject"><span class="from">Richard Doe </span><span class="time">
                                        16 mins </span></span><span class="message">Vivamus sed congue nibh auctor nibh congue
                                            nibh. auctor nibh auctor nibh... </span></a></li>
                                    <li><a href="inbox.html?a=view"><span class="photo">
                                        <img src="/assets/img/avatar1.jpg" alt="">
                                    </span><span class="subject"><span class="from">Bob Nilson </span><span class="time">
                                        2 hrs </span></span><span class="message">Vivamus sed nibh auctor nibh congue nibh.
                                            auctor nibh auctor nibh... </span></a></li>
                                    <li><a href="inbox.html?a=view"><span class="photo">
                                        <img src="/assets/img/avatar2.jpg" alt="">
                                    </span><span class="subject"><span class="from">Lisa Wong </span><span class="time">
                                        40 mins </span></span><span class="message">Vivamus sed auctor 40% nibh congue nibh...
                                        </span></a></li>
                                    <li><a href="inbox.html?a=view"><span class="photo">
                                        <img src="/assets/img/avatar3.jpg" alt="">
                                    </span><span class="subject"><span class="from">Richard Doe </span><span class="time">
                                        46 mins </span></span><span class="message">Vivamus sed congue nibh auctor nibh congue
                                            nibh. auctor nibh auctor nibh... </span></a></li>
                                </ul>
                                <div class="slimScrollBar" style="width: 7px; position: absolute; top: 0px; opacity: 0.4;
                                    display: block; border-radius: 7px; z-index: 99; right: 1px; background: rgb(161, 178, 189);">
                                </div>
                                <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute;
                                    top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px;
                                    background: rgb(51, 51, 51);">
                                </div>
                            </div>
                        </li>
                        <li class="external"><a href="inbox.html">See all messages <i class="m-icon-swapright">
                        </i></a></li>
                    </ul>
                </li>
                <!-- END INBOX DROPDOWN -->
                <!-- BEGIN TODO DROPDOWN -->
                <li class="dropdown" id="header_task_bar"><a href="#" class="dropdown-toggle" data-toggle="dropdown"
                    data-hover="dropdown" data-close-others="true"><i class="fa fa-tasks"></i><span class="badge">
                        5 </span></a>
                    <ul class="dropdown-menu extended tasks">
                        <li>
                            <p>
                                You have 12 pending tasks
                            </p>
                        </li>
                        <li>
                            <div class="slimScrollDiv" style="position: relative; overflow: hidden; width: auto;
                                height: 250px;">
                                <ul class="dropdown-menu-list scroller" style="height: 250px; overflow: hidden; width: auto;">
                                    <li><a href="#"><span class="task"><span class="desc">New release v1.2 </span><span
                                        class="percent">30% </span></span><span class="progress"><span style="width: 40%;"
                                            class="progress-bar progress-bar-success" aria-valuenow="40" aria-valuemin="0"
                                            aria-valuemax="100"><span class="sr-only">40% Complete </span></span></span>
                                    </a></li>
                                    <li><a href="#"><span class="task"><span class="desc">Application deployment </span>
                                        <span class="percent">65% </span></span><span class="progress progress-striped"><span
                                            style="width: 65%;" class="progress-bar progress-bar-danger" aria-valuenow="65"
                                            aria-valuemin="0" aria-valuemax="100"><span class="sr-only">65% Complete </span>
                                        </span></span></a></li>
                                    <li><a href="#"><span class="task"><span class="desc">Mobile app release </span><span
                                        class="percent">98% </span></span><span class="progress"><span style="width: 98%;"
                                            class="progress-bar progress-bar-success" aria-valuenow="98" aria-valuemin="0"
                                            aria-valuemax="100"><span class="sr-only">98% Complete </span></span></span>
                                    </a></li>
                                    <li><a href="#"><span class="task"><span class="desc">Database migration </span><span
                                        class="percent">10% </span></span><span class="progress progress-striped"><span style="width: 10%;"
                                            class="progress-bar progress-bar-warning" aria-valuenow="10" aria-valuemin="0"
                                            aria-valuemax="100"><span class="sr-only">10% Complete </span></span></span>
                                    </a></li>
                                    <li><a href="#"><span class="task"><span class="desc">Web server upgrade </span><span
                                        class="percent">58% </span></span><span class="progress progress-striped"><span style="width: 58%;"
                                            class="progress-bar progress-bar-info" aria-valuenow="58" aria-valuemin="0" aria-valuemax="100">
                                            <span class="sr-only">58% Complete </span></span></span></a></li>
                                    <li><a href="#"><span class="task"><span class="desc">Mobile development </span><span
                                        class="percent">85% </span></span><span class="progress progress-striped"><span style="width: 85%;"
                                            class="progress-bar progress-bar-success" aria-valuenow="85" aria-valuemin="0"
                                            aria-valuemax="100"><span class="sr-only">85% Complete </span></span></span>
                                    </a></li>
                                    <li><a href="#"><span class="task"><span class="desc">New UI release </span><span
                                        class="percent">18% </span></span><span class="progress progress-striped"><span style="width: 18%;"
                                            class="progress-bar progress-bar-important" aria-valuenow="18" aria-valuemin="0"
                                            aria-valuemax="100"><span class="sr-only">18% Complete </span></span></span>
                                    </a></li>
                                </ul>
                                <div class="slimScrollBar" style="width: 7px; position: absolute; top: 0px; opacity: 0.4;
                                    display: block; border-radius: 7px; z-index: 99; right: 1px; background: rgb(161, 178, 189);">
                                </div>
                                <div class="slimScrollRail" style="width: 7px; height: 100%; position: absolute;
                                    top: 0px; display: none; border-radius: 7px; opacity: 0.2; z-index: 90; right: 1px;
                                    background: rgb(51, 51, 51);">
                                </div>
                            </div>
                        </li>
                        <li class="external"><a href="#">See all tasks <i class="m-icon-swapright"></i></a>
                        </li>
                    </ul>
                </li>
                <!-- END TODO DROPDOWN -->
                <!-- BEGIN USER LOGIN DROPDOWN -->
                <li class="dropdown user"><a href="#" class="dropdown-toggle" data-toggle="dropdown"
                    data-hover="dropdown" data-close-others="true">
                    <img alt="" src="/assets/img/avatar1_small.jpg">
                    <span class="username">Bob Nilson </span><i class="fa fa-angle-down"></i></a>
                    <ul class="dropdown-menu">
                        <li><a href="extra_profile.html"><i class="fa fa-user"></i>My Profile</a> </li>
                        <li><a href="page_calendar.html"><i class="fa fa-calendar"></i>My Calendar</a> </li>
                        <li><a href="inbox.html"><i class="fa fa-envelope"></i>My Inbox <span class="badge badge-danger">
                            3 </span></a></li>
                        <li><a href="#"><i class="fa fa-tasks"></i>My Tasks <span class="badge badge-success">
                            7 </span></a></li>
                        <li class="divider"></li>
                        <li><a href="javascript:;" id="trigger_fullscreen"><i class="fa fa-move"></i>Full Screen</a>
                        </li>
                        <li><a href="extra_lock.html"><i class="fa fa-lock"></i>Lock Screen</a> </li>
                        <li><a href="login.html"><i class="fa fa-key"></i>Log Out</a> </li>
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
                            <li id="MW_Car_Locus" class=""><a href="#<% = RedirectHelper.CarLocus %>">
                                车辆历史轨迹</a> </li>
                            <li id="MW_Car_Round" class=""><a href="#<% = RedirectHelper.CarRound %>">
                                地理围栏设置</a> </li>
                        </ul>
                    </li>
                    <li id="MW_Inventory" class=""><a href="javascript:void;"><i class="fa fa-shopping-cart">
                    </i><span class="title">库存管理 </span><span class="arrow "></span><span class="selected">
                    </span></a>
                        <ul class="sub-menu">
                            <li id="MW_Inventory_Auth" class=""><a href="javascript:void;">货损审核</a> </li>
                            <li id="MW_Inventory_Log" class=""><a href="javascript:void;">出入库日志</a> </li>
                            <li id="MW_Residue_Log" class=""><a href="javascript:void;">残渣处理日志</a> </li>
                        </ul>
                    </li>
                    <li id="MW_Report" class=" "><a href="javascript:;"><i class="fa fa-bar-chart-o"></i>
                        <span class="title">统计查询 </span><span class="arrow "></span><span class="selected">
                        </span></a>
                        <ul class="sub-menu">
                            <li><a href="javascript:void;">医疗机构产量查询</a> </li>
                            <li><a href="javascript:void;">运量查询</a> </li>
                            <li><a href="javascript:void;">库存量查询</a> </li>
                            <li><a href="javascript:void;">处置量查询</a> </li>
                            <li><a href="javascript:void;">厂区产量查询</a> </li>
                        </ul>
                    </li>
                    <li id="MW_DailyClose" class=" "><a href="javascript:;"><i class="fa fa-pencil-square-o">
                    </i><span class="title">结算上报</span> <span class="selected"></span></a></li>
                    <li id="MW_BaseData" class=" "><a href="javascript:;"><i class="fa fa-folder-open-o">
                    </i><span class="title">基础档案管理 </span><span class="arrow "></span><span class="selected">
                    </span></a>
                        <ul class="sub-menu">
                            <li class=""><a href="javascript:void;">员工档案</a> </li>
                            <li class=""><a href="javascript:void;">车辆档案</a> </li>
                            <li><a href="javascript:void;">货箱档案</a> </li>
                            <li><a href="javascript:void;">仓库档案</a> </li>
                            <li><a href="javascript:void;">医院档案</a> </li>
                            <li><a href="javascript:void;">医疗废物档案</a> </li>
                        </ul>
                    </li>
                    <li id="MW_Sys" class="last "><a href="javascript:;"><i class="fa fa-cogs"></i><span
                        class="title">系统管理 </span><span class="arrow "></span><span class="selected"></span>
                    </a>
                        <ul class="sub-menu">
                            <li class=""><a href="javascript:void;">参数设置</a> </li>
                            <li class=""><a href="javascript:void;">权限管理</a> </li>
                            <li class=""><a href="javascript:void;">数据初始化</a> </li>
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

                   <div class="modal fade" id="portlet-config" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
			            <div class="modal-dialog">
				            <div class="modal-content">
					            <div class="modal-header">
						            <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
						            <h4 class="modal-title">Modal title</h4>
					            </div>
					            <div class="modal-body">
							            Widget settings form goes here
					            </div>
					            <div class="modal-footer">
						            <button type="button" class="btn blue">Save changes</button>
						            <button type="button" class="btn default" data-dismiss="modal">Close</button>
					            </div>
				            </div>
				            <!-- /.modal-content -->
			            </div>
			            <!-- /.modal-dialog -->
		            </div>

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
