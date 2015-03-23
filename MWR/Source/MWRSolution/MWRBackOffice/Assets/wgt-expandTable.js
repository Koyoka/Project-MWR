var WGTExpandTable = function () {

    var initHelper = function () {
        gl.wgt.set('mw-expandtable-ajaxchild', {
            _oTable: null,
            $this: null,
            _url: null,
            _method: null,
            init: function () {
                if (this.element.find('.dataTables_empty').length > 0) {
                    return;
                }
                if (!jQuery().dataTable) {
                    window.alert('please set datatable plugins');
                    return;
                }
                $this = this;
                this._oTable = this.element.data('mw-oTable');
                if (!this._oTable) {
                    window.alert('please set table data[$(table),data("mw-oTable",oTable)]');
                    return;
                }

                this._url = this.element.attr('data-wgt-submit-url');
                this._method = this.element.attr('data-wgt-submit-method');


                var nCloneTh = document.createElement('th');
                var nCloneTd = document.createElement('td');
                $(nCloneTd).attr('width', '20')
                nCloneTd.innerHTML = '<span class="row-details row-details-close"></span>';

                $('thead tr', this.element).each(function () {
                    this.insertBefore(nCloneTh, this.childNodes[0]);
                });

                $('tbody tr', this.element).each(function () {
                    this.insertBefore(nCloneTd.cloneNode(true), this.childNodes[0]);
                });

                this.element.on('click', ' tbody td .row-details', function () {

                    if (!$this._oTable) {
                        return;
                    }
                    var nTr = $(this).parents('tr')[0];
                    if ($this._oTable.fnIsOpen(nTr)) {
                        /* This row is already open - close it */
                        $(this).addClass("row-details-close").removeClass("row-details-open");
                        $this._oTable.fnClose(nTr);
                    } else {

                        var nRow = $(this).parents('tr')[0];
                        var data = {};
                        for (var i = 0; i < $('input[name]', $(nRow)).length; i++) {
                            var name = $('input[name]', $(nRow)).eq(i).attr('name');
                            var val = $('input[name]', $(nRow)).eq(i).val();
                            data[name] = val;
                        }
                        //                        window.alert(JSON.stringify(data));
                        //                        return;
                        $me = this;
                        //                        $($this).addClass("row-details-open").removeClass("row-details-close");
                        $.AjaxPJson($this._url, $this._method, data, function (d) {
                            if (!tmpl) {
                                window.alert('please set teml.min.js plugins');
                                return;
                            }
                            var func = tmpl('mw-table-template');
                            if (!func) {
                                window.alert('please set temp <script id="mw-table-template" type="text/x-tmpl">');
                                return;
                            }
                            var result = func({
                                data: d.Value
                            });
                            if (result instanceof $) {
                                return;
                            }

                            var sOut = result;
                            //                            window.alert(sOut + " " + $this._url + " " + $this._method)
                            $($me).addClass("row-details-open").removeClass("row-details-close");
                            $this._oTable.fnOpen(nTr, sOut, '');
                            //                    App.unblockUI($(nTr));
                        }, function (r) {
                            Modal.alert('[' + r + ']');
                        });
                    }

                });
            }
        });
    };

    return {
        init: function () {
            initHelper();
        }
    };
} ();