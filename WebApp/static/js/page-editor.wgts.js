/*jshint globalstrict:true, jquery:true, sub:true */
/*global lyr Mustache*/
'use strict';


// Creator utils
lyr.btg = {

    // Cross-browser transform:scale()
    scale: function(frame, scale) {
        if ($('html').hasClass('ie-nosupport')) { // Kind of ironic
            frame.css({
                filter: lyr.format.sprintf('progid:DXImageTransform.Microsoft.Matrix(M11={1}, M12=0, M21=0, M22={1}, SizingMethod="auto expand")', scale)
            });
        } else {
            frame.css({
                width          : 100 / scale + '%',
                height         : 100 / scale + '%',
                transform      : 'scale(' + scale + ')',
                transformOrigin: '0 0',
                transformStyle : 'preserve-3d' // https://bugs.webkit.org/show_bug.cgi?id=15676#c10
            });
        }
    },

    iframeAttrs: {
        scrolling        : 'no',
        frameborder      : 0,
        allowtransparency: 1
    }

};


/**
 * Widget for adding/editing widgets
 */
lyr.wgt.set('btg-buttons', {

    init: function() {
        this.initialized    = false;
        this.buttonTemplate = this.element.data('button-template');
        this.deleteURL      = this.element.data('delete-url');

        this.customList     = $('#custom').find('.btg-figure-list').assert();
        this.intro          = this.element.find('.btg-buttons-empty');

        this.bindEvents();
        this.addManageEventHandlers();
        this.toggleIntroDisplay();

        $(document).on(lyr.event.PAGE_LOAD_COMPLETE, this.onEditorInitDone.bind(this));
    },

    onEditorInitDone: function(e, widget) {
        if (!this.initialized) {
            this.addEditorEventHandlers();
            this.editorWgt   = widget;
            this.initialized = true;
        }
    },

    bindEvents: function() {
        $(document).on(lyr.event.CREATOR_BUTTON_CREATE, function(e, button) {
            this.addButton(button);
        }.bind(this));
    },

    toggleIntroDisplay: function() {
        this.intro.toggle(this.customList.find('li').length === 0);
    },

    addButton: function(button) {
        var template = lyr.tpl(this.buttonTemplate);

        template.addClass('btg-button-' + button.id);
        template.data('button', button);
        template.find('figcaption span').text(button.title);
        template.find('img').attr({src: button.url});
        template.prependTo(this.customList);

        this.makeButtonDraggable(template);
        this.toggleIntroDisplay();
    },

    addManageEventHandlers: function() {
        this.customList.on('click', '.delete', this.attemptDeleteButton.bind(this));
    },

    addEditorEventHandlers: function() {
        var elements = this.element.find('.btg-button');
        this.element.on('click', '.btg-button', this.addButtonToPage.bind(this));
        for (var i = 0, m = elements.length; i < m; i++) {
            this.makeButtonDraggable($(elements[i]));
        }
    },

    addButtonToPage: function(e) {
        if (!this.editorWgt.viewOnlyMode) {
            var widget, image = $(e.currentTarget).find('img');
            widget = this.addWidgetToEditor($(e.currentTarget), {
                widthPx : image.width(),
                heightPx: image.height()
            });
            e.stopPropagation(); // Prevent bubbling to body where widget focus is removed.
            $(document).trigger(lyr.event.CREATOR_BUTTON_ADD, [widget]);
        }
    },

    sendDeleteRequest: function(buttonID, button, confirmInUse) {
        var data = {id: buttonID, confirm: confirmInUse ? '1' : ''};
        $.post(this.deleteURL, data, function(json) {
            this.handleDeleteResponse(json, buttonID, button);
        }.bind(this));
    },

    attemptDeleteButton: function(e) {
        var button, buttonData, buttonID, ok;

        button = $(e.currentTarget).parents('.btg-button');
        buttonData = button.data('button');
        buttonID = buttonData.type_id || buttonData.id;

        ok = function() {
            this.sendDeleteRequest(buttonID, button, 0);
        }.bind(this);

        lyr.confirm('Delete button', 'Are you sure you want to delete this button?', {
            ok: ok,
            offsetObj: button
        });

        // Don't bubble: adds button to canvas
        return false;
    },

    confirmDeleteButtonInUse: function(buttonID, button) {
        var ok = function() {
            this.sendDeleteRequest(buttonID, button, true);
        }.bind(this);

        lyr.confirm('Button is in use', 'This button is placed on one or more pages. It will be removed from all pages. Delete anyway?', {
            ok: ok,
            offsetObj: button
        });
    },

    /** @namespace json.in_use */
    handleDeleteResponse: function(json, buttonID, button) {
        if (!json.error) {
            this.deleteButton(button, json);
        } else if (json.in_use) {
            this.confirmDeleteButtonInUse(buttonID, button);
        } else {
            lyr.alert('Error', json.message);
        }
    },

    deleteButton: function(button, json) {
        button.fadeOut(function() {
            this.toggleIntroDisplay();
        }.bind(this));
        $(document).trigger(lyr.event.CREATOR_BUTTON_DELETE, [json.id]);
    },

    // Allow buttons in the toolbar to be dragged on the reference image.
    makeButtonDraggable: function(button) {
        var dragStart, dragStop,
            buttonImage = button.find('img');

        dragStart = function(e, ui) {
            this.dragStart(e, ui, button, buttonImage);
        }.bind(this);

        dragStop = this.dragStop.bind(this);

        buttonImage.draggable({
            appendTo       : 'body',
            helper         : 'clone',
            cursor         : 'move',
            revert         : 'invalid',
            revertDuration : 200,
            scroll         : false,
            zIndex         : 1001, // Cover lightbox
            start          : dragStart,
            stop           : dragStop
        });
    },

    dragStart: function(e, ui, button, buttonImage) {
        $('html').css({overflow: 'hidden'});

        ui.helper.data(button.data()).attr({
            width : buttonImage.width(),
            height: buttonImage.height()
        });

        if (!this.editorWgt.viewOnlyMode) {
            this.editorWgt.canvas.droppable({
                tolerance : 'fit',
                drop      : this.dragDrop.bind(this)
            });
        }
    },

    dragStop: function() {
        this.editorWgt.canvas.droppable('destroy');
        window.setTimeout(function() {
            $('html').removeAttr('style');
        }, 210);
    },

    dragDrop: function(event, ui) {
        var coords, dimensions, offset, dragOffset, refImgOffset, widget;

        dragOffset = ui.helper.offset();
        refImgOffset = this.editorWgt.page.element.offset();

        dimensions = {
            width  : ui.helper.width(),
            height : ui.helper.height()
        };

        coords = {
            top  : dragOffset.top  - refImgOffset.top,
            left : dragOffset.left - refImgOffset.left
        };

        offset = this.editorWgt.coordsToOffset(dimensions, coords);

        widget = this.addWidgetToEditor(ui.helper, {
            widthPx  : ui.helper.width(),
            heightPx : ui.helper.height(),
            offset_x : offset.x,
            offset_y : offset.y
        });

        this.editorWgt.setDirty(true);

        $(document).trigger(lyr.event.CREATOR_BUTTON_ADD, [widget]);
    },

    addWidgetToEditor: function(dataElement, dimensionalData) {
        var button, widget;

        button        = $.extend({}, dataElement.data('button'), dimensionalData);
        button.width  = 100 * (button.width / this.editorWgt.page.width);
        button.height = 100 * (button.height / this.editorWgt.page.height);

        if (!button.type_id) {
            button.type_id = button.id;
            delete button.id;
        }

        widget = this.editorWgt.addWidget(button);
        this.editorWgt.focusWidget(widget);

        return widget;
    }

});

/**
 * Rejected page actions.
 * Lightbox.
 */
