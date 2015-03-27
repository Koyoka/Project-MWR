<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="TxnDetail.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Txn.TxnDetail" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/assets/plugins/select2/select2_metro.css"/>
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
<link href="/assets/css/pages/invoice.css" rel="stylesheet" type="text/css">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		交易详情 <%--<small>查看所有废品出库交易详情</small>--%>
		</h3>
		<%--<ul class="page-breadcrumb breadcrumb">
			<li class="btn-group">
				
			</li>
			<li>
				<i class="fa fa-home"></i>
				<a href="#<% = RedirectHelper.BOMain %>">主页</a>
				<i class="fa fa-angle-right"></i>
			</li>
            <li>
				交易详情
			</li>
		</ul>--%>
	</div>
</div>

			<div class="invoice">
				<div class="row invoice-logo">
					<div class="col-xs-6 invoice-logo-space">
						<%--<img src="assets/img/invoice/walmart.png" alt=""/>--%>
					</div>
					<div class="col-xs-6">
						<p>
							#<% = PageTxnNumData%> / <% =  PageTxnStartDateData %>
							<span class="muted">
                                 操作状态：<% = PageTxnStatusData%> 
							</span>
						</p>
					</div>
				</div>
				<hr/><%--
				<div class="row">
					<div class="col-xs-4">
						<h4>Client:</h4>
						<ul class="list-unstyled">
							<li>
								John Doe
							</li>
							<li>
								Mr Nilson Otto
							</li>
							<li>
								FoodMaster Ltd
							</li>
							<li>
								Madrid
							</li>
							<li>
								Spain
							</li>
							<li>
								1982 OOP
							</li>
						</ul>
					</div>
					<div class="col-xs-4">
						<h4>About:</h4>
						<ul class="list-unstyled">
							<li>
								Drem psum dolor sit amet
							</li>
							<li>
								Laoreet dolore magna
							</li>
							<li>
								Consectetuer adipiscing elit
							</li>
							<li>
								Magna aliquam tincidunt erat volutpat
							</li>
							<li>
								Olor sit amet adipiscing eli
							</li>
							<li>
								Laoreet dolore magna
							</li>
						</ul>
					</div>
					<div class="col-xs-4 invoice-payment">
						<h4>Payment Details:</h4>
						<ul class="list-unstyled">
							<li>
								<strong>V.A.T Reg #:</strong> 542554(DEMO)78
							</li>
							<li>
								<strong>Account Name:</strong> FoodMaster Ltd
							</li>
							<li>
								<strong>SWIFT code:</strong> 45454DEMO545DEMO
							</li>
							<li>
								<strong>V.A.T Reg #:</strong> 542554(DEMO)78
							</li>
							<li>
								<strong>Account Name:</strong> FoodMaster Ltd
							</li>
							<li>
								<strong>SWIFT code:</strong> 45454DEMO545DEMO
							</li>
						</ul>
					</div>
				</div>--%>
				<div class="row">
					<div class="col-xs-12">
						<table class="table table-striped table-hover">
						<thead>
						<tr>
							<th>
								#
							</th>
							<th>
								货箱编号
							</th>
							<th class="hidden-480">
								来源医院
							</th>
							<th class="hidden-480">
								废品类型
							</th>
							<th class="hidden-480">
								提交重量
							</th>
							<th>
								实际重量
							</th>
						</tr>
						</thead>
						<tbody>
                            <%
                                int index = 0;
                                foreach (var item in PageDetailDataList)
	{
        index++;
                            %>
						<tr>
							<td>
								<% = index %>
							</td>
							<td>
								<% = item.CrateCode %>
							</td>
							<td class="hidden-480">
								<% = item.Vendor %>
							</td>
							<td class="hidden-480">
								<% = item.Waste %>
							</td>
							<td class="hidden-480">
								<% = item.SubWeight %>
							</td>
							<td>
								<% = item.TxnWeight %>
							</td>
						</tr>
                            <%
	}
                            %>
					
						</tbody>
						</table>
					</div>
				</div>
				<div class="row">
					<div class="col-xs-4">
						<div class="well">
							<address>
							<strong>操作信息.</strong><br/>
                            <% = PageTxnInfoData%>
							<%--795 Park Ave, Suite 120<br/>
							San Francisco, CA 94107<br/>
							<abbr title="Phone">P:</abbr> (234) 145-1810 </address>
							<address>
							<strong>Full Name</strong><br/>
							<a href="mailto:#">first.last@email.com</a>
							</address>--%>
						</div>
					</div>
					<div class="col-xs-8 invoice-block">
						<ul class="list-unstyled amounts" >
                            <li>
								<strong>操作总箱数:</strong> <span style="display:inline-block; width:60px;"><% = PageTotalQtyData %> 箱</span>
							</li>
							<li>
								<strong>提交总重量:</strong> <span style="display:inline-block; width:60px;"><% = PageTotalSubWeightData%> KG</span>
							</li>
							<li>
								<strong>实际总总量:</strong> <span style="display:inline-block; width:60px;"><% = PageTotalTxnWeightData%> KG</span>
							</li>
							<li>
								<strong>总重量差值:</strong> <span style="display:inline-block; width:60px;"><% = PageTotalDiffWeightData%> KG</span>
							</li>
							
						</ul>
						<br/>
						<a class="btn btn-lg blue hidden-print" onclick="javascript:window.print();">打印 <i class="fa fa-print"></i></a>
                        <a class="btn btn-lg green hidden-print" onclick="history.back();">返回 <i class="fa fa-check"></i></a>
						<%--<a class="btn btn-lg green hidden-print">Submit Your Invoice <i class="fa fa-check"></i></a>--%>
					</div>
				</div>
			</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
