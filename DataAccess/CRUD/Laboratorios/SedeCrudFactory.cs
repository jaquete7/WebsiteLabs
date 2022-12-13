using DataAccess.DAO;
using DataAccess.Mapper.Laboratorios;
using DTO;
using System;
using System.Collections.Generic;

namespace DataAccess.CRUD.Laboratorios
{
    public class SedeCrudFactory : CrudFactory
    {
        private SedeMapper mapper;
        public SedeCrudFactory() : base()
        {
            mapper = new SedeMapper();
            DAO = SqlDAO.GetInstance();
        }

        public override void Create(EntidadBase entityDTO)
        {
            var sede = (Sede)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(sede);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public void Eliminar(int idSede, int idLab)
        {
            var sqlOperation = mapper.GetDeleteStatement(idSede, idLab);
            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public List<T> RetrieveBySede<T>(int idSede, int idLab)
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByIdStatement(idSede, idLab));

            var Dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objSede = mapper.BuildObjectsID(listResult);

                foreach (var c in objSede)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;

        }

        public void Editar(int idSede, int idLab, EntidadBase entityDTO)
        {
            var sede = (Sede)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(idSede, idLab, sede);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public  List<T> RetrieveAllBySede<T>(int id)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetAllRetrieveByIdStatement(id));
            var dicc = new Dictionary<string, object>();

             if (listResult.Count > 0)
            {
                var objsPedido = mapper.BuildObjects(listResult);

                foreach (var c in objsPedido)
                {   //convierto objeto tipo Entidad Base a tipo T
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;

           
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
