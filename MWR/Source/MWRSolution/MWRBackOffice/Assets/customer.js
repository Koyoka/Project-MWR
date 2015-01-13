
var MW_AppHelper = {

    SetCurMenu: function (menuBarId,menuSubBarId) {
        $("#" + menuBarId).addClass("active");
        if(menuSubBarId != "undefined")
            $("#" + menuSubBarId).addClass("active");
    },
    set: function () { 
        window.alert(2)
    }

}