lyr.wgt.set('btg-rejected-actions', {

    init: function() {
        this.editorWgt          = lyr.wgt.get('.btg-editor', 'btg-editor');
        this.deleteURL          = this.element.data('delete-url');
        this.deleteAllButton    = this.element.find('.remove-all-pages').assert();
        this.deleteSingleButton = this.element.find('.remove-this-page').assert(0, 1);
        this.bindEvents();
    },

    bindEvents: function() {
        this.deleteAllButton.on('click', this.deleteAll.bind(this));
        this.deleteSingleButton.on('click', this.deleteSingle.bind(this));
    },

    deleteAll: function(e) {
        var keys = [], rejected, options;

        rejected = this.editorWgt.getPagesInNav().filter('.rejected');
        for (var i = 0, m = rejected.length; i < m; i++) {
            keys.push(rejected[i].id.substr(1));
        }

        options = {
            ok: function() { this.deletePages(keys); }.bind(this),
            offsetObj: e.currentTarget
        };

        lyr.confirm(
            'Delete all rejected pages',
            'Are you sure you want to delete all rejected pages? ' +
            'This action cannot be undone.',
            options
        );
    },

    deleteSingle: function() {
        this.deletePages([this.editorWgt.page.key]);
    },

    deletePages: function(pages) {
        lyr.toggleLoading(this.element.closest('.overlay'), true);
        $.post(this.deleteURL, {keys: JSON.stringify(pages)})
            .success(this.removePagesFromDoc.bind(this));
    },

    removePagesFromDoc: function(json) {
        if (json.error) {
            lyr.alert('Error', json.message);
        } else {
            for (var i = 0, m = json.keys.length; i < m; i++) {
                $(document).trigger(lyr.event.PAGE_DELETED, [json.keys[i]]);
            }
        }
    }

});


/**
 * Button Accordion
 */
lyr.wgt.set('btg-button-accordion', {

    speed: 200,

    init: function() {
        this.endpoint = this.element.data('endpoint');
        this.panels = this.element.children('div').assert(2, 10);
        this.setDimensions();
        this.bindEvents();
    },

    setDimensions: function() {
        this.collapsedPanelheight = this.element.find('h1:first').height();
        this.containerHeight = this.element.height();
        this.panelHeight = this.containerHeight - (this.panels.length * this.collapsedPanelheight);
        this.expand(this.panels.filter('.expanded'), 0);
    },

    bindEvents: function() {
        this.element.on('click', 'h1', this.clickEvent.bind(this));
        $(window).on(lyr.event.WINDOW_RESIZE, this.setDimensions.bind(this));
    },

    clickEvent: function(e) {
        var target = $(e.currentTarget).parent();
        if (target.hasClass('expanded')) {
            this.collapse(target, this.speed);
            this.store(-1);
        } else {
            lyr.trackEvent('Creator', 'Open Button Group', target.data('name'));
            this.collapse(this.panels.not(target), this.speed);
            this.expand(target, this.speed);
            this.store(target.data('id'));
        }
        return false;
    },

    collapse: function(target, speed) {
        target.find('ul').animate({maxHeight: 0}, speed);
        target.removeClass('expanded').addClass('collapsed');
    },

    expand: function(target, speed) {
        target.find('ul').animate({maxHeight: this.panelHeight}, speed, function() {
            target.addClass('expanded').removeClass('collapsed');

            // Trigger scrollbar indication in Mac OSX Lion
            $(this).scrollTop(1).scrollTop(0);
        });
    },

    store: function(id) {
        if (this.xhr) {
            this.xhr.abort();
        }
        this.xhr = $.post(this.endpoint, {expanded: id});
    }

});


/**
 * Create a new button
 */
lyr.wgt.set('btg-create-button', {

    init: function() {
        this.element.on(lyr.event.FORM_SUCCESS, this.onSuccess.bind(this));
    },

    onSuccess: function(e, json) {
        $(document).trigger(lyr.event.CREATOR_BUTTON_CREATE, [json.widget]);
        lyr.lightbox.closeAll();
    }

});


/**
 * Widget for navigating through pages
 */
lyr.wgt.set('btg-pages-nav', {

    init: function() {
        this.list         = this.element.find('.btg-figure-list').assert();
        this.pageTemplate = $('#mustache-nav-page').html(); //_sidebar_page_template.html
        this.bindEvents();
    },

    bindEvents: function() {
        $(document).on(lyr.event.PAGE_UPLOAD_WIZARD_COMPLETE, function(e, page) {
            if (page) {
                this.addPages(page);
                location.href = '#P' + page.key;
            }
        }.bind(this));

        $(document).on(lyr.event.CREATOR_PAGES_SELECT, function(e, pages) {
            this.addPages(pages);
            window.location.replace('#P' + pages[0].key);
        }.bind(this));

        $(document).on(lyr.event.PAGE_DELETED, function(e, key) {
            this.element.find('#P' + key).remove();
        }.bind(this));

        $(document).on(lyr.event.PAGE_REORDER, function(e, order) {
            for (var i = 0, m = order.length; i < m; i++) {
                this.list.append($('#P' + order[i]));
                location.replace(location.hash);
            }
        }.bind(this));
    },


    /**
     * Appends pages within data object/s to this.list
     * @param data: expects {key, thumbnail, title, processed }
     */
    addPages: function(data) {
        var pages = Mustache.render(this.pageTemplate, data);
       //window.alert(pages)
        //lyr.wgt.scan();
        //window.alert(data.key)
        this.list.append(pages);
       var e = this.list.find("#P"+data.key).find(".wgt_ratting");
       lyr.wgt.scan(e);
       //window.alert(888);
    }

});


/**
 * Widget for editing
 */
