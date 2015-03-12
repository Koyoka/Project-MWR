var SysInitHelper = function () {
    var initHelper = function () {
        var ProEl = $('.progress .progress-bar');
        ProEl.hide();
        //        ProEl.css("width", progress + "%");
        var URL = "/Pages/BO/Sys/SysInit.aspx";
        $('#fileupload').fileupload({
            url: URL,
            autoUpload: true,
            progressall: function (e, data) {
                var progress = parseInt(data.loaded / data.total * 100, 10);
                //                var el = $('.progress .progress-bar ');
                ProEl.show();
                ProEl.css("width", progress + "%");
            }
            //            progress: function (e, data) {
            ////                if (data.context) {
            ////                var el = $('.progress .progress-bar');
            //                ProEl.show();
            ////                window.alert(parseInt(data.loaded / data.total * 100, 10))
            //                ProEl.css(
            //                    'width',
            //                    parseInt(data.loaded / data.total * 100, 10) + "%"
            //                );
            ////            }
            //            }mCLqnhJ@RkeE_h]S{YLoCbedr@R]BeRhmRJC{]lgmP
        })
        .bind('fileuploaddone', function (e, data) {

            _uploadReback(URL, e, data);
        });

        gl.wgt.set('mw-submitImportAll', {
            init: function () {
                this.element.on('click', this.click.bind(this));
            },
            click: function (e) {
                e.preventDefault();
                Modal.confirm("请再次确认，您将执行覆盖导入数据操作！").on(function (r) {
                    if (r) {
                        $('#mw-importDataName').val("");
                        $('#mwFrmImport').submit();
                    }
                });



            }

        });

        gl.wgt.set('mw-submitImportCurData', {
            init: function () {
                this.element.on('click', this.click.bind(this));
            },
            click: function (e) {
                //                window.alert(1);
                e.preventDefault();
                var dName = this.element.attr('data-wgt-import-data');
                Modal.confirm("请再次确认，您将执行覆盖导入数据操作！").on(function (r) {
                    if (r) {
                        $('#mw-importDataName').val(dName);
                        $('#mwFrmImport').submit();
                    }
                });
            }

        });
    };

    var _uploadReback = function (url, e, d) {
        //        window.alert(d.result.result);
        //        return;
        var ProEl = $('.progress .progress-bar');
        if (d.result.error) {
            Modal.alert('[' + d.result.result + ']');
            return;
        }
        var method = "AjaxGetInitData";
        var el = $('#mw-initData');
        var blockEl = el.parent();
        var data = {};
        var fileName = d.result.result;
        data["fileName"] = fileName;

        $.AjaxPJson(url, method, data, function (d) {

            var defineEl = $(d).find("#" + el.attr("id"));
            gl.wgt.scan(defineEl);
            el.replaceWith(defineEl)
            $('#mw-importFileName').val(fileName);
            $('#mw-importDataName').val("");
            $('#mw-importInitData').removeClass('disabled');
            ProEl.hide();
        }, function (r) {
            Modal.alert('[' + r + ']');
        }, function () {
            if (blockEl)
                App.blockUI(blockEl);
        }, function () {
            if (blockEl)
                App.unblockUI(blockEl);
        });
    };

    var _recallImport = function (el, netData, locData) {
        Modal.alert('数据导入成功。');
    }

    return {
        init: function () {
            initHelper();
        },
        recallImport: _recallImport
    };
} ();
//mCLqnhJ@RkeE_h]S{YLoCbedr@R]BeRhmRJC{]lgmP