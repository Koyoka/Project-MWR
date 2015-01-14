/*jshint globalstrict:true, jquery:true */
/*global lyr */
'use strict';


lyr.wgt.set('btg-manage-pages', {

    init: function() {
        this.layer        = this.element.data('layer');
        this.saveURL      = this.element.data('save-url');
        this.deleteURL    = this.element.data('delete-url');
        this.metaLightbox = this.element.data('meta-lightbox');
        this.list         = this.element.find('.btg-figure-grid').assert();
        this.order        = this.getOrder();

        this.bindEvents();
        this.updateElements();
        this.updateRejectedCount();
        this.makeSortable();
    },

    getItems: function() {
        return this.list.children('li');
    },

    bindEvents: function() {
        var ev = lyr.event.PAGE_DELETED + '.' + this.name;

        this.element.on('click', '.delete', this.deletePageConfirm.bind(this));
        this.element.on('click', '.edit, .wrap', this.openMetaLightbox.bind(this));
        this.element.on('click', 'li:not(.help-fill-space)', this.openMetaLightbox.bind(this));

        $(document).off(ev).on(ev, this.pageDeleteListener.bind(this));
    },

    openMetaLightbox: function(e) {
        var metaLightbox = new lyr.Lightbox(), html, li, data;

        html = lyr.tpl(this.metaLightbox);
        li   = $(e.currentTarget).closest('li');
        data = li.data();

        html.data('page', li);
        html.find('h1').text('Edit ' + data.title);
        html.find('[name=key]').val(data.key);
        html.find('[name=title]').val(data.title);
        html.find('[name=type] option[value="' + data.type + '"]').prop('selected', true);
        html.find('img.btg-page-image-preview').attr('src', data.image);

        metaLightbox.open({
            html      : html,
            offsetObj : li,
            width     : 750,
            height    : 600
        });

        return false;
    },

    getOrder: function() {
        var order = [], items = this.getItems();
        for (var i = 0, m = items.length; i < m; i++) {
            order.push( $(items[i]).data('key') );
        }
        return order;
    },

    makeSortable: function() {
        var numitems = this.getItems().length;

        if (numitems > 1) {

            this.list.addClass('btg-sortable');

            // Start/stop callback: fix Firefox scrolling bug
            this.list.sortable({
                forcePlaceholderSize : true,
                placeholder : 'plh',
                tolerance   : 'pointer',
                containment : 'parent',
                zIndex      : 1000,
                revert      : 200,
                scroll      : false,
                start       : function(){ $(this).data('scrolltop', $('html').scrollTop()); },
                stop        : function(){ $('html').scrollTop($(this).data('scrolltop')); },
                update      : this.checkOrder.bind(this)
            });
        } else {
            this.list.prevAll('.help').remove();
        }
    },

    checkOrder: function() {
        var order = this.getOrder();

        if (this.order[0] !== order.join('.')) {
            this.saveOrder(order);
            $(document).trigger(lyr.event.PAGE_REORDER, [order]);
        }
    },

    saveOrder: function(order) {
        if (this.xhr) {
            this.xhr.abort();
        }
        this.xhr = $.post(this.saveURL, {order: order}, function() {
            this.order = order;
        }.bind(this));
    },

    deletePageConfirm: function(e) {
        var obj = $(e.currentTarget);
        lyr.confirm('Delete page', 'Are you sure you want to delete this page?', {
                ok       : function() {
                    this.deletePageRequest(obj.closest('li'));
                }.bind(this),
                offsetObj: e.currentTarget
            });
        return false;
    },

    deletePageRequest: function(obj) {
        var data, key = obj.data('key');

        data = {key: key, layer: this.layer};
        obj.fadeOut();

        $.post(this.deleteURL, data).success(function(json) {
            if (json.error) {
                obj.show();
            } else {
                // Calls pageDeleteListener with a detour
                $(document).trigger(lyr.event.PAGE_DELETED, [key]);
            }
        }.bind(this));
    },

    pageDeleteListener: function(e, key) {
        this.getItems().filter('[data-key="' + key + '"]').remove();
        this.updateElements();
        this.updateRejectedCount();
    },

    updateElements: function() {
        this.element.find('.empty-no-pages').toggle(!this.getItems().length);
    },

    updateRejectedCount: function() {
        var buttons, rejected = this.getItems().filter('.rejected');
        buttons = this.element.find('.buttons-remove-rejected');
        buttons.toggle(!!rejected.length);
        buttons.find('.count').text(rejected.length);
        buttons.find('.plural').toggle(rejected.length !== 1);
    }

});


