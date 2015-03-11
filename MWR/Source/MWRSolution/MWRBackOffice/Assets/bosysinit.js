var SysInitHelper = function () {
    var initHelper = function () {
        var URL = "/Pages/BO/Sys/SysInit.aspx";
        $('#fileupload').fileupload({
            url: URL,
            autoUpload: true
        })
        .bind('fileuploaddone', function (e, data) {
            _uploadReback(URL, e, data);
        });

        gl.wgt.set('mw-submitImportAll', {
            init: function () {
                this.element.on('click', this.click.bind(this));
            },
            click: function (e) {
                //                window.alert(1);
                e.preventDefault();
                $('#mw-importDataName').val("");
                $('#mwFrmImport').submit();
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
                $('#mw-importDataName').val(dName);
                $('#mwFrmImport').submit();
            }

        });
    };

    var _uploadReback = function (url, e, d) {
        //        window.alert(d.result.result);
        //        return;
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
        Modal.alert('数据导入成功。' + netData.Value);
    }

    return {
        init: function () {
            initHelper();
        },
        recallImport: _recallImport
    };
} ();