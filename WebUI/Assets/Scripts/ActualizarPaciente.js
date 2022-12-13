const user = JSON.parse(sessionStorage.getItem('userData'));

const llenarFormulario = () => {

    const user = JSON.parse(sessionStorage.getItem('userData'));

    if (user != null) {
      
        document.getElementById('txtIdentificacion').value = user.id;
        document.getElementById('txtNombreCompleto').value = user.nombre;
        document.getElementById('txtProvincia').value = user.provincia;
        document.getElementById('txtCanton').value = user.canton;
        document.getElementById('txtDistrito').value = user.distrito;
        document.getElementById('txtDescripcion').value = user.direccion;
        document.getElementById('txtTelefono').value = user.celular;
        document.getElementById('txtCorreo').value = user.email;
        document.getElementById('txtPassword').value = user.password;
        document.getElementById('txtConfirmarPassword').value = user.password;
        document.getElementById('user-photo').value = user.ruta_foto;
    }

}


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


//const file = document.getElementById('oFile');



//Evento Principal Iniciado al darle al Botón Registrarse.
form.addEventListener('submit', e => {
    e.preventDefault();

    var pruebaValidacion = validateInputs();
    if (pruebaValidacion) {
        console.log("Aqui le enviamos al controlador los datos")
        Swal.fire({
            title: 'Éxito!',
            text: 'Actualización Exitosa',
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
    /** if (identificacionValue === '') {
         setError(identificacion);
         validacionCorrecta = false
     } else {
         setSuccess(identificacion);
 
     }
     */

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

    //return validacionCorrecta;


    //LLamada Ajax a Controller.

    if (validacionCorrecta) {
        const user = JSON.parse(sessionStorage.getItem('userData'));
        const id = user.id;

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
            rol: user.rol,
            idrol: "1",
            permisos: "TODOS",
        }


        $.ajax({
            type: 'PUT',
            url: "https://nolimits-web.azurewebsites.net/api/UsuariosAdmin/EditarUsuario/" + id ,
            traditional: true,
            data: data,
            content: "application/json;",
            dataType: "json",
            success: function () {
            }
        });

        let updateUserSession = {
            canton: canton.value,
            celular: telefono.value,
            direccion: descripcion.value,
            distrito: distrito.value,
            email: correo.value,
            email_pagos: correo.value,
            estado: user.estado,
            fecha_registro: user.fecha_registro,
            id: identificacion.value,
            id_custom_rol: "1",
            laboratorioColab: user.laboratorioColab,
            nombre: nombre.value,
            password: password.value,
            permisos: "TODOS",
            provincia: provincia.value,
            rol: user.rol,
            ruta_foto: imagen.src,
            token_recovery: user.token_recovery
        }

        sessionStorage.setItem("userData", JSON.stringify(updateUserSession));


    }
    return validacionCorrecta;
};

$(document).ready(function () {
    llenarFormulario();
})
