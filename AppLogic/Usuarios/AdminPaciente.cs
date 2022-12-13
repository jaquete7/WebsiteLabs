using DataAccess.CRUD;
using DTO;
using DTO.Usuarios;
using System.Collections.Generic;

namespace AppLogic.Usuarios
{
    public class AdminPaciente
    {

        public string Registrar(Paciente paciente)
        {
            PacienteCrudFactory crud = new PacienteCrudFactory();
            crud.Create(paciente);

            return "Paciente registrado con exito";
        }

        public string Actualizar(Paciente paciente)
        {
            PacienteCrudFactory crud = new PacienteCrudFactory();
            crud.Update(paciente);
            return "Paciente actualizado con exito";
        }

        public string ActualizarEstado(Paciente paciente)
        {
            PacienteCrudFactory crud = new PacienteCrudFactory();
            crud.UpdateEstado(paciente);
            return "Paciente actualizado con exito";
        }

        public Paciente ObtenerPaciente(int Id)
        {
            PacienteCrudFactory crud = new PacienteCrudFactory();

            return crud.RetrieveById<Paciente>(Id);
            
           
        }

        public List<Dictionary<string, object>> MostrarCitasPendientes(Usuario usuario)
        {
            UsuarioCrudFactory crud = new UsuarioCrudFactory();

            return crud.MostrarCitasPendientes(usuario);
        }
        public List<Dictionary<string, object>> MostrarCitasAgendadas(Usuario usuario)
        {
            UsuarioCrudFactory crud = new UsuarioCrudFactory();

            return crud.MostrarCitasAgendadas(usuario);
        }

        public List<Dictionary<string, object>> AgendarCitasPendientes(Citas citas)
        {
            UsuarioCrudFactory crud = new UsuarioCrudFactory();

            return crud.AgendarCita(citas);
        }
        

        public List<Dictionary<string, object>> ReAgendarCitasAgendadas(Citas citas)
        {
            UsuarioCrudFactory crud = new UsuarioCrudFactory();

            return crud.ReAgendarCita(citas);
        }
        public List<ReporteDashPaciente> GetDataDashboard(int idUsua)
        {
            PacienteCrudFactory crud = new PacienteCrudFactory();
            return crud.RetrieveGetDataDashboard<ReporteDashPaciente>(idUsua);
        }

        public List<MesesPaciente> GetDataMesesPaciente(int idUsua)
        {
            PacienteCrudFactory crud = new PacienteCrudFactory();
            return crud.RetrieveGetDataMesesPaciente<MesesPaciente>(idUsua);
        }
    }
}
