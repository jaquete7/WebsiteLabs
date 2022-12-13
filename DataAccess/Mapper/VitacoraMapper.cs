using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class VitacoraMapper : ICrudStatements, IObjectMapper
    {
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var v = new Vitacora()
            {
                descripcion = row["descripcion"].ToString(),
                actividad = row["accion"].ToString(),
                fecha = row["fecha_registro"].ToString(),
            };

            return v;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var v = BuildObject(row);
                listResuts.Add(v);
            }
            return listResuts;
        }

        public SqlOperation GetAllRetrieve()
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerVitacora"
            };
            return operation;
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
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }
    }
}
