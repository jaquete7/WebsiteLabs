using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CitaPendiente : EntidadBase
    {
        public int id_cita { get; set; }
        public int id_examen { get; set; }
        public int id_usuario { get; set; }
        public int id_lab { get; set; }
        
        public string fecha { get; set; }
        public string estado { get; set; }
    }
}
