<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOEmpty.Master" AutoEventWireup="true" CodeBehind="BDVendor.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.BaseData.BDVendor" %>
<%@ Import Namespace="YRKJ.MWR" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<%@ Register src="../../UCtrl/UPage.ascx" tagname="UPage" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="/assets/plugins/data-tables/DT_bootstrap.css"/>
<link href="/assets/plugins/bootstrap-modal/css/bootstrap-modal-bs3patch.css" rel="stylesheet" type="text/css"/>
<link href="/assets/plugins/bootstrap-modal/css/bootstrap-modal.css" rel="stylesheet" type="text/css"/><style>
    #allmap11{width:100%;height:500px;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
<%--<a class="btn default" data-target="#baidumap" data-toggle="modal">View Demo</a>--%>
<div id="baidumap" class="modal container fade" tabindex="-1" data-backdrop="static" data-keyboard="false" data-attention-animation="false">
 <%--   <div class="modal-dialog">
			<div class="modal-content">--%>
	            <div class="modal-body"  >
		            <p>
			            请从地图中选取地点坐标！<input type="text" value="" readonly id="mwTxtVendorAddress" />
		            </p>
                    <div id="allmap" style="width:100%;height:500px;">123123</div>
	            </div>
	<div class="modal-footer">
		<button type="button" data-dismiss="modal" class="btn btn-default">关闭</button>
		<button id="btnOK" type="button" data-dismiss="modal" class="btn blue">确定</button>
	</div>
   <%--     </div>
		</div>--%>
</div>

<div class="row">
	<div class="col-md-12">
		<h3 class="page-title">
		医院档案 <small>查看、编辑医院信息</small>
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
				医院档案
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
					<i class="fa fa-edit"></i>医院列表
				</div>
				<div class="tools">
						
				</div>
			</div>
			<div class="portlet-body">
                <form data-wgt="mw-submit-group mw-edittable" 
                    id="mwFrmList"
                    data-wgt-submit-method="AjaxSubVendor" 
                    <%--data-wgt-submit-options-reload="true" 
                    data-wgt-submit-options-block="true" --%>
                    data-wgt-submit-options-recall="BOBDVendor.subrecall"
                    action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.BDVendor) %>">
				    <div class="table-toolbar">
					    <div class="btn-group">
						    <button id="sample_editable_1_new" type="button" class="btn green mw-creat">
						    添加新医院 <i class="fa fa-plus"></i>
						    </button>
					    </div>
				    </div>
				<table class="table table-striped table-hover table-bordered" id="sample_editable_1">
				<thead>
				<tr>

                    <th>
                        医院编号
                    </th>
                    <th>
                        医院名称
                    </th>
                    <th>
                        地址坐标
                    </th>
					<th>
						编辑
					</th>
				</tr>
				</thead>
				<tbody>
                            <%
                                foreach (var item in PageVendorDataList)
                                {
                            %>
				<tr>
					<td>
                        <% = item.VendorCode %>
                    </td>
                    <td>
                        <% = item.Vendor %>
                    </td>
                    <td>
                        <% = item.Address %>
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
                            [Value]<input id="[empty]vendorCode" name="[empty]vendorCode" submit-group="[empty]save" type="hidden" class="form-control input-small" value="" />
                        </td>
                            <td>
                            <input id="[empty]vendor" name="[empty]vendor" submit-group="[empty]save" maxlength="<% = TblMWVendor.getVendorColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                        </td>
                        <td>
                            <a class="btn default" data-target="#baidumap" data-toggle="modal">打开地图</a>
                            <input id="[empty]address" name="[empty]address" submit-group="[empty]save" maxlength="<% = TblMWVendor.getAddressColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                        </td>
						<td>
							    <a class="edit" data-mode="save" data-opt="edit" href="">保存</a> <a class="cancel"  href="">取消</a>
                                <input type="hidden" name="[empty]optType" submit-group="[empty]save" value="edit" />
						</td>
                    </tr>
                    <tr id="mw-rownewtemp" style="display:none;">
                        <td>
                        
                            <input id="[empty1]vendorCode" name="[empty1]vendorCode" submit-group="[empty1]save"  maxlength="<% = TblMWVendor.getVendorCodeColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                        </td>
                            <td>
                            
                            <input id="[empty1]vendor" name="[empty1]vendor" submit-group="[empty1]save"  maxlength="<% = TblMWVendor.getVendorColumn().ColumnSize %>" type="text" class="form-control input-small" value="" />
                        </td>
                        <td>
                            <a class="btn default" data-target="#baidumap" data-toggle="modal">打开地图</a>
                            <input id="[empty1]address" name="[empty1]address" submit-group="[empty1]save"  maxlength="<% = TblMWVendor.getAddressColumn().ColumnSize %>" type="text" class="form-control input-small" value="">
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
<script src="/assets/bobdvendor.js"></script>
<script src="/assets/wgt-edittable.js"></script>
<%--<script src="/assets/plugins/bootstrap-modal/js/bootstrap-modalmanager.js" type="text/javascript"></script>
<script src="/assets/plugins/bootstrap-modal/js/bootstrap-modal.js" type="text/javascript"></script>--%>
<script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=<% = YRKJ.MWR.Business.Sys.MWParams.GetBaiduMapAK() %>"></script>--%>

<script>

    var map = null;
    function initBaiduMap() {
        map = new BMap.Map("allmap");
        map.enableScrollWheelZoom(true);
        //        map.centerAndZoom(new BMap.Point(117.35721, 39.263985), 15);
        var ads = $('#address').val();
        if (ads) {
            var adsArray = ads.split(',');
            if (adsArray.length == 2) {
               
                map.centerAndZoom(new BMap.Point(parseFloat(adsArray[0]), parseFloat(adsArray[1])), 15);
                setMapAddressLab(parseFloat(adsArray[0]), parseFloat(adsArray[1]));
            } else {
                map.centerAndZoom('<% = YRKJ.MWR.Business.Sys.MWParams.GetDefaultMapCity() %>', 15);
            }
        }else
            map.centerAndZoom('<% = YRKJ.MWR.Business.Sys.MWParams.GetDefaultMapCity() %>', 15);
        map.addEventListener("click", showInfo);
    }

    jQuery(document).ready(function () {
        BOBDVendor.init();
        WGTEdtiTable.init();
        $('#baidumap').on('shown', function () {
          
            map = null;
            if (!map) {
                initBaiduMap();
                return;
            }
            return;
        });
        $('#btnOK').click(function () {
            $('#address').val($('#mwTxtVendorAddress').val());
        });
    });
   
   
    function showInfo(e) {
        setMapAddressLab(e.point.lng, e.point.lat)
       
    }
    function setMapAddressLab(lng,lat) {
        map.clearOverlays();
        var point = new BMap.Point(lng,lat);
        map.centerAndZoom(point);
        map.panTo(point); 
        var marker = new BMap.Marker(point);  // 创建标注
        map.addOverlay(marker);               // 将标注添加到地图中
        marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画
        var opts = {
            position: point,    // 指定文本标注所在的地理位置
            offset: new BMap.Size(30, -40)    //设置文本偏移量
        }
        var label = new BMap.Label('当前坐标[' + lng + ',' + lat + '] ', opts);  // 创建文本标注对象
        label.setStyle({
            color: "black",
            fontSize: "12px",
            height: "20px",
            lineHeight: "20px",
            border: "none",
            fontFamily: "微软雅黑"
        });
        map.addOverlay(label);
        $('#mwTxtVendorAddress').val(lng + ',' + lat);
    }
</script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footscript" runat="server">
</asp:Content>
