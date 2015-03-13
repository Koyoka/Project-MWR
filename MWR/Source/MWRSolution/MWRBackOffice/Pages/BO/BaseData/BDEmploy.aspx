<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="BDEmploy.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDEmploy" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		员工档案 <small>查看、编辑员工信息</small>
		</h3>
		<ul class="page-breadcrumb breadcrumb">
			<li class="btn-group">
				
			</li>
			<li>
				<i class="fa fa-home"></i>
				<a href="#<% = RedirectHelper.BOMain %>">主页</a>
				<i class="fa fa-angle-right"></i>
			</li>
			<li>
				员工档案
			</li>
		</ul>
	</div>
</div>

<div class="clearfix">
</div>
<%--<div class="row">
   
		<div class="col-md-8">
			<div class="booking-search">
				<form action="#" role="form">
					<div class="row form-group">
						<div class="col-md-12">
							<label class="control-label">员工编号</label>
							<div class="input-icon">
								<i class="fa fa-map-marker"></i>
								<input class="form-control" type="text" placeholder="Canada, Malaysia, Russia ...">
							</div>
						</div>
					</div>
					<div class="row form-group">
						<div class="col-md-6">
							<label class="control-label">员工姓名:</label>
							<div class="input-icon">
								<i class="fa fa-calendar"></i>
								<input class="form-control date-picker" size="16" type="text" value="12-02-2012" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years"/>
							</div>
						</div>
						<div class="col-md-6">
							<label class="control-label">登录密码:</label>
							<div class="input-icon">
								<i class="fa fa-calendar"></i>
								<input class="form-control date-picker" size="16" type="text" value="12-02-2012" data-date="12-02-2012" data-date-format="dd-mm-yyyy" data-date-viewmode="years"/>
							</div>
						</div>
					</div>
					<div class="row form-group">
						<div class="col-md-6">
							<label class="control-list">员工类型:</label>
                            
							<div class="checkbox-list">
								<div class="btn-group" data-toggle="buttons">
									<label class="btn btn-default active">
									<input type="radio" class="toggle"> 一般员工 </label>
									<label class="btn btn-default">
									<input type="radio" class="toggle"> 司机 </label>
									<label class="btn btn-default">
									<input type="radio" class="toggle"> 跟车员 </label>
                                    <label class="btn btn-default">
									<input type="radio" class="toggle"> 注销 </label>
								</div>
							</div>
						</div>
						<div class="col-md-6">
							<label class="control-label">权限管理:</label>
							<div class="input-icon">
								<a href="#">[点击]转到权限管理</a>
							</div>
						</div>
					</div>
					<button class="btn blue btn-block margin-top-20">提交 <i class="m-icon-swapright m-icon-white"></i></button>
				</form>
			</div>
		</div>
		<!--end booking-search-->
		<div class="col-md-4">
			
		</div>
		<!--end col-md-4-->
	

    
    
