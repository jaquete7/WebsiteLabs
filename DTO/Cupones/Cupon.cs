using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Cupones
{
    public class Cupon : EntidadBase
    {
        public int id_laboratorio { get; set; }
        public string nombre { get; set; }
        public string codigo { get; set; }

        public int porcentaje_descuento { get; set; }
        public string fecha_caducidad { get; set; }
        public string fecha_registro { get; set; }
        public string estado { get; set; }
    }
}
