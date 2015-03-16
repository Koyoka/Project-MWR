<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="VendorReport.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Report.VendorReport" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/assets/plugins/select2/select2_metro.css"/>
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		医疗机构库存详情 <small>查看医疗机构库存详情</small>
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
				<i class="fa fa-home"></i>
                <a href="#<% = RedirectHelper.BOMain %>">综合报告</a>
                <i class="fa fa-angle-right"></i>
			</li>
            <li>
				医疗机构库存详情
			</li>
		</ul>
	</div>
</div>
<div class="row">
    <div class="col-md-12">
	    <!-- BEGIN EXAMPLE TABLE PORTLET-->
	    <div class="portlet box green">
		    <div class="portlet-title">
			    <div class="caption">
				    <i class="fa fa-globe"></i><% = PageVendorNameData %>-库存废品列表
			    </div>
			    <div class="tools">
				    <a href="javascript:;" class="reload"></a>
				    <a href="javascript:;" class="remove"></a>
			    </div>
		    </div>
		    <div class="portlet-body">
			    <table class="table table-striped table-bordered table-hover" id="sample_1">
			    <thead>
			    <tr>
				    <th>
					    货箱编号
				    </th>
				    <th>
					    仓库编号
				    </th>
				    <th>
					    废料类型
				    </th>
				    <th>
					    回收重量
				    </th>
				    <th>
					    入库重量
				    </th>
                    <th>
					    处置重量
				    </th>
                    <th>
					    状态
				    </th>
			    </tr>
			    </thead>
			    <tbody>
                    <%
                        foreach (var item in PageInventoryDataList)
	{
                    %>
                    
			    <tr>
				    <td>
					    <% = item.CrateCode %>
				    </td>
				    <td>
					    <% = item.DepotCode %>
				    </td>
				    <td>
					    <% = item.Waste %>
				    </td>
				    <td>
					    <% = item.RecoWeight %>
				    </td>
				    <td>
					    <% = item.InvWeight %>
				    </td>
                    <td>
					    <% = item.DestWeight %>
				    </td>
                    <td>
					    <% = YRKJ.MWR.Business.BizHelper.GetInventoryStatus(item.Status)%>
				    </td>
			    </tr>
                <%
	}
                    %>
			  <%--  <tr>
				    <td>
					    Trident
				    </td>
				    <td>
					    Internet Explorer 5.0
				    </td>
				    <td>
					    Win 95+
				    </td>
				    <td>
					    5
				    </td>
				    <td>
					    C
				    </td>
			    </tr>
			    <tr>
				    <td>
					    Trident
				    </td>
				    <td>
					    Internet Explorer 5.5
				    </td>
				    <td>
					    Win 95+
				    </td>
				    <td>
					    5.5
				    </td>
				    <td>
					    A
				    </td>
			    </tr>
			    <tr>
				    <td>
					    Trident
				    </td>
				    <td>
					    Internet Explorer 6
				    </td>
				    <td>
					    Win 98+
				    </td>
				    <td>
					    6
				    </td>
				    <td>
					    A
				    </td>
			    </tr>
			    <tr>
				    <td>
					    Trident
				    </td>
				    <td>
					    Internet Explorer 7
				    </td>
				    <td>
					    Win XP SP2+
				    </td>
				    <td>
					    7
				    </td>
				    <td>
					    A
				    </td>
			    </tr>--%>
			    </tbody>
			    </table>
		    </div>
	    </div>
	    <!-- END EXAMPLE TABLE PORTLET-->
	   
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>
<script src="/assets/scripts/table-advanced.js"></script>
<script>
    jQuery(document).ready(function () {

        TableAdvanced.init();
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
