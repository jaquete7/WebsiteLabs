const user = JSON.parse(sessionStorage.getItem('userData'));
let currentLab = sessionStorage.getItem('view-lab')
let iva = 0;
let infoRepresentanteLab = [];
let cuponesLab = [];
let isCuponActive = false;
let descuentoCupon = 0;

//Obtiene la suma de precio de todos los items
getPrecioItems = () => {
    let precioItems = 0;
    $(".precio").each(function () {
        precioItems += parseFloat($(this).attr("data-precio").replace(',', '.'));
    });
    return precioItems;
}

//Obtiene el total de iva de todos los items
const getPrecioIVA = () => {
    let totalItems = parseFloat(getPrecioItems());
    return totalItems * iva;
}

//Elimina un item de la tabla de items, necesita el id del row
const removeItem = id => {
    let rowCount = $('#table-items tr').length;
    if (rowCount > 2) {
        $('#' + id).remove();

        $('#val-iva').text('$' + getPrecioIVA())
        setTotalCheckout()
        return
    }
    Swal.fire({
        icon: 'error',
        title: '¡Atención!',
        text: '¡No puedes eliminar todos los elementos!'
    })
}

const checkoutItemSelected = () => {
    const e = JSON.parse(sessionStorage.getItem('view-examen'));
    $('#table-items tr:last').after(
        `   <tr class='id-examen' id='${e.id}'>
                <td data-val='${e.nombre}' class='examen-name'>${e.nombre}</td>
                <td class='precio' data-precio='${e.precio}'>$ ${e.precio}</td>
            </tr>
        `
    );

    $('#val-iva').text('$'+getPrecioIVA())
}

const checkoutCarrito = carrito => {
    carrito.forEach((e) => {
        $('#table-items tr:last').after(
            `   <tr class='id-examen' id='${e.id}'>
                <td data-val='${e.nombre}' class='examen-name'>${e.nombre}</td>
                <td class='precio' data-precio='${e.precio}'>$ ${e.precio}</td>
                <td><a href='#' onclick="removeItem(${e.id})" ><i class="fas fa-trash-alt"></i></a></td>
            </tr>
        `
        );
    })
    $('#val-iva').text('$' + getPrecioIVA())
}


//Setea los items en las tablas
const setItems = () => {
    let carrito = JSON.parse(sessionStorage.getItem(`examenesCarrito${currentLab}`));
    if (carrito == null) {
        checkoutItemSelected();
        return
    } else {
        checkoutCarrito(carrito);
    }
}

//Obtiene el total a pagar sumando iva + total - descuento
const getTotalCheckout = () => {
    let items = getPrecioItems();
    let iva = getPrecioIVA();
    let cupon = descuentoCupon;

    items = items - cupon;
    items = items + iva;

    return items;
}

//Setea el total a pagar
const setTotalCheckout = () => {
    let total = getTotalCheckout();
    $('.total').text('$' + total)
    $('.total').attr('data-total', total)
} 

//Inicia el flujo de funciones
const setCheckout = valIVA => {
    iva = valIVA;
    setItems()
    setTotalCheckout()
}

const searchCupon = codigo => {
    let query = codigo;
    const filteredItems = cuponesLab.filter(item => item.codigo === query);
    return filteredItems[0];
}

const visualizarDescuento = descuento => $('#descuento-cupon').text('$'+descuento)

const aplicarCuponDescuento = porcentaje => {
    let total = getPrecioItems();
    descuentoCupon = total * (porcentaje / 100);
    visualizarDescuento(descuentoCupon);
    setTotalCheckout();
}

const setCupon = () => {
    let codigoSelected = $('#txt-cupon').val();
    if (codigoSelected.length > 0) {
        let cupon = searchCupon(codigoSelected);
        if (cupon != null) {
            if (!isCuponActive) {
                aplicarCuponDescuento(cupon.porcentaje_descuento)

                Swal.fire({
                    icon: 'success',
                    title: '¡Cupón aplicado!',
                    text: `Ahora tienes un ${cupon.porcentaje_descuento}% de descuento en tu compra`,
                    showConfirmButton: false,
                    timer: 2000
                })

                isCuponActive = true;
            } else {
                Swal.fire({
                    icon: 'warning',
                    title: 'No puedes aplicar más de 1 cupón por compra',
                    showConfirmButton: false,
                    timer: 2000
                })
            }
        } else {
            Swal.fire({
                icon: 'warning',
                title: 'Cupón no valido',
                showConfirmButton: false,
                timer: 2000
            })
        }
    } else {
        Swal.fire({
            icon: 'warning',
            title: 'Ingresa un cupon para continuar',
            showConfirmButton: false,
            timer: 2000
        })
    }
}

