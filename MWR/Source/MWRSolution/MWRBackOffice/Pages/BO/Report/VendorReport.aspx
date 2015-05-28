<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="VendorReport.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Report.VendorReport" %>
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
		医疗机构库存详情 <small>查看医疗机构库存详情</small>
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
				<i class="fa fa-home"></i>
                <a class="mw-redirect" href="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.IntegratedReport) %>">综合报告</a>
                <i class="fa fa-angle-right"></i>
			</li>
            <li>
				医疗机构库存详情
			</li>
		</ul>
	</div>
</div>
<div class=" row portfolio-block note note-info">
		<div class="col-md-3 ">
			<div class="portfolio-text ">
				<div class="portfolio-info">
					<h4><% = PageVendorNameData %></h4>
					<%--<p>
						<% = PageVendorNameData %>-重量信息
					</p>--%>
				</div>
			</div>
		</div>
		<div class="col-md-8 portfolio-stat " >
			<div class="portfolio-info">
					回收总重量
				<span>
					<% = PageInventoryVendorReportData.RecoWeight%> KG
				</span>
			</div>
			<div class="portfolio-info">
					库存总重量
				<span>
					<% = PageInventoryVendorReportData.InvWeight%> KG
				</span>
			</div>
			<div class="portfolio-info">
					处置总重量
				<span>
					<% = PageInventoryVendorReportData.DestWeight%> KG
				</span>
			</div>
		</div>
	</div>
<div class="row">
    <div class="col-md-12">
	    <!-- BEGIN EXAMPLE TABLE PORTLET-->
	    <div class="portlet box blue">
		    <div class="portlet-title">
			    <div class="caption">
				    <i class="fa fa-globe"></i><% = PageVendorNameData %>-库存废品列表
			    </div>
			   <%-- <div class="tools">
				    <a href="javascript:;" class="reload"></a>
				    <a href="javascript:;" class="remove"></a>
			    </div>--%>
		    </div>
		    <div class="portlet-body">

                <form data-wgt="mw-submit-group" 
                        id="mwFrmList"
                        data-wgt-submit-method="AjaxSub" 
                        <%--data-wgt-submit-options-reload="true" 
                        data-wgt-submit-options-block="true" --%>
                        data-wgt-submit-options-recall="subrecall"
                        action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.VendorReport) %>">
                <input type="hidden" submit-group="common"  name="vendorCode" value="<% = PageVendorCodeData %>" />
			    <table 
                    data-wgt="mw-expandtable-ajaxchild" 
                    data-wgt-submit-url="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.VendorReport) %>" 
                    data-wgt-submit-method="AjaxGetInvTrack" 
                    class="table table-striped table-bordered table-hover" id="sample_1">
			    <thead>
			    <tr>
				    <th>
					    货箱编号
				    </th>
				    <th>
					    仓库编号
				    </th>
				    <th>
					    废料类型
				    </th>
				    <th>
					    回收重量
				    </th>
				    <th>
					    入库重量
				    </th>
                    <th>
					    处置重量
				    </th>
                    <th>
                        入库时间
                    </th>
                    <th>
					    状态
				    </th>
			    </tr>
			    </thead>
			    <tbody>
                    <%
                        foreach (var item in PageInventoryDataList)
	{
                    %>
			    <tr>
				    <td>
					    <% = item.CrateCode %>
                        <input class="mw-invRecodId" name="invRecordId" type="hidden" value="<% = item.InvRecordId %>" />
				    </td>
				    <td>
					    <% = item.DepotCode %>
				    </td>
				    <td>
					    <% = item.Waste %>
				    </td>
				    <td>
					    <% = item.RecoWeight %>
				    </td>
				    <td>
					    <% = item.InvWeight %>
				    </td>
                    <td>
					    <% = item.DestWeight %> 
				    </td>
                    <td>
                        <% =  ComLib.ComFn.DateTimeToString(item.EntryDate, YRKJ.MWR.Business.BizBase.GetInstance().DateTimeFormatString)%>
                    </td>
                    <td>
					    <% = YRKJ.MWR.Business.BizHelper.GetInventoryStatus(item.Status)%>
				    </td>
			    </tr>
                <%
	}
                    %>
			    </tbody>
			    </table>
                <uc1:UPage ID="c_UPage" runat="server" />
                </form>
		    </div>
	    </div>
	    <!-- END EXAMPLE TABLE PORTLET-->
	   
    </div>
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
<script type="text/javascript" src="/assets/plugins/select2/select2.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="/assets/plugins/data-tables/DT_bootstrap.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/vendor/tmpl.min.js"></script>
<script src="/assets/wgt-expandTable.js"></script>
<%--<script src="/assets/bovendorreport.js"></script>--%>
<script>
    jQuery(document).ready(function () {
        //        VendorReport.init();
        initOTable();
        WGTExpandTable.init();
    });
    function initOTable(){
        var oTable = $('#sample_1').dataTable( {
            "aoColumnDefs": [
                {"bSortable": false, "aTargets": [ 0 ] }
            ],
            "bInfo": false, //开关，是否显示表格的一些信息
            "bPaginate": false, //开关，是否显示分页器
            "bLengthChange": false, //开关，是否显示每页大小的下拉框
            "bFilter": false, //开关，是否启用客户端过滤器
            "aaSorting": [[6, 'desc']],
             "aLengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#sample_1').data('mw-oTable',oTable);
    }
    function subrecall(el,d,data){
        initOTable();
    }
</script>

<script id="mw-table-template" type="text/x-tmpl">

<table  class="table table-hover">
    <thead>
    <tr>
        <th>操作员</th>
        <th>操作终端</th>
        <th>操作类型</th>
        <th>操作时间</th>
        <th>操作提交重量</th>
        <th>操作实际重量</th>
        <th>实际重量差值</th>
        <th>是否审核</th>
    </tr>
    </thead>
    <tbody>
{% for (var i=0, d; d=o.data[i]; i++) { %}
    <tr>
        <td>{%=d.EmpyName%}</td>
        <td>{%=d.WSCode %}</td>
        <td>{%=d.TxnType %}</td>
        <td>{%=d.EntryDate %}</td>
        <td>{%=d.SubWeight %} KG</td>
        <td>{%=d.TxnWeight %} KG</td>
        <td>{%=d.DiffWeight %} KG</td>
        <td>
            {% if (d.HasAuthorize) { %}
            是
            {% }else{ %}
            否
            {% } %}
        </td>
    </tr>
{% } %}
    </tbody>
</table>

</script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
