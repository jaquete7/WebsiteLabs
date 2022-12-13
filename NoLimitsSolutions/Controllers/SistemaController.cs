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
    public class SistemaController : ApiController
    {
        [HttpGet]
        public List<DataSistema> ObtenerData ()
        {
            AdminSistema admin = new AdminSistema();
            return admin.GetAll();
        }

        [HttpGet]
        public List<ReporteDashboard> ObtenerDatosDashboard()
        {
            AdminSistema admin = new AdminSistema();
            return admin.GetDataDashboard();
        }

        [HttpPost]
        public string CrearCitaPendiente(CitaPendiente c)
        {
            AdminSistema admin = new AdminSistema();
            return admin.CrearCitaPendiente(c);
        }

        [HttpPut]
        public string EditarMembresia(DataSistema membresia)
        {
            AdminSistema admin = new AdminSistema();

            return admin.EditarMembresia(membresia);
        }

        [HttpPut]
        public string EditarIva(DataSistema iva)
        {
            AdminSistema admin = new AdminSistema();

            return admin.EditarIva(iva);
        }
    }
}
