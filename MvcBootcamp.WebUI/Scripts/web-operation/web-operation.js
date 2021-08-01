$(document).ready(function () {
    $('#Create-post').click(function () {
        $('.profile-btn').css({ display: 'none' });
        $('.bio').css({ display: 'none' });
        $('.crtform').css({ display: 'block' });
    });
});

$(document).ready(function () {
    $('.btn-danger').click(function () {
        $('.profile-btn').css({ display: 'block' });
        $('.bio').css({ display: 'block' });
        $('.crtform').css({ display: 'none' });
    });
});


var btnUpload = $("#upload_file"),
    btnOuter = $(".button_outer");
btnUpload.on("change", function (e) {
    var ext = btnUpload.val().split('.').pop().toLowerCase();
    if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
        $(".error_msg").text("Lütfen, resim dosyası seçiniz...");
    } else {
        $(".error_msg").text("");
        btnOuter.addClass("file_uploading");
        setTimeout(function () {
            btnOuter.addClass("file_uploaded");
        }, 3000);
        var uploadedFile = URL.createObjectURL(e.target.files[0]);
        setTimeout(function () {
            $("#uploaded_view").append('<img src="' + uploadedFile + '" />').addClass("show");
            $('.btnUp').css({ display: 'block' });
        }, 3500);
    }
});
$(".file_remove").on("click", function (e) {
    $("#uploaded_view").removeClass("show");
    $("#uploaded_view").find("img").remove();
    btnOuter.removeClass("file_uploading");
    btnOuter.removeClass("file_uploaded");
    $('.btnUp').css({ display: 'none' });
});



//Remove Category alert
$(document).ready(function () {
    $(".btnRemoveCategory").click(function () {
        swal({
            title: "Silmek istediğinize emin misiniz?",
            text: "Bu işlem geri alınamaz!",
            icon: "warning",
            buttons: ["Vazgeç", "Evet,Sil"],
            dangerMode: true,

        })
            .then((willDelete) => {
                if (willDelete) {
                    var ID = $(this).attr('name');
                    //Tıklanan ilgili linkin name özelliğindeki ID değerini çekiyoruz.
                    // var x = $(this); seçilen satır değeri alınır.
                    $.ajax({
                        url: '/PanelCategory/Remove/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
                        type: 'POST',
                        dataType: 'json',
                        success: function (data) {
                            location.reload();
                        }

                    });
                    //  x.parent('td').parent('tr').remove(); silenen satır tablodan silinir.

                }
            });

    });
});

//status change Category
$(document).ready(function () {
    $('.btnStatusCategory').click(function (event) {
        var ID = $(this).attr("id");  //id değerini alıyoruz
        $.ajax({
            type: 'POST',
            url: '/PanelCategory/SetStatus/' + ID,  //işlem yaptığımız sayfayı belirtiyoruz
            dataType: 'json',
            success: function () {
                location.reload();
            },
            error: function () {
                alert('Hata oluştu.');
            }
        });


    });
});

$(document).ready(function () {
    $(".btnRemoveHeadline").click(function () {
        swal({
            title: "Silmek istediğinize emin misiniz?",
            text: "Bu işlem geri alınamaz!",
            icon: "warning",
            buttons: ["Vazgeç", "Evet,Sil"],
            dangerMode: true,

        })
            .then((willDelete) => {
                if (willDelete) {
                    var ID = $(this).attr('name');
                    //Tıklanan ilgili linkin name özelliğindeki ID değerini çekiyoruz.
                    // var x = $(this); seçilen satır değeri alınır.
                    $.ajax({
                        url: '/PanelHeadline/Remove/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
                        type: 'POST',
                        dataType: 'json',
                        success: function (data) {
                            location.reload();
                        }

                    });
                    //  x.parent('td').parent('tr').remove(); silenen satır tablodan silinir.

                }
            });

    });
});



//status change Headline
$(document).ready(function () {
    $('.btnStatusHeadline').click(function (event) {
        var ID = $(this).attr("id");  //id değerini alıyoruz
        $.ajax({
            type: 'POST',
            url: '/PanelHeadline/SetStatus/' + ID,  //işlem yaptığımız sayfayı belirtiyoruz
            dataType: 'json',
            success: function () {
                location.reload();
            },
            error: function () {
                alert('Hata oluştu.');
            }
        });


    });
});

//status change Author
$(document).ready(function () {
    $('.btnStatusAuthor').click(function (event) {
        var ID = $(this).attr("id");  //id değerini alıyoruz
        $.ajax({
            type: 'POST',
            url: '/PanelAuthor/SetStatus/' + ID,  //işlem yaptığımız sayfayı belirtiyoruz
            dataType: 'json',
            success: function () {
                location.reload();
            },
            error: function () {
                alert('Hata oluştu.');
            }
        });


    });
});

// Checkbox selected
// select single
$(document).ready(function () {
    $('.SelectItem').click(function () {
        if ($('.SelectItem').prop("checked"))
            $('#RemoveSelected').css({ display: 'block' });
        else
            $('#RemoveSelected').css({ display: 'none' });
    });
});

//select all
$(document).ready(function () {
    $('#SelectAll').click(function () {  //on click
        if (this.checked) { // check select status
            $(":checkbox").prop("checked", true);
            $('#RemoveSelected').css({ display: 'block' });
        } else {
            $(":checkbox").prop("checked", false);
            $('#RemoveSelected').css({ display: 'none' });
        }
    });

});


