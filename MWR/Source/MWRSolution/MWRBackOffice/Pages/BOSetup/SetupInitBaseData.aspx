<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="SetupInitBaseData.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BOSetup.SetupInitBaseData" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/assets/plugins/select2/select2_metro.css">
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
<link href="/assets/plugins/jquery-file-upload/css/jquery.fileupload-ui.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="note note-success">
	<p>
        系统使用基础数据设置。模板请于<a href="<% = WebAppFn.GetBoFullPageUrl("Sys/1.xlsx") %>">这里</a>下载  
	</p>
</div>

<div class="row">
    <div class="table-toolbar col-md-12">
     <div class="btn-group">
            <span class="btn green fileinput-button">
                <span>
					上传模板
				</span>
				<i class="fa fa-plus"></i>
				
				<input id="fileupload" type="file" name="files[]" multiple="" />
			</span>
	    </div>
       
	    <div class="btn-group pull-right">
            <form role="form"
                id="mwFrmImport" 
                data-wgt="mw-submit" 
                data-wgt-submit-method="AjaxImportInitData" 
                data-wgt-submit-options-reload="false" 
                data-wgt-submit-options-block="false" 
                data-wgt-submit-options-recall="recallImport"
                action="<% = WebAppFn.GetBoSetupFullPageUrl(RedirectHelper.SetupInitBaseData) %>" class="">
                <button data-wgt="mw-submitImportAll" id="mw-importInitData" type="button" class="btn blue disabled">
		        <i class="fa fa-reply-all"></i> 导入完成 
		        </button>
                <input id="mw-importFileName" type="hidden" name="fileName" value="" />
                <input id="mw-importDataName" type="hidden" name="dataName" value="" />
            </form>
		    <%--<button class="btn dropdown-toggle" data-toggle="dropdown">Tools <i class="fa fa-angle-down"></i>
		    </button>
		    <ul class="dropdown-menu pull-right">
			    <li>
				    <a href="#">Print</a>
			    </li>
			    <li>
				    <a href="#">Save as PDF</a>
			    </li>
			    <li>
				    <a href="#">Export to Excel</a>
			    </li>
		    </ul>--%>
	    </div>
    </div>       
</div> 
<div class="row  col-md-12">
<div class="progress progress-striped active">
			<div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width: 0%">
				<span class="sr-only">
					40% Complete (success)
				</span>
			</div>
		</div>
</div>
 
<div id="mw-initData">
<%
    if (PageInitGroupDataList.Count > 0)
    { 
     %>


    <div class="row">
	    <div class="col-md-12">
            <%
               
                foreach (var item in PageInitGroupDataList)
	{
            %>
           
		    <div class="portlet ">
			    <div class="portlet-title">
				    <div class="caption">
					    <i class="fa fa-globe"></i><% = item.GroupName %>
				    </div>
				    <div class="tools">
					    <a href="javascript:;" class="collapse"></a>
					    <%--<a href="#portlet-config" data-toggle="modal" class="config"></a>
					    <a href="javascript:;" class="reload"></a>
					    <a href="javascript:;" class="remove"></a>--%>
				    </div>
                  
			    </div>
			    <div class="portlet-body">
                    <table class="table table-striped table-bordered table-hover" id="sample_1">
				<thead>
				<tr>
					<th width="35">
						
					</th>
					<th>
						<% = item.title1 %>
					</th>
					<th>
						<% = item.title2 %>
					</th>
					<th>
						<% = item.title3 %>
					</th>
					<%--<th>
						Joined
					</th>
					<th>
						&nbsp;
					</th>--%>
				</tr>
				</thead>
				<tbody>
                    <%
                        int i = 0;
	foreach (var cldItem in item.dataList)
	{
        i++;
                    %>
				<tr class="odd gradeX">
					<td>
						<% = i+""%>
					</td>
					<td>
						<% = cldItem.code %>
					</td>
					<td>
						<% = cldItem.desc1 %>
					</td>
					<td>
						<% = cldItem.desc2 %>
					</td>
					<%--<td class="center">
						12 Jan 2012
					</td>
					<td>
						<span class="label label-sm label-success">
							Approved
						</span>
					</td>--%>
				</tr>
                 <%
	}
                    %>
				
				</tbody>
				</table>
			    </div>
		    </div>
	     <%
	}
            %>
        
        </div>
    </div>

<%
    }
     %>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<%--<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload.js"></script>--%>
<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/jquery.dataTables.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>
<script src="/assets/scripts/table-managed.js"></script>



<script src="/assets/bosysinit.js"></script>
<script>
    function recallImport(el, netData, locData) {
        window.parent['SetupIndexHelper'].NextStep();
    }
    jQuery(document).ready(function () {
        SysInitHelper.init('<% = WebAppFn.GetBoSetupFullPageUrl(RedirectHelper.SetupInitBaseData) %>');
    });
</script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
