using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Examenes
{
    public class Examen : EntidadBase
    {
        public int id_laboratorio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public float precio  { get; set; }
        public string recomendaciones { get; set; }
        public string datos_evaluados { get; set; }
        public string fecha_registro { get; set; }
        public string estado { get; set; }
        public string idExamen { get; set; }
    }
}
