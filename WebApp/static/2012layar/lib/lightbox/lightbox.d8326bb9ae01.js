/*jshint globalstrict: true */
/*global $, lyr*/

'use strict';


/**
 * Lightbox
 * Open content in a page overlay
 * Example use: lyr.lightbox.open({html: 'Hello'});
 */
lyr.Lightbox = function() {
    this.selector = '.' + this.ns + 'lightbox';
};

lyr.Lightbox.prototype = {

    ns: 'lyr-lb-', // Namespace prefix for CSS classes

    settings: {
        // Content
        id                : '',        // Unique ID
        url               : '',        // Fetch URL using Ajax and display this in dialog
        html              : '',        // Put HTML in dialog
        dom               : '',        // Copy dom_id inner HTML to dialog

        // Display
        width             : 750,       // Width
        height            : 'auto',    // Initial height
        addClass          : '',        // Extra classname(s) for lightbox
        closeButton       : true,      // Add a close button
        vitrage           : true,      // Show vitrage
        vitrageOpacity    : 0.6,       // Opacity of vitrage. 0 for invisible
        vitrageClick      : 'close',   // What happens when you click the vitrage (close|ignore)
        fadeIn            : 500,       // Vitrage fade in speed
        fadeOut           : 300,       // Vitrage fade out speed

        // Positioning, default is center
        offsetObj         : false,     // Position at element, 'this' is current element
        offsetX           : 3,         // Left offset calculated from top left of parent
        offsetY           : 3,         // Top offset calculated from top left of parent
        left              : false,     // Left absute position (offset and offsetObj are ignored)
        top               : false,     // Top absolute position (offset and offsetObj are ignored)
        windowPadding     : 30,        // Minimal distance from window
        animateOnResize   : true,      // Animate position when resizing

        forcePosition     : false,     // Ignore checks if lightbox is within viewport

        // Events
        onopen            : false,     // Open callback
        onclose           : false      // Close callback
    },

    open: function(settings) {

        if (typeof settings === 'string') {
            settings = {html: settings};
        }

        this.iSettings = $.extend({}, this.settings, settings);

        this.vitrage = $();
        if (this.iSettings.vitrage) {
            this.vitrage = this._addVitrage();
        }

        this.lightbox = this._addLightbox();

        this.content(this._getContent(), this.iSettings.url);
        this.setPosition();
        this._addCloseTriggers();

        $(window).on('resize', this.setPosition.bind(this));

        if ($.isFunction(this.iSettings.onopen)) {
            this.iSettings.onopen(this.lightbox);
        }

        $(document).trigger(lyr.event.LIGHTBOX_OPEN, [this.lightbox]);

        return this;
    },

    // Close current instance
    close: function() {

        if (!this.lightbox) {
            return;
        }

        if (this.xhr) {
            this.xhr.abort();
        }

        this.lightbox.remove();
        this.vitrage.fadeOut(this.iSettings.fadeOut, function() {
            $(this).remove();
        });

        if (this.iSettings.onclose) {
            this.iSettings.onclose(this.lightbox);
            this.clearCallbacks();
        }

        $(document).trigger(lyr.event.LIGHTBOX_CLOSE, [this.lightbox]);
    },

    // Close all, starting from last. Last lightbox is most upper one.
    closeAll: function() {
        for (var i = $(this.selector).length; i > 0; i--){
            this.closeLast();
        }
    },

    closeAllButFirst: function() {
        for (var i = $(this.selector).length; i > 1; i--){
            this.closeLast();
        }
    },

    closeLast: function() {
        return $(this.selector).last().data('lightbox').close();
    },

    anyOpen: function() {
        return (0 !== $(this.selector).length);
    },

    /**
     * @param {string|jQuery} element
     * @return {lyr.Lightbox}
     */
    get: function(element) {
        return $(element).closest(this.selector).data('lightbox');
    },

    content: function(content, placeholder) {
        var scripts = $(), allScriptsLoaded;

        // Prevent space = re-trigger
        $(':focus:not(body)').blur();

        // Convert content to jQuery object
        if (typeof content === 'string') {
            content = $($.trim(content));
        }

        scripts = content.filter('script[src]');

        // Callback function after all scripts in content are loaded
        allScriptsLoaded = function() {
            this.contentWrap.html(content.not('script[src]'));
            lyr.wgt.scan(this.contentWrap);
            if (!placeholder && this.iSettings.animateOnResize) {
                window.setTimeout(function() {
                    this.lightbox.addClass('canhasanim');
                }.bind(this), 500);
            }
        }.bind(this);

        // Preload all scripts before showing any content to prevent
        // visible shifts and glitches while applying scripts
        (function preloadScriptsSequentially(index) {
            if (index === scripts.length) {
                allScriptsLoaded();
            } else {
                $.getScript(scripts[index].src).always(function() {
                    preloadScriptsSequentially(++index);
                });
            }
        })(0);
    },

    width: function(width) {
        this.iSettings.width = width;
        this.lightbox.css({width: width});
    },

    clearCallbacks: function() {
        this.iSettings.onclose = this.iSettings.onopen = false;
    },

    // Overwrite this method for an instance to proxy.
    userClose: function() {
        this.close();
    },

    _addCloseTriggers: function() {
        var closeTriggers = this.closeButton;
        if (this.vitrage && this.iSettings.vitrageClick === 'close') {
            closeTriggers = closeTriggers.add(this.vitrage);
        }
        
        closeTriggers.on('click', this._handleCloseClick.bind(this));
    },

    _handleCloseClick: function() {
        $(document).trigger(lyr.event.LIGHTBOX_CLOSE_BY_USER, [this.lightbox]);
        this.userClose();
       
        return false;
    },

    _addVitrage: function() {
        var vitrage;
        vitrage = $('<div>').appendTo('body').css({opacity: 0});
        vitrage.addClass('vitrage ' + this.ns + 'vitrage');
        vitrage.fadeTo(this.iSettings.fadeIn, this.iSettings.vitrageOpacity);
        return vitrage;
    },

    _addLightbox: function() {
        var lightbox, content;

        this.contentWrap = $('<div>').addClass(this.ns + 'content');
//        this.contentWrap.css({border:"1px solid red"});

        this.closeButton = $();
        if (this.iSettings.closeButton) {
            this.closeButton = $('<div>').addClass(this.ns + 'close').text('Close');
//            this.closeButton.css({border:"1px solid blue"});
        }

        lightbox = $('<section>').data({lightbox: this})
            .attr({id: this.iSettings.id})
            .addClass(this.ns + 'lightbox')
            .addClass(this.iSettings.addClass)
            .append(this.closeButton, this.contentWrap)
            .appendTo('body').css({opacity: 0});
        
        return lightbox;
    },

    setPosition: function() {
        var pos, offset, width, height, offsetObj, pxTooWide, pxTooHigh,
            middle       = {},
            settings     = this.iSettings,
            windowWidth  = $(window).width(),
            windowHeight = $(window).height(),
            padding      = settings.windowPadding,
            scroll       = $('html').scrollTop() || $('body').scrollTop();

        this.lightbox.css('width', ''); // Prepare for natural width sample

        width = (settings.width === 'auto') ? this.lightbox.width() : settings.width;
        height = (settings.height === 'auto') ? this.lightbox.height() : settings.height;

        // Position at DOM element
        if (settings.offsetObj && $(settings.offsetObj).length) {
            offsetObj = $(settings.offsetObj);
            offset = offsetObj.offset();
            pos = {
                width  : width,
                height : height,
                left   : offsetObj.width()  + offset.left + parseFloat(settings.offsetX),
                top    : offsetObj.height() + offset.top  + parseFloat(settings.offsetY)
            };
        }

        else {
            middle = {
                left : (windowWidth / 2) - (width / 2),
                top  : (scroll + (windowHeight / 2)) - (height / 1.8)
            };

            pos = {
                width  : width,
                height : height,
                left   : (settings.left !== false) ? settings.left : middle.left,
                top    : (settings.top !== false) ? settings.top : middle.top
            };
        }

        if (!settings.forcePosition) {
            // Correct position if lightbox is out of viewport
            pxTooWide = (pos.left + pos.width)  - (windowWidth - 10);
            pxTooHigh = (pos.top  + pos.height) - (scroll + windowHeight - padding);

            if (pxTooWide > 0) { pos.left -= pxTooWide; }
            if (pxTooHigh > 0) { pos.top  -= pxTooHigh; }
        }

        pos.left = Math.max(padding, pos.left);
        pos.top  = Math.max(padding, pos.top);

        if (pos.height > windowHeight) {
            pos.top  = scroll + padding;
        }

        pos = $.extend(pos, {opacity: 1, height: 'auto'});
        this.lightbox.css(pos);
    },

    _getContent: function() {
        var content = '',
            settings = this.iSettings;

        // Content of DOM node
        if (settings.dom && $(settings.dom).length) {
            content = $(settings.dom).clone(false).html();
        }

        // Ajax
        else if (settings.url) {
            content = $('<div>').addClass(this.ns + 'loading');
            //window.alert(this.ns + 'loading')
            this.xhr = $.ajax(settings.url, {
                success: this._ajaxSuccess.bind(this),
                error: this._ajaxError.bind(this)
            });
        }

        // HTML string
        else if (settings.html) {
            content = settings.html;
        }

        return content;
    },

    _ajaxSuccess: function(content) {
//    window.alert(1 + "   " +content)
        // Server returns HTML string
        if (typeof content === 'string') {
            this.content(content);
            this.setPosition();
        }

        // Server returns JsonResponse, should be picked up by initiator.
        else if ($.isPlainObject(content)) {
            var event = (content.error) ?
                lyr.event.LIGHTBOX_AJAX_ERROR :
                lyr.event.LIGHTBOX_AJAX_SUCCESS;
            $(document).trigger(event, [content, this]);
        }

        this.xhr = null;
    },

    _ajaxError: function(xhr, status) {
//    window.alert(2)
//    window.alert(status)
        this.clearCallbacks();
        this.close();
        this.xhr = null;
        $.ajaxSettings.error(xhr, status);
    }
    
};

// Public instance
lyr.lightbox = new lyr.Lightbox();
