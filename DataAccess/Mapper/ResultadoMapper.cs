using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ResultadoMapper : ICrudStatements, IObjectMapper
    {
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var f = new Resultado()
            {
                id_cita = int.Parse(row["id_cita"].ToString()),
                descripcion = row["descripcion"].ToString(),
                evaluacion = row["evaluacion"].ToString(),
               
            };

            return f;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var rol = BuildObject(row);
                listResuts.Add(rol);
            }
            return listResuts;
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearResultado"
            };

            var f = (Resultado)entidadDTO;
            operation.AddIntegerParam("id_cita", f.id_cita);
            
            operation.AddVarcharParam("descripcion", f.descripcion);
            operation.AddVarcharParam("evaluacion", f.evaluacion);
            

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
                ProcedureName = "SP_ObtnerFacturas"
            };
            operation.AddIntegerParam("idUsuario", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }
    }
}
