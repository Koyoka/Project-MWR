/*jshint globalstrict: true */
/*global $, _gaq, google */

'use strict';


var lyr = {};
/*jshint globalstrict: true */
/*global lyr */

lyr.event = {

    CONTRIBUTORS_ADD            : 'CONTRIBUTORS_ADD',
    CONTRIBUTORS_LIST           : 'CONTRIBUTORS_LIST',

    CREATOR_BUTTON_ADD          : 'CREATOR_BUTTON_ADD',
    CREATOR_BUTTON_ERROR        : 'CREATOR_BUTTON_ERROR',
    CREATOR_BUTTON_CREATE       : 'CREATOR_BUTTON_CREATE',
    CREATOR_BUTTON_DELETE       : 'CREATOR_BUTTON_DELETE',
    CREATOR_CAROUSEL_META_SAVE  : 'CREATOR_CAROUSEL_META_SAVE',
    CREATOR_CAROUSEL_META_SKIP  : 'CREATOR_CAROUSEL_META_SKIP',
    CREATOR_CAROUSEL_TILE_REMOVE: 'CREATOR_CAROUSEL_TILE_REMOVE',
    CREATOR_EDITOR_DIRTY        : 'CREATOR_EDITOR_DIRTY',
    CREATOR_EDITOR_SAVED        : 'CREATOR_EDITOR_SAVED',
    CREATOR_PAGES_SELECT        : 'CREATOR_PAGES_SELECT',
    CREATOR_PAGES_SELECT_SUBMIT : 'CREATOR_PAGES_SELECT_SUBMIT',
    CREATOR_PROCESSING_CONFIRM  : 'CREATOR_PROCESSING_CONFIRM',
    CREATOR_UPLOAD_INIT         : 'CREATOR_UPLOAD_INIT',
    CREATOR_UPLOAD_COMPLETE     : 'CREATOR_UPLOAD_COMPLETE',

    FORM_ERROR                  : 'FORM_ERROR',
    FORM_ERRORS                 : 'FORM_ERRORS',
    FORM_BEFORE_SUBMIT          : 'FORM_BEFORE_SUBMIT',
    FORM_SUBMIT                 : 'FORM_SUBMIT',
    FORM_SUCCESS                : 'FORM_SUCCESS',

    INLINE_UPLOAD_501           : 'INLINE_UPLOAD_501',
    INLINE_UPLOAD_ERROR         : 'INLINE_UPLOAD_ERROR',
    INLINE_UPLOAD_PICKED        : 'INLINE_UPLOAD_PICKED',
    INLINE_UPLOAD_READY         : 'INLINE_UPLOAD_READY',
    INLINE_UPLOAD_SUCCESS       : 'INLINE_UPLOAD_SUCCESS',

    LIGHTBOX_AJAX_ERROR         : 'LIGHTBOX_AJAX_ERROR',
    LIGHTBOX_AJAX_SUCCESS       : 'LIGHTBOX_AJAX_SUCCESS',
    LIGHTBOX_CLOSE              : 'LIGHTBOX_CLOSE',
    LIGHTBOX_CLOSE_BY_USER      : 'LIGHTBOX_CLOSE_BY_USER', // Closed by clicking the X or the Vitrage
    LIGHTBOX_OPEN               : 'LIGHTBOX_OPEN',

    LIVE                        : 'keydown keyup paste change', // Live updating other sections

    PAGE_DELETED                : 'PAGE_DELETED',
    PAGE_LOAD_START             : 'PAGE_LOAD_START',
    PAGE_LOAD_COMPLETE          : 'PAGE_LOAD_COMPLETE',
    PAGE_RENAME                 : 'PAGE_RENAME',
    PAGE_REORDER                : 'PAGE_REORDER',
    PAGE_UPLOAD_WIZARD_COMPLETE : 'PAGE_UPLOAD_WIZARD_COMPLETE',

    PAYMENT_BUNDLE_CHECKED      : 'PAYMENT_BUNDLE_CHECKED',
    PAYMENT_BUNDLE_VOLUME       : 'PAYMENT_BUNDLE_VOLUME',

    PLACEHOLDER_BLUR            : 'PLACEHOLDER_BLUR',

    SYSTEM_MESSAGE_READ         : 'SYSTEM_MESSAGE_READ',

    UPLOAD_FILE_PICKED          : 'UPLOAD_FILE_PICKED',
    UPLOAD_PAGE_CANCELED        : 'UPLOAD_PAGE_CANCELED',
    UPLOAD_PAGE_SERIALIZE       : 'UPLOAD_PAGE_SERIALIZE',
    UPLOAD_PAGE_UPLOADED        : 'UPLOAD_PAGE_UPLOADED',

    WIDGET_FORM_SAVE            : 'WIDGET_FORM_SAVE',
    WIDGET_FORM_NOCHANGE        : 'WIDGET_FORM_NOCHANGE',
    WIDGET_FORM_UPDATE          : 'WIDGET_FORM_UPDATE',
    WIDGET_META_SET             : 'WIDGET_META_SET',
    WIDGET_PREVIEW_READY        : 'WIDGET_PREVIEW_READY',
    WIDGET_PREVIEW_RENDERED     : 'WIDGET_PREVIEW_RENDERED',
    WINDOW_RESIZE               : 'WINDOW_RESIZE',
    WINDOW_RESIZE_DELAY         : 'WINDOW_RESIZE_DELAY' // Window is resized, but with a short delay so it doesn't trigger as often

};


/**
 * Google Analytics event tracking
 * @param {string} action
 * @param {string} category
 * @param {string|null=} label
 * @param {number|null=} value
 * @param {boolean|null=} nonInteraction
 */
lyr.trackEvent = function(category, action, label, value, nonInteraction) {
    if (typeof _gaq === 'undefined') {
        return;
    }
    if (typeof label === 'undefined') { label = null; }
    if (typeof value === 'undefined') { value = null; }
    if (typeof nonInteraction === 'undefined') { nonInteraction = true; }
    _gaq.push(['_trackEvent', category, action, label, value, nonInteraction]);
};


/**
 * Simple wrapper for localStorage
 * @param {string} key
 * @param {*?} value
 * @return {*}
 */
lyr.storage = function(key, value) {
    if (!key || !localStorage || !localStorage.setItem) {
        return null;
    } else if (value === null) {
        localStorage.removeItem(key);
        return null;
    } else if (value) {
        localStorage.setItem(key, value);
        return value;
    } else {
        return localStorage.getItem(key);
    }
};


/**
 * Report Javascript errors
 * Exclude unsupported browsers
 */
