const setAdminData = () => {
    const user = JSON.parse(sessionStorage.getItem('userData'));
    $('#paciente-name').text(user.nombre);
    $('#paciente-pic').attr('src', user.ruta_foto);
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
    let url2 = "https://nolimits-web.azurewebsites.net/api/Paciente/ObtenerDatosDashboard?idUsua=" + user.id
    $.ajax({
        method: "GET",
        url: url2,
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            $('#citas_agendadas').text('$' + response[0].citas_agendadas);
            $('#citas_pendientes').text(response[0].citas_pendientes);
        }
    });
}

$(document).ready(function () {
    setAdminData();
    getReporte();
})