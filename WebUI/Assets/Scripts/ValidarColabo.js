//Se obtienen los datos de cada input del form.
//No se le aplica el .value aun ya que se necesita para las validaciones
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
    getRolesAdmin();
})

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

//Función que valida los campos una vez se active el evento del botón Registrar.
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
        var data = {
            id: identificacionValue,
            nombre: nombreValue,
            celular: telefonoValue,
            provincia: provinciaValue,
            canton: cantonValue,
            distrito: distritoValue,
            direccion: descripcionValue,
            email: correoValue,
            password: passwordValue,
            ruta_foto: imagenValue,
            laboratorioColab: lab,
            id_custom_rol: $('#txtRol').children(':selected')[0].id,
            permisos: $('#txtRol').children(':selected')[0].value,
        }


        $.ajax({
            type: 'POST',
            url: 'https://nolimits-web.azurewebsites.net/api/Colaborador/Registrar',
            traditional: true,
            data: data,
            content: "application/json;",
            dataType: "json",
            success: function () {
            }
        });

    }
    return validacionCorrecta;

};

form.addEventListener('submit', e => {
    e.preventDefault();

    var pruebaValidacion = validateInputs();
    if (pruebaValidacion) {
        console.log("Aqui le enviamos al controlador los datos")
        Swal.fire({
            title: 'Éxito!',
            text: 'Registro Exitoso',
            icon: 'success',
            confirmButtonText: 'Continuar'

            //AQUÍ IRÁ EL LLAMADO AL CONTROLLER YA SEA PARA ENVIAR LOS PARAMETROS O MANDAR EL OBJETO PACIENTE YA CREADO.
        })

    } else Swal.fire({
        title: 'Error',
        text: 'Espacios faltantes / incorrectos',
        icon: 'error',
        confirmButtonText: 'Continuar'
    })
});

