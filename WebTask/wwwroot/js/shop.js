$(function () {
    GetStudents();
});
$('#btnLoadingMore').on('click', function (e) {
    var filters = {
        itemsCount: $('#itemsCount').text(),
        itemsPerPage: $('#itemsPerPage').val()
    };
    GetStudents(filters);
});
function GetStudents(filters) {
    $.ajax({
        url: '/Shop/Products',
        type: 'POST',
        cache: false,
        async: true,
        dataType: "html",
        data: filters
    })
        .done(function (result) {
            $('#products').html(result);
        }).fail(function (xhr) {
            console.log('error : ' + xhr.status + ' - '
                + xhr.statusText + ' - ' + xhr.responseText);
        });
}