/*jshint globalstrict: true */
/*global $, lyr, Mustache*/

'use strict';

lyr.pmt = {

    paypalSubmit: function(url, data) {
        var form = $('<form>').attr({action: url, method: 'POST'});
        for (var k in data) {
            if (data.hasOwnProperty(k)) {
                var attr = {name: k, value: data[k], type: 'hidden'};
                $('<input>').attr(attr).appendTo(form);
            }
        }

        // Close lightbox just before redirecting, fixes an issue in Safari
        // where the payment lightbox remains visible after navigating back.
        $(window).on('unload', lyr.lightbox.closeAll.bind(lyr.lightbox));

        form.appendTo('body').submit();
    },

    onFormSuccess: function(e, json) {
        if (!json.error) {
            // Go to Paypal
            if (json.paypal) {
                lyr.pmt.showLoadingMessage(this, 'Proceeding to checkout with PayPal…');
                lyr.pmt.paypalSubmit(json.paypal.url, json.paypal.data);
            }

            // Reload at location server updated layer
            else if (json.updated) {
                lyr.pmt.showLoadingMessage(this, 'Reloading overview…');
                location.reload(true);
            }
        }
    },

    showLoadingMessage: function(scope, message) {
        scope.element.find('button').text(message).attr('disabled', true);
    },

    buildPriceWithDecimalFormat: function(el, num) {
        var bits  = num.split('.'),
            whole = bits[0],
            dec   = bits[1];

        $(el).html('').append(whole);

        if (parseInt(dec, 10)) {
            $(el).append($("<span/>").addClass('dec').html('.' + dec));
        }
    }

};


/**
 * Payment Polling
 * Poll server to see if payment has been completed
 */
lyr.wgt.set('pmt-poll', {

    init: function() {
        this.returnToURL = this.element.data('return-to-url');
        this.checkStatusURL = this.element.data('status-url');

        this.tries = 0;
        this.triesMax = 20;
        this.interval = 2000;

        this.poll();
    },

    poll: function() {
        $.ajax({
            url    : this.checkStatusURL,
            success: this.onSuccess.bind(this),
            error  : this.onError.bind(this)
        });
    },

    retryLater: function() {
        window.setTimeout(this.poll.bind(this), this.interval);
        this.tries++;
    },

    onSuccess: function(json) {
        if (json.processed || this.tries >= this.triesMax) {
            this.alertRedirect();
        } else {
            this.retryLater();
        }
    },

    alertRedirect: function() {
        var redirect, term, message;

        $('.pleasewait').text('Redirecting…');

        redirect = function() {
            location.replace(this.returnToURL);
        }.bind(this);

        message = 'We’re sorry; processing your payment is taking longer ' +
            'than expected. You may work on other {1}s in the meantime. ' +
            'We will notify you when your payment has been processed.' +
            '<br><br>Click <strong>OK</strong> to continue.';

        term = this.returnToURL.match(/creator/g) ? 'campaign' : 'layer';

        lyr.alert('Processing payment', lyr.format.sprintf(message, term), {
            onclose: redirect
        });
    },

    onError: function() {
        this.retryLater();
    }

});


/**
 * Payment Polling
 * Poll server to see if payment has been completed
 * Extends pmt-poll widget
 */
lyr.wgt.set('pmt-poll-overview', {

    init: function() {
        var base = this.element.data('_widgets')['pmt-poll'];

        base.interval = 5000;

        base.onSuccess = function(json) {
            if (json.processed) {
                this.reloadOverview();
            } else {
                this.retryLater();
            }
        };

        base.reloadOverview = function() {
            if (location.hash.length > 1) {
                location.hash = '';
            }
            if (!lyr.lightbox.anyOpen()) {
                location.reload(true);
            } else {
                lyr.lightbox.onClose = function() {
                    location.reload(true);
                };
            }
        };
    }

});


/**
 * Payment Message
 * Show a message after a payment has completed
 */
