let currentLab = sessionStorage.getItem(`view-lab`);
let examenesCarritoNuevoItem = [];
let examen;


const payNow = () => {
    if (validarCarrito()) {
        let carritoLocal = JSON.parse(sessionStorage.getItem(`examenesCarrito${currentLab}`));
        if (!validarExamenEnCarrito(carritoLocal, examen.id)) {
            carritoLocal.push(examen);
            sessionStorage.setItem(`examenesCarrito${currentLab}`, JSON.stringify(carritoLocal));
        }

    } else {
        console.log('Carrito creado con ' + examen.nombre);
        examenesCarritoNuevoItem.push(examen);
        sessionStorage.setItem(`examenesCarrito${currentLab}`, JSON.stringify(examenesCarritoNuevoItem));
    }
    window.location.href = '/Examenes/Checkout';
}

const addCarrito = () => {

    if (validarCarrito()) {

        let carritoLocal = JSON.parse(sessionStorage.getItem(`examenesCarrito${currentLab}`));

        if (validarExamenEnCarrito(carritoLocal, examen.id)) {
            Swal.fire({
                position: 'center',
                icon: 'warning',
                title: 'Este producto ya ha sido agregado al carrito',
                showConfirmButton: false,
                timer: 2000
            });
        } else {
            carritoLocal.push(examen);
            sessionStorage.setItem(`examenesCarrito${currentLab}`, JSON.stringify(carritoLocal));

            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Examen agregado al carrito correctamente',
                showConfirmButton: false,
                timer: 2000
            }).then(() => {
                location.reload();
            });
        }

    } else {
        console.log('Carrito creado con ' + examen.nombre);
        examenesCarritoNuevoItem.push(examen);
        sessionStorage.setItem(`examenesCarrito${currentLab}`, JSON.stringify(examenesCarritoNuevoItem));
        Swal.fire({
            position: 'center',
            icon: 'success',
            title: 'Examen agregado correctamente al carrito',
            showConfirmButton: false,
            timer: 2000
        }).then(() => {
            location.reload();
        });;
    }
}

const validarCarrito = () => {
    let carrito = JSON.parse(sessionStorage.getItem(`examenesCarrito${currentLab}`));
    if (carrito) {
        return true;
    } 
    return false;
}

const validarExamenEnCarrito = (carritoLocal, idE) => {
    console.log(carritoLocal)
    for (let i = 0; i < carritoLocal.length; i++) {
        if (carritoLocal[i].id == idE) {
            return true;
        }
    }
}

$(document).ready(function () {
    examen = {
        id: $('#add-carrito').attr('data-id'),
        nombre: $('#add-carrito').attr('data-name'),
        precio: $('#add-carrito').attr('data-precio'),
    };
})