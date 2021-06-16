$(document).ready(function () {
    $(".product-pic").on('click', function () {
        $('<input type="file">').on('change', function () {
            myfiles = this.files; //save selected files to the array
            var filename = this.files[0].name;
            console.log(myfiles); //show them on console
            var files = {
                BigImageSrc: filename,
                UploadImageSrc: null,
            };
            GetImg(files);
        }).click();

        
    });
    $(".fw-size-choose .sc-item label, .pdc-size-choose .sc-item label").on('click', function () {
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
        } else {
            $(this).addClass('active');
        }
    });
    function GetImg(files) {
        $.ajax({
            url: '/Product/ProductDetailsImg',
            type: 'POST',
            cache: false,
            async: true,
            dataType: "html",
            data: files,
            success: function (result) {
                $('#productDetailsImg').html(result);
                $('.BigImageSrc').val(files.BigImageSrc);
            },
            error: function (xhr) {
                console.log('error : ' + xhr.status + ' - '
                    + xhr.statusText + ' - ' + xhr.responseText);
            }
        });
    }

});