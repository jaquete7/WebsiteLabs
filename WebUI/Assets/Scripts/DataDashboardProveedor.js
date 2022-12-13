const setPacienteData = () => {
    const user = JSON.parse(sessionStorage.getItem('userData'));
    $('#proveedor-name').text(user.nombre);
    $('#proveedor-pic').attr('src', user.ruta_foto);
}

const fixFecha = (arr) => {
    const newArr = arr.map(object => {
        if (object.fecha.includes('00:00:00')) {
            let fix = object.fecha
            return { ...object, fecha: fix.replace('00:00:00', '') };
        }
        return object;
    });
    return newArr;
}

const getReporte = () => {
    let url2 = "https://nolimits-web.azurewebsites.net/api/Proveedor/ObtenerDatosDashboard?idLab=" + idLab
    console.log(url2)
    $.ajax({
        method: "GET",
        url: url2,
        
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            $('#total-ingresos').text('$' + response[0].ingresos);
            $('#compras-realizadas').text(response[0].compras);
        }
    });
    
    console.log(url2)
}

$(document).ready(function () {
    setPacienteData();
    getReporte();
})