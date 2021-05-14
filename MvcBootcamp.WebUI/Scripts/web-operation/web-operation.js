//sweet alert
$(document).ready(function () {
    $(".btnRemove").click(function () {
        swal({
            title: "Silmek istediğinize emin misiniz?",
            text: "Bu işlem geri alınamaz!",
            icon: "warning",
            buttons: ["Vazgeç", true],
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    var ID = $(this).attr('name');
                    //Tıklanan ilgili linkin name özelliğindeki ID değerini çekiyoruz.
                    var x = $(this);
                    $.ajax({
                        url: '/PanelCategory/Remove/' + ID,//Ajax ile tetiklenecek ilgili adresi belirliyoruz.
                        type: 'POST',
                        dataType: 'json',
                        success: function (data) {
                            swal({
                                text: data,
                                icon: "success",
                                button: "Tamam",
                            });

                        }

                    });
                    x.parent('td').parent('tr').remove();
                }
            });

    });
});

//status change
$(document).ready(function () {
    $('.btnStatus').click(function (event) {
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