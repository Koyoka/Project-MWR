<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="BDWaste.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDWaste" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		医疗废品档案 <small>查看、编辑医疗废品类型信息</small>
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
				医疗废品档案
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
		<div class="portlet box blue">
			<div class="portlet-title">
				<div class="caption">
					<i class="fa fa-edit"></i>废品类型列表
				</div>
				<div class="tools">
						
				</div>
			</div>
			<div class="portlet-body">
                <form data-wgt="mw-submit-group mw-edittable" 
                    id="mwFrmList"
                    data-wgt-submit-method="AjaxSubWaste" 
                    <%--data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" --%>
                    data-wgt-submit-options-recall="BOBDWaste.subrecall"
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.BDWaste) %>">
				    <div class="table-toolbar">
					    <div class="btn-group">
						    <button id="sample_editable_1_new" type="button" class="btn green mw-creat">
						    添加新废品类型 <i class="fa fa-plus"></i>
						    </button>
					    </div>
				    </div>
				<table class="table table-striped table-hover table-bordered" id="sample_editable_1">
				<thead>
				<tr>

                    <th>
                        废品类型编号
                    </th>
                    <th>
                        废品类型名称
                    </th>
					<th>
						编辑
					</th>
				</tr>
				</thead>
				<tbody>
                            <%
                                foreach (var item in PageWasteDataList)
                                {
                            %>
				<tr>
					<td>
                        <% = item.WasteCode %>
                    </td>
                    <td>
                        <% = item.Waste %>
                    </td>
					<td>
						<a class="edit" href="javascript:;">编辑</a>
					</td>
				</tr>
                <% 
                                }
                        %>
				</tbody>
                <tfoot>
                    <tr id="mw-rowedittemp" style="display:none;">
                        <td>
                        
                            [Value]<input id="[empty]wasteCode" name="[empty]wasteCode" submit-group="[empty]save" type="hidden" class="form-control input-small" value="" />
                        </td>
                            <td>
                            <input id="[empty]waste" name="[empty]waste" submit-group="[empty]save"  maxlength="<% = TblMWWasteCategory.getWasteColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                        </td>
						<td>
							    <a class="edit" data-mode="save" data-opt="edit" href="">保存</a> <a class="cancel"  href="">取消</a>
                                <input type="hidden" name="[empty]optType" submit-group="[empty]save" value="edit" />
						</td>
                    </tr>
                    <tr id="mw-rownewtemp" style="display:none;">
                        <td>
                        
                            <input id="[empty1]wasteCode"  name="[empty1]wasteCode" submit-group="[empty1]save" maxlength="<% = TblMWWasteCategory.getWasteCodeColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                        </td>
                            <td>
                            
                            <input id="[empty1]waste"  name="[empty1]waste" submit-group="[empty1]save" maxlength="<% = TblMWWasteCategory.getWasteColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                        </td>
						<td>
							    <a class="edit"  data-mode="save" data-opt="new" href="">保存</a> <a class="cancel" data-mode="new" href="">取消</a>
                                <input type="hidden" name="[empty1]optType" submit-group="[empty1]save" value="new" />
						</td>
                    </tr>
                </tfoot>
				</table>
                <uc1:UPage ID="c_UPage" runat="server" />
                </form>
			</div>
		</div>
	</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script type="text/javascript" src="/assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/jquery.dataTables.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>
<script src="/assets/bobdwaste.js"></script>
<script src="/assets/wgt-edittable.js"></script>
<script>
    jQuery(document).ready(function () {
        BOBDWaste.init();
        WGTEdtiTable.init();
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
