$(function () {

        GetProducts();
});
$(document).ready(function () {
    $("#pSort").on("change", function () {
            var filters = {
                itemsCount: $('#itemsCount').text(),
                itemsPerPage: 0,
                pSort: $('#pSort').val(),
                pCategory: $('.pCategory a.selected').attr('id'),
                pType: $('.pType a.selected').attr('id')
            };
            GetProducts(filters);
        });
    });
$(document).ready(function () {
    $('#btnLoadingMore').on('click', function (e) {
            var filters = {
                itemsCount: $('#itemsCount').text(),
                itemsPerPage: $('#itemsPerPage').val(),
                pSort: $('#pSort').val(),
                pCategory: $('.pCategory a.selected').attr('id'),
                pType: $('.pType a.selected').attr('id')
            };
            GetProducts(filters);
        });
    });
$(document).ready(function () {
        $('.pCategory a').on('click', function () {
            $('.pCategory a').removeClass('selected');
            $('.pType a').removeClass('selected');
            $(this).addClass('selected');
            var rangeSlider = $(".price-range");
            var filters = {
                itemsCount: 0,
                itemsPerPage: $('#itemsPerPage').val(),
                pSort: $('#pSort').val(),
                pCategory: $(this).attr('id'),
                pType: 0,
                minPrice: rangeSlider.slider("values", 0),
                maxPrice: rangeSlider.slider("values", 1)
            };
            GetProducts(filters);
        });
});
$(document).ready(function () {
        $('.pType a').on('click', function () {
            $('.pType a').removeClass('selected');
            $(this).addClass('selected');
            var filters = {
                itemsCount: 0,
                itemsPerPage: $('#itemsPerPage').val(),
                pSort: $('#pSort').val(),
                pCategory: $('.pCategory a.selected').attr('id'),
                pType: $(this).attr('id')
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
            data: filters,
            success: function (result) {
                $('#products').html(result);
                var products = {
                    newItemsCount: $("#newItemsCount").val(),
                    newProductsCount: $("#newProductsCount").val(),
                    newMinPrice: $("#newMinPrice").val(),
                    newMaxPrice: $("#newMaxPrice").val()
                }
                $("#itemsCount").text(products.newItemsCount);
                $("#productsCount").text(products.newProductsCount);
                $('.price-range').attr('data-min',products.newMinPrice);
                $('.price-range').attr('data-max', products.newMaxPrice);
            },
            error: function (xhr) {
                console.log('error : ' + xhr.status + ' - '
                    + xhr.statusText + ' - ' + xhr.responseText);
            }
        });
    }