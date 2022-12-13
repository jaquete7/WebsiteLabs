using DataAccess.DAO;
using DataAccess.Mapper;
using DTO;
using DTO.Examenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class SistemaCrudFactory : CrudFactory
    {

        private DataSistemaMapper mapper;
        private ReporteDashboardMapper mapperD;

        //Implementeamos el contrusctor del padre
        public SistemaCrudFactory() : base()
        {
            mapper = new DataSistemaMapper();
            mapperD = new ReporteDashboardMapper();
            DAO = SqlDAO.GetInstance();
        }

        public override void Create(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
        public void CreateCitaPendiente(EntidadBase entityDTO)
        {
            var c = (CitaPendiente)entityDTO;
            var sqlOperation = mapper.GetCreateCitaPendiente(c);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }
        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveAllStatament());

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

        public void EditarMebresia(EntidadBase entityDTO)
        {
            var membresia = (DataSistema)entityDTO;
            var sqlOperation = mapper.GetUpdateStatementMembresia(membresia);
            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public void EditarIva(EntidadBase entityDTO)
        {
            var iva = (DataSistema)entityDTO;
            var sqlOperation = mapper.GetUpdateStatementIva(iva);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public List<T> RetrieveGetDataDashboard<T>()
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapperD.GetRetrieve());

            var dicc = new Dictionary<string, object>();
            if (listResult.Count > 0)
            {
                var objsDataSistema = mapperD.BuildObjects(listResult);
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

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public  List<T> RetrieveAllCitasById<T>(int id)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveAllCitasById(id));

            var dicc = new Dictionary<string, object>();
            if (listResult.Count > 0)
            {
                var objsCita = mapper.BuildObjectsCita(listResult);
                foreach (var cita in objsCita)
                {
                    list.Add((T)Convert.ChangeType(cita, typeof(T)));
                }
            }
            return list;
        }
    }
}
