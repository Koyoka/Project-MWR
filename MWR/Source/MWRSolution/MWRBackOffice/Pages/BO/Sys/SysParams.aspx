<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="SysParams.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Sys.SysParams" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Import Namespace="YRKJ.MWR.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link rel="stylesheet" type="text/css" href="/assets/plugins/bootstrap-switch/static/stylesheets/bootstrap-switch-metro.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<!-- BEGIN PAGE TITLE & BREADCRUMB-->
		<h3 class="page-title">
		参数设置 <small>系统参数管理</small>
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
				参数设置
			</li>
		</ul>
		<!-- END PAGE TITLE & BREADCRUMB-->
	</div>
</div>

<div class="row">
	<div class="col-md-12">
		<div class="tab-pane" id="tab_1">
			<div class="portlet box blue">
				<div class="portlet-title">
					<div class="caption">
						<i class="fa fa-reorder"></i>参数设置
					</div>
					<div class="tools">
						<a href="javascript:;" class="collapse"></a>
						<a href="#portlet-config" data-toggle="modal" class="config"></a>
						<a href="javascript:;" class="reload"></a>
						<a href="javascript:;" class="remove"></a>
					</div>
				</div>
				<div class="portlet-body form">
					<!-- BEGIN FORM-->
					<form 
                        id="mwFrm" 
                        data-wgt="mw-submit" 
                        data-wgt-submit-method="AjaxFormSub" 
                        data-wgt-submit-options-recall="subRecall"
                        data-wgt-submit-options-reload="false" 
                        action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.SysParams) %>"  >
                       
						<div class="form-body">
							<h3 class="form-section">通用参数</h3>
							<div class="row">
								<div class="col-md-6">
									<div class="form-group">
										<label class="control-label">货箱二维码格式</label>
										<input type="text" id="crateCode" name="crateCode" class="form-control" placeholder="请输入货箱二维码格式"  
                                        maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>"  
                                        value="<% = MWParams.GetCrateCodeMask() %>" />
										<span class="help-block">
											#：数字 @：字符 <br/>例：HX@###,共6位，HX为开头2位字符，3位为[A-Z,a-z]字符，后3位为数字 
										</span>
									</div>
								</div>
								<!--/span-->
							<%--	<div class="col-md-6">
									<div class="form-group ">
										<label class="control-label">系统使用单位</label>
										<%--<input type="text"  data-mask="mask_decime" class="form-control" placeholder="请输入系统使用单位" 
                                        maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>"  
                                        value="<% = MWParams.GetWeightUnit() %>" />
                                       div class="radio-list">
											<label class="radio-inline">
											<input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked> 千克 [kg] </label>
											<label class="radio-inline">
											<input type="radio" name="optionsRadios" id="optionsRadios2" value="option2"> 克 [g] </label>
                                            <label class="radio-inline">
											<input type="radio" name="optionsRadios" id="Radio1" value="option2"> 吨 [t] </label>
										</div>
                                        <div class="clearfix">
								            <div class="btn-group" data-toggle="buttons">
									            <label class="btn blue">
									            <input type="radio" class="toggle"> 千克 [kg] </label>
									            <label class="btn blue">
									            <input type="radio" class="toggle"> &nbsp;克 [g] </label>
									            <label class="btn blue active">
									            <input type="radio" class="toggle">  &nbsp;吨 [t] </label>
								            </div>
							            </div>
										<span class="help-block">
											系统使用重量单位
										</span>
									</div>
								</div>--%>
								<!--/span-->
							</div>
							<!--/row-->
							<div class="row">
								<div class="col-md-6">
									<div class="form-group">
										<label class="control-label">使用通用重量差值</label>
                                        <div>
										    <div class="make-switch " data-on-label="是" data-off-label="否" data-on="success"  data-off="danger">
											    <input type="checkbox" id="allowDiffWeightAsIdentical" name="allowDiffWeightAsIdentical"  <% = MWParams.GetAllowDiffWeightAsIdentical()?"checked":"" %> value="1" class="toggle" />
										    </div>                                        </div>
										<span class="help-block">
											如果打开，各个工作站在回收、出库、处置时，将使用【通用重量差值】来校验货箱重量
										</span>
									</div>
								</div>
                                <div class="col-md-6">
									<div class="form-group ">
										<label class="control-label">通用重量差值</label>
										<input type="text" id="allowDiffWeight_All" name="allowDiffWeight_All"  data-mask="mask_decime" class="form-control" placeholder="请输入数量差值"
                                        maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>"  
                                        value="<% = MWParams.GetAllowDiffWeight_All() %>" />
										<span class="help-block">
											回收、出库、处置时校验货箱允许的重量差值
										</span>
									</div>
								</div>
								<!--/span-->
								<%--<div class="col-md-6">
									<div class="form-group">
										<label class="control-label">Date of Birth</label>
										<input type="text" class="form-control" placeholder="dd/mm/yyyy">
									</div>
								</div>--%>
								<!--/span-->
							</div>
							<!--/row-->
						<%--	<div class="row">
								<div class="col-md-6">
									<div class="form-group">
										<label class="control-label">Category</label>
										<select class="select2_category form-control" data-placeholder="Choose a Category" tabindex="1">
											<option value="Category 1">Category 1</option>
											<option value="Category 2">Category 2</option>
											<option value="Category 3">Category 5</option>
											<option value="Category 4">Category 4</option>
										</select>
									</div>
								</div>
								<!--/span-->
								<div class="col-md-6">
									<div class="form-group">
										<label class="control-label">Membership</label>
										<div class="radio-list">
											<label class="radio-inline">
											<input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked> Option 1 </label>
											<label class="radio-inline">
											<input type="radio" name="optionsRadios" id="optionsRadios2" value="option2"> Option 2 </label>
										</div>
									</div>
								</div>
								<!--/span-->
							</div>--%>
							<!--/row-->
							<h3 class="form-section">工作站参数</h3>
							<div class="row">
								<div class="col-md-6 ">
									<div class="form-group">
										<label class="control-label">回收重量差值</label>
										<input type="text" id="allowDiffWeight_Recover" name="allowDiffWeight_Recover"  data-mask="mask_decime" class="form-control" placeholder="请回收输入数量差值" 
                                        maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>"  
                                        value="<% = MWParams.GetAllowDiffWeight_Recover() %>" />
                                         <span class="help-block">
											回收时校验货箱允许的重量差值
									    </span>
									</div>
                                   
								</div>
                                <div class="col-md-6 ">
									<div class="form-group">
										<label class="control-label">出库重量差值</label>
										<input type="text" id="allowDiffWeight_Post" name="allowDiffWeight_Post"  data-mask="mask_decime" class="form-control" placeholder="请输入出库数量差值" 
                                        maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>"  
                                        value="<% = MWParams.GetAllowDiffWeight_Post() %>" />
                                         <span class="help-block">
											出库时校验货箱允许的重量差值
									    </span>
									</div>
                                   
								</div>
							</div>
							<div class="row">
								<div class="col-md-6 ">
									<div class="form-group">
										<label class="control-label">处置重量差值</label>
										<input type="text" id="allowDiffWeight_Destory" name="allowDiffWeight_Destory"  data-mask="mask_decime" class="form-control" placeholder="请输入处置数量差值" 
                                        maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>"  
                                        value="<% = MWParams.GetAllowDiffWeight_Destory() %>" />
                                         <span class="help-block">
											处置时校验货箱允许的重量差值
									    </span>
									</div>
                                   
								</div>
								<!--/span-->
                                <div class="col-md-6">
									<div class="form-group">
										<label class="control-label">处置工作站残渣管理</label>
                                        <div>
										    <div class="make-switch " data-on-label="打开" data-off-label="关闭" data-on="success"  data-off="danger">
											    <input type="checkbox"  id="isResidueFunction" name="isResidueFunction" <% = MWParams.GetIsResidueFunction()?"checked":"" %> value="1" class="toggle"
                                                maxlength="<% = YRKJ.MWR.TblSysParameter.getParameterValueColumn().ColumnSize %>" />
										    </div>                                        </div>
										<span class="help-block">
											如果打开，处置工作站将出现残渣管理功能
										</span>
									</div>
								</div>
								<%--<div class="col-md-6">
									<div class="form-group">
										<label>State</label>
										<input type="text" class="form-control">
									</div>
								</div>--%>
								<!--/span-->
							</div>
							<!--/row-->
							<%--<div class="row">
								<div class="col-md-6">
									<div class="form-group">
										<label>Post Code</label>
										<input type="text" class="form-control">
									</div>
								</div>
								<!--/span-->
								<div class="col-md-6">
									<div class="form-group">
										<label>Country</label>
										<select class="form-control">
										</select>
									</div>
								</div>
								<!--/span-->
							</div>--%>
						</div>
						<div class="form-actions right">
							
							<button type="button" id="btnSub" class="btn blue"><i class="fa fa-check"></i> Save</button>
						</div>
					</form>
					<!-- END FORM-->
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">

