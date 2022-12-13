using AppLogic;
using AppLogic.Cupones;
using DTO.Cupones;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Http;

namespace NoLimitsSolutions.Controllers
{
    public class CuponController : ApiController
    {
        [HttpPost]
        public string Registrar(Cupon cupon)
        {
            AdminCupon admin = new AdminCupon();
            return admin.Registrar(cupon);
        }

        [HttpGet]
        public List<Cupon> ObtenerTodos(int idLab)
        {
            AdminCupon admin = new AdminCupon();
            return admin.Obtener(idLab); 
        }

        [HttpPut]
        public string EditarCupon(int idCup, int idLab, Cupon cupon)
        {
            AdminCupon admin = new AdminCupon();

            return admin.EditarCupon(idCup, idLab, cupon);
        }

        [HttpGet]
        public List<Cupon> DevolverCupon(int idCup, int idLab)
        {
            AdminCupon admin = new AdminCupon();

            return admin.ObtenerCupon(idCup, idLab);
        }

        [HttpDelete]
        public string EliminarCupon(int idCup, int idLab)
        {
            AdminCupon admin = new AdminCupon();

            return admin.EliminarCupon(idCup, idLab);
        }
    }
}