//Se obtienen los datos de cada input del form. 
//No se le aplica el .value aun ya que se necesita para las validaciones
//const form = document.getElementById('form');

const nombre = document.getElementById('txtNombre');

const provincia = document.getElementById('txtProvincia');
const canton = document.getElementById('txtCanton');
const distrito = document.getElementById('txtDistrito');
const direccion = document.getElementById('txtDireccion');
const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));


//Evento Principal Iniciado al darle al Botón Registrarse.
form.addEventListener('submit', e => {
    e.preventDefault();

    var pruebaValidacion = validateInputs();
    if (pruebaValidacion) {
        console.log("Aqui le enviamos al controlador los datos")
        Swal.fire({
            title: 'Éxito!',
            text: 'Registro Exitoso',
            icon: 'success',
            confirmButtonText: 'Ok'

      
        })


    } else Swal.fire({
        title: 'Error',
        text: 'Espacios faltantes / incorrectos',
        icon: 'error',
        confirmButtonText: 'Ok'
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
   
    const nombreValue = nombre.value;
    const provinciaValue = provincia.value;
    const cantonValue = canton.value;
    const distritoValue = distrito.value;
    const direccionValue = direccion.value;
    

    //De aquí para abajo valida input por input buscando errores.
    //Si algun input da error, la variable ValidacionCorrecta se vuelve false para no enviar los datos al Controller


    

    if (nombreValue === '') {
        setError(nombre);
        validacionCorrecta = false
    } else {
        setSuccess(nombre);
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

    if (direccionValue === '') {
        setError(direccion);
        validacionCorrecta = false
    } else {
        setSuccess(direccion);
    }


    if (validacionCorrecta) {
        var data = {  
            id_laboratorio: idLab,
            nombre: nombreValue,
            provincia: provinciaValue,
            canton: cantonValue,
            distrito: distritoValue,
            direccion: direccionValue,
           
        }


        $.ajax({
            type: 'POST',
            url: 'https://nolimits-web.azurewebsites.net/api/Sede/Registrar',
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




