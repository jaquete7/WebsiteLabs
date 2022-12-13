using DataAccess.DAO;
using DTO.Usuarios;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Examenes;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;

namespace DataAccess.Mapper.Examenes
{
    public class ExamenMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos CRUD
        public SqlOperation GetCreateStatement(EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_CrearExamen"
            };

            var examen = (Examen)entidadDTO;
            operation.AddIntegerParam("id_laboratorio", examen.id_laboratorio);
            operation.AddVarcharParam("nombre", examen.nombre);
            operation.AddVarcharParam("descripcion", examen.descripcion);
            operation.AddFloatParam("precio", examen.precio);
            operation.AddVarcharParam("recomendaciones", examen.recomendaciones);
            operation.AddVarcharParam("datos_evaluados", examen.datos_evaluados);
            operation.AddVarcharParam("idExamen", examen.idExamen);

            return operation;
        }

        public SqlOperation GetDeleteStatement(int idLab, string idExam)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EliminarExamen"

            };
            operation.AddVarcharParam("idexam", idExam);
            operation.AddIntegerParam("idlab", idLab);
            return operation;
        }

        public SqlOperation GetRetrieveByIdStatement(int idLab,string idExam)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SeleccionarExamen"

            };
            operation.AddVarcharParam("idExamen", idExam);
            operation.AddIntegerParam("idlab", idLab);
            return operation;
        }

        public SqlOperation GetRetrieveAllStatement(int idlab)
        {
            var operation = new SqlOperation()
            {             
            
                ProcedureName = "SP_DevolverExamenes"
             
            };
            operation.AddIntegerParam("idlab",idlab);

            return operation;
        }

        public SqlOperation GetUpdateStatement(int idlab, string idExam, EntidadBase entidadDTO)
        {
            var operation = new SqlOperation()
            {
                ProcedureName = "SP_EditarExamen"
            };

            var examen = (Examen)entidadDTO;
            operation.AddVarcharParam("ExamenId", idExam);
            operation.AddIntegerParam("id_laboratorio", idlab);
            operation.AddVarcharParam("nombre", examen.nombre);
            operation.AddVarcharParam("descripcion", examen.descripcion);
            operation.AddFloatParam("precio", examen.precio);
            operation.AddVarcharParam("recomendaciones", examen.recomendaciones);
            operation.AddVarcharParam("datos_evaluados", examen.datos_evaluados);
            operation.AddVarcharParam("idExamen", examen.idExamen);

            return operation;
        }
        #endregion

        #region Object Mappers
        public EntidadBase BuildObject(Dictionary<string, object> row)
        {
            var examen = new Examen()
            {
                id_laboratorio = int.Parse(row["id_laboratorio"].ToString()),
                nombre = row["nombre"].ToString(),
                descripcion = row["descripcion"].ToString(),
                precio = float.Parse(row["precio"].ToString()),
                recomendaciones = row["recomendaciones"].ToString(),
                datos_evaluados = row["datos_evaluados"].ToString(),
                fecha_registro = row["fecha_registro"].ToString(),
                idExamen = row["idExamen"].ToString(),
                id = int.Parse(row["id"].ToString()),
            };


            return examen;
        }
        public EntidadBase BuildObjectID(Dictionary<string, object> row)
        {
            var examen = new Examen()
            {
                nombre = row["nombre"].ToString(),
                descripcion = row["descripcion"].ToString(),
                precio = float.Parse(row["precio"].ToString()),
                recomendaciones = row["recomendaciones"].ToString(),
                datos_evaluados = row["datos_evaluados"].ToString(),
                fecha_registro = row["fecha_registro"].ToString(),
                idExamen = row["idExamen"].ToString(),
            };


            return examen;
        }

        public List<EntidadBase> BuildObjectsID(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var examen = BuildObjectID(row);
                lstResults.Add(examen);
            }

            return lstResults;
        }

        public List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows)
        {
            var lstResults = new List<EntidadBase>();

            foreach (var row in listRows)
            {
                var examen = BuildObject(row);
                lstResults.Add(examen);
            }

            return lstResults;
        }

        public SqlOperation GetRetrieveByIdStatement(int id)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetUpdateStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation GetDeleteStatement(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
