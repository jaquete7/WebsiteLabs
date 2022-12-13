using DataAccess.DAO;
using DTO;
using DTO.Usuarios;
using System;
using System.Collections.Generic;

namespace DataAccess.Mapper
{
    public class ProveedorMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos CRUD
        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearProveedor"
            };

            var proveedor = (Proveedor)entidadDTO;
            operation.AddIntegerParam("id", proveedor.id);
            operation.AddVarcharParam("nombre", proveedor.nombre);
            operation.AddVarcharParam("email", proveedor.email);
            operation.AddVarcharParam("celular", proveedor.celular);
            operation.AddVarcharParam("password", proveedor.password);
            operation.AddVarcharParam("provincia", proveedor.provincia);
            operation.AddVarcharParam("canton", proveedor.canton);
            operation.AddVarcharParam("distrito", proveedor.distrito);
            operation.AddVarcharParam("direccion", proveedor.direccion);
            operation.AddVarcharParam("ruta_foto", proveedor.ruta_foto);
            //operation.AddVarcharParam("", proveedor.rol);

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
        #endregion

        #region Object Mappers
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            throw new NotImplementedException();
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
