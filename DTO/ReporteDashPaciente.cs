using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReporteDashPaciente : EntidadBase
    {
        public int citas_agendadas { get; set; }
        public int id_usuario { get; set; }
        public int citas_pendientes { get; set; }
    }
}
