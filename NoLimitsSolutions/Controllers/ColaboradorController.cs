using AppLogic;
using DTO.Examenes;
using DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NoLimitsSolutions.Controllers
{
    public class ColaboradorController : ApiController
    {
        [HttpPost]
        //public String Registrar(String id, String nombre, String telefono, String provincia, String canton, String distrito, String direccion, String correo, String password)
        public string Registrar(Colaborador colaborador)

        {
            //Proveedor proveedor = new Proveedor();
            AdminColaborador admin = new AdminColaborador();

            admin.Registrar(colaborador);

            return "Todo funciona";
        }

        [HttpGet]
        public List<Colaborador> DevolverTodosColaboradores(int id)
        {
            AdminColaborador admin = new AdminColaborador();

            return admin.DevolverTodosColaboradores(id);
        }
    }
}
