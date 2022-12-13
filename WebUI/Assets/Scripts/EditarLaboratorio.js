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

const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));
const user = JSON.parse(sessionStorage.getItem('userData'));

function getDataFromAPI(dataId) {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Laboratorio/DevolverLaboratorio?idLab=" + dataId + "&idProv=" + user.id
    console.log(urlAPI)
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
    console.log(data);
    $('#txtNombre').val(data[0].nombre);
    $('#txtNombreComercial').val(data[0].nombre_comercial);
    $('#txtCedulaJuridica').val(data[0].cedula_juridica);
    $('#txtRazonSocial').val(data[0].razon_social);
    $('#txtTelefonoContacto').val(data[0].tel_contacto);
    $('#txtCorreoElectronico').val(data[0].correo_electronico);
    $('#txtProvincia').val(data[0].provincia);
    $('#txtCanton').val(data[0].canton);
    $('#txtDistrito').val(data[0].distrito);
    $('#txtUrlFacebook').val(data[0].url_facebook);
    $('#txtUrlInstagram').val(data[0].url_instagram);
    $('#txtUrlTwitter').val(data[0].url_twitter);
    $('#txtUrlLinkedIn').val(data[0].url_linkedin);
    $('#txtUrlPaginaLab').val(data[0].web_site);
    $('#txtDireccion').val(data[0].direccion);
    $(imagen).attr("src", data[0].ruta_fotos1);
    // y así sucesivamente
}

$(document).ready(function () {
    var dataId = sessionStorage.getItem("dataId");

    var data = getDataFromAPI(dataId); // Obtener los datos de la API
    fillFormFields(data); // Rellenar los campos del formulario
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

    if (webSiteValue === '') {
        setError(web_site);
        validacionCorrecta = false
    } else {
        setSuccess(web_site);
    }

    if (validacionCorrecta) {

        var dataId = sessionStorage.getItem("dataId");
        var urlAPI = "https://nolimits-web.azurewebsites.net/api/Laboratorio/EditarLaboratorio?idLab=" + dataId + "&idProv=" + user.id

        var data = {
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
            web_site: webSiteValue,
            url_facebook: urlFacebookValue == '' ? 'no-tiene' : urlFacebookValue,
            url_instagram: urlInstagramValue == '' ? 'no-tiene' : urlInstagramValue,
            url_twitter: urlTwitterValue == '' ? 'no-tiene' : urlTwitterValue,
            url_linkedin: urlLinkedInValue == '' ? 'no-tiene' : urlLinkedInValue,
            ruta_fotos1: imagenValue
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
                title: 'Tu laboratorio ha sido editado!',
                showConfirmButton: false,
                timer: 1500
            })
            setTimeout(
                function () {
                    window.location.href = 'https://nolimits.azurewebsites.net/Proveedor?id=' + user.id;
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