<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="DestroyLog.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Inventory.DestroyLog" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/assets/plugins/select2/select2_metro.css"/>
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
<link href="/assets/css/pages/profile.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		处置日志 <small>查看所有废品库存处置日志</small>
		</h3>
		<ul class="page-breadcrumb breadcrumb">
			<li class="btn-group">
				
			</li>
			<li>
				<i class="fa fa-home"></i>
                <a class="mw-redirect" href="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.BOMain) %>">主页</a>
				<i class="fa fa-angle-right"></i>
			</li>
            <li>
				处置日志
			</li>
		</ul>
	</div>
</div>
<div class="row">
    <div class="col-md-12">
	    <!-- BEGIN EXAMPLE TABLE PORTLET-->
	    <div class="portlet box blue">
		    <div class="portlet-title">
			    <div class="caption">
				    <i class="fa fa-globe"></i>处置日志列表
			    </div>
		    </div>
		    <div class="portlet-body">
                <form data-wgt="mw-submit-group" 
                        id="mwFrmList"
                        data-wgt-submit-method="AjaxSubTxn" 
                        <%--data-wgt-submit-options-reload="true" 
                        data-wgt-submit-options-block="true" --%>
                        data-wgt-submit-options-recall="BODestroyLog.subrecall"
                        action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.DestroyLog) %>">
                <div class="table-toolbar">
					<div class="input-group btn-group pull-right col-md-3">
                        <span class="input-group-btn">
							<button class="btn yellow mw-btn-search-clear" type="button">清空</button>
						</span>
						<input type="text"  class="form-control mw-txt-filterEdit"  value="<% = PageFilterValue %>" />
                        <input type="hidden" submit-group="common search" name="filter" class="form-control mw-txt-filterValue" value="<% = PageFilterValue %>" />
						<span class="input-group-btn">
							<button class="btn blue mw-btn-search"  type="button" >搜索</button>
						</span>
					</div>
				</div>

			    <table data-wgt="mw-expandtable-ajaxchild" 
                    data-wgt-submit-url="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.DestroyLog) %>" 
                    data-wgt-submit-method="AjaxExpandTable" 
                    class="table table-striped table-bordered table-hover" id="sample_1">
			    <thead>
			    <tr>
				    <th>
					    交易编号
				    </th>
				    <th>
					    货箱编号
				    </th>
				    <th>
					    仓库编号
				    </th>
                    <th>
					    回收医院
				    </th>
                    <th>
					    废料类型
				    </th>
                    <th>
					    操作员工
				    </th>
                    <th>
					    操作工作站
				    </th>
				    <th>
					    提交重量
				    </th>
                    <th>
					    实际重量
				    </th>
                    <th>
					    操作时间
				    </th>
                    <th>
					    是否审核
				    </th>
			    </tr>
			    </thead>
			    <tbody>
                    <%
                        foreach (var item in PageDestroyInvTrackDatalist)
	{
                    %>
                <tr>
                    <td>
                        <a class="mw-redirect" href="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.TxnDetail) %>?txnNum=<% = item.TxnNum %>"><% = item.TxnNum %></a>
                        <input type="hidden" name="txnDetailId" value="<% = item.TxnDetailId %>" />
				    </td>
				    <td>
					    <% = item.CrateCode %>
				    </td>
				    <td>
					    <% = item.DepotCode %>
				    </td>
                    <td>
					    <% = item.Vendor %>
				    </td>
                    <td>
					    <% = item.Waste %>
				    </td>
                    <td>
					    <% = item.EmpyName %>
				    </td>
                    <td>
					    <% = item.WSCode %>
				    </td>
				    <td>
					    <% = item.SubWeight %> KG
				    </td>
                    <td>
					    <% = item.TxnWeight %> KG
				    </td>
                    <td>
					    <% = ComLib.ComFn.DateTimeToString(item.EntryDate, YRKJ.MWR.Business.BizBase.GetInstance().DateTimeFormatString)  %>
				    </td>
                    <td>
                    
					   <% if (item.InvAuthId != 0){  %>
                       <a class="mw-redirect" href="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.InvAuthorizelog) %>?ID=<% = item.InvAuthId %>">查看审核</a>
                       
                        <% } %>
                        <% if (item.InvAuthId == 0){  %>
					       否
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
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/vendor/tmpl.min.js"></script>
<script src="/assets/wgt-expandTable.js"></script>
<script src="/assets/bodestroylog.js"></script>
<script>
    jQuery(document).ready(function () {
        BODestroyLog.init();
        WGTExpandTable.init();
    });
</script>
<script id="mw-table-template" type="text/x-tmpl">
<table  class="table table-hover">
    <thead>
    <tr>
        <th>操作工作站</th>
        <th>操作员</th>
        <th>操作类型</th>
        <th>操作时间</th>
    </tr>
    </thead>
    <tbody>
{% for (var i=0, d; d=o.data[i]; i++) { %}
    <tr>
        <td>{%=d.WSCode%}</td>
        <td>{%=d.EmpyName %}</td>
        <td>{%=d.OptType %}</td>
        <td>{%=d.OptDate %}</td>
    </tr>
{% } %}
    </tbody>
</table>
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
