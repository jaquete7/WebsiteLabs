function Login() {

    var contenido = {
        "email": $("#txt_correo").val(),
        "password": $("#txt_password").val()
    };

    $.ajax({    
        method: "POST",
        url: 'https://nolimits-web.azurewebsites.net/api/Login/ValidarLogin',
        contentType: "application/json",
        data: JSON.stringify(contenido),
        hasContent: true
    }).done(function (response) {
        
        if (response && response.length > 0 ) {

            sessionStorage.setItem("userData", JSON.stringify(response[0]));

            if (response[0].estado == 0) {
                window.location.href = "/Registro/VerificacionOTP";
                return;
            }   
               
            switch (response[0].rol) {
                case "Proveedor":
                    window.location.href = "/Proveedor?id=" + response[0].id;
                    break;
                case "Paciente":
                    window.location.href = "/Paciente/Dashboard?id=" + response[0].id;
                    break;
                case "Administrador":
                    window.location.href = "/Administrador/Dashboard?id=" + response[0].id;
                    break;
                default:
                    window.location.href = "/";
            }

        } else {
            Swal.fire({
                icon: 'error',
                title: '¡Atención!',
                text: '¡Usuario o contraseña inválido!'
            })
        }
    }
    ).fail(function () {
        Swal.fire({
            icon: 'error',
            title: '¡Atención!',
            text: '¡API fuera de servicio!'
        })
    });
}