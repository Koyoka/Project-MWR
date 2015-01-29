var InvAuthHelper = function () {

    var initHelper = function () {
        gl.wgt.set('mw-showauthform', {

            init: function () {
                this.element.on("click", this.show.bind(this));
            },

            show: function (e) {
                e.preventDefault();
                var ctrl = this.element.attr("data-wgt-showauthformid");
                var txnnum = $("." + ctrl + " .txnnum").text().trim();
                var cratecode = $("." + ctrl + " .cratecode").text().trim();
                var subwscode = $("." + ctrl + " .subwscode").text().trim();
                var subempyname = $("." + ctrl + " .subempyname").text().trim();
                var subweight = $("." + ctrl + " .subweight").text().trim();
                var txnweight = $("." + ctrl + " .txnweight").text().trim();
                var entrydate = $("." + ctrl + " .entrydate").text().trim();
                var txntype = $("." + ctrl + " .txntype").text().trim();
                var diffweight = $("." + ctrl + " .diffweight").val();

                $("#txnnum").val(txnnum);
                $("#cratecode").val(cratecode);
                $("#subwscode").val(subwscode);
                $("#subempyname").val(subempyname);
                $("#subweight").val(subweight);
                $("#txnweight").val(txnweight);
//                $("#txntype").val(txntype);
                $("#diffweight").val(diffweight);


//                window.alert(txnnum + " " + cratecode);
            }
        });
    };


    return {
        init: function () {
            initHelper();
        }
    };
} ();