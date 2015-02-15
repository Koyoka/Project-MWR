
var WSManageHelper = function () {

    var initHelper = function () {
        gl.wgt.set('mw-InitMobile', {
            init: function () {
                this.element.on('click', this.showInit.bind(this));
            },

            showInit: function (e) {
                e.preventDefault();
                //                $('#stack1').modal();
                var url = this.element.attr('data-wgt-initmobile-url');
                var method = this.element.attr('data-wgt-initmobile-method');

                $.AjaxPJson(url, method, {}, function (d) {
//                    window.alert(d.Value);
                    $('#imgQRCode').attr('src', '/Services/QRCodeThumbnail.ashx?content=' + d.Value);
                    $('#stack1').modal();
                }, function (r) {
                    window.alert(r);
                });

            }
        });
    }

    return {
        init: function () {
            initHelper();
        }
    }
} ();