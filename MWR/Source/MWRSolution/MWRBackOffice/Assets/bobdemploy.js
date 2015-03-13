var BOBDEmploy = function () {


    var initHelper = function () {
        gl.wgt.set('mw-activeempy', {
            init: function () {
                this.element.on('click', this.onClick.bind(this));
            },
            onClick: function (e) {
                e.preventDefault();
                var code = this.element.attr('data-wgt-empycode');
                $('#mw-opyType').val('active');
                $('#mw-opyEmpyCode').val(code);
                $('#mwFrmList').submit();
            }
        });

        gl.wgt.set('mw-voidempy', {
            init: function () {
                this.element.on('click', this.onClick.bind(this));
            },
            onClick: function (e) {
                e.preventDefault();
                var code = this.element.attr('data-wgt-empycode');
                $('#mw-opyType').val('void');
                $('#mw-opyEmpyCode').val(code);
                $('#mwFrmList').submit();
            }
        });

        gl.wgt.set('mw-editempy', {
            init: function () {
                this.element.on('click', this.onClick.bind(this));
            },
            onClick: function (e) {
                e.preventDefault();
                window.alert(1)
//                $('#mw-opyType').val('edit');
//                $('#mwFrmList').submit();
            }
        });
        gl.wgt.set('mw-newempy', {
            init: function () {
                this.element.on('click', this.onClick.bind(this));
            },
            onClick: function (e) {
                e.preventDefault();
                window.alert(2)
//                $('#mw-opyType').val('new');
//                $('#mwFrmList').submit();
            }
        });
      
    }

    var oTable;
    var nEditing = null;


    var _subrecall = function (el, netData, locData) {

        _initOTable();
        nEditing = null;
    };
    var _initOTable = function () {
        oTable = $('#sample_editable_1').dataTable({
            "aLengthMenu": [
                    [5, 15, 20, -1],
                    [5, 15, 20, "All"] // change per page values here
                ],
            // set the initial value
            //                "iDisplayLength": 5,
            //                "aaSorting": [[0, "asc"]],
            "bInfo": false, //开关，是否显示表格的一些信息
            "bPaginate": false, //开关，是否显示分页器
            //                "bSort": false, //开关，是否启用各列具有按列排序的功能
            "bLengthChange": false, //开关，是否显示每页大小的下拉框
            "bFilter": false, //开关，是否启用客户端过滤器
            "sPaginationType": "bootstrap",
            //                "oLanguage": {
            //                    "sLengthMenu": "_MENU_ records",
            //                    "oPaginate": {
            //                        "sPrevious": "Prev",
            //                        "sNext": "Next"
            //                    }
            //                },
            "aoColumnDefs": [
                    {
                        'bSortable': false,
                        'aTargets': [0]
                    },
                    {
                        'bSortable': false,
                        'aTargets': [1]
                    },
                    {
                        'bSortable': false,
                        'aTargets': [2]
                    },
                    {
                        'bSortable': false,
                        'aTargets': [3]
                    },
                    {
                        'bSortable': false,
                        'aTargets': [4]
                    }
                    ,
                    {
                        'bSortable': false,
                        'aTargets': [5]
                    }
                ]
        });
    };

    return {
        subrecall: _subrecall,
        init: function () {

            initHelper();

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
                var jqTds = $('>td', nRow);

                jqTds[0].innerHTML = aData[0] + '<input name="empyCode" type="hidden" class="form-control input-small" value="' + aData[0] + '">';
                jqTds[1].innerHTML = '******<input name="password" type="hidden" class="form-control input-small" value="' + aData[1] + '">';
                jqTds[2].innerHTML = '<input name="empyName" type="text" class="form-control input-small" value="' + aData[2] + '">';

                var temp = $('select[name="mw-tempEmpyTpe"]');
                jqTds[3].innerHTML = '<select name="empyTpe" class="form-control input-lg">' + temp.html() + '</select><input type="hidden" class="form-control input-small" value="' + aData[3] + '">'; //temp.html();// '<input type="text" class="form-control input-small" value="' + aData[2] + '">';
                $("select option[text='" + aData[3] + "']", $(jqTds[3])).attr("selected", true);

                //                jqTds[3].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[3] + '">';
                jqTds[5].innerHTML = '<a class="edit" data-wgt="mw-editempy" data-mode="save" href="">保存</a> <a class="cancel"  href="">取消</a>';

                $('input', jqTds[2]).focus();
                gl.wgt.scan($(nRow));
            }
            function newRow(oTable, nRow) {
                var aData = oTable.fnGetData(nRow);
                var jqTds = $('>td', nRow);
                jqTds[0].innerHTML = '<input name="empyCode" type="text" class="form-control input-small" value="' + aData[0] + '">';
                jqTds[1].innerHTML = '<input name="password" type="text" class="form-control input-small" value="' + aData[1] + '">';
                jqTds[2].innerHTML = '<input name="empyName" type="text" class="form-control input-small" value="' + aData[2] + '">';


                var temp = $('select[name="mw-tempEmpyTpe"]');
                jqTds[3].innerHTML = '<select name="empyTpe" class="form-control input-lg">' + temp.html() + '</select><input type="hidden" class="form-control input-small" value="' + aData[3] + '">'; //temp.html();// '<input type="text" class="form-control input-small" value="' + aData[2] + '">';
                $("select option[text='" + aData[3] + "']", $(jqTds[3])).attr("selected", true);

                //                jqTds[3].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[3] + '">';
                jqTds[5].innerHTML = '<a class="edit" data-wgt="mw-newempy" data-mode="save" href="">保存</a> <a class="cancel" data-mode="new" href="">取消</a>';
                $('input', jqTds[0]).focus();
                gl.wgt.scan($(nRow));
                //                jqTds[5].innerHTML = '<a href="#"  class="btn default btn-xs red cancel" data-mode="new"><i class="fa fa-edit"></i> 注销</a>'; //'<a class="cancel" data-mode="new" href="">Cancel</a>';
            }

            function saveRow(oTable, nRow) {
                var aData = oTable.fnGetData(nRow);

                var jqInputs = $('input', nRow);
                var jqSelect = $('select', nRow);
                oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
                oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
                oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
                oTable.fnUpdate($(jqSelect[0]).find("option:selected").text(), nRow, 3, false);

                //                oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
                oTable.fnUpdate('<a class="edit" href="">编辑</a>', nRow, 5, false);

                var dVoid = aData[6] == "" ? '<a href="#"  class="btn default btn-xs red cancel"><i class="fa fa-edit"></i> 注销</a>' : aData[6];
                oTable.fnUpdate(dVoid, nRow, 6, false);
                //                oTable.fnUpdate('<a class="delete" href="">Delete</a>', nRow, 5, false);
                oTable.fnDraw();
                
            }

            //            function cancelEditRow(oTable, nRow) {
            //                var jqInputs = $('input', nRow);
            //                var jqSelect = $('select', nRow);

            //                oTable.fnUpdate(jqInputs[0].value, nRow, 0, false);
            //                oTable.fnUpdate(jqInputs[1].value, nRow, 1, false);
            //                oTable.fnUpdate(jqInputs[2].value, nRow, 2, false);
            //                oTable.fnUpdate($(jqSelect[0]).find("option:selected").text(), nRow, 2, false);

            //                //                oTable.fnUpdate(jqInputs[3].value, nRow, 3, false);
            //                oTable.fnUpdate('<a class="edit" href="">编辑</a>', nRow, 4, false);
            //                oTable.fnDraw();
            //            }

            _initOTable();

            jQuery('#sample_editable_1_wrapper .dataTables_filter input').addClass("form-control input-medium"); // modify table search input
            jQuery('#sample_editable_1_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
            jQuery('#sample_editable_1_wrapper .dataTables_length select').select2({
                showSearchInput: false //hide search box with special css class
            }); // initialize select2 dropdown



            $('#sample_editable_1_new').click(function (e) {
                e.preventDefault();

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
                //                        '<a class="edit" href="">Edit</a>', 'data-mode="new"'//'<a class="cancel" data-mode="new" href="">Cancel</a>'
                ]);

                var nRow = oTable.fnGetNodes(aiNew[0]);



                newRow(oTable, nRow);
                nEditing = nRow;
            });

            $('#sample_editable_1 a.delete').live('click', function (e) {
                e.preventDefault();

                if (confirm("Are you sure to delete this row ?") == false) {
                    return;
                }

                var nRow = $(this).parents('tr')[0];
                oTable.fnDeleteRow(nRow);
                alert("Deleted! Do not forget to do some ajax to sync with backend :)");
            });

            $('#sample_editable_1 a.cancel').live('click', function (e) {
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

            $('#sample_editable_1 a.edit').live('click', function (e) {
                e.preventDefault();

                /* Get the row as a parent of the link that was clicked on */
                var nRow = $(this).parents('tr')[0];

                if (nEditing !== null && nEditing != nRow) {
                    /* Currently editing - but not this row - restore the old before continuing to edit mode */
                    restoreRow(oTable, nEditing);
                    editRow(oTable, nRow);
                    nEditing = nRow;
                } else if (nEditing == nRow && $(this).attr('data-mode') == "save") {
                    /* Editing this row and want to save it */
                    window.alert(3)
//                    saveRow(oTable, nEditing);
                    nEditing = null;
                    alert("Updated! Do not forget to do some ajax to sync with backend :)");
                } else {
                    /* No edit in progress - let's start one */
                    editRow(oTable, nRow);
                    nEditing = nRow;
                }
            });
        }
    };

} ();