lyr.wgt.set('pmt-message', {

    init: function() {
        var data;

        this.message = this.element.data('message');
        data         = {action_id: this.message.id};

        window.scrollTo(0,0);

        this.setRead = function() {
            $.post(this.element.data('read-url'), data);
        }.bind(this);

        $(window).load(function() {
            this.moveViewportToCampaign();
        }.bind(this));
    },

    moveViewportToCampaign: function() {
        var targetID, target;

        if (this.message.name) {
            targetID = '#' + this.message.name,
            target   = $(targetID);

            if (!target.isInViewport()) {
                $('html, body').animate({scrollTop: target.offset().top}, 500, this.delayedLightbox());
            } else {
                this.delayedLightbox();
            }
        }
    },

    delayedLightbox: function() {
        window.setTimeout(function() {
            lyr.alert(this.message.title, this.message.body, {
                vitrageClick : 'ignore',
                width        : 520,
                ok           : this.setRead,
                cancel       : this.setRead
            });
        }.bind(this), 1000);
    }

});


/**
 * Payment on publication of campaign
 * Either via paypal or using credits
 */
lyr.wgt.set('pmt-on-publication', {
    init: function() {
        this.receiptTotalRow   = this.element.find('.pmt-receipt-total-row, .pmt-receipt-msg');
        this.auxiliaryHide     = this.element.find('.pmt-receipt-foot, .pmt-receipt-foot-msg');

        this.purchaseWrapper   = this.element.find('.pmt-buy-options');
        this.purchaseOptions   = this.purchaseWrapper.find('fieldset');
        this.purchaseSpeils    = this.purchaseOptions.find('ul');
        this.proceedCheckout   = this.element.find('.pmt-proceed-checkout');

        this.freeFieldset      = this.element.find('fieldset.free');

        this.bundleFieldset    = this.element.find('fieldset.bundle');

        this.allOptions        = this.element.find('fieldset');
        this.paymentType       = this.element.data('pmt-type') || 'money';

        this.reqPages          = this.element.data('required-pages');
        this.maxBundlePages    = this.element.data('max-bundle-pages');

        this.bindEvents();
        this.initialSetup();

        this.setEqualHeight(this.purchaseSpeils);
        this.setEqualHeight(this.purchaseOptions);
    },

    publishViaCredits: function() {
        return this.paymentType !== 'money';
    },

    canOfferBundle: function() {
        return this.reqPages < this.maxBundlePages;
    },

    bindEvents: function() {
        this.element.on(lyr.event.FORM_SUCCESS, lyr.pmt.onFormSuccess.bind(this));

        this.purchaseOptions.on('click', function(e) {
            var src = $(e.srcElement);
            this.setAsSelected($(e.currentTarget), !src.is('input'));
        }.bind(this));

        if (!this.publishViaCredits()) {
            this.freeFieldset.on('click', function(e) {
                var src = $(e.srcElement || e.target);
                this.setAsSelected(this.freeFieldset, src);
            }.bind(this));
        }
    },

    initialSetup: function() {
        this.receiptTotalRow.hide();
        this.auxiliaryHide.hide();

        if (!this.canOfferBundle()) {
            this.bundleFieldset.hide();
        }

        $(this.allOptions[0]).find('input').click();
    },

    setAsSelected: function(option, triggerInput) {
        var dataKey = option.data('submit-text-alt') ? 'text-alt' : 'text';

        this.allOptions.removeClass('selected');
        option.addClass('selected');

        // ie - not propagating??
        if (triggerInput) {
            option.find('input').prop('checked', true);
        }

        this.proceedCheckout.text(this.proceedCheckout.data(dataKey));
    },

    setEqualHeight: function(elements) {
        var maxHeight = elements.eq(0).height();

        elements.each(function(i) {
            maxHeight = Math.max(maxHeight, elements.eq(i).height());
        });

        elements.css('height', maxHeight);
    }

});


