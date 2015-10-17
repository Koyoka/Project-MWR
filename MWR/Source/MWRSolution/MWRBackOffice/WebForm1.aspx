<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="YRKJ.MWR.BackOffice.WebForm1" %>
<<<<<<< HEAD
{"error":null,"unAuthorizedRequest":false,"result":{"orders":[{"total":69300,"cancelTime":null,"customerRemark":null,"orderPayments":[],"customerHxUserName":"MTM2NTY1NjU2NTY=","shipContactPhone":"13689898989","paymentStatus":10001,"orderItems":[{"id":6,"unit":null,"categoryName":"混凝土","attributeDescription":"强度等级: C30\r\n到场坍落度: 200-220\r\n卸料方式: 车泵\r\n","quatity":220,"unitPrice":315,"productAttributes":null,"attributeXML":"<attribute id='1' valueId='4' mappingId='1' \/><attribute id='2' valueId='10' mappingId='2' \/><attribute id='3' valueId='19' mappingId='3' \/>","productName":null,"orderId":4,"productId":1}],"serviceOrderId":19,"vendorHxUserName":"MTM2ODk4OTg5ODk=","vendorId":20,"orderRemark":null,"orderStatus":10002,"id":4,"planDeliveryDate":"2015-08-06T01:16:45","orderReviews":[],"confirmTime":"2015-08-06T15:33:47.873","closeTime":null,"customerId":19,"isPlanDeliveryDatePending":false,"shipContactName":"老王亲戚请","orderNumber":"201508064586","paidAmount":0,"shipAddress":"未来之光1003请"}]},"success":true}
=======
{"Orders":[{"OrderNumber":"","CustomerHxUserName":"","VendorHxUserName":"","OrderStatus":0,"PaymentStatus":0,"CustomerRemark":"","OrderRemark":"","ShipAddress":"","ShipContactName":"","ShipContactPhone":"","Id":0}]}

<%
    string path = Server.MapPath("~/Setting");
    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
    if (di.Exists)
    {
        System.IO.FileInfo[] files = di.GetFiles();
        foreach (var item in files)
        {
            Response.Write("count:" + item.Name);
        }
        Response.Write("count:"+files.Length);
        return;
    }
     %>

<%--<div style="display:none;">
<% = HttpRuntime.AppDomainAppPath  %>
<br />
<% = Server.MapPath("")%>
<br />// ComLib.ComFn.AESDecrypt(ss)
<% = Request.ApplicationPath %><br />
<% string s = ComLib.ComFn.EncryptDBPassword("1ADSFADF11", "eleveneleveneleveneleveneleveneleveneleveneleveneleven"); %><br />
<% = s %><br />
</div>
<% = s %>
<br />

<br />
<%
    string DBKey = "pMwrdbWORDTaBlE01234567890123456";
    string ss = ComLib.ComFn.AESEncrypt(DBKey,"-101868");
     %>
     <% = ss %><br />
     <%
         string DBKey1 = "pMwrdbWORD";
    string sss = ComLib.ComFn.AESEncrypt(DBKey1, "yrkj@1q2w3e");
     %>
     <% = sss  %><br />
     <% = ComLib.ComFn.DecryptDBPassword( DBKey1,sss)%>

     <% 
         
         string dbName = System.Configuration.ConfigurationManager.AppSettings["DBName"].ToString();
         string dbService = System.Configuration.ConfigurationManager.AppSettings["DBService"].ToString();
         string dbUser = System.Configuration.ConfigurationManager.AppSettings["DBUser"].ToString();
         string dbPassword = System.Configuration.ConfigurationManager.AppSettings["DBPassword"].ToString();
         string dbKey = System.Configuration.ConfigurationManager.AppSettings["Key"].ToString();
         dbPassword = ComLib.ComFn.DecryptDBPassword(dbKey, dbPassword);
         %><br />
         ================1111<br />
         <% = dbName %><br />
         <% = dbService%><br />
         <% = dbUser%><br />
         <% = dbPassword%><br />--%>
>>>>>>> origin/master
