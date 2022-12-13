using DataAccess.DAO;
using DataAccess.Mapper;
using DTO;
using DTO.Usuarios;
using System;
using System.Collections.Generic;


namespace DataAccess.CRUD
{
    public class ProveedorCrudFactory : CrudFactory
    {

        private ProveedorMapper mapper;
        private ReporteDashboardProveedorMapper mapperD;

        //Implementeamos el contrusctor del padre
        public ProveedorCrudFactory() : base()
        {
            mapper = new ProveedorMapper();
            mapperD = new ReporteDashboardProveedorMapper();
            DAO = SqlDAO.GetInstance();
        }


        public override void Create(EntidadBase entityDTO)
        {
            var proveedor = (Proveedor)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(proveedor);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public List<T> RetrieveGetDataDashboard<T>(int idLab)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapperD.GetRetrieve(idLab));

            var dicc = new Dictionary<string, object>();
            if (listResult.Count > 0)
            {
                var objsDataSistema = mapperD.BuildObjectsID(listResult);
                foreach (var dataSistema in objsDataSistema)
                {
                    list.Add((T)Convert.ChangeType(dataSistema, typeof(T)));
                }
            }
            return list;
        }

        public List<T> RetrieveGetDataMeses<T>(int idLab)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapperD.GetRetrieveMeses(idLab));

            var dicc = new Dictionary<string, object>();
            if (listResult.Count > 0)
            {
                var objsDataSistema = mapperD.BuildObjectsMesesID(listResult);
                foreach (var dataSistema in objsDataSistema)
                {
                    list.Add((T)Convert.ChangeType(dataSistema, typeof(T)));
                }
            }
            return list;
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
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
