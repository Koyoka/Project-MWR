<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="UserPermit.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Sys.UserPermit" %>
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
                权限管理 <small>添加、设置用户所属的权限组</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li><i class="fa fa-home"></i><a href="#<% = RedirectHelper.BOMain %>">首页</a> <i
                    class="fa fa-angle-right"></i></li>
                <li>权限管理</li>

               
            </ul>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
    <div class="clearfix">
    </div>

<%--
    <div class="col-md-12">
		<div class="add-portfolio">
			<span>
				5 个权限组
			</span>
			<a href="#" class="btn icn-only green">添加新的权限组 <i class="m-icon-swapright m-icon-white"></i></a>
		</div>
	</div>--%>

    <div class="row">
        <div class="col-md-3  inbox">

            <ul class="inbox-nav margin-bottom-10 ">
				<li class="compose-btn">
					<a href="#" data-title="Compose" class="btn green">
					<i class="fa fa-plus"></i> 权限组列表（点击添加） </a>
				</li>
                <%
                    int i = 0;
                    foreach (YRKJ.MWR.TblMWFunctionGroup item in PageFuncGroupDataList)
	{
                        
        string active = i == 0 ? "active" : "";
        i++;
                %>
				<li class=" <% = active %>">
					<a href="#" data-wgt="mw-changeFuncGroup" data-mw-changefuncgroup-id="<% = item.FuncGroupId %>" class="btn" data-toggle="tab" data-title="Inbox"><% = item.FuncGroupName %></a><b></b>
				</li>
                
                <%
	}
                %>
				<%--<li class="">
					<a class="btn" href="#" data-toggle="tab"  data-title="Sent">库存工作站</a><b></b>
				</li>
				<li class="">
					<a class="btn" href="#" data-toggle="tab"  data-title="Draft">处置工作站</a><b></b>
				</li>
				<li class="">
					<a class="btn" href="#" data-toggle="tab"  data-title="Trash">审核组</a><b></b>
				</li>--%>
			</ul>

			<%--<ul class="ver-inline-menu tabbable margin-bottom-10">
				<li class="active">
					<a data-toggle="tab" href="#tab_1">
					<i class="fa fa-briefcase"></i> General Questions </a>
					<span class="after">
					</span>
				</li>
				<li>
					<a data-toggle="tab" href="#tab_2"><i class="fa fa-group"></i> Membership</a>
				</li>
				<li>
					<a data-toggle="tab" href="#tab_3"><i class="fa fa-leaf"></i> Terms Of Service</a>
				</li>
				<li>
					<a data-toggle="tab" href="#tab_1"><i class="fa fa-info-circle"></i> License Terms</a>
				</li>
				<li>
					<a data-toggle="tab" href="#tab_2"><i class="fa fa-tint"></i> Payment Rules</a>
				</li>
				<li>
					<a data-toggle="tab" href="#tab_3"><i class="fa fa-plus"></i> Other Questions</a>
				</li>
			</ul>--%>
		</div>


        <div class="col-md-9">

        <form id="mwFrmUserFuncGrp" 
                       data-wgt="mw-submit" 
                       data-wgt-submit-method="AjaxRefUserPermitGroup" 
                      <%-- data-wgt-submit-options-recall="CommHelper.recallCarDispatch"--%>
                       action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.UserPermit) %>" class="">
        <input id="functionGroupId" type="hidden" name="functionGroupId" value="<% = PageCurPermitGroupId %>" />
        <input id="optEmpyCode" type="hidden" name="optEmpyCode" value="" />
        <input id="optType" type="hidden" name="optType" value="none" />
            <div class="portlet">
				<div class="portlet-title line">
					<div class="caption">
						<i class="fa fa-check"></i>当前组-<% = PageCurPermitGroupName %>
					</div>
					<div class="tools">
						<a href="" class="collapse"></a>
						
					</div>
				</div>
				<div class="portlet-body" id="chats">
                    <table class="table table-striped table-bordered table-advance table-hover">
				        <thead>
				        <tr>
					        <th>
						        <i class="fa fa-briefcase"></i> 员工姓名
					        </th>
					        <th class="hidden-xs">
						        <i class="fa fa-question"></i> 员工编号
					        </th>
					        <th>
						       <%-- <i class="fa fa-bookmark"></i> --%>
					        </th>
					       <%-- <th>
					        </th>--%>
				        </tr>
				        </thead>
				        <tbody>
                        
                            <%
                                foreach (YRKJ.MWR.TblMWEmploy item in PageCurPermitEmpyDataList)
	{
                            %>
				            <tr>
					            <td>
						            <a href="javascript:;"><% = item.EmpyName%></a>
					            </td>
					            <td class="hidden-xs">
						            <% = item.EmpyCode %>
					            </td>
					            <td align="right">
						            <a data-wgt="mw-removeFuncGroup" data-mw-optfuncgroup-code="<% = item.EmpyCode %>" class="btn default btn-xs red-stripe" href="#">移出当前组</a>
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
						<i class="fa  fa-plus"></i>未分配成员
					</div>
					<div class="tools">
						<a href="" class="collapse"></a>
						
					</div>
				</div>
				<div class="portlet-body" id="Div2">
                    <table class="table table-striped table-bordered table-advance table-hover">
                         <thead>
				            <tr>
					            <th>
						            <i class="fa fa-briefcase"></i> 员工姓名
					            </th>
					            <th class="hidden-xs">
						            <i class="fa fa-question"></i> 员工编号
					            </th>
					            <th>
					            </th>
				            </tr>
				        </thead>
				        <tbody>
                            <%
                                foreach (YRKJ.MWR.TblMWEmploy item in PageNoPermitEmpyDataList)
	{
                            %>
                              <tr>
					            <td>
						            <a href="javascript:;">
						            <% = item.EmpyName%> </a>
					            </td>
					            <td class="hidden-xs">
						            <% = item.EmpyCode %>
					            </td>
					            <td align="right">
						            <a data-wgt="mw-addFuncGroup" data-mw-optfuncgroup-code="<% = item.EmpyCode %>" class="btn default btn-xs green-stripe" href="#">添加当前组</a>
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
						<i class="fa fa-user"></i>其他组成员
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
						            <i class="fa fa-briefcase"></i> 员工姓名
					            </th>
					            <th class="hidden-xs">
						            <i class="fa fa-question"></i> 员工编号
					            </th>
					            <th>
						          所属权限组
					            </th>
					            <th>
					            </th>
				            </tr>
				        </thead>
				        <tbody>
                        
                            <%
                                foreach (YRKJ.MWR.TblMWEmploy item in PageOtherPermitEmpyDataList)
	{
                            %>
				            <tr>
					            <td>
						            <a href="javascript:;">
						            <% = item.EmpyName%> </a>
					            </td>
					            <td class="hidden-xs">
						            <% = item.EmpyCode %>
					            </td>
					            <td>
						            <% = GetFunctionGroupName(item.FuncGroupId)%>
					            </td>
					            <td align="right">
						            <a data-wgt="mw-addFuncGroup" data-mw-optfuncgroup-code="<% = item.EmpyCode %>" class="btn default btn-xs blue-stripe" href="#">转到当前组</a>
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
<script src="/assets/userpermit.js"></script>
 <script type="text/javascript">
     jQuery(document).ready(function () {
         UserPermitHelper.init();
     });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
