/*jshint globalstrict: true */
/*global $, lyr */

'use strict';

/* Layar's custom validation methods */
$.validator.messages.required = '该值不能为空&nbsp;';
$.validator.messages.url = 'Please enter a valid URL that starts with http://';

$.validator.isValidYouTube = function(value) {
    var youtubeComRE, youtuBeRE;
    youtubeComRE = /^https?:\/\/(?:www\.)?youtube\.com\/watch\?(?=.*v=[a-zA-Z0-9_\-]{11})(?:\S+)?/;
    youtuBeRE = /^https?:\/\/(?:www\.)?youtu\.be\/[a-zA-Z0-9_\-]{11}(?:\S+)?$/;
    return youtubeComRE.test(value) || youtuBeRE.test(value);
};

$.validator.isValidURL = function(value) {
    var isValidURL = $.validator.methods.url.bind({optional: function() {
        return false;
    }});
    return isValidURL(value);
};

// Resolve conflict between HTML5 accept and jQuery Validator accept
$.validator.addMethod('accept', function() {
    return true;
});

$.validator.addMethod('alphanumeric', function(value, element) {
    return this.optional(element) || /^[a-z0-9_]+$/i.test(value);
}, 'Please use only letters, numbers and underscores');

$.validator.addMethod('loweralphanum', function(value, element) {
    return this.optional(element) || /^[a-z0-9]+$/.test(value);
}, 'Please use only lowercase letters and numbers');

$.validator.addMethod('validatelayername', function(value, element) {
    return this.optional(element) || /^[a-z0-9_]+$/.test(value);
}, 'Please use only lowercase letters, numbers and underscores');

$.validator.addMethod('hexnum', function(value, element) {
    return this.optional(element) || /^[a-fA-F0-9]+$/.test(value);
}, 'Must be a valid hexadecimal number, like 019ABF');

$.validator.addMethod('url_http_opt', function(value, element) {
    return this.optional(element) || /(https?:\/\/|www\.)(([a-zA-Z0-9\-])+\.)*/i.test(value);
}, $.validator.format('Enter a valid website starting with http:// or www'));

$.validator.addMethod('regex', function(value, element, param) {
    return this.optional(element) || param.test(value);
}, 'Incorrect format');

$.validator.addMethod('phone', function(phone_number, element) {
    phone_number = phone_number.replace(/\s+/g, "");
    return this.optional(element) || phone_number.match(/^\+?([0-9\(\)\-]){9,20}$/);
}, 'Please specify a valid phone number');

