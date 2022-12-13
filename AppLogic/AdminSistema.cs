using AppLogic.Laboratorios;
using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppLogic
{
    public class AdminSistema
    {
        public List<DataSistema> GetAll()
        {
            SistemaCrudFactory crud = new SistemaCrudFactory();
            return crud.RetrieveAll<DataSistema>();
        }
        public List<ReporteDashboard> GetDataDashboard()
        {
            SistemaCrudFactory crud = new SistemaCrudFactory();
            return crud.RetrieveGetDataDashboard<ReporteDashboard>();
        }
        public string CrearCitaPendiente(CitaPendiente c)
        {
            SistemaCrudFactory crud = new SistemaCrudFactory();
            crud.CreateCitaPendiente(c);

            return "Creado con exito";
        }

        [HttpGet]
        public List<CitaPendiente> ObtenerTodasCitas(int idLab)
        {

            SistemaCrudFactory crud = new SistemaCrudFactory();
            return crud.RetrieveAllCitasById<CitaPendiente>(idLab);

        }   

        public string EditarMembresia(DataSistema membresia)
        {
            SistemaCrudFactory crud = new SistemaCrudFactory();
            crud.EditarMebresia(membresia);

            return "Membresia Editado con exito";
        }

        public string EditarIva(DataSistema iva)
        {
            SistemaCrudFactory crud = new SistemaCrudFactory();
            crud.EditarIva(iva);

            return "Iva Editado con exito";
        }
    }
}
