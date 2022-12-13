using AppLogic;
using AppLogic.Laboratorios;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoLimitsSolutions.Controllers
{
    public class SedeController : ApiController
    {
        // GET: Sede
        [HttpPost]
        public string Registrar(Sede sede)

        {
            AdminSede admin = new AdminSede();

            admin.Registrar(sede);

            return "Todo funciona";
        }

        [HttpGet]
        public List<Sede> ObtenerTodos(int idLab)
        {

            AdminSede admin = new AdminSede();
            return admin.Obtener(idLab); 
        }

        [HttpPut]
        public string EditarSede(int idSede, int idLab,  Sede sede)
        {
            AdminSede admin = new AdminSede();

            return admin.EditarSede(idSede, idLab, sede);
        }

        [HttpGet]
        public List<Sede> DevolverSede(int idSede, int idLab)
        {
            AdminSede admin = new AdminSede();

            return admin.ObtenerSede(idSede, idLab);
        }

        [HttpDelete]
        public string EliminarSede(int idSede, int idLab)
        {
            AdminSede admin = new AdminSede();

            return admin.EliminarSede(idSede, idLab);
        }
    }
}