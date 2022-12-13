$('input[type="radio"]').on("mousedown", function () {
    if (this.checked) {
        $(this).one("click", function () {
            this.checked = false;
        });
    }
});

const getPermisosSelected = () => {
    let permisosSelected = [];
    $("input:radio:checked").each(function () {
        permisosSelected += $(this).attr("id") + ',';
    });
    return permisosSelected;
}

const generarID = () => Math.floor(100000 + Math.random() * 900000);

const getCurrentLab = () => {
    const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));
    if (idLab != null)
        return idLab

    return 0
}

function getDataFromAPI(dataId) {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Roles/DevolverRol?idlab=" + 0 + "&idrol=" + dataId
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

(() => {
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

                $('#guardar-rol').text('Procesando...');

                let permisos = getPermisosSelected();
                let nombre = $('#nombre-rol').val();

                let data = {
                    nombre: nombre,
                    permisos: permisos,
                }

                var ID = sessionStorage.getItem("dataId");
                var urlAPI = "https://nolimits-web.azurewebsites.net/api/Roles/EditarRol?idlab=" + 0 + "&idrol=" + ID
                $.ajax({
                    type: 'PUT',
                    url: urlAPI,
                    traditional: true,
                    data: data,
                    content: "application/json;",
                    dataType: "json",
                    success: function () {
                        Swal.fire({
                            icon: 'success',
                            title: 'El Rol ha sido editado!',
                            showConfirmButton: false,
                            timer: 1500
                        })
                        $('#guardar-rol').text('Editar rol');
                        setTimeout(
                            function () {
                                window.location.href = 'https://nolimits.azurewebsites.net/Roles/ListarRolesAdmin';
                            }, 1600);                   
                    }
                });

            }
            form.classList.add('was-validated')
        }, false)
    })
})()



// Cuando la página esté lista
$(document).ready(function () {
    var dataId = sessionStorage.getItem("dataId");
    var data = getDataFromAPI(dataId); // Obtener los datos de la API
    fillFormFields(data); // Rellenar los campos del formulario
});
