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
    public class RepresentanteController : ApiController
    {
        [HttpGet]
        public List<Representante> ObtenerRepresentante(int idLab)
        {
            AdminRepresentante admin = new AdminRepresentante();
            return admin.Obtener(idLab);
        }
    }
}
