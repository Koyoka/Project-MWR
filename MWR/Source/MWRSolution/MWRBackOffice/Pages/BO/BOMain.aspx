﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master"
    AutoEventWireup="true" CodeBehind="BOMain.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BOMain" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
            <!-- begin target bar -->
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN PAGE TITLE & BREADCRUMB-->
                    <h3 class="page-title">
                        首页 <small>欢迎登录医疗废物回收管理系统</small>
                    </h3>
                    <ul class="page-breadcrumb breadcrumb">
                        <li class="btn-group">
                            <%--<button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown"
                                data-delay="1000" data-close-others="true">
                                <span>Actions </span><i class="fa fa-angle-down"></i>
                            </button>
                            <ul class="dropdown-menu pull-right" role="menu">
                                <li><a href="#">Action</a> </li>
                                <li><a href="#">Another action</a> </li>
                                <li><a href="#">Something else here</a> </li>
                                <li class="divider"></li>
                                <li><a href="#">Separated link</a> </li>
                            </ul>--%>
                        </li>
                        <li><i class="fa fa-home"></i><a href="#<% = RedirectHelper.BOMain %>">首页</a>
                            <!-- <i class="fa fa-angle-right"></i>-->
                        </li>
                        <!-- <li>
                <a href="#">Layouts</a> 
                <i class="fa fa-angle-right"></i>
            </li>
            <li><a href="#">Blank Page</a> </li>-->
                    </ul>
                    <!-- END PAGE TITLE & BREADCRUMB-->
                </div>
            </div>
            <div class="clearfix">
            </div>
            <!-- end target bar -->

            <!--begin Home page short operate -->
            <div class="row">
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat blue">
                        <div class="visual">
                            <i class="fa fa-truck"></i>
                        </div>
                        <div class="details">
                            <div class="number">
                                <% = PageMainPageReport.CarOutCount%>
                            </div>
                            <div class="desc">
                                当前外出车辆
                            </div>
                        </div>
                        <a class="more mw-redirect" href="<% = RedirectHelper.CarDispatch %>">车辆调度 <i class="m-icon-swapright m-icon-white"></i></a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat green">
                        <div class="visual">
                            <i class="fa fa-shopping-cart"></i>
                        </div>
                        <div class="details">
                            <div class="number">
                                <% =  PageMainPageReport.AuthorizeCount %>
                            </div>
                            <div class="desc">
                                待审核货箱
                            </div>
                        </div>
                        <a class="more mw-redirect" href="<% = RedirectHelper.InvAuthorize %>">进入审核 <i class="m-icon-swapright m-icon-white"></i></a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat purple">
                        <div class="visual">
                            <i class="fa fa-bar-chart-o"></i>
                        </div>
                        <div class="details">
                            <div class="number">
                                <% = PageMainPageReport.TodayRecoverCount %> KG
                            </div>
                            <div class="desc">
                                今日入库总量
                            </div>
                        </div>
                        <a class="more mw-redirect" href="<% = RedirectHelper.RecoverLog %>">库存查看 <i class="m-icon-swapright m-icon-white"></i></a>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                    <div class="dashboard-stat yellow">
                        <div class="visual">
                            <i class="fa fa-bar-chart-o"></i>
                        </div>
                        <div class="details">
                            <div class="number">
                                <% = PageMainPageReport.TodayDestoryCount %> KG
                            </div>
                            <div class="desc">
                                今日处置总量
                            </div>
                        </div>
                        <a class="more mw-redirect" href="<% = RedirectHelper.DestroyLog %>">处置查看 <i class="m-icon-swapright m-icon-white"></i></a>
                    </div>
                </div>
            </div>
            <div class="clearfix">
            </div>
            <!--end Home page short operate -->

            <!--begin Home page MWR detail -->
            <div class="row ">
                <div class="col-md-6 col-sm-6">
                    <!-- BEGIN PORTLET-->
                    <div class="portlet paddingless">
                        <div class="portlet-title line">
                            <div class="caption">
                                <i class="fa fa-bell-o"></i>今日工作站处理记录
                            </div>
                            <div class="tools">
                                <a href="" class="collapse"></a><%--<a href="" class="reload"></a>--%>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <!--BEGIN TABS-->
                            <div class="tabbable tabbable-custom">
                                <ul class="nav nav-tabs">
                                    <li class="active"><a href="#tab_1_1" data-toggle="tab">出入库工作站</a> </li>
                                    <li><a href="#tab_1_2" data-toggle="tab">处置工作站</a> </li>
                                </ul>
                                <div class="tab-content">
                                    <div class="tab-pane active" id="tab_1_1">
                                        <div class="scroller" style="height: 430px;" data-always-visible="1" data-rail-visible="0">
                                            <ul class="feeds">
                                                <%
	foreach (var item in PageIWSTxnDetailDataList)
	{
                                                %>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <%--<div class="label label-sm label-<% = item.TxnType == YRKJ.MWR.TblMWTxnDetail.TXNTYPE_ENUM_Recover?"success":"info" %>">
                                                                    <i class="fa fa-bell-o"></i>
                                                                </div>--%>
                                                                 <%if(item.Status == YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Complete){ %>
                                                                <span class="label label-success">
                                                                <% } %>
                                                                <%if(item.Status == YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Authorize){ %>
                                                                <span class="label label-danger">
                                                                <% } %>
                                                                <%if(item.Status == YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Process){ %>
                                                                <span class="label label-default">
                                                                <% } %>
                                                                <%if(item.Status == YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Wait){ %>
                                                                <span class="label label-warning">
                                                                <% } %>
                                                                <% = YRKJ.MWR.Business.BizHelper.GetTxnDetailStatus(item.Status) %>
									                            </span>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                #<% = item.TxnNum %>
                                                              
                                                                <% = item.WSCode %>
                                                                <% = item.CrateCode %>
                                                                <% = item.Vendor %>
                                                                <% = item.Waste %>
                                                                <% = item.SubWeight %>KG
                                                                <%if(item.TxnType == YRKJ.MWR.TblMWTxnDetail.TXNTYPE_ENUM_Recover){ %>
                                                                <span class="label label-primary">
                                                                <% } %>
                                                                <%if(item.TxnType == YRKJ.MWR.TblMWTxnDetail.TXNTYPE_ENUM_Post){ %>
                                                                <span class="label label-info">
                                                                <% } %>
                                                                <% = YRKJ.MWR.Business.BizHelper.GetTxnDetailTxnType(item.TxnType)%>
                                                                </span>
                                                                    <%--<span class="label label-sm label-danger ">Take action <i
                                                                        class="fa fa-share"></i></span>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            <%if(item.Status != YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Process){ %>
                                                            <% = item.TxnWeight %> KG 
                                                            <% } %>
                                                            <% = item.EntryDate.ToString("HH:mm") %>
                                                        </div>
                                                    </div>
                                                </li>
                                                
                                                <%
	}
                                                %>
                                                <%--<li><a href="#">
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-success">
                                                                    <i class="fa fa-bell-o"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New version v1.4 just lunched!
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            20 mins
                                                        </div>
                                                    </div>
                                                </a></li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-danger">
                                                                    <i class="fa fa-bolt"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Database server #12 overloaded. Please fix the issue.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            24 mins
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            30 mins
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-success">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            40 mins
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-warning">
                                                                    <i class="fa fa-plus"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New user registered.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            1.5 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-success">
                                                                    <i class="fa fa-bell-o"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    Web server hardware needs to be upgraded. <span class="label label-sm label-default ">
                                                                        Overdue </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            2 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            3 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-warning">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            5 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            18 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            21 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            22 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            21 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            22 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            21 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            22 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-default">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            21 hours
                                                        </div>
                                                    </div>
                                                </li>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <div class="label label-sm label-info">
                                                                    <i class="fa fa-bullhorn"></i>
                                                                </div>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                    New order received. Please take care of it.
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            22 hours
                                                        </div>
                                                    </div>
                                                </li>--%>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="tab-pane" id="tab_1_2">
                                        <div class="scroller" style="height: 430px;" data-always-visible="1" data-rail-visible1="1">
                                            <ul class="feeds">
                                               <%
                                                   foreach (var item in PageDWSTxnDetailDataList)
	{
                                                %>
                                                <li>
                                                    <div class="col1">
                                                        <div class="cont">
                                                            <div class="cont-col1">
                                                                <%--<div class="label label-sm label-<% = item.TxnType == YRKJ.MWR.TblMWTxnDetail.TXNTYPE_ENUM_Recover?"success":"info" %>">
                                                                    <i class="fa fa-bell-o"></i>
                                                                </div>--%>
                                                                 <%if(item.Status == YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Complete){ %>
                                                                <span class="label label-success">
                                                                <% } %>
                                                                <%if(item.Status == YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Authorize){ %>
                                                                <span class="label label-danger">
                                                                <% } %>
                                                                <%if(item.Status == YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Process){ %>
                                                                <span class="label label-default">
                                                                <% } %>
                                                                <%if(item.Status == YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Wait){ %>
                                                                <span class="label label-warning">
                                                                <% } %>
                                                                <% = YRKJ.MWR.Business.BizHelper.GetTxnDetailStatus(item.Status) %>
									                            </span>
                                                            </div>
                                                            <div class="cont-col2">
                                                                <div class="desc">
                                                                #<% = item.TxnNum %>
                                                                <% = item.WSCode %>
                                                                <% = item.CrateCode %>
                                                                <% = item.Vendor %>
                                                                <% = item.Waste %>
                                                                <% = item.SubWeight %>KG
                                                               
                                                                    <%--<span class="label label-sm label-danger ">Take action <i
                                                                        class="fa fa-share"></i></span>--%>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col2">
                                                        <div class="date">
                                                            <%if(item.Status != YRKJ.MWR.TblMWTxnDetail.STATUS_ENUM_Process){ %>
                                                            <% = item.TxnWeight %> KG 
                                                            <% } %>
                                                            <% = item.EntryDate.ToString("HH:mm") %>
                                                        </div>
                                                    </div>
                                                </li>
                                                
                                                <%
	}
                                                %>
                                            </ul>
                                        </div>
                                    </div>
                                    
                                </div>
                            </div>
                            <!--END TABS-->
                        </div>
                    </div>
                    <!-- END PORTLET-->
                </div>

              <%--  <div class="col-md-6 col-sm-6">
				<!-- BEGIN PORTLET-->
				    <div class="portlet box blue calendar">
					    <div class="portlet-title">
						    <div class="caption">
							    <i class="fa fa-calendar"></i>工作日历
						    </div>
					    </div>
					    <div class="portlet-body light-grey">
						    <div id="calendar">
						    </div>
					    </div>
				    </div>
				<!-- END PORTLET-->
			    </div>--%>
            </div>
            <div class="clearfix">
            </div>
            <!--end Home page MWR detail -->

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
   
    <script type="text/javascript">
        jQuery(document).ready(function () {
            Index.init();
            Index.initCalendar(); // init index page's custom scripts

        });
    </script>

</asp:Content>
