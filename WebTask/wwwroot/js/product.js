$(document).ready(function () {
    $(".fw-size-choose .sc-item label, .pdc-size-choose .sc-item label").on('click', function () {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
        } else {
            $(this).addClass('active');
        }
    });
});