/**
 * Upload Widget
 * Upload image within a form, receive image dimensions and url
 */
lyr.wgt.set('btg-upload-page', {

    init: function() {
        this.buttons     = this.element.find('.buttons').assert();
        this.switchForm  = this.element.find('.btg-switch a');
        this.vitrage     = $('<div>').addClass('vitrage');

        this.setInitialCancelMessage();
        this.bindEvents();
        this.makeAjaxForm();
        
       
    },

    bindEvents: function() {
        this.switchForm.on('click', function(e) {
            var target = $(e.currentTarget).attr('href');

            // Reset validation
            this.element.data('validator').resetForm();
            this.element.find('.error').removeClass('error');

            this.element.hide();
            $(target).fadeIn();
            return false;
        }.bind(this));
    },

    makeAjaxForm: function() {
    
        this.ajaxForm = $(this.element).ajaxForm({
            dataType     : 'json',
            iframe       : true,
            beforeSerialize : function() {
                this.element.trigger(lyr.event.UPLOAD_PAGE_SERIALIZE, [this]);
                this.isBusy(true);
            }.bind(this),
            success      : this.onSuccess.bind(this),
            error        : this.onError.bind(this),
            beforeSend   : function(jqXHR) { this.xhr = jqXHR; }.bind(this)
        });
    },

    isBusy: function(busy) {
        lyr.toggleLoading(this.buttons, busy);
        this.toggleWindowFreeze(busy);
    },

    toggleWindowFreeze: function(freeze) {
        if (freeze) {
            this.vitrage.appendTo('body').on('click', this.confirmCancel.bind(this));
        } else {
            this.vitrage.remove();
            this.buttons.find('.help').remove();
        }
    },

    setInitialCancelMessage: function() {
        this.busyTitle   = 'Uploading';
        this.busyMessage = 'Are you sure you want to abort the upload process?';
    },

    confirmCancel: function(e) {
        lyr.confirm(this.busyTitle, this.busyMessage, {
            ok   : this.onCancel.bind(this),
            left : e.clientX - 100,
            top  : e.clientY - 100
        });
    },

    onCancel: function() {
        this.element.trigger(lyr.event.UPLOAD_PAGE_CANCELED, [this]);
        if (this.xhr) {
            this.xhr.abort();
        }
        this.setInitialCancelMessage();
        this.toggleWindowFreeze(false);
        this.isBusy(false);
    },

    onSuccess: function(json) {
//        window.alert(123)
        this.element.trigger(lyr.event.UPLOAD_PAGE_UPLOADED, [json, this]);
    },

    onError: function(e, xhr) {
//   window.alert(456)
        this.isBusy(false);
        $.ajaxSettings.error(e, xhr);
    }

});


/**
 * Upload Zip or PDF
 * Uploading, extracting polling
 */
lyr.wgt.set('btg-upload-multiple-pages', {

    init: function() {
        this.uploadWidget   = {};
        this.checkStatusURL = '';
        this.pollInterval   = 5000;
        this.buttons        = this.element.find('.buttons');

        this.element.on(lyr.event.UPLOAD_PAGE_UPLOADED, this.onSuccess.bind(this));
        this.element.on(lyr.event.UPLOAD_PAGE_CANCELED, this.onCancel.bind(this));
         
    },

    /**
     * Success call
     */
    onSuccess: function(e, json, widget) {
        this.uploadWidget = widget;
        this.checkStatusURL = json.url;
//        window.alert('btg-upload-multiple-pages');
        if (json.error) {
            lyr.alert('Error', json.message);
            widget.isBusy(false);
        } else {
            widget.busyTitle = 'Processing';
            this.updateMessage('Uploading complete; extracting images.. ');
            this.checkAgainLater();
        }
    },

    // Make sure pollling stops when user canceled process
    onCancel: function() {
        this.updateMessage('');
        try {
            window.clearTimeout(this.timer);
            this.xhr.abort();
        } catch(e) {}
    },

    checkProcessed: function() {
        this.xhr = $.get(this.checkStatusURL, this.checkProcessedResult.bind(this));
    },

    checkProcessedResult: function(json) {
        if (json.done) {
            this.handleResult(json);
        } else if (json.error) {
            lyr.alert('Error', json.message);
            this.uploadWidget.onCancel();
        } else {
            if (json.progress) {
                this.updateProgress(json.progress);
            }
            this.checkAgainLater();
        }
    },

    updateMessage: function(message) {
        if (!this.messageObj) {
            this.messageObj = $('<span>').addClass('btg-extraction-status');
            this.messageObj.prependTo(this.buttons);
        }
        this.messageObj.html(message);
    },

    updateProgress: function(progress) {
        this.updateMessage(
            'Extracting images.. ' +
            '<strong class="btg-extract-progress">' + Math.floor(progress) + '%</strong>'
        );
    },

    handleResult: function(json) {
        this.uploadWidget.isBusy(false);
        if (json.error) {
            lyr.alert('Error', json.message);
        } else {
            lyr.lightbox.get(this.element).content(json.html);
        }
    },

    checkAgainLater: function() {
        this.timer = window.setTimeout(function() {
            this.checkProcessed();
        }.bind(this), this.pollInterval);
    }

});