if (!$('html').hasClass('ie-nosupport')) {
    window.onerror = function(message, file, line) {
        if (message && file) {
            var label = location.href + ', file: ' + file + ', ln:' + line;
            lyr.trackEvent('Exception', message, label);
            if (console && console.error) {
                console.error(label);
            }
        }
    };
}


/**
 * Assert that a jQuery selector matches a number of elements.
 * Usage: $('foo').assert(); // Throw error when $('foo').length !== 1
 */
$.fn.assert = function(min, max) {
    min = (typeof min === 'undefined') ? 1 : min;
    max = (typeof max === 'undefined') ? min : max;
    if (this.length < min || this.length > max) {
        console.warn(this);
        throw new Error('' +
            '"' + this.selector + '" should match at least ' + min +
            ' and at most ' + max + ' elements, but matched ' +
            this.length + ' elements.');
    }
    return this;
};


/**
 * Is the element within the viewport
 * @return {boolean}
 */
$.fn.isInViewport = function() {
    var element         = this,
        elementBounds   = element.offset(),
        windowObj       = $(window),
        viewport        = {};

    viewport.top    = windowObj.scrollTop();
    viewport.bottom = viewport.top + windowObj.height();

    elementBounds.bottom = elementBounds.top + element.outerHeight();

    return (!(viewport.bottom < elementBounds.top || viewport.top > elementBounds.bottom));
};


/**
 * @param {string|jQuery} html
 * @returns {jQuery}
 */
lyr.tpl = function(html) {
    return (typeof html === 'string') ? $($.parseHTML($.trim(html))) : html;
};


/**
 * Shortcut for closing lightboxes that may need saving before exiting.
 * @param {boolean} dirty
 * @param {lyr.Lightbox} lightbox
 */
lyr.confirmDirtyClose = function(dirty, lightbox) {
    var body, okclose, title = 'Unsaved Changes';
    body = '<strong>You have unsaved changes.</strong><br>' +
           'Do you want to exit without saving?';
    okclose = { ok: function() { lightbox.close(); }};
    if (dirty) {
        lyr.confirm(title, body, okclose);
    } else {
        lightbox.close();
    }
};


// Global XHR settings
$.ajaxSetup({

    /**
     * Defaults for showing server errors when doing Ajax calls.
     * Call manually using $.ajaxSettings.error(xhr, status);
     */
    error: function(xhr, status) {
        if (status === 'abort') {
            return false;
        } else if (xhr.status === 403) {
            lyr.alert('No access', 'We’re sorry, you do not have access to this functionality.');
        } else if (xhr.status === 404) {
            lyr.alert('Page not found', 'We’re sorry, we could not find the page. Please try again later.');
        } else if (xhr.status === 500) {
            lyr.alert('Server Error', 'We’re sorry, we encountered a server error while processing your request. We will look into this. Please try again later.');
        } else if (status === 'parsererror') {
            lyr.alert('Parse Error', 'We’re sorry, we were unable to process this request. Please try again later.');
        } else if (status === 'timeout') {
            lyr.alert('Timeout Error', 'We’re sorry, the page did not load in time. Please try again later.');
        }
    },

    /**
     * Include a CSRF token in ajax-submitted forms
     * https://docs.djangoproject.com/en/dev/ref/contrib/csrf/#ajax
     */
    crossDomain: false,
    beforeSend: function(xhr, settings) {
        if (String(settings.type) !== 'GET') {
            xhr.setRequestHeader('X-CSRFToken', $.cookie('csrftoken'));
        }
    }

});


// Cache local <script> requests.
// Prevents delay in rendering widgets in lightboxes
$.ajaxPrefilter('script', function(options, origOptions, xhr) {
    // Only local scripts
    if (!options.crossDomain) {
        options.cache = true; // Encourage browser cache
        lyr.xhrScriptsLoaded = lyr.xhrScriptsLoaded || [];
        if (-1 === $.inArray(options.url, lyr.xhrScriptsLoaded)) {
            lyr.xhrScriptsLoaded.push(options.url);
        } else {
            xhr.abort(); // Already loaded
        }
    }
});


// ES5 bind() shim
if (!Function.prototype.bind) {
    Function.prototype.bind = function(scope) {
        var args, self, Proto, bound, applyto;
        args = Array.prototype.slice.call(arguments, 1);
        self = this;
        Proto = function() {};
        bound = function() {
            applyto = this instanceof Proto && scope ? this : scope;
            return self.apply(applyto, args.concat(Array.prototype.slice.call(arguments)));
        };
        Proto.prototype = this.prototype;
        bound.prototype = new Proto();
        return bound;
    };
}


lyr.format = {

    // Round float to two decimals
    twodecimals: function(num) {
        return Math.round(num * 100) / 100;
    },

    // Formats a number like 1000 => 1,000, 1501241 => 1,501,241
    intcomma: function(num) {
        num = (String(num)).split('').reverse().join('');
        num = num.replace(/([0-9]{3})([0-9])/g, '$1,$2');
        num = num.split('').reverse().join('');
        return num;
    },

    price: function(num, withhold_cents) {
        var bucks, cents;
        bucks = Math.floor(num);
        cents = Math.floor(num % 1 * 100);
        bucks = this.intcomma(bucks);
        return bucks +  (!withhold_cents ? '.' + (cents < 10 ? '0' : '') + cents : '');
    },

    priceRound: function(num) {
        if (num % 1 === 0) {
            // strip the .00's
            return this.price(parseFloat(num).toFixed(0), true);
        } else {
            return this.price(num);
        }
    },

    pluralize: function(num, single, plural) {
        return (num === 1) ? single || '' : plural || 's';
    },

    sprintf: function() {
        var args = arguments;
        return args[0].replace(/\{(\d+)\}/g, function(match, number) {
            return typeof args[number] !== 'undefined' ? args[number] : match;
        });
    }

};


/**
 * Preload an image
 */
lyr.preloadImage = function(src, callback, errCallback) {
    var image, imageLoaded;

    callback = callback || function() {};

    image = $('<img>').css({position: 'absolute', left: -99999, top: -99999});
    image.attr({src: src});
    image.appendTo(document.body);

    imageLoaded = function() {
        callback(src, image.prop('width'), image.prop('height'));
        image.remove();
    };

    if (image[0].complete) {
        imageLoaded();
    } else {
        image.on('load', imageLoaded);
        image.on('error', function() {
            image.remove();
            if (errCallback) {
                errCallback(src, image);
            }
            throw new Error('Error loading image: ' + src);
        });
    }
};

/**
 * Compare dicts
 */
