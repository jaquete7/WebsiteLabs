using DataAccess.CRUD;
using DataAccess.CRUD.Examenes;
using DTO.Examenes;
using DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminExamen
    {
        public string Registrar(Examen examen)
        {
            ExamenCrudFactory crud = new ExamenCrudFactory();
            crud.Create(examen);

            return "Examen registrado con exito";
        }

        public List<Examen> DevolverTodosExamenes(int idlab)
        {
            ExamenCrudFactory examenCrud = new ExamenCrudFactory();
            return examenCrud.RetrieveAll<Examen>(idlab);
        }

        public string EditarExamen(string idexam, int idlab, Examen examen)
        {
            ExamenCrudFactory crud = new ExamenCrudFactory();
            crud.Editar(idlab,idexam,examen);

            return "Examen Editado con exito";
        }
        public string EliminarExamen(int idLab, string idExam)
        {
            ExamenCrudFactory crud = new ExamenCrudFactory();
            crud.Eliminar(idLab,idExam);

            return "Examen Eliminado con exito";
        }

        public List<Examen> ObtenerExamen(string idexam, int idlab)
        {
            ExamenCrudFactory crud = new ExamenCrudFactory();
            return crud.RetrieveByExamen<Examen>(idlab,idexam);
        }
    }
}