lyr.wgt.set('btg-editor', {

    init: function() {
        this.focusClass     = 'btg-widget-focus';
        this.currentFocus   = false;
        this.ignoreNextHash = false; // Used during switching pages prompt with unsaved changes

        this.docTitleArr    = document.title.split(' – ');
        this.pageTitleEl    = $('.btg-page-title');
        this.pageStatusEl   = $('.btg-page-status');

        this.loading        = this.element.find('.btg-canvas-loading').assert();
        this.canvas         = this.element.find('.btg-canvas').assert();
        this.nopages        = this.element.find('.btg-editor-no-pages'); // Empty in view-only

        this.getPageURL     = this.element.data('get-page-url');
        this.getStatusURL   = this.element.data('get-status-pages-url');

        this.widgetFormURL  = this.element.data('widget-form-url');
        this.widgetDeleteURL= this.element.data('widget-delete-url');
        this.widgetUpdateURL= this.element.data('widget-update-url');

        this.actionPanel    = this.element.data('action-panel');
        this.processingLB   = this.element.data('processing-lightbox');
        this.rejectedPanel  = this.element.data('page-rejected-panel');

        this.statisticsMode = this.element.data('statistics-mode');
        this.viewOnlyMode   = this.element.data('view-only-mode');

        this.layerName      = this.element.data('layer');
        this.layerPaid      = this.element.data('layer-paid');
        this.pageData       = {};
        
        this.targetGroupId  = this.element.data('target-groupid');
        this.editBtnEl = this.element.find(".btg-save-button");
        this.targetInfoEl = $("#btg-targetItemInfo");
        
        this.loadInitialPage();
       
        this.preventDirtyExit();
        this.bindEvents();
        
        
//        window.alert(this.editBtnEl.eq(0).data().url);
        //window.alert(this.editBtnEl.length);

        if (!this.viewOnlyMode) {
            this.unprocessedPagesDaemon();
        }


    },

    getPadding: function() {
        return { x: 32, y: this.viewOnlyMode ? 18 : 80 };
    },

    confirmExit: function(settings) {
        lyr.confirmYesNo('Unsaved changes', '没有保存，需要推出么？', settings);
    },
    
    setEditUrl : function (key){
//        alert( this.editBtnEl );
    //window.alert(this.editBtnEl.eq(0).data().url);
//        window.alert(this.editBtnEl.eq(0).data().url+" == " + this.targetGroupId);
        this.editBtnEl.eq(0).data().url = "editTargetPage.do?key="+key+"&targetGroupId="+this.targetGroupId;
        //window.alert(this.targetInfoEl.attr("src"));
        this.targetInfoEl.attr("src","targetItemInfo.do?key="+key);
    },

    // Load new page when #hash changes
    addHashChangeEvent: function() {
        $(window).on('hashchange', function() {
            var save, ok, redirect, page = this.getPageByHash();

            if (!page.length) {
                return false;
            }

            // We're just restoring the correct hash in the address bar
            if (this.ignoreNextHash || page.attr('id') === this.page.key) {
                this.ignoreNextHash = false;
                return false;
            }

            redirect = function() {
                this.loadPage(page);
            }.bind(this);
            
//            this.setEditUrl(this.page.key);

            save = function() {
                var savePageWgt = lyr.wgt.get('.btg-save-page', 'btg-save-page');
                savePageWgt.saveIntent(redirect);
            };

            ok = function() {
                this.ignoreNextHash = true;
                location.href = '#P' + this.page.key;
                save();
            }.bind(this);

            // If there are unsaved changes, confirm with user first
            if (!this.dirty) {
                this.loadPage(this.getPageByHash());
            } else {
                this.confirmExit({ok: ok, cancel: redirect, offsetObj: page});
            }
        }.bind(this));
    },

    // Exit by clicking a hyperlink (hash links and external links are excluded)
    preventDirtyExit: function() {
        $(document).on('click', 'a[href]:not([target])', this.externalLinkClick.bind(this));
    },

    externalLinkClick: function(e) {
        var redirect, ok, href = $(e.currentTarget).attr('href');

        redirect = function() {
            location.href = href;
        };

        ok = function() {
            var savePageWgt = lyr.wgt.get('.btg-save-page', 'btg-save-page');
            savePageWgt.saveIntent(redirect);
        };

        if (this.dirty && href.charAt(0) !== '#') {
            this.confirmExit({ok: ok, cancel: redirect, offsetObj: e.currentTarget});
            return false;
        }
    },

    // Get current page by hash
    getPageByHash: function() {
        var page = false;
        if (location.hash && location.hash !== '#' && $(location.hash).length) {
            page = $(location.hash);
        }
        return page;
    },

    getPageByKey: function(key) {
        var page = $('#P' + key);
        return (page.length) ? page : false;
    },

    getPagesInNav: function() {
        return $('.btg-page-nav').on('mousedown',
            function(e) { e.preventDefault(); }); // Prevent dragging;
    },

    loadInitialPage: function() {
        var page = this.getPageByHash() || this.getPagesInNav().eq(0);
        
//        window.alert(111)
//        
//        window.alert(location.hash)
//        return;

        this.resetPage();
       
        if (page.length) {
//            this.setEditUrl(page.attr('id'));
            if (!location.hash || location.hash === '#') {
                location.replace('#' + page.attr('id'));
            } else {
                this.loadPage(page);
            }
        } else {
            this.noPagesYet();
        }
    },

    // Load a new page using Ajax
    loadPage: function(page) {
        var data = {page: page.attr('id').substr(1)};

        if (this.statisticsMode && page.find('.draft').length) {
            lyr.alert('Page not published', 'This page is not yet published. In order to activate page level statistics for it, please go back to the Campaign Overview and publish it.');
            return false;
        }

        this.getPagesInNav().removeClass('selected');
        page.addClass('selected');

        if (!page.length || (this.page.key && this.page.key === data.page)) {
            return false;
        }

        this.nopages.hide();
        this.resetPage();
        this.toggleLoading(true);
        this.setEditUrl(data.page);
        $(document).trigger(lyr.event.PAGE_LOAD_START, [data]);
        
        if (this.xhr) {
            this.xhr.abort();
        }
        this.xhr = $.get(this.getPageURL, data, function(json) {
            this.paintPageAndWidgets(json, {});
        }.bind(this));
    },

    noPagesYet: function() {
        this.toggleLoading(false);
        this.resetPage();
        this.canvas.hide();
        this.nopages.show();
        this.setTitle('');
    },

    resetPage: function() {
        this.page = {};
        this.pageData = {};
        this.scale = 1;
        this.setTitle();
        this.setDirty(false);
        this.emptyCanvas();
        this.viewOnlyMode = false;
    },

    emptyCanvas: function() {
        this.canvas.children().not('.btg-save-page,.btg-sample-page').remove();
        this.closeOverlays();
    },

    closeOverlays: function() {
        var overlay = this.rejectedOverlay;
        if (overlay) {
            overlay.close();
            this.rejectedOverlay = null;
        }
    },

    page404: function(prefix) {
        lyr.confirm('Error', prefix + '<br><br>' + 'It seems the editor is ' +
            'out of sync with the database. This can happen when changes were ' +
            'made to the campaign outside of this window.' + '<br><br>' + 'Do ' +
            'you want to reload the editor now to get the latest changes?', {
            ok: function() {
                location.replace('#'); // Don't reload 404-ing page
                window.location.reload(true);
            }
        });
    },

    toggleLoading: function(loading) {
        if (loading) {
            this.loading.show();
            this.canvas.hide();
        } else {
            this.loading.hide();
            this.canvas.show();
        }
    },

    paintPageAndWidgets: function(json, opts) {
        this.toggleLoading(false);
        if (!json.error) {
            if (!opts.repaint) {
                this.pageData  = json.page;
            }

            this.page = this.setPage(this.pageData, opts);
            this.setTitle(this.pageData.title || '');//("eleven");//(this.pageData.title || '');
//            var pageEl = this.getPageByKey(this.pageData.key);
//            
//            if(this.pageData.item_status == "C"){
//                var statusEl = pageEl.find(".numpages");
//                statusEl.show();
//                window.alert(1);
//            }
            
//            window.alert(this.pageData.item_status);
//            window.alert(pageEl.attr("id"));
//            this.handlePageStatus();

//            if (!this.pageData.rejected) {
////                this.addWidgets(this.pageData.widgets);
//            }

//            if (this.pageData.stats) {
//                this.setStatistics(this.pageData.stats);
//            }

//            if (this.pageData.slices) {
//                this.showSlices(this.pageData.slices);
//            }

            location.replace('#P' + this.page.key);
//            $(document).trigger(lyr.event.PAGE_LOAD_COMPLETE, [this, json]);
        } else {
            this.page404(json.message);
        }
    },

    // Updates editor title and document title
    setTitle: function(title) {
        var docTitleArr = this.docTitleArr;
        docTitleArr.splice(1, 1, title);
        docTitleArr = $.grep(docTitleArr, function(tit){ return !!tit; });
        document.title = docTitleArr.join(' – ');

        this.pageTitleEl.text(title);
        this.setStatusBadgeLabel();
    },

    setStatusBadgeLabel: function() {
        var title = '', page = this.pageData;

        if (page.rejected) {
            title = 'Rejected';
        }

        else if (!$.isEmptyObject(page)) {
            if (!page.processed) {
                title = 'Analyzing…';
            } else if (this.layerPaid && !page.published) {
                title = 'Draft';
            }
        }

        this.pageStatusEl.text(title).toggle(!!title);
    },

    setStatistics: function(stats) {
        for (var k in stats) {
            if (stats.hasOwnProperty(k)) {
                // Format number if it isn't a float
                var num = (stats[k] % 1 === 0) ?
                    lyr.format.intcomma(stats[k]) :
                    stats[k];
                $('#btg-stats-page-' + k).text(num);
            }
        }
    },

    showSlices: function(slices) {
        this.canvas.find('.btg-slice').remove();
        for (var i = 0, m = slices.length; i < m; i++) {
            var el, slice = slices[i];
            el = $('<div>');
            el.data('id', slice.id);
            el.addClass('btg-slice');
            el.css({
                width : this.scale * slice.width,
                height: this.scale * slice.height,
                left  : this.scale * slice.x,
                top   : this.scale * slice.y
            });
            el.appendTo(this.canvas);
        }
    },

    setNumWidgets: function(numpages) {
        var page = this.getPageByKey(this.page.key),
            counter = page.find('.numpages');
        if (counter.length) {
            counter.text(numpages);
            counter.toggle(!!numpages);
        }
    },

    setPage: function(props, opts) {
        var page, width, height;
        
        this.scale = this.getPageScale(props);

        width  = this.scale * props.width;
        height = this.scale * props.height;

        page = $('<img>').addClass('btg-page').attr({src: props.image});
        page.appendTo(this.canvas);
        page.on('mousedown', function(e) { // Prevent browser-native dragging
            e.preventDefault();
        });

        page.toggleClass('rejected', props.rejected);

        this.canvas.css({
            width  : Math.round(width),
            height : Math.round(height),
            opacity: opts.repaint ? 1 : 0
        }).delay(100).fadeTo(300, 1);
//        console.log($(".btg-canvas").html());
        return {
            element   : page,
            width     : width,
            height    : height,
            key       : props.key,
            realWidth : props.real_world_width,
            realHeight: props.real_world_height
        };
    },

    getPageScale: function(props) {
        var scale, maxWidth, maxHeight, width, height,
            padding = this.getPadding();

        scale     = 1;
        maxWidth  = Math.max(450, this.element.width() - padding.x);
        maxHeight = Math.max(450, this.element.height() - padding.y);
        width     = props.width;
        height    = props.height;

        if (width > maxWidth || height > maxHeight) {
            scale = Math.min(
                maxWidth  / width,
                maxHeight / height
            );
        }

        return scale;
    },

    repaintCanvas: function() {
        var saveData = (this.viewOnlyMode) ? {} : {
            widgets: this.getRepaintData()
        };
        this.emptyCanvas();
        this.paintPageAndWidgets(
            {page: $.extend(this.pageData, saveData)}, {repaint: true}
        );
    },

    getRepaintData: function() {
        var data = [], widgets = this.getWidgets();
        for (var i = 0, m = widgets.length; i < m; i++) {
            var wgt = lyr.wgt.get(widgets[i], 'btg-widget');
            data.push(wgt.getAllData());
        }
        return data;
    },

    addWidgets: function(widgets) {
        var collectWidgets = [], widget;
        for (var i = 0, m = widgets.length; i < m; i++) {
            widget = this.addWidget(widgets[i]);
            collectWidgets.push(widget);
        }
        this.setNumWidgets(collectWidgets.length);
        return collectWidgets;
    },

    bindEvents: function() {
        this.addHashChangeEvent();

        if (!this.viewOnlyMode) {
            this.addWidgetFocusHandler();
            this.managePagesProxyButton();

            $(document).on('keydown', this.handleUni.bind(this));
            $(document).on('keydown', this.handleKeys.bind(this));
        }

        $(window).on('resize', this.handleResize.bind(this));

        $(document).on(lyr.event.CREATOR_BUTTON_DELETE, function(e, typeid) {
            var widgets = this.canvas.find('.btg-widget-' + typeid);
            for (var i = 0, m = widgets.length; i < m; i++) {
                $(widgets[i]).remove();
            }
        }.bind(this));

        $(document).on(lyr.event.PAGE_UPLOAD_WIZARD_COMPLETE, function() {
            if (!this.confirmedProcessing()) {
                this.openProcessingLightbox();
            }
        }.bind(this));

        $(document).on(lyr.event.CREATOR_PROCESSING_CONFIRM, function() {
            this.confirmedProcessing(true);
            lyr.lightbox.closeAll();
        }.bind(this));

        $(document).on(lyr.event.CREATOR_BUTTON_ADD, function(e, widget) {
            lyr.wgt.get(widget, 'btg-widget').openActionLightbox();
        }.bind(this));

        $(document).on(lyr.event.CREATOR_EDITOR_SAVED, function(e, widgets, json) {
            if (json.slices) {
                this.pageData.slices = json.slices;
                this.showSlices(json.slices);
            }
            this.setNumWidgets(widgets.length);
            this.setDirty(false);
        }.bind(this));

        $(document).on(lyr.event.PAGE_RENAME, function(e, key, title) {
            if (key === this.page.key) {
                this.setTitle(title);
            }
        }.bind(this));

        $(document).on(lyr.event.PAGE_DELETED, function(e, key) {
            if (key === this.page.key) {
                this.loadInitialPage();
            }
        }.bind(this));
    },

    unprocessedPagesDaemon: function() {
//    window.alert(this.getStatusURL);
    // $.get(this.getStatusURL).success(this.handleStatusResult.bind(this));
//    return;
    
        window.setInterval(function() {
            
            if (this.hasUnprocessedPages()) {
                $.get(this.getStatusURL).success(this.handleStatusResult.bind(this));
            }
        }.bind(this), 10 * 1500);
    },

    confirmedProcessing: function(confirm) {
        var key = 'btg_process_msg_' + this.layerName;
        if (typeof confirm === 'undefined') {
            return !!lyr.storage(key); // Get
        } else {
            lyr.storage(key, true); // Set
        }
    },

    hasUnprocessedPages: function() {
//        window.alert(!!this.getPagesInNav().not('.processed').length)
        return !!this.getPagesInNav().not('.processed').length;
    },

    handleStatusResult: function(json) {
//        window.alert(json + " " +this.getPagesInNav().not('.processed').length)
        console.log(json);
        for (var k in json) {
           
            if (json.hasOwnProperty(k)) {
                var page = json[k], pageEl = this.getPageByKey(page.key);
//                window.alert(pageEl.find(".rating").data().average)
//                window.alert(page.item_status+"======");
//                window.alert(pageEl.length)
                if (pageEl && !!pageEl.not(".processed").length) {
//                  if(pageEl){
//                window.alert(!!pageEl.not(".processed").length)
                    var itemStatus = "";
                    if(page.item_status == "C"){
                        pageEl.toggleClass('processed', true);
//                        pageEl.find(".numpages").show();
                        pageEl.find(".numpages").text(page.item_rating);
                        
                        pageEl.find(".wgt_ratting").trigger("ChangeRating",page.item_rating*4);
                        
                        
                        itemStatus = "完成";
                    }else if(page.item_status == "P"){
                        pageEl.find(".numpages").hide();
                        itemStatus = "创建中";
                    }else if(page.item_status == "F"){
                        pageEl.toggleClass('processed', true);
                        itemStatus = "创建失败";
                    }
                    
                    pageEl.find(".processing-badge").text(itemStatus);
                
//                    pageEl.toggleClass('processed', page.processed);
//                    pageEl.toggleClass('rejected', page.rejected);
//                    pageEl.find('.processing-badge').toggle(!page.processed);
//                    pageEl.find('.rejected-badge').toggle(page.rejected);
                }
//                this.repaintIfCurrentPageAndAffected(page);
            }
        }
    },

    repaintIfCurrentPageAndAffected: function(page) {
        if (page.key === this.page.key) {
            for (var k in page) {
                if (page.hasOwnProperty(k) && this.pageData[k] !== page[k]) {
                    $.extend(this.pageData, page);
                    this.repaintCanvas();
                }
            }
        }
    },

    widgetWgtMap: {
        carousel             : 'btg-widget-preview-carousel',
        interactive_carousel : 'btg-widget-preview-carousel',
        video                : 'btg-widget-preview-video',
        youtube              : 'btg-widget-preview-video'
    },

    removeInvalidWidget: function(data, error) {
        console.error('Invalid button', data, error);
        $.post(this.widgetDeleteURL, {id: data.id});
        window.setTimeout(function() { throw new Error(error); }, 0);
    },

    addWidget: function(data) {
        var widget, wgt, wgts = [];

        // Detect corrupt widgets
        if (!data.action || !data.action.name) {
            return this.removeInvalidWidget(data, 'Button without action!');
        }

        if (!data.url && !data.meta.frame_url) {
            return this.removeInvalidWidget(data, 'Button without source URL');
        }

        // Append widgets
        wgts.push('btg-widget');

        // Only append preview widgets in Creator editing mode
        if (!this.viewOnlyMode) {
            wgts.push(this.widgetWgtMap[data.action.name] || '');
        }

        // Apply widgets
        widget = $('<div>').data('tmpdata', data);
        widget.addClass('btg-widget-' + data.type_id);
        widget.attr('data-wgt', wgts.join(' '));
        lyr.wgt.scan(widget);

        return widget;
    },

    addWidgetFocusHandler: function() {
        var listenElements = 'body, .lyr-lb-lightbox, .lyr-lb-vitrage, .btg-widget';

        // Remove focus from widget when something else than the widget is clicked
        // Make exception for the lightbox
        $('html').on('click touchstart', listenElements, function(e) {
            var clicked = $(e.currentTarget);
            if (clicked.is('body')) {
                this.blurWidgets();
            } else {
                if (clicked.hasClass('btg-widget')) {
                    this.focusWidget(clicked);
                }
                e.stopPropagation();
            }
        }.bind(this));
    },

    getFocusedWidget: function() {
        var widget = $('.' + this.focusClass);
        return (widget.length) ? widget : false;
    },

    focusWidget: function(widget) {
        // Don't refocus same object again
        if (widget[0] !== this.currentFocus[0]) {
            this.blurWidgets();
            this.currentFocus = widget;
            widget.addClass(this.focusClass);
            this.zIndexWidgets(widget);
        }
    },

    getWidgets: function() {
        return $('.btg-widget');
    },

    zIndexWidgets: function(widget) {
        var group, widgets = this.getWidgets();

        if (widgets.length < 2) {
            return;
        }

        group = $.makeArray(widgets).sort(function(a, b) {
            var aa = (parseInt($(a).css('zIndex'), 10) || 0),
                bb = (parseInt($(b).css('zIndex'), 10) || 0);
            return aa - bb;
        });

        $(group).each(function(i) {
            this.style.zIndex = i + 1;
        });

        widget[0].style.zIndex = group.length;

        this.setDirty(true);
    },

    // Remove active widget focus if it's not the element being dragged.
    dragStartFocus: function(e, ui) {
        if (ui.helper[0] !== this.getFocusedWidget()[0] && !('ontouchend' in document)) {
            this.blurWidgets();
        }
    },

    blurWidgets: function() {
        this.currentFocus = false;
        $('.' + this.focusClass).removeClass(this.focusClass);
    },

    handlePageStatus: function() {
        var pageEl = this.getPageByKey(this.pageData.key),
            rejected = this.pageData.rejected,
            processed = this.pageData.processed;

        window.alert(rejected + "  " + processed);

        pageEl.find('.processing-badge').toggle(!processed);
        pageEl.toggleClass('processed', processed);
        pageEl.toggleClass('rejected', rejected);

        this.viewOnlyMode = (this.statisticsMode) ? true : rejected;

        $('.btg-save-page').toggle(!rejected);
        if (rejected) {
            this.openRejectedPanel();
        }
    },

    openProcessingLightbox: function() {
        lyr.lightbox.open({
            html    : this.processingLB,
            width   : 600,
            addClass: 'overlay-page-processing'
        });
    },

    openRejectedPanel: function() {
        var rejectedCount, rejectedPanel, settings;

        rejectedCount = this.getPagesInNav().filter('.rejected').length;

        rejectedPanel = lyr.tpl(this.rejectedPanel);
        rejectedPanel.find('.remove-all-pages').toggle(rejectedCount >= 2);
        rejectedPanel.find('.rejected-count').text(rejectedCount);

        settings = $.extend({}, {
            html           : rejectedPanel,
            width          : 'auto',
            addClass       : 'overlay overlay-page-rejected',
            top            : 162,
            animateOnResize: false,
            vitrage        : false,
            closeButton    : false
        });

        this.rejectedOverlay = (new lyr.Lightbox()).open(settings);
    },

    // Special resize handler because jQuery UI's resizable also triggers
    // the resize event.
    handleResize: function(e) {
        if (!e.target.tagName) {
            $(window).trigger(lyr.event.WINDOW_RESIZE);
            window.clearTimeout(this._resizeTimeout);
            this._resizeTimeout = setTimeout(this.delayedResize.bind(this), 150);
        }
    },

    // Resize after a delay because repainting the canvas is expensive.
    delayedResize: function() {
        $(window).trigger(lyr.event.WINDOW_RESIZE_DELAY);
        var scaled = this.pageScaleChanged(this.pageData);
        if (this.canvas.is(':visible') && !lyr.lightbox.anyOpen() && scaled) {
            this.repaintCanvas();
            this._resizeTimeout = null;
        }
    },

    pageScaleChanged: function(props) {
        return this.scale !== this.getPageScale(props);
    },

    handleKeys: function(e) {
        var distance, widget, multiplier, pos, widgetWgt;

        distance = this.getKeyPressDistance(e);
        widget = this.getFocusedWidget();

        if (!widget || $(':input:focus').length || lyr.lightbox.anyOpen() || e.metaKey) {
            return true; // Exit and bubble
        }

        pos = widget.position();
        multiplier = e.shiftKey ? 5 : 1;

        switch (e.keyCode) {
            case 27: this.blurWidgets(); break; // Esc
            case 37: pos.left -= distance * multiplier; break; // Left
            case 38: pos.top  -= distance * multiplier; break; // Up
            case 39: pos.left += distance * multiplier; break; // Right
            case 40: pos.top  += distance * multiplier; break; // Down
            case 46:
                widgetWgt = lyr.wgt.get(widget, 'btg-widget');
                widgetWgt.confirmDelete({currentTarget: widget}); break;

            default: return true; // Exit and bubble
        }

        pos.left = Math.max(0, pos.left);
        pos.top = Math.max(0, pos.top);

        pos.left = Math.min(this.page.width - widget.width(), pos.left);
        pos.top = Math.min(this.page.height - widget.height(), pos.top);

        widget.css(pos);
        this.setDirty(true);

        e.preventDefault(); // Don't scroll page
    },

    // Detect a key modifier
    getKeyPressDistance: function(e) {
        var standard = 1,
            modified = 10;

        if (e.shiftKey) { return modified; }

        return standard;
    },

    handleUni: function(e) {
        var uni = [85, 78, 73, 67, 79, 82, 78],
            uniURL = '/static/img/btg-uni.png';
        if ($(':focus').is(':input')) { return true; }
        this._unilog = (this._unilog || []).slice((uni.length - 1) * -1);
        this._unilog.push(e.keyCode);
        if (uni.join('') === this._unilog.join('')) {
            lyr.preloadImage(uniURL, function(url, width) {
                lyr.alert('Hello!', '<img src="' + url + '" class="btg-wiggle">', {width: width + 40});
            });
        }
    },

    managePagesProxyButton: function() {
        this.nopages.find('button').on('click', function() {
            $('.btg-manage-pages-button').click();
        });
    },

    setDirty: function(dirty) {
        if (!this.viewOnlyMode) {
            this.dirty = dirty;
            $(document).trigger(lyr.event.CREATOR_EDITOR_DIRTY, [dirty]);
        }
    },

    // Coordinates in pixels calculated from left-top of reference image,
    // converted to relative offset X and Y in meters from center of reference image.
    coordsToOffset: function(dimensions, coords) {
        var offset,
            refWidth   = this.page.width,
            refHeight  = this.page.height,
            realWidth  = this.page.realWidth,
            realHeight = this.page.realHeight;

        offset = {
            x: (realWidth / -2)  + realWidth  * ((coords.left + (dimensions.width / 2)) / refWidth),
            y: (realHeight / -2) + realHeight * ((coords.top + (dimensions.height / 2)) / refHeight)
        };

        offset.y *= -1;

        return offset;
    },

    // Relative offset X and Y in meters from center of reference image,
    // converted to pixels calculated from left-top of reference image.
    offsetToCoords: function(dimensions, offsets) {
        var coords,
            refWidth   = this.page.width,
            refHeight  = this.page.height,
            realWidth  = this.page.realWidth,
            realHeight = this.page.realHeight;

        offsets.y *= -1;

        // Offset
        coords = {
            left: refWidth / 2 + (refWidth / realWidth) * offsets.x,
            top: refHeight / 2 + (refHeight / realHeight) * offsets.y
        };

        // Take center of image as anchor
        coords.left -= dimensions.width / 2;
        coords.top -= dimensions.height / 2;

        return coords;
    }

});

