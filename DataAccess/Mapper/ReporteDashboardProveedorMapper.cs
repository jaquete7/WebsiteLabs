using DataAccess.DAO;
using DTO;
using DTO.Cupones;
using DTO.Usuarios;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class ReporteDashboardProveedorMapper : ICrudStatements, IObjectMapper
    {
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var r = new ReporteDashProveedor()
            {
                compras = int.Parse(row["compras"].ToString()),
                ingresos = float.Parse(row["ingresos"].ToString()),
                id_laboratorio = int.Parse(row["id_laboratorio"].ToString())
            };
            return r;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var proveedor = BuildObject(row);
                listResuts.Add(proveedor);
            }
            return listResuts;
        }

        public SqlOperation GetRetrieve(int idLab)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerReporteDashboarProveedor"
            };
            operation.AddIntegerParam("idLab", idLab);

            return operation;
        }

        public SqlOperation GetRetrieveMeses(int idLab)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerMeses"
            };
            operation.AddIntegerParam("idLab", idLab);

            return operation;
        }

        public EntidadBase BuildObjectMesesID(Dictionary<string, object> row)
        {
            var meses = new Meses()
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

        public List<EntidadBase> BuildObjectsMesesID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var meses = BuildObjectMesesID(row);
                lstResults.Add(meses);
            }

            return lstResults;
        }

        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var prov = new ReporteDashProveedor()
            {
                compras = int.Parse(row["compras"].ToString()),
                ingresos = float.Parse(row["ingresos"].ToString()),
            };
            return prov;
        }

        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var prov = BuildObjectID(row);
                lstResults.Add(prov);
            }

            return lstResults;
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
