using AppLogic.Laboratorios;
using DTO.Laboratorios;
using System.Web.Http;
using System.Collections.Generic;
using AppLogic;
using DTO.Examenes;

namespace NoLimitsSolutions.Controllers
{
    public class LaboratorioController : ApiController
    {
        [HttpPost]
        public string Registrar(Laboratorio laboratorio)
        {
            AdminLaboratorios admin = new AdminLaboratorios();
            laboratorio.ruta_fotos2 = "https://prueba.com";
            laboratorio.ruta_fotos3 = "https://prueba.com";
            laboratorio.ruta_fotos4 = "https://prueba.com";
            laboratorio.ruta_fotos5 = "https://prueba.com";
            return admin.Registrar(laboratorio);
        }

        [HttpGet]
        public List<Laboratorio> DevolverTodosPedidos()
        {
            AdminLaboratorios admin = new AdminLaboratorios();

            return admin.DevolverTodosPedidos();
        }

        [HttpGet]
        public List<Laboratorio> ObtenerTodosId(int idProv)
        {
            AdminLaboratorios admin = new AdminLaboratorios();
            return admin.Obtener(idProv); 
        }

        [HttpGet]
        public List<Laboratorio> ObtenerRepresentante(int idLab)
        {
            AdminLaboratorios admin = new AdminLaboratorios();
            return admin.ObtenerRepresentante(idLab);
        }

        [HttpPut]
        public string EditarLaboratorio(int idLab, int idProv, Laboratorio laboratorio)
        {
            AdminLaboratorios admin = new AdminLaboratorios();

            return admin.EditarLaboratorio(idLab, idProv, laboratorio);
        }

        [HttpGet]
        public List<Laboratorio> DevolverLaboratorio(int idLab, int idProv)
        {
            AdminLaboratorios admin = new AdminLaboratorios();

            return admin.ObtenerLaboratorio(idLab, idProv);
        }

        [HttpDelete]
        public string EliminarLaboratorio(int idLab, int idProv)
        {
            AdminLaboratorios admin = new AdminLaboratorios();

            return admin.EliminarLaboratorio(idLab, idProv);
        }
    }
}