/**
 * Page Widget
 * (buttons on page)
 */
lyr.wgt.set('btg-widget', {

    init: function() {
        this.minButtonSize = 15;
        this.zMagnitude = 10000; // Meter (metric) to z-index factor
        this.editorWgt = lyr.wgt.get('.btg-editor', 'btg-editor');

        this.setData(this.element.data('tmpdata'));
        this.element.removeData('tmpdata');

        this.setupStructure();
        this.setPosition();
        this.addPanels();

        this.element.appendTo(this.editorWgt.canvas);
        this.scaleWidgetFrame();

        if (!this.editorWgt.viewOnlyMode) {
            this.addInteraction();
            this.bindEvents();
        }
    },

    // Set data
    // Get rid of all properties that are no longer required
    setData: function(data) {
        delete data.sidebar_height;
        delete data.title;
        this.data = data;
        this.data.meta = this.data.meta || {};
    },

    setMeta: function(meta, callback) {
        // Properties that are required for back-end,
        // but should not be stored in front-end.
        meta.widget_id  = this.data.id;
        meta.page_key   = this.editorWgt.page.key;
        meta.layer_name = this.editorWgt.layerName;

        this.storeServerMeta(meta, callback);
        this.removeError('action');
        this.checkBounds(true);

        this.element.trigger(lyr.event.WIDGET_META_SET, [meta]);
    },

    setID: function(id) {
        this.element.attr('id', 'W' + id);
        this.data.id = id;
    },

    refresh: function(extendData) {
        var data, replacement;

        data = this.getAllData();
        $.extend(data, extendData || {});

        // Add my replacement
        replacement = this.editorWgt.addWidget(data);
        this.editorWgt.focusWidget(replacement);

        // I'll show myself out :(
        this.element.remove();
    },

    storeServerMeta: function(meta, callback) {
        $.post(this.editorWgt.widgetUpdateURL, meta).success(function(json) {
            // Re-use ajaxsubmit object, which already has methods to handle
            // form errors properly.
            var AjaxForm = lyr.wgt.obj('ajaxsubmit'),
                ajaxform = new AjaxForm();

            // Element on which error events are triggered.
            ajaxform.element = $('.btg-action-form:last');
            ajaxform.buttons = ajaxform.element.find('.buttons');

            // Gets called when there are no errors in the json.
            ajaxform.success = function() {
                var meta = json.widget.meta;

                this.data.meta = json.widget.meta;
                this.data.url = json.widget.url;

                if (callback) {
                    callback(meta, json);
                }
            }.bind(this);

            // Start the handler.
            ajaxform.handleJsonResponse(json);

        }.bind(this));
    },

    setupStructure: function() {
        this.preview = $('<figure>').addClass('btg-preview').hide();
        this.content = $('<figure>').addClass('btg-content');
        this.cover   = $('<div>').addClass('btg-preview-cover');
        this.content.html(this.generateContent());

        this.element.append(this.preview, this.content, this.cover);
        if (this.data.id) {
            this.setID(this.data.id);
        }

        this.element.addClass('btg-widget btg-widget-' + this.data.action.name);
    },

    setPosition: function() {
        var data = this.data, width, height, dimensions, coords, zIndex;

        // Shortcut in case we already know pixel size
        if (data.widthPx && data.heightPx) {
            width  = data.widthPx;
            height = data.heightPx;
            delete data.widthPx;
            delete data.heightPx;
        }

        // Relative size to pixel size
        else {
            width  = this.editorWgt.page.width  * (data.width  / 100);
            height = this.editorWgt.page.height * (data.height / 100);
        }

        dimensions = {
            width  : Math.max(width,  this.minButtonSize),
            height : Math.max(height, this.minButtonSize)
        };

        coords = this.editorWgt.offsetToCoords(dimensions, {
            x: data.offset_x || 0,
            y: data.offset_y || 0
        });

        zIndex = (data.offset_z) ? Math.round(data.offset_z * this.zMagnitude) : 1;

        this.element.css({
            left  : Math.round(coords.left),
            top   : Math.round(coords.top),
            width : dimensions.width,
            height: dimensions.height,
            zIndex: zIndex
        });
    },

    addPanels: function() {
        if (this.editorWgt.viewOnlyMode) {
            this.element.addClass('btg-widget-view-only');
            if (this.editorWgt.statisticsMode) {
                this.addStatistics();
                this.addStatisticsPanel();
            }
        } else {
            this.actionPanel = this.getActionPanel();
            this.actionPanel.appendTo(this.element);
        }
    },

    bindEvents: function() {
        this.cover.on('dblclick', this.openActionLightbox.bind(this));
        this.element.on(lyr.event.CREATOR_BUTTON_ERROR, function(e, marking) {
            this.addError(marking);
            this.checkBounds();
        }.bind(this));
    },

    getActionPanel: function() {
        var panel, deleteButton, editButton;

        panel = lyr.tpl(this.editorWgt.actionPanel);

        deleteButton = panel.find('.delete');
        deleteButton.on('click touchstart', this.confirmDelete.bind(this));

        editButton = panel.find('.edit');
        editButton.on('click touchstart', this.openActionLightbox.bind(this));

        return panel;
    },

    confirmDelete: function(e) {
        lyr.confirm('Delete button', 'Are you sure you want to delete this button?', {
            offsetObj: e.currentTarget,
            ok       : this.remove.bind(this)
        });
        return false;
    },

    generateContent: function() {
        var content, data = this.data;
        if (data.meta && data.meta.frame_url) {
            content = $('<iframe>');
            content.data('viewport_width', data.meta.viewport_width);
            content.attr(lyr.btg.iframeAttrs);
            content.attr({
                src   : data.meta.frame_url + '?' + (+new Date()),
                width : data.meta.viewport_width,
                height: data.meta.viewport_height
            });
        } else if (data.url) {
            content = $('<img>').attr({ src: data.url });
        }
        return content;
    },

    scaleWidgetFrame: function() {
        var scale, frame = this.content.find('iframe');
        if (frame.length) {
            scale = this.element.width() / frame.data('viewport_width');
            lyr.btg.scale(frame, scale);
        }
    },

    // http://bugs.jqueryui.com/ticket/9107
    workAroundBugInjQueryUI: function(ui) {
        var ratio, minWidth, minHeight;

        if (ui.size.width + ui.size.height < this.minButtonSize * 2) {
            ratio = ui.originalSize.width / ui.originalSize.height;
            minWidth  = this.minButtonSize / (ratio < 1 ? ratio : 1);
            minHeight = this.minButtonSize / (ratio > 1 ? ratio : 1);
            ui.element.css({width: minWidth, height: minHeight});
        }
    },

    addInteraction: function() {
        // Resizable, keep aspect ratio
        this.element.resizable({
            minWidth    : this.minButtonSize,
            minHeight   : this.minButtonSize,
            handles     : 'ne, se, sw, nw',
            containment : '.btg-canvas',
            aspectRatio : true,
            start       : this.editorWgt.dragStartFocus.bind(this.editorWgt),
            stop        : this.setDirtyAndCheckBounds.bind(this)
        });

        // Real-time scaling frames
        this.element.resizable('option', 'resize', function(e, ui) {
            this.workAroundBugInjQueryUI(ui);
            this.scaleWidgetFrame();
        }.bind(this));

        // Make draggable
        this.element.draggable({
            containment : '.btg-page',
            handle      : this.cover,
            start       : this.editorWgt.dragStartFocus.bind(this.editorWgt),
            stop        : this.setDirtyAndCheckBounds.bind(this)
        });
    },

    addStatistics: function() {
        var wrap = $('<div>').addClass('btg-stats-widget');
        wrap.attr('style', this.element.attr('style'));
        this.element.wrapAll(wrap);

        this.element.addClass('btg-stats-item');
        this.element.on('mousedown', function() {
            return false; // Prevent drag
        });
    },

    addStatisticsPanel: function() {
        var panel, wrap, formatted = {};

        panel = $('<div>').addClass('btg-stats-panel').appendTo(this.element);
        wrap = $('<div>').addClass('wrap');

        if (formatted) {
            formatted['Button ID'] = this.data.id;
            formatted['Views'] = lyr.format.intcomma(this.data.stats.views);
            if ('interactions' in this.data.stats) {
                formatted['Interactions'] = lyr.format.intcomma(this.data.stats.interactions);
            }
            for (var k in formatted) {
                if (formatted.hasOwnProperty(k)) {
                    var dl = $('<dl>'),
                        dt = $('<dt>').text(k),
                        dd = $('<dd>').text(formatted[k]);
                    dl.append(dt, dd).appendTo(wrap);
                }
            }
        } else {
            wrap.text('No statistics available.');
        }

        wrap.appendTo(panel);
    },

    setDirtyAndCheckBounds: function() {
        this.editorWgt.setDirty(true);
        this.checkBounds();
        this.scaleWidgetFrame();
    },

    openActionLightbox: function() {
        var url, data = this.data;

        if (!data.action) {
            this.remove();
            throw new Error('Button without action name');
        }

        url = this.editorWgt.widgetFormURL;
        url += '?' + $.param({
            proprietary: data.proprietary ? 'true' : '',
            id         : data.id,
            type_id    : data.type_id
        });

        this.editorWgt.focusWidget(this.element);

        // Image widget does not have an action,
        // but we need to fetch a widget id.
        if ('image' === data.action.name) {
            $.get(url, this.handleImageWidgetForm.bind(this));
        }

        // Open lightbox to edit action
        else {
            lyr.lightbox.open({
                url      : url,
                offsetObj: this.element,
                offsetY  : -400,
                offsetX  : 30,
                width    : 600
            });
            this.handleActionLightboxClose();
        }

        return false;
    },

    handleActionLightboxClose: function() {
        var event = lyr.event.LIGHTBOX_CLOSE_BY_USER + '.' + this.name;
        $(document).off(event).on(event, function() {
            if ($.isEmptyObject(this.data.meta)) {
                this.element.remove();
            }
        }.bind(this));
    },

    handleImageWidgetForm: function(html) {
        var meta = this.meta || {},
            id = lyr.tpl(html).find('[name=widget_id]').val();

        if (!id) {
            throw new Error('Could not retrieve image widget ID');
        } else {
            this.setID(parseInt(id, 10));
        }

        this.setMeta(meta);
    },

    remove: function() {
        var data = {id: this.data.id};
        this.element.fadeOut();

        if (this.data.id) {
            $.post(this.editorWgt.widgetDeleteURL, data)
                .success(this.removeSuccess.bind(this))
                .error(function() { this.element.show(); }.bind(this));
        } else {
            this.removeSuccess();
        }
    },

    removeSuccess: function(json) {
        if (json && json.error) {
            lyr.alert('Error', json.message);
            this.element.show();
        } else {
            this.editorWgt.setDirty(true);
            this.element.remove();
        }
    },

    addError: function(marking, add) {
        this.element.addClass('btg-widget-error-' + marking, add);
        this.editorWgt.focusWidget(this.element);
    },

    removeError: function(marking) {
        this.element.removeClass('btg-widget-error-' + marking);
    },

    checkBounds: function(removeonly) {
        if (this.validBounds()) {
            this.removeError('bounds');
        } else if (!removeonly) {
            this.addError('bounds');
        }
    },

    validAction: function() {
        return (this.data.action.name === 'image' || !$.isEmptyObject(this.data.meta));
    },

    validBounds: function() {
        var pos, width, height, page;

        pos = this.element.position();
        width = this.element.width();
        height = this.element.height();
        page = this.editorWgt.page;

        // Rounding up/down is for IE8
        if (pos.left < 0 || pos.top < 0) {
            return false;
        } else if (Math.floor(pos.left + width) > Math.ceil(page.width)) {
            return false;
        } else if (Math.floor(pos.top + height) > Math.ceil(page.height)) {
            return false;
        }

        return true;
    },

    getAllData: function() {
        return $.extend({}, this.data, this.getPositionData());
    },

    getPositionData: function() {
        var dimensions, coords, offset, zIndex,
            refWidth  = this.editorWgt.page.width,
            refHeight = this.editorWgt.page.height;

        dimensions = {
            width  : this.element.width(),
            height : this.element.height()
        };

        coords = {
            left  : this.element.position().left,
            top   : this.element.position().top
        };

        offset = this.editorWgt.coordsToOffset(dimensions, coords);

        zIndex = parseInt(this.element.css('zIndex'), 10) || 1;

        return $.extend({id: this.data.id}, {
            offset_x: offset.x,
            offset_y: offset.y,
            offset_z: zIndex / this.zMagnitude,
            width   : (dimensions.width / refWidth) * 100,
            height  : (dimensions.height / refHeight) * 100
        });
    }

});


