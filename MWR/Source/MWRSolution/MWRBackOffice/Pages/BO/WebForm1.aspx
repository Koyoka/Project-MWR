<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="YRKJ.MWR.BackOffice.Pages.BO.WebForm1" %>

<!DOCTYPE HTML>
<html>
<head>

<meta charset="utf-8">
<title>jQuery File Upload Example</title>
<!--[if lt IE 9]>
<script src="/Assets/html5.js"></script>
<![endif]-->

<style>
.bar {
    height: 18px;
    background: green;
}
#progress {
  background: url(/assets/images/pbar-ani.gif);
  display:none;
}
</style>
</head>
<body>
<form class="template-upload" id="fileupload" action="WebForm1.aspx" method="POST" enctype="multipart/form-data">
<input type="text" name="eleven" />
<div class="fileupload-buttonbar">
    <label class="fileinput-button">
        <span>Add files...</span>
        <input type="file" name="files[]" multiple="multiple" />
    </label>
    <button type="submit" class="start button">
		Start upload
	</button>
    <button type="button" class="delete button">Delete all files</button>
	<div class="fileupload-progressbar"></div>
    <div class="fileupload-content">
        <div class="files">
        </div>
    </div>
</div>


</form>


<br />

<div id="progress">
    <div class="bar" style="width: 0%;"></div>
</div>
<script src="/assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    
<script src="/assets/plugins/jquery-file-upload/js/vendor/jquery.ui.widget.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/jquery.iframe-transport.js"></script>
<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload.js"></script>


<script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-ui.js"></script>

<%--<input id="" type="file" name="files[]" data-url="http://localhost:15809/Services/MWRecoverServer.aspx" multiple>--%>
 
    <!-- The Load Image plugin is included for the preview images and image resizing functionality -->
   <%-- <script src="/assets/plugins/jquery-file-upload/js/vendor/load-image.min.js"></script>
    <!-- The Canvas to Blob plugin is included for image resizing functionality -->
    <script src="/assets/plugins/jquery-file-upload/js/vendor/canvas-to-blob.min.js"></script>
    <!-- The Iframe Transport is required for browsers without support for XHR file uploads -->
   
    <!-- The basic File Upload plugin -->

    <!-- The File Upload processing plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-process.js"></script>
    <!-- The File Upload image preview & resize plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-image.js"></script>
    <!-- The File Upload audio preview plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-audio.js"></script>
    <!-- The File Upload video preview plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-video.js"></script>
    <!-- The File Upload validation plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-validate.js"></script>
    <!-- The File Upload user interface plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-ui.js"></script>
--%>
<script>
    $(function () {
        $("#btn").click(function (e) {
            //            window.alert($('#fileupload').data);
            $('#fileupload').fileupload().submit();
        });

        $('#fileupload').fileupload({
            dataType: 'text',
            autoUpload: false,
            done: function (e, data) {
                //                $.each(data.result.files, function (index, file) {
                //                    $('<p/>').text(file.name).appendTo(document.body);
                //                });
                $('#progress').hide();
            },
            submit: function (e, data) {
                window.alert(1);
            },
            start: function (e) {
                window.alert(2);
            },
            send: function (e, data) {
                $('#progress').show();
            },
            fail: function (e, data) {
                window.alert(data.textStatus)
            },
            add: function (e, data) {
                data.context = $('<button/>').text('Upload')
                        .addClass("start")
                        .appendTo(".fileupload-content .files")
                        .click(function () {
                            data.context = $('<p/>').text('Uploading...').replaceAll($(this));
                            data.submit();
                        });

            },
            progressall: function (e, data) {
                //            window.alert(1)
                var progress = parseInt(data.loaded / data.total * 100, 10);
                $('#progress .bar').css(
                            'width',
                            progress + '%'
                        );
                //                        $('#progress').show();
                $('#progress .bar').html(progress + '%');

            }
        });
    });
</script>
</body> 
</html>

 <%--    <script src="/assets/plugins/jquery-file-upload/js/vendor/tmpl.min.js"></script>
    <!-- The Load Image plugin is included for the preview images and image resizing functionality -->
  <script src="/assets/plugins/jquery-file-upload/js/vendor/load-image.min.js"></script>
    <!-- The Canvas to Blob plugin is included for image resizing functionality -->
    <script src="/assets/plugins/jquery-file-upload/js/vendor/canvas-to-blob.min.js"></script>
    <!-- The Iframe Transport is required for browsers without support for XHR file uploads -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.iframe-transport.js"></script>
    <!-- The basic File Upload plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload.js"></script>
    <!-- The File Upload processing plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-process.js"></script>
    <!-- The File Upload image preview & resize plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-image.js"></script>
    <!-- The File Upload audio preview plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-audio.js"></script>
    <!-- The File Upload video preview plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-video.js"></script>
    <!-- The File Upload validation plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-validate.js"></script>
    <!-- The File Upload user interface plugin -->
    <script src="/assets/plugins/jquery-file-upload/js/jquery.fileupload-ui.js"></script>
    
  <script>
     


      jQuery(document).ready(function () {


            //            $('#fileupload').fileupload({
            //                dataType: 'json',
            //                done: function (e, data) {
            //                    $.each(data.result.files, function (index, file) {
            //                        $('<p/>').text(file.name).appendTo(document.body);
            //                    });
            //                },
            ////                autoUpload: false,
            //                formData: $('#Form1').serializeArray();,
            ////                acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
            ////                maxFileSize: 5000000,
            //                progressall: function (e, data) {
            //                    
            //                    var progress = parseInt(data.loaded / data.total * 100, 10);
            //                    $('#progress .bar').css(
            //                        'width',
            //                        progress + '%'
            //                    );
            //                }
            //            });

        });
</script>

</body>
</html>
--%>