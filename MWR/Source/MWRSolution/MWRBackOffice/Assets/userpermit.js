
var UserPermitHelper = function () {

    var initHelper = function () {

        gl.wgt.set('mw-removeFuncGroup', {

            init: function () {
                this.element.on('click', this.changeFuncGroup.bind(this));
            },

            changeFuncGroup: function (e) {
                e.preventDefault();
                var code = this.element.attr('data-mw-optfuncgroup-code');
                $('#optType').val('remove');
                $('#optEmpyCode').val(code);
                $('#mwFrmUserFuncGrp').submit();
            }

        });
        gl.wgt.set('mw-addFuncGroup', {

            init: function () {
                this.element.on('click', this.changeFuncGroup.bind(this));
            },

            changeFuncGroup: function (e) {
                e.preventDefault();
                var code = this.element.attr('data-mw-optfuncgroup-code');
                $('#optType').val('add');
                $('#optEmpyCode').val(code);
                $('#mwFrmUserFuncGrp').submit();
            }

        });

        gl.wgt.set('mw-changeFuncGroup', {

            init: function () {
                this.element.on('click', this.changeFuncGroup.bind(this));
            },

            changeFuncGroup: function (e) {
                e.preventDefault();
                $('#optType').val('none');
                var id = this.element.attr('data-mw-changefuncgroup-id');
                $('#functionGroupId').val(id);
                $('#mwFrmUserFuncGrp').submit();
            }

        });

        //        gl.wgt.set('mw-InitMobile', {
        //            init: function () {
        //                this.element.on('click', this.showInit.bind(this));
        //            },

        //            showInit: function (e) {
        //                e.preventDefault();
        //                //                $('#stack1').modal();
        //                var url = this.element.attr('data-wgt-initmobile-url');
        //                var method = this.element.attr('data-wgt-initmobile-method');

        //                $.AjaxPJson(url, method, {}, function (d) {
        //                    //                    window.alert(d.Value);
        //                    $('#imgQRCode').attr('src', '/Services/QRCodeThumbnail.ashx?content=' + d.Value);
        //                    $('#stack1').modal();
        //                }, function (r) {
        //                    window.alert(r);
        //                });

        //            }
        //        });
    }

    return {
        init: function () {
            initHelper();
        }
    }
} ();