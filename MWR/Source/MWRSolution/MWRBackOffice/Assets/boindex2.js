
var IndexHelper = function () {

    var pageContent = $('.page-content');
    var _swicthContent = function (u) {
        App.blockUI(pageContent, false);
    };
    var initHelper = function () {

      
        $('a[target="mw-mainFrame"]').click(function (e) {
            var ifr = $('#mw-mainFrame');
            //            ifr.height(0+"px");
            App.blockUI(pageContent, false);
        });
        gl.wgt.set('mw-loadpage', {
            _ifr: null,
            init: function () {
                this.hashChangeEvent();
                this.loadDefaultPage();
            },
            menuArrowFocus: function (page) {
                //                window.alert(page)
                var menuContainer = jQuery('.page-sidebar ul');
                var pageContentBody = $('.page-content .page-content-body');
                menuContainer.children('li.active').removeClass('active');
                menuContainer.children('arrow.open').removeClass('open');

                var ctrl = $("a");
                var defineCtrl = ctrl
                .filter(function () {
                    return $(this).attr('href').indexOf(page) != -1;

                })
                .get();

                //                window.alert(defineCtrl.length);
                //                return;
                //                window.alert(ctrl.length);
                $(defineCtrl).parents('li').each(function () {
                    $(defineCtrl).addClass('active');
                    $(defineCtrl).children('a > span.arrow').addClass('open');
                });
                $(defineCtrl).parents('li').addClass('active');
            },
            loadDefaultPage: function () {
                var ifr = $('#mw-mainFrame');
                _ifr = ifr;
                var $this = this;
                $(_ifr).load(function () {

                    var a = window.frames[0].location.href;
                    var arry = a.split('/').length;
                    var page = a.split('/')[arry - 1];
                    //                    window.alert(a.split('/')[arry - 1]);
                    $this.menuArrowFocus(page);
                    App.unblockUI(pageContent);
                    $(window.frames[0].document).find('.mw-redirect').on('click', function (e) {
                        //                        window.alert('eleven')
                        App.blockUI(pageContent, false);
                    });
                   
                });
                var defaultPage = this.element.attr("data-default");
                if (!ifr.attr('src')) {
                    App.blockUI(pageContent, false);
                    ifr.attr('src', defaultPage);
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
                App.blockUI(pageContent, false);
                var pageContent = $('.page-content');

                var s = location.hash;
                s = s.indexOf('?', 0);
                var url = page + (s == -1 ? "?container=1" : "&container=1"); // $(this.element).attr("href") + "?container=1";
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

                //                                url = "webform1.aspx";
                //                window.setTimeout(function () {

                _ifr.attr("src", page);
                //                window.alert(_ifr.height()+" " + _ifr.attr("src"));
                return;
                $.ajax({
                    type: "GET",
                    //                        cache: true,
                    url: url,
                    dataType: "html",
                    success: function (res) {
                        pageContentBody.html("");

                        var html = $(res);
                        var link = html.find('link');
                        var loadTime = 0;
                        if (link.length != 0) {
                            pageContentBody.append(link);
                            loadTime = 400;
                            var count = 0;

                        }

                        //                            window.setTimeout(function () {
                        pageContentBody.append(html.find('#mw-content-body'));
                        App.fixContentHeight(); // fix content height
                        App.initAjax(); // initialize core stuff
                        gl.wgt.scan(pageContent);
                        App.unblockUI(pageContent);
                        //                            window.alert(pageContentBody.html())
                        //                            }, loadTime);
                        //                            pageContentBody.html(res);
                        //                            window.alert(pageContentBody.html())

                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        pageContentBody.html('<h4>页面加载连接错误。</h4>');
                        App.unblockUI(pageContent);
                    }
                    , async: true
                });
                //                }, 1);
            }

        });
    };
    return {
        init: function () {
            initHelper();
        },
        swicthContent: _swicthContent
    };
} ();
