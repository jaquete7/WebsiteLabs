using AppLogic;
using DTO;
using DTO.Usuarios;
using System.Collections.Generic;
using System.Web.Http;

namespace NoLimitsSolutions.Controllers
{
    public class ProveedorController : ApiController
    {
        [HttpPost]
        public string Registrar(Proveedor proveedor)

        {
            //Proveedor proveedor = new Proveedor();
            AdminProveedor admin = new AdminProveedor();

            admin.Registrar(proveedor);

            return "Todo funciona";
        }

        [HttpGet]
        public List<ReporteDashProveedor> ObtenerDatosDashboard(int idLab)
        {
            AdminProveedor admin = new AdminProveedor();
            return admin.GetDataDashboard(idLab);
        }

        [HttpGet]
        public List<Meses> ObtenerDatosMeses(int idLab)
        {
            AdminProveedor admin = new AdminProveedor();
            return admin.GetDataMeses(idLab);
        }
    }
}
