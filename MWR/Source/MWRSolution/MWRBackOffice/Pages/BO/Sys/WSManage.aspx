<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="WSManage.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Sys.WSManage" %>
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
                工作站管理 <small>出入库、处置工作站，手机终端管理</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li><i class="fa fa-home"></i><a href="#<% = RedirectHelper.BOMain %>">首页</a> <i
                    class="fa fa-angle-right"></i></li>
                <li>工作站管理</li>

               
            </ul>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
    <div class="clearfix">
    </div>
    <!-- end target bar -->
    <div class="row">
         <div class="col-md-12 ">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-reorder"></i>工作站列表
                    </div>
                    <div class="tools">
                    <a data-wgt="mw-reload" data-wgt-reload-formid="mwWSList" href="" class="reload"></a>
                    </div>
                    <div class="actions">
                    
						<a href="#" data-wgt="mw-InitMobile" 
                            data-wgt-initmobile-url="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.WSManage)%>" 
                            data-wgt-initmobile-method="AjaxInitMobile"  
                            class="btn btn-sm yellow easy-pie-chart-reload"><i class="fa fa-plus"></i> 添加手机终端</a>
					</div>
                    
                </div>
                <div class="portlet-body ">
                <form data-wgt="mw-submit" 
                    id="mwWSList"
                    data-wgt-submit-method="AjaxGetWS" 
                    data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" 
                   <%-- data-wgt-submit-options-recall="CommHelper.recallCarDispatch" --%>
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.WSManage) %>">
                    <div class="table-responsive table-scrollable">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>
                                        终端号
                                    </th>
                                    <th>
                                        终端类型
                                    </th>
                                    <th>
                                        AssessKey
                                    </th>
                                    <th>
                                        SecretKey
                                    </th>
                                    <th>
                                        操作类型
                                    </th>
                                    
                                </tr>
                            </thead>
                            <tbody>
                                <%
                                    foreach (PageWSData data in PageWSDataList)
	{
                                %>
                                <tr>
                                    <td>
                                        <% = data.WSCode %>
                                    </td>
                                    <td>
                                        <% = data.WSType %>
                                    </td>
                                   
                                    <td>
                                        <% = data.AssessKey %>
                                    </td>
                                    <td>
                                        <% = data.SecretKey %>
                                    </td>
                                    <td>
                                    <% 
                                        if (data.CanInitMob)
                                        {
                                    %>
                                        <a href="javascript:void;" class="btn default btn-xs purple"><i class="fa fa-edit"></i> 未使用终端号</a>
                                    <% 
                                        }
                                    %>
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


    
                       
    <div id="stack1" class="modal fade" tabindex="-1" data-width="400" aria-hidden="true" style="display: none;">
		<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
					<h4 class="modal-title">手机终端注册</h4>
				</div>
				<div class="modal-body">
					<div class="row">
						<div class="col-md-4">
                            <div class="row">
                            <center><h4>二维码图片</h4></center>
                            </div>
                            <div class="row">
							    <img id="imgQRCode" style="margin:5px;" src="/Services/QRCodeThumbnail.ashx?content=eleven" />
                            </div>
						</div>
                        <div class="col-md-8">
								<h1>手机终端注册</h1>
								<p>
									初次使用手机终端，会提示手机未初始化。请点击扫描按钮，对准左边二维码图片进行扫描初始化。
								</p>
								<center><img src="/assets/images/sample_1.png" /></center>
						</div>

					</div>
               
				</div>
				<div class="modal-footer">
					<button type="button" data-dismiss="modal" class="btn">关闭</button>
					<%--<button type="button" class="btn red">确认</button>--%>
				</div>
			</div>
		</div>
	</div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
<script src="/assets/plugins/fullcalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
<script src="/assets/scripts/table-managed.js"></script>
<script src="/assets/wsmanage.js"></script>
 <script type="text/javascript">
     jQuery(document).ready(function () {
         WSManageHelper.init();
     });
    </script>
</asp:Content>
