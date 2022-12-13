const form = document.getElementById('form');
const nombreExamen1 = document.getElementById('nombre');
const precio1 = document.getElementById('precio');
const descrip= document.getElementById('descrip');
const dato = document.getElementById('datos');
const recomen = document.getElementById('recomen');
const idExa = document.getElementById('idExamen');

const setError = (element) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    inputControl.classList.add('error');
    inputControl.classList.remove('sucess');

}

const setSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    inputControl.classList.add('success');
    inputControl.classList.remove('error');

}

function Examen() {

    const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));

    this.InitView = function () {
        $('#btnCrear').click(function () {
            var vista = new Examen();
            vista.CrearExamen();
        });
    }

    this.CrearExamen = function () {
        var validacionCorrecta = true;

        const nombreExamenValue = nombreExamen1.value;
        const precio = precio1.value;
        const descripcion = descrip.value;
        const datos = dato.value;
        const recomendaciones = recomen.value;
        const idExam = idExa.value;

        if (nombreExamenValue === '') {
            setError(nombreExamen1);
            validacionCorrecta = false
        } else {
            setSuccess(nombreExamen1);
        }

        if (precio === '') {
            setError(precio1);
            validacionCorrecta = false
        } else {
            setSuccess(precio1);
        }

        if (descripcion === '') {
            setError(descrip);
            validacionCorrecta = false
        } else {
            setSuccess(descrip);
        }

        if (datos === '') {
            setError(dato);
            validacionCorrecta = false
        } else {
            setSuccess(dato);
        }

        if (recomendaciones === '') {
            setError(recomen);
            validacionCorrecta = false
        } else {
            setSuccess(recomen);
        }

        if (idExam === '') {
            setError(idExa);
            validacionCorrecta = false
        } else {
            setSuccess(idExa);
        }

        if (validacionCorrecta) {
            var examen = {}

            examen.id_laboratorio = idLab;
            examen.Nombre = $("#nombre").val();
            examen.precio = $("#precio").val();
            examen.Descripcion = $("#descrip").val();
            examen.datos_evaluados = $("#datos").val();
            examen.recomendaciones = $("#recomen").val();
            examen.idExamen = $("#idExamen").val();

        var urlAPI = "https://nolimits-web.azurewebsites.net/api/Examen/Registrar"

            /*
           var controlAcciones = new ControlAcciones();
     
           controlAcciones.PostToAPI("/api/SinpagInteraction/Ofertar", oferta, function () {
               alert("Oferta Creada")
           })
           */

            $.ajax({
                Headers: {
                    'Accept': "application/json",
                    'Content-Type': "application/json"
                },
                method: "POST",
                url: urlAPI,
                contentType: "application/json",
                data: JSON.stringify(examen),
                hasContent: true
            }).done(function () {
                Swal.fire({
                    icon: 'success',
                    title: 'El Examen ha sido creado!',
                    showConfirmButton: false,
                    timer: 1500
                })
            }
            ).fail(function () {
                Swal.fire({
                    title: 'Oops...',
                    text: 'Hubo un problema!',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                })
            });

        } else {
            Swal.fire({
                title: 'Oops...',
                text: 'Espacios faltantes / incorrectos',
                icon: 'error',
                confirmButtonText: 'Ok'
            })
        }
        return validacionCorrecta;
    }
}

$(document).ready(function () {
    var view = new Examen();
    view.InitView();
});



(() => {
    const forms = document.querySelectorAll('.needs-validation')

    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            event.preventDefault()
            event.stopPropagation()
            form.classList.add('was-validated')
        }, false)
    })
})()