</div>
<br />--%>
    

    
    <div class="clearfix">
    </div>
	<div class="row">
		<div class="col-md-12">
			<!-- BEGIN EXAMPLE TABLE PORTLET-->
			<div class="portlet box blue">
				<div class="portlet-title">
					<div class="caption">
						<i class="fa fa-edit"></i>员工列表
					</div>
					<div class="tools">
						<a href="javascript:;" class="collapse"></a>
						<a href="#portlet-config" data-toggle="modal" class="config"></a>
						<a href="javascript:;" class="reload"></a>
						<a href="javascript:;" class="remove"></a>
					</div>
				</div>
				<div class="portlet-body">
					<div class="table-toolbar">
						<div class="btn-group">
							<button id="sample_editable_1_new" class="btn green">
							添加新员工 <i class="fa fa-plus"></i>
							</button>
						</div>
						<div class="btn-group pull-right">
							<button class="btn dropdown-toggle" data-toggle="dropdown">Tools <i class="fa fa-angle-down"></i>
							</button>
							<ul class="dropdown-menu pull-right">
								<li>
									<a href="#">Print</a>
								</li>
								<li>
									<a href="#">Save as PDF</a>
								</li>
								<li>
									<a href="#">Export to Excel</a>
								</li>
							</ul>
						</div>
					</div>
                    <form data-wgt="mw-submit" 
                        id="mwFrmList"
                        data-wgt-submit-method="AjaxGetEmpy" 
                        <%--data-wgt-submit-options-reload="true" 
                        data-wgt-submit-options-block="true" --%>
                       data-wgt-submit-options-recall="BOBDEmploy.subrecall"
                        action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.BDEmploy) %>">
					<table class="table table-striped table-hover table-bordered" id="sample_editable_1">
					<thead>
					<tr>

                        <th>
                            员工编号
                        </th>
                        <th>
                            员工姓名
                        </th>
                            <th>
                            员工职责
                        </th>
                        <th>
                            所属权限组
                        </th>
						
						<th>
							 编辑
						</th>
						<th width="50">
							
						</th>
					</tr>
					</thead>
					<tbody>
                                <%
                                    foreach (var item in PageEmployDataList)
                                    {
                                %>
					<tr>
						<td>
                            <% = item.EmpyCode %>
                        </td>
                        <td>
                            <% = item.EmpyName %>
                        </td>
                        <td>
                            <% = item.EmpyType %>
                        </td>
                        <td>
                            <% = item.FuncGroup %>
                        </td>
						<td>
							<a class="edit" href="javascript:;">编辑</a>
						</td>
						<td >
							<%--<a class="delete" href="javascript:;">Delete</a>--%>
                             <% if (item.IsActive) %>
                            <% { %>
                                <a href="#"  class="btn default btn-xs red cancel"><i class="fa fa-edit"></i> 注销</a>
                            <% } %>
                            <% if (!item.IsActive) %>
                            <% { %>
                                <a href="#"  class="btn default btn-xs green cancel"><i class="fa fa-edit"></i> 激活</a>
                            <% } %>
						</td>
					</tr>
                    <% 
                                    }
                            %>
				
					</tbody>
					</table>
                    <uc1:UPage ID="c_UPage" runat="server" />
                    </form>
				</div>
			</div>
			<!-- END EXAMPLE TABLE PORTLET-->
		</div>
	</div>

    <div class="clearfix">
    </div>
    <div class="row">
      <div class="col-md-12 col-md-12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-reorder"></i>员工列表
                    </div>
                    <%-- <div class="actions ">
                     2015年01月16日
                       
                    </div>--%>
                </div>
                <div class="portlet-body"  >
                <form <%--data-wgt="mw-submit" --%>
                    id="mwFrmList1"
                    data-wgt-submit-method="AjaxGetEmpy" 
                    <%--data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" --%>
                   <%-- data-wgt-submit-options-recall="CommHelper.recallCarDispatch" --%>
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.BDEmploy) %>">
                    <div class="table-responsive table-scrollable">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>
                                        员工编号
                                    </th>
                                    <th>
                                        员工姓名
                                    </th>
                                     <th>
                                        员工职责
                                    </th>
                                    <th>
                                        所属权限组
                                    </th>
                                    <th>
                                    编辑
                                    </th>
                                    <th>
                                        
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <%
                                    foreach (var item in PageEmployDataList)
	{
                                %>
                                <tr>
                                    <td>
                                        <% = item.EmpyCode %>
                                    </td>
                                    <td>
                                        <% = item.EmpyName %>
                                    </td>
                                    <td>
                                        <% = item.EmpyType %>
                                    </td>
                                    <td>
                                        <% = item.FuncGroup %>
                                    </td>
                                    
                                    <td>
                                        <a href="#"  class="btn default btn-xs blue"><i class="fa fa-edit"></i> 编辑</a>
                                    </td>
                                    <td>
                                        <% if (item.IsActive) %>
                                        <% { %>
                                         <a href="#"  class="btn default btn-xs red"><i class="fa fa-edit"></i> 注销</a>
                                        <% } %>
                                        <% if (!item.IsActive) %>
                                        <% { %>
                                         <a href="#"  class="btn default btn-xs green"><i class="fa fa-edit"></i> 激活</a>
                                        <% } %>
                                    </td>
                                </tr>
                                <%
	}
                                %>
                            </tbody>
                        </table>
                    </div>
                    
                </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/jquery.dataTables.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>
<script src="/assets/bobdemploy.js"></script>
<script>
    jQuery(document).ready(function () {
        BOBDEmploy.init();
        

    });
</script>

<div id="mw-EmpyTpe-temp" >
   <select  name="mw-tempEmpyTpe" class="form-control input-lg">
        <option text="一般员工" value="0">一般员工</option>
        <option text="司机"  value="1">司机</option>
        <option  text="跟车员" value="2">跟车员</option>
    </select>
</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
