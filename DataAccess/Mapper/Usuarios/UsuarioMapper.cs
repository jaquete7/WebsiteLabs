using DataAccess.DAO;
using DTO;
using DTO.Examenes;
using DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Usuarios
{
    public class UsuarioMapper
    {
        
        public SqlOperation GetLoginStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "userLogin"
            };

            var usuario = (Usuario)entidadDTO;
            
            operation.AddVarcharParam("Correo", usuario.email);
            operation.AddVarcharParam("Contrasenna", usuario.password);
            
            return operation;
        }
        //aqui es para mostrar citas pendientes
        public SqlOperation GetMostrarCitaPendiente(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_MostrarCitaPendiente"
            };

            var usuario = (Usuario)entidadDTO;
            operation.AddIntegerParam("id_usuario", usuario.id_usuario);


            return operation;
        }
        public SqlOperation GetRetrieveAllStatement()
        {
            var operation = new SqlOperation()
            {

                ProcedureName = "SP_ListarUsuarios"

            };

            return operation;
        }
        public SqlOperation GetDeleteStatement(int id)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EliminarUsuario"

            };
            operation.AddIntegerParam("id", id);
            return operation;
        }
        public SqlOperation GetUpdateStatement(int id, EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ActualizarUsuario"
            };

            var usuario = (Usuario)entidadDTO;
            operation.AddIntegerParam("id", id);
            operation.AddVarcharParam("nombre", usuario.nombre);
            operation.AddVarcharParam("email", usuario.email);
            operation.AddVarcharParam("celular", usuario.celular);
            operation.AddVarcharParam("password", usuario.password);
            operation.AddVarcharParam("provincia", usuario.provincia);
            operation.AddVarcharParam("canton", usuario.canton);
            operation.AddVarcharParam("distrito", usuario.distrito);
            operation.AddVarcharParam("direccion", usuario.direccion);
            operation.AddVarcharParam("ruta_foto", usuario.ruta_foto);
            operation.AddIntegerParam("idrol", usuario.idrol);
            operation.AddVarcharParam("permisos", usuario.permisos);
            operation.AddVarcharParam("rol", usuario.rol);


            return operation;
        }

        public SqlOperation RetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_MostrarUsuario"

            };
            operation.AddIntegerParam("id", id);
            return operation;
        }

        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Usuario()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                rol = row["rol"].ToString(),
                fecha_registro = row["fecha_registro"].ToString(),
            };


            return usuario;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var usuarios = BuildObject(row);
                lstResults.Add(usuarios);
            }

            return lstResults;
        }

        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var usuario = new Usuario()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                provincia = row["provincia"].ToString(),
                canton = row["canton"].ToString(),
                distrito = row["distrito"].ToString(),
                direccion = row["direccion"].ToString(),
                celular = row["celular"].ToString(),
                email = row["email"].ToString(),
                password = row["password"].ToString(),
                ruta_foto = row["ruta_foto"].ToString(),
                rol = row["rol"].ToString(),
                idrol = int.Parse(row["id_custom_rol"].ToString()),
            };


            return usuario;
        }

        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var usuario = BuildObjectID(row);
                lstResults.Add(usuario);
            }

            return lstResults;
        
        }
        //aqui es para agendar citas pendientes
        public SqlOperation GetAgendarCitaPendiente(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_AgendarCita"
            };

            var cita = (Citas)entidadDTO;

            operation.AddIntegerParam("id_cita", Convert.ToInt32(cita.idCita));
            operation.AddVarcharParam("fecha", cita.fecha);


            return operation;
        }
        //aqui es para mostrar citas agendadas
        public SqlOperation GetMostrarCitaAgendada(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_MostrarCitaAgendada"
            };

            var usuario = (Usuario)entidadDTO;

            operation.AddIntegerParam("id_usuario", usuario.id_usuario);


            return operation;
        }
        

        //aqui es para agendar citas pendientes
        public SqlOperation GetReAgendarCitaAgendada(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ReAgendarCita"
            };

            var cita = (Citas)entidadDTO;

            operation.AddIntegerParam("id_cita", Convert.ToInt32(cita.idCita));
            operation.AddVarcharParam("fecha", cita.fecha);
            return operation;
        }
    }
}