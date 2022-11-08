//shorthand for document ready:
$(function() {
    console.log("ready!");
    $('.detailBody').hide();
});

$('.detail').on('click', function(e){
    var detailId = e.currentTarget.getAttribute("value");
    var detail = $("#" + detailId);
    if(detail.is(':hidden')){
        detail.show();
    }else{
        detail.hide();
    };
});