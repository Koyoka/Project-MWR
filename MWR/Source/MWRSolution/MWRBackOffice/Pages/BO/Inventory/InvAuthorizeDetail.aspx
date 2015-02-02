<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="InvAuthorizeDetail.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Inventory.InvAuthorizeDetail" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="/assets/plugins/jquery-file-upload/css/jquery.fileupload-ui.css" rel="stylesheet">
<link href="/assets/css/pages/profile.css" rel="stylesheet" type="text/css"/>
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
            <li><a href="#<% = RedirectHelper.InvAuthorize %>">货损审核</a> <i class="fa fa-angle-right"></i></li>
            <li>审核详情</li>
        </ul>
        <!-- END PAGE TITLE & BREADCRUMB-->
    </div>
</div>
<div class="clearfix">
</div>
<!-- end target bar -->
<div class="row">
	<div class="col-md-8">
		<div class="booking-search">

			<form id="mwSubAuth" role="form"
                data-wgt="mw-submit" 
                data-wgt-submit-method="AjaxSubAuthorize" 
                data-wgt-submit-options-reload="false" 
                data-wgt-submit-options-block="true" 
                data-wgt-submit-options-recall="CommHelper.subAuthorize"
                data-wgt-submit-options-start="CommHelper.validAuthorize"
                action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.InvAuthorizeDetail) %>" >
                <div class="form-body">                    <div class="alert alert-danger display-hide">
					    <button class="close" data-close="alert"></button>
					    表单未能提交，请检查输入项
				    </div>
				    <%--<div class="alert alert-success display-hide">
					    <button class="close" data-close="alert"></button>
					    Your form validation is successful!
				    </div>--%>
				    <div class="row form-group">
					    <div class="col-md-12">
						    <label class="control-label">审核意见</label>
						    <div class="input-icon">
							    <i class="fa fa-map-marker"></i>
                                <input type="hidden" name="invAuthId" value="<% = PageAuthData.InvAuthId %>" />
                            
							    <input name="remark" maxlength="<% = YRKJ.MWR.TblMWInvAuthorize.getRemarkColumn().ColumnSize %>" class="form-control" type="text" placeholder="请输入货箱缺损说明...">
						    </div>
					    </div>
				    </div>
				    <div class="row form-group">
					    <div class="col-md-6">
						    <label class="control-label">交易编号:</label>
						    <div class="input-icon">
							    <i class="fa fa-calendar"></i>
							    <input  class="form-control" disabled="" size="16" type="text" value="<% = PageAuthData.TxnNum %>" />
						    </div>
					    </div>
					    <div class="col-md-6">
						    <label class="control-label">提交时间</label>
						    <div class="input-icon">
							    <i class="fa fa-calendar"></i>
							    <input class="form-control"  disabled="" size="16" type="text" value="<% = ComLib.ComFn.DateTimeToString(PageAuthData.EntryDate,YRKJ.MWR.Business.BizBase.GetInstance().DateTimeFormatString) %>" />
						    </div>
					    </div>
				    </div>
				    <div class="row form-group">
					    <div class="col-md-6">
						    <label class="control-label">提交工作站</label>
						    <div class="input-icon">
							    <i class="fa fa-user"></i>
							    <input class="form-control"  disabled="" size="16" type="text" value="<% = PageAuthData.WSCode %>" />
						    </div>
					    </div>
					    <div class="col-md-6">
						    <label class="control-list">提交操作员</label>
						    <div class="input-icon">
							    <i class="fa fa-user"></i>
							    <input class="form-control" size="16" disabled="" type="text" value="<% = PageAuthData.EmpyName %>" />
						    </div>
					    </div>
				    </div>
				    <button class="btn green btn-block margin-top-20">审核通过 <i class="m-icon-swapright m-icon-white"></i></button>
                </div>
			</form>
		</div>
	</div>
	<!--end booking-search-->
	<div class="col-md-4">
	    <div class="portlet sale-summary">
				<div class="portlet-title">
					<div class="caption">
						货箱信息
					</div>
					<%--<div class="tools">
						<a class="reload" href="javascript:;"></a>
					</div>--%>
				</div>
				<div class="portlet-body">
					<ul class="list-unstyled">
						<li>
							<span class="sale-info">
								货箱编号 <i class="fa fa-img-up"></i>
							</span>
							<span class="sale-num">
								<% = PageAuthData.CrateCode %>
							</span>
						</li>
						<li>
							<span class="sale-info">
								提交重量 <i class="fa fa-img-down"></i>
							</span>
							<span class="sale-num">
								<% = PageAuthData.SubWeight.ToString(YRKJ.MWR.Business.BizBase.GetInstance().DecimalFormatString) + " " + SysParams.GetInstance().GetSysWeightUnit()%>
							</span>
						</li>
						<li>
							<span class="sale-info">
								校验重量
							</span>
							<span class="sale-num">
								<% = PageAuthData.TxnWeight.ToString(YRKJ.MWR.Business.BizBase.GetInstance().DecimalFormatString) + " " + SysParams.GetInstance().GetSysWeightUnit()%>
							</span>
						</li>
						<li >
							<span class="sale-info">
								数量差值
							</span>
							<span class="sale-num">
								<% = PageAuthData.DiffWeight.ToString(YRKJ.MWR.Business.BizBase.GetInstance().DecimalFormatString) + " " + SysParams.GetInstance().GetSysWeightUnit() %>
							</span>
						</li>
					</ul>
				</div>
			</div>
	</div>
	<!--end col-md-4-->
