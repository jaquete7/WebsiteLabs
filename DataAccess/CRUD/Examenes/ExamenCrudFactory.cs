using DataAccess.DAO;
using DataAccess.Mapper;
using DataAccess.Mapper.Examenes;
using DTO.Usuarios;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Examenes;

namespace DataAccess.CRUD.Examenes
{
    public class ExamenCrudFactory : CrudFactory
    {
        private ExamenMapper mapper;

        //Implementeamos el contrusctor del padre
        public ExamenCrudFactory() : base()
        {
            mapper = new ExamenMapper();
            DAO = SqlDAO.GetInstance();
        }
        public override void Create(EntidadBase entityDTO)
        {
            var examen = (Examen)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(examen);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public void Eliminar(int idLab, string idExam)
        { 
            var sqlOperation = mapper.GetDeleteStatement(idLab,idExam);
            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public  List<T> RetrieveAll<T>(int idlab)
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveAllStatement(idlab));

            var Dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objExamen = mapper.BuildObjects(listResult);

                foreach (var c in objExamen)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveByExamen<T>(int Idlab,string IdExam)
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByIdStatement(Idlab,IdExam));

            var Dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objExamen = mapper.BuildObjectsID(listResult);

                foreach (var c in objExamen)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;

        }



        public void Editar(int idlab, string id, EntidadBase entityDTO)
        {
            var examen = (Examen)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(idlab,id,examen);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
