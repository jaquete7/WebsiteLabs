using AppLogic;
using AppLogic.Usuarios;
using DTO;
using DTO.Examenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace NoLimitsSolutions.Controllers
{
    public class UsuariosAdminController : ApiController
    {

        [HttpGet]
        public List<Usuario> DevolverTodosUsuarios()
        {
            usuariosAdmin admin = new usuariosAdmin();

            return admin.DevolverTodosUsuarios();
        }

        [HttpGet]
        public List<Usuario> DevolverUser(int id)
        {
            usuariosAdmin admin = new usuariosAdmin();

            return admin.ObtenerUsuario(id);
        }

        [HttpPut]
        public string EditarUsuario(int id,Usuario usuario)
        {
            usuariosAdmin admin = new usuariosAdmin();

            return admin.EditarUsuario(id,usuario);
        }

        [HttpDelete]
        public string EliminarUsuario(int id)
        {
            usuariosAdmin admin = new usuariosAdmin();

            return admin.EliminarUsuario(id);
        }
    }
}