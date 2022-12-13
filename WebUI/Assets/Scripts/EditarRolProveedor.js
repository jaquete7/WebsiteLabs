
const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));

function getPermisos() {
    let permisosSelected = [];
    $("input:radio:checked").each(function () {
        permisosSelected += $(this).attr("id") + ',';
    });
    return permisosSelected;
}

// Función para obtener los datos de la API
function getDataFromAPI(dataId) {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Roles/DevolverRol?idlab=" + idLab + "&idrol=" + dataId
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

    let arrayResponse = data[0];
    let permisos = arrayResponse['permisos'];
    let permisosArray = permisos.split(',');
    $('#nombre-rol').val(data[0].nombre);

    $.each(permisosArray, function (index, item) {
        // Comprobar si el elemento está presente
        console.log(item);
        if (item) {
            // Establecer el atributo "checked" en los inputs de tipo radio
            $('.form-check-input[id="' + item + '"]').attr('checked', true);
        }
    });
}

// Función para editar los datos de la API
$('#btnEditar').on('click', function () {
    var dataId = sessionStorage.getItem("dataId");
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Roles/EditarRol?idlab=" + idLab + "&idrol=" + dataId
    let permisos = getPermisos();
    let nombre = $('#nombre-rol').val();
    const forms = document.querySelectorAll('.needs-validation')

 

    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            event.preventDefault()
            event.stopPropagation()
            if (!form.checkValidity()) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: '¡Espacios requeridos!'
                })
            } else {
                var data = {
                    nombre: nombre,
                    permisos: permisos,
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
                        title: 'El Rol ha sido editado!',
                        showConfirmButton: false,
                        timer: 1500
                    })
                    setTimeout(
                        function () {
                            window.location.href = 'https://nolimits.azurewebsites.net/Roles/ListarRolesProveedor';
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
            form.classList.add('was-validated')
        }, false)
    })

   
});

// Cuando la página esté lista
$(document).ready(function () {
    var dataId = sessionStorage.getItem("dataId");

    var data = getDataFromAPI(dataId); // Obtener los datos de la API
    fillFormFields(data); // Rellenar los campos del formulario
});




