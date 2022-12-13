const labSelected = 0;
/*const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));*/

const validateMembresia = facturas => {
    if (facturas.length < 1) {
        Swal.fire({
            position: 'center',
            icon: 'warning',
            title: 'Para continuar porfavor completa tu suscripción mensual',
            showConfirmButton: true,
        }).then(() => {
            window.location.href = 'https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=YEVUZFEVVZQSS';
        });
    }
}

const getFacturaMembresia = () => {
    const user = JSON.parse(sessionStorage.getItem('userData'));
    $.ajax({
        method: "GET",
        url: `https://nolimits-web.azurewebsites.net/api/Factura/ObtenerFacturas?idUsuario=${user.id}`,
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            validateMembresia(response);
        }
    });
}

const fillTablaLabs = () => {

    const user = JSON.parse(sessionStorage.getItem('userData'));
    
    if (user != null && user.rol == 'Proveedor') {
        let colsData = [];
        colsData[0] = { 'data': 'nombre' };
        colsData[1] = { 'data': 'id' };

        $('#tbl-labs').DataTable({
            ajax: {
                method: "GET",
                url: `https://nolimits-web.azurewebsites.net/api/Laboratorio/ObtenerTodosId?idProv=${user.id}`,
                contentType: "application/json:charset=utf-8",
                dataSrc: function (json) {
                    let result = json
                    return result;
                }
            },
            columnDefs: [
                {
                    targets: 2,
                    data: null,
                    defaultContent: '<button class="administrar-lab btn btn-success btn-sm rounded-0 type="button" data-toggle="tooltip" data-placement="top" title="Edit"><i class="fas fa-tools"></i></button>',
                },
                {
                    targets: 3,
                    data: null,
                    defaultContent: '<button class="btn btn-danger btn-sm rounded-0" id="btnEliminar" type="button" data-toggle="tooltip" data-placement="top" title="Edit"><i class="fa fa-trash"></i></button>',
                },
                {
                    targets: 4,
                    data: null,
                    defaultContent: '<button class="btn btn-success btn-sm rounded-0" id="btnEdit" type="button" data-toggle="tooltip" data-placement="top" title="Edit"><i class="fa fa-edit"></i></button>',
                },
            ],
            columns: colsData
        });
    }

    $('#tbl-labs tbody').on('click', '#btnEdit', function () {
        var tr = $(this).closest('tr');
        var dataId = $('#tbl-labs').DataTable().row(tr).data().id;
        sessionStorage.setItem("dataId", dataId);
        window.location.href = 'https://nolimits.azurewebsites.net/Laboratorio/EditarLaboratorio';
    });

    $('#tbl-labs tbody').on('click', '#btnEliminar', function () {

        var tr = $(this).closest('tr');
        var dataId = $('#tbl-labs').DataTable().row(tr).data().id;
        var urlAPI = "https://nolimits-web.azurewebsites.net/api/Laboratorio/EliminarLaboratorio?idLab=" + dataId + "&idProv=" + user.id;

        Swal.fire({
            title: '¿Estas Seguro?',
            text: "¡No podrás revertir esto!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'Cancelar',
            confirmButtonText: '¡Sí, ¡borralo!'
        }).then((result) => {
            if (result.isConfirmed) {
                Swal.fire(
                    '¡Eliminado!',
                    'Tu laboratorio ha sido eliminado!.',
                    'success'
                )

                $.ajax({
                    url: urlAPI,
                    type: 'DELETE',
                    success: function (result) {
                        var table = $('#tbl-labs').DataTable();
                        table.ajax.reload();
                    }
                });
            }
        })

    });


}
const setCurrentLab = () => {
    $('#tbl-labs tbody').on('click', '.administrar-lab', function () {
        let tr = $(this).closest('tr');
        let idLab = $('#tbl-labs').DataTable().row(tr).data().id;
        sessionStorage.setItem("currentLabID", idLab);
        window.location.href = '/Laboratorio/Dashboard';
    });
}


$(document).ready(function () {
    getFacturaMembresia();
    fillTablaLabs();
    setCurrentLab();
})
