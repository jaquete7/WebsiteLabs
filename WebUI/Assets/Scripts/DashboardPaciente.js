const user = JSON.parse(sessionStorage.getItem('userData'));
function getDataFromAPI(dataId) {
    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Paciente/ObtenerDatosMeses?idUsua=" + user.id
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

    const months = Object.values(data[0]);
    const arr = Object.values(months).map(value => value);

    return arr;

}

function grafico(arr) {
    var examenesRegistrados = {
        annotations: {
            position: 'back'
        },
        dataLabels: {
            enabled: false
        },
        chart: {
            type: 'bar',
            height: 300
        },
        fill: {
            opacity: 1
        },
        plotOptions: {},
        series: [{
            name: 'Citas Registradas',
            data: arr
        }],
        colors: '#0a9a73',
        xaxis: {
            categories: ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"],
        },
    }
    var chartExamenesComprados = new ApexCharts(document.querySelector("#chart-profile-visit"), examenesRegistrados);
    chartExamenesComprados.render();
}



$(document).ready(function () {
    var dataId = sessionStorage.getItem("dataId");

    var data = getDataFromAPI(dataId);
    //data.pop();
    //data.pop();
    grafico(data);
});