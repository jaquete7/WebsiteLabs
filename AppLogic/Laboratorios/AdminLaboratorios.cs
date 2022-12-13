using DataAccess.CRUD.Laboratorios;
using DTO.Laboratorios;
using System.Collections.Generic;

namespace AppLogic.Laboratorios
{
    public class AdminLaboratorios
    {
        public string Registrar(Laboratorio laboratorio)
        {
            LaboratorioCrudFactory crud = new LaboratorioCrudFactory();
            crud.Create(laboratorio);

            return "Laboratorio registrado con exito";
        }

        public List<Laboratorio> DevolverTodosPedidos()
        {
            LaboratorioCrudFactory labCrud = new LaboratorioCrudFactory();

            return labCrud.RetrieveAll<Laboratorio>();
        }

        public List<Laboratorio> Obtener(int idProv)
        {
            LaboratorioCrudFactory crud = new LaboratorioCrudFactory();
            return crud.RetrieveAllById<Laboratorio>(idProv);
        }
        public List<Laboratorio> ObtenerRepresentante(int idLab)
        {
            LaboratorioCrudFactory crud = new LaboratorioCrudFactory();
            return crud.RetrieveRepresentante<Laboratorio>(idLab);
        }

        public string EditarLaboratorio(int idLab, int idProv, Laboratorio laboratorio)
        {
            LaboratorioCrudFactory crud = new LaboratorioCrudFactory();
            crud.Editar(idLab, idProv, laboratorio);

            return "Laboratorio Editado con exito";
        }
        public string EliminarLaboratorio(int idLab, int idProv)
        {
            LaboratorioCrudFactory crud = new LaboratorioCrudFactory();
            crud.Eliminar(idLab, idProv);

            return "Laboratorio Eliminado con exito";
        }

        public List<Laboratorio> ObtenerLaboratorio(int idLab, int idProv)
        {
            LaboratorioCrudFactory crud = new LaboratorioCrudFactory();
            return crud.RetrieveByLaboratorio<Laboratorio>(idLab, idProv);
        }
    }
}
