
var SetupIndexHelper = function () {
    var _stepArray = null;
    var _nextStep = function () {
        //        window.alert(_stepArray[0].toLowerCase());
        //        window.alert(window.location.hash);

        if (_stepArray != null) {
            var s = window.location.hash.toLowerCase();
            var curIndex = 0;
            for (i = 0; i < _stepArray.length; i++) {
                if (_stepArray[i].toLowerCase() == s) {
                    curIndex = i;
                    break;
                }
            }

            if (curIndex + 1 < _stepArray.length) {
                window.location.hash = _stepArray[curIndex + 1];
                $('.page-sidebar-menu .disabled-link').eq(0).removeClass('disabled-link');
            } else {
                window.alert('no next step.')
            }


        }
    }
    var initHelper = function () {

        $('.disabled-link a').live('click', function (e) {
//            window.alert("请完成当前步骤");
            return false;
        });


        _stepArray = $('.page-sidebar-menu a')
        .map(function (i, e) {
            return $(this).attr('href');
        })
        .get();


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
                    //                    location.reload();
                    //                    window.location.href = "";
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

                App.blockUI(pageContent, false);
                window.setTimeout(function () {
                    $.ajax({
                        type: "GET",
                        cache: false,
                        url: url,
                        dataType: "html",
                        success: function (res) {
                            pageContentBody.html("");
//                            $.widget('blueimp.fileupload', {});
                            var html = $(res);
                            var link = html.find('link');
                            var loadTime = 0;
                            if (link.length != 0) {
                                pageContentBody.append(link);
                                loadTime = 400;
                                var count = 0;

                            }

                            window.setTimeout(function () {
                                pageContentBody.append(html.find('#mw-content-body'));
                                App.fixContentHeight(); // fix content height
                                App.initAjax(); // initialize core stuff
                                gl.wgt.scan(pageContent);
                                App.unblockUI(pageContent);
                                //                            window.alert(pageContentBody.html())
                            }, loadTime);
                            //                            pageContentBody.html(res);
                            //                            window.alert(pageContentBody.html())

                        },
                        error: function (xhr, ajaxOptions, thrownError) {
                            pageContentBody.html('<h4>页面加载连接错误。</h4>');
                            App.unblockUI(pageContent);
                        },
                        async: false
                    });
                }, 1);
            }

        });
    };
    return {
        NextStep: _nextStep,
        init: function () {
            initHelper();
        }
    };
} ();
