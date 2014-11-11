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
    }
});

if (!Function.prototype.bind) {
	Function.prototype.bind = function(oThis) {
		if (typeof this !== "function") {
			// closest thing possible to the ECMAScript 5 internal IsCallable
			// function
			throw new TypeError(
					"Function.prototype.bind - what is trying to be bound is not callable");
		}
		var aArgs = Array.prototype.slice.call(arguments, 1), fToBind = this, fNOP = function() {
		}, fBound = function() {
			return fToBind.apply(this instanceof fNOP && oThis ? this : oThis,
					aArgs.concat(Array.prototype.slice.call(arguments)));
		};
		fNOP.prototype = this.prototype;
		fBound.prototype = new fNOP();
		return fBound;
	};
} 

var gl = {};

gl.wgt = {

    /**
     * Scan for, and initialize wgts
     * @param {...*} varArgs
     */
    scan: function(varArgs) {
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
    set: function(name, proto) {
        this._wgtObjects[name] = function(){};
        this._wgtObjects[name].prototype = proto;
        this._wgtObjects[name].prototype.name = name;
        this._wgtObjects[name].prototype.reinit = false;
        this._wgtObjects[name].prototype.getUniqueID = "";
    },

    /**
     * @param name
     * @returns {Object}
     */
    obj: function(name) {
        return this._wgtObjects[name];
    },

    /**
     * Get wgt instances by specifying an HTML element
     * @param {string|HTMLElement} element
     * @param {string} name
     * @return {Object|Array|boolean}
     */
    get: function(element, name) {
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
    count: function(element) {
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
    append: function(element, name) {
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
    extend: function(wgtInstance, wgtName) {
        var extendInstance = this.get(wgtInstance.element, wgtName);
        if (!extendInstance) {
            throw new Error('Wgt not found on element. Cannot extend wgt: ', wgtName);
        }
        $.extend(wgtInstance, extendInstance);
    },


    _wgtObjects: {},

    _initElementWgts: function(element) {
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

    _construct: function(element, name) {
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

    _uniqueID: function() {
        var identifier = window.location.pathname + this.name + '/';

        identifier += (this.element.attr('id')) ?
                        this.element.attr('id') :
                        $('[data-wgt$="' + this.name + '"]').index(this.element);

        return identifier;
    },

    _register: function(element, name, instance) {
        var data = element.data();
        data.wgtInstances = data.wgtInstances || {};
        data.wgtInstances[name] = instance;
    }
};


// Initialize widgets in body on document ready
$(function() {
    gl.wgt.scan();
});



//gl.wgt.set('validate1', {
//
//    init: function() {
//        this.jqValidator = this.element.validate(this.getValidateSettings());
//
//        this.emailformValidatorFix();
//        this.supportDomAutocomplete();
//
//        this.element.on(gl.event.FORM_ERRORS, function(e, widget, errors) {
//            this.showErrors(errors);
//        }.bind(this));
//    },
//
//    getValidateSettings: function() {
//        var settings = this.validateSettings;
//        return $.extend(settings, this.getDataValidateSettings(this.element.data('rules')));
//    },
//
//    getDataValidateSettings: function(settingsName) {
//        var rules = {};
//        if (settingsName) {
//            rules = gl.validationSettings[settingsName];
//            if (!rules) {
//                throw new Error('Undefined validate settings set: ' + settingsName);
//            }
//        }
//        return rules;
//    },
//
//    // Regular Django forms don't have a required class or attribute on form inputs
//    emailformValidatorFix: function() {
//        if (this.element.hasClass('validate-fix')) {
//            var field, fields = $('.item[data-validator]');
//            for (var i = 0, m = fields.length; i < m; i++) {
//                field = $(fields[i]);
//                field.find(':input').addClass(field.data('validator'));
//            }
//        }
//    },
//
//    validateSettings: {
//        highlight: function(element, errorClass, validClass) {
//            var el = $(element);
//            el = (el.hasClass('checkbox-enable-field')) ? el.closest('input') : el.closest('.item');
//            el.addClass(errorClass).removeClass(validClass);
//        },
//        unhighlight: function(element, errorClass, validClass) {
//            var el = $(element);
//            el = (el.hasClass('checkbox-enable-field')) ? el.closest('input') : el.closest('.item');
//            el.removeClass(errorClass).addClass(validClass);
//        },
//        errorPlacement: function(error, element) {
//            var wrap = (element.hasClass('checkbox-enable-field')) ?
//                            element.parents('.checkbox-enable-field-wrap:first') :
//                            element.parents('.wrap:first'),
//                help = wrap.find('.help:first');
//
//            if (wrap.length && help.length) {
//                error.insertBefore(help);
//            } else if (wrap.length) {
//                error.appendTo(wrap);
//            } else {
//                error.insertAfter(element);
//            }
//        }
//    },
//
//    supportDomAutocomplete: function() {
//        this.element.on('DOMAutoComplete', ':input', function() {
//            $(this).trigger('change');
//        });
//    },
//
//    showErrors: function(errors) {
//        this.jqValidator.showErrors(errors);
//    }
//
//});