//Obtiene cupones del lab
const getCupones = () => {
    const lab = sessionStorage.getItem('view-lab');
    $.ajax({
        method: "GET",
        url: `https://nolimits-web.azurewebsites.net/api/Cupon/ObtenerTodos?idLab=${lab}`,
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            cuponesLab = response;
        }
    });
}

//Obtiene el IVA
const getIVA = () => {
    $.ajax({
        method: "GET",
        url: "https://nolimits-web.azurewebsites.net/api/Sistema/ObtenerData",
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            console.log(response[0].iva);
            setCheckout(response[0].iva);
        }
    });
}

//Obtiene el IVA
const getinfoRepresentante = () => {
    const lab = sessionStorage.getItem('view-lab')   ;
    $.ajax({
        method: "GET",
        url: `https://nolimits-web.azurewebsites.net/api/Representante/ObtenerRepresentante?idLab=${lab}`,
        contentType: "application/json:charset=utf-8",
        success: function (response) {
            infoRepresentanteLab = response[0]
        }
    });
}

//Obtiene el email del proveedor
const getEmailProveedor = () => infoRepresentanteLab.email;
const getCedulaDeclarante = () => infoRepresentanteLab.id

$(document).ready(function () {
    getIVA();
    getinfoRepresentante();
    getCupones();
})

const clearCarrito = () => sessionStorage.removeItem(`examenesCarrito${currentLab}`);

const createFacturaExamenes = () => {

    const generarFecha = () => {
        let today = new Date();
        return today.toLocaleString();
    }
    const generarID = () => Math.floor(100000 + Math.random() * 900000);
    const generarNumeracion = () => Math.floor(1000 + Math.random() * 900000);
    const generarClave = () => Math.floor(30000 + Math.random() * 900000);
    const generarDetalle = () => {
        let detalle = 'Compra de examenes: '
        $(".examen-name").each(function () {
            detalle += $(this).attr("data-val") + ',';
        });
        return detalle;
    }

    let clave = generarClave();
    let detalle = generarDetalle();

    let data = {
        id: generarID(),
        declarante: getCedulaDeclarante(),
        usuario: user.id,
        tipo: 'Factura Electronica',
        numeracion: generarNumeracion(),
        clave_numerica: clave,
        condicion_venta: 'Al contado',
        medio_pago: 'Tarjeta',
        detalle: detalle,
        descuentos: `${descuentoCupon}`,
        subtotal: getPrecioItems(),
        impuesto: getPrecioIVA(),
        precio_neto: getPrecioItems(),
        total: getTotalCheckout(),
        moneda: '$'
    }

    $.ajax({
        type: 'POST',
        url: `https://nolimits.azurewebsites.net/Home/SendFactura?destino=${user.email}&clave=${clave}&detalle=${detalle}&descuento=${descuentoCupon}&impuesto=$ ${getPrecioIVA()}&total$ ${getTotalCheckout()}=&fecha=${generarFecha()}`,
        traditional: true,
        data: data,
        content: "application/json;",
        dataType: "json",
    });

    $.ajax({
        type: 'POST',
        url: 'https://nolimits-web.azurewebsites.net/api/Factura/CrearFactura',
        traditional: true,
        data: data,
        content: "application/json;",
        dataType: "json",
        success: function () {
            Swal.fire({
                title: 'Factura enviada por correo electrónico',
                text: "Deseas agendar tus examenes?",
                icon: 'success',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Quizá más tarde',
                confirmButtonText: 'Si'
            }).then((result) => {
                
                if (result.isConfirmed) {
                    window.location.href = '/Citas/AgendarCita';
                } else {
                    window.location.href = '/';
                }
            })
        }
    });


}

const createCitasPorAgendar = () => {
    $(".id-examen").each(function () {
        let data = {
            id_examen: $(this).attr('id'),
            id_usuario: user.id,
            id_lab: currentLab
        }

        console.log(data)

        $.ajax({
            type: 'POST',
            url: 'https://nolimits-web.azurewebsites.net/api/Sistema/CrearCitaPendiente',
            data: data,
            content: "application/json;",
            dataType: "json",
        });

        clearCarrito();
    });
}

paypal.Buttons({
    createOrder: (data, actions) => {
        return actions.order.create({
            purchase_units: [{
                amount: {
                    value: getTotalCheckout()
                },
                payee: {
                    email_address: getEmailProveedor()
                }
            }]
        });
    },
    style: {
        layout: 'horizontal',
        height: 40,
        color: "blue",
        label: 'pay',
    },
    onApprove: (data, actions) => {
        return actions.order.capture().then(function (orderData) {
            createCitasPorAgendar();
            createFacturaExamenes();
        });
    },
    button_config: {
        text: 'Pagar'
    },
}).render('#paypal-button-container');