using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Resultado : EntidadBase
    {
        public int id_cita { get; set; }
        public int id_usuario { get; set; }
        public string descripcion{ get; set; }
        public string evaluacion { get; set; }
    }
}
