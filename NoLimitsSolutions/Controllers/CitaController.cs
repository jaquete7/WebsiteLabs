using AppLogic;
using AppLogic.Laboratorios;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoLimitsSolutions.Controllers
{
    public class CitaController : ApiController
    {
        
        [HttpGet]
        public List<CitaPendiente> ObtenerTodasCitas(int idLab)
        {

            AdminSistema admin = new AdminSistema();
            return admin.ObtenerTodasCitas(idLab); ;
        }
        
    }
}
