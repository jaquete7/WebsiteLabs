using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Factura : EntidadBase
    {
        public int declarante { get; set; }
        public int usuario { get; set; }
        public string tipo { get; set; }
        public int numeracion { get; set; }
        public int clave_numerica { get; set; }
        public string fecha_emicion { get; set; }
        public string hora_emicion { get; set; }
        public string condicion_venta { get; set; }
        public string medio_pago { get; set; }
        public string detalle { get; set; }
        public string descuentos { get; set; }
        public int subtotal { get; set; }
        public int impuesto { get; set; }
        public int precio_neto { get; set; }
        public int total { get; set; }
        public string moneda { get; set; }

    }
}