lyr.isEqualDict = function(a, b) {
    var key;
    for (key in a) {
        if (a.hasOwnProperty(key)) {
            if (a[key] !== b[key]) { return false; }
        }
    }
    for (key in b) {
        if (b.hasOwnProperty(key)) {
            if (a[key] !== b[key]) { return false; }
        }
    }
    return true;
};

/**
 * Toggle loading indicator
 */
lyr.toggleLoading = function(wrapper, isLoading) {
    var loading, buttonset, lastbutton, buttons, buttonMsg;

    wrapper = $(wrapper);
    if (!wrapper.length) {
        return;
    }

    buttons = wrapper.find('button, .button');
    buttons.attr('disabled', isLoading);

    buttonset = buttons.last().parent();
    lastbutton = buttonset.find(buttons).first();
    loading = buttonset.find('.loading');

    buttonMsg = lyr.wgt.get(buttons, 'button-state-toggle');
    if (buttonMsg) {
        buttonMsg.toggleMsg();
    }

    if (isLoading) {
        if (!loading.length) {
            loading = $('<span>').addClass('loading');
            loading.css({opacity: 0}).attr({title: 'Loading…'}); // css(): IE8
            loading.insertBefore(lastbutton).animate({opacity: 1}, 200);
        } else {
            loading.stop().animate({opacity: 1}, 200);
        }
    } else {
        loading.stop().animate({opacity: 0}, 200, function() {
            $(this).remove();
        });
    }
};



/**
 * Styled version of a confirm dialog
 * @namespace settings.cancel
 * @namespace settings.nocancel (no cancel button)
 */
lyr.confirm = function(title, question, settings) {
    var lbsettings,
        lightbox = new lyr.Lightbox(),
        template =
        '<h1>'+title+'</h1>' +
        '<form>' +
        '   <p class="question">' + question + '</p>' +
        '   <div class="buttons">' +
        '       <button class="cancel">Cancel</button>' +
        '       <button class="ok">OK</button>' +
        '   </div>' +
        '</form>';

    template = $(template);

    settings.ok = settings.ok || lightbox.close.bind(lightbox);

    template.find('.ok').on('click', function() {
        settings.ok();
        lightbox.clearCallbacks();
        lightbox.close();
        return false;
    });

    template.find('.cancel').on('click', function() {
        lightbox.close();
        return false;
    });

    // keypress events
    $(document).on('keydown', function(e) {
        switch (e.keyCode) {
            case 27: template.find('.cancel').trigger('click'); break;
            case 13: template.find('.ok').trigger('click'); break;
            default: return true;
        }
    });

    if (settings.nocancel) {
        template.find('.cancel').remove();
    }

    if (settings.yesOrNo) {
        template.find('.ok').html('Yes');
        template.find('.cancel').html('No');
    }

    if (settings.continue_) {
        template.find('.ok').html('Continue');
    }

    lbsettings = $.extend({
        html    : template,
        onclose : settings.cancel,
        width   : settings.width || 320,
        height  : settings.height || 220
    }, settings);

    lightbox.open(lbsettings);
};


lyr.confirmYesNo = function(title, question, settings) {
    settings = $.extend(settings, {yesOrNo: true});
    lyr.confirm(title, question, settings);
};


lyr.alert = function(title, message, settings) {
    settings = $.extend(settings, {nocancel: true});
    lyr.confirm(title, message, settings);
};

lyr.continue_ = function(title, message, settings) {
    settings = $.extend(settings, {continue_: true, nocancel: true});
    lyr.confirm(title, message, settings);
};


/**
 * Wgts
 * Interface for adding DOM interaction.
 * Documentation: Front end development > Layar and Stiktu widgets system
 */
lyr.wgt = {

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
    lyr.wgt.scan();
});


// Initialize widgets in colorboxes
$(document).bind('cbox_complete', function() {
    lyr.wgt.scan('#colorbox');
    $.fn.colorbox.resize();
});