/**
 * Uploading a single page
 */
lyr.wgt.set('btg-upload-single-page', {

    init: function() {
        this.element.on(lyr.event.UPLOAD_PAGE_UPLOADED, this.onSuccess.bind(this));
    },

    onSuccess: function(e, json, widget) {
        var page, image;
        widget.isBusy(false);
//        window.alert(222)
//        window.alert('btg-upload-single-page'+ " 1 " + json.error);
        if (json.error) {
            lyr.alert('Error', json.message);
        } else {
            page = json.page;//{};//json.page;
//            page.key = "keyasdfasdfadsfadf";
//            page.title = "title";
//            page.thumbnail = "btg-instruct-start.6607b99586a5.png";//page.reference_image.thumbnails.thumbnail_small;
//            page.processed = false;
//        window.alert(page.key)

            lyr.lightbox.closeAll();

            $(document).trigger(lyr.event.PAGE_UPLOAD_WIZARD_COMPLETE,page);
        }
    }

});


/**
 * Unified file upload
 * Uploading either image or zip/pdf
 * Determines what wgt to use based on file extension before form submit
 */
lyr.wgt.set('unified-file-upload', {
    init: function() {
        this.isSinglePageUpload = true;
        this.fileInput = this.element.find('.valid_image_or_pdfzip');

        this.fileInput.on('change', this.setAction.bind(this));
        this.element.on(lyr.event.UPLOAD_PAGE_SERIALIZE,this.attachWgt.bind(this));
    },

    /**
     * on file pick - detect file extension and set the respective form action
     */
    setAction: function() {
        var fileName  = this.fileInput.val();
//        window.alert(1);

        if (/\.(jpe|jpg|jpeg|png)$/i.test(fileName)) {
            if (this.element.attr('action') !== this.element.data('action-single-page')) {
                this.element.attr('action', this.element.data('action-single-page'));
                this.isSinglePageUpload = true;
            }

        } else if (/\.(pdf|zip)$/i.test(fileName)) {
            if (this.element.attr('action') !== this.element.data('action-multiple-pages')) {
                this.element.attr('action', this.element.data('action-multiple-pages'));
                this.isSinglePageUpload = false;
            }
        } 
//        else if (/\.(mp4)$/i.test(fileName)){
//            window.alert(1);
//            
//        }
    },

    /**
     * before serialize of the form, attach the respective wgt
     */
    attachWgt: function() {
        if (this.isSinglePageUpload) {
            lyr.wgt.append(this.element, 'btg-upload-single-page');
        } else {
            lyr.wgt.append(this.element, 'btg-upload-multiple-pages');
        }
    }
});


lyr.wgt.set('btg-edit-page-meta', {

    init: function() {
        this.buttons = this.element.find('.buttons').assert();
        this.page = this.element.data('page');
        this.makeAjaxForm();
    },

    makeAjaxForm: function() {
        $(this.element).ajaxForm({
            dataType     : 'json',
            beforeSubmit : function() { this.isBusy(true); }.bind(this),
            success      : this.onSuccess.bind(this),
            error        : this.onError.bind(this)
        });
    },

    isBusy: function(busy) {
        lyr.toggleLoading(this.buttons, busy);
    },

    onSuccess: function(json) {
        if (!json.error) {
            var form  = this.element,
                key   = form.find('[name=key]').val(),
                title = form.find('[name=title]').val(),
                type  = form.find('[name=type]').val();

            $('.btg-title-' + key).text(title);
            $(document).trigger(lyr.event.PAGE_RENAME, [key, title]);

            // Update data in case user reopens page meta
            this.page.data('title', title);
            this.page.data('type', type);

            lyr.lightbox.closeAll();
        } else {
            lyr.lightbox.open({html: json.message});
        }
    },

    onError: function(e, xhr) {
        lyr.toggleLoading(this.buttons, false);
        $.ajaxSettings.error(e, xhr);
    }

});


