﻿
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
    }

    return {
        init: function () {
            initHelper();
        }
    }
} ();