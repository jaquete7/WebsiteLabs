using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Usuarios
{
    public class Colaborador : Usuario
    {
        public int id_custom_rol { get; set; }
        public string permisos { get; set; }
        public int laboratorioColab { get; set; }
    }
}
