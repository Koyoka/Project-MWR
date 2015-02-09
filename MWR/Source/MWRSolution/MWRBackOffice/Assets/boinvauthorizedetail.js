var InvAuthHelper = function () {

    var initHelper = function () {
        $('#mwSubAuth input[name="remark"]').focus();
        'use strict';
        _validForm();
        $('#fileupload').fileupload({
            url: "/Services/FileUpload/MWFileUploadHandler.ashx",
            autoUpload: false
            //            progressall: function (e, data) {
            //                var progress = parseInt(data.loaded / data.total * 100, 10);
            //                $('.progress .progress-bar ').css("width", progress + "%");
            //            },
            //            progress: function (e, data) {
            //                if (data.context) {
            //                    data.context.find('.progress').show();
            //                    data.context.find('.progress .progress-bar').css(
            //                        'width',
            //                        parseInt(data.loaded / data.total * 100, 10) + "%"
            //                    );
            //                }
            //            },
            //            start: function () {
            //                $('.progress .progress-bar ').css("width", "0px");
            //                $(this).find('.fileupload-progressbar')
            //                    .progressbar('value', 0).fadeIn();
            //            }
        });
        var action = $('#fileupload form input[name="action"]').val();
        var txnNum = $('#fileupload form input[name="txnNum"]').val();
        var crateCode = $('#fileupload form input[name="crateCode"]').val();
        _getFileList(action, txnNum, crateCode);
    };
    function _getFileList(action, txnnum, crateCode) {
        // Load existing files:
        $.getJSON("/Services/FileUpload/MWFileUploadHandler.ashx?action=" + action + "&txnnum=" + txnnum + "&crateCode=" + crateCode, function (data) {
            var fu = $('#fileupload').data('blueimp-fileupload')
            || $('#fileupload').data('fileupload'),
            template,
            deferred;
            var files = data.files;
            
            template = fu._renderDownload(files)[
                        fu.options.prependFiles ? 'prependTo' : 'appendTo'
                    ](fu.options.filesContainer);
            fu._forceReflow(template);
            fu._transition(template);
        });
    }
    function _validForm() {
        var form1 = $('#mwSubAuth');
        var error1 = $('.alert-danger', form1);
        form1.validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: true, // do not focus the last invalid input
            ignore: "",
            rules: {
                remark: {
                    minlength: 2,
                    required: true
                }
            },
            messages: {
                remark: "请输入审核意见"
            },
            invalidHandler: function (event, validator) { //display error alert on form submit              
                error1.show();
                App.scrollTo(error1, -200);
            },
            highlight: function (element) { // hightlight error inputs
                $(element)
                        .closest('.form-group').addClass('has-error'); // set error class to the control group
            },

            unhighlight: function (element) { // revert the change done by hightlight
                $(element)
                        .closest('.form-group').removeClass('has-error'); // set error class to the control group
            },
            success: function (label) {
                label
                        .closest('.form-group').removeClass('has-error'); // set success class to the control group
            },
            submitHandler: function (form) {
                error1.hide();
            }
        });
    }


    return {
        init: function () {
            initHelper();
        }
    };
} ();