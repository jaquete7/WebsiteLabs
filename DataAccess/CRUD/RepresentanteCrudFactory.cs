using DataAccess.DAO;
using DataAccess.Mapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class RepresentanteCrudFactory : CrudFactory
    {
        private RepresentanteMapper mapper;

        //Implementeamos el contrusctor del padre
        public RepresentanteCrudFactory() : base()
        {
            mapper = new RepresentanteMapper();
            DAO = SqlDAO.GetInstance();
        }

        public override void Create(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
        public  List<T> RetrieveAllByLab<T>(int id)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByIdStatement(id));
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

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
