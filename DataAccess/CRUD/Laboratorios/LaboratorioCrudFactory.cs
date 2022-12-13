using DataAccess.DAO;
using DataAccess.Mapper.Laboratorios;
using DTO;
using DTO.Laboratorios;
using System;
using System.Collections.Generic;

namespace DataAccess.CRUD.Laboratorios
{
    public class LaboratorioCrudFactory : CrudFactory
    {
        private LaboratorioMapper mapper;
        public LaboratorioCrudFactory() : base()
        {
            mapper = new LaboratorioMapper();
            DAO = SqlDAO.GetInstance();
        }

        public override void Create(EntidadBase entityDTO)
        {
            var laboratorio = (Laboratorio)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(laboratorio);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveAllStatement());

            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objsPedido = mapper.BuildObjects(listResult);

                foreach (var c in objsPedido)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return list;
        }

        public List<T> RetrieveAllById<T>(int idProv)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetAllRetrieveByIdStatement(idProv));

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

        public override T RetrieveById<T>(int Id)
        {
            throw new NotImplementedException();
        }
        public List<T> RetrieveRepresentante<T>(int idLab)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRepresentante(idLab));

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

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int idLab, int idProv)
        {
            var sqlOperation = mapper.GetDeleteStatement(idLab, idProv);
            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public List<T> RetrieveByLaboratorio<T>(int idLab, int idProv)
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByIdStatement(idLab, idProv));

            var Dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objLaboratorio = mapper.BuildObjectsID(listResult);

                foreach (var c in objLaboratorio)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public void Editar(int idLab, int idProv, EntidadBase entityDTO)
        {
            var laboratorio = (Laboratorio)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(idLab, idProv, laboratorio);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }
    }
}