</div>
<div class="clearfix">
</div>
<div class="row margin-top-20"  id="fileupload">
    
        <div class="col-md-12">
            <div>
                <form  method="post" enctype="multipart/form-data">
                <input type="hidden" name="action" value="authoize" />
                <input type="hidden" name="txnNum" value="<% = PageAuthData.TxnNum %>" />
                <input type="hidden" name="crateCode" value="<% = PageAuthData.CrateCode %>" />
                <input type="hidden" name="invauthid" value="<% = PageAuthData.InvAuthId%>" />
                <div class="fileupload-buttonbar">
                    <span class="btn green fileinput-button">
					    <i class="fa fa-plus"></i>
					    <span>
						    添加附件...
					    </span>
					    <input type="file" name="files[]" multiple="" />
				    </span>
                    <button type="submit" class="btn blue start">
				        <i class="fa fa-upload"></i>
				        <span>
					        开始上传
				        </span>
				    </button>
                    <%--<button type="submit" class="start">
				        Start upload
			        </button>--%>
                    <%--<button type="button" class="btn red delete">
						<i class="fa fa-trash-o"></i>
						<span>
							删除所有
						</span>
					</button>--%>
                   <button type="button" class="btn red delete">
					<i class="fa fa-trash-o"></i>
					<span>
						删除所有
					</span>
					</button>
					<input type="checkbox" class="toggle" />
                    <span class="fileupload-loading">
					</span>
                   <%-- <label class="fileinput-button">
                        <span>Add files...</span>
                        <input type="file" name="files[]" multiple="multiple" />
                    </label>

                    <button type="submit" class="start">
				        Start upload
			        </button>

                    <button type="button" class="delete button">Delete all files</button>

			        --%>
                </div>
                </form>
            </div>
        </div>
        <div class="col-md-12 ">
        <div class="col-md-12 fileupload-progress fade">
			<!-- The global progress bar -->
			<div class="progress progress-striped active" role="progressbar" aria-valuemin="0" aria-valuemax="100">
				<div class="progress-bar progress-bar-success" style="width:0%;">
				</div>
			</div>
			<!-- The extended global progress information -->
			<div class="progress-extended">
				&nbsp;
			</div>
		</div>
        <%--<span class="fileupload-loading" style="border:1px solid red;">1
								</span>--%>
         <%-- <div class="progress fileupload-progressbar" style="display:none;">
	        <div class="progress-bar progress-bar-success  " role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 0%">
		        <span class="sr-only" >
			       
		        </span>
	        </div>
        </div>--%>
        </div>
        <div class="col-md-12">
            <table role="presentation" class="table table-striped clearfix">
			<tbody class="files">
			</tbody>
			</table>
        </div>
    
</div>

