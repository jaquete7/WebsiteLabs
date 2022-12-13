function Facturas() {

    const user = JSON.parse(sessionStorage.getItem('userData'));
    const id = user.id;

    this.InitView = function () {
        this.CargarTabla();
    }

    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Factura/ObtenerFacturas?idUsuario=" + id

    this.CargarTabla = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'id' };
        arrayColumnsData[1] = { 'data': 'fecha_emicion' };
        arrayColumnsData[2] = { 'data': 'total' };
        arrayColumnsData[3] = { 'data': 'detalle' };

        $('#tblFacturas').DataTable({
            ajax: {
                method: "GET",
                url: urlAPI,
                contentType: "application/json;charset=utf-8",
                dataSrc: function (json) {
                    var json = { 'data': json }
                    console.log(json.data);
                    return json.data;
                }
            },
        
            columns: arrayColumnsData

        });
    }
}

$(document).ready(function () {
    var view = new Facturas();
    view.InitView();
});