/*
    The associated receipt row of the bundles being purchased
 */
lyr.wgt.set('pmt-bundle-receipt', {

    MAX_VALUE: 999,

    init: function() {
        this.bundleID   = this.element.data('bundle-id');
        this.parent      = this.element.parents('.pmt-buy-pages');

        this.inputVolume = this.element.find('.bundle-volume');
        this.humanPrice  = this.element.find('.pmt-subtotal'); // 00,00.00
        this.labelTitle  = this.element.find('.title');

        this.spinnerUp   = this.element.find('.up');
        this.spinnerDown = this.element.find('.dwn');

        this.price       = this.element.data('price');
        this.pages       = this.element.data('pages');
        this.title       = this.element.data('title');

        this.inputVolume.prop('name', 'bundle_id_' + this.bundleID);
        this.labelTitle.html(this.title);

        this.bundle = this.getBundle();

        this.element.hide();
        this.bindEvents();
    },

    getBundle: function() {
        var bundle = {
            id        : this.bundleID,
            title     : this.title,
            price     : this.price,
            pages     : this.pages,
            userAmount: 0
        };

        bundle.userPrice = function(unformat) {
            if (!unformat) {
                return lyr.format.priceRound(bundle.price * this.userAmount);
            } else {
                return bundle.price * this.userAmount;
            }
        };

        bundle.userPages = function() {
            return this.userAmount * bundle.pages;
        };

        return bundle;
    },

    bindEvents: function() {
        this.inputVolume.on('keyup', this.volumeChanged.bind(this));
        this.inputVolume.on('blur', this.inputBlur.bind(this));
        this.parent.on(lyr.event.PAYMENT_BUNDLE_CHECKED, this.bundleChecked.bind(this));

        this.spinnerUp.on('click', this.spinnerClicked.bind(this, 1));
        this.spinnerDown.on('click', this.spinnerClicked.bind(this, -1));
    },

    bundleChecked: function(e, bundleID, checked) {
        if (this.bundleID === bundleID) {
            if (checked) {
                this.inputVolume.val('1');
                this.element.stop();
                this.element.effect('highlight', {color: '#47b7d5'}, 500);
            } else {
                this.inputVolume.val('0');
            }
            this.element.toggle(checked);
            this.volumeChanged();
        }
    },

    inputBlur: function() {
        if (!this.inputVolume.val()) { this.inputVolume.val('1'); }
     },

    spinnerClicked: function(modifier) {
        var newVal = parseInt(this.inputVolume.val(), 10) + modifier;
        if (newVal) {
            this.inputVolume.val(newVal);
            this.volumeChanged();
        }
    },

    volumeChanged: function() {
        var volume = this.inputVolume.val().replace(/[^0-9]/, '');
        if (volume > this.MAX_VALUE) { volume = this.MAX_VALUE; } // max value check
        this.inputVolume.val(volume);
        this.bundle.userAmount = parseInt(volume || 1, 10);
        this.humanPrice.html(this.bundle.userPrice());
        this.parent.trigger(lyr.event.PAYMENT_BUNDLE_VOLUME, this.bundle);
    }
});



/*
    The form wrapping the bundles options and receipts.
    Bundle receipts are created from their respective option data.
        ~ built this way as there's less info to pass to the receipt than option.
 */
