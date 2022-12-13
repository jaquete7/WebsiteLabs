const getData = () => {
    $.ajax({
        method: "GET",
        url: "https://nolimits-web.azurewebsites.net/api/Sistema/ObtenerData",
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            $('#txtCurrentMembresia').val(response[0].membresia + '$');
        }
    });
}


$(document).ready(function () {
    getData();
})

$('#btnEditar').on('click', function () {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Sistema/EditarMembresia"
    var data = {
        membresia: $('#txtMembresia').val(),
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
            title: 'La Membresia ha sido editada!',
            showConfirmButton: false,
            timer: 1500
        })
        setTimeout(
            function () {
                window.location.href = 'https://nolimits.azurewebsites.net/Sistema/Membresia';
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



(() => {
    const forms = document.querySelectorAll('.needs-validation')

    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            event.preventDefault()
            event.stopPropagation()
            form.classList.add('was-validated')
        }, false)
    })
})()