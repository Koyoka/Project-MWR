<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="InvAuthorizeLog.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Inventory.InvAuthorizeLog" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" type="text/css" href="/assets/plugins/select2/select2_metro.css"/>
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
<link href="/assets/css/pages/profile.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		审核日志 <small>查看废品回收、出库、处置审核日志</small>
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
				审核日志
			</li>
		</ul>
	</div>
</div>
<div class="row">
    <div class="col-md-12">
	    <!-- BEGIN EXAMPLE TABLE PORTLET-->
	    <div class="portlet box blue">
		    <div class="portlet-title">
			    <div class="caption">
				    <i class="fa fa-globe"></i>出库日志列表
			    </div>
		    </div>
		    <div class="portlet-body">
                <form data-wgt="mw-submit-group" 
                        id="mwFrmList"
                        data-wgt-submit-method="AjaxSubTxn" 
                        <%--data-wgt-submit-options-reload="true" 
                        data-wgt-submit-options-block="true" --%>
                        data-wgt-submit-options-recall="BODestroyLog.subrecall"
                        action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.InvAuthorizelog) %>">
                <div class="table-toolbar">
					<div class="input-group btn-group pull-right col-md-3">
                        <span class="input-group-btn">
							<button class="btn yellow mw-btn-search-clear" type="button">清空</button>
						</span>
						<input type="text"  class="form-control mw-txt-filterEdit"  value="<% = PageFilterValue %>" />
                        <input type="hidden" submit-group="common search" name="filter" class="form-control mw-txt-filterValue" value="<% = PageFilterValue %>" />
						<span class="input-group-btn">
							<button class="btn blue mw-btn-search"  type="button" >搜索</button>
						</span>
					</div>
				</div>

			    <table data-wgt="mw-expandtable-ajaxchild" 
                    data-wgt-submit-url="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.InvAuthorizelog) %>" 
                    data-wgt-submit-method="AjaxExpandTable" 
                    class="table table-striped table-bordered table-hover" id="sample_1">
			    <thead>
			    <tr>
				    <th>
					    审核交易编号
				    </th>
                    <th>
					    审核交易类型
				    </th>
                     <th>
					    审核货箱编号
				    </th>
				    <th>
					    审核员工
				    </th>
				    <th>
					    提交员工
				    </th>
                    <th>
					    提交终端
				    </th>
                    <th>
					    提交时间
				    </th>
                    <th>
					    完成审核时间
				    </th>
				    <th>
					    提交重量
				    </th>
                    <th>
					    实际重量
				    </th>
                    <th>
					    审核状态
				    </th>
			    </tr>
			    </thead>
			    <tbody>
                    <%
                        foreach (var item in PageInvAuthorizeDataList)
	{
                    %>
                <tr>
                    <td>
					    <a class="mw-redirect" href="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.TxnDetail)%>?txnNum=<% = item.TxnNum %>"><% = item.TxnNum %></a>
                        <input type="hidden" name="invAuthId" value="<% = item.InvAuthId %>" />
                        <input type="hidden" name="txnDetailId" value="<% = item.TxnDetailId %>" />
                        <input type="hidden" id="remark_<% = item.InvAuthId %>" value="<% = item.Remark %>" />
				    </td>
                    <td>
                        <% = YRKJ.MWR.Business.BizHelper.GetTxnDetailTxnType(item.TxnType)%>
				    </td>
				    <td>
					    <% = item.CrateCode %>
				    </td>
                    <td>
					    <% = item.AuthEmpyName %>
				    </td>
                    <td>
					    <% = item.EmpyName %>
				    </td>
                    <td>
					    <% = item.WSCode %>
				    </td>
                    <td>
					     <% = ComLib.ComFn.DateTimeToString(item.EntryDate, YRKJ.MWR.Business.BizBase.GetInstance().DateTimeFormatString)  %>
				    </td>
                    <td>
                        <% = ComLib.ComFn.DateTimeToString(item.CompDate, YRKJ.MWR.Business.BizBase.GetInstance().DateTimeFormatString)%>
				    </td>
				    <td>
					    <% = item.SubWeight %> KG
				    </td>
                    <td>
					    <% = item.TxnWeight %> KG
				    </td>
                    <td>
                        <% = YRKJ.MWR.Business.BizHelper.GetAuthorizeStatus(item.Status)%>
				    </td>
                    
                </tr>
               <%-- <tr>
                    <td colspan="12"> <% = item.Remark %></td>
                </tr>--%>
                <%
	}
                    %>
			    </tbody>
			    </table>
                <uc1:UPage ID="c_UPage" runat="server" />
                </form>
            </div>
	    </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/vendor/tmpl.min.js"></script>
<script src="/assets/wgt-expandTable.js"></script>
<script src="/assets/bodestroylog.js"></script>
<script>
    jQuery(document).ready(function () {
        BODestroyLog.init();
        WGTExpandTable.init();
    });
    var reg = /(\.|\/)(gif|jpe?g|png)/;
    function text(s) {

        var isImg = reg.test(s);
        if (isImg) {
            return "/"+s;
        } else {
            return "/Assets/images/default_thumb.jpg";
        }

    }
    function getRemark(s) {
        return $("#remark_" + s).val();
    }
</script>
<script id="mw-table-template" type="text/x-tmpl">
<table  class="table table-hover">
    <thead>
    <tr>
        <th width="100">所属医院</th>
        <th>废品类型</th>
    </tr>
    </thead>
    <tbody>
{% var d =o.data; %}
    <tr>
        <td>{%=d.Vendor%}</td>
        <td>{%=d.Waste %}</td>
    </tr>
    <tr>
        <td>审核意见</td>
        <td>{%=getRemark(d.InvAuthId)%}</td>
    </tr>
    {% for (var i=0, f; f=d.AttachList[i]; i++) { %}
    <tr>
        <td>附件</td>
        <td> <a href="/{%=f %}" target="_blank"> <img width="50" height=50 src="{%=text(f) %}"></a></td>
    </tr>
    {% } %}

    </tbody>
</table>
</script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
