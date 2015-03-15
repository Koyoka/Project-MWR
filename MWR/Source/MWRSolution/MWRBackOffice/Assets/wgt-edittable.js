

var WGTEdtiTable = function () {
    var oTable;
    var nEditing = null;
    var initHelper = function () {
        gl.wgt.set('mw-edittable-cancel', {
            init: function () {
                this.element.on('click', this.onClick.bind(this));
            },
            onClick: function (e) {
                e.preventDefault();
                if (nEditing == null) { return; }
                if ($(this).attr("data-mode") == "new") {
                    var nRow = $(this).parents('tr')[0];
                    oTable.fnDeleteRow(nRow);
                    nEditing = null;
                } else {
                    restoreRow(oTable, nEditing);
                    nEditing = null;
                }
            }
        });

        gl.wgt.set('mw-edittable-edit', {
            init: function () {
                this.element.on('click', this.onClick.bind(this));
            },
            onClick: function (e) {
                e.preventDefault();

                var nRow = $(this).parents('tr')[0];
                if (nEditing !== null && nEditing != nRow) {
                    restoreRow(oTable, nEditing);
                    editRow(oTable, nRow);
                    nEditing = nRow;
                } else if (nEditing == nRow && $(this).attr('data-mode') == "save") {




                    var url, method, data;
                    method = this.element.attr('data-wgt-edittable-method'); //"AjaxEditCar";
                    url = this.element.attr('data-wgt-edittable-url'); // "/Pages/BO/BaseData/BDCar.aspx";
                    data = {};

                    var tempForm = $("<form>");
                    tempForm.html($(nRow).html());
                    var tempInput = $('input,select', tempForm);
                    for (var i = 0; i < tempInput.length; i++) {

                        var name = tempInput.eq(i).attr('name')
                        if (!name) {
                            tempInput.eq(i).attr('name', tempInput.eq(i).attr('id'));
                        }
                    }


//                    var jqTds = $('>td', nRow);
//                    for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
//                        var td = $(jqTds[i]);
//                        var input = $('input', td);
//                        if (input.length > 0) {
//                            data["carCode"]
//                        } else if (true) {

//                        }
//                    }

//                    data["carCode"] = $('#carCode').val();
//                    data["desc"] = $('#desc').val();
//                    data["opyType"] = $(this).attr('data-opt');

//                    if (data["carCode"] == ""
//                    || data["desc"] == "") {
//                        Modal.alert("请填写信息")
//                        return;
//                    }

//                    $.AjaxPJson(url, method, data, function (d) {
//                        $('#mwFrmList').submit();
//                    }, function (r) {
//                        Modal.alert('[' + r + ']');
//                    });
                } else {
                    editRow(oTable, nRow);
                    nEditing = nRow;
                }
            }
        });
    }

    function restoreRow(oTable, nRow) {
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
    }
    function editRow(oTable, nRow) {

        var aData = oTable.fnGetData(nRow);
        var temp = $('#mw-rowedittemp');
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
            if (input.length > 0)
                input.val(data);
            if (select.length > 0)
                $("option[text='" + data + "']", select).attr("selected", true);
        }
        $('input', jqTds[1]).focus();
        gl.wgt.scan($(nRow));
    }
    function newRow(oTable, nRow) {
        var aData = oTable.fnGetData(nRow);
        var temp = $('#mw-rownewtemp');
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
            if (input.length > 0)
                input.val(data);
            if (select.length > 0)
                $("option[text='" + data + "']", select).attr("selected", true);
        }
        $('input', jqTds[0]).focus();
        gl.wgt.scan($(nRow));
    }
    function saveRow(oTable, nRow) {
        var aData = oTable.fnGetData(nRow);
        var jqTds = $('>td', nRow);

        var temp = $('#mw-rowdefaulttemp');
        var tempTds = $('>td', temp);


        for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
            var td = $(jqTds[i]);
            var tempTd = tempTds[i];

            var html = tempTd.html().replace(reg, function (node, key) {
                return {
                    Value: aData[i],
                    empty1: ""
                }[key];
            });

            var input = $('input', $(html));
            var select = $("select", $(html));
            var val;
            if (input.length > 0) {
                oTable.fnUpdate(input.value, nRow, 0, false);
                val = input.val();
            } else if (select.length > 0) {
                val = select.val();
            }
            oTable.fnUpdate(val, nRow, i, false);
        }
        oTable.fnDraw();

        return;
        var jqInputs = $('input', nRow);
        var jqSelect = $('select', nRow);
        oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
        oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
        oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
        oTable.fnUpdate($(jqSelect[0]).find("option:selected").text(), nRow, 3, false);

        oTable.fnUpdate('<a class="edit" href="">编辑</a>', nRow, 5, false);

        var dVoid = aData[6] == "" ? '<a href="#"  class="btn default btn-xs red cancel"><i class="fa fa-edit"></i> 注销</a>' : aData[6];
        oTable.fnUpdate(dVoid, nRow, 6, false);
        oTable.fnDraw();

    }

    return {
        subrecall: _subrecall,
        init: function () {

            initHelper();


            _initOTable();

            jQuery('#sample_editable_1_wrapper .dataTables_filter input').addClass("form-control input-medium"); // modify table search input
            jQuery('#sample_editable_1_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
            jQuery('#sample_editable_1_wrapper .dataTables_length select').select2({
                showSearchInput: false //hide search box with special css class
            });

            $('#sample_editable_1_new').click(function (e) {
                e.preventDefault();
                window.alert("clcik c")
                return;
                if (nEditing !== null && nEditing != nRow) {
                    /* Currently editing - but not this row - restore the old before continuing to edit mode */
                    if ($(nEditing).find('.cancel').attr('data-mode') == "new") {
                        window.alert("新数据未保存");
                        return;
                    }
                    restoreRow(oTable, nEditing);
                }
                var aiNew = oTable.fnAddData(['', '', '', '', '',
                    '', ''
                ]);
                var nRow = oTable.fnGetNodes(aiNew[0]);
                newRow(oTable, nRow);
                nEditing = nRow;
            });

            $('#sample_editable_1 a.cancel').on('click', function (e) {
                e.preventDefault();
                if (nEditing == null) { return; }
                if ($(this).attr("data-mode") == "new") {
                    var nRow = $(this).parents('tr')[0];
                    oTable.fnDeleteRow(nRow);
                    nEditing = null;
                } else {
                    restoreRow(oTable, nEditing);
                    nEditing = null;
                }
            });

            $('#sample_editable_1 a.edit').on('click', function (e) {
                e.preventDefault();

            });
        }
    };

} ();