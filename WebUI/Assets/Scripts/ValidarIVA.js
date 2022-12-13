const getData = () => {
    $.ajax({
        method: "GET",
        url: "https://nolimits-web.azurewebsites.net/api/Sistema/ObtenerData",
        contentType: "application/json:charset=utf-8",
        success: function (response) {

            //let ivaResponse = response;
            //let ivaFinal = Math.round(ivaResponse * 10) / 10
            $('#txtCurrentIVA').val(response[0].iva * 100 + '%');
            console.log(response[0].iva);
        }
    });
}

$(document).ready(function () {
    getData();
})


$('#btnEditar').on('click', function () {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Sistema/EditarIva"
    var data = {
        Iva: $('#txtIva').val() / 100,
    };
    console.log(data);
    $.ajax({
        Headers: {
            'Accept': "application/json",
            'Content-Type': "application/json"
        },
        method: "PUT",
        url: urlAPI,
        contentType: "application/json",
        data: JSON.stringify(data),
        hasContent: true
    }).done(function () {
        Swal.fire({
            icon: 'success',
            title: 'El Iva ha sido editado!',
            showConfirmButton: false,
            timer: 1500
        })
        setTimeout(
            function () {
                window.location.href = 'https://nolimits.azurewebsites.net/Sistema/Iva';
            }, 1600);

    }
    ).fail(function () {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Algo salió mal!',
        })
    });
});


