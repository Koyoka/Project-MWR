
var MW_AppHelper = {

    SetCurMenu: function (menuBarId, menuSubBarId) {
        $("#" + menuBarId).addClass("active");
        if (menuSubBarId != "undefined")
            $("#" + menuSubBarId).addClass("active");
    },
    set: function () {
        window.alert(2)
    }

};

var gl = {};
var Custom = function () {

    // private functions & variables

    var myFunc = function (text) {
        alert(text);
    }

    var initCustModal = function (modelId) {

        //        $(function () {
        window.Modal = function () {
            var reg = new RegExp("\\[([^\\[\\]]*?)\\]", 'igm');
            var alr = $(modelId ? "#" + modelId : "#portlet-config");
            var ahtml = alr.html();

            //关闭时恢复 modal html 原样，供下次调用时 replace 用
            //var _init = function () {
            //	alr.on("hidden.bs.modal", function (e) {
            //		$(this).html(ahtml);
            //	});
            //}();

            /* html 复原不在 _init() 里面做了，重复调用时会有问题，直接在 _alert/_confirm 里面做 */


            var _alert = function (options) {
                alr.html(ahtml); // 复原
                alr.find('.ok').removeClass('btn-success').addClass('btn-primary');
                alr.find('.cancel').hide();
                _dialog(options);

                return {
                    on: function (callback) {
                        if (callback && callback instanceof Function) {
                            alr.find('.ok').click(function () { callback(true) });
                        }
                    }
                };
            };

            var _confirm = function (options) {
                alr.html(ahtml); // 复原
                alr.find('.ok').removeClass('btn-primary').addClass('btn-success');
                alr.find('.cancel').show();
                _dialog(options);

                return {
                    on: function (callback) {
                        if (callback && callback instanceof Function) {
                            alr.find('.ok').click(function () { callback(true) });
                            alr.find('.cancel').click(function () { callback(false) });
                        }
                    }
                };
            };

            var _dialog = function (options) {
                if (typeof options === "string") {
                    options = {
                        msg: options
                    }
                }
                var ops = {
                    msg: "提示内容",
                    title: "消息",
                    btnok: "确定",
                    btncl: "取消"
                };

                $.extend(ops, options);

                //                    console.log(alr);

                var html = alr.html().replace(reg, function (node, key) {
                    return {
                        Title: ops.title,
                        Message: ops.msg,
                        BtnOk: ops.btnok,
                        BtnCancel: ops.btncl
                    }[key];
                });

                alr.html(html);
                alr.modal({
                    width: 500,
                    backdrop: 'static'
                });
            }

            return {
                alert: _alert,
                confirm: _confirm
            }

        } ();
        //        });

        //        Modal.alert(
        //        {
        //            msg: '内容',
        //            title: '标题',
        //            btnok: '确定',
        //            btncl: '取消'
        //        });

        //            // 如需增加回调函数，后面直接加 .on( function(e){} );
        //            // 点击“确定” e: true
        //            // 点击“取消” e: false
        //            Modal.confirm(
        //        {
        //            msg: "是否删除角色？"
        //        })
        //        .on(function (e) {
        //            alert("返回结果：" + e);
        //        });
    }

    var initCommonWGT = function () {

    }
    var initjQueryPlus = function () {
        $.fn.setGroupDebug = function () {
            this.attr('submit-group-debug', true);
        };
        $.fn.setGroup = function (s, allowCommon) {
            if (s)
                this.data('submit-group', s);
            //            this.data('eleven', 'aa');
//            window.alert(allowCommon != undefined)
            if (allowCommon != undefined)
                this.data('submit-allowCommon', allowCommon);
            else
                this.data('submit-allowCommon',true);
//            window.alert(!!this.data('submit-allowCommon'))
        };
        $.fn.serializeGroupJson = function () {
            var mw_group = this.data('submit-group');
            var allowCommon = !!this.data('submit-allowCommon');
            var serializeObj = {};
            var $this = this;
            //            window.alert(mw_group)
            $(this.serializeArray()).each(function () {
                if (!mw_group) {
                    serializeObj[this.name] = this.value;
                    //                } else if ($('[name="' + this.name + '"]', $this).attr('submit-group') == mw_group) {
                    //                } else if ($('[name="' + this.name + '"]', $this).attr('submit-group') == mw_group) {
                    //                    serializeObj[this.name] = this.value;
                    //                    var s = "";

                } else if (allowCommon && $('[name="' + this.name + '"]', $this).attr('submit-group').indexOf('common') != -1/* == 'common'*/) {
                    serializeObj[this.name] = this.value;
                } else {
                    var ctrl = $('[name="' + this.name + '"]', $this);
                    for (i = 0; i < ctrl.length; i++) {
                        var tempCtrl = ctrl.eq(i);
                        var g = tempCtrl.attr('submit-group');
                        if (g) {
                            var gnames = g.split(/\s+/);
                            for (ii = 0; ii < gnames.length; ii++) {
                                if (gnames[ii] == mw_group) {
                                    serializeObj[this.name] = this.value;
                                    break;
                                }
                            }
                        }

                    }
                }

            });
            this.attr('submit-group', '')
            if (!!mw_group) {
                serializeObj['_Group'] = mw_group;
            }
            if (this.attr('submit-group-debug'))
                window.alert(JSON.stringify(serializeObj) + " Group[" + mw_group + "]");
            return serializeObj;
        };
        $.fn.serializeJson = function () {
            var serializeObj = {};
            var $this = this;
            $(this.serializeArray()).each(function () {
                //                window.alert($('[name="' + this.name + '"]', $this).attr('name'))
                serializeObj[this.name] = this.value;
            });
            return serializeObj;
        };
    }
    var initCustAjax = function () {
        jQuery.extend({

            AjaxPostURL: function (URL, Func, Params, SCallFunc, ECallFunc, type) {
                var requestType = type != "" && type != "text" ? "json" : "text";
                if (Params == null) Params = {};
                Params["_AjaxRequest"] = "AjaxRequest";
                Params["Method"] = Func;
                $.post(URL, Params,
                 function (data, success) {
                     if (success == "success") {
                         if (requestType == "json") {
                             if (data.Result == 0) {
                                 SCallFunc(data.Value);
                             }
                             else {
                                 ECallFunc(data.Value);
                             }
                         }
                         else {
                             SCallFunc(data);
                         }
                     }
                     else {
                         ECallFunc(data);
                     }
                     SCallFunc = null;
                     ECallFunc = null;
                     requestType = null;
                     Params = null;
                     success = null;
                     data = null;
                 },
                    requestType);
            },
            AjaxPJson: function (URL, FUNC, JSONDATA, SCallFunc, ECallFunc, BF, CF) {
                JSONDATA["_AjaxRequest"] = "AjaxRequest";
                JSONDATA["_Method"] = FUNC;
                $.ajax({
                    cache: true,
                    //                    dataType: "json",
                    type: "POST",
                    url: URL,
                    data: JSONDATA,
                    async: false,
                    error: function (data) {
                        if (typeof data === "object") {
                            if (data.Result == 0) {
                                SCallFunc(data);
                            }
                            else {
                                if (!!data.Value)
                                    ECallFunc(data.Value);
                                else
                                    ECallFunc("服务器连接错误，请联系管理员");
                            }
                        } else {
                            ECallFunc(data);
                        }

                    },
                    success: function (data) {
                        if (typeof data === "object") {
                            if (data.Result == 0) {
                                SCallFunc(data);
                            }
                            else {
                                ECallFunc(data.Value);
                            }
                        } else {
                            SCallFunc(data);
                        }
                    },
                    beforeSend: function () {
                        if (BF)
                            BF();
                    },
                    complete: function () {
                        if (CF)
                            CF();
                    }
                });
            },
            AjaxPSJson: function (URL, FUNC, JSONDATA, SCallFunc, ECallFunc, BF, CF) {

                $.ajax({
                    cache: true,
                    dataType: "json",
                    type: "POST",
                    url: URL,
                    data: JSONDATA,
                    async: false,
                    error: function (data) {
                        if (typeof data === "object") {
                            if (data.Error == 0) {
                                SCallFunc(data);
                            }
                            else {
                                if (!!data.ErrMsg)
                                    ECallFunc(data.ErrMsg);
                                else
                                    ECallFunc("服务器连接错误，请联系管理员");
                            }
                        } else {
                            ECallFunc(data);
                        }

                    },
                    success: function (data) {
                        if (typeof data === "object") {
                            if (data.Error == 0) {
                                SCallFunc(data.Result);
                            }
                            else {
                                ECallFunc(data.ErrMsg);
                            }
                        } else {
                            SCallFunc(data);
                        }
                    },
                    beforeSend: function () {
                        if (BF)
                            BF();
                    },
                    complete: function () {
                        if (CF)
                            CF();
                    }
                });
            }

        });
    }
    var initFunctionBind = function () {
        if (!Function.prototype.bind) {
            Function.prototype.bind = function (oThis) {
                if (typeof this !== "function") {
                    // closest thing possible to the ECMAScript 5 internal IsCallable
                    // function
                    throw new TypeError(
					    "Function.prototype.bind - what is trying to be bound is not callable");
                }
                var aArgs = Array.prototype.slice.call(arguments, 1), fToBind = this, fNOP = function () {
                }, fBound = function () {
                    return fToBind.apply(this instanceof fNOP && oThis ? this : oThis,
					    aArgs.concat(Array.prototype.slice.call(arguments)));
                };
                fNOP.prototype = this.prototype;
                fBound.prototype = new fNOP();
                return fBound;
            };
        }

    }
    var initGLWgt = function () {
        gl.wgt = {

            /**
            * Scan for, and initialize wgts
            * @param {...*} varArgs
            */
            scan: function (varArgs) {
                var scan;

                if (arguments.length === 0) {
                    this.scan(document.documentElement);
                }

                for (var i = 0, m = arguments.length; i < m; i++) {

                    // Find all widget elements for element's children
                    var element = $(arguments[i]);
                    scan = element.find('[data-wgt]');

                    // Add element if it contains a widget
                    if (element.attr('data-wgt')) {
                        scan = scan.add(element);
                    }

                    for (var ii = 0, mm = scan.length; ii < mm; ii++) {
                        this._initElementWgts(scan[ii]);
                    }
                }
            },

            /**
            * Set a widget
            * @param {string} name
            * @param {Object} proto
            */
            set: function (name, proto) {
                this._wgtObjects[name] = function () { };
                this._wgtObjects[name].prototype = proto;
                this._wgtObjects[name].prototype.name = name;
                this._wgtObjects[name].prototype.reinit = false;
                this._wgtObjects[name].prototype.getUniqueID = "";
            },

            /**
            * @param name
            * @returns {Object}
            */
            obj: function (name) {
                return this._wgtObjects[name];
            },

            /**
            * Get wgt instances by specifying an HTML element
            * @param {string|HTMLElement} element
            * @param {string} name
            * @return {Object|Array|boolean}
            */
            get: function (element, name) {
                var data;

                element = $(element);

                // No matches for selector
                if (!element.length) {
                    return false;
                }

                // Get first matching element
                data = $(element).eq(0).data();

                // No wgts defined on this element
                if (!data.wgtInstances) {
                    return false;
                }

                // Get wgt instance by name
                if (name) {
                    return data.wgtInstances[name] || false;
                }

                // Get only matching wgt instance. Potentially dangerous when
                // user expects one wgt while there are multiple wgts defined.
                if (this.count(element) === 1) {
                    return data.wgtInstances[data.wgt];
                }

                // Get ALL wgt instances in Object
                return data.wgtInstances.length ? data.wgtInstances : false;
            },

            /**
            * Number of wgts set to an element
            * @param element
            * @return {number}
            */
            count: function (element) {
                var count = 0, instances = $(element).data('wgtInstances');
                for (var k in instances) {
                    if (instances.hasOwnProperty(k)) {
                        count++;
                    }
                }
                return count;
            },

            /**
            * Add and initialize a wgt
            * @param element
            * @param {string} name
            * @return {Object} instance
            */
            append: function (element, name) {
                var instance;
                element = $(element);
                if (typeof this._wgtObjects[name] === 'function') {
                    instance = this._construct(element, name);
                } else {
                    throw new Error('Widget undefined: ' + name);
                }
                return instance;
            },

            /**
            * @param {Object} wgtInstance
            * @param {string} wgtName
            */
            extend: function (wgtInstance, wgtName) {
                var extendInstance = this.get(wgtInstance.element, wgtName);
                if (!extendInstance) {
                    throw new Error('Wgt not found on element. Cannot extend wgt: ', wgtName);
                }
                $.extend(wgtInstance, extendInstance);
            },

            _wgtObjects: {},

            _initElementWgts: function (element) {
                var widgets, name;
                element = $(element);

                // Find individual widget names
                widgets = element.attr('data-wgt');
                widgets = widgets.split(/\s+/);

                // Walk through widgets
                for (var i = 0, l = widgets.length; i < l; i++) {
                    name = widgets[i];

                    if (!name) { continue; }
                    this.append(element, name);
                }
            },

            _construct: function (element, name) {
                var instance = this.get(element, name);
                if (!instance) {
                    instance = new this._wgtObjects[name]();
                    instance.element = element;
                    //            var iid = this._uniqueID.bind(instance);
                    //            var iid = this._uniqueID.bind(this);
                    //            window.alert(iid)
                    instance.getUniqueID = this._uniqueID.bind(instance);
                    this._register(element, name, instance);
                    if ($.isFunction(instance.init)) {
                        instance.init();
                    }
                } else if (instance.reinit && $.isFunction(instance.init)) {
                    instance.init();
                }
                return instance;
            },

            _uniqueID: function () {
                var identifier = window.location.pathname + this.name + '/';

                identifier += (this.element.attr('id')) ?
                        this.element.attr('id') :
                        $('[data-wgt$="' + this.name + '"]').index(this.element);

                return identifier;
            },

            _register: function (element, name, instance) {
                var data = element.data();
                data.wgtInstances = data.wgtInstances || {};
                data.wgtInstances[name] = instance;
            }
        };



    }

    // public functions
    return {

        //main function
        init: function () {
            //initialize here something.    
            initjQueryPlus();
            initCustModal();

            initFunctionBind();
            initGLWgt();
            initCustAjax();
            initCommonWGT();

        },
        scan: function () {
            gl.wgt.scan();
        },
        //some helper function
        doSomeStuff: function () {
            myFunc();
        }

    };

} ();
