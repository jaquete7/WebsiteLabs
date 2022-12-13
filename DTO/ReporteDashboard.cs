using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReporteDashboard : EntidadBase
    {
        public float ingresos { get; set; }
        public int proveedores { get; set; }
        public int pacientes { get; set; }
    }
}
