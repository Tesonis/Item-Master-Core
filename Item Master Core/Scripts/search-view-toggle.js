$(document).ready(function () {
    $("#listview").hide();

});

$(".grid-view-btn").click(function () {
    if ($(".grid-view-btn").hasClass("btn-outline-secondary")) {
        $("#gridview").toggle();
        $("#listview").toggle();
        $(".grid-view-btn").removeClass("btn-outline-secondary");
        $(".grid-view-btn").addClass("btn-secondary");
        $(".list-view-btn").removeClass("btn-secondary");
        $(".list-view-btn").addClass("btn-outline-secondary");
    }  
});

$(".list-view-btn").click(function () {
    if ($(".list-view-btn").hasClass("btn-outline-secondary")) {
        $("#listview").toggle();
        $("#gridview").toggle();
        $(".list-view-btn").removeClass("btn-outline-secondary");
        $(".list-view-btn").addClass("btn-secondary");
        $(".grid-view-btn").removeClass("btn-secondary");
        $(".grid-view-btn").addClass("btn-outline-secondary");
    }
});

