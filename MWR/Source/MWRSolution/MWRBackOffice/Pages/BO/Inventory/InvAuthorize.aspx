<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.master" AutoEventWireup="true" CodeBehind="InvAuthorize.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Inventory.InvAuthorize" %>
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
                货损审核 <small>审核工作站上报货损货箱</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li><i class="fa fa-home"></i><a href="#<% = RedirectHelper.BOMain %>">首页</a> <i
                    class="fa fa-angle-right"></i></li>
                <li><a href="#">库存管理</a> <i class="fa fa-angle-right"></i></li>
                <li><a href="#<% = RedirectHelper.InvAuthorize %>">货损审核</a> </li>
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
                        <i class="fa fa-reorder"></i>货箱审核列表
                    </div>
                    <div class="actions ">

                    </div>
                </div>
                <div class="portlet-body ">
                <form data-wgt="mw-submit" 
                    id="mwAuthList"
                    data-wgt-submit-method="AjaxGetAuthorize" 
                    data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" 
                   <%-- data-wgt-submit-options-recall="CommHelper.recallCarDispatch" --%>
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.InvAuthorize) %>">
                    <!-- BEGIN FORM-->
                     <div class="table-responsive table-scrollable">
                        <table class="table table-hover">
                            <thead>
                                <tr>
                                    <th>
                                        交易编号
                                    </th>
                                    <th>
                                        货箱编号
                                    </th>
                                    <th>
                                        提交工作站
                                    </th>
                                    <th>
                                        提交人
                                    </th>
                                    <th>
                                        货箱预计重量
                                    </th>
                                    <th>
                                        货箱实际重量
                                    </th>
                                    <th>
                                        提交审核时间
                                    </th>
                                    <th>
                                        操作类型
                                    </th>
                                    <th>
                                        
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <%
                                    foreach (PageInvAuthorizeData item in PageInAuthorizeDataList)
	                                {
                                %>
                                <tr class="auth<% = item.AuthId %>">
                                    <td class="txnnum">
                                    <% = item.TxnNum %>
                                    </td>
                                    <td class="cratecode">
                                    <% = item.CrateCode %>
                                    </td>
                                    <td class="subwscode">
                                    <% = item.SubWSCode %>
                                    </td>
                                    <td class="subempyname">
                                    <% = item.SubEmpyName %>
                                    </td>
                                    <td class="subweight">
                                    <% = item.SubWeight %>
                                    </td>
                                    <td class="txnweight">
                                    <% = item.TxnWeight %>
                                    </td>
                                    <td class="entrydate">
                                    <% = item.EntryDate %>
                                    </td>
                                    <td class="txntype">
                                    <% = item.TxnType %>
                                    </td>
                                    <td>
                                        <input class="diffweight" type="hidden" value="<% = item.DiffWeight %>" /> 
                                        <a href="#<% = RedirectHelper.InvAuthorizeDetail %>?id=<% = item.AuthId %>" class="btn default btn-xs purple"><i class="fa fa-edit"></i> 审核</a>
                                        <!--
                                        <a href="#" data-wgt="mw-showauthform" data-wgt-showauthformid="auth<% = item.AuthId %>" data-target="#stack1"  data-toggle="modal" class="btn default btn-xs purple"><i class="fa fa-edit"></i> 审核</a>
                                        -->
                                    </td>
                                </tr>

                                <%
	                                }
                                %>
                                
                              
                            </tbody>
                        </table>
                       
                        <div id="stack1" class="modal fade" tabindex="-1" data-width="400" aria-hidden="true" style="display: none;">
								<div class="modal-dialog">
									<div class="modal-content">
										<div class="modal-header">
											<button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
											<h4 class="modal-title">货箱审核</h4>
										</div>
										<div class="modal-body">
											<div class="row">
												<div class="col-md-6 form">
                                                <div class="form-body">
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            交易编号</label>
                                                        <input id="txnnum" type="text" class="form-control" placeholder="Disabled" value="A00001" disabled="">
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="control-label">
                                                            提交工作站</label>
                                                        <input id="subwscode" type="text" class="form-control" placeholder="Disabled" value="WS001" disabled="">
                                                    </div>
                                                    <div class="form-group ">
                                                        <label class="control-label">
                                                            操作员</label>
                                                        <input id="subempyname" type="text" class="form-control" placeholder="Disabled" value="张三" disabled="">
                                                    </div>
                                                    <div class="form-group last">
                                                        <label class="control-label">
                                                            提交审核时间</label>
                                                        <input id="entrydate" type="text" class="form-control" placeholder="Disabled" value="张三" disabled="">
                                                    </div>
                                                </div>
												</div>
                                                <div class="col-md-6 form">
                                                    <div class="form-body">
                                                        <div class="form-group">
                                                            <label class="control-label">
                                                                货箱编号</label>
                                                            <input id="cratecode" type="text" class="form-control" placeholder="Disabled" value="A00001" disabled="">
                                                        </div>
                                                        <div class="form-group ">
                                                            <label class="control-label">
                                                                回收重量</label>
                                                            <input id="subweight" type="text" class="form-control" placeholder="Disabled" value="12KG" disabled="">
                                                        </div>
                                                        <div class="form-group ">
                                                            <label class="control-label">
                                                                实际重量</label>
                                                            <input id="txnweight" type="text" class="form-control" placeholder="Disabled" value="12KG" disabled="">
                                                        </div>
                                                        <div class="form-group last">
                                                            <label class="control-label">
                                                                重量差值</label>
                                                            <input id="diffweight" type="text" class="form-control" placeholder="Disabled" value="12KG" disabled="">
                                                        </div>
                                                    </div>
                                                </div>
											</div>
                                            <div class="row">
                                                <div class="col-md-12 form">
                                                    <div class="form-body">
                                                        <div class="form-group ">
                                                            <label class="control-label">
                                                                确认描述</label>
                                                            <input type="text" class="form-control" placeholder="审核确认通过原因" value="" >
                                                        </div>
                                                        <div class="form-group last">
                                                            <label class="control-label">
                                                                提交附件</label>
                                                            <input type="file" class="form-control" placeholder="审核确认通过附件" value="" >
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
										</div>
										<div class="modal-footer">
											<button type="button" data-dismiss="modal" class="btn">关闭</button>
											<button type="button" class="btn red">确认</button>
										</div>
									</div>
								</div>
							</div>
                    </div>
                    <uc1:UPage ID="c_UPage" runat="server" />
                  
                </form>
                    <!-- END FORM-->
                </div>
            </div>
         </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script src="/assets/plugins/fullcalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
<script src="/assets/scripts/table-managed.js"></script>
<script src="/assets/boinvauthorize.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        InvAuthHelper.init();
    });
</script>
</asp:Content>
