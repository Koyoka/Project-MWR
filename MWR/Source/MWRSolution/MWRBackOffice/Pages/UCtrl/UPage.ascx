<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UPage.ascx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.UCtrl.UPage" %>
 <div class="row">
    <div class="col-md-3 ">
        <div class="dataTables_info" id="sample_2_info">
        <% = CurrentPage+"" %>/<% = ShowPageCount + ""%> 页</div>
    </div>
    <div class="col-md-9 ">
        <div class="dataTables_paginate paging_bootstrap">
            <input type="hidden" class="mw_curpage" submit-group="common" name="page" value="<% = CurrentPage %>" />
            <ul class="pagination" style="visibility: visible;">
                                    
                <li class="prev <% = DisPre %>">
                    <a href="#" data-wgt-page="<% = PrePage %>" title="Prev" class="<% = DisPre %>">
                    <i class="fa fa-angle-left"></i>
                    </a>
                </li>
                <%
                                        
                    for (int i = 1 + fPage; i <= PageCount + fPage; i++)
                    {
                                            
                %>
                <li class="<% = (i==CurrentPage?"active":"") %>"><a href="#" data-wgt-page="<% = i %>"><% = i %></a></li>
                <%
                    }
                %>
                                    
                <%-- <li><a href="#" data-wgt-page="2">2</a></li>
                <li><a href="#" data-wgt-page="3">3</a></li>--%>
                <li class="next <% = DisNext %>">
                    <a href="#" title="Next" data-wgt-page="<% = NextPage %>" class="<% = DisNext %>">
                    <i class="fa fa-angle-right"></i>
                    </a>
                </li>
            </ul>
        </div>
    </div>
</div>