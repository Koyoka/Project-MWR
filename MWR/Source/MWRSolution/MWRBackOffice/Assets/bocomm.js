var CommHelper = function () {

    var initHelper = function () {

        gl.wgt.set('mw-submit', {
            //            <form data-wgt="mw-submit" 
            //                data-wgt-submit-method="" 
            //                data-wgt-submit-options-reload="true" 
            //                data-wgt-submit-options-block="true" 
            //                data-wgt-submit-options-recall="CommHelper.recallCarDispatch" 
            //                action="">
            //                    <input type="submit" value="submit" />
            //                </form>

            init: function () {
                if (this.element.context.tagName !== "FORM") {
                    window.alert("[mw-submit] Must be wgt to [FORM]");
                } else {
                    this.initPageCtrl();
                    this.element.on("submit", this.submit.bind(this))
                }
            },
            submit: function (e) {
                e.preventDefault();

                var method = this.element.attr("data-wgt-submit-method");
                var url = this.element.attr("action");
                var data = this.element.serializeJson();

                var needblock = !(this.element.attr("data-wgt-submit-options-block") === "false");
                var needreload = !(this.element.attr("data-wgt-submit-options-reload") === "false");

                var wgtrecall = this.element.attr('data-wgt-submit-options-recall');
                var recall;
                if (!!wgtrecall) {
                    var recallStr = wgtrecall.split(".");

                    for (i = 0; i < recallStr.length; i++) {
                        if (i == 0) {
                            recall = window[recallStr[i]];
                        } else {
                            recall = recall[recallStr[i]];
                        }
                    }
                }

                var el = this.element;
                var blockEl;
                if (needblock)
                    blockEl = el.parent();
                var loadBtn = this.element.find(".demo-loading-btn").length == 1 ? this.element.find(".demo-loading-btn") : false;
//                window.cursor = "hand"
                $.AjaxPJson(url, method, data, function (d) {

                    if (needreload) {
                        var defineEl = $(d).find("#" + el.attr("id"));
                        gl.wgt.scan(defineEl);
                        el.replaceWith(defineEl)
                    }
                    if (recall)
                        recall(el, d);
                   
                }, function (r) {
                    Modal.alert('服务器连接错误，请联系管理员。[' + r + ']');

                }, function () {
                    
                    if (loadBtn)
                        loadBtn.button('loading');
                    if (blockEl)
                        App.blockUI(blockEl);
                }, function () {
                    if (loadBtn)
                        loadBtn.button('reset');
                    if (blockEl)
                        App.unblockUI(blockEl);
                    
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

        gl.wgt.set('mw-submit-cardispatch', {

            init: function () {
                if (this.element.context.tagName !== "FORM") {
                    window.alert("Must wgt to [FORM]");
                } else {
                    this.element.on("submit", this.submit.bind(this));
                }
            },

            submit: function (e) {
                e.preventDefault();

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

    var _testFunc = function (s) {
        window.alert(12345 + " " + s)
    }

    var _recallCarDispatch = function (el, data) {
        $("#mwFrmDispList").submit();
        Modal.alert('车辆调度已提交。'); //.on(function (e) {});
    }

    return {
        init: function () {
            initHelper();
            //            initFromPageEvent();
        },

        testFunc: _testFunc,
        recallCarDispatch: _recallCarDispatch
    };
} ();
