using DataAccess.DAO;
using DTO;
using DTO.Cupones;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper.Cupones
{
    public class CuponMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos CRUD
        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearCupon"
            };

            var cupon = (Cupon)entidadDTO;
            operation.AddIntegerParam("id_laboratorio", cupon.id_laboratorio);
            operation.AddVarcharParam("nombre", cupon.nombre);
            operation.AddVarcharParam("codigo", cupon.codigo);
            operation.AddIntegerParam("porcentaje_descuento", cupon.porcentaje_descuento);
            operation.AddVarcharParam("fecha_caducidad", cupon.fecha_caducidad);

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
        public SqlOperation GetAllRetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ListarCuponesId"
            };
            operation.AddIntegerParam("id_laboratorio", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(int idCup, int idLab, EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EditarCupon"
            };

            var cupon = (Cupon)entidadDTO;
            operation.AddIntegerParam("id", idCup);
            operation.AddIntegerParam("id_laboratorio", idLab);
            operation.AddVarcharParam("nombre", cupon.nombre);
            operation.AddVarcharParam("codigo", cupon.codigo);
            operation.AddIntegerParam("porcentaje_descuento", cupon.porcentaje_descuento);
            operation.AddVarcharParam("fecha_caducidad", cupon.fecha_caducidad);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int idCup, int idLab)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerCupon"

            };
            operation.AddIntegerParam("idCup", idLab);
            operation.AddIntegerParam("idLab", idCup);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int idCup, int idLab)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EliminarCupon"

            };
            operation.AddIntegerParam("idCup", idLab);
            operation.AddIntegerParam("idLab", idCup);
            return operation;
        }
        #endregion

        #region Object Mappers
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var cupon = new Cupon()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                codigo = row["codigo"].ToString(),
                porcentaje_descuento = int.Parse(row["porcentaje_descuento"].ToString()),
                fecha_registro = row["fecha_registro"].ToString(),
                fecha_caducidad = row["fecha_caducidad"].ToString(),
                estado = row["estado"].ToString()
            };

            return cupon;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var cupon = BuildObject(row);
                listResuts.Add(cupon);
            }
            return listResuts;
        }

        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var cup = new Cupon()
            {
                nombre = row["nombre"].ToString(),
                codigo = row["codigo"].ToString(),
                porcentaje_descuento = int.Parse(row["porcentaje_descuento"].ToString()),
                fecha_caducidad = row["fecha_caducidad"].ToString()
            };
            return cup;
        }

        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var cup = BuildObjectID(row);
                lstResults.Add(cup);
            }

            return lstResults;
        }
        #endregion
    }
}

