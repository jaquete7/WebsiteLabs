const form = document.getElementById('form');
const identificacion = document.getElementById('txtIdentificacion');
const nombre = document.getElementById('txtNombreCompleto');
const telefono = document.getElementById('txtTelefono');
const provincia = document.getElementById('txtProvincia');
const canton = document.getElementById('txtCanton');
const distrito = document.getElementById('txtDistrito');
const descripcion = document.getElementById('txtDireccion');
const correo = document.getElementById('txtCorreo');
const password = document.getElementById('txtPassword');
const password2 = document.getElementById('txtConfirmarPassword');
const sltTipos = document.getElementById('txtTipoUsuario');
const tipoUsuario = document.getElementById('txtTipoUsuario');

function getDataFromAPI(dataId) {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/UsuariosAdmin/DevolverUser/" + dataId
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

$(document).on('change', '#txtTipoUsuario', function () {
        if (sltTipos.value == 'Colaborador') {
            $('#container-rol').css('display', 'block');
        } else {
            $('#container-rol').css('display', 'none');
        }

});

const setOptionsRoles = roles => {
    $.each(roles, function (i, rol) {
        $('#txtRol').append($('<option>', {
            value: rol.permisos,
            text: rol.nombre,
            id: rol.id
        }));
    });
    $("#txtRol").niceSelect('update');
    $("#txtRol").niceSelect('refresh');
}

const getRolesAdmin = () => {
    $.ajax({
        method: "GET",
        url: "https://nolimits-web.azurewebsites.net/api/Roles/ObtenerTodos?idLab=0",
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            setOptionsRoles(response);
        }
    });
}



function obtenerRol(data) {
    console.log(setTimeout(function () {
        console.log("Hola Mundo");
        $(`#txtTipoUsuario option[value='${data}']`).prop('selected', true);
        $(`#txtTipoUsuario option[value='${data}']`).trigger('change');
        $("#txtTipoUsuario").niceSelect('update');
        $("#txtTipoUsuario").niceSelect('refresh');
    }, 2000));

}


function fillFormFields(data) {
    $('#txtIdentificacion').val(data[0].id);
    $('#txtNombreCompleto').val(data[0].nombre);
    $('#txtTelefono').val(data[0].celular);
    $('#txtProvincia').val(data[0].provincia);
    $('#txtCanton').val(data[0].canton);
    $('#txtDistrito').val(data[0].distrito);
    $('#txtCorreo').val(data[0].email);
    $('#txtPassword').val(data[0].password);
    $('#txtConfirmarPassword').val(data[0].password);
    $('#txtTipoUsuario').val(data[0].rol);
    $('#txtDireccion').val(data[0].direccion);
    $(imagen).attr("src", data[0].ruta_foto);
    obtenerRol(data[0].rol);
    // y así sucesivamente
}


$(document).ready(function () {
    var dataId = sessionStorage.getItem("dataId");
    var data = getDataFromAPI(dataId); // Obtener los datos de la API
    fillFormFields(data); // Rellenar los campos del formulario
    getRolesAdmin();
});




//Valores de los inputs
//Evento Principal Iniciado al darle al Botón Registrarse.
//Función que marca los campos en rojo. Recibe un elemento y le incluye el borde rojo agregandole extensión a la class.
const setError = (element) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    inputControl.classList.add('error');
    inputControl.classList.remove('sucess');

}

//Función que desmarca los campos en rojo. Recibe un elemento y le borra el borde rojo agregandole extensión a la class.
const setSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    inputControl.classList.add('success');
    inputControl.classList.remove('error');

}




