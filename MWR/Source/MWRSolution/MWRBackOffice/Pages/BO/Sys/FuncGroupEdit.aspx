<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="FuncGroupEdit.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Sys.FuncGroupEdit" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/assets/css/pages/profile.css" rel="stylesheet" type="text/css">
<link href="/assets/css/pages/inbox.css" rel="stylesheet" type="text/css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
            <h3 class="page-title">
                权限组管理 <small>添加、设置权限组</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li><i class="fa fa-home"></i><a href="#<% = RedirectHelper.BOMain %>">首页</a> <i
                    class="fa fa-angle-right"></i></li>
                <li><a href="#<% = RedirectHelper.UserPermit %>">权限管理</a><i
                    class="fa fa-angle-right"></i></li></li>
                <li>权限组管理</li>
            </ul>

            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
    <div class="clearfix">
    </div>

    
    <div class="row">
        <div class="col-md-3  inbox">
           
               
            <form role="form"
                id="mwFrmNewFuncGroup" 
                data-wgt="mw-submit" 
                data-wgt-submit-method="AjaxAddNewFuncGroup" 
                <%-- data-wgt-submit-options-recall="CommHelper.recallCarDispatch"--%>
                action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.FuncGroupEdit) %>" class="">
                <input id="Hidden1" type="hidden" name="functionGroupId" value="<% = PageCurPermitGroupId+"" %>" />
            <ul class="inbox-nav margin-bottom-10 mw-menu">
            
				<li class="compose-btn">
				    <div class="form-group">
					    <label>添加新的权限组</label>
					    <div class="input-group input-medium col-md-3">
                            <input id="funcGrpName" name="funcGrpName" type="text" class="form-control" maxlength="<% = YRKJ.MWR.TblMWFunctionGroup.getFuncGroupNameColumn().ColumnSize %>" placeholder="权限组名称">
				            <span class="input-group-btn">
					            <button class="btn green" type="submit">添加</button>
				            </span>
			            </div>
                    </div>
				</li>
                <%
                    int i = 0;
                    foreach (YRKJ.MWR.TblMWFunctionGroup item in PageFuncGroupDataList)
	{
                        
        string active = i == 0 ? "active" : "";
        i++;
                %>
				<li class="mw-tab-item <% = active %>">
                  
					<a href="#" data-wgt="mw-changeFuncDetail" data-mw-changefuncgroup-id="<% = item.FuncGroupId %>" class="btn" data-toggle="tab" data-title="Inbox"><% = item.FuncGroupName %>
                     <% = (item.FuncGroupId < 0 ? "(默认组)" : "")%>
                    </a><b></b>
                   
                </li>
                
                <%
	}
                %>
			</ul>
            </form>
		</div>

        <div class="col-md-9">
        <form id="mwFrmFuncDetail" 
            data-wgt="mw-submit" 
            data-wgt-submit-method="AjasSubFunctionGroupDetail" 
            data-wgt-submit-options-recall="FuncGroupEditHelper.removeFuncGroupRecall"
            action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.FuncGroupEdit) %>" class="">
        <input id="functionGroupId" type="hidden" name="functionGroupId" value="<% = PageCurPermitGroupId %>" />
        <input id="optFuncTag" type="hidden" name="optFuncTag" value="" />
        <input id="optType" type="hidden" name="optType" value="none" />
            <div class="portlet">
				<div class="portlet-title line">
					<div class="caption">
						<i class="fa fa-check"></i>当前组-<% = PageCurPermitGroupName %>
					</div>
					<div class="tools">
						<a href="" class="collapse"></a>
					</div>
                     <% if (PageCurPermitGroupId > 0)
                        { %>
                    <div class="actions">
						<a href="#" data-wgt="mw-removeFuncGroup" class="btn btn-sm red easy-pie-chart-reload"><i class="fa  fa-minus-circle"></i> 删除当前组</a>
					</div>
                    <% } %>
				</div>
				<div class="portlet-body" id="chats">
                    <table class="table table-striped table-bordered table-advance table-hover">
				        <thead>
				        <tr>
					        <th>
						        <i class="fa fa-briefcase"></i> 功能名称
					        </th>
                            <th>
						        <i class="fa fa-briefcase"></i> 所属模块
					        </th>
					        <th class="hidden-xs">
						       
					        </th>
				        </tr>
				        </thead>
				        <tbody>
                        
                            <%
                                foreach (YRKJ.MWR.TblMWFunction item in PageCurGroupFunctionDataList)
	{
                            %>
				            <tr>
					            <td>
						            <a href="javascript:;"><% = GetFunctionShortName(item.FuncName) %></a>
					            </td>
                                <td class="hidden-xs">
						            <% = GetFunctionPackageName(item.FuncName) %>
					            </td>
					            <td align="right">
                                    <% if (PageCurPermitGroupId < 0) { %>
                                    <a href="javascript:;"  class="btn default btn-xs green-stripe"  >默认功能</a>
                                    <% }else{ %>
						            <a data-wgt="mw-removeFuncGroupDetail" data-mw-optfuncgroup-code="<% = item.FuncTag %>" class="btn default btn-xs red-stripe" href="#">移出当前组</a>
					                 <% } %>
                                </td>
				            </tr>
                            <%
	}
                            %>
				            
				        </tbody>
				        </table>
                </div>
			</div>

            <div class="portlet">
				<div class="portlet-title line">
					<div class="caption">
						<i class="fa fa-check"></i>其他功能
					</div>
					<div class="tools">
						<a href="" class="collapse"></a>
						
					</div>
				</div>
				<div class="portlet-body" id="Div1">
                    <table class="table table-striped table-bordered table-advance table-hover">
				        <thead>
				        <tr>
					        <th>
						        <i class="fa fa-briefcase"></i> 功能名称
					        </th>
                            <th>
						        <i class="fa fa-briefcase"></i> 所属模块
					        </th>
					        <th class="hidden-xs">
						       
					        </th>
				        </tr>
				        </thead>
				        <tbody>
                        
                            <%
                                foreach (YRKJ.MWR.TblMWFunction item in PageOtherFunctionDataList)
	{
                            %>
				            <tr>
					            <td>
						            <a href="javascript:;"><% = GetFunctionShortName(item.FuncName) %></a>
					            </td>
                                <td class="hidden-xs">
						            <% = GetFunctionPackageName(item.FuncName) %>
					            </td>
					            <td align="right">
						            <a data-wgt="mw-addFuncGroupDetail" data-mw-optfuncgroup-code="<% = item.FuncTag %>" class="btn default btn-xs blue-stripe" href="#">转到当前组</a>
					            </td>
				            </tr>
                            <%
	}
                            %>
				            
				        </tbody>
				        </table>
                </div>
			</div>
        </form>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script src="/assets/funcgroupedit.js"></script>
 <script type="text/javascript">
     jQuery(document).ready(function () {
         FuncGroupEditHelper.init();
         $('#funcGrpName').focus();
     });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
