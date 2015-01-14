/*jshint globalstrict:true, jquery:true */
/*global lyr */
'use strict';

/**
 * New campaign form
 */
lyr.wgt.set('btg-new-campaign', {

    init: function() {
        this.element.on(lyr.event.FORM_SUCCESS, this.success.bind(this));
    },

    /** @namespace json.redirect */
    success: function(e, json) {
        
        lyr.toggleLoading(this.element, true);
        if(json.error){
            lyr.alert("Ê§°Ü",json.message);
        }else{
//            location.href = json.redirect;
            location.reload() 
        }
        
        
    }

});

/*
    lyr.wgt.set('btg-new-campaign', {

    init: function() {
        this.field = {
            title: this.element.find('[name=title]').assert(),
            id   : this.element.find('[name=campaign_title]').assert()
        };
        this.populateEvent = 'change.' + this.name;
        this.stopEvent = lyr.format.sprintf('keypress.{1} paste{1}', this.name);
        this.bindEvents();
    },

    bindEvents: function() {
        this.field.title.on(this.populateEvent, this.autoPopulateCampaignID.bind(this));
        this.field.id.on(this.stopEvent, this.unbindAutoPopulateEvent.bind(this));
        this.element.on(lyr.event.FORM_SUCCESS, this.submitSuccess.bind(this));
    },

    autoPopulateCampaignID: function() {
        var title = this.field.title.val();
        title = title.substring(0, this.field.id.attr('maxlength'));
        this.field.id.val($.trim(title));
    },

    unbindAutoPopulateEvent: function(e) {
        if (e.which || e.type === 'paste') { // Visible character or paste
            this.field.title.off(this.populateEvent);
            this.field.id.off(this.stopEvent);
        }
    },

    submitSuccess: function(e, json) {
        lyr.toggleLoading(this.element, true);
        location.href = json.redirect;
    }

});
*/


/**
 * Layer properties form
 */
lyr.wgt.set('btg-campaign-properties', {

    init: function() {
        this.underlyingItem = $('#' + this.element.data('layer')).assert();
        this.underlyingTitle = this.underlyingItem.find('.btg-campaign-title').assert();
        this.formTitleInput = this.element.find('[name=campaign_title]').assert();
        this.element.on(lyr.event.FORM_SUBMIT, this.rememberTitle.bind(this));
        this.element.on(lyr.event.FORM_SUCCESS, this.success.bind(this));
    },

    rememberTitle: function() {
        this.campaignTitle = this.formTitleInput.val();
    },

    success: function() {
        this.underlyingTitle.text(this.campaignTitle);
        lyr.lightbox.closeAll();
    }

});


/**
 * Overview of campaigns
 * Change status, delete, edit properties in lightbox
 */
