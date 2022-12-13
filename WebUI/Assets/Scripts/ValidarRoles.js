
$('input[type="radio"]').on("mousedown", function () {
    if (this.checked) {
        $(this).one("click", function () {
            this.checked = false;
        });
    }
});

const getPermisosSelected = () => {
    let permisosSelected = [];
    $("input:radio:checked").each(function () {
        permisosSelected += $(this).attr("id") + ',';
    });
    return permisosSelected;
}

const generarID = () => Math.floor(100000 + Math.random() * 900000);

const getCurrentLab = () => {
    const idLab = JSON.parse(sessionStorage.getItem('currentLabID'));
    if (idLab != null)
        return idLab

    return 0
}

(() => {
    const forms = document.querySelectorAll('.needs-validation')

    Array.from(forms).forEach(form => {
        form.addEventListener('submit', event => {
            event.preventDefault()
            event.stopPropagation()
            if (!form.checkValidity()) {
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: '¡Espacios requeridos!'
                })
            } else {

                $('#guardar-rol').text('Procesando...');

                let permisos = getPermisosSelected();
                let nombre = $('#nombre-rol').val();
                let laboratorio = getCurrentLab();
                console.log(laboratorio);

                let data = {
                    nombre: nombre,
                    permisos: permisos,
                    laboratorio: laboratorio
                }

                $.ajax({
                    type: 'POST',
                    url: 'https://nolimits-web.azurewebsites.net/api/Roles/Registrar',
                    traditional: true,
                    data: data,
                    content: "application/json;",
                    dataType: "json",
                    success: function () {
                        Swal.fire({
                            icon: 'success',
                            title: 'Registro exitoso',
                        })
                        $('#guardar-rol').text('Registrar rol');
                    }
                });

            }
            form.classList.add('was-validated')
        }, false)
    })
})()
