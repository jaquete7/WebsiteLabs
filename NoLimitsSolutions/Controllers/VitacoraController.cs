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
    public class VitacoraController : ApiController
    {
        [HttpGet]
        public List<Vitacora> Obtener()
        {
            AdminVitacora admin = new AdminVitacora();
            return admin.Obtener();
        }
    }
}
