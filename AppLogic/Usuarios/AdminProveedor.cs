using DataAccess.CRUD;
using DTO;
using DTO.Usuarios;
using System.Collections.Generic;

namespace AppLogic
{
    public class AdminProveedor
    {
        public string Registrar(Proveedor proveedor)
        {
            ProveedorCrudFactory crud = new ProveedorCrudFactory();
            crud.Create(proveedor);

            return "Proveedor registrado con exito";
        }

        public List<ReporteDashProveedor> GetDataDashboard(int idLab)
        {
            ProveedorCrudFactory crud = new ProveedorCrudFactory();
            return crud.RetrieveGetDataDashboard<ReporteDashProveedor>(idLab);
        }

        public List<Meses> GetDataMeses(int idLab)
        {
            ProveedorCrudFactory crud = new ProveedorCrudFactory();
            return crud.RetrieveGetDataMeses<Meses>(idLab);
        }
    }
}
