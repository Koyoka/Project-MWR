

lyr.viewTargetBox = function() {
    this.selector = '.' + this.ns + 'lightbox';
}

lyr.viewTargetBox.prototype = {
    ns: 'lyr-lb-',
    open:function(){
     
        this.vitrage = $();
     
        this.vitrage = this._addVitrage();
        this._addLightbox();
        
       
        this.vitrage.on("click",this.close.bind(this));
    },
    
    close:function(){
         this.vitrage.fadeOut(this.setting.fadeOut, function() {
//            $(this).remove();
        });
    },
    _addVitrage: function() {
    
        var vitrage;
        vitrage = $('<div>').appendTo('body').css({opacity: 0});
        vitrage.addClass('vitrage lyr-lb-vitrage');
//        vitrage.addClass('vitrage ' + this.ns + 'vitrage');
        vitrage.fadeTo(this.setting.fadeIn, this.setting.vitrageOpacity);
        vitrage.on("click",this.close.bind(this));
        
        return vitrage;
    },
    _addLightbox: function() {
        var lightbox, content;

        this.contentWrap = $('<div>').addClass(this.ns + 'content');
        
        this.closeButton = $();
//        if (this.setting.closeButton) {
//            this.closeButton = $('<div>').addClass(this.ns + 'close').text('Close');
//        }

        lightbox = $('<div>').data({lightbox: this})
            .attr({id: this.setting.id})
            .addClass(this.ns + 'lightbox')
            .addClass(this.setting.addClass)
            .append(this.closeButton, this.contentWrap)
            .appendTo('body').css({opacity: 5});
        this.lightbox = lightbox;
        this.content("<div style='border:1px solid red;width:40px;height:40px;'>asdfafd</div>","");


        return lightbox;
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
            if (!placeholder && this.setting.animateOnResize) {
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
    
    setting:{
     // Content
        id                : '',        // Unique ID
//        url               : '',        // Fetch URL using Ajax and display this in dialog
//        html              : '',        // Put HTML in dialog
//        dom               : '',        // Copy dom_id inner HTML to dialog
    
     // Display
//        width             : 750,       // Width
//        height            : 'auto',    // Initial height
        addClass          : '',        // Extra classname(s) for lightbox
        closeButton       : true,      // Add a close button
//        vitrage           : true,      // Show vitrage
        vitrageOpacity    : 0.6,       // Opacity of vitrage. 0 for invisible
//        vitrageClick      : 'close',   // What happens when you click the vitrage (close|ignore)
        fadeIn            : 500,       // Vitrage fade in speed
        fadeOut           : 300,       // Vitrage fade out speed
        
         // Positioning, default is center
//        offsetObj         : false,     // Position at element, 'this' is current element
//        offsetX           : 3,         // Left offset calculated from top left of parent
//        offsetY           : 3,         // Top offset calculated from top left of parent
//        left              : false,     // Left absute position (offset and offsetObj are ignored)
//        top               : false,     // Top absolute position (offset and offsetObj are ignored)
//        windowPadding     : 30,        // Minimal distance from window
        animateOnResize   : true,      // Animate position when resizing
    }

}

lyr.viewTarget = new lyr.viewTargetBox();

//lyr.viewTarget.open();