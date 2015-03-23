var BOBDWaste = function () {
    var initHelper = function () {

    }

    var _initFrmValid = function () {
        var error1 = $('.alert-danger');
        $('#mwFrmList').validate({
            errorElement: 'span', //default input error message container
            errorClass: 'help-block', // default input error message class
            focusInvalid: true, // do not focus the last invalid input
            ignore: "",
            rules: {
                wasteCode: {
                    required: true
                },
                waste: {
                    required: true
                }
            },
            messages: {
                wasteCode: "请输入废品类型编号",
                waste: "请输入废品类型名称"
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

            "bInfo": false, //开关，是否显示表格的一些信息
            "bPaginate": false, //开关，是否显示分页器
            "bLengthChange": false, //开关，是否显示每页大小的下拉框
            "bFilter": false, //开关，是否启用客户端过滤器
            "sPaginationType": "bootstrap",
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
                    }

                ]
        });
        $('#sample_editable_1').data('mw-oTable', ot);
    };

    return {
        subrecall: _subrecall,
        initOTable: _initOTable,
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