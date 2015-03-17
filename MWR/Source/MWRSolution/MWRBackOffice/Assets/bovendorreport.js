var VendorReport = function () {

    var initTable1 = function() {

        /* Formatting function for row details */
        function fnFormatDetails ( oTable, nTr )
        {
            var aData = oTable.fnGetData( nTr );
            var sOut = '<table>';
            sOut += '<tr><td>Platform(s):</td><td>'+aData[2]+'</td></tr>';
            sOut += '<tr><td>Engine version:</td><td>'+aData[3]+'</td></tr>';
            sOut += '<tr><td>CSS grade:</td><td>'+aData[4]+'</td></tr>';
            sOut += '<tr><td>Others:</td><td>Could provide a link here</td></tr>';
            sOut += '</table>';
             
            return sOut;
        }

        /*
         * Insert a 'details' column to the table
         */
        var nCloneTh = document.createElement( 'th' );
        var nCloneTd = document.createElement( 'td' );
        nCloneTd.innerHTML = '<span class="row-details row-details-close"></span>';
         
        $('#sample_1 thead tr').each( function () {
            this.insertBefore( nCloneTh, this.childNodes[0] );
        } );
         
        $('#sample_1 tbody tr').each( function () {
            this.insertBefore(  nCloneTd.cloneNode( true ), this.childNodes[0] );
        } );
         
        /*
         * Initialize DataTables, with no sorting on the 'details' column
         */
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

        jQuery('#sample_1_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
        jQuery('#sample_1_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
        jQuery('#sample_1_wrapper .dataTables_length select').select2(); // initialize select2 dropdown
         
        /* Add event listener for opening and closing details
         * Note that the indicator for showing which row is open is not controlled by DataTables,
         * rather it is done here
         */
        $('#sample_1').on('click', ' tbody td .row-details', function () {
            var nTr = $(this).parents('tr')[0];
            if ( oTable.fnIsOpen(nTr) )
            {
                /* This row is already open - close it */
                $(this).addClass("row-details-close").removeClass("row-details-open");
                oTable.fnClose( nTr );
            }
            else
            {
               
                var url = "/Pages/BO/Report/VendorReport.aspx";
                var method = "AjaxGetInvTrack";
                var data = {};
                data["invRecordId"] = $(nTr).find('.mw-invRecodId').val();
                
//                App.blockUI($(nTr), false);
                var $this = this;
                $.AjaxPJson(url, method, data, function (d) {
//                    window.alert(d.Value.length);
//                    return;
                     var sOut = '<table>';
                        sOut += '<tr>';
                        sOut += '<td>操作员</td>';
                        sOut += '<td>操作终端</td>';
                        sOut += '<td>操作类型</td>';
                        sOut += '<td>操作时间</td>';
                        sOut += '<td>操作提交重量</td>';
                        sOut += '<td>操作实际重量</td>';
                        sOut += '<td>实际重量差值</td>';
                        sOut += '<td>是否审核</td>';
                        sOut += '</tr>';
                     for(var i = 0;i<d.Value.length;i++)
                     {
                        var item = d.Value[i];
                        sOut += '<tr>';
                        sOut += '<td>'+item.EmpyName+'</td>';
                        sOut += '<td>'+item.WSCode+'</td>';
                        sOut += '<td>'+item.TxnType+'</td>';
                        sOut += '<td >'+item.EntryDate+'</td>';
                        sOut += '<td align="right">'+item.SubWeight+'</td>';
                        sOut += '<td align="right">'+item.TxnWeight+'</td>';
                        sOut += '<td align="right">'+item.DiffWeight+'</td>';
                        sOut += '<td align="right">'+(item.HasAuthorize?"是":"")+'</td>';
                        sOut += '</tr>';
                     }
                    sOut += '</table>'; 
                    $($this).addClass("row-details-open").removeClass("row-details-close");
                    oTable.fnOpen( nTr, sOut, 'details' );
//                    App.unblockUI($(nTr));
                }, function (r) {
                    Modal.alert('[' + r + ']');
                });
                return;
                /* Open this row */                
                $(this).addClass("row-details-open").removeClass("row-details-close");
                oTable.fnOpen( nTr, fnFormatDetails(oTable, nTr), 'details' );
            }
        });
    }

    var initTable2 = function() {
        var oTable = $('#sample_2').dataTable( {           
            "aoColumnDefs": [
                { "aTargets": [ 0 ] }
            ],
            "aaSorting": [[1, 'asc']],
             "aLengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "All"] // change per page values here
            ],
            // set the initial value
            "iDisplayLength": 10,
        });

        jQuery('#sample_2_wrapper .dataTables_filter input').addClass("form-control input-small"); // modify table search input
        jQuery('#sample_2_wrapper .dataTables_length select').addClass("form-control input-small"); // modify table per page dropdown
        jQuery('#sample_2_wrapper .dataTables_length select').select2(); // initialize select2 dropdown

        $('#sample_2_column_toggler input[type="checkbox"]').change(function(){
            /* Get the DataTables object again - this is not a recreation, just a get of the object */
            var iCol = parseInt($(this).attr("data-column"));
            var bVis = oTable.fnSettings().aoColumns[iCol].bVisible;
           

            oTable.fnSetColumnVis(iCol, (bVis ? false : true));
        });
    }

    return {

        //main function to initiate the module
        init: function () {
            
            if (!jQuery().dataTable) {
                return;
            }

            initTable1();
            initTable2();
        }

    };

}();