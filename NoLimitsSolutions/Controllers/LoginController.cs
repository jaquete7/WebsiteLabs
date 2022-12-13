using AppLogic;
using AppLogic.Usuarios;
using DTO;
using DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace NoLimitsSolutions.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public List<Dictionary<string, object>> ValidarLogin(Usuario usuario)
        {
            UserLogin admin = new UserLogin();
            return admin.Login(usuario);
        }
    }
}
