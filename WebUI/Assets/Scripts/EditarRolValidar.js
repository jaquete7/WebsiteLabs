
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
    let currentLab = sessionStorage.getItem('currentLab');
    if (currentLab != null)
        return currentLab

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
                let id = generarID();
                let laboratorio = getCurrentLab();

                let data = {
                    id: id,
                    nombre: nombre,
                    permisos: permisos,
                    laboratorio: laboratorio
                }

                $.ajax({
                    type: 'POST',
                    url: '#',
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
