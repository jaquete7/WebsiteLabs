const setInfoExamen = () => {
    const e = JSON.parse(sessionStorage.getItem('view-examen'));
    $('.nombre').text(e.nombre)
    $('.precio').text('$'+ e.precio)
    $('.descripcion').text(e.descripcion)
    $('.recomendaciones').text(e.recomendaciones)
    $('.datos-evaluados').text(e.datos_evaluados)

    $('#add-carrito').attr('data-id', e.idExamen)
    $('#add-carrito').attr('data-name', e.nombre)
    $('#add-carrito').attr('data-precio', e.precio)
}

$(document).ready(function () {
    setInfoExamen();
})