/**
 * Handle Carousel button on page:
 * Add arrow buttons to navigate through frames.
 */
lyr.wgt.set('btg-widget-preview-carousel', {

    init: function() {
        this.wgt   = lyr.wgt.get(this.element, 'btg-widget');
        this.data  = this.wgt.data || {};
        this.meta  = this.data.meta || {};
        this.wrap  = this.wgt.content || $();
        this.frame = this.wrap.find('iframe');

        // Initialize when carousel can be rendered
        if (!this.meta.carousel || !this.frame.length || !this.frame.is(':visible')) {
            window.setTimeout(this.init.bind(this), 500);
            return;
        }

        this.panel    = this.wgt.actionPanel;
        this.maxIndex = this.getMaxIndex(JSON.parse(this.meta.carousel));

        if (-1 !== this.maxIndex) {
            this.panel.css({minWidth: 100});
            this.buttons = this.addButtons();
            this.frame[0].onload = function() {
                this.gotoFrame(this.meta.index || 0);
            }.bind(this);
        }
    },

    getMaxIndex: function(carousel) {
        var maxIndex = -1;
        for (var i = 0, m = carousel.length; i < m; i++) {
            if (carousel[i]) {
                maxIndex++;
            }
        }
        return maxIndex;
    },

    addButtons: function() {
        var last = this.panel.find('li:last'),
            prevButton = $('<li>').html('<a class="prev">&#9668;</a>'),
            nextButton = $('<li>').html('<a class="next">&#9658;</a>');

        prevButton.on('click', this.prev.bind(this)).insertBefore(last);
        nextButton.on('click', this.next.bind(this)).insertBefore(last);

        return {
            prev: prevButton,
            next: nextButton
        };
    },

    gotoFrame: function(index) {
        var targetOrigin = this.frame[0].src.split('/').slice(0, 3).join('/'),
            contentWindow = this.frame[0].contentWindow;

        if (contentWindow && contentWindow.postMessage) {
            this.meta.index = this.index = index;
            contentWindow.postMessage(index, targetOrigin);
            this.updateButtons();
        }
    },

    updateButtons: function() {
        this.buttons.prev.attr('disabled', this.meta.index === 0);
        this.buttons.next.attr('disabled', this.meta.index === this.maxIndex);
    },

    prev: function() {
        this.gotoFrame(Math.max(0, this.meta.index - 1));
    },

    next: function() {
        this.gotoFrame(Math.min(this.maxIndex, this.meta.index + 1));
    }

});


