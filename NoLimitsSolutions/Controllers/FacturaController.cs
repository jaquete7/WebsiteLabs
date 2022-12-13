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
    public class FacturaController : ApiController
    {
        [HttpPost]
        public string CrearFactura(Factura factura)
        {
            AdminFactura admin = new AdminFactura();
            return admin.Registrar(factura);
        }

        [HttpGet]
        public List<Factura> ObtenerFacturas(int idUsuario)
        {
            AdminFactura admin = new AdminFactura();
            return admin.ObtenerFacturas(idUsuario);
        }
    }
}
