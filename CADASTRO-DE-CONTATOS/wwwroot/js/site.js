$(document).ready(function () {
    $("#pesquisar").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#tabelacontatos tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});

$(function () {

    var elementoModalContato = $('#modal-contato');
    $('a[data-toggle="ajax-modal"]').click(function (event) {


        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);

        $.get(decodedUrl).done(function (data) {
            elementoModalContato.html("");
            elementoModalContato.html(data);
            elementoModalContato.find('.modal').modal('show');
        })


    })

})

$(document).ready(function () {
    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        });
    }, 2000);
});