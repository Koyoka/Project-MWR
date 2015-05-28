<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

			<!-- END STYLE CUSTOMIZER -->
			<!-- BEGIN PAGE HEADER-->
			<div class="row">
				<div class="col-md-12">
					<!-- BEGIN PAGE TITLE & BREADCRUMB-->
					<h3 class="page-title">
					错误 <small>错误信息</small>
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
							错误
						</li>
					</ul>
					<!-- END PAGE TITLE & BREADCRUMB-->
				</div>
			</div>
			<!-- END PAGE HEADER-->
			<!-- BEGIN PAGE CONTENT-->
			<div class="row">
				<div class="col-md-12 page-404">
					<div class="number" style="font-size:90px;">
						出错啦!
					</div>
					<div class="details">
						<h3><% = string.IsNullOrEmpty(Request.QueryString["Msg"]) ? "" : Request.QueryString["Msg"].ToString()%></h3>
                         <%
                        string btype = Request.QueryString["BT"] == null ? "" : Request.QueryString["BT"].ToString();
                        string href = Request.QueryString["BP"] == null ? "" : Request.QueryString["BP"].ToString();
                        if (btype == YRKJ.MWR.BackOffice.Business.Sys.RedirectHelper.BackType.redirect.ToString())
                        {
                            href = YRKJ.MWR.BackOffice.Business.Sys.WebAppFn.GetBoFullPageUrl(href);
                        }
                        else if (btype == YRKJ.MWR.BackOffice.Business.Sys.RedirectHelper.BackType.include.ToString())
                        {
                            href = "#" + href;
                        }
                         %>
						<p>
							 请根据错误信息联系管理员<br>
							<a href="<% = href %>">返回主页</a> 
						</p>
						
					</div>
				</div>
			</div>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
