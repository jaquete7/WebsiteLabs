using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper.Usuarios
{
    public class ReporteDashboardPacienteMapper : ICrudStatements, IObjectMapper
    {
        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var usua = new ReporteDashPaciente()
            {
                citas_agendadas = int.Parse(row["citas_agendadas"].ToString()),
                citas_pendientes = int.Parse(row["citas_pendientes"].ToString()),
            };
            return usua;
        }

        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var usua = BuildObjectID(row);
                lstResults.Add(usua);
            }

            return lstResults;
        }
        public SqlOperation GetRetrieve(int idUsua)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerReporteDashboarUsuario"
            };
            operation.AddIntegerParam("idUsua", idUsua);

            return operation;
        }

        public SqlOperation GetRetrieveMesesPaciente(int idUsua)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerMesesUsuario"
            };
            operation.AddIntegerParam("idUsua", idUsua);

            return operation;
        }

        public EntidadBase BuildObjectMesesPacienteID(Dictionary<string, object> row)
        {
            var meses = new MesesPaciente()
            {
                enero = int.Parse(row["enero"].ToString()),
                febrero = int.Parse(row["febrero"].ToString()),
                marzo = int.Parse(row["marzo"].ToString()),
                abril = int.Parse(row["abril"].ToString()),
                mayo = int.Parse(row["mayo"].ToString()),
                junio = int.Parse(row["junio"].ToString()),
                julio = int.Parse(row["julio"].ToString()),
                agosto = int.Parse(row["agosto"].ToString()),
                septiembre = int.Parse(row["septiembre"].ToString()),
                octubre = int.Parse(row["octubre"].ToString()),
                noviembre = int.Parse(row["noviembre"].ToString()),
                diciembre = int.Parse(row["diciembre"].ToString())
            };
            return meses;
        }

        public List<EntidadBase> BuildObjectsMesesPacienteID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var meses = BuildObjectMesesPacienteID(row);
                lstResults.Add(meses);
            }

            return lstResults;
        }
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            throw new NotImplementedException();
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