/**
 * Show AR badge on AR video preview
 */
lyr.wgt.set('btg-widget-preview-video', {

    init: function() {
        this.badge = $('<div class="btg-badge">AR</div>').appendTo(this.element);
        this.element.on(lyr.event.WIDGET_META_SET, this.updateDisplayBadge.bind(this));
        this.updateDisplayBadge();
    },

    updateDisplayBadge: function(e, meta) {
        meta = meta || lyr.wgt.get(this.element, 'btg-widget').data.meta;
        this.badge.toggle(!!(meta.name === 'video' && meta.ar));
    }

});


/**
 * Test a page
 * Opens a lightbox where the current page can be tested
 */
lyr.wgt.set('btg-test-page', {

    init: function() {
        this.bindEvents();
        this.updateButton();
    },

    bindEvents: function() {
        var events = [
            lyr.event.CREATOR_EDITOR_SAVED,
            lyr.event.PAGE_LOAD_COMPLETE,
            lyr.event.CREATOR_EDITOR_DIRTY
        ];
        this.element.on('click', this.openTestLightbox.bind(this));
        $(document).on(events.join(' '), this.updateButton.bind(this));
    },

    isDisabled: function() {
        var editorWgt, numWidgets;
        editorWgt = lyr.wgt.get('.btg-editor', 'btg-editor');
        numWidgets = $('.btg-widget:visible').length;

        return (
            numWidgets === 0 ||
            editorWgt.dirty ||
            !editorWgt.pageData.processed
        );
    },

    updateButton: function() {
        // Cannot use disabled attribute, disabled attr disables all
        // interaction with object, including tooltip on mouseover.
        this.element.toggleClass('disabled', this.isDisabled());
        this.toggleButtonTooltip();
    },

    toggleButtonTooltip: function() {
        var editorWgt = lyr.wgt.get('.btg-editor', 'btg-editor'),
            processed = editorWgt.pageData.processed;
        if (processed === false) {
            this.element.tooltip('enable');
        } else {
            this.element.tooltip('disable');
        }
    },

    openTestLightbox: function() {
        if (this.isDisabled()) { return; }

        var html = lyr.tpl(this.element.data('html'));
        html.find('img:last').attr('src', $('.btg-page').attr('src'));
        lyr.lightbox.open({
            addClass: 'btg-test-page-lightbox',
            width   : 666,
            top     : 20,
            html    : html
        });
    }

});


