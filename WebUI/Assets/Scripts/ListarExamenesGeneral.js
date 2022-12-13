const actionViewItem = () => {
    let selectedExamen;
    $('.ver-examen').click(function () {

        const user = JSON.parse(sessionStorage.getItem('userData'));

        if (user == null || user.rol != 'Paciente') {
            Swal.fire({
                icon: 'error',
                title: '¡Atención!',
                text: 'Debes registrarte como un paciente para continuar'
            }).then(() => {
                window.location.href = '/Home/Producto#Registrarse';
            });
        } else {
            selectedExamen = {
                idExamen: $(this).attr('data-id'),
                nombre: $(this).attr('data-name'),
                descripcion: $(this).attr('data-descripcion'),
                precio: $(this).attr('data-precio'),
                recomendaciones: $(this).attr('data-recomendaciones'),
                datos_evaluados: $(this).attr('data-datos'),
            }

            sessionStorage.setItem("view-examen", JSON.stringify(selectedExamen));
            window.location.href = '/Examenes/Informacion';
        }
    })
}

const createExams = (exams) => {
    let container = document.querySelector('#examenes-container');
    container.innerHTML = '<div class="row">' +
        exams.map(function (e) {
            return `
                <div class="col-lg-4 col-sm-6 col-12">
                    <div class="ltn__blog-item ltn__blog-item-3">
                        <div class="ltn__blog-brief">
                            <h3 class="ltn__blog-title"><a href="#">${e.nombre}</a></h3>
                            <p>
                                ${e.descripcion}
                            </p>
                            <div class="ltn__blog-meta-btn">
                                <div class="ltn__blog-meta">
                                    <ul>
                                        <li class="ltn__blog-tags">
                                            <a href="#"><i class="fas fa-money-check-alt"></i>$${e.precio}</a>
                                        </li>
                                    </ul>
                                </div>
                                <div class="ltn__blog-btn">
                                    <a class='ver-examen' href="#"
                                        data-id="${e.id}" data-descripcion="${e.descripcion}" data-precio="${e.precio}"
                                        data-recomendaciones="${e.recomendaciones}" data-datos="${e.datos_evaluados}" data-name="${e.nombre}"
                                    >
                                        Ver información
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            `;
        })
        .join('') + '</div>';
    actionViewItem();
}

const getLabSelected = () => sessionStorage.getItem('view-lab');


const fillExamenes = () => {
    $.ajax({
        method: "GET",
        url: `https://nolimits-web.azurewebsites.net/api/Examen/DevolverTodosExamenes?idLab=${getLabSelected()}`,
        contentType: "application/json:charset=utf-8",
    }).done(function (response) {
        createExams(response);
    }).fail(function () {
        Swal.fire({
            icon: 'error',
            title: '¡Atención!',
            text: '¡API fuera de servicio!'
        })
    });
}

$(document).ready(function () {
    fillExamenes();
})
