using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Laboratorios
{
    public class Laboratorio : EntidadBase
    {
        public int id_proveedor { get; set; }
        public string nombre { get; set; }
        public string nombre_comercial { get; set; }
        public string cedula_juridica { get; set; }
        public string razon_social { get; set; }
        public string tel_contacto { get; set; }
        public string correo_electronico { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public string web_site { get; set; }
        public string url_facebook { get; set; }
        public string url_linkedin { get; set; }
        public string url_instagram { get; set; }
        public string url_twitter { get; set; }
        public string ruta_fotos1 { get; set; }
        public string ruta_fotos2 { get; set; }
        public string ruta_fotos3 { get; set; }
        public string ruta_fotos4 { get; set; }
        public string ruta_fotos5 { get; set; }
        public string horario_apertura { get; set; }
        public string horario_finalizacion { get; set; }
        public string fecha_registro { get; set; }
        public string estado { get; set; }
        public string email_representante { get; set; }
    }
}
