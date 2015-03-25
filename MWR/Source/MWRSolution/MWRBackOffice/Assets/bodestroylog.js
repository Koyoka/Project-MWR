var BODestroyLog = function () {

    var initHelper = function () {
        _registEvent();
        _initOTable();
    };

    var _registEvent = function(){
        $('.mw-txt-filterEdit').on('keydown',function(e){
//            
            if(e.keyCode ==13){
                e.preventDefault();
                var el = $('#mwFrmList');
                el.find('.mw-txt-filterValue').val(el.find('.mw-txt-filterEdit').val());
                el.setGroup('search',false);
                el.submit();
            }
        });

        $('.mw-btn-search').on('click',function(e){
            e.preventDefault();
            var el = $('#mwFrmList');
            el.find('.mw-txt-filterValue').val(el.find('.mw-txt-filterEdit').val());
            el.setGroup('search',false);
            el.submit();
        });

        $('.mw-btn-search-clear').on('click',function(e){
         e.preventDefault();
            var el = $('#mwFrmList');
            el.find('.mw-txt-filterValue').val('');
            el.setGroup('search',false);
            el.submit();
        });
    }

    var _subrecall = function (el, netData, locData) {
        _initOTable();
        _registEvent();
    };
    var _initOTable = function () {
         var oTable = $('#sample_1').dataTable( {
            "aoColumnDefs": [
                {"bSortable": false, "aTargets": [ 0 ] }
            ],   
            "bInfo": false, //开关，是否显示表格的一些信息
            "bPaginate": false, //开关，是否显示分页器
            "bLengthChange": false, //开关，是否显示每页大小的下拉框
            "bFilter": false, //开关，是否启用客户端过滤器
            "aaSorting": [[1, 'asc']],
                "aLengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });
        $('#sample_1').data('mw-oTable',oTable);
    };
    return {
        subrecall: _subrecall,
        init: function () {

            initHelper();
            jQuery('#sample_editable_1_wrapper .dataTables_filter input').addClass("form-control input-medium"); // modify table search input
            jQuery('#sample_editable_1_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
            jQuery('#sample_editable_1_wrapper .dataTables_length select').select2({
                showSearchInput: false //hide search box with special css class
            });
        }
    };
} ();