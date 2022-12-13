using DataAccess.CRUD;
using DataAccess.CRUD.Examenes;
using DTO;
using DTO.Examenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.Usuarios
{
    public class usuariosAdmin
    {
        public List<Usuario> DevolverTodosUsuarios()
        {
            UsuarioCrudFactory usuarioCrud = new UsuarioCrudFactory();
            return usuarioCrud.RetrieveAll<Usuario>();
        }

        public List<Usuario> ObtenerUsuario(int id)
        {
            UsuarioCrudFactory crud = new UsuarioCrudFactory();
            return crud.RetrievebyUser<Usuario>(id);
        }

        public string EditarUsuario(int id, Usuario usuario)
        {
            UsuarioCrudFactory crud = new UsuarioCrudFactory();
            crud.Editar(id,usuario);

            return "Usuario Editado con exito";
        }
        public string EliminarUsuario(int id)
        {
            UsuarioCrudFactory crud = new UsuarioCrudFactory();
            crud.Eliminar(id);

            return "Usuario Eliminado con exito";
        }

    }
}
