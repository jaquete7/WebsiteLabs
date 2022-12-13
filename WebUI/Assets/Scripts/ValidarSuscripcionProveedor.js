
const generarID = () => Math.floor(100000 + Math.random() * 900000);
const generarNumeracion = () => Math.floor(1000 + Math.random() * 900000);
const generarClave = () => Math.floor(30000 + Math.random() * 900000);
const generarFecha = () => {
    var today = new Date(); 
    return today.toLocaleString();
}

const createFactura = () => {
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);
    const isSucess = urlParams.get('success');

    let clave = generarClave();
    let detalle = 'Suscripcion Mensual al Sistema NoLimits Solutions';

    if (isSucess == 'true') {

        const user = JSON.parse(sessionStorage.getItem('userData'));

        let data = {
            id: generarID(),
            declarante: 118330299,
            usuario: user.id,
            tipo: 'Factura Electronica',
            numeracion: generarNumeracion(),
            clave_numerica: clave,
            condicion_venta: 'Al contado',
            medio_pago: 'Tarjeta',
            detalle: detalle,
            descuentos: '0',
            subtotal: 30,
            impuesto: 4,
            precio_neto: 30,
            total: 34,
            moneda: '$'
        }
        
        $.ajax({
            type: 'POST',
            url: `https://nolimits.azurewebsites.net/Home/SendFactura?destino=${user.email}&clave=${clave}&detalle=${detalle}&descuento=0&impuesto=$4&total$34=&fecha=${generarFecha()}`,
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
                    position: 'center',
                    icon: 'success',
                    title: 'Factura enviada a tu correo electrónico',
                    showConfirmButton: false,
                    timer: 4000
                })
            }
        });


    }
}


$(document).ready(function () {
    createFactura();
})