lyr.wgt.set('btg-load-pages-from-campaign', {

    init: function() {
        this.getPagesURL = this.element.data('get-pages-url');
        this.content     = this.element.find('.btg-campaign-pages').assert();
        this.selectBox   = this.element.find('select').assert();
        this.loading     = this.element.find('.loading').assert();
        this.selCampaign = '';
        this.busy        = false;
        this.bindEvents();
    },

    bindEvents: function() {
        this.selectBox.on('change', this.selectChanged.bind(this));
    },

    selectChanged: function(e) {
        var obj = $(e.currentTarget).blur(),
            campaign = obj.find(':selected').val();
        if (campaign && campaign !== this.selCampaign) {
            this.selCampaign = campaign;

            if (this.xhr) {
                this.xhr.abort();
            }

            this.xhr = this.loadPagesFromCampaign(campaign);
            this.isBusy(true);
        }
    },

    loadPagesFromCampaign: function(campaign) {
        var url = this.getPagesURL.replace('__campaign__', campaign);
        return $.get(url, function(html) {
            this.setPages(html);
            this.isBusy(false);
        }.bind(this));
    },

    isBusy: function(busy) {
        var fade = (busy) ? $.fn.fadeIn : $.fn.fadeOut;
        fade.call(this.loading, 200);
        this.busy = busy;
    },

    setPages: function(html) {
        this.content.hide().html(html).fadeIn();
        lyr.wgt.scan(this.content);
    }

});


lyr.wgt.set('btg-selectable-pages', {

    init: function() {
        this.buttons        = this.element.find('.buttons').assert();
        this.submitButton   = this.buttons.find('button').assert();
        this.counter        = this.submitButton.find('.count').assert();
        this.plural         = this.submitButton.find('.plural').assert();
        this.selectAllInput = this.addSelectAll();

        this.bindEvents();
        this.updateCount();
    },

    addSelectAll: function() {
        var label, checkbox;
        checkbox = $('<input type="checkbox">');
        label = $('<label>').addClass('help btg-select-all');
        label.append(checkbox, ' Select all pages');
        label.prependTo(this.buttons);
        return checkbox;
    },

    bindEvents: function() {
        this.element.on('click', 'li:not(.untrackable)', this.selectPage.bind(this));
        this.selectAllInput.on('change', this.toggleSelectAll.bind(this));
        this.submitButton.on('click', this.submit.bind(this));
    },

    toggleSelectAll: function() {
        var checked, elements, func;
        checked = this.selectAllInput.is(':checked');
        elements = this.element.find('li:not(.untrackable)');
        func = (checked) ? $.fn.addClass : $.fn.removeClass;
        func.call(elements, 'selected');
        this.updateCount();
    },

    selectPage: function(e) {
        $(e.currentTarget).toggleClass('selected');
        this.updateCount();
        this.updateSelectAllInput();
    },

    updateCount: function() {
        var count = this.element.find('.selected').length;
        this.submitButton.attr('disabled', !count);
        this.counter.text(count);
        this.plural.toggle(count !== 1);
    },

    updateSelectAllInput: function() {
        var selectable = this.element.find('li:not(.untrackable)').length,
            selected = this.element.find('.selected').length;
        this.selectAllInput.prop('checked', (selectable === selected));
    },

    submit: function() {
        var pages = this.element.find('.selected');
        this.element.trigger(lyr.event.CREATOR_PAGES_SELECT_SUBMIT, [this, pages]);
        lyr.toggleLoading(this.buttons, true);
    },

    appendSelection: function(selection) {
        lyr.lightbox.closeAll();
        $(document).trigger(lyr.event.CREATOR_PAGES_SELECT, [selection]);
    }

});


lyr.wgt.set('btg-pick-pages-from-bulk-upload', {

    init: function() {
        this.endpoint   = this.element.data('submit-url');
        this.ticket      = this.element.data('ticket');
        this.targetLayer = $('.btg-editor').assert().data('layer');
        this.bindEvents();
    },

    bindEvents: function() {
        this.element.on(lyr.event.CREATOR_PAGES_SELECT_SUBMIT, this.addPages.bind(this));
    },

    addPages: function(e, widget, pages) {
        var data, post, selection = [], ids = [];

        for (var i = 0, m = pages.length; i < m; i++) {
            data = $(pages[i]).data();
            ids.push(data.id);
            selection.push(data);
        }

        post = {
            ticket      : this.ticket,
            target_layer: this.targetLayer,
            ids         : ids
        };

        $.post(this.endpoint, post, function(json) {

            if (json.error) {
                lyr.alert('Error', json.message);
                lyr.toggleLoading(widget.buttons, false);
                return;
            }

            for (var i = 0, m = selection.length; i < m; i++) {
                selection[i].key = json.keys[i]; // Merge new keys
            }

            widget.appendSelection(selection);

            $(document).trigger(lyr.event.PAGE_UPLOAD_WIZARD_COMPLETE);
        });
    }

});

