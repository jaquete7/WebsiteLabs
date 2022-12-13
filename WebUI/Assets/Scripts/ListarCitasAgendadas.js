const fillTablaCitas = () => {
    let colsData = [];
    colsData[0] = { 'data': 'id_cita'};
    colsData[1] = { 'data': 'id_examen' };
    colsData[2] = { 'data': 'nombre' };
    colsData[3] = { 'data': 'fecha_examen' };
    colsData[4] = { 'data': 'estado' };
    var id_usuario = JSON.parse(sessionStorage.getItem('userData')).id;
    
    $('#tbl_CitasAgendadas').DataTable({
        ajax: {
            type: "GET",
            
            url: "https://nolimits-web.azurewebsites.net/api/Paciente/MostrarCitasAgendadas?id_usuario=" + id_usuario, 
            contentType: "application/json;charset=utf-8", 
            dataSrc: function (json) {

                var json = { 'data': json }
                console.log("DATATABLE");
                console.log(json.data);

                $.each(json.data, function (pos, item) {
                    item.fecha_examen = formatDate(item.fecha_examen);
                })

                return json.data;
            }
        },
        bDestroy: true,
        columns: colsData
    });

    $('#tbl_CitasAgendadas').on('click', 'tr', function () {
        var tr = $(this).closest('tr');
        var data = $('#tbl_CitasAgendadas').DataTable().row(tr).data();
        console.log(data);
        $('#txtNombreExamen').val(data.nombre);
        $('#hdnId_examen').val(data.id_cita);
        
    });

}
const formatDate = (inputDate, type = 'default') => {
    if (inputDate && typeof (inputDate !== undefined) && inputDate !== '') {
        var formattedYear = inputDate.substring(0, 10).split('-')[0];
        var formattedMonth = inputDate.substring(0, 10).split('-')[1];
        var formattedDay = inputDate.substring(0, 10).split('-')[2];
        var formattedHour = inputDate.split('T')[1].split('-')[0];
        return (formattedMonth + '/' + formattedDay + '/' + formattedYear + ' ' + formattedHour);
    } else {
        return '';
    }

}





$(document).ready(function () {
    
    fillTablaCitas();
    
    $('#btn_Reagendar').on('click', function () {
        let nombreExamen = $('#txtNombreExamen').val();
        let idExamen = $('#hdnId_examen').val();
        if (nombreExamen && idExamen) {
            $.ajax({
                method: "POST",
                url: 'https://nolimits-web.azurewebsites.net/api/Paciente/ReAgendarCitasAgendadas?id_cita=' + idExamen + '&fecha=' + $("#fechaHora").val() +'',
                contentType: "application/json",
                hasContent: true
            }).done(function (response) {
                fillTablaCitas();
                let qrcodeContainer = document.getElementById("qrcode");
                qrcodeContainer.innerHTML = "";
                var URL = "https://nolimits.azurewebsites.net/ConfirmacionQR/ConfirmacionQR?" +
                    "nom=" + response[0].Usuario + "&" +
                    "id=" + response[0].Cita + "&" +
                    "lab=" + response[0].NombreLab + "&" +
                    "con=" + response[0].Fecha + "&" +
                    "exa=" + response[0].NombreExam + "&" +
                    "tel=" + response[0].TelLab + "&" +
                    "email=" + response[0].CorreoLab + "&" +
                    "dir=" + response[0].Direccion + "&" +
                    "correoUsuario=" + response[0].CorreoUsuario;
                new QRCode(qrcodeContainer, URL);
                URL = "https://nolimits.azurewebsites.net/Home/EnviarQR?" +
                    "nom=" + response[0].Usuario + "&" +
                    "id=" + response[0].Cita + "&" +
                    "lab=" + response[0].NombreLab + "&" +
                    "con=" + response[0].Fecha + "&" +
                    "exa=" + response[0].NombreExam + "&" +
                    "tel=" + response[0].TelLab + "&" +
                    "email=" + response[0].CorreoLab + "&" +
                    "dir=" + response[0].Direccion + "&" +
                    "correoUsuario=" + response[0].CorreoUsuario;
                $.ajax({
                    type: 'POST',
                    url: URL,
                    traditional: true,
                    content: "application/json;",
                    dataType: "json",
                });
                Swal.fire({
                    icon: 'success',
                    title: '¡Agendado con éxito!',
                    text: '¡Para editar su cita dirijase a la pestaña de Reagendar Citas!'
                });
            }
            ).fail(function () {
                Swal.fire({
                    icon: 'error',
                    title: '¡Atención Error API!',
                    text: '¡Comuniquese con mantenimiento!'
                })
            });
        } else {
            Swal.fire({
                icon: 'error',
                title: '¡Seleccione un exámen!',
                text: 'Favor selecciones un exámen en la lista adjunta'
            });
        }
    });
    

})

    