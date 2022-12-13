function Citas()

{

    this.InitView = function () {
        $("#btnRegistrarResultado").click(function () {
            var vista = new Citas();
            vista.CrearResultado();
        });



        //apenas se inicialize la pagina se cargua la tabla
        this.CargarTabla();
    }
    //LLenar Tabla
    this.CargarTabla= () => {
        const user = JSON.parse(sessionStorage.getItem('userData'));
        const lab_id = JSON.parse(sessionStorage.getItem('currentLabID'));
        let colsData = [];
        colsData[0] = { 'data': 'id_cita' };
        colsData[1] = { 'data': 'id_examen' };
        colsData[2] = { 'data': 'id_usuario' };
        colsData[3] = { 'data': 'fecha' };
        colsData[4] = { 'data': 'estado' };
        //colsData[5] = { 'data': 'id_lab' };


        $('#tbl-citas').DataTable({
            ajax: {
                method: "GET",
                url: `https://nolimits-web.azurewebsites.net/api/Cita/ObtenerTodasCitas?idLab=${lab_id}`,
                contentType: "application/json:charset=utf-8",
                dataSrc: function (json) {
                    var json = { 'data': json }
                    return json.data;
                    ;
                }
            },
            columns: colsData
        });
    }

    //Crear Resultado



    this.CrearResultado =() => {
        const queryString = window.location.search;
        const urlParams = new URLSearchParams(queryString);
        //const isSucess = urlParams.get('success');

        //let clave = generarClave();
        //let detalle = 'Suscripcion Mensual al Sistema NoLimits Solutions';
        const user = JSON.parse(sessionStorage.getItem('userData'));

        const form = document.getElementById('form');
        const idCita = document.getElementById('txtIdCita').value;
        const idUsuario = document.getElementById('txtIdUsuario').value;
        const descripcion = document.getElementById('txtDescripcion').value;
        const evaluacion = document.getElementById('txtEvaluacion').value;
       //let correo = recibirCorreo(idUsuario);

        
        correo = recibirCorreo(idUsuario);
        
        console.log(correo);

        var resultado = {}
        resultado.id_cita = idCita;
        resultado.id_usuario = idUsuario;
        resultado.descripcion = descripcion;
        resultado.evaluacion = evaluacion;

        var urlAPI = "https://nolimits-web.azurewebsites.net/api/Resultado/RegistarResultado";

      
      

        $.ajax({
            type: 'POST',
            url: `https://nolimits.azurewebsites.net/Home/SendResultado?destino=${correo}&descripcion=${descripcion}&evaluacion=${evaluacion}&idCita=${idCita}`,
            traditional: true,
            data: data,
            content: "application/json;",
            dataType: "json",
        });

        var data = {
            id_cita: idCita,
            id_usuario: idUsuario,
            descripcion: descripcion,
            evaluacion: evaluacion,
            
        }

        $.ajax({
            type: 'POST',
            url: 'https://nolimits-web.azurewebsites.net/api/Resultado/CrearResultado',
            traditional: true,
            data: data,
            content: "application/json;",
            dataType: "json",
            success: function () {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'Resultado enviado a tu correo electrónico',
                    showConfirmButton: false,
                    timer: 4000
                })
            },
        });


        var pruebaValidacion = validateInputs();
        if (!pruebaValidacion) {
            Swal.fire({
                title: 'Oops...',
                text: 'Espacios faltantes / incorrectos',
                icon: 'error',
                confirmButtonText: 'Ok'
            })
        }
    }

}



function recibirCorreo(idUsuario) {

    var urlAPI = " https://nolimits-web.azurewebsites.net/api/Paciente/ObtenerUsuario?id=" + idUsuario;
    var data;
    $.ajax({
        method: "GET",
        url: urlAPI,
        dataType: "json",
        async: false,
        success: function (response) {
            data = response.email;

            console.log(data);
        },
        error: function (xhr, status, error) {
            console.log(xhr.responseText);
        }
    });
    return data;

}


$(document).ready(function () {
    var view = new Citas();
    view.InitView();

})
