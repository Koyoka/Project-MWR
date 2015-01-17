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
                var method = this.element.attr("data-wgt-submit-method");
                var loadBtn = this.element.find(".demo-loading-btn") ? this.element.find(".demo-loading-btn") : false;
                var url = this.element.attr("action");
                var data = this.element.serializeJson();
                if (loadBtn) 
                    loadBtn.button('loading');

                App.blockUI(this.element, false);
                var el = this.element;
                $.AjaxPJson(url, method, data, function (d) {

                    var defineEl = $(d).find("#" + el.attr("id"));
                    gl.wgt.scan(defineEl);
                    el.replaceWith(defineEl)
                    $("#mwFrmDispList").submit();
                    App.unblockUI(el);
                    Modal.alert('车辆调度已提交。'); //.on(function (e) {});
                    if (loadBtn) 
                        loadBtn.button('reset');
                }, function (r) {
                    Modal.alert('服务器连接错误，请联系管理员。');
                    App.unblockUI(el);
                    if (loadBtn) 
                        loadBtn.button('reset');
                });
            }
        });
        gl.wgt.set('mw-submit-cardispatchList', {

            init: function () {
                this.initPageCtrl();
                this.element.on("submit", this.submit.bind(this));
            },
            submit: function (e) {
                e.preventDefault();
                if (this.element.context.tagName !== "FORM") {
                    window.alert("Must wgt to [FORM]");
                    return;
                }

                var method = this.element.attr("data-wgt-submit-method");
                var url = this.element.attr("action");
                var data = this.element.serializeJson();

                App.blockUI(this.element, false);
                var el = this.element;
                $.AjaxPJson(url, method, data, function (d) {
                    var defineEl = $(d).find("#" + el.attr("id"));
                    gl.wgt.scan(defineEl);
                    el.replaceWith(defineEl)
                    App.unblockUI(el);
                }, function (r) {
                    Modal.alert('服务器连接错误，请联系管理员。');
                    App.unblockUI(el);
                });
            },
            initPageCtrl: function () {
                var el = this.element;
                el.find('.dataTables_paginate .pagination a').on("click", function (e) {
                    e.preventDefault();
                    if ($(this).hasClass("disabled"))
                        return;
                    var curPage = $(this).attr("data-wgt-page");
                    el.find(".mw_curpage").val(curPage)
                    el.submit();
                });
            }


        });



    }

    return {
        init: function () {
            initHelper();
            //            initFromPageEvent();
        }
    };
} ();
