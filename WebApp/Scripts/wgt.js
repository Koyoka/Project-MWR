


gl.wgt.set('t', {
    init: function () {
        this.element.on("click", this.testClick.bind(this));
    },
    testClick: function (e) {
        $.AjaxPostURL("Test.aspx", "TestFunc", {
                a: 1,
                b: 2
            },
            function (data) {
                // window.location.href = "COperatOrder.aspx?OrderId=" + data;
            }, function (data) {
                window.alert(data);
            }
        );
    }
});

gl.validationSettings = {};

gl.wgt.set('validate', {
    init: function () {
        this.element.validate(this.getValidateSettings());
    },
    getValidateSettings: function () {

        var settings = this.validateSettings;
        return $.extend(settings, this.getDataValidateSettings(this.element.data('rules')));
    },
    getDataValidateSettings: function (settingsName) {
        var rules = {};
        if (settingsName) {
            rules = gl.validationSettings[settingsName];
            if (!rules) {
                throw new Error('Undefined validate settings set: ' + settingsName);
            }
        }
        return rules;
    },
    validateSettings: {
        //			highlight: function(element, errorClass, validClass) {
        //	            var el = $(element);
        //	            el = (el.hasClass('checkbox-enable-field')) ? el.closest('input') : el.closest('.item');
        //	            el.addClass(errorClass).removeClass(validClass);
        //	        },
        //	        unhighlight: function(element, errorClass, validClass) {
        //	            var el = $(element);
        //	            el = (el.hasClass('checkbox-enable-field')) ? el.closest('input') : el.closest('.item');
        //	            el.removeClass(errorClass).addClass(validClass);
        //	        },
        errorClass: "error",
        errorElement: "span",
        errorPlacement: function (error, element) {
           
            var wrap1 = element.parents(".inputBox").children(".msg");
            if (wrap1.length) {
                error.appendTo(wrap1);
            }
        }
    }
});