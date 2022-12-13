using DataAccess.DAO;
using DataAccess.Mapper.Usuarios;
using DTO;
using DTO.Usuarios;
using System;
using System.Collections.Generic;

namespace DataAccess.CRUD
{
    public class PacienteCrudFactory : CrudFactory
    {
        private PacienteMapper mapper;
        private ReporteDashboardPacienteMapper mapperD;

        //Implementeamos el contrusctor del padre
        public PacienteCrudFactory() : base()
        {
            mapper = new PacienteMapper();
            mapperD = new ReporteDashboardPacienteMapper();
            DAO = SqlDAO.GetInstance();
        }


        public override void Create(EntidadBase entityDTO)
        {
            var paciente = (Paciente)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(paciente);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public List<T> RetrieveGetDataMesesPaciente<T>(int idUsua)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapperD.GetRetrieveMesesPaciente(idUsua));

            var dicc = new Dictionary<string, object>();
            if (listResult.Count > 0)
            {
                var objsDataSistema = mapperD.BuildObjectsMesesPacienteID(listResult);
                foreach (var dataSistema in objsDataSistema)
                {
                    list.Add((T)Convert.ChangeType(dataSistema, typeof(T)));
                }
            }
            return list;
        }

        public List<T> RetrieveGetDataDashboard<T>(int idUsua)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapperD.GetRetrieve(idUsua));

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
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByIdStatement(Id));
            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objsPedido = mapper.BuildObjects(listResult);

                foreach (var c in objsPedido)
                {   //convierto objeto tipo Entidad Base a tipo T
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list[0];
        }

        public override void Update(EntidadBase entityDTO)
        {
            var paciente = (Paciente)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(paciente);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public void UpdateEstado(EntidadBase entityDTO)
        {
            var paciente = (Paciente)entityDTO;
            var sqlOperation = mapper.GetUpdateStatementEstado(paciente);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }
    }
}
