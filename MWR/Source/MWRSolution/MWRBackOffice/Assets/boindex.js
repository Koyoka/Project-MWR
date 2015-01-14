
var IndexHelper = function () {

    var initHelper = function () {

        gl.wgt.set('t', {

            init: function () {
                this.element.on("click", this.testClick.bind(this));
            },

            testClick: function (e) {
                window.alert(1);
            }
        });

        gl.wgt.set('mw-loadpage', {

            init: function () {
                this.hashChangeEvent();
                this.loadDefaultPage();
            },
            loadDefaultPage: function () {
                var pageContentBody = $('.page-content .page-content-body');
                var defaultPage = this.element.attr("data-default");

                var page = this.getPageByHash();
                if (pageContentBody.html().trim().length == 0
                    && !page) {
                    location.hash = defaultPage;
                } else if (pageContentBody.html().trim().length == 0 && !!page) {
                    this.loadPage(page);
                } else {

                }
            },
            hashChangeEvent: function () {
                $(window).on('hashchange', function () {
                    var page = this.getPageByHash();
                    if (page) {
                        this.loadPage(page);
                    }
                } .bind(this));
            },
            getPageByHash: function () {
                var page = false;
                if (location.hash && location.hash !== '#') {
                    page = location.hash.replace("#", "");
                }

                return page;
            },
            loadPage: function (page) {
                //                e.preventDefault();
                var pageContent = $('.page-content');
                

                var url = page + "?container=1"; // $(this.element).attr("href") + "?container=1";
                var menuContainer = jQuery('.page-sidebar ul');

                var pageContentBody = $('.page-content .page-content-body');

                menuContainer.children('li.active').removeClass('active');
                menuContainer.children('arrow.open').removeClass('open');

                var ctrl = $("[href='#" + page + "']");

                $(ctrl).parents('li').each(function () {
                    $(ctrl).addClass('active');
                    $(ctrl).children('a > span.arrow').addClass('open');
                });
                $(ctrl).parents('li').addClass('active');
                App.blockUI(pageContent, false);
                window.setTimeout(function () {
                    $.ajax({
                        type: "GET",
                        cache: false,
                        url: url,
                        dataType: "html",
                        success: function (res) {
                            App.unblockUI(pageContent);
                            pageContentBody.html(res);

                            App.fixContentHeight(); // fix content height
                            App.initAjax(); // initialize core stuff
                            gl.wgt.scan(pageContent);
                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            pageContentBody.html('<h4>页面加载连接错误。</h4>');
                            App.unblockUI(pageContent);
                        },
                        async: true
                    });
                }, 10);
            }

        });
    };
    return {
        init: function () {
            initHelper();
        }
    };
} ();
