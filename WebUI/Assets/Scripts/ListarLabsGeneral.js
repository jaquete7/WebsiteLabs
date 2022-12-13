const actionViewExamenes = () => {
    let selectedLab;
    $('.ver-examenes-lab').click(function () {
        selectedLab = $(this).attr('data-id');
        sessionStorage.setItem("view-lab", selectedLab);
        window.location.href = '/Laboratorio/Examenes';
    })
}

const createLabs = (labs) => {
    let container = document.querySelector('#labs-container');
    container.innerHTML = '<div class="row">' +
        labs.map(function (lab) {
            return `
                  <div class="col-lg-4 col-sm-6 col-12">
                    <div class="ltn__blog-item ltn__blog-item-3">
                        <div class="ltn__blog-img">
                            <img src="${lab.ruta_fotos1}" alt="#">
                        </div>
                        <div class="ltn__blog-brief">
                            <h3 class="ltn__blog-title">
                                ${lab.nombre_comercial}
                            </h3>
                            <div class="ltn__blog-meta-btn">
                                <div class="ltn__blog-meta">
                                    <ul>
                                        <li class="ltn__blog-date"><i class="fas fa-thumbtack"></i>${lab.provincia}/ ${lab.canton}</li>
                                    </ul>
                                </div>
                                <div class="ltn__blog-btn">
                                   <a class='ver-examenes-lab' data-id="${lab.id}" href="#">Ver Exámenes</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            `;
        })
        .join('') + '</div>';
    actionViewExamenes();
}

const fillLabsRegistrados = () => {
    $.ajax({
        method: "GET",
        url: 'https://nolimits-web.azurewebsites.net/api/Laboratorio/DevolverTodosPedidos',
        contentType: "application/json:charset=utf-8",
    }).done(function (response) {
        createLabs(response);
    }).fail(function () {
        Swal.fire({
            icon: 'error',
            title: '¡Atención!',
            text: '¡API fuera de servicio!'
        })
    });
}

$(document).ready(function () {
    fillLabsRegistrados();
})
