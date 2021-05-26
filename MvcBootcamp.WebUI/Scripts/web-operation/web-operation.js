//Remove alert
$(document).ready(function () {
    $(".btnRemove").click(function () {
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


