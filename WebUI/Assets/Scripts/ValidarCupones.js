const form = document.getElementById('form');
const nombreExamen = document.getElementById('txtNombreExamen');
const codigo = document.getElementById('txtCodigo');
const porcentaje_descuento = document.getElementById('txtPrctjDesc');
const fecha = document.getElementById('txtFecha');
const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));

form.addEventListener('submit', e => {
    e.preventDefault();

    var pruebaValidacion = validateInputs();
    if (pruebaValidacion) {
        console.log("Aqui le enviamos al controlador los datos");
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
        var data = {
            
            id_laboratorio: idLab,
            nombre: nombreExamenValue,
            codigo: codigoValue,
            porcentaje_descuento: porcentaje_descuentoValue,
            fecha_caducidad: fechaValue,

        }
        console.log(data);

        $.ajax({
            type: 'POST',
            url: 'https://nolimits-web.azurewebsites.net/api/Cupon/Registrar',
            traditional: true,
            data: data,
            content: "application/json;",
            dataType: "json",
            success: function () {
            }
        });

    }
    return validacionCorrecta;
}