// Tipsy Tooltips
// http://onehackoranother.com/projects/jquery/tipsy/
lyr.wgt.set('tooltip', {
    init: function() {

        var title = this.element[0].title.replace(/(&#10|\n)/g, '<br>'),
            options = {
                content: '<p class="tipsy-innerwrap">' + title + '</p>',
                html: true,
                gravity: this.element.attr('data-gravity') || 'w',
                trigger: this.element.attr('data-trigger') || 'hover',
                offset: this.element.attr('data-offset') || 5,
                opacity: 1
            };
        this.element.tipsy(options);
    }
});


// Popup widget
lyr.wgt.set('popup', {
    init: function() {
        this.element.click(function() {
            var width = $(this).attr('data-popup-width') || 650,
                height = $(this).attr('data-popup-height') || 500,
                target = $(this).attr('data-target') || '_blank';
            window.open(this.href, target, 'location=0,status=0,scrollbars=0,width=' + width + ',height=' + height + '');
            return false;
        });
    }
});


// Google Analytics external links
lyr.wgt.set('ga_track', {
    init: function() {
        this.element.click(function() {
            try {
                _gaq.push(['_trackPageview','/outbound/article/' + this.href]);
            } catch(e){}
        });
    }
});


/**
 * Fetch authbox HTML using Ajax
 * Allows pages to be completely static to allow aggressive back-end caching.
 */

lyr.wgt.set('authbox', {

    init: function() {
//       window.alert(this.element.data('data-cc'))
//        window.alert(this.show)
        $.get(this.element.data('url'), this.show.bind(this));
    },

    show: function(html) {
        if (html) {
            this.element.html(html);
            lyr.wgt.scan(this.element);
            try {
                sessionStorage.setItem('authbox', html);
                sessionStorage.setItem('authbox_expires', (+new Date()) + 1000 * 60 * 15);
            } catch(err) {}
        }
    }
});


/**
 * Add this widget to all forms and links that trigger a login or logout.
 */
lyr.wgt.set('authbox-clear', {

    init: function() {
        if (this.element.is('form')) {
            this.element.on('submit', this.clear.bind(this));
        } else {
            this.element.on('click', this.clear.bind(this));
        }
    },

    clear: function() {
        try {
            sessionStorage.removeItem('authbox');
            sessionStorage.removeItem('authbox_expires');
        } catch (err) {}
    }

});


// Datepicker
lyr.wgt.set('date', {

    getDefaultSettings: function() {
        return {
            firstDay    : 1,
            altFormat   : $.datepicker.ATOM,
            dateFormat  : 'd M yy',
            showAnim    : false,
            changeMonth : true,
            changeYear  : true,
            onSelect    : this.onSelect.bind(this)
        };
    },

    init: function() {
        var settings = $.extend(this.getDefaultSettings(), this.element.data());
        this.element
            .attr('readonly', true)
            .css({cursor: 'pointer'})
            .datepicker(settings)
            .val(this.getDefaultDate(settings));
    },

    getDefaultDate: function(settings) {
        var date;
        if (settings.altField && $(settings.altField).val()) {
            date = $.datepicker.parseDate(settings.altFormat, $(settings.altField).val());
            return $.datepicker.formatDate(settings.dateFormat, date);
        } else {
            return null;
        }
    },

    onSelect: function(selectedDate) {
        var range = this.element.data('daterange');
        if (range) {
            this.setRangeLimitations(range, selectedDate);
        }
    },

    setRangeLimitations: function(range, selectedDate) {
        var otherInput = $($(this.element.data('daterange-with'))),
            option = (range === 'start') ? 'minDate' : 'maxDate';

        otherInput.datepicker('option', option, selectedDate);
    }

});


// Replaces file input fields with dummy form fields,
// This allows for consistent styling.
lyr.wgt.set('upload-file', {

    init: function() {
        this.createStructure();
        this.bindEvents();
    },

    createStructure: function() {
        this.wrap = $('<div>').addClass('upl-wrap');

        this.dummyField = $('<input>')
                .addClass('upl-dummy-input')
                .attr('readonly', 'readonly')
                .attr('placeholder', this.element.attr('placeholder'));

        if (this.element.attr('placeholder')) {
            lyr.wgt.append(this.dummyField, 'placeholder');
        }

        this.dummyButton = $('<button>').addClass('upl-dummy-button').attr('type', 'button').text('浏览文件');
        this.element.addClass('upl-hidden-input').css({opacity: 0}).wrap(this.wrap);
        this.element.before(this.dummyField).before(this.dummyButton);
    },

    bindEvents: function() {
        this.element.on('change', function(e) {
            // Strip fake path to file, only keep basename
            this.dummyField.val(e.currentTarget.value.replace(/^.*[\/\\]/g, ''));
            this.dummyField.removeClass('placeholder');
            this.element.trigger('keyup'); // Trigger validation
            this.element.trigger(lyr.event.UPLOAD_FILE_PICKED);
        }.bind(this));
    }

});


/**
 * Combine form field rows to one line
 * By default, combining fields is not supported
 */
lyr.wgt.set('form-field-combine', {

    init: function() {
        this.combineWith = $(this.element.data('combine-with')).assert();
        this.oldParent = this.element.closest('.item').assert();
        this.newParent = this.combineWith.closest('.item').assert();

        this.separator = $('<span>').addClass('field-sep');
        this.separator.html(this.element.data('combine-sep'));

        this.newParent.addClass('item-multiple');
        this.element.insertAfter(this.combineWith);
        this.element.before(this.separator);
        this.oldParent.remove();
    }

});


// Placeholder behaviour for older browsers (IE9 and below)
lyr.wgt.set('placeholder', {

    init: function() {
        var input, dummy;

        input = this.element;
        dummy = document.createElement('input');

        // Do not apply the placeholder replacement if native placeholders are
        // supported or when applied to file inputs (prevents security error).
        if ('placeholder' in dummy || input.attr('type') === 'file') {
            return;
        }

        if (!('setSelectionRange' in dummy)) {
            input[0].setSelectionRange = function(start, end) {
                var range = this.createTextRange();
                range.collapse(true);
                range.moveStart('character', start);
                range.moveEnd('character', end - start);
                range.select();
            };
        }

        // When input is focused, caret will be at start, but placeholder
        // remians visible until user starts typing.
        input.on('focus', function() {
            if (input.hasClass('placeholder')) {
                input[0].setSelectionRange(0, 0);
            }
        });

        // Remove placeholder text when starting to type
        input.on('keydown keyup paste', function() {
            if (!input.val()) {
                input.val('').removeClass('placeholder');
            }
        }.bind(this));

        // When input loses focus and input does not have a value,
        // repopulate input with placeholder.
        input.on('blur ' + lyr.event.PLACEHOLDER_BLUR, function() {
            if (!input.val()) {
                input.val(input.attr('placeholder')).addClass('placeholder');
            }
        });

        // When form is submitted, remove all placeholder values.
        input.closest('form').on('submit', function() {
            input.find('.placeholder').each(function() {
                input.val('');
            });
        });

        // Return empty string when the placeholder is set as the value.
        $.valHooks.input = $.valHooks.textarea = {
            get: function(el) {
                return $(el).is('.placeholder') ? '' : el.value;
            }
        };

        input.trigger(lyr.event.PLACEHOLDER_BLUR);
    }

});


// Conditionally show sections
lyr.wgt.set('show-on-condition', {

    init: function() {
        this.condition = this.element.data('condition');
        this.triggers  = this.element.data('triggers') || ':input';
        this.events    = this.element.data('events') || 'change.showoncondition';

        this.bindEvents();
        this.checkCondition();
    },

    bindEvents: function() {
        var checkCondition = this.checkCondition.bind(this);
        $('html').on(this.events, this.triggers, checkCondition);
    },

    checkCondition: function() {
        var show = !!$(this.condition).length;
        this.element.toggle(show);
    }

});


/**
 * Storage for keeping form validations
 * Append using lyr.validationRules.ruleName = {...}
 * Use by adding data-rules="ruleName" to a form with a validation widget
 */
lyr.validationSettings = {};

/**
 * jQuery validate
 * For forms that have all rules applied to class names
 * Expects standard 2012layar forms.html
 */
lyr.wgt.set('validate', {

    init: function() {
        this.jqValidator = this.element.validate(this.getValidateSettings());

        this.emailformValidatorFix();
        this.supportDomAutocomplete();

        this.element.on(lyr.event.FORM_ERRORS, function(e, widget, errors) {
            this.showErrors(errors);
        }.bind(this));
    },

    getValidateSettings: function() {
        var settings = this.validateSettings;
        return $.extend(settings, this.getDataValidateSettings(this.element.data('rules')));
    },

    getDataValidateSettings: function(settingsName) {
        var rules = {};
        if (settingsName) {
            rules = lyr.validationSettings[settingsName];
            if (!rules) {
                throw new Error('Undefined validate settings set: ' + settingsName);
            }
        }
        return rules;
    },

    // Regular Django forms don't have a required class or attribute on form inputs
    emailformValidatorFix: function() {
        if (this.element.hasClass('validate-fix')) {
            var field, fields = $('.item[data-validator]');
            for (var i = 0, m = fields.length; i < m; i++) {
                field = $(fields[i]);
                field.find(':input').addClass(field.data('validator'));
            }
        }
    },

    validateSettings: {
        highlight: function(element, errorClass, validClass) {
            var el = $(element);
            el = (el.hasClass('checkbox-enable-field')) ? el.closest('input') : el.closest('.item');
            el.addClass(errorClass).removeClass(validClass);
        },
        unhighlight: function(element, errorClass, validClass) {
            var el = $(element);
            el = (el.hasClass('checkbox-enable-field')) ? el.closest('input') : el.closest('.item');
            el.removeClass(errorClass).addClass(validClass);
        },
        errorPlacement: function(error, element) {
            var wrap = (element.hasClass('checkbox-enable-field')) ?
                            element.parents('.checkbox-enable-field-wrap:first') :
                            element.parents('.wrap:first'),
                help = wrap.find('.help:first');

            if (wrap.length && help.length) {
                error.insertBefore(help);
            } else if (wrap.length) {
                error.appendTo(wrap);
            } else {
                error.insertAfter(element);
            }
        }
    },

    supportDomAutocomplete: function() {
        this.element.on('DOMAutoComplete', ':input', function() {
            $(this).trigger('change');
        });
    },

    showErrors: function(errors) {
        this.jqValidator.showErrors(errors);
    }

});


/**
 * Focus
 * Focus first input field in form
 */
lyr.wgt.set('autofocus', {

    init: function() {
        var inputs = this.element.find('input, textarea, select'),
            input = inputs.filter(':visible:first'),
            value = input.val();

        if (input.attr('type') !== 'file') {
            try {
                input.trigger('focus').addClass('autofocus');
            } catch(err){}

            try {
                input[0].setSelectionRange(value.length, value.length);
            } catch(err){}
        }
    }

});


/**
 * Ajax submit
 * Submit form, receive dictionary with errors
 * http://jquery.malsup.com/form/
 */
lyr.wgt.set('ajaxsubmit', {

    init: function() {
        this.buttons = this.element.find('.buttons');
        if (!this.buttons.length) {
            this.buttons = this.element;
        }
        this.options = {
            forceSync      : false,
            success        : this.handleJsonResponse.bind(this),
            error          : this.handleError.bind(this),
            beforeSerialize: this.beforeSerialize.bind(this),
            beforeSubmit   : this.beforeSubmit.bind(this)
        };
        this.element.ajaxForm(this.options);
    },

    submit: function() {
        this.element.ajaxSubmit(this.options);
    },

    // Submit can be cancelled by rewriting options.beforeSubmit to return false.
    beforeSerialize: function(form, options) {
        form.trigger(lyr.event.FORM_BEFORE_SUBMIT, [options]);
    },

    beforeSubmit: function(values, form, options) {
        form.trigger(lyr.event.FORM_SUBMIT, [values, options]);
        this.toggleLoading(true);
    },

    handleError: function(xhr, status) {
        this.toggleLoading(false);
        this.element.trigger(lyr.event.FORM_ERROR, [xhr, status]);
        $.ajaxSettings.error(xhr, status);
    },

    handleJsonResponse: function(json) {
        // Handle json sent as text/html (e.g. iframe file upload)
        if (typeof json === 'string') {
            try { json = JSON.parse(json); }
            catch(err) {
                this.handleError({}, 'parsererror');
                return false;
            }
        }

        this.toggleLoading(false);

        if ($.isEmptyObject(json.errors) && !json.error) {
            this.success(json);
        }  else {
            if (json.error && json.message) {
                lyr.alert('Error', json.message);
            } else {
                this.showFormErrors(json.errors);
            }
        }
    },

    success: function(json) {
        this.element.trigger(lyr.event.FORM_SUCCESS, [json]);
    },

    toggleLoading: function(isLoading) {
        lyr.toggleLoading(this.buttons, isLoading);
    },

    showFormErrors: function(errors) {
        var flatErrors = {};
        for (var k in errors) {
            if (errors.hasOwnProperty(k)) {
                flatErrors[k] = errors[k].join('<br>');
            }
        }
        this.element.trigger(lyr.event.FORM_ERRORS, [this, flatErrors]);
    }
});



/**
 * Report when form has been saved successfully.
 */
lyr.wgt.set('reportsaved', {

    init: function() {
        this.buttons = this.element.find('.buttons:last');
        this.element.on(lyr.event.FORM_SUCCESS, this.report.bind(this));
    },

    report: function(e, json) {
        var report;

        report = $('<span>').addClass('form-success').css({opacity: 0});
        report.text(json.message || 'Successfully saved the form!');
        report.prependTo(this.buttons);
        report.animate({opacity: 1}, 200);

        window.setTimeout(function() {
            report.fadeOut(200, function() {
                report.remove();
            });
        }, 4000);
    }

});


/**
 * Authbox in header menu foldouts
 *
 */
lyr.wgt.set('authbox-foldout', {

    init: function() {
        this.element.on('click.authbox', this.foldout.bind(this));
    },

    foldout: function() {
        var focused = this.element.hasClass('focus');
        $(document.body).on('click.authbox', this.collapse.bind(this));
        this.element.closest('.authbox').find('a').removeClass('focus');
        this.element.toggleClass('focus', !focused);
        this.element.trigger('blur');
        return false;
    },

    collapse: function() {
        this.element.removeClass('focus');
    }

});


/**
 * Make <select multiple> easier for users to interact with.
 * Creates two lists, one for available options, one for selected options.
 */
lyr.wgt.set('select-multiple', {

    init: function() {
        var dom = this.getDOM();

        this.options         = this.element.find('option').clone();

        this.counter         = dom.find('.slm-count');
        this.addButton       = dom.find('.slm-add');
        this.removeButton    = dom.find('.slm-remove');
        this.availableSelect = dom.find('.slm-available select');
        this.selectedsSelect = dom.find('.slm-selected select');

        this.storeOriginalOrder();
        this.reConnectLabel();
        this.populateOptions();
        this.initEventHandling();
        this.updateCount();
        
        this.element.before(dom);
    },
    
    getDOM: function() {
        return $('' +
            '<div class="select-multiple">' +
            '   <div class="slm-column slm-selected">' +
            '       <strong>Selected (<span class="slm-count">0</span>)</strong>' +
            '       <select multiple></select>' +
            '   </div>' +
            '   <div class="slm-column slm-controls">' +
            '       <div class="slm-add" title="Add to selected values">◄</div>' +
            '       <div class="slm-remove" title="Remove from selected values">►</div>' +
            '   </div>' +
            '   <div class="slm-column slm-available">' +
            '       <strong>Available options</strong>' +
            '       <select multiple></select>' +
            '   </div>' +
            '</div>');
    },
    
    storeOriginalOrder: function() {
        for (var i = 0, m = this.options.length; i < m; i++) {
            if ('setAttribute' in document.documentElement) {
                this.options[i].setAttribute('index', i / 10000);
            } else {
                $.data(this.options[i], 'index', i);
            }
        }   
    },
    
    reConnectLabel: function() {
        var id = this.element.attr('id');
        this.element.removeAttr('id');
        this.availableSelect.attr('id', id);
        this.element.css({position: 'absolute', left: '-99999em'}).attr('readonly', true);
    },
    
    populateOptions: function() {
        this.availableSelect.html( this.options.filter(':not([selected])') );
        this.selectedsSelect.html( this.options.filter('[selected]').prop('selected', false) );
    },

    initEventHandling: function() {
        var buttons = this.addButton.add(this.removeButton);
        buttons.on('click', this.handleEvent.bind(this));

        this.availableSelect.on('dblclick', function() {
            this.addButton.click();
        }.bind(this));

        this.selectedsSelect.on('dblclick', function() {
            this.removeButton.click();
        }.bind(this));
    },

    handleEvent: function(e) {
        var selection, source, target;

        if (e.currentTarget === this.addButton[0]) {
            source = this.availableSelect;
            target = this.selectedsSelect;
        } else {
            source = this.selectedsSelect;
            target = this.availableSelect;
        }

        selection = source.find(':selected');

        if (selection.length) {

            target.find('option').prop('selected', false);
            target.append(selection);
            selection.prop('selected', true);

            this.updateHiddenSelect();
            this.orderList(target);

            target.focus();

            // Force redraw, fixes this issue: http://stackoverflow.com/q/5908494/451480
            if ($('html').hasClass('ie')) {
                target.css('width', 0).css('width', '');
            }
        }
    },

    updateHiddenSelect: function() {
        this.selectedOpts = this.selectedsSelect.find('option');
        this.element.find('option').prop('selected', false);
        for (var i = 0, m = this.selectedOpts.length; i < m; i++) {
            this.element.find('[value="' + this.selectedOpts[i].value + '"]').prop('selected', true);
        }
        this.updateCount();
    },

    orderList: function(target) {
        var sortingCallback, options = target.find('option');

        // getAttribute() is significantly faster than $.data(),
        // but unsupported in IE8 and below.
        // Also: http://www.allenpike.com/2009/arraysort-browser-differences/
        if ('getAttribute' in document.documentElement) {
            sortingCallback = function(a, b) {
                return a.getAttribute('index') - b.getAttribute('index');
            };
        } else {
            sortingCallback = function(a, b) {
                return $.data(a, 'index') - $.data(b, 'index');
            };
        }
        options.sort(sortingCallback);
        target.append(options);
    },

    updateCount: function() {
        var count = this.selectedsSelect.find('option').length;
        this.counter.text(count);
        return count;
    }

});


/**
 * Prepend URL in input value with host
 */
lyr.wgt.set('url-prepend-domain', {

    init: function() {
        var value    = this.element.val(),
            domain   = this.element.data('domain') || location.host,
            protocol = window.location.protocol;

        if (!value.match(/^[a-z]+:\/\//)) {
            this.element.val(protocol + '//' + domain + value);
        }
    }

});


/**
 * Open a lightbox
 * See lightbox.js for documentation
 */
lyr.wgt.set('lightbox', {

    init: function() {
        this.element.on('click', this.openLightbox.bind(this));
        this.handleJson();
    },

    handleJson: function() {
        var events = [
            lyr.event.LIGHTBOX_AJAX_SUCCESS,
            lyr.event.LIGHTBOX_AJAX_ERROR
        ].join(' ');
        $(document).off(events).on(events, this.alert);
    },

    alert: function(e, json, type) {
        lyr.lightbox.closeAll();
        lyr.alert(type === 'error' ? 'Error' : 'Message', json.message);
    },

    setupLightbox: function() {
        var data = this.element.data();
        if (data.offsetObj === 'this') {
            data.offsetObj = this.element;
        }
        return data;
    },

    openLightbox: function() {
        this.lightbox = new lyr.Lightbox();
        this.lightbox.open(this.setupLightbox());
        return false;
    }

});


/**
 * Textarea countdown
 * Counts number of characters left in textarea
 * Include <span class="count"> in label or help text
 */
lyr.wgt.set('field-countdown', {

    init: function() {
        this.counter = this.element.closest('.item').find('.count').assert();
        this.maxlength = parseInt(this.counter.text(), 10);
        this.element.on(lyr.event.LIVE, this.update.bind(this));
        this.element.attr({maxlength: this.maxlength});
        this.update();
    },

    update: function(e) {
        var charsleft = this.maxlength - this.element[0].value.length;
        this.counter.text(charsleft);
        if (e && charsleft < 0) {
            return false;
        }
    }

});


/**
 * Tabs
 * Widget for showing/hiding sections using a menu with href/id matching
 * Requires ul|ol > li > a structure for menu
 */
lyr.wgt.set('tabs', {

    init: function() {
        this.id      = this.getUniqueID();
        this.persist = this.element.data('persist');

        this.tabActions = this.element.find('li');
        this.tabContent = [];

        this.setInitialTab();
        this.bindEvents();
    },

    hideAllTabContent: function() {
        for (var i = 0, m = this.tabActions.length; i < m; i++) {
            $($(this.tabActions[i]).children('a').attr('href')).hide();
        }
    },

    setInitialTab: function() {
        var activeContentId,
            activeContentElement;

        this.hideAllTabContent();

        if (this.persist && lyr.storage(this.id)) {
            activeContentId = lyr.storage(this.id);
            activeContentElement = this.element.find('a[href$="' + activeContentId + '"]');
        } else {
            activeContentElement = this.element.find('a:first');
        }

        this.switchTab(activeContentElement);
    },

    bindEvents: function() {
        this.element.on('click', 'a', function(e) {
            this.switchTab($(e.currentTarget));
            return false;
        }.bind(this));
    },

    switchTab: function(hyperlink) {
        // get new content area
        var newTargetContent = $(hyperlink.attr('href'));

        // check if it's not already active
        if (this.oldTargetContent && this.oldTargetContent.is(newTargetContent)) {
            return;
        }

        // we've already loaded in content, so we want to fade when toggling
        if (this.oldTargetContent) {
            this.oldTargetContent.fadeOut('fast', function() {
                newTargetContent.fadeIn('fast');
            });
        } else {
            newTargetContent.show();
        }

        this.tabActions.removeClass('selected');
        hyperlink.parent().addClass('selected');

        this.oldTargetContent = newTargetContent;

        if (this.persist) {
            lyr.storage(this.id, newTargetContent.attr('id'));
        }
    }

});


/**
 * Autoclick
 * Triggers click on load
 */
lyr.wgt.set('click', {

    init: function() {
        this.element.trigger('click');
    }

});


/**
 * Geo Chart
 * Widget wrapper for https://developers.google.com/chart/interactive/docs/gallery/geochart
 */
lyr.wgt.set('geochart', {

    /** @namespace google.setOnLoadCallback */
    init: function() {
        this.data = this.element.data('data');
        this.options = $.extend({}, this.element.data('color-axis'));
        google.setOnLoadCallback(this.drawChart.bind(this));
    },

    /** @namespace google.visualization.arrayToDataTable */
    /** @namespace google.visualization.GeoChart */
    drawChart: function() {
        var data = google.visualization.arrayToDataTable(this.data);
        this.chart = new google.visualization.GeoChart(this.element[0]);
        return this.chart.draw(data, this.options);
    }

});


/**
 * Scroll to anchor
 */
lyr.wgt.set('anchor-scroll', {

    init: function() {
        this.speed = this.element.data('as-speed') || 500;
        this.offset = this.element.data('as-offset') || -50;

        this.element.on('click', function() {
            this.scroll();
            return false;
        }.bind(this));
    },

    scroll: function() {
        var href   = this.element.attr('href').split('#')[1],
            target = $('#' + href),
            top    = target.offset().top + this.offset;

        if (target.length) {
            $('html, body').animate({scrollTop: top}, this.speed);
            history.pushState(null, null, '#' + href);
        }
    }

});


/**
 * Creator signup button
 */
lyr.wgt.set('creator-signup-button', {

    init: function() {
        this.action   = this.element.attr('action');
        this.checkbox = this.element.find('input[name=newsletter]').assert();
        this.element.on('submit', this.submit.bind(this));
    },

    submit: function() {
        var data = {
            newsletter: this.checkbox.is(':checked') ? '1' : ''
        };

        $.post(this.action, data, function(resp) {
            if (resp.error) {
                lyr.lightbox.closeAll();
                lyr.alert('Error', resp.message);
            } else {
                window.location.href = resp.next_url;
            }
        });

        return false;
    }

});


/**
 * Contact sales form
 * Works in conjunction with ajaxsubmit-cms-form
 */
lyr.wgt.set('contact-sales-form-wrapper', {
    init: function(){
        var title = $('<h1/>').html('Contact sales'),
            item_key;

        this.user = this.element.data('profile');
        this.form = this.element.find('form');
        this.items = this.form.find(':text').closest('.item');

        for (var i = 0, m = this.items.length; i < m; i++) {
            item_key = $(this.items[i]).find('label').html().trim().toLowerCase().replace(' ', '-');
            if (item_key && !!this.user[item_key]) {
                $(this.items[i]).find(':text').val(this.user[item_key]);
            }
        }

        this.form.attr('data-wgt','validate ajaxsubmit ajaxsubmit-cms-form')
                 .attr('action', '/contact-sales/')// TODO: Remove hard-coding, use {% page_url ... %}
                 .removeClass('uniform')
                 .prepend(title);
        this.element.on(lyr.event.FORM_SUCCESS, this.success.bind(this));
    },

    success: function(e, _response) {
        lyr.continue_('Request sent', _response, {
            ok: function() {
                lyr.lightbox.closeAll();
            }.bind(this),
            width: 480
        });
    }
});


lyr.wgt.set('ajaxsubmit-cms-form', {
    init: function() {
        lyr.wgt.extend(this, 'ajaxsubmit');
        this.options.success = this.handleCmsFormResponse.bind(this);
    },

    handleCmsFormResponse: function(_response) {
        if (typeof _response === 'string') {
            if (!_response.indexOf('success')) {
                return false;
            }
        }
        this.toggleLoading(false);
        this.success(_response);
    }
});


lyr.wgt.set('pricing-table', {
    init: function() {
        var hash          = window.location.hash.substring(1);
        this.struct       = lyr.pricing.struct();
        this.currency     = this.element.data('currency') || 'EUR';
        this.template     = $('#tpl-pricing-table').html();
        this.decTemplate  = $('#tpl-decimal').html();

        if (this.struct[hash]) {
            this.populateTemplate(hash);
        } else {
            this.populateTemplate(this.currency);
        }
    },

    populateTemplate: function(currency_type) {
        var html = this.template.replace(/{[^{}]+}/g, function(match) {
            var value = this.struct[currency_type][match.replace(/[{}]+/g, "")] || "",
                price_bits  = value.split('.');

            if (price_bits.length > 1) {
                value = lyr.format.sprintf(this.decTemplate, price_bits[0], price_bits[1]);
            }
            return value;
        }.bind(this));

        this.element.append(html);
        this.element.toggleClass('with-note', this.struct[currency_type].note);

        this.altCurrencyLink = this.element.find('.alt-currency');
        this.altCurrencyLink.on('click', this.altCurrencyClick.bind(this));
    },

    altCurrencyClick: function(e) {
        var altCurrency = $(e.target).data('alt-currency');

        this.element.fadeOut('fast', function() {
            this.element.empty();
            this.populateTemplate(altCurrency);
            this.element.fadeIn('fast');
        }.bind(this));

        window.location.hash(altCurrency);
    }
});




/**
 * Mark system messages as read
 */
lyr.wgt.set('system-messages-mark-read', {

    init: function() {
//    window.alert(this.element.name)
        this.latest = this.element.data('latest');
        this.element.on('click ' + lyr.event.SYSTEM_MESSAGE_READ, function() {
            // TODO: Store in back-end
            $.cookie('sys_msgs_read', this.latest, {path: '/', expires: 365});
        }.bind(this));
    }

});



// gets called by lyr.toggleLoading
lyr.wgt.set('button-state-toggle', {

    init: function() {
        this.flag       = false;
        this.msg        = this.element.text();
        this.loadingMsg = this.element.data('loading-msg');
        this.defaultMsg = this.element.data('default-msg');
    },

    // toggle text and loading msg depending on flag state
    toggleMsg: function() {
        if (this.loadingMsg) {
            if (this.flag) {
                this.element.text(this.defaultMsg);
            } else { // initial pass through
                if (!this.defaultMsg) { this.defaultMsg = this.msg; }
                this.element.text(this.loadingMsg);
            }
            this.flag = !this.flag;
        }
    }

});



/*
    tooltip trigger.
    on mouseover, trigger the tooltip wgt.
    keep the tooltip open when hovering this el.
    keep the tooltip open for a set period after mouseleave this el
        so user can navigate to tooltip wgt without it disappearing.
 */
lyr.wgt.set('tooltip-trigger', {

    init: function() {
    
        var lbOpen  = lyr.event.LIGHTBOX_OPEN + '.' + this.name,
            open    = this.openTooltip.bind(this),
            update  = this.positionTooltip.bind(this),
            content = this.toolTipContent.bind(this);

        // direction of arrow
        this.position = (this.element.data('position') || 'north');

        // where to position the elements: my = element, at = target
        this.positions = {
            north   : { my: 'center top',    at: 'center bottom'},
            east    : { my: 'right center',  at: 'left center'},
            south   : { my: 'center bottom', at: 'center top'},
            west    : { my: 'left center',   at: 'right center'}
        };

        // close other tooltips when opening a lightbox
        $(document).off(lbOpen).on(lbOpen, this.closeOtherTooltips.bind(this));

        // jquery-ui tooltip setup
        this.element.tooltip({
            items   : '[data-txt]',
            show    : 100,
            hide    : 100,
            content : content,
            open    : open,
            position: {
                my       : this.positions[this.position].my,
                at       : this.positions[this.position].at,
                using    : update,
                collision: 'flipfit'
            }
        });

        this.element.on('mouseleave', this.mouseLeave.bind(this));
    },

    toolTipContent: function() {
        return this.element.attr('data-txt');
    },

    openTooltip: function(e, ui) {
        var tt = ui.tooltip;
        this.closeOtherTooltips();
        tt.animate({ top: tt.position().top + 10 }, 'fast');
        tt.mouseenter(function() { this.haltTimer(); }.bind(this) );
        tt.mouseleave(function() { this.exitTooltip(); }.bind(this) );
    },

    closeOtherTooltips: function() {
   
        var wgtElements = $('[data-wgt$=tooltip-trigger]').not(this.element);
        for (var i = 0, m = wgtElements.length; i < m; i++) {
            var wgt = lyr.wgt.get(wgtElements[i], this.name);
            if (wgt) {
                wgt.exitTooltip();
            }
        }
    },

    positionTooltip: function(coords, fdbck) {
        var tooltip = fdbck.element.element,
            isHorizontal  = (this.position === 'east' || this.position === 'west');

        // params being passed by ref
        if (isHorizontal) {
            this.positionHorizontalTooltip(fdbck, coords);
        } else {
            this.positionVerticalTooltip(fdbck, coords);
        }

        tooltip.css({
            left: coords.left + 'px',
            top : coords.top + 'px',
            'margin-right': '20px'
        }).addClass('pos-' + fdbck.horizontal + '-' + fdbck.vertical);

        tooltip.toggleClass('pad', (tooltip.height() <= 20));
    },


    /*
        Arrow is pointing E/W
    */
    positionHorizontalTooltip : function(fdbck, coords) {
        coords.top -= 8;

        switch (fdbck.horizontal) {
            case 'left' : coords.left += 6; break;
            case 'right': coords.left -= 10; break;
        }
    },

    /*
        Arrow is pointing N/S
        @fdbck: info re target and tooltip(element/tt)
        @coords: position of the tt
     */
    positionVerticalTooltip: function(fdbck, coords) {
        var targetCPos = fdbck.target.left + (fdbck.target.width / 2),
            ttHOffset  = 24, // (24 + 18)
            ttL        = targetCPos - fdbck.element.width + ttHOffset,
            ttR        = targetCPos - ttHOffset,
            isTtOnEdge = ((fdbck.element.left + fdbck.element.width) >= $(document).width());

        switch (fdbck.horizontal) {
            case 'left'  : coords.left = ttL; break;
            case 'right' : coords.left = ttR - fdbck.element.width ; break;
            case 'center': {
                if (isTtOnEdge) { // force a different position
                    coords.left = ttL;
                    fdbck.horizontal = 'left';
                } else {
                    coords.left += 4;
                }

                break;
            }
        }

        switch (fdbck.vertical) {
            case 'top'   : coords.top += 6; break;
            case 'bottom': coords.top -= 24; break;
        }
    },

    mouseLeave: function(e) {
        e.stopImmediatePropagation();
        this.hideTooltip = setTimeout(this.exitTooltip.bind(this), 500 );
    },

    exitTooltip: function() { this.element.tooltip('close'); },
    haltTimer  : function() { clearTimeout( this.hideTooltip ); }

});


/**
 * A simple accordion module
 */
lyr.wgt.set('simple-accordion', {

    init: function() {
        this.id       = this.getUniqueID();
        this.persist  = this.element.data('persist');

        this.headings = this.element.children(':even'); // 0 based
        this.bodies   = this.element.children(':odd');

        this.bindEvents();
        this.setup();
    },

    bindEvents: function() {
        this.headings.on('click', this.accordionToggle.bind(this));
    },

    setup: function() {
        var heading, body;

        this.headings.addClass('simple-accordion-header');

        // scan through localStorage and toggle
        for (var i = 0, m = this.headings.length; i < m; i++) {
            heading = this.headings.eq(i);
            body    = this.bodies.eq(i);

            if (this.persist && lyr.storage(this.id + '.' + heading.index())) {
                heading.addClass('closed');
                body.toggle();
            } else {
                // if we've overridden it as closed elsewhere (html)
                if (heading.hasClass('closed')) {
                    body.toggle();
                } else {
                    heading.toggleClass('open');
                }
            }
        }
    },

    /**
     * Accordion heading toggle was clicked
     * @param e
     */
    accordionToggle: function(e) {
        var heading = $(e.target),
            body    = heading.next();

        heading.toggleClass('open').
                toggleClass('closed');

        body.toggleClass('open').
             stop().
             slideToggle('fast');

        this.persistState(heading);
    },

    persistState: function(heading) {
        if (this.persist) {
            lyr.storage( this.id + '.' + heading.index(),
                    heading.hasClass('closed') ? 'closed' : null);
        }
    }

});


/**
 * Track outbound links.
 * Add this event handler below widgets so that widgets get a chance
 * to cancel the click event.
 */
$(function() {
    $(document).on('click.gaq', 'a', function(e) {
        if (e.currentTarget.hostname && e.currentTarget.hostname !== window.location.hostname) {
            lyr.trackEvent('Outbound', e.currentTarget.href, location.pathname);
            // Allow some time to track event when link is opened in the same window
            if (!(e.metaKey || e.ctrlKey) && !e.target) {
                e.preventDefault();
                setTimeout(function() {
                    location.href = e.currentTarget.href;
                }.bind(this), 50);
            }
        }
    });
});

