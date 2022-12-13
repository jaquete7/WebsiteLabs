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


namespace NoLimitsSolutions.Controllers
{
    public class PacienteController : ApiController
    {
        [HttpPost]
        public string Registrar(Paciente paciente)
        {
            AdminPaciente admin = new AdminPaciente();
            

            admin.Registrar(paciente);

            return "Todo funciona";
        }
        [HttpGet]
        public List<Dictionary<string, object>> MostrarCitasPendientes(string id_usuario)
        {
            AdminPaciente admin = new AdminPaciente();
            Usuario usuario = new Usuario();
            usuario.id_usuario = Convert.ToInt32(id_usuario);
            return admin.MostrarCitasPendientes(usuario);
        }
        [HttpPost]
        public List<Dictionary<string, object>> AgendarCitasPendientes(string id_cita, string fecha)
        {
            AdminPaciente admin = new AdminPaciente();
            Citas cita = new Citas();
            cita.idCita = id_cita;
            cita.fecha = fecha;
            return admin.AgendarCitasPendientes(cita);
        }

        [HttpGet]
        public List<Dictionary<string, object>> MostrarCitasAgendadas(string id_usuario)
        {
            AdminPaciente admin = new AdminPaciente();
            Usuario usuario = new Usuario();
            usuario.id_usuario = Convert.ToInt32(id_usuario);
            return admin.MostrarCitasAgendadas(usuario);
        }
        [HttpPost]
        public List<Dictionary<string, object>> ReAgendarCitasAgendadas(string id_cita, string fecha)
        {
            AdminPaciente admin = new AdminPaciente();
            Citas cita = new Citas();
            cita.idCita = id_cita;
            cita.fecha = fecha;
            return admin.ReAgendarCitasAgendadas(cita);
        }


        [HttpPost]

        public string Actualizar(Paciente paciente) 
        {
            AdminPaciente admin = new AdminPaciente();
            admin.Actualizar(paciente);

            return "Todo funciona";
        }

        [HttpPost]

        public string ActualizarEstado(Paciente paciente)
        {
            AdminPaciente admin = new AdminPaciente();
            admin.ActualizarEstado(paciente);

            return "Todo funciona";
        }


        [HttpGet]

        public Paciente ObtenerUsuario(int id)
        {
            AdminPaciente admin = new AdminPaciente();
            Paciente paciente = admin.ObtenerPaciente(id);

            return paciente;
        }

        [HttpGet]
        public List<ReporteDashPaciente> ObtenerDatosDashboard(int idUsua)
        {
            AdminPaciente admin = new AdminPaciente();
            return admin.GetDataDashboard(idUsua);
        }

        [HttpGet]
        public List<MesesPaciente> ObtenerDatosMeses(int idUsua)
        {
            AdminPaciente admin = new AdminPaciente();
            return admin.GetDataMesesPaciente(idUsua);
        }
    }
}
