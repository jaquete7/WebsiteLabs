
const ocultarOpcionesLogout = () => $('.logout').css('display', 'none');
const logout = () => $('#logout').click(function () {
    sessionStorage.removeItem('userData');
    window.location.href = "/";
})

const validarMenu = () => {

    const user = JSON.parse(sessionStorage.getItem('userData'));

    if (user != null) {
        let tipoUsuario = user.rol;
        $('.' + tipoUsuario).css('display', 'block');
        ocultarOpcionesLogout();
        logout();
    }

}

$(document).ready(function () {
    validarMenu();
})
