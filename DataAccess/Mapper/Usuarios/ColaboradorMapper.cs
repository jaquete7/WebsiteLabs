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
    public class ColaboradorMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos CRUD
        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                //Crear procedure en base de datos
                ProcedureName = "SP_CrearColaborador"
            };

            var colaborador = (Colaborador)entidadDTO;
            operation.AddIntegerParam("id", colaborador.id);
            operation.AddVarcharParam("nombre", colaborador.nombre);
            operation.AddVarcharParam("email", colaborador.email);
            operation.AddVarcharParam("celular", colaborador.celular);
            operation.AddVarcharParam("password", colaborador.password);
            operation.AddVarcharParam("provincia", colaborador.provincia);
            operation.AddVarcharParam("canton", colaborador.canton);
            operation.AddVarcharParam("distrito", colaborador.distrito);
            operation.AddVarcharParam("direccion", colaborador.direccion);
            operation.AddVarcharParam("ruta_foto", colaborador.ruta_foto);
            operation.AddIntegerParam("laboratorioColab", colaborador.laboratorioColab);
            operation.AddIntegerParam("id_custom_rol", colaborador.id_custom_rol);
            operation.AddVarcharParam("permisos", colaborador.permisos);

            return operation;
        }

        public SqlOperation GetRetrieveAllStatement(int id)
        {
            var operation = new SqlOperation()
            {

                ProcedureName = "SP_ListarColaboradorProveedor"

            };

            operation.AddIntegerParam("idlab", id);
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
            var colaborador = new Colaborador()
            {
                id = int.Parse(row["id"].ToString()),
                nombre = row["nombre"].ToString(),
                id_custom_rol = int.Parse(row["id_custom_rol"].ToString()),
                fecha_registro = row["fecha_registro"].ToString(),
                permisos = row["permisos"].ToString(),
            };


            return colaborador;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var colaborador = BuildObject(row);
                lstResults.Add(colaborador);
            }

            return lstResults;
        }
        #endregion
    }
}
