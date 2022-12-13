using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper.Laboratorios
{
    public class SedeMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos CRUD
        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearSede"
            };

            var sede = (Sede)entidadDTO;
            
            operation.AddVarcharParam("nombre", sede.nombre);
            
            operation.AddVarcharParam("provincia", sede.provincia);
            operation.AddVarcharParam("canton", sede.canton);
            operation.AddVarcharParam("distrito", sede.distrito);
            operation.AddVarcharParam("direccion", sede.direccion);
            operation.AddIntegerParam("id_laboratorio", sede.id_laboratorio);


            return operation;
        }

        public SqlOperation GetDeleteStatement(int idSede, int idLab)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EliminarSede"

            };
            operation.AddIntegerParam("id", idSede);
            operation.AddIntegerParam("id_Laboratorio", idLab);
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int idSede, int idLab)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerSedes"

            };
            operation.AddIntegerParam("idSede", idSede);
            operation.AddIntegerParam("idLab", idLab);
            return operation;
        }

        public SqlOperation GetUpdateStatement(int idSede, int idLab, EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EditarSede"
            };

            var sede = (Sede)entidadDTO;
            operation.AddIntegerParam("id", idSede);
            operation.AddIntegerParam("id_laboratorio", idLab);
            operation.AddVarcharParam("nombre", sede.nombre);
            operation.AddVarcharParam("provincia", sede.provincia);
            operation.AddVarcharParam("canton", sede.canton);
            operation.AddVarcharParam("distrito", sede.distrito);
            operation.AddVarcharParam("direccion", sede.direccion);


            return operation;
        }
        public SqlOperation GetDeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetAllRetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerSede"
            };

            operation.AddIntegerParam("idlab", id);

            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Object Mappers
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var sede = new Sede()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                provincia = row["provincia"].ToString(),
                canton = row["canton"].ToString(),
                distrito = row["distrito"].ToString(),
                direccion = row["direccion"].ToString(),
                fecha_registro = row["fecha_registro"].ToString(),
                id_laboratorio = int.Parse(row["id_laboratorio"].ToString()),
            };

            return sede;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {

            var listResuts = new List<EntidadBase>();
            foreach (var row in listRows)
            {
                var sede = BuildObject(row);
                listResuts.Add(sede);
            }
            return listResuts;
        }

        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var sede = new Sede()
            {
                nombre = row["nombre"].ToString(),
                provincia = row["provincia"].ToString(),
                canton = row["canton"].ToString(),
                distrito = row["distrito"].ToString(),
                direccion = row["direccion"].ToString()
            };


            return sede;
        }

        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var sede = BuildObjectID(row);
                lstResults.Add(sede);
            }

            return lstResults;
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