<%--<script id="template-upload" type="text/x-jquery-tmpl">
    <tr class="template-upload{{if error}} ui-state-error{{/if}}">
        <td class="preview"></td>
        <td class="name">${name}  
                
        </td>
        <td class="size">${sizef}</td>
        {{if error}}
            <td class="error" colspan="2">Error:
                {{if error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="" style="">
            <div class="progress progress-striped active" style="display:none;width:300px;" >
				<div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 0%;">
					<span class="sr-only">
						40% Complete (success)
					</span>
				</div>
			</div>
            </td>
            <td class="start">
                <button type="button" class="btn blue">
				    <i class="fa fa-upload"></i>
				    <span>
					    上传
				    </span>
				</button>
            </td>
        {{/if}}
        <td class="cancel">
            <button type="reset" class="btn yellow">
			<i class="fa fa-ban"></i>
			<span>
				取消
			</span>
			</button>
        </td>
    </tr>
</script>
<script id="template-download" type="text/x-jquery-tmpl">
    <tr class="template-download{{if error}} ui-state-error{{/if}}">
        {{if error}}
            <td></td>
            <td class="name">${name}</td>
            <td class="size">${sizef}</td>
            <td class="error" colspan="2">Error:
                {{if error === 1}}File exceeds upload_max_filesize (php.ini directive)
                {{else error === 2}}File exceeds MAX_FILE_SIZE (HTML form directive)
                {{else error === 3}}File was only partially uploaded
                {{else error === 4}}No File was uploaded
                {{else error === 5}}Missing a temporary folder
                {{else error === 6}}Failed to write file to disk
                {{else error === 7}}File upload stopped by extension
                {{else error === 'maxFileSize'}}File is too big
                {{else error === 'minFileSize'}}File is too small
                {{else error === 'acceptFileTypes'}}Filetype not allowed
                {{else error === 'maxNumberOfFiles'}}Max number of files exceeded
                {{else error === 'uploadedBytes'}}Uploaded bytes exceed file size
                {{else error === 'emptyResult'}}Empty file upload result
                {{else}}${error}
                {{/if}}
            </td>
        {{else}}
            <td class="preview">
                {{if thumbnail_url}}
                    <a href="${url}" target="_blank"><img height="40" wight="80" src="${thumbnail_url}"></a>
                {{/if}}
            </td>
            <td class="name">
                <a href="${url}"{{if thumbnail_url}} target="_blank"{{/if}}>${name}</a>
            </td>
            <td class="size">${sizef}</td>
            <td colspan="2"></td>
        {{/if}}
        <td class="delete">
            <button type="button" class="btn red delete" data-type="${delete_type}" data-url="${delete_url}">
                 <i class="fa fa-trash-o"></i>
                <span>
	                删除
                </span>
            </button>
            
        </td>
    </tr>
</script>
--%>

<script id="template-upload" type="text/x-tmpl">
{% for (var i=0, file; file=o.files[i]; i++) { %}
    <tr class="template-upload fade">
        <td>
            <span class="preview"></span>
        </td>
        <td>
            <p class="name">{%=file.name%}</p>
            {% if (file.error) { %}
                <div><span class="label label-danger">Error</span> {%=file.error%}</div>
            {% } %}
        </td>
        <td>
            <p class="size">{%=o.formatFileSize(file.size)%}</p>
            {% if (!o.files.error) { %}
                <div class="progress progress-striped active" role="progressbar" aria-valuemin="0" aria-valuemax="100" aria-valuenow="0">
                <div class="progress-bar progress-bar-success" style="width:0%;"></div>
                </div>
            {% } %}
        </td>
        <td>
            {% if (!o.files.error && !i && !o.options.autoUpload) { %}
                <button class="btn blue start">
                    <i class="fa fa-upload"></i>
                    <span>上传</span>
                </button>
            {% } %}
            {% if (!i) { %}
                <button class="btn yellow cancel">
                    <i class="fa fa-ban"></i>
                    <span>取消</span>
                </button>
            {% } %}
        </td>
    </tr>
{% } %}
</script>
<!-- The template to display files available for download -->
<script id="template-download" type="text/x-tmpl">
{% for (var i=0, file; file=o.files[i]; i++) { %}
    <tr class="template-download fade">
        <td>
            <span class="preview">
                {% if (file.thumbnail_url) { %}
                    <a href="{%=file.url%}" title="{%=file.name%}" download="{%=file.name%}" data-gallery><img height="40" weight="80" src="{%=file.thumbnail_url%}"></a>
                {% } %}
            </span>
        </td>
        <td>
            <p class="name">
                {% if (file.url) { %}
                    <a href="{%=file.url%}" title="{%=file.name%}" download="{%=file.name%}" {%=file.thumbnailUrl?'data-gallery':''%}>{%=file.name%}</a>
                {% } else { %}
                    <span>{%=file.name%}</span>
                {% } %}
            </p>
            {% if (file.error) { %}
                <div><span class="label label-danger">Error</span> {%=file.error%}</div>
            {% } %}
        </td>
        <td>
            <span class="size">{%=o.formatFileSize(file.size)%}</span>
        </td>
        <td>
            {% if (file.delete_url) { %}
                <button class="btn red delete" data-type="{%=file.delete_type%}" data-url="{%=file.delete_url%}"{% if (file.deleteWithCredentials) { %} data-xhr-fields='{"withCredentials":true}'{% } %}>
                    <i class="fa fa-trash-o"></i>
                    <span>删除</span>
                </button>
                <input type="checkbox" name="delete" value="1" class="toggle">
            {% } else { %}
                <button class="btn yellow cancel">
                    <i class="fa fa-ban"></i>
                    <span>取消</span>
                </button>
            {% } %}
        </td>
    </tr>
{% } %}
</script>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">

<script src="/assets/plugins/jquery-file-upload/js/vendor/jquery.ui.widget.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/vendor/tmpl.min.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/vendor/load-image.min.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/vendor/canvas-to-blob.min.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/jquery.iframe-transport.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-process.js"></script>
<%--<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-image.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-audio.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-video.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-validate.js"></script>--%>
<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-ui.js"></script>

<script type="text/javascript" src="/assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
<script type="text/javascript" src="/assets/plugins/jquery-validation/dist/additional-methods.min.js"></script><%--<script type="text/javascript" src="/assets/plugins/jquery-validation/localization/messages_zh.js"></script>--%>
<script src="/assets/boinvauthorizedetail.js"></script>
<script type="text/javascript">
    jQuery(document).ready(function () {
        InvAuthHelper.init();
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
