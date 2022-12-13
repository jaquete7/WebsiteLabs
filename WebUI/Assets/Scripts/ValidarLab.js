const form = document.getElementById('form');
const nombre = document.getElementById('txtNombre');
const nombreComercial = document.getElementById('txtNombreComercial');
const cedulaJuridica = document.getElementById('txtCedulaJuridica');
const razonSocial = document.getElementById('txtRazonSocial');
const telefonoContacto = document.getElementById('txtTelefonoContacto');
const correoElectronico = document.getElementById('txtCorreoElectronico');
const provincia = document.getElementById('txtProvincia');
const canton = document.getElementById('txtCanton');
const distrito = document.getElementById('txtDistrito');
const direccion = document.getElementById('txtDireccion');
const web_site = document.getElementById('txtUrlPaginaLab');
const url_facebook = document.getElementById('txtUrlFacebook');
const url_instagram = document.getElementById('txtUrlInstagram');
const url_twitter = document.getElementById('txtUrlTwitter');
const url_linkedin = document.getElementById('txtUrlLinkedIn');

const getIdProveedor = () => {
    const user = JSON.parse(sessionStorage.getItem('userData'));
    if (user != null && user.rol == 'Proveedor')
        return user.id;
}


form.addEventListener('submit', e => {
    e.preventDefault();

    var pruebaValidacion = validateInputs();
    if (!pruebaValidacion) {
 
        Swal.fire({
            title: 'Oops...',
            text: 'Espacios faltantes / incorrectos',
            icon: 'error',
            confirmButtonText: 'Ok'
        })
    }
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
    const idProveedorValue = getIdProveedor();
    const nombreValue = nombre.value;
    const nombreComercialValue = nombreComercial.value;
    const cedulaJuridicaValue = cedulaJuridica.value;
    const razonSocialValue = razonSocial.value;
    const telefonoContactoValue = telefonoContacto.value;
    const correoElectronicoValue = correoElectronico.value;
    const provinciaValue = provincia.value;
    const cantonValue = canton.value;
    const distritoValue = distrito.value;
    const direccionValue = direccion.value;
    const webSiteValue = web_site.value;
    const urlFacebookValue = url_facebook.value;
    const urlInstagramValue = url_instagram.value;
    const urlTwitterValue = url_twitter.value;
    const urlLinkedInValue = url_linkedin.value;
    const imagenValue = imagen.src;



    if (nombreValue === '') {
        setError(nombre);
        validacionCorrecta = false
    } else {
        setSuccess(nombre);
    }

    if (nombreComercialValue === '') {
        setError(nombreComercial);
        validacionCorrecta = false
    } else {
        setSuccess(nombreComercial);
    }

    if (cedulaJuridicaValue === '') {
        setError(cedulaJuridica);
        validacionCorrecta = false
    } else {
        setSuccess(cedulaJuridica);
    }

    if (razonSocialValue === '') {
        setError(razonSocial);
        validacionCorrecta = false
    } else {
        setSuccess(razonSocial);
    }

    if (telefonoContactoValue === '') {
        setError(telefonoContacto);
        validacionCorrecta = false
    } else {
        setSuccess(telefonoContacto);
    }

    if (correoElectronicoValue === '') {
        setError(correoElectronico);
        validacionCorrecta = false
    } else {
        setSuccess(correoElectronico);
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
            id_proveedor: idProveedorValue,
            nombre: nombreValue,
            nombre_comercial: nombreComercialValue,
            cedula_juridica: cedulaJuridicaValue,
            razon_social: razonSocialValue,
            tel_contacto: telefonoContactoValue,
            correo_electronico: correoElectronicoValue,
            provincia: provinciaValue,
            canton: cantonValue,
            distrito: distritoValue,
            direccion: direccionValue,
            web_site: webSiteValue == '' ? 'no-tiene' : webSiteValue,
            url_facebook: urlFacebookValue == '' ? 'no-tiene' : urlFacebookValue,
            url_instagram: urlInstagramValue == '' ? 'no-tiene' : urlInstagramValue,
            url_twitter: urlTwitterValue == '' ? 'no-tiene' : urlTwitterValue,
            url_linkedin: urlLinkedInValue == '' ? 'no-tiene' : urlLinkedInValue,
            ruta_fotos1: imagenValue
        }


        $.ajax({
            type: 'POST',
            url: 'https://nolimits-web.azurewebsites.net/api/Laboratorio/Registrar',
            data: data,
            content: "application/json;",
            success: function () {
                Swal.fire({
                    title: 'Éxito!',
                    text: 'Registro Exitoso',
                    icon: 'success',
                    confirmButtonText: 'Ok'
                }).then(() => {
                   
                    window.location.href = '/Proveedor';
                
                })
            }
        });

    }
    return validacionCorrecta;
}