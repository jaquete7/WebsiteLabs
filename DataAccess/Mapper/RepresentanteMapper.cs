using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RepresentanteMapper : ICrudStatements, IObjectMapper
    {
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var r = new Representante()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                email = row["email"].ToString(),
            };

            return r;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var r = BuildObject(row);
                listResuts.Add(r);
            }
            return listResuts;
        }

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerRepresentanteLab"
            };
            operation.AddIntegerParam("idlab", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }
    }
}
