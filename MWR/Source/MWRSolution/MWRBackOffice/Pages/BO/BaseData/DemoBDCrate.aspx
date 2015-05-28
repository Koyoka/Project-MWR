<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="DemoBDCrate.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BaseData.DemoBDCrate" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%--<%@ Register src="../../UCtrl/UServicePage.ascx" tagname="UServicePage" tagprefix="uc1" %>--%>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>
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
                <a class="mw-redirect" href="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.BOMain) %>">主页</a>
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
        <div class="alert alert-danger display-hide">
			<button class="close" data-close="alert"></button>
			表单未能提交，请检查输入项
		</div>
		<div class="portlet box blue">
			<div class="portlet-title">
				<div class="caption">
					<i class="fa fa-edit"></i>货箱列表
				</div>
				<div class="tools">
						
				</div>
			</div>
			<div class="portlet-body">
                

                 <form data-wgt="mw-submit-group mw-edittable" 
                    id="mwFrmList"
                    data-wgt-submit-method="AjaxSubCrate" 
                    <%--data-wgt-submit-options-page="false"--%>
                    <%--data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" --%>
                    data-wgt-submit-options-recall="BOBDCrate.subrecall"
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.DemoBDCrate) %>">

				<div class="table-toolbar">
					<div class="btn-group">
						<button id="sample_editable_1_new" type="button" class="btn green mw-creat">
						添加新货箱 <i class="fa fa-plus"></i>
						</button>
					</div>
						
				</div>
                    <input id="mw-opyCode" submit-group="active" type="hidden" name="opyCode" value="" />
                    <input id="mw-opyType" submit-group="active" type="hidden" name="opyType" value="" />
                   
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
						            <a class="edit" <%--data-wgt="mw-edittable-edit"--%> href="javascript:;">编辑</a>
					            </td>
					            <td >
                                        <% if (item.Status != TblMWCar.STATUS_ENUM_Void) %>
                                    <% { %>
                                        <a href="#" data-wgt="mw-void" data-wgt-code="<% = item.CrateCode %>" class="btn default btn-xs red "><i class="fa fa-edit"></i> 注销</a>
                                    <% } %>
                                    <% if (item.Status == TblMWCar.STATUS_ENUM_Void) %>
                                    <% { %>
                                        <a href="#" data-wgt="mw-active" data-wgt-code="<% = item.CrateCode %>"  class="btn default btn-xs green"><i class="fa fa-edit"></i> 激活</a>
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
							            <a class="edit" <%--data-wgt="mw-edittable-edit"--%> data-mode="save" data-opt="edit" href="">保存</a> 
                                        <a class="cancel" <%--data-wgt="mw-edittable-cancel"--%>  href="">取消</a>
                                        <input type="hidden" name="[empty]optType" submit-group="[empty]save" value="edit" />
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
							            <a class="edit" <%--data-wgt="mw-edittable-edit"--%> data-mode="save" data-opt="new" href="">保存</a> 
                                        <a class="cancel" <%--data-wgt="mw-edittable-cancel"--%> data-mode="new" href="">取消</a>
                                        <input type="hidden" name="[empty1]optType" submit-group="[empty1]save" value="new" />
						            </td>
						            <td>
							
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
<script src="/assets/demobobdcrate.js"></script>
<script src="/assets/wgt-edittable.js"></script>
<script>
    jQuery(document).ready(function () {
        BOBDCrate.init();
        WGTEdtiTable.init();
//        WGTEdtiTable.initOTable = {};
//        $('#mwFrmList').setGroupDebug();
        $('#test').click(function (e) {
            //            $('form').setGroup('1');
            //            window.alert(111);
            //            var json = $('form').serializeGroupJson();
            //            var s = JSON.stringify(json)
            //            window.alert(s); //$.stringifyJSON($('form').serializeJson())
            //            window.alert($('[submit-group="save"]').val());

            //            return;
            $('#mwFrmList').setGroup('save');
            $('#mwFrmList').submit();

            return;
            //.setGroup('save');

            json = $('#mwFrmList').serializeGroupJson();
            $('#mwFrmList').setGroup('1');

            json = $('#mwFrmList').serializeGroupJson();
            //             s = JSON.stringify(json)
            //             window.alert(s); //$.stringifyJSON($('form').serializeJson())

        });
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
