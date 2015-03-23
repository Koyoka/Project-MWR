var WGTEdtiTable = function () {

    var initHelper = function () {
        validFromGroup();
        gl.wgt.set('mw-edittable', {
            _oTable: null,
            _nEditing: null,
            $this: null,
            init: function () {
                $this = this;
                this._oTable = this.element.find('table').data('mw-oTable');
                if (!this._oTable) {
                    window.alert('please set table data[$(table),data("mw-oTable",oTable)]');
                    return;
                }
                this.setBtnEvent(this.element);
            },
            setBtnEvent: function (el) {
                $('a.cancel', el).on('click', this.onCancelClickEvent);
                $('a.edit', el).on('click', this.onEditClickEvent);
                $('.mw-creat', el).on('click', this.onCreateClickEvent);
                $('.mw-btn-search', el).on('click', function (e) {
                    e.preventDefault();
                    el.find('.mw-txt-filterValue').val(el.find('.mw-txt-filterEdit').val());
                    el.setGroup('search', false);
                    el.submit();
                });
                $('.mw-btn-search-clear', el).on('click', function (e) {
                    el.find('.mw-txt-filterValue').val('');
                    el.setGroup('search', false);
                    el.submit();
                });
            },
            onCancelClickEvent: function (e) {
                e.preventDefault();
                //                                window.alert('cancel event')
                if ($this._nEditing == null) { return; }
                if ($(this).attr("data-mode") == "new") {
                    var nRow = $(this).parents('tr')[0];
                    $this._oTable.fnDeleteRow(nRow);
                    $this._nEditing = null;
                } else {
                    $this.restoreRow($this._oTable, $this._nEditing);
                    $this._nEditing = null;
                }
            },
            onEditClickEvent: function (e) {
                e.preventDefault();
                //                                window.alert('edit event')
                var nRow = $(this).parents('tr')[0];
                if ($this._nEditing !== null && $this._nEditing != nRow) {
                    $this.restoreRow($this._oTable, $this._nEditing);

                    $this.editRow($this._oTable, nRow);
                    $this._nEditing = nRow;
                } else if ($this._nEditing == nRow && $(this).attr('data-mode') == "save") {
                    $this.element.setGroup('save');
                    $this.element.submit();
                } else {
                    //                    window.alert($this._oTable+" 111")
                    $this.editRow($this._oTable, nRow);
                    $this._nEditing = nRow;
                }
            },
            onCreateClickEvent: function (e) {
                //                window.alert('click event')
                if ($this._nEditing !== null && $this._nEditing != nRow) {
                    if ($($this._nEditing).find('.cancel').attr('data-mode') == "new") {
                        window.alert("新数据未保存");
                        return;
                    }
                    $this.restoreRow($this._oTable, $this._nEditing);
                }
                var aiNew = $this._oTable.fnAddData(['', '', '', '', '',
                    '', ''
                ]);
                var nRow = $this._oTable.fnGetNodes(aiNew[0]);
                $this.newRow($this._oTable, nRow);
                $this._nEditing = nRow;
            },
            restoreRow: function (oTable, nRow) {
                var aData = oTable.fnGetData(nRow);
                var jqTds = $('>td', nRow);

                for (var i = 0, iLen = jqTds.length; i < iLen; i++) {

                    if ($(nRow).find('.cancel').attr('data-mode') == "new") {
                        oTable.fnDeleteRow(nRow);
                    } else {
                        oTable.fnUpdate(aData[i], nRow, i, false);
                    }
                }
                oTable.fnDraw();
                gl.wgt.scan($this.element);
                this.setBtnEvent(nRow);
            },
            newRow: function (oTable, nRow) {
                var aData = oTable.fnGetData(nRow);
                var temp = $('#mw-rownewtemp', this.element);
                $(nRow).html(temp.html());
                var reg = new RegExp("\\[([^\\[\\]]*?)\\]", 'igm');
                var jqTds = $('>td', nRow);
                for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                    var td = $(jqTds[i]);

                    var html = td.html().replace(reg, function (node, key) {
                        return {
                            Value: aData[i],
                            empty1: ""
                        }[key];
                    });

                    td.html(html);
                    var data = aData[i];
                    var input = $('input', td);
                    var select = $("select", td);
                    if (input.length > 0) {
                        if (input.eq(0).val() == "") {
                            input.val(data);
                        }
                        //                        input.val(data);
                    }
                    if (select.length > 0)
                        $("option[text='" + data + "']", select).attr("selected", true);
                }
                $('input', jqTds[0]).focus();
                gl.wgt.scan($this.element);
                this.setBtnEvent(nRow);
            },
            editRow: function (oTable, nRow) {
                //                window.alert(oTable)
                var aData = oTable.fnGetData(nRow);
                //                window.alert(aData)
                var temp = $('#mw-rowedittemp', this.element);
                $(nRow).html(temp.html());
                var reg = new RegExp("\\[([^\\[\\]]*?)\\]", 'igm');
                var jqTds = $('>td', nRow);
                for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                    var td = $(jqTds[i]);

                    var tempInput = $('<div>').html(aData[i]).find('input')
                    var data = tempInput.length == 0 ? aData[i] : tempInput.eq(0).val();
                    var html = td.html().replace(reg, function (node, key) {
                        return {
                            Value: data,
                            empty: ""
                        }[key];
                    });
                    td.html(html);
                    var input = $('input', td);
                    var select = $("select", td);
                    if (input.length > 0) {
                        if (input.eq(0).val() == "") {
                            input.val(data);
                        }
                    }
                    if (select.length > 0)
                        $("option[text='" + data + "']", select).attr("selected", true);
                }
                $('input', jqTds[1]).focus();
                gl.wgt.scan($this.element);
                this.setBtnEvent(nRow);
            }

        });

        return;
        //        gl.wgt.set('mw-edittable-cancel', {
        //            init: function () {
        //                this.element.on('click', this.onClick.bind(this));
        //            },
        //            onClick: function (e) {
        //                e.preventDefault();
        //                if (nEditing == null) { return; }
        //                if ($(this.element).attr("data-mode") == "new") {
        //                    var nRow = $(this.element).parents('tr')[0];
        //                    oTable.fnDeleteRow(nRow);
        //                    nEditing = null;
        //                } else {
        //                    restoreRow(oTable, nEditing);
        //                    nEditing = null;
        //                }
        //            }
        //        });

        //        gl.wgt.set('mw-edittable-edit', {
        //            init: function () {
        //                this.element.on('click', this.onClick.bind(this));
        //            },
        //            onClick: function (e) {
        //                e.preventDefault();
        //                //                window.alert(1);
        //                //                return;

        //                var nRow = $(this.element).parents('tr')[0];
        //                if (nEditing !== null && nEditing != nRow) {
        //                    restoreRow(oTable, nEditing);
        //                    editRow(oTable, nRow);
        //                    nEditing = nRow;
        //                } else if (nEditing == nRow && $(this.element).attr('data-mode') == "save") {
        //                    //                    var url, method, data;
        //                    //                    method = this.element.attr('data-wgt-edittable-method'); //"AjaxEditCar";
        //                    //                    url = this.element.attr('data-wgt-edittable-url'); // "/Pages/BO/BaseData/BDCar.aspx";
        //                    //                    data = {};

        //                    //                    var tempForm = $("<form>");
        //                    //                    tempForm.html($(nRow).html());
        //                    //                    var tempInput = $('input,select', tempForm);
        //                    //                    for (var i = 0; i < tempInput.length; i++) {
        //                    //                        var name = tempInput.eq(i).attr('name')
        //                    //                        if (!name) {
        //                    //                            tempInput.eq(i).attr('name', tempInput.eq(i).attr('id'));
        //                    //                        }
        //                    //                    }
        //                    $('form').setGroup($(this.element).attr('data-mode'));
        //                    $('form').submit();
        //                    //                    var jqTds = $('>td', nRow);
        //                    //                    for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
        //                    //                        var td = $(jqTds[i]);
        //                    //                        var input = $('input', td);
        //                    //                        if (input.length > 0) {
        //                    //                            data["carCode"]
        //                    //                        } else if (true) {

        //                    //                        }
        //                    //                    }

        //                    //                    data["carCode"] = $('#carCode').val();
        //                    //                    data["desc"] = $('#desc').val();
        //                    //                    data["opyType"] = $(this).attr('data-opt');

        //                    //                    if (data["carCode"] == ""
        //                    //                    || data["desc"] == "") {
        //                    //                        Modal.alert("请填写信息")
        //                    //                        return;
        //                    //                    }

        //                    //                    $.AjaxPJson(url, method, data, function (d) {
        //                    //                        $('#mwFrmList').submit();
        //                    //                    }, function (r) {
        //                    //                        Modal.alert('[' + r + ']');
        //                    //                    });
        //                } else {
        //                    editRow(oTable, nRow);
        //                    nEditing = nRow;
        //                }
        //            }
        //        });
    }
    function validFromGroup() {
        if (!$.validator) {
            return;
        }
        $.validator.prototype.checkForm = function () {
            this.prepareForm();
            var mw_group = $(this.currentForm).data('submit-group');
            for (var i = 0, elements = (this.currentElements = this.elements()); elements[i]; i++) {
                if (mw_group) {
                    var g = $(elements[i]).attr('submit-group')
                    if (g == mw_group) {
                        this.check(elements[i]);
                    }
                } else {
                    this.check(elements[i]);
                }
            }
            return this.valid();
        }
        $.validator.staticRules = function (element) {
            var rules = {};
            var validator = $.data(element.form, "validator");
            if (!validator) {
                return rules;
            }
            if (validator.settings.rules) {
                rules = $.validator.normalizeRule(validator.settings.rules[element.name]) || {};
            }
            return rules;
        };
    };
    return {
        init: function () {
            initHelper();
        }
    };

} ();