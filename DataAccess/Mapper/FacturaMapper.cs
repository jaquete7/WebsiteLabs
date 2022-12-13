using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class FacturaMapper : ICrudStatements, IObjectMapper
    {
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var f = new Factura()
            {
                id = int.Parse(row["id"].ToString()),
                declarante = int.Parse(row["id_declarante"].ToString()),
                usuario = int.Parse(row["id_usuario"].ToString()),
                total = int.Parse(row["total"].ToString()),
            };

            return f;
        }
        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var f = new Factura()
            {
                id = int.Parse(row["id"].ToString()),
                fecha_emicion = row["fecha_emision"].ToString(),
                detalle = row["detalle"].ToString(),
                total = int.Parse(row["total"].ToString()),
            };

            return f;
        }
        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var rol = BuildObjectID(row);
                listResuts.Add(rol);
            }
            return listResuts;
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
                ProcedureName = "SP_CrearFactura"
            };

            var f = (Factura)entidadDTO;
            operation.AddIntegerParam("id", f.id);
            operation.AddIntegerParam("idDeclarante", f.declarante);
            operation.AddIntegerParam("idUsuario", f.usuario);
            operation.AddVarcharParam("tipo", f.tipo);
            operation.AddIntegerParam("numeracion", f.numeracion);
            operation.AddIntegerParam("clave_numerica", f.clave_numerica);
            operation.AddVarcharParam("condicion_venta", f.condicion_venta);
            operation.AddVarcharParam("medio_pago", f.medio_pago);
            operation.AddVarcharParam("detalle", f.detalle);
            operation.AddVarcharParam("descuentos", f.descuentos);
            operation.AddIntegerParam("sub_total", f.subtotal);
            operation.AddIntegerParam("impuesto", f.impuesto);
            operation.AddIntegerParam("precio_neto", f.precio_neto);
            operation.AddIntegerParam("total", f.total);
            operation.AddVarcharParam("moneda", f.moneda);

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
                ProcedureName = "SP_MostrarFacturas"
            };
            operation.AddIntegerParam("id", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }
    }
}
