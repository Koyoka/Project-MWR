﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="InventoryReport.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Report.InventoryReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/assets/plugins/select2/select2_metro.css"/>
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
<link href="/assets/css/pages/profile.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		库存报告 <small>查看所有仓库保存的废料信息</small>
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
				运量报告
			</li>
		</ul>
	</div>
</div>
<div class=" row portfolio-block note note-info">
		<%--<div class="col-md-3 ">
			<div class="portfolio-text ">
				<div class="portfolio-info">
					<h4></h4>
					<p>
						
					</p>
				</div>
			</div>
		</div>--%>
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
					<% = PageRecoverReportData.TotalTxnWeight%> KG
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
                <form data-wgt="mw-submit-group" 
                        id="mwFrmList"
                        data-wgt-submit-method="AjaxSubTxn" 
                        <%--data-wgt-submit-options-reload="true" 
                        data-wgt-submit-options-block="true" --%>
                        data-wgt-submit-options-recall="BORecoverReport.subrecall"
                        action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.RecoverReport) %>">
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
                    data-wgt-submit-url="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.RecoverReport) %>" 
                    data-wgt-submit-method="AjaxExpandTable" 
                    class="table table-striped table-bordered table-hover" id="sample_1">
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
					    处理类型
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
                        <a class="mw-redirect" href="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.TxnDetail)%>?txnNum=<% = item.TxnNum %>"><% = item.TxnNum %></a>
                        
                        <input type="hidden" name="txnNum" value="<% = item.TxnNum %>" />
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
                        <% = item.TotalSubWeight %> KG
                    </td>
                    <td>
                        <% = item.TotalTxnWeight %> KG
                    </td>
                    <td>
                        <% = item.TotalCrateQty %>
                    </td>
                    <td>
                     <% = YRKJ.MWR.Business.BizHelper.GetTxnRecoverHeaderOptType(item.OperateType)%>
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
                </form>
            </div>
	    </div>
	    <!-- END EXAMPLE TABLE PORTLET-->
	   
    </div>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