lyr.wgt.set('btg-campaign-overview', {

    init: function() {
        this.setStatusURL = this.element.data('set-status-url');
        this.deleteURL    = this.element.data('delete-url');
        this.bindEvents();
    },

    bindEvents: function() {
        var selectors = '.btg-overview-changestatus button, .delete a, .btg-shared-campaign-actions button';
        this.element.on('click', selectors, this.onButtonClick.bind(this));
        $(document).on(lyr.event.LIGHTBOX_AJAX_ERROR, function(e, data) {
            if (data.type === 'flagged_paypal') {
                this.flagged(data);
            }
        }.bind(this));
    },

    onButtonClick: function(e) {
        var data,
            element    = $(e.currentTarget),
            buttonData = element.data(),
            parentLI   = element.closest('.btg-campaign, .btg-shared-campaign').assert(),
            layerData  = parentLI.data();

        data = $.extend({element: element, parent: parentLI}, buttonData, layerData);

        switch (data.action) {
            case 'publish':   this.checkHasRejectedPages(data); break;
            case 'republish': this.confirmRepublish(data); break;
            case 'archive':   this.confirmArchive(data); break;
            case 'delete':    this.confirmDeleteCampaign(data); break;

            // collaboration (placeholder (for possible) actions)
            case 'complete':  this.confirmCompleteCampaign(data); break;
            case 'edit':      this.confirmEditCampaign(data); break;
        }
    },

    checkHasRejectedPages: function(data) {
        if (data.numRejected !== 0) {
            this.confirmDeleteRejectedPages(data);
        } else {
            this.checkPublishAllowed(data);
        }
    },

    confirmDeleteRejectedPages: function(data) {
        var body;
        body = 'Your campaign contains {1} rejected page{2} that cannot be published at this moment. Do you want to continue publishing your campaign?';
        body = lyr.format.sprintf(body, data.numRejected, lyr.format.pluralize(data.numRejected));

        lyr.confirm('Campaign has rejected pages', body, {
            ok: function() { this.checkPublishAllowed(data); }.bind(this)
        });
    },

    checkPublishAllowed: function(data) {
        lyr.lightbox.open({
            html           : '<div class="lyr-lb-loading"></div>',
            animateOnResize: false,
            width          : 'auto'
        });
        $.get(data.checkUrl, function(json) {
            this.checkPublishAllowedResult(json, data);
        }.bind(this));
    },

    checkPublishAllowedResult: function(json, data) {
        if (json.valid) {
            this.publishCampaign(data);
        } else {
            lyr.lightbox.closeLast();
            lyr.alert('Error', json.message || 'Something went wrong!');
        }
    },

    publishCampaign: function(data) {
        $.get(data.publishUrl, lyr.lightbox._ajaxSuccess.bind(lyr.lightbox));
    },

    confirmRepublish: function(data) {
        lyr.confirm('Republish campaign', 'Are you sure you want to republish this campaign? Your campaign will be publicly available again.', {
            ok: function() {
                this.changeStatus(data);
            }.bind(this)
        });
    },

    confirmArchive: function(data) {
        lyr.confirm('Archive campaign', 'Are you sure you want to archive this campaign? Your campaign will no longer be visible in the Layar mobile app.', {
            ok: function() {
                this.changeStatus(data);
            }.bind(this)
        });
    },

    confirmDeleteCampaign: function(data) {
        lyr.confirm('Delete campaign', 'Are you sure? This campaign, including all pages in this campaign, will be deleted permanently.', {
            ok: function() {
                this.deleteCampaign(data);
            }.bind(this)
        });
        return false;
    },

    confirmCompleteCampaign: function(data) {
        lyr.confirm('Complete campaign', 'Are you sure? This campaign will be marked as complete and the campaign owner will be notified.', {
            ok: function() {
                this.changeStatus(data);
            }.bind(this)
        });
        return false;
    },

    confirmEditCampaign: function(data) {
        lyr.confirm('Move to work in progress', 'Are you sure? This campaign will no longer be marked as complete', {
            ok: function() {
                this.changeStatus(data);
            }.bind(this)
        });
        return false;
    },

    changeStatus: function(data) {
        var post = {
            status: data.status,
            layer : data.layer
        };

        this.showLoadingMessage('Reloading overview¡­');
        $.post(this.setStatusURL, post, function(json) {
            this.onStatusSuccess(json, data);
        }.bind(this));
    },

    // Flagged, show OK/Cancel where OK submits a publish as free,
    // which result is then handled like a regular status change.
    flagged: function(json) {
        lyr.lightbox.closeAll();
        lyr.confirm('PayPal error', json.message, {
            ok: function() {
                this.showLoadingMessage('Reloading overview¡­');
                var data = json.post;
                $.post(json.publish_url, data, function(json) {
                    this.onStatusSuccess(json, data);
                }.bind(this));
            }.bind(this)
        });
    },

    deleteCampaign: function(data) {
        var post = {layer: data.layer};
        $.post(this.deleteURL, post, function(json) {
            this.deleteSuccess(json, data);
        }.bind(this));
    },

    deleteSuccess: function(json, data) {
        if (!json.error) {
            data.item = $('#' + data.layer).closest('.btg-campaign').assert();
            data.group = data.item.closest('.btg-campaign-list').assert();
            data.header = data.group.prev().assert();
            data.item.remove();
            this.updateCount(data);
        } else {
            lyr.alert('Error', json.message);
        }
    },

    updateCount: function(data) {
        var counter, newCount;

        counter  = data.header.find('var.count').assert();
        newCount = parseInt(counter.eq(0).text(), 10) - 1;

        if ($('.btg-campaign').length === 0) {
            window.location.reload(true); // No campaigns, reload entire page
        } else if (newCount > 0) {
            counter.text(newCount);
        } else {
            data.header.remove();
            data.group.remove();
        }
    },

    showLoadingMessage: function(message) {
        var messageObj = $('<p>').addClass('help-fill-space').text(message);
        lyr.lightbox.open({html: $('<div>').html(messageObj).html(), width: 360});
    },

    onStatusSuccess: function(json, data) {
        if (!json.error) {
            data.parent.removeAttr('id');
            location.assign('#' + data.layer);
            location.reload(true);
        } else {
            lyr.lightbox.closeAll();
            lyr.alert('Error', json.message);
        }
    }

});
//@ sourceURL=campaign-overview.wgt.js