$.validator.addMethod('website', function(value, element) {
    return this.optional(element) || /(https?:\/\/|www\.)(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/.test(value);
}, $.validator.messages.url);

/* Creator */
$.validator.addMethod('youtube', function(value, element) {
    return this.optional(element) || $.validator.isValidYouTube(value);
}, 'Invalid YouTube video URL');

$.validator.addMethod('valid_youtube_prospect', function(value, element) {
    return this.optional(element) || !value.match(/(youtu\.be|youtube\.com)\//) || $.validator.isValidYouTube(value);
}, 'Invalid YouTube video URL');

$.validator.addMethod('valid_image_ext', function(value, element) {
    return this.optional(element) || /^.+\.(jpe|jpg|jpeg|png)$/i.test(value);
}, 'Please select a .jpg or .png image file');

$.validator.addMethod('valid_pdfzip', function(value, element) {
    return this.optional(element) || /^.+\.(pdf|zip)$/i.test(value);
}, 'Please select a .pdf or .zip file');

$.validator.addMethod('valid_image_or_pdfzip', function(value, element) {
    return this.optional(element) || /^.+\.(jpe|jpg|jpeg|png|pdf|zip)$/i.test(value);
}, 'Please select a .pdf or .zip file');

$.validator.addMethod('valid_appstore_link', function(value) {
    return !value || /(itunes\.apple\.com\/|apple\.com\/itunes).*id[0-9]{5,10}/.test(value);
}, 'Please provide a valid link to your iOS app');

$.validator.addMethod('valid_google_play_link', function(value) {
    return !value || /play\.google\.com\/store.*(\?|&)id=[\w\.]+(\?|&|$)/.test(value);
}, 'Please provide a valid link to your app on Google Play');

$.validator.addMethod('valid_facebook_link', function(value) {
    return !value || /^https?:\/\/(?:www\.)?facebook\.com/.test(value);
}, 'Please provide a valid link to your Facebook page');

$.validator.addMethod('valid_pinterest', function(value) {
    return !value || /^https?\:\/\/(?:www\.)?pinterest\.com\/pin\/[0-9]+\/$/.test(value);
}, 'Please provide a valid link to your Pinterest pin');

$.validator.addMethod('valid_hex_color', function(value) {
    return !value || /^[a-fA-F0-9]{6}$/.test(value);
}, 'Please provide a valid color');

$.validator.addMethod('valid_twitter_account', function(value) {
    return !value || /([A-Za-z0-9_]{1,15})/.test(value);
}, 'Please provide a valid Twitter account name.');

$.validator.addMethod('valid_carousel_min_imgs', function() {
    return ($('.btg-csl-tile img').length >= 2);
}, 'Please add at least two images to your carousel. Use this field to upload JPG or PNG image files.');

$.validator.addMethod('valid_viewport_side', function(value) {
    return !value || parseInt(value, 10) <= 1024;
}, 'The maximum value for a viewport dimension is 1024');

$.validator.addMethod('valid_viewport_total', function(value, element) {
    var elements = $(element).closest('form').find('.valid_viewport_total'),
        w = parseInt(elements[0].value, 10),
        h = parseInt(elements[1].value, 10);
    return h * w <= 512 * 512;
}, 'The viewport dimensions’ width &times; height exceeds the maximum of 262,144 pixels. ' +
   'Consider linking to a page optimized for mobile screen sizes.');

$.validator.addMethod('valid_download_app', function(value, element) {
    var form = $(element).closest('form'),
        iphone_url = form.find('[name=iphone_url]:visible'),
        android_url = form.find('[name=android_url]:visible');
    return (iphone_url.val() || android_url.val());
}, 'Please enter at least one platform.');

$.validator.addMethod('valid_custom_scheme_platform', function(value, element) {
    var form = $(element).closest('form'),
        iphone_uri = form.find('[name=ios_uri]:visible'),
        android_uri = form.find('[name=android_uri]:visible');
    return (iphone_uri.val() || android_uri.val());
}, 'Please enter at least one platform.');

$.validator.addMethod('valid_custom_scheme', function(value) {
    var uriRegex = /^(?:([a-z0-9+.-]+:\/\/)((?:(?:[a-z0-9-._~!$&'()*+,;=:]|%[0-9A-F]{2})*)@)?((?:[a-z0-9-._~!$&'()*+,;=]|%[0-9A-F]{2})*)(:(?:\d*))?(\/(?:[a-z0-9-._~!$&'()*+,;=:@\/]|%[0-9A-F]{2})*)?|([a-z0-9+.-]+:)(\/?(?:[a-z0-9-._~!$&'()*+,;=:@]|%[0-9A-F]{2})+(?:[a-z0-9-._~!$&'()*+,;=:@\/]|%[0-9A-F]{2})*)?)(\?(?:[a-z0-9-._~!$&'()*+,;=:\/?@]|%[0-9A-F]{2})*)?(#(?:[a-z0-9-._~!$&'()*+,;=:\/?@]|%[0-9A-F]{2})*)?$/i;
    return !value || uriRegex.test(value);
}, 'Please provide a valid URI.');

$.validator.addMethod('validate_hotspot', function(value) {
    try {
        var json = JSON.parse(value);
        return !value || !!json;
    } catch(err) {
        return false;
    }
}, 'Invalid JSON!');