
const fillTablaRoles = () => {
    let colsData = [];
    colsData[0] = { 'data': 'id' };
    colsData[1] = { 'data': 'nombre' };
    colsData[2] = { 'data': 'permisos' };

    $('#tbl-roles').DataTable({
        ajax: {
            method: "GET",
            url: "https://nolimits-web.azurewebsites.net/api/Roles/ObtenerTodos?idLab=0",
            contentType: "application/json:charset=utf-8",
            dataSrc: function (json) {
                let result = json
                return result;
            }
        },
        columnDefs: [
            {
                targets: 3,
                data: null,
                defaultContent: '<button class="btn btn-danger btn-sm rounded-0" id="btnEliminar" type="button" data-toggle="tooltip" data-placement="top" title="Delete"><i class="fa fa-trash"></i></button>',
            },
            {
                targets: 4,
                data: null,
                defaultContent: '<button class="btn btn-success btn-sm rounded-0" id="btnEdit" type="button" data-toggle="tooltip" data-placement="top" title="Edit"><i class="fa fa-edit"></i></button>',
            },
        ],
        columns: colsData
    });

    $('#tbl-roles tbody').on('click', '#btnEdit', function () {
        var tr = $(this).closest('tr');
        var dataId = $('#tbl-roles').DataTable().row(tr).data().id;
        sessionStorage.setItem("dataId", dataId);
        console.log(dataId)
        window.location.href = 'https://nolimits.azurewebsites.net/Roles/EditarRolAdmin';
    });

    $('#tbl-roles tbody').on('click', '#btnEliminar', function () {

        var tr = $(this).closest('tr');
        var dataId = $('#tbl-roles').DataTable().row(tr).data().id;
        var urlAPI = "https://nolimits-web.azurewebsites.net/api/Roles/EliminarRol?idLab=+" + 0 + "&idRol=" + dataId;

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
                    'El Rol ha sido eliminado!.',
                    'success'
                )

                $.ajax({
                    url: urlAPI,
                    type: 'DELETE',
                    success: function (result) {
                        var table = $('#tbl-roles').DataTable();
                        table.ajax.reload();
                    }
                });
            }
        })

    });
}



$(document).ready(function () {
    fillTablaRoles();
})
