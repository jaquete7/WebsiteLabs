//Se obtienen los datos de cada input del form. 
//No se le aplica el .value aun ya que se necesita para las validaciones
const form = document.getElementById('form');
const nombre = document.getElementById('txtNombreCompleto');
const asunto = document.getElementById('txtAsunto');
const correo = document.getElementById('txtCorreo');
const telefono = document.getElementById('txtTelefono');
const descripcion = document.getElementById('txtDescripcion');



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
    const nombreValue = nombre.value;
    const asuntoValue = asunto.value;
    const correoValue = correo.value;
    const telefonoValue = telefono.value;
    const descripcionValue = descripcion.value;



    //De aquí para abajo valida input por input buscando errores.
    //Si algun input da error, la variable ValidacionCorrecta se vuelve false para no enviar los datos al Controller


    if (nombreValue === '') {
        setError(nombre);
        validacionCorrecta = false
    } else {
        setSuccess(nombre);
    }
    if (asuntoValue === '') {
        setError(asunto);
        validacionCorrecta = false
    } else {
        setSuccess(asunto);
    }
    if (correoValue === '') {
        validacionCorrecta = false
        setError(correo);
    } else {
        setSuccess(correo);
    }
    if (telefonoValue === '') {
        setError(telefono);
        validacionCorrecta = false
    } else {
        setSuccess(telefono);
    }
    if (descripcionValue === '') {
        setError(descripcion);
        validacionCorrecta = false
    } else {
        setSuccess(descripcion);
    }

    return validacionCorrecta;
};

form.addEventListener('submit', e => {
    e.preventDefault();

    var pruebaValidacion = validateInputs();
    if (pruebaValidacion) {
        
        Swal.fire({
            title: 'Éxito!',
            text: 'Mensaje enviado con éxito, pronto será contactado.',
            icon: 'success',
            confirmButtonText: 'Aceptar'

        
        })


    } else Swal.fire({
        title: 'Error',
        text: 'Espacios faltantes / incorrectos',
        icon: 'error',
        confirmButtonText: 'Aceptar'
    })
});
