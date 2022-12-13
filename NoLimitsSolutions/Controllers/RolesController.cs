using AppLogic;
using DTO;
using DTO.Examenes;
using System.Collections.Generic;
using System.Web.Http;

namespace NoLimitsSolutions.Controllers
{
    public class RolesController : ApiController
    {
        [HttpPost]
        public string Registrar(Roles rol)
        {
            AdminRoles admin = new AdminRoles();
            return admin.Registrar(rol); ;
        }

        [HttpGet]
        public List<Roles> ObtenerTodos(int idLab)
        {
            AdminRoles admin = new AdminRoles();
            return admin.Obtener(idLab); 
        }

        [HttpPut]
        public string EditarRol(int idlab, int idrol, Roles rol)
        {
            AdminRoles admin = new AdminRoles();

            return admin.EditarRol(idlab,idrol,rol);
        }

        [HttpGet]
        public List<Roles> DevolverRol(int idlab, int idrol)
        {
            AdminRoles admin = new AdminRoles();

            return admin.ObtenerRol(idlab,idrol);
        }

        [HttpDelete]
        public string EliminarRol(int idLab, int idRol)
        {
            AdminRoles admin = new AdminRoles();

            return admin.EliminarRol(idLab, idRol);
        }
    }
}
