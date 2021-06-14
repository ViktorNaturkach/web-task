$(document).ready(function () {
    GetProducts();
    $("#pSort").on("change", function () {
        var filters = {
            itemsCount: $('#itemsCount').text(),
            itemsPerPage: 0,
            pSort: $('#pSort').val(),
            pCategory: $('.pCategory a.selected').attr('id'),
            pType: $('.pType a.selected').attr('id'),
         };
        GetProducts(filters);
    });
    $("#itemsPerPage").on("change", function () {
        var filters = {
            itemsCount: 0,
            itemsPerPage: $('#itemsPerPage').val(),
            pSort: $('#pSort').val(),
            pCategory: $('.pCategory a.selected').attr('id'),
            pType: $('.pType a.selected').attr('id'),
        };
        GetProducts(filters);
    });
    $('#btnLoadingMore').on('click', function (e) {
        var filters = {
            itemsCount: $('#itemsCount').text(),
            itemsPerPage: $('#itemsPerPage').val(),
            pSort: $('#pSort').val(),
            pCategory: $('.pCategory a.selected').attr('id'),
            pType: $('.pType a.selected').attr('id'),
        };
            GetProducts(filters);
        });
    $('.pCategory a').on('click', function () {
        $('.pCategory a').removeClass('selected');
        $('.pType a').removeClass('selected');
        $(".fw-size-choose .sc-item label, .pd-size-choose .sc-item label").removeClass('active');
        $(this).addClass('selected');
        var filters = {
                itemsCount: 0,
                itemsPerPage: $('#itemsPerPage').val(),
                pSort: $('#pSort').val(),
                pCategory: $(this).attr('id'),
                pType: 0,
         };
        GetProducts(filters);
    });
    $('.pType a').on('click', function () {
        $('.pType a').removeClass('selected');
        $(".fw-size-choose .sc-item label, .pd-size-choose .sc-item label").removeClass('active');
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
    $('a.filter-btn').button().click(function (e) {
        $(".fw-size-choose .sc-item label, .pd-size-choose .sc-item label").removeClass('active');
        var filters = {
            itemsCount: 0,
            itemsPerPage: $('#itemsPerPage').val(),
            pSort: $('#pSort').val(),
            pCategory: $('.pCategory a.selected').attr('id'),
            pType: $(this).attr('id'),
            minPrice: $(".price-range").slider('values', 0),
            maxPrice: $(".price-range").slider('values', 1)
        };
        GetProducts(filters);
    })
    $(".fw-size-choose .sc-item label, .pd-size-choose .sc-item label").on('click', function () {
        var filters = {
            itemsCount: 0,
            itemsPerPage: $('#itemsPerPage').val(),
            pSort: $('#pSort').val(),
            pCategory: $('.pCategory a.selected').attr('id'),
            pType: $(this).attr('id'),
            minPrice: $(".price-range").slider('values', 0),
            maxPrice: $(".price-range").slider('values', 1),
            pSize: $(this).attr('for')
        };
        GetProducts(filters);
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
                }
                $("#itemsCount").text(products.newItemsCount);
                $("#productsCount").text(products.newProductsCount);
            },
            error: function (xhr) {
                console.log('error : ' + xhr.status + ' - '
                    + xhr.statusText + ' - ' + xhr.responseText);
            }
        });
        }
 

});