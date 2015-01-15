var CommHelper = function () {

    var initHelper = function () {

        gl.wgt.set('mw-submit-cardispatch', {

            init: function () {
                this.element.on("submit", this.submit.bind(this));
            },

            submit: function (e) {
                e.preventDefault();
                if (this.element.context.tagName !== "FORM") {
                    window.alert("Must wgt to [FORM]");
                    return;
                }
                var method = this.element.attr("data-submit-method");

                var loadBtn = this.element.find(".demo-loading-btn") ? this.element.find(".demo-loading-btn") : false;
                var url = this.element.attr("action");
                var data = this.element.serializeJson();
                if (loadBtn) {
                    loadBtn.button('loading');
                }
                App.blockUI(this.element, false);

                var el = this.element;
                $.AjaxPJson(url, method, data, function (d) {
                    var s = JSON.stringify(d);
                    Modal.alert(
                    {
                        msg: '车辆调度已提交。'+s,
                    });//.on(function (e) {});
                    App.unblockUI(el);
                    if (loadBtn) {
                        loadBtn.button('reset');
                    }
                }, function (r) {
                     Modal.alert(
                    {
                        msg: '服务器连接错误，请联系管理员。',
                    });
                    App.unblockUI(el);
                    if (loadBtn) {
                        loadBtn.button('reset');
                    }
                });

            }
        });

    }

    return {
        init: function () {
            initHelper();
        }
    };
} ();
