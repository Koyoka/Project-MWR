<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/MWBOBlock.master" AutoEventWireup="true" CodeBehind="BlockSendCarDispatch.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.Block.BlockSendCarDispatch" %>
<%@ Import Namespace="YRKJ.MWR.BackOffice.Business.Sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="block" runat="server">

 <!-- BEGIN FORM-->
                <form id="cc" data-wgt="mw-submit-cardispatch" data-submit-method="AjaxSubCarDispstch" action="<% = WebAppFn.GetBoFullPageUrl(RedirectHelper.CarDispatch) %>" class="">
                    <div class="form-body">
                        <div class="form-group">
                            <label class="control-label">
                                当前驻厂车辆</label>
                            <select  name="data1" class="form-control input-lg">
                                <option value="value1">选择车辆</option>
                                <option>鄂A88888</option>
                                <option>鄂A88888</option>
                                <option>鄂A88888</option>
                                <option>鄂A88888</option>
                                <option>鄂A88888</option>
                            </select>
                        </div>
                        <div class="form-group">
                            <label class="control-label">
                                当前驻留司机</label>
                            <select  name="data2" class="form-control input-lg">
                                <option  value="value2">选择司机</option>
                                <option>张三</option>
                                <option>张三</option>
                                <option>张三</option>
                                <option>张三</option>
                                <option>张三</option>
                                <option>张三</option>
                            </select>
                        </div>
                        <div class="form-group last">
                            <label class="control-label">
                                当前驻留跟车员</label>
                            <select name="data3" class="form-control input-lg">
                                <option  value="value3">选择跟车员</option>
                                <option>李四</option>
                                <option>李四</option>
                                <option>李四</option>
                                <option>李四</option>
                                <option>李四</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-actions right">
                        <input type="submit" value="提交" data-loading-text="提交..." class="demo-loading-btn btn btn-primary green" />
                       <%-- <button type="button" data-loading-text="提交..." class="demo-loading-btn btn btn-primary green">
								提交 </button>--%>
                    </div>
                    </form>
                    <!-- END FORM-->

</asp:Content>