using DataAccess.DAO;
using DTO;
using DTO.Examenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class DataSistemaMapper : ICrudStatements, IObjectMapper
    {
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var sistema = new DataSistema()
            {
                id = 0,
                iva = float.Parse(row["iva"].ToString()),
                membresia = float.Parse(row["costo_membresia"].ToString()),
            };
            return sistema;
        }

        public EntidadBase BuildObjectCita(Dictionary<string, object> row)
        {
            var cita = new CitaPendiente()
            {
                id_cita = int.Parse(row["id_cita"].ToString()),
                id_examen = int.Parse(row["id_examen"].ToString()),
                id_usuario = int.Parse(row["id_usuario"].ToString()),
                fecha = row["fecha_examen"].ToString(),
                estado = row["estado"].ToString(),
                id_lab = int.Parse(row["id_lab"].ToString()),

            };
            return cita;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var sistema = BuildObject(row);
                listResuts.Add(sistema);
            }
            return listResuts;
        }

        public List<EntidadBase> BuildObjectsCita(List<Dictionary<string, object>> listRows)
        {
            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var cita = BuildObjectCita(row);
                listResuts.Add(cita);
            }
            return listResuts;
        }

        public SqlOperation GetUpdateStatementMembresia(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ActualizarMembresia"
            };

            var membresia = (DataSistema)entidadDTO;
            operation.AddFloatParam("precio",membresia.membresia);

            return operation;
        }

        public SqlOperation GetUpdateStatementIva(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ActualizarIva"
            };
            var iva = (DataSistema)entidadDTO;
            operation.AddFloatParam("Iva", iva.iva);


            return operation;
        }

        public SqlOperation GetRetrieveAllStatament()
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_GetDataSistema"
            };

            return operation;
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }
        public SqlOperation GetCreateCitaPendiente(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearCitaPorAgendar"
            };

            var c = (CitaPendiente)entidadDTO;
            operation.AddIntegerParam("id_examen", c.id_examen);
            operation.AddIntegerParam("id_usuario", c.id_usuario);
            operation.AddIntegerParam("id_lab", c.id_lab);
            return operation;
        }

        public SqlOperation GetDeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }
        public SqlOperation GetRetrieveAllCitasById(int id)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerCitas_Por_Id"
            };
            operation.AddIntegerParam("idlab", id);

            return operation;
        }
        
    }
}
