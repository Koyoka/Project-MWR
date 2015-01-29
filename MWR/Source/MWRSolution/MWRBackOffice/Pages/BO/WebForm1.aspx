<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style>
.bar {
height: 18px;
background: green;
}
</style>
</head>
<body>
    <form  id="fileupload" action="/Pages/BO/WebForm1.aspx" method="POST" enctype="multipart/form-data">
    <div>
    <input type="text" name="val1" value="eleven" />

    <input  type="file" name="files[]" multiple>    <button type="submit" class="btn blue start">
	<i class="fa fa-upload"></i>
	<span>
		Start upload
	</span>
	</button>
    </div>

    </form>
    1<div id="progress">
    <div class="bar" style="width: 0%;"></div>
    </div>1
    <br />
    <input id="fileupload1" type="file" name="files[]" data-url="/Pages/BO/WebForm1.aspx" multiple>
    <br />
    <input id="btn" type="button" value="click" />

    <script src="/assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="/assets/plugins/jquery-file-upload/js/vendor/jquery.ui.widget.js"></script>    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload.js"></script>    <script>
        jQuery(document).ready(function () {

            //            $("#btn").click(function () {
            //                
            //                window.alert(111);

            //                $('#fileupload').fileupload({
            //                    dataType: 'json',
            //                    done: function (e, data) {
            //                        $.each(data.result.files, function (index, file) {
            //                            $('<p/>').text(file.name).appendTo(document.body);
            //                        });
            //                    }
            //                });
            //            });

            $('#fileupload').fileupload({
                dataType: 'json',
                done: function (e, data) {
                    $.each(data.result.files, function (index, file) {
                        $('<p/>').text(file.name).appendTo(document.body);
                    });
                },
                autoUpload: false,
//                formData: function (form) {
                //                    return form.serializeArray();
//                },
//                acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
//                maxFileSize: 5000000,
                progressall: function (e, data) {
                    
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    $('#progress .bar').css(
                        'width',
                        progress + '%'
                    );
                }
            });

        });
</script>

</body>
</html>
