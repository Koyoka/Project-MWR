var CommHelper = function () {

    var initHelper = function () {

        gl.wgt.set('mw-submit-group', {
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
                    var needpage = !(this.element.attr("data-wgt-submit-options-page") === "false");
                    if (needpage)
                        this.initPageCtrl();
                    this.element.on("submit", this.submit.bind(this))
                }
            },
            submit: function (e) {
                e.preventDefault();

                if (!!this.element.valid) {
                    if (!this.element.valid())
                        return;
                }
                var method = this.element.attr("data-wgt-submit-method");
                var url = this.element.attr("action");
                var data = this.element.serializeGroupJson();
                //                return;
                var needblock = !(this.element.attr("data-wgt-submit-options-block") === "false");
                var needreload = !(this.element.attr("data-wgt-submit-options-reload") === "false");

                var wgtsubstart = this.element.attr('data-wgt-submit-options-start');
                var substart = _getwgtrecall(wgtsubstart);
                if (substart) {
                    if (!substart(this.element, data))
                        return;
                }

                var wgtrecall = this.element.attr('data-wgt-submit-options-recall');
                var recall = _getwgtrecall(wgtrecall);
                var el = this.element;
                var blockEl;
                if (needblock)
                    blockEl = el.parent();
                var loadBtn = this.element.find(".demo-loading-btn").length == 1 ? this.element.find(".demo-loading-btn") : false;

                $.AjaxPJson(url, method, data, function (d) {
                    var defineEl = null;
                    if (needreload) {
                        var defineEl = $(d).find("#" + el.attr("id"));
                        el.replaceWith(defineEl);
                    }
                    if (recall)
                        recall(el, d, data);
                    if (defineEl) {
                        gl.wgt.scan(defineEl);
                    }

                }, function (r) {
                    Modal.alert('[' + r + ']');
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
                    el.setGroup('common');
                    el.submit();
                });
            }
        });

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
                    var needpage = !(this.element.attr("data-wgt-submit-options-page") === "false");
                    if (needpage)
                        this.initPageCtrl();
                    this.element.on("submit", this.submit.bind(this))
                }
            },
            submit: function (e) {
                e.preventDefault();

                if (!!this.element.valid) {
                    if (!this.element.valid())
                        return;
                }
                var method = this.element.attr("data-wgt-submit-method");
                var url = this.element.attr("action");
                var data = this.element.serializeJson();

                var needblock = !(this.element.attr("data-wgt-submit-options-block") === "false");
                var needreload = !(this.element.attr("data-wgt-submit-options-reload") === "false");

                var wgtsubstart = this.element.attr('data-wgt-submit-options-start');
                var substart = _getwgtrecall(wgtsubstart);
                if (substart) {
                    if (!substart(this.element, data))
                        return;
                }

                var wgtrecall = this.element.attr('data-wgt-submit-options-recall');
                var recall = _getwgtrecall(wgtrecall);
                //                if (!!wgtrecall) {
                //                    var recallStr = wgtrecall.split(".");
                //                    for (i = 0; i < recallStr.length; i++) {
                //                        if (i == 0) {
                //                            recall = window[recallStr[i]];
                //                        } else {
                //                            recall = recall[recallStr[i]];
                //                        }
                //                    }
                //                }
                var el = this.element;
                var blockEl;
                if (needblock)
                    blockEl = el.parent();
                var loadBtn = this.element.find(".demo-loading-btn").length == 1 ? this.element.find(".demo-loading-btn") : false;

                $.AjaxPJson(url, method, data, function (d) {
                    if (needreload) {
                        var defineEl = $(d).find("#" + el.attr("id"));
                        gl.wgt.scan(defineEl);
                        el.replaceWith(defineEl)
                    }
                    if (recall)
                        recall(el, d, data);
                }, function (r) {
                    Modal.alert('[' + r + ']');
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

        gl.wgt.set('mw-submitService', {

            init: function () {
                if (this.element.context.tagName !== "FORM") {
                    window.alert("[mw-submit] Must be wgt to [FORM]");
                } else {
                    //                    this.initPageCtrl();
                    this.element.on("submit", this.submit.bind(this));
                }
            },
            submit: function (e) {
                e.preventDefault();

                if (!!this.element.valid) {
                    if (!this.element.valid())
                        return;
                }
                var method = this.element.attr("data-wgt-submit-method");
                var url = "/Services/MWMainServiceHandler.ashx"; // this.element.attr("action");
                //                this.element.attr("action", "");
                var data = this.element.serializeJson();

                data["action"] = this.element.attr("action");

                var needblock = !(this.element.attr("data-wgt-submit-options-block") === "false");
                var needreload = !(this.element.attr("data-wgt-submit-options-reload") === "false");

                var wgtsubstart = this.element.attr('data-wgt-submit-options-start');
                var substart = _getwgtrecall(wgtsubstart);
                if (substart) {
                    if (!substart(this.element, data))
                        return;
                }

                var wgtrecall = this.element.attr('data-wgt-submit-options-recall');
                var recall = _getwgtrecall(wgtrecall);

                var el = this.element;
                var blockEl;
                if (needblock)
                    blockEl = el.parent();
                var loadBtn = this.element.find(".demo-loading-btn").length == 1 ? this.element.find(".demo-loading-btn") : false;

                $.AjaxPSJson(url, method, data, function (d) {
                    if (needreload) {
                        var defineEl = $(d).find("#" + el.attr("id"));
                        gl.wgt.scan(defineEl);
                        el.replaceWith(defineEl)
                    }
                    if (recall)
                        recall(el, d, data);
                }, function (r) {
                    Modal.alert('[' + r + ']');
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
            }
        });

        gl.wgt.set('mw-submit-completecardispatch', {
            init: function () {
                this.element.on("click", this.completeDispatch.bind(this));
            },
            completeDispatch: function (e) {
                e.preventDefault();
                var disId = this.element.attr("data-wgt-submit-completecardispatch-disid");

                Modal.confirm({
                    msg: "请确认车辆回场，终端回收！是否继续完成本班次？",
                    title: "车辆班次完成",
                    btnok: "继续",
                    btncl: "取消"
                }).on(function (r) {
                    if (r) {
                        $("#mwDisId").val(disId);
                        $("#mwTxtIsSubmit").val("");
                        $("#mwFrmDispList").submit();
                        $("#mwFrmCarDisp").submit();
                        //                        Modal.alert('车辆调度已提交。');
                    } else {
                    }
                });
            }


        });

        gl.wgt.set('mw-reload', {
            init: function () {
                this.element.click(this.click.bind(this));
            },
            click: function (e) {
                e.preventDefault();
                var form = $("#" + this.element.attr('data-wgt-reload-formid'));
                if (form.is("form")) {
                    form.submit();
                }
            }
        });

        gl.wgt.set('mw-submit-page', {
            _url: "",
            _method: "",
            init: function () {
                this.initPageCtrl();

            },
            click: function (e) {
                e.preventDefault();
            },
            initPageCtrl: function () {
                _url = this.element.attr("data-wgt-submit-url");
                _method = this.element.attr("data-wgt-submit-method");

                var el = this.element;
                var $this = this;
                el.find('.dataTables_paginate .pagination a').on("click", function (e) {
                    e.preventDefault();

                    if ($(this).hasClass("disabled"))
                        return;
                    var curPage = $(this).attr("data-wgt-page");
                    el.find(".mw_curpage").val(curPage)
                    $this.getPageData(curPage);
                });
            },
            getPageData: function (p) {
                var data = {};
                data["page"] = p;
                var el = this.element;

                var blockEl = el.parent();
                var wgtrecall = this.element.attr('data-wgt-submit-options-recall');
                var recall = _getwgtrecall(wgtrecall);
                $.AjaxPJson(_url, _method, data, function (d) {
                    var defineEl = $(d).find("#" + el.attr("id"));

                    gl.wgt.scan(defineEl);
                    el.replaceWith(defineEl)
                    if (recall)
                        recall(el, d, data);
                }, function (r) {
                    Modal.alert('[' + r + ']');
                }, function () {
                    //                    if (loadBtn)
                    //                        loadBtn.button('loading');
                    //                    if (blockEl)
                    App.blockUI(blockEl);
                }, function () {
                    //                    if (loadBtn)
                    //                        loadBtn.button('reset');
                    //                    if (blockEl)
                    App.unblockUI(blockEl);
                });
            }
        });
    }

    var _testFunc = function (s) {
        window.alert(12345 + " " + s)
    }
    var _redirectPage = function (s) {
        window.location.hash = s;
    }
    var _getwgtrecall = function (wgtrecall) {
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
        return recall;
    }
    var _recallCarDispatch = function (el, netData, locData) {
        $("#mwFrmDispList").submit();
        if (!!locData.issubmit)
            Modal.alert('车辆调度已提交。'); //.on(function (e) {});
    }
    var _subAuthorize = function (el, netData, locData) {
        //        window.alert(netData.Value + " " + locData)
        if (netData.Result == 1) {
            Modal.alert(netData.Value);
        } else {
            Modal.alert(netData.Value).on(function (e) {
                _redirectPage("Inventory/InvAuthorize.aspx");
            });
        }
    }
    var _validAuthorize = function (el, data) {
        //        if (data.remark.trim().length == 0) {
        //            Modal.alert("请填写说明。").on(function (e) {
        //                el.find('input[name="remark"]').focus();
        //            });
        //           
        //            return false;
        //        }
        //        return false;
        return true;
    }


    return {
        init: function () {
            initHelper();
            //            initFromPageEvent();
        },

        testFunc: _testFunc,
        recallCarDispatch: _recallCarDispatch,
        subAuthorize: _subAuthorize,
        validAuthorize: _validAuthorize
    };
} ();

/*
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
*/