using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Usuario : EntidadBase
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string password { get; set; }
        public string ruta_foto { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public string estado { get; set; }
        public string fecha_registro { get; set; }
        public string rol { get; set; }
        public int idrol { get; set; }
        public string permisos { get; set; }

    }
}