const validateInputs = () => {
    var validacionCorrecta = true;
    const identificacionValue = $('#txtIdentificacion').val();
    const nombreValue = $('#txtNombreCompleto').val();
    const telefonoValue = $('#txtTelefono').val();
    const provinciaValue = $('#txtProvincia').val();
    const cantonValue = $('#txtCanton').val();
    const distritoValue = $('#txtDistrito').val();
    const descripcionValue = $('#txtDireccion').val();
    const correoValue = $('#txtCorreo').val();
    const passwordValue = $('#txtPassword').val();
    const password2Value = $('#txtConfirmarPassword').val();
    const imagenValue = imagen.src;


    //De aquí para abajo valida input por input buscando errores.
    //Si algun input da error, la variable ValidacionCorrecta se vuelve false para no enviar los datos al Controller


    if (Number.isInteger(+identificacionValue) && +identificacionValue !== 0) {
        setSuccess(identificacion);

    } else {
        setError(identificacion);
        validacionCorrecta = false

    }

    if (nombreValue === '') {
        setError(nombre);
        validacionCorrecta = false
    } else {
        setSuccess(nombre);
    }

    if (telefonoValue === '') {
        setError(telefono);
        validacionCorrecta = false
    } else {
        setSuccess(telefono);
    }



    if (provinciaValue === '') {
        setError(provincia);
        validacionCorrecta = false
    } else {
        setSuccess(provincia);
    }

    if (cantonValue === '') {
        setError(canton);
        validacionCorrecta = false
    } else {
        setSuccess(canton);
    }

    if (distritoValue === '') {
        setError(distrito);
        validacionCorrecta = false
    } else {
        setSuccess(distrito);
    }

    if (descripcionValue === '') {
        setError(descripcion);
        validacionCorrecta = false
    } else {
        setSuccess(descripcion);
    }

    if (correoValue === '') {
        validacionCorrecta = false
        setError(correo);
    } else {
        setSuccess(correo);
    }

    if (passwordValue === '') {

        setError(password);
        validacionCorrecta = false
    } else if (passwordValue.length < 8 || passwordValue.length > 16) {
        console.log(passwordValue.length)
        setError(password);
        validacionCorrecta = false

    } else {
        setSuccess(password);
    }

    if (password2Value === '') {
        setError(password2);
        validacionCorrecta = false

    } else if (passwordValue != password2Value) {
        setError(password2)
        validacionCorrecta = false



    } else {
        setSuccess(password2);
    }

    if (validacionCorrecta) {
        var dataId = sessionStorage.getItem("dataId");
        var urlAPI = "https://nolimits-web.azurewebsites.net/api/UsuariosAdmin/EditarUsuario/" + dataId

        var idvalidacion;
        var permisosvalidacion;

        console.log(tipoUsuario);


        if (tipoUsuario.value == 'Proveedor') {
            idvalidacion = "1";
            permisosvalidacion = "ninguno";
        } else if (tipoUsuario.value == 'Paciente') {
            idvalidacion = "1";
            permisosvalidacion = "ninguno";
        } else {
            idvalidacion = $('#txtRol').children(':selected')[0].id;
            permisosvalidacion = $('#txtRol').children(':selected')[0].value;
        }

        var data = {
            nombre: $('#txtNombreCompleto').val(),
            celular: $('#txtTelefono').val(),
            provincia: $('#txtProvincia').val(),
            canton: $('#txtCanton').val(),
            distrito: $('#txtDistrito').val(),
            email: $('#txtCorreo').val(),
            password: $('#txtPassword').val(),
            direccion: $('#txtDireccion').val(),
            rol: tipoUsuario.value,
            ruta_foto: imagen.src,
            idrol: idvalidacion,
            permisos: permisosvalidacion,
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
                title: 'El usuario ha sido editado!',
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(
                function () {
                    window.location.href = 'https://nolimits.azurewebsites.net/Colaboradores/ListarColabAdmin';
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
        console.log("Aqui le enviamos al controlador los datos")
      

    } else Swal.fire({
        title: 'Error',
        text: 'Espacios faltantes / incorrectos',
        icon: 'error',
        confirmButtonText: 'Continuar'
    })
});
