$(function () {
    GetProducts();
});
$(document).ready(function () {
    $("#pSort").on("change", function () {
        var filters = {
            itemsCount: $('#itemsCount').text(),
            itemsPerPage: 0,
            pSort: $('#pSort').val()
        };
        GetProducts(filters);
    });
});
$(document).ready(function () {
    $('#btnLoadingMore').on('click', function (e) {
        var filters = {
            itemsCount: $('#itemsCount').text(),
            itemsPerPage: $('#itemsPerPage').val(),
            pSort: $('#pSort').val()
        };
        GetProducts(filters);
    });
});
function GetProducts(filters) {
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
            var products = {
                newItemsCount: $("#newItemsCount").val(),
                newProductsCount: $("#newProductsCount").val()
            }
            $("#itemsCount").text(products.newItemsCount);
            $("#productsCount").text(products.newProductsCount);
        }).fail(function (xhr) {
            console.log('error : ' + xhr.status + ' - '
                + xhr.statusText + ' - ' + xhr.responseText);
        });
}