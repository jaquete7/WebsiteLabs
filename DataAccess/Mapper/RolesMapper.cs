using DataAccess.DAO;
using DTO;
using DTO.Examenes;
using DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RolesMapper : ICrudStatements, IObjectMapper
    {
        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearRol"
            };

            var rol = (Roles)entidadDTO;
            operation.AddVarcharParam("nombre", rol.nombre);
            operation.AddVarcharParam("permisos", rol.permisos);
            operation.AddIntegerParam("laboratorio", rol.laboratorio);

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

        public SqlOperation GetUpdateStatement(int idlab, int idRol, EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EditarRol"
            };

            var rol = (Roles)entidadDTO;
            operation.AddIntegerParam("idrol", idRol);
            operation.AddIntegerParam("idlab", idlab);
            operation.AddVarcharParam("nombre", rol.nombre);
            operation.AddVarcharParam("permisos", rol.permisos);

            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int idLab, int idrol)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerRol"

            };
            operation.AddIntegerParam("idrol", idrol);
            operation.AddIntegerParam("idlab", idLab);
            return operation;
        }

        public SqlOperation GetDeleteStatement(int idLab, int idRol)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EliminarRol"

            };
            operation.AddIntegerParam("idrol", idRol);
            operation.AddIntegerParam("idlab", idLab);
            return operation;
        }
        public SqlOperation GetAllRetrieveByIdStatement(int id)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_ObtenerRoles"
            };
            operation.AddIntegerParam("idlab", id);
            return operation;
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var rol = new Roles()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                permisos = row["permisos"].ToString(),
                laboratorio = int.Parse(row["laboratorio"].ToString()),
            };

            return rol;
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

        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var rol = new Roles()
            {
                nombre = row["nombre"].ToString(),
                permisos = row["permisos"].ToString()
            };


            return rol;
        }

        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var rol = BuildObjectID(row);
                lstResults.Add(rol);
            }

            return lstResults;
        }
    }
}
