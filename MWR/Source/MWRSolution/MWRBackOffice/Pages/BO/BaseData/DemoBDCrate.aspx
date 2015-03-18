<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="DemoBDCrate.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BaseData.DemoBDCrate" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UServicePage.ascx" tagname="UServicePage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		货箱档案 <small>查看、编辑货箱信息</small>
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
				货箱档案
			</li>
		</ul>
	</div>
</div>
<div class="clearfix">
</div>

<div class="row">
	<div class="col-md-12">
		<!-- BEGIN EXAMPLE TABLE PORTLET-->
		<div class="portlet box blue">
			<div class="portlet-title">
				<div class="caption">
					<i class="fa fa-edit"></i>货箱列表
				</div>
				<div class="tools">
						
				</div>
			</div>
			<div class="portlet-body">
				<div class="table-toolbar">
					<div class="btn-group">
						<button id="sample_editable_1_new" class="btn green">
						添加新货箱 <i class="fa fa-plus"></i>
						</button>
					</div>
						
				</div>
                <button id="test" type="button"></button>
                <form data-wgt="mw-submit" 
                    id="mwFrmList"
                    data-wgt-submit-method="AjaxSubCrate" 
                    data-wgt-submit-options-page="false"
                    <%--data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" --%>
                    data-wgt-submit-options-recall="BOBDCrate.subrecall"
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.DemoBDCrate) %>">
                    <input id="mw-opyCode" submit-group="1" type="hidden" name="opyCode" value="" />
                    <input id="mw-opyType" submit-group="1" type="hidden" name="opyType" value="" />
                    <div id="mw-submit-page"
                        data-wgt="mw-submit-page" 
                        data-wgt-submit-url="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.DemoBDCrate) %>"
                        data-wgt-submit-method="AjaxSubPage"
                        data-wgt-submit-options-recall="BOBDCrate.subrecall">
				        <table class="table table-striped table-hover table-bordered" id="sample_editable_1">
				            <thead>
				            <tr>
                                <th>
                                    货箱编号
                                </th>
                                    <th>
                                    货箱名称
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
                                            foreach (var item in PageCrateDataList)
                                            {
                                        %>
				            <tr>
					            <td>
                                    <% = item.CrateCode %>
                                </td>
                                <td>
                                    <% = item.Desc %>
                                </td>
					            <td>
						            <a class="edit" data-wgt="mw-edittable-edit" href="javascript:;">编辑</a>
					            </td>
					            <td >
                                        <% if (item.Status != TblMWCar.STATUS_ENUM_Void) %>
                                    <% { %>
                                        <a href="#" data-wgt="mw-void" data-wgt-code="<% = item.CrateCode %>" class="btn default btn-xs red cancel"><i class="fa fa-edit"></i> 注销</a>
                                    <% } %>
                                    <% if (item.Status == TblMWCar.STATUS_ENUM_Void) %>
                                    <% { %>
                                        <a href="#" data-wgt="mw-active" data-wgt-code="<% = item.CrateCode %>"  class="btn default btn-xs green cancel"><i class="fa fa-edit"></i> 激活</a>
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
                                        [Value]<input  submit-group="[empty]save" name="[empty]crateCode" type="hidden" class="form-control input-small" value="" />
                                    </td>
                                    <td>
                                        <input  name="[empty]desc" submit-group="[empty]save" maxlength="<% = TblMWCrate.getDescColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                                    </td>
						            <td>
							            <a class="edit" data-wgt="mw-edittable-edit" data-mode="save" data-opt="edit" href="">保存</a> 
                                        <a class="cancel" data-wgt="mw-edittable-cancel"  href="">取消</a>
                                       <%-- <input type="hidden" name="optType" submit-group="[empty]save" value="edit" />--%>
						            </td>
						            <td>
							            [Value]
						            </td>
                                </tr>
                                <tr id="mw-rownewtemp" style="display:none;">
                                    <td>
                                        <input  name="[empty1]crateCode" submit-group="[empty1]save"  maxlength=" <% = TblMWCrate.getCrateCodeColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                                    </td>
                                    <td>
                                        <input  name="[empty1]desc" submit-group="[empty1]save"  maxlength="<% = TblMWCrate.getDescColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                                    </td>
						            <td>
							            <a class="edit" data-wgt="mw-edittable-edit" data-mode="save" data-opt="new" href="">保存</a> 
                                        <a class="cancel" data-wgt="mw-edittable-cancel" data-mode="new" href="">取消</a>
                                        <input type="hidden" name="optType" submit-group="[empty1]save" value="new" />
						            </td>
						            <td>
							
						            </td>
                                </tr>
                            </tfoot>
				        </table>
                        <uc1:UServicePage ID="c_UPage" runat="server" />
                    </div>
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
<script src="/assets/demobobdcrate.js"></script>
<script src="/assets/wgt-edittable.js"></script>
<script>
    jQuery(document).ready(function () {
        BOBDCrate.init();
        WGTEdtiTable.init();

        $('#test').click(function (e) {
//            $('form').setGroup('1');

//            var json = $('form').serializeGroupJson();
//            var s = JSON.stringify(json)
            //            window.alert(s); //$.stringifyJSON($('form').serializeJson())

            $('#mwFrmList').setGroup('save');

            json = $('#mwFrmList').serializeGroupJson();
             s = JSON.stringify(json)
             window.alert(s); //$.stringifyJSON($('form').serializeJson())
            
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
