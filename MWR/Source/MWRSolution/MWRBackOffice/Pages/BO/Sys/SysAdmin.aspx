<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="SysAdmin.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Sys.SysAdmin" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<!-- BEGIN PAGE TITLE & BREADCRUMB-->
		<h3 class="page-title">
		超级管理员 <small>超级管理员账号管理</small>
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
				超级管理员
			</li>
		</ul>
		<!-- END PAGE TITLE & BREADCRUMB-->
	</div>
</div>
<div class="row">	
    <div class="col-md-12">

	<div class="portlet box green">
		<div class="portlet-title">
			<div class="caption">
				<i class="fa fa-reorder"></i>超级管理员
			</div>
			<%--<div class="tools">
				<a href="javascript:;" class="collapse"></a>
				<a href="#portlet-config" data-toggle="modal" class="config"></a>
				<a href="javascript:;" class="reload"></a>
				<a href="javascript:;" class="remove"></a>
			</div>--%>
		</div>
		<div class="portlet-body form">
			<!-- BEGIN FORM-->
			<form 
                id="mwFrm" 
                data-wgt="mw-submit" 
                data-wgt-submit-method="AjaxFormSub" 
                data-wgt-submit-options-recall="subRecall"
                data-wgt-submit-options-reload="false" 
                action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.SysAdmin) %>"  class="form-horizontal">
				<div class="form-body">
                    <div class="form-group ">
						<label class="col-md-3 control-label">账号</label>
						<div class="col-md-4">
							<p class="form-control-static">
								<% = PageAdministratorAccount %>
							</p>
						</div>
					</div>
                    <div class="form-group">
						<label class="col-md-3 control-label">旧密码</label>
						<div class="col-md-4">
								<input type="password" id="oldAdminPassword" name="oldAdminPassword" maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>" class="form-control" placeholder="请输入旧的密码" />
						</div>
					</div>
					<div class="form-group">
						<label class="col-md-3 control-label">新密码</label>
						<div class="col-md-4">
							<input type="password" id="newAdminPassword" name="newAdminPassword" maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>" class="form-control" placeholder="请输入新的密码" />
							
						</div>
					</div>
					<div class="form-group last">
						<label class="col-md-3 control-label">重复新密码</label>
						<div class="col-md-4">
								<input type="password" id="confirmAdminPassword" name="confirmAdminPassword" maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>" class="form-control" placeholder="再次输入新的密码" />
						</div>
					</div>
					
					<%--<div class="form-group">
						<label class="col-md-3 control-label">Left Icon</label>
						<div class="col-md-4">
							<div class="input-icon">
								<i class="fa fa-bell-o"></i>
								<input type="text" class="form-control" placeholder="Left icon">
							</div>
						</div>
					</div>
					<div class="form-group">
						<label class="col-md-3 control-label">Right Icon</label>
						<div class="col-md-4">
							<div class="input-icon right">
								<i class="fa fa-microphone"></i>
								<input type="text" class="form-control" placeholder="Right icon">
							</div>
						</div>
					</div>
					<div class="form-group">
						<label class="col-md-3 control-label">Input With Spinner</label>
						<div class="col-md-4">
							<input type="password" class="form-control spinner" placeholder="Password">
						</div>
					</div>
					<div class="form-group last">
						<label class="col-md-3 control-label">Static Control</label>
						<div class="col-md-4">
							<p class="form-control-static">
								email@example.com
							</p>
						</div>
					</div>--%>
				</div>
				<div class="form-actions fluid">
					<div class="col-md-offset-3 col-md-9">
						<button id="btnSub" type="button" class="btn blue">提交</button>
						<button id="btnReset" type="button" class="btn default">重置</button>
					</div>
				</div>
			</form>
			<!-- END FORM-->
		</div>
	</div>
    </div>
</div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script type="text/javascript" src="/assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
<script>
    var initFrmValid = function () {
        var error1 = $('.alert-danger');
        $('#mwFrm').validate({
            errorElement: 'span', 
            errorClass: 'help-block', 
            focusInvalid: true, 
            ignore: "",
            rules: {
                oldAdminPassword: {
                    required: true
                },
                newAdminPassword: {
                    required: true
                },
                confirmAdminPassword: {
                    required: true,
                    equalTo: "#newAdminPassword"
                }
            },
            messages: {
                oldAdminPassword: "请输入旧的密码",
                newAdminPassword: "请输入新的密码",
                confirmAdminPassword: {
                    required: "请输入重复新的密码",
                    equalTo:"重复新的密码不同"
                }
            },
            invalidHandler: function (event, validator) {          
                error1.show();
//                App.scrollTo(error1, -200);
            },
            highlight: function (element) { 
                $(element)
                        .closest('.form-group').addClass('has-error'); 
            },
            unhighlight: function (element) { 
                $(element)
                        .closest('.form-group').removeClass('has-error');
            },
            success: function (label) {
                label
                        .closest('.form-group').removeClass('has-error'); 
            },
            submitHandler: function (form) {
                error1.hide();
            }
        });
    };
    function subRecall(el, d, data) {
        Modal.alert('修改成功。');
    }
    jQuery(document).ready(function () {
        initFrmValid();
        $('#btnSub').click(function (e) {
            $('#mwFrm').submit();
        });
        $('#btnReset').click(function (e) {
            $('input', '#mwFrm').val('');
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
