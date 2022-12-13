using DataAccess.CRUD;
using DataAccess.CRUD.Examenes;
using DTO;
using DTO.Examenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminRoles
    {
        public string Registrar(Roles rol)
        {
            RolesCrudFactory crud = new RolesCrudFactory();
            crud.Create(rol);

            return "Rol registrado con exito";
        }
        public List<Roles> Obtener(int idLab)
        {
            RolesCrudFactory crud = new RolesCrudFactory();
            return crud.RetrieveAllByLab<Roles>(idLab);
        }

        public string EditarRol(int idlab, int idrol, Roles rol)
        {
            RolesCrudFactory crud = new RolesCrudFactory();
            crud.Editar(idlab,idrol,rol);

            return "Examen Editado con exito";
        }

        public List<Roles> ObtenerRol(int idlab, int idrol)
        {
            RolesCrudFactory crud = new RolesCrudFactory();
            return crud.RetrieveByRol<Roles>(idlab, idrol);
        }

        public string EliminarRol(int idLab, int idRol)
        {
            RolesCrudFactory crud = new RolesCrudFactory();
            crud.Eliminar(idLab, idRol);

            return "Rol Eliminado con exito";
        }
    }
}
