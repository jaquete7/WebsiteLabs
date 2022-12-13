using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReporteDashProveedor : EntidadBase
    {
        public float ingresos { get; set; }
        public int id_laboratorio { get; set; }
        public int compras{ get; set; }
    }
}