<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script src="/assets/plugins/bootstrap-switch/static/js/bootstrap-switch.min.js" type="text/javascript"></script>

<script type="text/javascript" src="/assets/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"></script>
<script>
//    jQuery.fn.extend({
//        serialize: function () {
//            return jQuery.param(this.serializeArray());
//        },
//        serializeArray: function () {
//            return this.map(function () {
//                // Can add propHook for "elements" to filter or add form elements
//                var elements = jQuery.prop(this, "elements");
//                return elements ? jQuery.makeArray(elements) : this;
//            })
//		.filter(function () {
//		    var type = this.type;
//		    // Use .is(":disabled") so that fieldset[disabled] works
//		    return this.name && !jQuery(this).is(":disabled") &&
//				rsubmittable.test(this.nodeName) && !rsubmitterTypes.test(type) &&
//				(this.checked || !rcheckableType.test(type));
//		})
//		.map(function (i, elem) {
//		    var val = jQuery(this).val();

//		    return val == null ?
//				null :
//				jQuery.isArray(val) ?
//					jQuery.map(val, function (val) {
//					    return { name: elem.name, value: val.replace(rCRLF, "\r\n") };
//					}) :
//					{ name: elem.name, value: val.replace(rCRLF, "\r\n") };
//		}).get();
//        }
//    });
   

    function subRecall(el, d, data) {
        Modal.alert('修改成功,请重启工作站才能应用参数。');
    }
    jQuery(document).ready(function () {
        //       $("#mask_number").inputmask({
        //            "mask": "9",
        //            "repeat": 10,
        //            "greedy": false
        //        });]
        //data-mask="mask_decime"
        $('#btnSub').click(function (e) {
                        $('#mwFrm').submit();
            //            window.alert($('input[name]', 'form').length);
            //            var elements = jQuery.prop($('form'), "elements");
            //            jQuery.fn.serializeArray.filter(function () {
            //		        var type = this.type;
            //		        // Use .is(":disabled") so that fieldset[disabled] works
            //		        return this.name && !jQuery(this).is(":disabled") &&
            //				    rsubmittable.test(this.nodeName) && !rsubmitterTypes.test(type) &&
            //				    (this.checked || !manipulation_rcheckableType.test(type));
            ////		    })
           
//            var json = $('form').cc();
//            window.alert(JSON.stringify(json));
//            return;
            //            var jj = {};
            //            jj['name'] = "eleven";
            //            jj['value'] = "ok";
            //            json.push(jj);
            //            window.alert(JSON.stringify(json));
//            var arry = new Array();
//            for (var i = 0, item; i < $('input[name]', 'form').length; i++) {
//                item = $('input[name]', 'form').eq(i);
//                //                window.alert(item.val() + " " + item.attr('name'));
//                var defineJson = {};
//                defineJson['name'] = item.attr('name');
//                defineJson['value'] = item.val();
//                arry.push(defineJson);

//            }
//            window.alert(JSON.stringify(arry));
//            var dj = $.extend(json, arry);
//            window.alert(JSON.stringify(dj));
            //            var ops = {
            //                msg: "提示内容",
            //                title: "消息",
            //                btnok: "确定",
            //                btncl: "取消"
            //            };

            //            $.extend(ops, options);
        });

        $('[data-mask="mask_decime"]').inputmask('decimal', {
            rightAlignNumerics: false
        });
        //        $("#mask_number").inputmask('decimal', {
        //            rightAlignNumerics: false
        //        });
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
