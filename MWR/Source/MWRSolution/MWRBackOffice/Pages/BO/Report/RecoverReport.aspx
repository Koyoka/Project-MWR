<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="RecoverReport.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Report.RecoverReport" %>
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
		运量报告 <small>查看所有回收医疗废品详情</small>
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
				运量报告
			</li>
		</ul>
	</div>
</div>
<div class=" row portfolio-block note note-info">
		<div class="col-md-3 ">
			<div class="portfolio-text ">
				<div class="portfolio-info">
					<h4>车辆回收统计信息</h4>
					<p>
						
					</p>
				</div>
			</div>
		</div>
		<div class="col-md-8 portfolio-stat " >
			<div class="portfolio-info">
					回收总重量
				<span>
					<% = PageRecoverReportData.TotalSubWeight%> KG
				</span>
			</div>
            <div class="portfolio-info">
					提交总重量
				<span>
					<% = PageRecoverReportData.TotalTxnWeight%> 箱
				</span>
			</div>
			<div class="portfolio-info">
					回收总箱数
				<span>
					<% = PageRecoverReportData.TotalCrateQty%> 箱
				</span>
			</div>
			<div class="portfolio-info">
					派遣总车次
				<span>
					<% = PageRecoverReportData.RecoHeaderId%> 次
				</span>
			</div>
		</div>
</div>
<div class="row">
    <div class="col-md-12">
	    <!-- BEGIN EXAMPLE TABLE PORTLET-->
	    <div class="portlet box blue">
		    <div class="portlet-title">
			    <div class="caption">
				    <i class="fa fa-globe"></i>运量报告明细列表
			    </div>
			   <%-- <div class="tools">
				    <a href="javascript:;" class="reload"></a>
				    <a href="javascript:;" class="remove"></a>
			    </div>--%>
		    </div>
		    <div class="portlet-body">
			    <table data-wgt="mw-expandtable-ajaxchild" class="table table-striped table-bordered table-hover" id="sample_1">
			    <thead>
			    <tr>
				    <th>
					    交易编号
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
					    回收总重量
				    </th>
                    <th>
					    提交总重量
				    </th>
                    <th>
					    回收总箱数
				    </th>
                    <th>
					    处理开始时间
				    </th>
                    <th>
					    处理结束时间
				    </th>
                    <th>
					    状态
				    </th>
			    </tr>
			    </thead>
			    <tbody>
                    <%
                        foreach (var item in PageRecoverListData)
	{
                    %>
                <tr>
                    <td>
                        <% = item.TxnNum %>
                    </td>
                    <td>
                        <% = item.CarCode %>
                    </td>
                    <td>
                        <% = item.Driver %>
                    </td>
                    <td>
                        <% = item.Inspector %>
                    </td>
                    <td>
                        <% = item.TotalSubWeight %>
                    </td>
                    <td>
                        <% = item.TotalTxnWeight %>
                    </td>
                    <td>
                        <% = item.TotalCrateQty %>
                    </td>
                    <td>
                        <% =  ComLib.ComFn.DateTimeToString(item.StartDate, YRKJ.MWR.Business.BizBase.GetInstance().DateTimeFormatString)%>
                    </td>
                    <td>
                        <% =  ComLib.ComFn.DateTimeToString(item.EndDate, YRKJ.MWR.Business.BizBase.GetInstance().DateTimeFormatString)%>
                    </td>
                    <td>
                        <% = YRKJ.MWR.Business.BizHelper.GetTxnRecoverHeaderStatus(item.Status) %>
                    </td>
                </tr>
                <%
	}
                    %>
			    </tbody>
			    </table>
		    
            <uc1:UPage ID="c_UPage" runat="server" />
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
<script src="/assets/wgt-expandTable.js"></script>
<script>
    jQuery(document).ready(function () {
        var oTable = $('#sample_1').dataTable( {
            "aoColumnDefs": [
                {"bSortable": false, "aTargets": [ 0 ] }
            ],   
            "bInfo": false, //开关，是否显示表格的一些信息
            "bPaginate": false, //开关，是否显示分页器
            "bLengthChange": false, //开关，是否显示每页大小的下拉框
            "bFilter": false, //开关，是否启用客户端过滤器
            "aaSorting": [[1, 'asc']],
                "aLengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#sample_1').data('mw-oTable',oTable);

        WGTExpandTable.init();
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
