
let datatest;
const setAdminData = () => {
    const user = JSON.parse(sessionStorage.getItem('userData'));
    $('#admin-name').text(user.nombre);
    $('#admin-pic').attr('src', user.ruta_foto);
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

const fillTablaV = () => {
    let colsData = [];
    colsData[0] = { 'data': 'actividad' };
    colsData[1] = { 'data': 'descripcion' };
    colsData[2] = { 'data': 'fecha' };

    $('#tbl-vitacora').DataTable({
        ajax: {
            method: "GET",
            url: "https://nolimits-web.azurewebsites.net/api/Vitacora/Obtener",
            contentType: "application/json:charset=utf-8",
            dataSrc: function (json) {
                return fixFecha(json);
            }
        },
        columns: colsData
    });
}

const getReporte = () => {
    $.ajax({
        method: "GET",
        url: "https://nolimits-web.azurewebsites.net/api/Sistema/ObtenerDatosDashboard",
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            $('#total-ingresos').text( '$' + response[0].ingresos );
            $('#proveedores-registrados').text(response[0].proveedores);
            $('#pacientes-ingresos').text(response[0].pacientes);
        }
    });
}

$(document).ready(function () {
    setAdminData();
    fillTablaV();
    getReporte();
})
