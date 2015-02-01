<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxFileUpload.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.Demo.AjaxFileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
    <form action="AjaxFileUpload.aspx" method="POST" name="asdf" id="asdf" enctype="multipart/form-data" >
    <div>
    <input type="file" id="file1" name="file" />
    </div>
    <div>
    <input type="text" id="file2" name="file" />
    </div>
    </form>
    
    <br />
    <input id="btn" type="button" value="click" />
    <script src="/assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/assets/cscripts/ajaxfileupload.js" type="text/javascript"></script>
    <script>

        $(function () {
            $("#btn").click(function (e) {
                window.alert(1);

                var da = {};
                da["eleven"] = "ads";
                da["value"] = "value";
                $.ajaxFileUpload({
//                    url: 'AjaxFileUpload.aspx', //用于文件上传的服务器端请求地址
                    secureuri: false, //是否需要安全协议，一般设置为false
//                    fileElementId: 'file1', //文件上传域的ID
                    fileForm: $("form"),
                    dataType: 'text', //返回值类型 一般设置为json,
//                    data: da,
                    success: function (data, status)  //服务器成功响应处理函数
                    {
                        window.alert("success");
                        //                        $("#img1").attr("src", data.imgurl);
                        //                        if (typeof (data.error) != 'undefined') {
                        //                            if (data.error != '') {
                        //                                alert(data.error);
                        //                            } else {
                        //                                alert(data.msg);
                        //                            }
                        //                        }
                    },
                    error: function (data, status, e)//服务器响应失败处理函数
                    {
                        alert(e);
                    }
                }
            )

            });
        });
    </script>
</body>
</html>
