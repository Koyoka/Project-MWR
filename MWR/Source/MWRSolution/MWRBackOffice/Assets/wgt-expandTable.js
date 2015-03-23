var WGTExpandTable = function () {

    var initHelper = function () {
        gl.wgt.set('mw-expandtable-ajaxchild', {
            oTable:null,
            init: function () {

                if (!jQuery().dataTable) {
                    return;
                }
//                oTable = this.element.data('mw-oTable');
//                window.alert(oTable)
//                if (!oTable) {
//                    return;
//                }
                  
//                   var oTable = $('#sample_1').dataTable( {
//                             "bAutoWith": false,      
//                            "bInfo": false, //开关，是否显示表格的一些信息
//                            "bPaginate": false, //开关，是否显示分页器
//                            "bLengthChange": false, //开关，是否显示每页大小的下拉框
//                            "bFilter": false, //开关，是否启用客户端过滤器
//                            "aaSorting": [[1, 'asc']],
//                                "aLengthMenu": [
//                                [5, 15, 20, -1],
//                                [5, 15, 20, "All"] // change per page values here
//                            ],
//                            // set the initial value
//                            "iDisplayLength": 10,
//                        });

                var nCloneTh = document.createElement('th');
                var nCloneTd = document.createElement('td');
                $(nCloneTd).attr('width','20')
                nCloneTd.innerHTML = '<span class="row-details row-details-close"></span>';

                $('thead tr', this.element).each(function () {
                    this.insertBefore(nCloneTh, this.childNodes[0]);
                });

                $('tbody tr', this.element).each(function () {
                    this.insertBefore(nCloneTd.cloneNode(true), this.childNodes[0]);
                });
               
       
                //                jQuery('#sample_1_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
                //                jQuery('#sample_1_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
                //                jQuery('#sample_1_wrapper .dataTables_length select').select2(); // initialize select2 dropdown
                //         

                this.element.on('click', ' tbody td .row-details', function () {

                    if (!oTable) {
                        return;
                    }
                    var nTr = $(this).parents('tr')[0];
                    if (oTable.fnIsOpen(nTr)) {
                        /* This row is already open - close it */
                        $(this).addClass("row-details-close").removeClass("row-details-open");
                        oTable.fnClose(nTr);
                    } else {
                        $($this).addClass("row-details-open").removeClass("row-details-close");
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