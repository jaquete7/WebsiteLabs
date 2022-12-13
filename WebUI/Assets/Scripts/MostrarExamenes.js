function Examen() {

    const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));
    console.log(idLab)

    this.InitView = function () {
        this.CargarTabla();
    }

    var urlAPI = "https://nolimits-web.azurewebsites.net/api/Examen/DevolverTodosExamenes?idlab=" + idLab

    this.CargarTabla = function () {
        var arrayColumnsData = [];
        arrayColumnsData[0] = { 'data': 'idExamen' };
        arrayColumnsData[1] = { 'data': 'fecha_registro' };
        arrayColumnsData[2] = { 'data': 'nombre' };

        $('#tblOfertas').DataTable({
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
            columns: arrayColumnsData

           

        });
    }

    $('#tblOfertas tbody').on('click', '#btnEdit', function () {
        var tr = $(this).closest('tr');
        var dataId = $('#tblOfertas').DataTable().row(tr).data().idExamen;
        sessionStorage.setItem("dataId", dataId);
        window.location.href = 'https://nolimits.azurewebsites.net/Examenes/editar';
    });

    $('#tblOfertas tbody').on('click', '#btnEliminar', function () {

        var tr = $(this).closest('tr');
        var dataId = $('#tblOfertas').DataTable().row(tr).data().idExamen;
        var urlAPI = "https://nolimits-web.azurewebsites.net/api/Examen/EliminarExamen?idLab=" + idLab + "&idExam=" + dataId;

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
                    'Tu examen ha sido eliminado!.',
                    'success'
                )

                $.ajax({
                    url: urlAPI,
                    type: 'DELETE',
                    success: function (result) {
                        var table = $('#tblOfertas').DataTable();
                        table.ajax.reload();
                    }
                });
            }
        })
       
    });

}

$(document).ready(function () {
    var view = new Examen();
    view.InitView();
});
