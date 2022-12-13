using DataAccess.DAO;
using DTO;
using DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Usuarios
{
    public class PacienteMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos CRUD
        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearPaciente"
            };

            var paciente = (Paciente)entidadDTO;
            operation.AddIntegerParam("id", paciente.id);
            operation.AddVarcharParam("nombre", paciente.nombre);
            operation.AddVarcharParam("email", paciente.email);
            operation.AddVarcharParam("celular", paciente.celular);
            operation.AddVarcharParam("password", paciente.password);
            operation.AddVarcharParam("provincia", paciente.provincia);
            operation.AddVarcharParam("canton", paciente.canton);
            operation.AddVarcharParam("distrito", paciente.distrito);
            operation.AddVarcharParam("direccion", paciente.direccion);
            operation.AddVarcharParam("ruta_foto", paciente.ruta_foto);
            //operation.AddVarcharParam("", paciente.rol);

            return operation;
        }

        public SqlOperation GetDeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {

            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerPaciente"
            };



            operation.AddIntegerParam("idUsuario", id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ActualizarUsuario"
            };

            var paciente = (Paciente)entidadDTO;

            operation.AddIntegerParam("id", paciente.id);
            operation.AddVarcharParam("nombre", paciente.nombre);
            operation.AddVarcharParam("email", paciente.email);
            operation.AddVarcharParam("celular", paciente.celular);
            operation.AddVarcharParam("password", paciente.password);
            operation.AddVarcharParam("provincia", paciente.provincia);
            operation.AddVarcharParam("canton", paciente.canton);
            operation.AddVarcharParam("distrito", paciente.distrito);
            operation.AddVarcharParam("direccion", paciente.direccion);
            operation.AddVarcharParam("ruta_foto", paciente.ruta_foto);


            return operation;
        }

        public SqlOperation GetUpdateStatementEstado(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ActualizarEstadoUsuario"
            };

            var paciente = (Paciente)entidadDTO;

            operation.AddIntegerParam("id", paciente.id);
          
            return operation;
        }
        #endregion

        #region Object Mappers
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var usuario = new Paciente()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                rol = row["rol"].ToString(),
                fecha_registro = row["fecha_registro"].ToString(),
                email = row["email"].ToString(),
                celular = row["celular"].ToString(),
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
        #endregion
    }
}
