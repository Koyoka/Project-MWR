<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master"
    AutoEventWireup="true" CodeBehind="CarDispatch.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Car.CarDispatch" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>

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
                        <i class="fa fa-cogs"></i>车辆调度
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                   <form id="mwFrmCarDisp" 
                       data-wgt="mw-submit" 
                       data-wgt-submit-method="AjaxSubCarDispstch" 
                       data-wgt-submit-options-recall="CommHelper.recallCarDispatch"
                       action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.CarDispatch) %>" class="">
                    <div class="form-body">
                        <div class="form-group">
                            <label class="control-label">
                                当前驻厂车辆</label>
                            <select  name="carCode" class="form-control input-lg">
                                <% 
                                    if (PageCarDataList.Count == 0)
                                    { 
                                %>
                                    <option  value="0">没有车辆可选...</option>
                                <%        
                                    }else if (PageCarDataList.Count != 1)
                                  { 
                                %>
                                    <option value="0">选择车辆</option>
                                <%        
                                    }
                                %>
                                
                                <% 
                                    foreach (PageCarData item in PageCarDataList)
                                    { 
                                %> 
                                    <option value="<% = item.CarCode %>"><% = item.CarCode%></option>
                                <% 
                                    }
                                %>
                              
                            </select>
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                当前驻留司机</label>
                            <select  name="driverCode" class="form-control input-lg">
                                <% 
                                    if (PageEmplDriverDataList.Count == 0)
                                    { 
                                %>
                                    <option  value="0">没有司机可选...</option>
                                <%        
                                    }else if (PageEmplDriverDataList.Count != 1)
                                    { 
                                %>
                                    <option  value="0">选择司机</option>
                                <%        
                                    }
                                %>
                                
                                 <% 
                                    foreach (PageEmplData item in PageEmplDriverDataList)
                                    {
                                 %>
                                 <option value="<% = item.EmplCode %>"><% = item.EmplName%></option>
                                 <%   
                                    }
                                    %>
                            </select>
                        </div>
                        <div class="form-group ">
                            <label class="control-label">
                                当前驻留跟车员</label>
                            <select name="inspectorCode" class="form-control input-lg">
                                <% 
                                    if (PageEmplInspectorDataList.Count == 0)
                                    { 
                                %>
                                    <option  value="0">没有跟车员可选...</option>
                                <%        
                                    }else if (PageEmplInspectorDataList.Count != 1)
                                    { 
                                %>
                                    <option  value="0">选择跟车员</option>
                                <%        
                                    }
                                %>
                                
                                 <% 
                                    foreach (PageEmplData item in PageEmplInspectorDataList)
                                    {
                                 %>
                                 <option value="<% = item.EmplCode %>"><% = item.EmplName%></option>
                                 <%   
                                    }
                                %>
                            </select>
                        </div>
                        <div class="form-group last">
                            <label class="control-label">
                                当前可派发的终端</label>
                            <select name="mwsCode" class="form-control input-lg">
                                <% 
                                    if (PageMobileWSDataList.Count == 0)
                                    { 
                                %>
                                    <option  value="0">没有移动终端可选...</option>
                                <%        
                                    }else if (PageMobileWSDataList.Count != 1){ 
                                %>
                                    <option  value="0">选择配置的移动终端</option>
                                <%        
                                    }
                                %>
                                 <% 
                                     foreach (string  item in PageMobileWSDataList)
                                    {
                                 %>
                                 <option value="<% = item %>"><% = item%></option>
                                 <%   
                                    }
                                %>
                            </select>
                        </div>
                    </div>
                    <div class="form-actions right">
                        <input id="mwTxtIsSubmit" type="hidden" name="issubmit" value="YES" />
                        <input type="submit" value="提交" data-loading-text="提交..." class="demo-loading-btn btn btn-primary green" />
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
                        <i class="fa fa-reorder"></i>车辆班次列表
                    </div>
                     <div class="actions ">
                     2015年01月16日
                        <%--<div id="dashboard-report-range" class="dashboard-date-range tooltips" data-placement="top" data-original-title="Change dashboard date range" style="display: block;">
								<i class="fa fa-calendar"></i>
								<span>December 17, 2014 - December 28, 2014</span>
								<i class="fa fa-angle-down"></i>
						</div>--%>
                    </div>
                </div>
                <div class="portlet-body" >
                <form data-wgt="mw-submit" 
                    id="mwFrmDispList"
                    data-wgt-submit-method="AjaxGetCarDispstch" 
                    data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" 
                   <%-- data-wgt-submit-options-recall="CommHelper.recallCarDispatch" --%>
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.CarDispatch) %>">
                    <div class="table-responsive table-scrollable">
                        <table class="table table-hover">
                            <thead>
                                <tr>
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
                                        手机终端
                                    </th>
                                    <th>
                                        出车时间
                                    </th>
                                    <th>
                                        回车时间
                                    </th>
                                    <th>
                                        
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <%
	foreach (PageCarInOutData item in PageCarInOutDataList)
	{
                                %>
                                <tr>
                                    <td>
                                        <% = item.CarDesc %>
                                    </td>
                                    <td>
                                        <% = item.DriverName %>
                                    </td>
                                    <td>
                                        <% = item.InspectorName %>
                                    </td>
                                    <td>
                                        <% = item.MWSCode %>
                                    </td>
                                    <td>
                                        <% = item.OutTime %>
                                    </td>
                                    <td>
                                        <% = item.InTime %>
                                    </td>
                                    <td>
                                         <a href="#" data-wgt="mw-submit-completecardispatch" data-wgt-submit-completecardispatch-disid="<% = item.DisId %>" class="btn default btn-xs purple"><i class="fa fa-edit"></i> 完成本班次</a>
                                    </td>
                                </tr>
                                <%
	}
                                %>
                            </tbody>
                        </table>
                    </div>
                    <uc1:UPage ID="c_UPage" runat="server" />
                    <input id="mwDisId" type="hidden" name="disId" value="" />
                </form>
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script src="/assets/plugins/fullcalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
<%--<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>--%>
<script src="/assets/scripts/table-managed.js"></script>



</asp:Content>
