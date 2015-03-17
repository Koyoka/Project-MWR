<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="IntegratedReport.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Report.IntegratedReport" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/assets/css/pages/pricing-tables.css" rel="stylesheet" type="text/css" />
<link href="/assets/css/pages/profile.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		综合报告 <small>查看医疗机构、废料的库存处理数据</small>
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
				综合报告
			</li>
		</ul>
	</div>
</div>
<div class="clearfix">
</div>

<div class=" row portfolio-block note note-info">
		<div class="col-md-3 ">
			<div class="portfolio-text ">
				<div class="portfolio-info">
					<h4>回收系统统计信息</h4>
					<p>
						当前系统重量信息
					</p>
				</div>
			</div>
		</div>
		<div class="col-md-8 portfolio-stat " >
			<div class="portfolio-info">
					回收总重量
				<span>
					<% = PageInventoryReortData.RecoWeight %> KG
				</span>
			</div>
			<div class="portfolio-info">
					库存总重量
				<span>
					<% = PageInventoryReortData.InvWeight %> KG
				</span>
			</div>
			<div class="portfolio-info">
					处置总重量
				<span>
					<% = PageInventoryReortData.DestWeight %> KG
				</span>
			</div>
		</div>
	</div>

			<div class="row">
				<div class="col-md-12">
					<!-- BEGIN INLINE NOTIFICATIONS PORTLET-->
					<div class="portlet box blue">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-cogs"></i>医疗机构回收统计信息
							</div>
							<div class="tools">
								<a href="javascript:;" class="collapse"></a>
								<%--<a href="#portlet-config" data-toggle="modal" class="config"></a>
								<a href="javascript:;" class="reload"></a>
								<a href="javascript:;" class="remove"></a>--%>
							</div>
						</div>
						<div class="portlet-body">
							<div class="row">
                                <%
                                    foreach (var item in PageVendorInfoDataList)
	{
                                %>
								<div class="col-md-3">
									<div class="pricing-table">
										<h2><% = item.Vendor %></h2>
										<div class="desc text-right">
											回收废料 Top <% = topCount%>.
										</div>
										<ul>
                                        <%-- <li>
												<h5></h5>
											</li>--%>
                                            <%
	foreach (var subItem in item.TopWasteDataList)
	{
        
                                            %>
											<li>
												<i class="fa fa-angle-right"></i> 
                                                <span ><% = subItem.Waste %> <% = subItem.RecoverWeight%></span> KG
											</li>
                                            
                                            <%
	}
                                            %>
                                            <%
                                                for (int i = 0; i < topCount - item.TopWasteDataList.Count; i++)
                                                {
                                            %>
                                            <li>
												&nbsp;
											</li>
                                            <%
                                                }
                                            %>
										</ul>
										<div class="rate">
                                            
											<div class="price">
												<div class="currency ">
													 KG<br/>
													总重量
												</div>
												<div class="amount " style="padding-left:15px;">
													 <% = item.RecoverWeight %>
												</div>
											</div>
                                           
										</div>
                                        <div class="text-right">
                                        
											<a href="#<% = RedirectHelper.VendorReport+"?code="+item.Code %>" class="btn blue">
											查看详情 <i class="m-icon-swapright m-icon-white"></i>
											</a>
                                        </div>
									</div>
								</div>
								<div class="spance10 visible-xs">
								</div>
                                                                <%
	}
                                %>
								<%--<div class="col-md-3">
									<div class="pricing-table">
										<h3>武汉医院</h3>
										<div class="desc">
											 以下显示当前医疗机构，回收废料前5位的废料类型.
										</div>
										<ul>
											<li>
												<i class="fa fa-angle-right"></i> A型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> B型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> C型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> D型废料 10KG
											</li>
											<li>
												&nbsp;
											</li>
											<li>
												&nbsp;
											</li>
											<li>
												&nbsp;
											</li>
										</ul>
										<div class="rate">
                                            
											<div class="price">
												<div class="currency ">
													 KG<br/>
													总重量
												</div>
												<div class="amount ">
													 99
												</div>
											</div>
											<a href="#" class="btn green">
											查看详情 <i class="m-icon-swapright m-icon-white"></i>
											</a>
										</div>
									</div>
								</div>
								<div class="spance10 visible-xs">
								</div>
                                <div class="col-md-3">
									<div class="pricing-table">
										<h3>武汉医院</h3>
										<div class="desc">
											 以下显示当前医疗机构，回收废料前5位的废料类型.
										</div>
										<ul>
											<li>
												<i class="fa fa-angle-right"></i> A型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> B型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> C型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> D型废料 10KG
											</li>
											<li>
												&nbsp;
											</li>
											<li>
												&nbsp;
											</li>
											<li>
												&nbsp;
											</li>
										</ul>
										<div class="rate">
                                            
											<div class="price">
												<div class="currency ">
													 KG<br/>
													总重量
												</div>
												<div class="amount ">
													 99
												</div>
											</div>
											<a href="#" class="btn green">
											查看详情 <i class="m-icon-swapright m-icon-white"></i>
											</a>
										</div>
									</div>
								</div>
								<div class="spance10 visible-xs">
								</div>
                                <div class="col-md-3">
									<div class="pricing-table">
										<h3>武汉医院</h3>
										<div class="desc">
											 以下显示当前医疗机构，回收废料前5位的废料类型.
										</div>
										<ul>
											<li>
												<i class="fa fa-angle-right"></i> A型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> B型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> C型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> D型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> A型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> B型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> C型废料 10KG
											</li>
											<li>
												<i class="fa fa-angle-right"></i> D型废料 10KG
											</li>
										</ul>
										<div class="rate">
                                            
											<div class="price">
												<div class="currency ">
													 KG<br/>
													总重量
												</div>
												<div class="amount ">
													 99
												</div>
											</div>
											<a href="#" class="btn green">
											查看详情 <i class="m-icon-swapright m-icon-white"></i>
											</a>
										</div>
									</div>
								</div>
                                <div class="spance10 visible-xs">
								</div>--%>
							</div>
						</div>
					</div>
					<!-- END INLINE NOTIFICATIONS PORTLET-->
				</div>
			</div>
			<div class="row">
				<div class="col-md-12">
					<!-- BEGIN INLINE NOTIFICATIONS PORTLET-->
					<div class="portlet box green">
						<div class="portlet-title">
							<div class="caption">
								<i class="fa fa-cogs"></i>医疗废料统计信息
							</div>
							<div class="tools">
								<a href="javascript:;" class="collapse"></a>
								<%--<a href="#portlet-config" data-toggle="modal" class="config"></a>
								<a href="javascript:;" class="reload"></a>
								<a href="javascript:;" class="remove"></a>--%>
							</div>
						</div>
						<div class="portlet-body">
							<div class="row">
                                <%
                                    foreach (var item in PageWasteInfoDataList)
	{
                                %>
								<div class="col-md-3">
									<div class="pricing-table">
										<h2><% = item.Waste %></h2>
										<div class="desc text-right">
											医疗机构 Top <% = topCount%>.
										</div>
										<ul>
                                        <%-- <li>
												<h5></h5>
											</li>--%>
                                            <%
	foreach (var subItem in item.TopVendorDataList)
	{
        
                                            %>
											<li>
												<i class="fa fa-angle-right"></i> 
                                                <span ><% = subItem.Vendor %> <% = subItem.RecoverWeight%></span> KG
											</li>
                                            
                                            <%
	}
                                            %>
                                            <%
                                                for (int i = 0; i < topCount - item.TopVendorDataList.Count; i++)
                                                {
                                            %>
                                            <li>
												&nbsp;
											</li>
                                            <%
                                                }
                                            %>
										</ul>
										<div class="rate">
                                            
											<div class="price">
												<div class="currency ">
													 KG<br/>
													总重量
												</div>
												<div class="amount " style="padding-left:15px;">
													 <% = item.RecoverWeight %>
												</div>
											</div>
											
										</div>
                                        <div class="text-right"><a href="#<% = RedirectHelper.WasteReport+"?code="+item.Code %>" class="btn green">
											查看详情 <i class="m-icon-swapright m-icon-white"></i>
											</a></div>
									</div>
								</div>
								<div class="spance10 visible-xs">
								</div>
                                                                <%
	}
                                %>
							
							</div>
						</div>
					</div>
					<!-- END INLINE NOTIFICATIONS PORTLET-->
				</div>
			</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