lyr.wgt.set('pmt-pre-purchase-credits', {

    EMPTY: '0',

    init: function() {
        this.receipt            = []; // will hold bundles {}

        this.receiptTable       = this.element.find('.pmt-receipt');
        this.receiptTotalRow    = this.element.find('.pmt-receipt-total-row, .pmt-receipt-msg');
        this.auxiliaryHide      = this.element.find('.pmt-receipt-foot, .pmt-receipt-foot-msg');
        this.receiptTotalLbl    = this.element.find('.pmt-receipt-total-label');
        this.receiptTotalFld    = this.element.find('.pmt-receipt-total-field');
        this.receiptPagesLbl    = this.element.find('.pmt-receipt-pages-label');
        this.receiptRows        = this.element.find('.pmt-receipt-wrap tbody');
        this.bundleOptions      = this.element.find('.pmt-buy-option');
        this.receiptTemplate    = this.element.find('#pmt-bundle-price').html();
        this.proceedCheckout    = this.element.find('.pmt-proceed-checkout');
        this.pricePerPage       = this.element.find('.ppp');

        this.initialSetup();
        this.bindEvents();
    },

    initialSetup: function() {
        this.receiptTotalRow.hide();
        this.auxiliaryHide.hide();
        this.proceedCheckout.prop('disabled', true);
        this.buildPricePerPage();
    },

    buildPricePerPage: function() {
        this.pricePerPage.each(function(i, val) {
            lyr.pmt.buildPriceWithDecimalFormat(this, $(val).html());
        });
    },

    /**
     * Deprecated
     * Used django loop instead
     * Left for testing/regression
     */
    populateBundleReceipts: function() {
        var receiptsWrap = this.receiptRows,
            receipts = [],
            receiptsHtml;

        $.each(this.bundleOptions, function(key, option) {
            option = $(option);

            receipts.push(
                {
                    bundle_id: option.data('bundle-id'),
                    price:     option.data('price'),
                    pages:     option.data('pages-per'),
                    title:     option.data('bundle-title')
                }
            );
        }.bind(this));

        receiptsHtml = Mustache.to_html(this.receiptTemplate, receipts);
        this.receiptRows.prepend(receiptsHtml);

        lyr.wgt.scan(receiptsWrap);
    },

    bindEvents: function() {
        this.element.on(lyr.event.PAYMENT_BUNDLE_VOLUME, this.volumeChanged.bind(this));
        this.element.on(lyr.event.FORM_SUCCESS, lyr.pmt.onFormSuccess.bind(this));
        this.bundleOptions.on('click', this.bundleOptionClick.bind(this));
    },

    isAnOptionSelected: function() {
        return this.bundleOptions.hasClass('selected');
    },

    bundleOptionClick: function(e) {
        var el    = $(e.target || e.currentTarget).parents('fieldset'),
            input = el.find('.bundle-choose'),
            checked;

        el.toggleClass('selected');
        checked = (el.hasClass('selected'));
        input.prop('checked', checked);
        this.element.trigger(lyr.event.PAYMENT_BUNDLE_CHECKED, [el.data('bundle-id'), checked]);

        // Toggle submit button
        this.proceedCheckout.prop('disabled', (!parseInt(this.receiptTotalLbl.html(), 10)) ||
                                               !this.isAnOptionSelected());
        // Remove border on table..
        this.receiptTable.toggleClass('visible', !this.proceedCheckout.prop('disabled'));

        // Stop propagation
        if ($(e.target).is('label')) {
             return false;
         }
    },

    volumeChanged: function(e, _bundle) {
       this.receipt[_bundle.id] = _bundle;
       this.calculateTotal();
    },

    calculateTotal: function() {
        var total = 0, volume = 0;

        for (var i = this.receipt.length; i >= 0; i--) {
            if (this.receipt[i]) {
                total += this.receipt[i].userPrice(true);
                volume += this.receipt[i].userPages();
            }
        }

        total = lyr.format.priceRound(total);

        // update the labels, values
        this.receiptTotalLbl.html(total);
        lyr.pmt.buildPriceWithDecimalFormat(this.receiptTotalLbl, total);

        this.receiptPagesLbl.html(volume); // + ' ' + lyr.format.pluralize(v, 'Page', 'Pages'));
        this.receiptTotalFld.val(total);

        // show/hide receipt total row
        this.receiptTotalRow.toggle(parseInt(total, 10) > 0);
        this.proceedCheckout.prop('disabled', parseInt(total, 10) <= 0);
    }

});
