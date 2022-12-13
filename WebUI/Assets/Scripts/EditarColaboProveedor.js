const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));
const form = document.getElementById('form');
const identificacion = document.getElementById('txtIdentificacion');
const nombre = document.getElementById('txtNombreCompleto');
const telefono = document.getElementById('txtTelefono');
const provincia = document.getElementById('txtProvincia');
const canton = document.getElementById('txtCanton');
const distrito = document.getElementById('txtDistrito');
const descripcion = document.getElementById('txtDescripcion');
const correo = document.getElementById('txtCorreo');
const password = document.getElementById('txtPassword');
const password2 = document.getElementById('txtConfirmarPassword');
const lab = sessionStorage.getItem('currentLabID');

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

function obtenerRol(id) {
    console.log(setTimeout(function () {
        console.log(id);
        $(`#txtRol option[id='${id}']`).prop('selected', true);
        $(`#txtRol option[id='${id}']`).trigger('change');
        $("#txtRol").niceSelect('update');
        $("#txtRol").niceSelect('refresh');
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
    $('#txtDescripcion').val(data[0].direccion);
    $(imagen).attr("src", data[0].ruta_foto);
    obtenerRol(data[0].idrol);
    // y así sucesivamente
}

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
        url: "https://nolimits-web.azurewebsites.net/api/Roles/ObtenerTodos?idLab=" + idLab,
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            console.log(response);
            setOptionsRoles(response);
        }
    });
}

$(document).ready(function () {
    var dataId = sessionStorage.getItem("dataId");
    var data = getDataFromAPI(dataId); // Obtener los datos de la API
    fillFormFields(data); // Rellenar los campos del formulario
    getRolesAdmin();
})

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
    const identificacionValue = identificacion.value;
    const nombreValue = nombre.value;
    const telefonoValue = telefono.value;
    const provinciaValue = provincia.value;
    const cantonValue = canton.value;
    const distritoValue = distrito.value;
    const descripcionValue = descripcion.value;
    const correoValue = correo.value;
    const passwordValue = password.value;
    const password2Value = password2.value;
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



        var data = {
            nombre: nombreValue,
            celular: telefonoValue,
            provincia: provinciaValue,
            canton: cantonValue,
            distrito: distritoValue,
            direccion: descripcionValue,
            email: correoValue,
            password: passwordValue,
            ruta_foto: imagenValue,
            rol: "Colaborador",
            idrol: $('#txtRol').children(':selected')[0].id,
            permisos: $('#txtRol').children(':selected')[0].value,
        }


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
                title: 'El Colaborador ha sido editado!',
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(
                function () {
                    window.location.href = 'https://nolimits.azurewebsites.net/Colaboradores/ListarColabProveedor';
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

};

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