
var FuncGroupEditHelper = function () {

    var initHelper = function () {
        gl.wgt.set('mw-removeFuncGroup', {
            init: function () {
                this.element.on('click', this.submit.bind(this));
            },

            submit: function (e) {
                e.preventDefault();
                Modal.confirm("确认删除当前组？").on(function (r) {
                    if (r) {
                        $('#optType').val('removeFuncGroup');
                        $('#mwFrmFuncDetail').submit();
                    }
                });

            }
        });


        gl.wgt.set('mw-removeFuncGroupDetail', {

            init: function () {
                this.element.on('click', this.changeFuncGroup.bind(this));
            },

            changeFuncGroup: function (e) {
                e.preventDefault();
                var code = this.element.attr('data-mw-optfuncgroup-code');
                $('#optType').val('remove');
                $('#optFuncTag').val(code);
                $('#mwFrmFuncDetail').submit();
            }

        });
        gl.wgt.set('mw-addFuncGroupDetail', {

            init: function () {
                this.element.on('click', this.changeFuncGroup.bind(this));
            },

            changeFuncGroup: function (e) {
                e.preventDefault();
                var code = this.element.attr('data-mw-optfuncgroup-code');
                $('#optType').val('add');
                $('#optFuncTag').val(code);
                $('#mwFrmFuncDetail').submit();
            }

        });

        gl.wgt.set('mw-changeFuncDetail', {

            init: function () {
                this.element.on('click', this.changeFuncGroup.bind(this));
            },

            changeFuncGroup: function (e) {
                e.preventDefault();
                $('#optType').val('none');
                var id = this.element.attr('data-mw-changefuncgroup-id');
                $('#functionGroupId').val(id);
                $('#mwFrmFuncDetail').submit();
            }

        });
    }

    var _removeFuncGroupRecall = function (el, netData, locData) {
        if (locData['optType'] != "removeFuncGroup") {
            return;
        }
        $('.mw-tab-item, .active').remove('.active');
        $('.mw-tab-item').eq(0).addClass('active');
    }

    return {
        init: function () {
            initHelper();
        },
        removeFuncGroupRecall: _removeFuncGroupRecall

    }
} ();