lyr.wgt.set('btg-pick-pages-from-campaign', {

    init: function() {
        this.buttons     = this.element.find('.buttons').assert();
        this.endpoint    = this.element.data('submit-url');
        this.sourceLayer = this.element.data('source-layer');
        this.targetLayer = $('.btg-editor').data('layer');
        this.bindEvents();
    },

    bindEvents: function() {
        this.element.on(lyr.event.CREATOR_PAGES_SELECT_SUBMIT, this.addPages.bind(this));
    },

    addPages: function(e, widget, pages) {
        var data, post, selection = [], keys = [];

        for (var i = 0, m = pages.length; i < m; i++) {
            data = $(pages[i]).data();
            keys.push(data.key);
            selection.push(data);
        }

        post = {
            source_layer: this.sourceLayer,
            target_layer: this.targetLayer,
            keys        : keys
        };

        $.post(this.endpoint, post, function(json) {
        
            if (json.error) {
                lyr.alert('Error', json.message);
                lyr.toggleLoading(widget.buttons, false);
                return;
            }
            for (var i = 0, m = json.keys.length; i < m; i++) {
                selection[i].key = json.keys[i]; // Merge new keys
            }
            widget.appendSelection(selection);
        }.bind(this));
    }

});


lyr.wgt.set("eleven_wgt", {
    
    init : function() {
        window.alert(1)
    }
});


lyr.wgt.set('btg-upload-edit-page', {

    init: function() {
        this.buttons     = this.element.find('.buttons').assert();
        this.switchForm  = this.element.find('.btg-switch a');
        this.vitrage     = $('<div>').addClass('vitrage');

        this.setInitialCancelMessage();
        this.bindEvents();
        this.makeAjaxForm();
        
       
    },

    bindEvents: function() {
        this.switchForm.on('click', function(e) {
            var target = $(e.currentTarget).attr('href');

            // Reset validation
            this.element.data('validator').resetForm();
            this.element.find('.error').removeClass('error');

            this.element.hide();
            $(target).fadeIn();
            return false;
        }.bind(this));
    },

    makeAjaxForm: function() {
    
        this.ajaxForm = $(this.element).ajaxForm({
            dataType     : 'json',
            iframe       : true,
            beforeSerialize : function() {
                this.element.trigger(lyr.event.UPLOAD_PAGE_SERIALIZE, [this]);
                this.isBusy(true);
            }.bind(this),
            success      : this.onSuccess.bind(this),
            error        : this.onError.bind(this),
            beforeSend   : function(jqXHR) { this.xhr = jqXHR; }.bind(this)
        });
    },

    isBusy: function(busy) {
        lyr.toggleLoading(this.buttons, busy);
        this.toggleWindowFreeze(busy);
    },

    toggleWindowFreeze: function(freeze) {
        if (freeze) {
            this.vitrage.appendTo('body').on('click', this.confirmCancel.bind(this));
        } else {
            this.vitrage.remove();
            this.buttons.find('.help').remove();
        }
    },

    setInitialCancelMessage: function() {
        this.busyTitle   = '上传';
        this.busyMessage = '确定取消提交么?';
    },

    confirmCancel: function(e) {
        lyr.confirm(this.busyTitle, this.busyMessage, {
            ok   : this.onCancel.bind(this),
            left : e.clientX - 100,
            top  : e.clientY - 100
        });
    },

    onCancel: function() {
        this.element.trigger(lyr.event.UPLOAD_PAGE_CANCELED, [this]);
        if (this.xhr) {
            this.xhr.abort();
        }
        this.setInitialCancelMessage();
        this.toggleWindowFreeze(false);
        this.isBusy(false);
    },

    onSuccess: function(json) {
//        window.alert(json.status)
        this.isBusy(false);
        lyr.lightbox.closeAll();
        if(json.error){
//            window.alert(json.message);
            lyr.alert("失败",message);
        }else{
//            window.alert(json.message);
            lyr.alert("成功","数据已更新.");
            
        }
        
        
        
        
         
//        this.element.trigger(lyr.event.UPLOAD_PAGE_UPLOADED, [json, this]);
    },

    onError: function(e, xhr) {
//   window.alert(456)
        this.isBusy(false);
        $.ajaxSettings.error(e, xhr);
    }

});

//@ sourceURL=manage-pages.wgt.js