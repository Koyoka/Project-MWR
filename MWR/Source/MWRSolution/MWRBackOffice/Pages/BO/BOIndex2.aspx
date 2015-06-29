<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BOIndex2.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BOIndex2" %>
<%@ Register src="~/Pages/UCtrl/UModal.ascx" tagname="UModal" tagprefix="uc1" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->

<html lang="en" class="no-js"><!--<![endif]--><!-- BEGIN HEAD --><head>
<meta charset="utf-8" />
<title>医疗废物回收管理系统</title>
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta content="width=device-width, initial-scale=1.0" name="viewport" />
<meta content="" name="description" />
<meta content="" name="author" />
<meta name="MobileOptimized" content="320" />

<link href="/assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
<link href="/assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
<link href="/assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />


<!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
<link href="/assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css"/>
<link href="/assets/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css"/>
<link href="/assets/plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css"/>
<link href="/assets/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css"/>
<link href="/assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css"/>

<link href="/assets/css/style-metronic.css" rel="stylesheet" type="text/css" />
<link href="/assets/css/style.css" rel="stylesheet" type="text/css" />
<link href="/assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
<link href="/assets/css/plugins.css" rel="stylesheet" type="text/css" />
<link href="/assets/css/themes/light.css" rel="stylesheet" type="text/css" id="style_color" />

<link href="/assets/custom.css" rel="stylesheet" type="text/css" />
<!-- END THEME STYLES -->

<!-- MWR STYLE -->

<link rel="shortcut icon" href="favicon.ico" />
<style type="text/css">
        iframe {
            margin: 0px 0px 0px 0px;
            width:100%;
        }
    </style>
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body class="page-header-fixed page-footer-fixed1 ">
<%--<div class="page-content-wrapper">
<div class="page-content" >--%>
<uc1:UModal ID="UModal1" runat="server" />
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
        <div class="page-sidebar-wrapper" style="border:0px solid blue;">
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
                      <form class="sidebar-search" action="" method="POST">
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
                    <li id="MW_Home" class="start "><a class=""  href="BOMain.aspx" target="mw-mainFrame">
                        <i class="fa fa-home"></i><span class="title">首页 </span><span class="selected"></span>
                    </a></li>
                    <li id="MW_Car" class=" "><a href="javascript:void;"><i class="fa fa-truck "></i><span
                        class="title">车辆管理 </span><span class="arrow "></span><span class="selected"></span>
                    </a>
                        <ul class="sub-menu">
                            <li id="MW_Car_Dispatch" class=""><a target="mw-mainFrame" href="<% = RedirectHelper.CarDispatch %>">
                                车辆调度管理</a> </li>
                            <li id="MW_Car_Track" class=""><a target="mw-mainFrame" href="<% = RedirectHelper.CarTrack %>">
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
                            <li id="MW_Inventory_Auth" class=""><a target="mw-mainFrame" href="<% = RedirectHelper.InvAuthorize %>">货损审核</a> </li>
                             <li id="MW_Inventory_Auth_Log" class=""><a target="mw-mainFrame" href="<% = RedirectHelper.InvAuthorizelog %>">审核日志</a> </li>
                            <li id="MW_Recover_Log" class=""><a target="mw-mainFrame" href="<% = RedirectHelper.RecoverLog %>">回收入库日志</a> </li>
                            <li id="MW_Post_Log" class=""><a target="mw-mainFrame" href="<% = RedirectHelper.PostLog %>">废品出库日志</a> </li>
                            <li id="MW_Residue_Log" class=""><a target="mw-mainFrame" href="<% = RedirectHelper.DestroyLog %>">废品处理日志</a> </li>
                        </ul>
                    </li>
                    <li id="MW_Report" class=" "><a href="javascript:;"><i class="fa fa-bar-chart-o"></i>
                        <span class="title">统计报告 </span><span class="arrow "></span><span class="selected">
                        </span></a>
                        <ul class="sub-menu">
                            <li><a target="mw-mainFrame" href="<% = RedirectHelper.IntegratedReport %>">综合报告</a> </li>
                            <li><a target="mw-mainFrame" href="<% = RedirectHelper.RecoverReport %>">运量报告</a> </li>
                            <li><a target="mw-mainFrame" href="<% = RedirectHelper.PostReport %>">出库报告</a> </li>
                            <li><a target="mw-mainFrame" href="<% = RedirectHelper.DestroyReport %>">处置量报告</a> </li>
                          <%--  <li><a href="javascript:void;">厂区产量报告</a> </li>--%>
                        </ul>
                    </li>
                  <%--  <li id="MW_DailyClose" class=" "><a href="javascript:;"><i class="fa fa-pencil-square-o">
                    </i><span class="title">结算上报</span> <span class="selected"></span></a></li>--%>
                    <li id="MW_BaseData" class=" "><a href="javascript:;"><i class="fa fa-folder-open-o">
                    </i><span class="title">基础档案管理 </span><span class="arrow "></span><span class="selected">
                    </span></a>
                        <ul class="sub-menu">
                            <li class=""><a target="mw-mainFrame" href="<% = RedirectHelper.BDEmploy %>">员工档案</a> </li>
                            <li class=""><a target="mw-mainFrame" href="<% = RedirectHelper.BDCar %>">车辆档案</a> </li>
                            <li><a target="mw-mainFrame" href="<% = RedirectHelper.BDCrate %>">货箱档案</a> </li>
                            <li><a target="mw-mainFrame" href="<% = RedirectHelper.BDDepot %>">仓库档案</a> </li>
                            <li><a target="mw-mainFrame" href="<% = RedirectHelper.BDVendor %>">医院档案</a> </li>
                            <li><a target="mw-mainFrame" href="<% = RedirectHelper.BDWaste %>">医疗废物档案</a> </li>
                        </ul>
                    </li>
                    <li id="MW_Sys" class="last "><a href="javascript:;"><i class="fa fa-cogs"></i><span
                        class="title">系统管理 </span><span class="arrow "></span><span class="selected"></span>
                    </a>
                        <ul class="sub-menu">
                            <li class=""><a target="mw-mainFrame" href="<% = RedirectHelper.WSManage %>">工作站管理</a> </li>
                            <li class=""><a target="mw-mainFrame" href="<% = RedirectHelper.UserPermit %>">权限管理</a> </li>
                            <li class=""><a target="mw-mainFrame" href="<% = RedirectHelper.SysParams %>">参数设置</a> </li>
                           
                            <li class=""><a target="mw-mainFrame" href="<% = RedirectHelper.SysInit %>">数据初始化</a> </li>
                            <li class=""><a href="<% = RedirectHelper.SysAdmin %>" target="mw-mainFrame">超级管理员</a> </li>
                        </ul>
                    </li>
                </ul>
                <!-- END SIDEBAR MENU -->
            </div>
        </div>
         <!-- END SIDEBAR -->
        <!-- BEGIN CONTENT -->
         <div class="page-content-wrapper" style="overflow:hidden;">
            <div class="page-content" style="border:0px solid red; padding:0px;min-height:700px; overflow:hidden;">
               
                <iframe name="mw-mainFrame" data-default="<% = RedirectHelper.BOMain %>" data-wgt="mw-loadpage" id="mw-mainFrame" class="auto-height"
                
                    marginheight="0" marginwidth="0"  height="0"
                    frameborder="0" scrolling="no"></iframe>  
               <%-- <div class="page-content-body" data-default="<% = RedirectHelper.BOMain %>" data-wgt="mw-loadpage">                 </div>--%>
                
            </div>
        </div>
        <!-- END CONTENT -->