/**
 * Widget for saving/applying/cancelling changes in editor
 */
lyr.wgt.set('btg-save-page', {

    init: function() {
        this.initialized = false;
        this.saveButton  = this.element.find('.btg-save-button').assert();
        this.saveURL     = this.element.data('save-url');
        this.published   = this.element.data('publication-status') === 1;
        this.adSupported = this.element.data('ad-supported');
        this.purchased   = this.element.data('purchased');
        this.layerName   = this.element.data('layer-name');

        this.skipPubMsgKey = 'btg_skip_pub_' + this.layerName;
        this.skipProMsgKey = 'btg_skip_pro_' + this.layerName;

        this.saveButton.attr('disabled', true);

        $(document).on(lyr.event.PAGE_LOAD_COMPLETE, this.onEditorInitDone.bind(this));
    },

    onEditorInitDone: function(e, widget) {
        if (!this.initialized) {
            this.bindEvents();
            this.initialized = true;
            this.editorWgt = widget;
        }
    },

    bindEvents: function() {
        var events = [
            lyr.event.CREATOR_EDITOR_DIRTY,
            lyr.event.PAGE_LOAD_COMPLETE
        ].join(' ');
        this.saveButton.on('click', this.saveIntentProxy.bind(this));
        $(document).on(events, this.updateButton.bind(this));
    },

    updateButton: function() {
        this.saveButton.attr('disabled', !this.editorWgt.dirty);
    },

    getEditorWidget: function() {
        return lyr.wgt.get('.btg-editor', 'btg-editor');
    },

    confirmPub: function() {
        if ($('[name=skip_pub_msg]').is(':checked')) {
            lyr.storage(this.skipPubMsgKey, true);
        }
        this.save();
    },

    confirmPro: function() {
        if ($('[name=skip_pro_msg]').is(':checked')) {
            lyr.storage(this.skipProMsgKey, true);
        }
        this.save();
    },

    saveIntentProxy: function() {
        this.saveIntent();
    },

    saveIntent: function(callback) {
        var purchased = this.editorWgt.pageData.purchased;

        if (!this.getSaveData({reportErrors: true})) {
            return false;
        }

        if (this.published) {
            if (!lyr.storage(this.skipPubMsgKey) && (this.adSupported || purchased)) {
                this.showPublishConfirmation();
                return false;
            }
            if (!lyr.storage(this.skipProMsgKey) && !this.adSupported && !purchased) {
                this.showPublishProMessage();
                return false;
            }
        }

        this.save(callback);
    },

    showPublishConfirmation: function() {
        lyr.confirm('Campaign is published', [
            'This campaign is published. The changes that you made will be',
            'visible immediately. Do you wish to continue?<p><label><input',
            'type="checkbox" name="skip_pub_msg"> Don’t ask me again for this',
            'campaign</label></p>'].join(' '),
            { ok: this.confirmPub.bind(this) }
        );
    },

    showPublishProMessage: function() {
        lyr.alert('Campaign is Published', [
            'Once you complete your edits, please go to the Campaign Overview',
            'section to purchase unpublished pages.<p><label><input',
            'type="checkbox" name="skip_pro_msg"> Don’t show me again for this',
            'campaign</label></p>'].join(' '),
            { ok: this.confirmPro.bind(this) }
        );
    },

    getSaveData: function(options) {
        var sprintf, pluralize, widgets,
            saveData = [], invalidActions = [], invalidBounds = [];

        sprintf = lyr.format.sprintf;
        pluralize = lyr.format.pluralize;

        widgets = this.getEditorWidget().getWidgets();

        for (var i = 0, m = widgets.length; i < m; i++) {
            var widget = $(widgets[i]),
                wgt = lyr.wgt.get(widget, 'btg-widget');

            saveData.push(wgt.getPositionData());

            if (!wgt.validAction()) {
                invalidActions.push(widget);
            } else if (!wgt.validBounds()) {
                invalidBounds.push(widget);
            }
        }

        if (invalidActions.length && options.reportErrors) {
            this.markWidgets(invalidActions, 'action');
            lyr.alert(
                sprintf('{1} button{2} without an action', invalidActions.length, pluralize(invalidActions.length)), [
                    'All buttons need to have a valid action. Please add an',
                    'action to the buttons outlined in red<br><br>Once',
                    'complete, save the page.'].join(' ')
            );
            return false;
        } else if (invalidBounds.length && options.reportErrors) {
            this.markWidgets(invalidBounds, 'bounds');
            lyr.alert(
                sprintf('Button{1} outside page', pluralize(invalidBounds.length)), [
                'All buttons must be within the page boundary. Please move or',
                'resize the buttons outlined in red so that they are within',
                'the bounds of the page.<br><br>Once complete, save the page.'].join(' ')
            );
            return false;
        } else {
            return saveData;
        }
    },

    markWidgets: function(widgets, marking) {
        for (var i = 0, m = widgets.length; i < m; i++) {
            $(widgets[i]).trigger(lyr.event.CREATOR_BUTTON_ERROR, [marking]);
        }
    },

    save: function(callback) {
        var data, saveData, editorWgt, widgets;

        editorWgt = this.editorWgt;
        editorWgt.blurWidgets();

        widgets = editorWgt.getWidgets();
        saveData = this.getSaveData();

        data = {
            page      : editorWgt.page.key,
            widgetdata: JSON.stringify(saveData)
        };

        lyr.toggleLoading(this.element, true);

        return $.post(this.saveURL, data)
            .always(this.stopLoading.bind(this))
            .success(function(json) {
                if (!json.error) {
                    $(document).trigger(lyr.event.CREATOR_EDITOR_SAVED, [widgets, json]);
                    if (callback) { callback(); }
                } else {
                    lyr.alert('Error', json.message);
                }
            }.bind(this));
    },

    // lyr.toggleLoading() affects disabled state of buttons.
    // Make sure to reset disabled state after toggleLoading().
    stopLoading: function() {
        lyr.toggleLoading(this.element, false);
        $(document).trigger(lyr.event.CREATOR_EDITOR_DIRTY, this.editorWgt.dirty);
    }

});


