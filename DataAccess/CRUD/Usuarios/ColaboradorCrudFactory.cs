using DataAccess.DAO;
using DataAccess.Mapper;
using DTO;
using DTO.Usuarios;
using System;
using System.Collections.Generic;


namespace DataAccess.CRUD
{
    public class ColaboradorCrudFactory : CrudFactory
    {

        private ColaboradorMapper mapper;

        //Implementeamos el contrusctor del padre
        public ColaboradorCrudFactory() : base()
        {
            mapper = new ColaboradorMapper();
            DAO = SqlDAO.GetInstance();
        }


        public override void Create(EntidadBase entityDTO)
        {
            var colaborador = (Colaborador)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(colaborador);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public List<T> RetrieveAll<T>(int id)
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveAllStatement(id));

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

        public override T RetrieveById<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