</div>
<%--container end--%>

<%--</div>
</div>
--%>

<!--[if lt IE 9]>
   <script src="/assets/plugins/respond.min.js"></script>
   <script src="/assets/plugins/excanvas.min.js"></script> 
   <![endif]-->
<script src="/assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
<script src="/assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
<!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
<script src="/assets/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
<script src="/assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
<script src="/assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
<script src="/assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
<script src="/assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
<script src="/assets/plugins/jquery.cokie.min.js" type="text/javascript"></script>
<script src="/assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>

<script src="/assets/plugins/bootstrap-modal/js/bootstrap-modalmanager.js" type="text/javascript"></script>
<script src="/assets/plugins/bootstrap-modal/js/bootstrap-modal.js" type="text/javascript"></script>


<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload.js"></script>

<!-- IMPORTANT! fullcalendar depends on jquery-ui-1.10.3.custom.min.js for drag & drop support -->
<script src="/assets/plugins/fullcalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
<script src="/assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.js" type="text/javascript"></script>
<script src="/assets/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
<!-- END PAGE LEVEL PLUGINS -->
<script src="/assets/plugins/bootstrap-daterangepicker/moment.min.js" type="text/javascript"></script>
<script src="/assets/plugins/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>


<script src="/Assets/custplugins/jquery-iframe-auto-height-master/release/jquery.iframe-auto-height.js" type="text/javascript"></script>

<script src="/assets/scripts/app.js"  type="text/javascript"></script>
<script src="/assets/scripts/index.js" type="text/javascript"></script>

<script src="/assets/customer.js"  type="text/javascript"></script>
<script src="/assets/bocomm.js" type="text/javascript"></script>
<%--<script type="text/javascript"  type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=<% = YRKJ.MWR.Business.Sys.MWParams.GetBaiduMapAK() %>"></script>--%>
<script src="/assets/boindex2.js"></script>
<script>
    jQuery(document).ready(function () {
        App.init();
        Custom.init();
        CommHelper.init();




        IndexHelper.init();
        Custom.scan();
        $('iframe').iframeAutoHeight({ debug: true ,animate:false});
        
    });

    jQuery(document).ready(function () {
//        Custom.scan();
    });


</script>

</body></html>