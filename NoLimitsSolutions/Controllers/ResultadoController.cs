using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoLimitsSolutions.Controllers
{
    public class ResultadoController : ApiController
    {
        [HttpPost]
        public string CrearResultado(Resultado resultado)
        {
            AdminResultado admin = new AdminResultado();
            return admin.Registrar(resultado);
        }
        [HttpGet]
        public List<Resultado> ObtenerResultados(int idUsuario)
        {
            AdminResultado admin = new AdminResultado();
            return admin.ObtenerResultados(idUsuario);
        }
    }
}
