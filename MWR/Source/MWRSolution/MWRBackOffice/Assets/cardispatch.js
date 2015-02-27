
var CarDispatchHelper = function () {

    var initHelper = function () {
        gl.wgt.set('mw-StartShift', {
            init: function () {

                this.element.on('click', this.showInit.bind(this));
            },

            showInit: function (e) {
                e.preventDefault();
                //                $('#stack1').modal();
                var url = this.element.attr('data-wgt-startshift-url');
                var method = this.element.attr('data-wgt-startshift-method');
                var data = $('#mwFrmCarDisp').serializeJson();
                $.AjaxPJson(url, method, data, function (d) {
                    if (d.Result == 1) {
                        Modal.alert(d.Value);
                    } else {
                        //                        window.alert(d.Value + " ok");
                        $('#imgQRCode').attr('src', '/Services/QRCodeThumbnail.ashx?content=' + d.Value);
                        $('#stack1').modal();
                    }

                }, function (r) {
                    Modal.alert(r);
                });

            }
        });

        $('#stack1').find('.ok').on('click', function (e) {
            //            window.alert("eleven");
            $("#mwTxtIsSubmit").val("");
            $("#mwFrmDispList").submit();
            $("#mwFrmCarDisp").submit();
        });
    }

    return {
        init: function () {
            initHelper();
        }
    }
} ();