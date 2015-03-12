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
		<!-- END PAGE TITLE & BREADCRUMB-->
	</div>
</div>

    <div class="clearfix">
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
                <form data-wgt="mw-submit" 
                    id="mwFrmList"
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
                    <uc1:UPage ID="c_UPage" runat="server" />
                </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
