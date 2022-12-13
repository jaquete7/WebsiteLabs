using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ReporteDashboardMapper : ICrudStatements, IObjectMapper
    {
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var r = new ReporteDashboard()
            {
                proveedores = int.Parse(row["proveedores"].ToString()),
                ingresos = float.Parse(row["ingresos"].ToString()),
                pacientes = int.Parse(row["pacientes"].ToString())
            };
            return r;
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

        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetRetrieve()
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerReporteDashboardAdmin"
            };

            return operation;
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
