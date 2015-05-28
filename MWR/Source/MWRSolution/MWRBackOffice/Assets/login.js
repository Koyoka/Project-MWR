var LoginHelper = function () {
    var initHelper = function () {

    }

    var _recallLogin = function (el, netData, locData) {
        window.location.href = "/Pages/BO/BOIndex2.aspx";

    }

    return {
        init: function () {
            initHelper();

        },
        recallLogin: _recallLogin

    };
} ();