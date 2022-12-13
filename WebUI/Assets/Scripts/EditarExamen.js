const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));
const form = document.getElementById('form');
const nombreExamen1 = document.getElementById('nombre');
const precio1 = document.getElementById('precio');
const descrip = document.getElementById('descripcion');
const dato = document.getElementById('datos_evaluados');
const recomen = document.getElementById('recomendaciones');
const idExa = document.getElementById('idExamen');

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


// Función para obtener los datos de la API
function getDataFromAPI(dataId) {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Examen/DevolverExamen?idlab=" + idLab +"&idExam=" + dataId
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

    $('#nombre').val(data[0].nombre);
    $('#precio').val(data[0].precio);
    $('#descripcion').val(data[0].descripcion);
    $('#datos_evaluados').val(data[0].datos_evaluados);
    $('#idExamen').val(data[0].idExamen);
    $('#recomendaciones').val(data[0].recomendaciones);
    // y así sucesivamente
}

// Función para editar los datos de la API
$('#btnEditar').on('click', function () {
    var validacionCorrecta = true;

    const nombreExamenValue = nombreExamen1.value;
    const precio = precio1.value;
    const descripcion = descrip.value;
    const datos = dato.value;
    const recomendaciones = recomen.value;
    const idExam = idExa.value;

    if (nombreExamenValue === '') {
        setError(nombreExamen1);
        validacionCorrecta = false
    } else {
        setSuccess(nombreExamen1);
    }

    if (precio === '') {
        setError(precio1);
        validacionCorrecta = false
    } else {
        setSuccess(precio1);
    }

    if (descripcion === '') {
        setError(descrip);
        validacionCorrecta = false
    } else {
        setSuccess(descrip);
    }

    if (datos === '') {
        setError(dato);
        validacionCorrecta = false
    } else {
        setSuccess(dato);
    }

    if (recomendaciones === '') {
        setError(recomen);
        validacionCorrecta = false
    } else {
        setSuccess(recomen);
    }

    if (idExam === '') {
        setError(idExa);
        validacionCorrecta = false
    } else {
        setSuccess(idExa);
    }

    if (validacionCorrecta) {
        var dataId = sessionStorage.getItem("dataId");
        var urlAPI = "https://nolimits-web.azurewebsites.net/api/Examen/EditarExamen?idlab=" + idLab + "&idExam=" + dataId;

        var data = {
            nombre: $('#nombre').val(),
            precio: $('#precio').val(),
            descripcion: $('#descripcion').val(),
            datos_evaluados: $('#datos_evaluados').val(),
            idExamen: $('#idExamen').val(),
            recomendaciones: $('#recomendaciones').val()
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
                title: 'Tu examen ha sido editado!',
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(
                function () {
                    window.location.href = 'https://nolimits.azurewebsites.net/Examenes/Listar';
                }, 1600);

        }
        ).fail(function () {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Algo salió mal!',
            })
        });
    } else {
        Swal.fire({
            title: 'Oops...',
            text: 'Espacios faltantes / incorrectos',
            icon: 'error',
            confirmButtonText: 'Ok'
        })
    }
});

// Cuando la página esté lista
$(document).ready(function () {
    var dataId = sessionStorage.getItem("dataId");

    var data = getDataFromAPI(dataId); // Obtener los datos de la API
    fillFormFields(data); // Rellenar los campos del formulario
});





(() => {
    const forms = document.querySelectorAll('.needs-validation')

    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            event.preventDefault()
            event.stopPropagation()
            console.log('hello');
            form.classList.add('was-validated')
        }, false)
    })
})()