using AppLogic;
using AppLogic.Usuarios;
using DTO.Examenes;
using DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;


namespace NoLimitsSolutions.Controllers
{
    public class ExamenController : ApiController
    {
        [HttpPost]
        public string Registrar(Examen examen)
        {
            AdminExamen admin = new AdminExamen();
            
            
            return admin.Registrar(examen);
        }

        [HttpPut]
        public string EditarExamen(int idlab,string idexam, Examen examen)
        {
            AdminExamen admin = new AdminExamen();

            return admin.EditarExamen(idexam,idlab,examen);
        }

        [HttpGet]
        public List<Examen> DevolverTodosExamenes(int idlab)
        {
            AdminExamen admin = new AdminExamen();

            return admin.DevolverTodosExamenes(idlab);
        }

        [HttpGet]
        public List<Examen> DevolverExamen(int idlab, string idExam)
        {
            AdminExamen admin = new AdminExamen();

            return admin.ObtenerExamen(idExam,idlab);
        }

        [HttpDelete]
        public string EliminarExamen(int idLab, string idExam)
        {
            AdminExamen admin = new AdminExamen();

            return admin.EliminarExamen(idLab,idExam);
        }

    }
    }

