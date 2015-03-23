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
                $('#mwFrmList').setGroup('active');
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
                $('#mwFrmList').setGroup('active');
                $('#mwFrmList').submit();
            }
        });
    }

    var _initFrmValid = function () {
        var error1 = $('.alert-danger');
        $('#mwFrmList').validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: true, // do not focus the last invalid input
            ignore: "",
            rules: {
                empyCode: {
                    minlength: 2,
                    required: true
                },
                password: {
                    required: true
                },
                empyName: {
                    required: true
                }
            },
            messages: {
                empyCode: "请输入员工编号，大于2字符",
                password: "请输入员工密码",
                empyName: "请输入员工姓名"
            },
            invalidHandler: function (event, validator) { //display error alert on form submit              
                error1.show();
                App.scrollTo(error1, -200);
            },
            highlight: function (element) { // hightlight error inputs
                $(element)
                        .closest('.form-group').addClass('has-error'); // set error class to the control group
            },
            unhighlight: function (element) { // revert the change done by hightlight
                $(element)
                        .closest('.form-group').removeClass('has-error'); // set error class to the control group
            },
            success: function (label) {
                label
                        .closest('.form-group').removeClass('has-error'); // set success class to the control group
            },
            submitHandler: function (form) {
                error1.hide();
            }
        });
    };
    var _subrecall = function (el, netData, locData) {
        _initOTable();
        _initFrmValid();

    };
    var _initOTable = function () {
        var ot = $('#sample_editable_1').dataTable({
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
        $('#sample_editable_1').data('mw-oTable', ot);
    };

    return {
        subrecall: _subrecall,
        init: function () {
            initHelper();
            _initOTable();
            _initFrmValid();
            jQuery('#sample_editable_1_wrapper .dataTables_filter input').addClass("form-control input-medium"); // modify table search input
            jQuery('#sample_editable_1_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
            jQuery('#sample_editable_1_wrapper .dataTables_length select').select2({
                showSearchInput: false //hide search box with special css class
            });
            
        }
    };

} ();