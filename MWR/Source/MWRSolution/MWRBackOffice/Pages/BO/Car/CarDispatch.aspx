<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master"
    AutoEventWireup="true" CodeBehind="CarDispatch.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Car.CarDispatch" %>

<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <!-- begin target bar -->
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
            <h3 class="page-title">
                车辆调度 <small>派遣外出车辆</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                
                <li><i class="fa fa-home"></i><a href="#<% = RedirectHelper.BOMain %>">首页</a> <i
                    class="fa fa-angle-right"></i></li>
                <li><a href="#">车辆管理</a> <i class="fa fa-angle-right"></i></li>
                <li><a href="#<% = RedirectHelper.CarDispatch %>">车辆调度</a> </li>
            </ul>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
    <div class="clearfix">
    </div>
    <!-- end target bar -->
    <div class="row">
        <div class="col-md-3 col-md-12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-reorder"></i>车辆调度
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <form id="cc" data-wgt="mw-submit-cardispatch" data-submit-method="AjaxSubCarDispstch" action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.CarDispatch) %>" class="">
                    <div class="form-body">
                        <div class="form-group">
                            <label class="control-label">
                                当前驻厂车辆</label>
                            <select  name="data1" class="form-control input-lg">
                                <option value="value1">选择车辆</option>
                                <option>鄂A88888</option>
                                <option>鄂A88888</option>
                                <option>鄂A88888</option>
                                <option>鄂A88888</option>
                                <option>鄂A88888</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                当前驻留司机</label>
                            <select  name="data2" class="form-control input-lg">
                                <option  value="value2">选择司机</option>
                                <option>张三</option>
                                <option>张三</option>
                                <option>张三</option>
                                <option>张三</option>
                                <option>张三</option>
                                <option>张三</option>
                            </select>
                        </div>
                        <div class="form-group last">
                            <label class="control-label">
                                当前驻留跟车员</label>
                            <select name="data3" class="form-control input-lg">
                                <option  value="value3">选择跟车员</option>
                                <option>李四</option>
                                <option>李四</option>
                                <option>李四</option>
                                <option>李四</option>
                                <option>李四</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-actions right">
                        <input type="submit" value="提交" data-loading-text="提交..." class="demo-loading-btn btn btn-primary green" />
                       <%-- <button type="button" data-loading-text="提交..." class="demo-loading-btn btn btn-primary green">
								提交 </button>--%>
                    </div>
                    </form>
                    <!-- END FORM-->
                </div>
            </div>
        </div>
        <div class="col-md-9 col-md-12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-cogs"></i>车辆班次列表
                    </div>
                     <div class="actions ">
                        <div id="dashboard-report-range" class="dashboard-date-range tooltips" data-placement="top" data-original-title="Change dashboard date range" style="display: block;">
								<i class="fa fa-calendar"></i>
								<span>December 17, 2014 - December 28, 2014</span>
								<i class="fa fa-angle-down"></i>
						</div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table-responsive table-scrollable">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>
                                        #
                                    </th>
                                    <th>
                                        车辆编号
                                    </th>
                                    <th>
                                        司机
                                    </th>
                                    <th>
                                        跟车员
                                    </th>
                                    <th>
                                        出车时间
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>
                                        1
                                    </td>
                                    <td>
                                        Mark
                                    </td>
                                    <td>
                                        Otto
                                    </td>
                                    <td>
                                        makr124
                                    </td>
                                    <td>
                                        <span class="label label-sm label-success">Approved </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        2
                                    </td>
                                    <td>
                                        Jacob
                                    </td>
                                    <td>
                                        Nilson
                                    </td>
                                    <td>
                                        jac123
                                    </td>
                                    <td>
                                        <span class="label label-sm label-info">Pending </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        3
                                    </td>
                                    <td>
                                        Larry
                                    </td>
                                    <td>
                                        Cooper
                                    </td>
                                    <td>
                                        lar
                                    </td>
                                    <td>
                                        <span class="label label-sm label-warning">Suspended </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        4
                                    </td>
                                    <td>
                                        Sandy
                                    </td>
                                    <td>
                                        Lim
                                    </td>
                                    <td>
                                        sanlim
                                    </td>
                                    <td>
                                        <span class="label label-sm label-danger">Blocked </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        4
                                    </td>
                                    <td>
                                        Sandy
                                    </td>
                                    <td>
                                        Lim
                                    </td>
                                    <td>
                                        sanlim
                                    </td>
                                    <td>
                                        <span class="label label-sm label-danger">Blocked </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        4
                                    </td>
                                    <td>
                                        Sandy
                                    </td>
                                    <td>
                                        Lim
                                    </td>
                                    <td>
                                        sanlim
                                    </td>
                                    <td>
                                        <span class="label label-sm label-danger">Blocked </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        4
                                    </td>
                                    <td>
                                        Sandy
                                    </td>
                                    <td>
                                        Lim
                                    </td>
                                    <td>
                                        sanlim
                                    </td>
                                    <td>
                                        <span class="label label-sm label-danger">Blocked </span>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        4
                                    </td>
                                    <td>
                                        Sandy
                                    </td>
                                    <td>
                                        Lim
                                    </td>
                                    <td>
                                        sanlim
                                    </td>
                                    <td>
                                        <span class="label label-sm label-danger">Blocked </span>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        4
                                    </td>
                                    <td>
                                        Sandy
                                    </td>
                                    <td>
                                        Lim
                                    </td>
                                    <td>
                                        sanlim
                                    </td>
                                    <td>
                                        <span class="label label-sm label-danger">Blocked </span>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        4
                                    </td>
                                    <td>
                                        Sandy
                                    </td>
                                    <td>
                                        Lim
                                    </td>
                                    <td>
                                        sanlim
                                    </td>
                                    <td>
                                        <span class="label label-sm label-danger">Blocked </span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="row">
                        <div class="col-md-3 ">
                            <div class="dataTables_info" id="sample_2_info">
                                1/12 页</div>
                        </div>
                        <div class="col-md-9 ">
                            <div class="dataTables_paginate paging_bootstrap">
                                <ul class="pagination" style="visibility: visible;">
                                    <li class="prev disabled">
                                        <a href="#" title="Prev">
                                        <i class="fa fa-angle-left"></i>
                                        </a>
                                    </li>
                                    <li class="active"><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li class="next">
                                        <a href="#" title="Next">
                                        <i class="fa fa-angle-right"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
               
            </div>
        </div>
    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script src="/assets/plugins/fullcalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
<%--<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>--%><script src="/assets/scripts/table-managed.js"></script>
<script src="/assets/bocomm.js" type="text/javascript"></script>

<script>
    jQuery(document).ready(function () {

        //        TableManaged.init();
        CommHelper.init();
        //        $('body').addClass("modal-open-noscroll");
        // initiate  and plugins
        // button state demo

        $('.demo-loading-btn')
          .click(function () {
              Modal.alert(
              {
                  msg: '内容11111111',
                  title: '标题',
                  btnok: '确定',
                  btncl: '取消'
              });
              var btn = $(this)
              btn.button('loading')
              setTimeout(function () {
                  btn.button('reset')
              }, 3000)
          });
        //    


    });


	

//         
</script>
</asp:Content>
