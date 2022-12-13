using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sede : EntidadBase
    {
        public string nombre { get; set; }
       
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public string fecha_registro { get; set; }

        public int id_laboratorio { get; set; }
    }
}