/**
 * Close processing explanation lightbox.
 */
lyr.wgt.set('close-processing-lightbox', {

    init: function() {
        this.element.on('click', function() {
            $(document).trigger(lyr.event.CREATOR_PROCESSING_CONFIRM);
        });
    }

});


/**
 * MaxHeight
 * Dynamically set max-height on an HTML element,
 * based on the browser’s viewport height.
 */
lyr.wgt.set('btg-maxheight', {

    init: function() {
        this.subtract = this.element.data('subtract') || 0;
        this.maxHeight = this.element.data('maxheight') || 685;
        $(window).on(lyr.event.WINDOW_RESIZE, this.setSize.bind(this));
        this.setSize();
    },

    setSize: function() {
        var dynamicHeight = $(window).height() - this.subtract;
        this.element.css({
            maxHeight: Math.min(dynamicHeight, this.maxHeight)
        });
    }

});


/**
 * Collapse/Expand a section
 */
lyr.wgt.set('btg-collapse-expand', {

    init: function() {
        this.target      = $(this.element.data('target')).assert();
        this.targetInner = this.target.children().first().assert();
        this.height      = this.targetInner.height();

        this.element.on('click', this.clickEvent.bind(this));
    },

    clickEvent: function() {
        var toHeight = (this.element.hasClass('active')) ? 0 : this.height;
        // Match speed with .wrap-viewport-help:before transition
        this.target.animate({height: toHeight}, 200);
        this.element.toggleClass('active');
        return false;
    }

});


/**
 * Remove prefix, legacy fix.
 */
lyr.wgt.set('btg-remove-prefix', {

    init: function() {
        var value = this.element.attr('value') || '',
            prefix = this.element.data('prefix');
        if (value.indexOf(prefix) === 0) {
            this.element.val(value.substr(prefix.length));
        }
    }

});

//@ sourceURL=page-editor.wgt.js