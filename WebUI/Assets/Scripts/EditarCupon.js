const form = document.getElementById('form');
const nombreExamen = document.getElementById('txtNombreExamen');
const codigo = document.getElementById('txtCodigo');
const porcentaje_descuento = document.getElementById('txtPrctjDesc');
const fecha = document.getElementById('txtFecha');
const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));

function getDataFromAPI(dataId) {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Cupon/DevolverCupon?idCup=" + idLab + "&idLab=" + dataId
    console.log(urlAPI)
    var data;
    $.ajax({
        method: "GET",
        url: urlAPI,
        dataType: "json",
        async: false,
        success: function (response) {
            data = response;
        },
        error: function (xhr, status, error) {
            console.log(xhr.responseText);
        }
    });
    return data;

}

// Función para rellenar los campos del formulario con los datos obtenidos de la API
function fillFormFields(data) {
    console.log(data);
    $('#txtNombreExamen').val(data[0].nombre);
    $('#txtCodigo').val(data[0].codigo);
    $('#txtPrctjDesc').val(data[0].porcentaje_descuento);
    $('#txtFecha').val(data[0].fecha_caducidad);
    // y así sucesivamente
}

const setError = (element) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    inputControl.classList.add('error');
    inputControl.classList.remove('sucess');

}

const setSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    inputControl.classList.add('success');
    inputControl.classList.remove('error');

}

const validateInputs = () => {
    var validacionCorrecta = true;

    const nombreExamenValue = nombreExamen.value;
    const codigoValue = codigo.value;
    const fechaValue = fecha.value;
    const porcentaje_descuentoValue = porcentaje_descuento.value;


    if (nombreExamenValue === '') {
        setError(nombreExamen);
        validacionCorrecta = false
    } else {
        setSuccess(nombreExamen);
    }

    if (codigoValue === '') {
        setError(codigo);
        validacionCorrecta = false
    } else {
        setSuccess(codigo);
    }

    if (porcentaje_descuentoValue === '') {
        setError(porcentaje_descuento);
        validacionCorrecta = false
    } else {
        setSuccess(porcentaje_descuento);
    }

    if (fechaValue === '') {
        setError(fecha);
        validacionCorrecta = false
    } else {
        setSuccess(fecha);
    }

    if (validacionCorrecta) {
        var dataId = sessionStorage.getItem("dataId");
        var urlAPI = "https://nolimits-web.azurewebsites.net/api/Cupon/EditarCupon?idCup=" + dataId + "&idLab=" + idLab

        var data = {
            nombre: $('#txtNombreExamen').val(),
            codigo: $('#txtCodigo').val(),
            fecha_caducidad: $('#txtFecha').val(),
            porcentaje_descuento: $('#txtPrctjDesc').val()
        };
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
                title: 'Tu cupon ha sido editado!',
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(
                function () {
                    window.location.href = 'https://nolimits.azurewebsites.net/Cupones/ListarCupones';
                }, 1600);

        }
        ).fail(function () {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Algo salió mal!',
            })
        });

    }
    return validacionCorrecta;
}

form.addEventListener('submit', e => {
    e.preventDefault();

    var pruebaValidacion = validateInputs();
    if (pruebaValidacion) {
        console.log("Aqui le enviamos al controlador los datos");
    } else Swal.fire({
        title: 'Error',
        text: 'Espacios faltantes / incorrectos',
        icon: 'error',
        confirmButtonText: 'Ok'
    })
});

// Cuando la página esté lista
$(document).ready(function () {
    var dataId = sessionStorage.getItem("dataId");

    var data = getDataFromAPI(dataId); // Obtener los datos de la API
    fillFormFields(data); // Rellenar los campos del formulario
});