<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="WSManage.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Sys.WSManage" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <!-- begin target bar -->
    <div class="row">
        <div class="col-md-12">
            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
            <h3 class="page-title">
                工作站管理 <small>出入库、处置工作站，手机终端管理</small>
            </h3>
            <ul class="page-breadcrumb breadcrumb">
                <li><i class="fa fa-home"></i><a href="#<% = RedirectHelper.BOMain %>">首页</a> <i
                    class="fa fa-angle-right"></i></li>
                <li>工作站管理</li>

               
            </ul>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
    <div class="clearfix">
    </div>
    <!-- end target bar -->
    <div class="row">
         <div class="col-md-12 ">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="fa fa-reorder"></i>货箱审核列表
                    </div>
                    <div class="tools">
                    <a data-wgt="mw-reload" data-wgt-reload-formid="mwAuthList" href="" class="reload"></a>
                    </div>
                </div>
                <div class="portlet-body ">
                
                <form data-wgt="mw-submit" 
                    id="mwWSList"
                    data-wgt-submit-method="AjaxGetWS" 
                    data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" 
                   <%-- data-wgt-submit-options-recall="CommHelper.recallCarDispatch" --%>
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.WSManage) %>">

                    <uc1:UPage ID="c_UPage" runat="server" />
                  
                </form>

                </div>
            </div>
         </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
<script src="/assets/scripts/table-managed.js"></script>
</asp:Content>
