using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Roles : EntidadBase
    {
        public string nombre{ get; set; }
        public string permisos { get; set; }
        public int laboratorio { get; set; }
    }
}
