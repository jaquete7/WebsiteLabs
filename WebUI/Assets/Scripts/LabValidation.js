(() => {
    'use strict'

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
                Swal.fire({
                    icon: 'success',
                    title: '¡Exito!',
                    text: 'Laboratorio Registrado',
                    closeOnCancel: true
                })
            }
            form.classList.add('was-validated')
        }, false)
    })
})()
