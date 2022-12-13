using DataAccess.DAO;
using DataAccess.Mapper.Cupones;
using DTO;
using DTO.Cupones;
using System;
using System.Collections.Generic;

namespace DataAccess.CRUD.Cupones
{
    public class CuponCrudFactory : CrudFactory
    {
        private CuponMapper mapper;
        public CuponCrudFactory() : base()
        {
            mapper = new CuponMapper();
            DAO = SqlDAO.GetInstance();
        }

        public override void Create(EntidadBase entityDTO)
        {
            var cupon = (Cupon)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(cupon);

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

        public List<T> RetrieveAllByLab<T>(int Id)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetAllRetrieveByIdStatement(Id));

            var dicc = new Dictionary<string, object>();
            if (listResult.Count > 0)
            {
                var objsDataSistema = mapper.BuildObjects(listResult);
                foreach (var dataSistema in objsDataSistema)
                {
                    list.Add((T)Convert.ChangeType(dataSistema, typeof(T)));
                }
            }
            return list;
        }

        public List<T> RetrieveByCupon<T>(int idCup, int idLab)
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByIdStatement(idCup, idLab));

            var Dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objCup = mapper.BuildObjectsID(listResult);

                foreach (var c in objCup)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;

        }

        public void Eliminar(int idCup, int idLab)
        {
            var sqlOperation = mapper.GetDeleteStatement(idCup, idLab);
            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public override T RetrieveById<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public void Editar(int idCup, int idLab, EntidadBase entityDTO)
        {
            var cupon = (Cupon)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(idCup, idLab, cupon);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }
    }
}
