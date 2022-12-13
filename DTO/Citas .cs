using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Citas : EntidadBase
    {
        public string idCita { get; set; }
        public string estado { get; set; }
        public string nombreExamen { get; set; }
        public string fecha { get; set; }
        
    }
}
