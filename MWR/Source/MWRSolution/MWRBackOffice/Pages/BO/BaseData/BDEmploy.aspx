<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="BDEmploy.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDEmploy" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		员工档案 <small>查看、编辑员工信息</small>
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
				员工档案
			</li>
		</ul>
	</div>
</div>
<div class="clearfix">
</div>
	<div class="row">
		<div class="col-md-12">
         <div class="alert alert-danger display-hide">
			<button class="close" data-close="alert"></button>
			表单未能提交，请检查输入项
		</div>
			<!-- BEGIN EXAMPLE TABLE PORTLET-->
			<div class="portlet box blue">
				<div class="portlet-title">
					<div class="caption">
						<i class="fa fa-edit"></i>员工列表
					</div>
					<div class="tools">
						
					</div>
				</div>
				<div class="portlet-body">
					
                    <form data-wgt="mw-submit-group mw-edittable" 
                        id="mwFrmList"
                        data-wgt-submit-method="AjaxSubEmpy" 
                        <%--data-wgt-submit-options-reload="true" 
                        data-wgt-submit-options-block="true" --%>
                       data-wgt-submit-options-recall="BOBDEmploy.subrecall"
                        action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.BDEmploy) %>">
                        <div class="table-toolbar">
					        <div class="btn-group">
						        <button id="sample_editable_1_new" type="button" class="btn green mw-creat">
						        添加新员工 <i class="fa fa-plus"></i>
						        </button>
					        </div>
				        </div>

					<table class="table table-striped table-hover table-bordered" id="sample_editable_1">
					<thead>
					<tr>

                        <th>
                            员工编号
                        </th>
                         <th>
                            密码
                        </th>
                        <th>
                            员工姓名
                        </th>
                            <th>
                            员工职责
                        </th>
                        <th>
                            所属权限组
                        </th>
						
						<th>
							 编辑
						</th>
						<th width="50">
							
						</th>
					</tr>
					</thead>
					<tbody>
                                <%
                                    foreach (var item in PageEmployDataList)
                                    {
                                %>
					<tr>
						<td>
                            <% = item.EmpyCode %>
                        </td>
                        <td>
                            ******
                           <input type="password" value="<% = item.EmpyPassword %>" style="border:0px;display:none;" />
                        </td>
                        <td>
                            <% = item.EmpyName %>
                        </td>
                        <td>
                            <% = item.EmpyType %>
                        </td>
                        <td>
                            <% = item.FuncGroup %>
                        </td>
						<td>
							<a class="edit" href="javascript:;">编辑</a>
						</td>
						<td >
							<%--<a class="delete" href="javascript:;">Delete</a>--%>
                             <% if (item.IsActive) %>
                            <% { %>
                                <a href="#" data-wgt="mw-voidempy" data-wgt-empycode="<% = item.EmpyCode %>" class="btn default btn-xs red cancel"><i class="fa fa-edit"></i> 注销</a>
                            <% } %>
                            <% if (!item.IsActive) %>
                            <% { %>
                                <a href="#" data-wgt="mw-activeempy" data-wgt-empycode="<% = item.EmpyCode %>"  class="btn default btn-xs green cancel"><i class="fa fa-edit"></i> 激活</a>
                            <% } %>
						</td>
					</tr>
                    <% 
                                    }
                            %>
					</tbody>
                    <tfoot>
                        <tr id="mw-rowedittemp" style="display:none;">
                            <td>
                                [Value]<input id="[empty]empyCode" name="[empty]empyCode" submit-group="[empty]save" type="hidden" class="form-control input-small" value="" />
                            </td>
                             <td>
                                <input id="[empty]password" name="[empty]password" submit-group="[empty]save" maxlength="25" type="text" class="form-control input-small" value="" />
                            </td>
                            <td>
                                <input id="[empty]empyName" name="[empty]empyName" submit-group="[empty]save" maxlength="25" type="text" class="form-control input-small" value="" />
                            </td>
                            <td>
                                <select  id="[empty]empyType" name="[empty]empyType" submit-group="[empty]save" class="form-control">
                                    <option text="一般员工" value="<% = YRKJ.MWR.TblMWEmploy.EMPYTYPE_ENUM_WorkStation%>">一般员工</option>
                                    <option text="司机"  value="<% = YRKJ.MWR.TblMWEmploy.EMPYTYPE_ENUM_Driver%>">司机</option>
                                    <option  text="跟车员" value="<% = YRKJ.MWR.TblMWEmploy.EMPYTYPE_ENUM_Inspector%>">跟车员</option>
                                </select>
                               <%-- <input type="hidden" class="form-control input-small" value="" />--%>
                            </td>
                            <td>
                                <select  id="[empty]empyFuncGroup" name="[empty]empyFuncGroup" submit-group="[empty]save" class="form-control ">
                                    <%
                                        foreach (var func in PageFuncGroupDataList)
	{
                                            
                                    %>
                                    <option text="<% = func.FuncGroupName %>" value="<% = func.FuncGroupId%>"><% = func.FuncGroupName %></option>
                                    <%
	}
                                    %>
                                </select>
                            </td>
						    <td>
							     <a class="edit" data-mode="save" data-opt="edit" href="">保存</a> <a class="cancel"  href="">取消</a>
                                 <input type="hidden" name="[empty]optType" submit-group="[empty]save" value="edit" />
						    </td>
						    <td>
							    [Value]
						    </td>
                        </tr>
                        <tr id="mw-rownewtemp" style="display:none;">
                            <td>
                                <input id="[empty1]empyCode" name="[empty1]empyCode" submit-group="[empty1]save"  maxlength="10" type="text" class="form-control input-small" value="" />
                            </td>
                             <td>
                                <input id="[empty1]password" name="[empty1]password" submit-group="[empty1]save"  maxlength="25" type="text" class="form-control input-small" value="" />
                            </td>
                            <td>
                                <input id="[empty1]empyName" name="[empty1]empyName" submit-group="[empty1]save"  maxlength="25" type="text" class="form-control input-small" value="">
                            </td>
                            <td>
                                <select  id="[empty1]empyType" name="[empty1]empyType" submit-group="[empty1]save" class="form-control">
                                    <option text="一般员工" value="<% = YRKJ.MWR.TblMWEmploy.EMPYTYPE_ENUM_WorkStation%>">一般员工</option>
                                    <option text="司机"  value="<% = YRKJ.MWR.TblMWEmploy.EMPYTYPE_ENUM_Driver%>">司机</option>
                                    <option  text="跟车员" value="<% = YRKJ.MWR.TblMWEmploy.EMPYTYPE_ENUM_Inspector%>">跟车员</option>
                                </select>
                            </td>
                            <td>
                                 <select  id="[empty1]empyFuncGroup" name="[empty1]empyFuncGroup" submit-group="[empty1]save" class="form-control ">
                                    <%
                                        foreach (var func in PageFuncGroupDataList)
	{
                                            
                                    %>
                                    <option text="<% = func.FuncGroupName %>" value="<% = func.FuncGroupId%>"><% = func.FuncGroupName %></option>
                                    <%
	}
                                    %>
                                </select>
                            </td>
						    <td>
							     <a class="edit"  data-mode="save" data-opt="new" href="">保存</a> <a class="cancel" data-mode="new" href="">取消</a>
                                 <input type="hidden" name="[empty1]optType" submit-group="[empty1]save" value="new" />
						    </td>
						    <td>
							
						    </td>
                        </tr>
                        <tr id="mw-rowdefaulttemp" style="display:none;">
                            <td>
                                [Value]
                            </td>
                             <td>
                                [Value]
                            </td>
                            <td>
                               [Value]
                            </td>
                            <td>
                                [Value]
                            </td>
                            <td>
                                [Value]
                            </td>
						    <td>
							     <a class="edit"  data-mode="save" data-opt="new" href="">保存</a> <a class="cancel" data-mode="new" href="">取消</a>
						    </td>
						    <td>
							
						    </td>
                        </tr>
                    </tfoot>
					</table>
                    
                    <input id="mw-opyEmpyCode" submit-group="active" type="hidden" name="opyEmpyCode" value="" />
                    <input id="mw-opyType" submit-group="active" type="hidden" name="opyType" value="" />
                    <uc1:UPage ID="c_UPage" runat="server" />
                    </form>
				</div>
			</div>
			<!-- END EXAMPLE TABLE PORTLET-->
		</div>
	</div>
<div class="clearfix">
</div>
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script type="text/javascript" src="/assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/jquery.dataTables.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>
<script src="/assets/bobdemploy.js"></script>
<script src="/assets/wgt-edittable.js"></script>
<script>
    jQuery(document).ready(function () {
        BOBDEmploy.init();
        WGTEdtiTable.init(BOBDEmploy.initOTable());
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
